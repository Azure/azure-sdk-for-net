// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.LocationFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    /// <summary>
    /// Summary description for RdfePropertyFinderClientTests
    /// </summary>
    [TestClass]
    public class RdfeServiceRestClientTests : IntegrationTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("RdfePropertyFinderClient")]
        public void ICanPerformA_EmptyXmlParsing_RdfePropertyFinderXmlParsing()
        {
            string xml = @"<root/>";
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var rdfeCapabilitiesClient = ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>().Create(credentials, GetAbstractionContext(), false);
            var capabilities = rdfeCapabilitiesClient.ParseCapabilities(xml);
            Assert.AreEqual(0, capabilities.Count());
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("RdfePropertyFinderClient")]
        public void ICanPerformA_PositiveAdditionalProppertiesXmlParsing_RdfePropertyFinderXmlParsing()
        {
            string xml = @"<ResourceProviderProperties xmlns=""http://schemas.microsoft.com/windowsazure"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">" +
                "<P><Key>My Key</Key><Value>My Value</Value></P>" +
                "<ResourceProviderProperty><Key>CAPABILITY_REGION_EAST_US</Key><Value>East US</Value></ResourceProviderProperty>" +
                "</ResourceProviderProperties>";
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var rdfeCapabilitiesClient = ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>().Create(credentials, GetAbstractionContext(), false);
            var capabilities = rdfeCapabilitiesClient.ParseCapabilities(xml);
            Assert.AreEqual(0, capabilities.Count(capability => capability.Key == "My Key"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("RdfePropertyFinderClient")]
        public void ICanPerformA_InvalidPropertiesXmlParsing_RdfePropertyFinderXmlParsing()
        {
            string xml = @"<ResourceProviderProperties xmlns=""http://schemas.microsoft.com/windowsazure"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><ResourceProviderProperty><KeyA>CAPABILITY_REGION_EAST_US</KeyA><Value>East US</Value></ResourceProviderProperty></ResourceProviderProperties>";
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var rdfeCapabilitiesClient = ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>().Create(credentials, GetAbstractionContext(), false);
            var capabilities = rdfeCapabilitiesClient.ParseCapabilities(xml);
            Assert.AreEqual(0, capabilities.Count());

            xml = @"<ResourceProviderProperties xmlns=""http://schemas.microsoft.com/windowsazure"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><ResourceProviderProperty><Key>CAPABILITY_REGION_EAST_US</Key><ValueB>East US</ValueB></ResourceProviderProperty></ResourceProviderProperties>";
            capabilities = rdfeCapabilitiesClient.ParseCapabilities(xml);
            Assert.AreEqual(0, capabilities.Count());
        }
    }
}
