using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class BicepModelReaderWriterOptionsTests
    {
        [Test]
        public void FormatIsSetToBicep()
        {
            BicepModelReaderWriterOptions options = new BicepModelReaderWriterOptions();
            Assert.AreEqual("bicep", options.Format);
        }

        [Test]
        public void ParameterOverridesIsInitialized()
        {
            BicepModelReaderWriterOptions options = new BicepModelReaderWriterOptions();
            Assert.IsNotNull(options.PropertyOverrides);
        }
    }
}
