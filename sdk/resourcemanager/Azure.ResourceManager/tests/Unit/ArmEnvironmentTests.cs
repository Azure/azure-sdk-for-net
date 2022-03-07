using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ArmEnvironmentTests
    {
        [TestCase]
        public void BaseUriNotNull()
        {
            Assert.Throws<ArgumentNullException>(() => { new ArmEnvironment(default, "https://management.azure.com"); });
        }

        [TestCase]
        public void AudienceNotNullOrWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => { new ArmEnvironment(new Uri("https://management.azure.com/"), null); });
            Assert.Throws<ArgumentNullException>(() => { new ArmEnvironment(new Uri("https://management.azure.com/"), default); });
            Assert.Throws<ArgumentException>(() => { new ArmEnvironment(new Uri("https://management.azure.com/"), " "); });
        }

        [TestCase]
        public void DefaultValueIsNull()
        {
            var defaultValue = default(ArmEnvironment);
            Assert.IsNull(defaultValue.BaseUri);
            Assert.IsNull(defaultValue.Audience);
            Assert.IsNull(defaultValue.DefaultScope);
        }

        [TestCase]
        public void DefaultScope()
        {
            Assert.AreEqual("https://management.azure.com//.default", ArmEnvironment.AzureCloud.DefaultScope);
            Assert.AreEqual("https://management.chinacloudapi.cn/.default", ArmEnvironment.AzureChinaCloud.DefaultScope);
            Assert.AreEqual("https://management.usgovcloudapi.net/.default", ArmEnvironment.AzureUSGovernment.DefaultScope);
            Assert.AreEqual("https://management.microsoftazure.de/.default", ArmEnvironment.AzureGermanCloud.DefaultScope);
            Assert.AreEqual("https://foo.com/.default", new ArmEnvironment(new Uri("https://foo.com"), "https://foo.com").DefaultScope);
        }
    }
}
