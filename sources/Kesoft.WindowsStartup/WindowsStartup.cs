using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace Kesoft.WindowsStartup
{
    /// <summary>
    /// 设置自启动帮助类。
    /// </summary>
    public static class WindowsStartup
    {
        private const string keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// 设置自启动。
        /// </summary>
        /// <param name="fileName">全路径可执行文件名称。</param>
        /// <param name="autoStart">是否自启动。</param>
        public static void Set(string fileName, bool autoStart)
        {
            var lm = Registry.LocalMachine;
            var key = lm.OpenSubKey(keyName, true);
            if (key == null) lm.CreateSubKey(keyName);
            key = lm.OpenSubKey(keyName, true);
            if (key != null)
            {
                var name = Path.GetFileName(fileName);
                if (name != null)
                {
                    if (autoStart) key.SetValue(name, fileName);
                    else key.DeleteValue(name);
                    lm.Close();
                }
            }
        }

        /// <summary>
        /// 是否已设置自启动。
        /// </summary>
        /// <param name="fileName">全路径可执行文件名称。</param>
        /// <returns>是返回true否则返回false。</returns>
        public static bool IsStartup(string fileName)
        {
            var name = Path.GetFileName(fileName);
            if (name != null)
            {
                var lm = Registry.LocalMachine;
                var key = lm.OpenSubKey(keyName);
                if (key != null)
                {
                    key = lm.OpenSubKey(keyName);
                    if (key != null)
                    {
                        var value = key.GetValue(name);
                        lm.Close();
                        if ((string) value == fileName)
                            return true;
                    }
                }
            }

            return false;
        }
    }
}