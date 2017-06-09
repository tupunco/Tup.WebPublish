# ASP.NET 发布打包工具

## 介绍
调用 `MSBuild` 直接编译发布 `ASP.NET` 项目. 根据 `输出目录` 内文件时间筛选出 `增量更新` 文件.

## 配置
DefaultCatalog.xml
```xml
<ArrayOfCatalog xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Catalog>         <!--待打包站点目录-->
    <Id>1</Id>      <!--站点 ID, 手动自增-->
    <Name>WebApp</Name>                                                <!--站点 名称, 自定义-->
    <SrcProjectFile>E:\Work\WebApp\WebApp.csproj</SrcProjectFile>      <!--站点源 csproj 文件-->
    <SrcFolder>E:\Work\发布\WebApp</SrcFolder>                          <!--站点发布源目录-->
    <OutFolder>E:\Work\发布\WebApp_copy</OutFolder>                     <!--站点发布输出目录(最终增量更新文件)-->
    <LastPublishTime>2016-06-01T00:00:00.0000001+08:00</LastPublishTime>   <!--当前站点上次打包时间-->
  </Catalog>

</ArrayOfCatalog>
```

