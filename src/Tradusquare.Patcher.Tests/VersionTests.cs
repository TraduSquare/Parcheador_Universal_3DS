namespace Tradusquare.Patcher.Tests
{
    using NUnit.Framework;
    using Tradusquare.Patcher;

    public class Tests
    {
        [Test]
        public void TestVersionNotNull()
        {
            Assert.That(LibVersion.GetVersion(), Is.Not.Null);
        }
    }
}
