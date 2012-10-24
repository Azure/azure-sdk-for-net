using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.WindowsAzure.Storage
{
    public class TestConfigurations
    {
        public static readonly string DefaultTestConfigFilePath = @"TestConfigurations.xml";
        public string TargetTenantName { get; internal set; }
        public List<TenantConfiguration> TenantConfigurations { get; internal set; }

        public static TestConfigurations ReadFromXml(XDocument testConfigurationsDoc)
        {
            XElement testConfigurationsElement = testConfigurationsDoc.Element("TestConfigurations");
            return ReadFromXml(testConfigurationsElement);
        }

        public static TestConfigurations ReadFromXml(XElement testConfigurationsElement)
        {
            TestConfigurations result = new TestConfigurations();

            result.TargetTenantName = (string)testConfigurationsElement.Element("TargetTestTenant");

            result.TenantConfigurations = new List<TenantConfiguration>();
            foreach (var tenantConfigurationElement in testConfigurationsElement.Element("TenantConfigurations").Elements("TenantConfiguration"))
            {
                TenantConfiguration config = new TenantConfiguration();
                config.TenantName = (string)tenantConfigurationElement.Element("TenantName");
                config.AccountName = (string)tenantConfigurationElement.Element("AccountName");
                config.AccountKey = (string)tenantConfigurationElement.Element("AccountKey");
                config.BlobServiceEndpoint = (string)tenantConfigurationElement.Element("BlobServiceEndpoint");
                config.QueueServiceEndpoint = (string)tenantConfigurationElement.Element("QueueServiceEndpoint");
                config.TableServiceEndpoint = (string)tenantConfigurationElement.Element("TableServiceEndpoint");
                config.TenantType = (TenantType)Enum.Parse(typeof(TenantType), (string)tenantConfigurationElement.Element("TenantType"), true);
                result.TenantConfigurations.Add(config);
            }

            return result;
        }
    }
}
