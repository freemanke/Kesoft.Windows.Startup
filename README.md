# Windows系统下应用程序开机自启动帮助
开发好的Windows系统下的应用程序经常需要随系统自动启动，该帮助项目提供了代码和脚本两种方式来实现该功能。

## 如何下载

1. 代码实现的可以通过nuget下载：[http://www.nuget.org/packages/Kesoft.WindowsStartup/](http://www.nuget.org/packages/Kesoft.WindowsStartup/ "Kesoft.WindowsStartup")
2. 安装脚本实现可以直接下载并修改源代码中的脚本文件:[https://github.com/guang810828/kesoft.windowsstartup/blob/master/setup.iss](https://github.com/guang810828/kesoft.windowsstartup/blob/master/setup.iss "Setup.iss")

## 如何使用

### 使用代码方式

使用代码方式只要在程序中调用帮助类的方法即可，例如：

<!-- lang:c# --> 
    [TestFixture]
    class WindowsStartupTest
    {
        [Test]
        public void Set()
        {
            var fileName = Assembly.GetAssembly(GetType()).Location;
            WindowsStartup.Set(fileName, true);
            Assert.IsTrue(WindowsStartup.IsStartup(fileName));
            WindowsStartup.Set(fileName, false);
            Assert.IsFalse(WindowsStartup.IsStartup(fileName));
        }
    }

### 使用安装脚本方式
<!-- lang: c# --> 
    [Registry]
    ;添加开机自启动注册表项
    Root: HKLM; Subkey: SOFTWARE\Microsoft\Windows\CurrentVersion\Run; ValueType: string; ValueName: {#MyAppName}; ValueData: {app}\{#MyAppExeName}; Flags: uninsdeletevalue

