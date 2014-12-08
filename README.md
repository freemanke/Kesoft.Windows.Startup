# Windows系统应用程序开机自启动帮助 #

## 代码内实现 ##

在WindowsStartup.cs文件中实现

## 安装脚本实现 ##
在安装脚本文件setup.iss中添加注册表操作段
> [Run]
;添加安装完成后启动程序项
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

