using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class AzureResourceManagerClientOptionsTests
    {
        [TestCase]
        public void VersionIsDefault()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            Assert.AreEqual(FakeResourceApiVersions.Default, options.FakeRpApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void MultiClientSeparateVersions()
        {
            AzureResourceManagerClientOptions options1 = new AzureResourceManagerClientOptions();
            AzureResourceManagerClientOptions options2 = new AzureResourceManagerClientOptions();

            options2.FakeRpApiVersions().FakeResourceVersion = FakeResourceApiVersions.V2019_12_01;
            Assert.AreEqual(FakeResourceApiVersions.Default, options1.FakeRpApiVersions().FakeResourceVersion);
            Assert.AreEqual(FakeResourceApiVersions.V2019_12_01, options2.FakeRpApiVersions().FakeResourceVersion);
        }
    }
}
