using System;
using System.Collections.Generic;

namespace Tup.WebPublish
{
    /// <summary>
    /// 路径 实体
    /// </summary>
    public class Catalog
    {
        /// <summary>
        ///
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 目录名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 源项目文件
        /// </summary>
        public string SrcProjectFile { get; set; }

        /// <summary>
        /// 源文件夹/编译目标文件夹
        /// </summary>
        public string SrcFolder { get; set; }

        /// <summary>
        /// 输出文件夹/Copy目标文件夹
        /// </summary>
        public string OutFolder { get; set; }

        /// <summary>
        /// 最后发布时间
        /// </summary>
        public DateTime LastPublishTime { get; set; }
    }

    /// <summary>
    /// PathNode
    /// </summary>
    public class PathNode
    {
        /// <summary>
        /// 子节点
        /// </summary>
        public List<PathNode> ChildNodes { get; set; }

        /// <summary>
        /// 是否文件
        /// </summary>
        public bool IsFile { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件全名, 包括路径
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 扩展名(文件有效)
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 父级路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 相对路径
        /// </summary>
        public string RelativePath { get; set; }

        /// <summary>
        /// 获取或设置上次写入当前文件或目录的时间
        /// </summary>
        public DateTime LastWriteTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PathNode Name:{0}, FullName:{1}, IsFile:{2}, Extension:{3}, Path:{4}, RelativePath:{5}, LastWriteTime:{6}]",
                                    this.Name, this.FullName, this.IsFile, this.Extension,
                                    this.Path, this.RelativePath, this.LastWriteTime);
        }
    }
}