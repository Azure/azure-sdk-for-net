// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotHub.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.IotHub.Tests.Scenario
{
    internal class CertificateDescriptionTests : IotHubManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;

        // Temporary certificate used for testing purposes only, valid until 20220815
        // The extra \" is to workaround the BinaryData serialization issue for pure string
        private const string _certificationContent = "\"LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tDQpNSUlDRkRDQ0FibWdBd0lCQWdJUWJVWXpKaGZHWFlaQmdqS2wyRXBicERBS0JnZ3Foa2pPUFFRREFqQW9NU1l3DQpKQVlEVlFRRERCMUJlblZ5WlNCSmIxUWdRMEVnVkdWemRFOXViSGtnVW05dmRDQkRRVEFlRncweU1qQTNNVFV3DQpOekU0TXpGYUZ3MHlNakE0TVRRd056STRNekZhTURJeE1EQXVCZ05WQkFNTUowRjZkWEpsSUVsdlZDQkRRU0JVDQpaWE4wVDI1c2VTQkpiblJsY20xbFpHbGhkR1VnTVNCRFFUQlpNQk1HQnlxR1NNNDlBZ0VHQ0NxR1NNNDlBd0VIDQpBMElBQkNDT2E5YVd4dU5jWUtuaC9nS2g2MlhFZEk3UStNaUVYbWNDRzlnLzg0UktGa3krMkFoREttZzdJTHlFDQpJMWptNjdEamdXV2VUWmlIamZVckpBQklsNjJqZ2Jvd2diY3dEZ1lEVlIwUEFRSC9CQVFEQWdJRU1CMEdBMVVkDQpKUVFXTUJRR0NDc0dBUVVGQndNQ0JnZ3JCZ0VGQlFjREFUQXlCZ05WSFJFRUt6QXBnaWRCZW5WeVpTQkpiMVFnDQpRMEVnVkdWemRFOXViSGtnU1c1MFpYSnRaV1JwWVhSbElERWdRMEV3RWdZRFZSMFRBUUgvQkFnd0JnRUIvd0lCDQpEREFmQmdOVkhTTUVHREFXZ0JRYmJ1UCsyblZuWGdDL0l1M1FHRVYvNVNObjdUQWRCZ05WSFE0RUZnUVV0VXYxDQphZVVIYWdWMDdWZWMzUFhlUzY2Q0VpZ3dDZ1lJS29aSXpqMEVBd0lEU1FBd1JnSWhBTUhMUk5zbjZqNjJ0eXE1DQp6cDJUd1o4RUtQU0VtbnU3QVNWSkJSVXAwaC9JQWlFQTM2SGljSUtQd1VSMXIwbGExWWYxeWJoMWFtK0lJVjl5DQpPUGYySWlpWjNNND0NCi0tLS0tRU5EIENFUlRJRklDQVRFLS0tLS0NCg==\"";

        public CertificateDescriptionTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("IotHub-RG-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroupIdentifier = rgLro.Value.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        private async Task<IotHubCertificateDescriptionResource> CreateDefaultCertification(IotHubDescriptionResource iothub, string certName)
        {
            IotHubCertificateDescriptionData data = new IotHubCertificateDescriptionData()
            {
                Properties = new IotHubCertificateProperties()
                {
                    Certificate =  BinaryData.FromString(_certificationContent)
                }
            };
            var cert = await iothub.GetIotHubCertificateDescriptions().CreateOrUpdateAsync(WaitUntil.Completed, certName, data);
            return cert.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            string certName = Recording.GenerateAssetName("cert-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            var certification = await CreateDefaultCertification(iothub, certName);
            Assert.IsNotNull(certification);
            Assert.AreEqual(certName, certification.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            string certName = Recording.GenerateAssetName("cert-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            var getCertification = await CreateDefaultCertification(iothub, certName);
            Assert.IsNotNull(getCertification);
            Assert.AreEqual(certName, getCertification.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            string certName = Recording.GenerateAssetName("cert-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);

            var list = await iothub.GetIotHubCertificateDescriptions().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);

            await CreateDefaultCertification(iothub, certName);
            list = await iothub.GetIotHubCertificateDescriptions().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(certName, list.FirstOrDefault().Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            string certName = Recording.GenerateAssetName("cert-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);

            await CreateDefaultCertification(iothub, certName);
            bool isExisted = await iothub.GetIotHubCertificateDescriptions().ExistsAsync(certName);
            Assert.IsTrue(isExisted);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            string certName = Recording.GenerateAssetName("cert-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);

            var deleteCertification = await CreateDefaultCertification(iothub, certName);
            bool isExisted = await iothub.GetIotHubCertificateDescriptions().ExistsAsync(certName);
            Assert.IsTrue(isExisted);

            await deleteCertification.DeleteAsync(WaitUntil.Completed, deleteCertification.Data.ETag.ToString());
            isExisted = await iothub.GetIotHubCertificateDescriptions().ExistsAsync(certName);
            Assert.IsFalse(isExisted);
        }
    }
}
