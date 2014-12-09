using System.Reflection;
using NUnit.Framework;

namespace Kesoft.Windows.Startup.Tests
{
    [TestFixture]
    internal class StartupTest
    {
        [Test]
        public void Set()
        {
            var fileName = Assembly.GetAssembly(GetType()).Location;
            Startup.Set(fileName, true);
            Assert.IsTrue(Startup.IsStartup(fileName));
            Startup.Set(fileName, false);
            Assert.IsFalse(Startup.IsStartup(fileName));
        }
    }
}