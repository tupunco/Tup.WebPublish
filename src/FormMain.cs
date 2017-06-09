using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tup.WebPublish
{
    public partial class FormMain : Form
    {
        private List<Catalog> DefaultCatalog = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DefaultCatalog = XmlSerializeHelper.DeserializeFromXml<List<Catalog>>("DefaultCatalog.xml");

            this.DefaultBindingSource.DataSource = DefaultCatalog;
        }

        private void TreeViewOutFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGo_Click(object sender, EventArgs e)
        {
            var catalog = this.DefaultBindingSource.Current as Catalog;
            if (catalog == null)
                return;

            this.ButtonGo.Enabled = false;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    if (!Directory.Exists(catalog.SrcFolder))
                        Directory.CreateDirectory(catalog.SrcFolder);

                    //1.尝试编译项目
                    if (!string.IsNullOrEmpty(catalog.SrcProjectFile)
                            && File.Exists(catalog.SrcProjectFile))
                    {
                        Msg("编译项目:{0}...", catalog.SrcProjectFile);
                        var buildRes = ExecuteAction("pub.bat",
                            string.Format(" {0} {1}", catalog.SrcProjectFile, catalog.SrcFolder),
                            msg => Msg(msg));
                        buildRes.Wait();
                        Msg("编译项目-结束-MSG:{0}...", buildRes.Result);   
                    }

                    //2.遍历输出目录
                    Msg("遍历目录:{0}...", catalog.SrcFolder);
                    PathNode fileNode = null;
                    Dir(catalog.SrcFolder, new DirectoryInfo(catalog.SrcFolder), ref fileNode);

                    var outFolderPath = catalog.OutFolder;

                    var outFolderParentDir = Directory.GetParent(outFolderPath);
                    if (!outFolderParentDir.Exists)
                        Directory.CreateDirectory(outFolderParentDir.FullName);

                    if (Directory.Exists(outFolderPath))
                        Directory.Delete(outFolderPath, true);

                    //3.Copy 需要文件到发布目录
                    Msg("Copy 目录:{0}...", outFolderPath);
                    Copy(outFolderPath, fileNode, catalog.LastPublishTime);
                    Msg("...发布结束...");

                    //4.展示发布目录
                    Msg("遍历输出目录:{0}...", outFolderPath);
                    PathNode outFileNode = null;
                    Dir(outFolderPath, new DirectoryInfo(outFolderPath), ref outFileNode);

                    //5.打开发布目录
                    ProcessStart(outFolderPath);

                    this.BeginInvoke(() =>
                    {
                        BindPathTreeView(this.TreeViewOutFolder, outFileNode);
                    });
                }
                catch (Exception ex)
                {
                    Msg("***异常:{0}", ex);
                }
                finally
                {
                    this.BeginInvoke(() =>
                    {
                        this.ButtonGo.Enabled = true;
                    });
                }
            });
        }

        #region 绑定 TreeView

        /// <summary>
        ///
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="rootFileNode"></param>
        private static void BindPathTreeView(TreeView treeView, PathNode rootFileNode)
        {
            if (treeView == null || rootFileNode == null)
                return;

            var treeNode = treeView.Nodes;
            treeView.Enabled = false;
            treeView.BeginUpdate();
            treeNode.Clear();

            var rootNode = new TreeNode() { Text = rootFileNode.Name, };
            treeNode.Add(rootNode);
            BindPathTreeNode(rootNode, rootFileNode);

            treeView.EndUpdate();
            treeView.ExpandAll();
            treeView.Enabled = true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="rootFileNode"></param>
        private static void BindPathTreeNode(TreeNode rootNode, PathNode rootFileNode)
        {
            if (rootNode == null || rootFileNode == null)
                return;

            if (rootFileNode.IsFile)
                throw new SystemException();

            var childNodes = rootFileNode.ChildNodes;
            if (childNodes == null || childNodes.Count <= 0)
                return;

            rootNode.Text = rootFileNode.Name;

            TreeNode tTreeNode = null;
            foreach (var fileItem in childNodes)
            {
                tTreeNode = new TreeNode()
                {
                    Text = fileItem.Name,
                    ToolTipText = fileItem.FullName,
                };
                rootNode.Nodes.Add(tTreeNode);

                if (!fileItem.IsFile)
                {
                    BindPathTreeNode(tTreeNode, fileItem);
                }
            }
        }

        #endregion 绑定 TreeView

        #region 目录操作

        /// <summary>
        /// Copy 文件
        /// </summary>
        /// <param name="outFolder"></param>
        /// <param name="rootFileNode"></param>
        /// <param name="lastPublishTime"></param>
        /// <param name="rootOutFileNode"></param>
        private static void Copy(string outFolder, PathNode rootFileNode, DateTime lastPublishTime)
        {
            if (outFolder == null || rootFileNode == null)
                return;

            if (rootFileNode.IsFile)
                throw new SystemException();

            var childNodes = rootFileNode.ChildNodes;
            if (childNodes == null || childNodes.Count <= 0)
                return;

            var outFolderPath = string.Empty;
            var outFileFilePath = string.Empty;
            foreach (var fileItem in childNodes)
            {
                if (!fileItem.IsFile)
                {
                    Copy(outFolder, fileItem, lastPublishTime);
                    continue;
                }

                if (fileItem.LastWriteTime >= lastPublishTime)
                {
                    outFolderPath = string.Format(@"{0}{1}\", outFolder, fileItem.RelativePath);
                    outFileFilePath = Path.Combine(outFolderPath, fileItem.Name);

                    if (!Directory.Exists(outFolderPath))
                        Directory.CreateDirectory(outFolderPath);

                    File.Copy(fileItem.FullName, outFileFilePath, true);
                }
            }
        }

        /// <summary>
        /// 遍历目录
        /// </summary>
        /// <param name="srcFolder"></param>
        /// <param name="rootDir"></param>
        /// <param name="fileNode"></param>
        private static void Dir(string srcFolder, DirectoryInfo rootDir, ref PathNode fileNode)
        {
            if (srcFolder == null || rootDir == null)
                return;

            var sLen = srcFolder.Length;
            var childNodes = new List<PathNode>();
            fileNode = new PathNode()
            {
                Name = rootDir.Name,
                FullName = rootDir.FullName,
                IsFile = false,
                Path = rootDir.FullName,
                ChildNodes = childNodes,
            };
            var rPathIndex = fileNode.Path.Length - sLen;
            fileNode.RelativePath = rPathIndex > 0 ? fileNode.Path.Substring(sLen, rPathIndex) : @"\";

            //忽略 隐藏文件
            var dirs = rootDir.GetDirectories().Where(x => (x.Attributes & FileAttributes.Hidden) == 0).ToArray();
            var files = rootDir.GetFiles().Where(x => (x.Attributes & FileAttributes.Hidden) == 0).ToArray();
            if (dirs.Length <= 0 && files.Length <= 0)
                return;

            PathNode nfileNode = null;
            foreach (var dir in dirs)
            {
                Dir(srcFolder, dir, ref nfileNode);

                childNodes.Add(nfileNode);
            }

            PathNode tFile = null;
            foreach (var file in files)
            {
                tFile = new PathNode()
                {
                    IsFile = true,
                    Extension = file.Extension,
                    FullName = file.FullName,
                    Name = file.Name,
                    Path = Path.GetDirectoryName(file.FullName),
                    LastWriteTime = file.LastWriteTime,
                };

                rPathIndex = tFile.Path.Length - sLen;
                tFile.RelativePath = rPathIndex > 0 ? fileNode.Path.Substring(sLen, rPathIndex) : @"\";

                childNodes.Add(tFile);
            }
        }

        #endregion 目录操作

        #region 文件夹选择

        /// <summary>
        /// 文件夹选择
        /// </summary>
        /// <param name="folderTextBox"></param>
        private void FolderBrowser(TextBox folderTextBox)
        {
            var srcFolder = folderTextBox.Text;
            var folder = new FolderBrowserDialog();
            if (!string.IsNullOrEmpty(srcFolder) && Directory.Exists(srcFolder))
                folder.SelectedPath = srcFolder;

            folder.ShowNewFolderButton = true;
            var res = folder.ShowDialog(this);
            if (res == DialogResult.OK)
                folderTextBox.Text = folder.SelectedPath;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelectSrcFolder_Click(object sender, EventArgs e)
        {
            Msg("TODO__ButtonSelectSrcFolder_Click__DO...");

            FolderBrowser(this.TextBoxSrcFolder);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelectOutFolder_Click(object sender, EventArgs e)
        {
            Msg("TODO__ButtonSelectOutFolder_Click__DO...");

            FolderBrowser(this.TextBoxOutFolder);
        }

        #endregion 文件夹选择

        #region Msg

        /// <summary>
        /// BeginInvoke
        /// </summary>
        /// <param name="action"></param>
        public void BeginInvoke(Action action)
        {
            if (action == null)
                return;

            base.BeginInvoke(action);
        }

        /// <summary>
        /// Msg
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        private void Msg(string format, params object[] args)
        {
            if (string.IsNullOrEmpty(format))
                return;

            Msg(string.Format(format, args));
        }

        /// <summary>
        /// Msg
        /// </summary>
        /// <param name="msg"></param>
        private void Msg(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return;

            this.BeginInvoke(new Action(() =>
            {
                this.TextBoxMsg.AppendText(string.Format("{0}\r\n", msg));
            }));
        }

        #endregion Msg

        /// <summary>
        /// Process Start
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool ProcessStart(string path, string arguments = null)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(path, "path");

            try
            {
                if (string.IsNullOrEmpty(arguments))
                    Process.Start(path);
                else
                    Process.Start(path, arguments);

                return false;
            }
            catch (Exception ex)
            {
                Msg("HostHelper-ProcessStart-path:{0}-ex:{1}", path, ex);
                //LogHelper.Error("HostHelper-ProcessStart-path:{0}-ex:{1}", path, ex);
                return false;
            }
        }

        /// <summary>
        /// Execute Command Action
        /// </summary>
        /// <param name="startFileName"></param>
        /// <param name="startFileArg"></param>
        /// <param name="msgAction"></param>
        /// <returns></returns>
        private static Task<bool> ExecuteAction(string startFileName, string startFileArg, Action<string> msgAction)
        {
            ThrowHelper.ThrowIfNull(msgAction, "msgAction");
            ThrowHelper.ThrowIfNull(startFileName, "startFileName");
            ThrowHelper.ThrowIfNull(startFileArg, "startFileArg");

            var cmdProcess = new Process();
            var si = cmdProcess.StartInfo;
            si.FileName = startFileName;      // 命令
            si.Arguments = startFileArg;      // 参数

            si.CreateNoWindow = true;         // 不创建新窗口
            si.UseShellExecute = false;
            si.RedirectStandardInput = true;  // 重定向输入
            si.RedirectStandardOutput = true; // 重定向标准输出
            si.RedirectStandardError = true;  // 重定向错误输出
            //si.WindowStyle = ProcessWindowStyle.Hidden;

            var tcs = new TaskCompletionSource<bool>();
            cmdProcess.OutputDataReceived += (sender, e) => msgAction(e.Data);
            cmdProcess.ErrorDataReceived += (sender, e) => msgAction(e.Data);

            cmdProcess.EnableRaisingEvents = true; // 启用Exited事件
            cmdProcess.Exited += (sender, e) => tcs.SetResult(true);

            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();

            return tcs.Task.ContinueWith<bool>(t =>
            {
                cmdProcess.Close();
                cmdProcess.Dispose();
                cmdProcess = null;
                return true;
            });
        }
    }
}