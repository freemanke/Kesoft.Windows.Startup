using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Kesoft.WindowsStartup.Tests
{
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
}
