// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HealthcareApis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HealthcareApis.Tests
{
    internal class IotFhirDestinationTests : HealthcareApisManagementTestBase
    {
        private const string _fhirDestinationPrefixName = "fhirdestination";
        private ResourceIdentifier _fhirServiceResourceId;
        private HealthcareApisIotFhirDestinationCollection _fhirDestinationCollection;

        public IotFhirDestinationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            var workspace = await CreateHealthcareApisWorkspace(resourceGroup, Recording.GenerateAssetName("workspace"));
            var fhirService = await CreateFhirService(workspace, Recording.GenerateAssetName("fhir"));
            _fhirServiceResourceId = fhirService.Data.Id;
            var iotConnector = await CreateHealthcareApisIotConnector(resourceGroup, workspace, Recording.GenerateAssetName("medtech"));
            _fhirDestinationCollection = iotConnector.GetHealthcareApisIotFhirDestinations();
        }

        [RecordedTest]
        [Ignore("Pipeline playback error")]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string fhirDestinationName = Recording.GenerateAssetName(_fhirDestinationPrefixName);
            var fhirDestination = await CreateHealthcareApisIotFhirDestination(fhirDestinationName);
            ValidateHealthcareApisIotFhirDestination(fhirDestination.Data, fhirDestinationName);

            // Exist
            var flag = await _fhirDestinationCollection.ExistsAsync(fhirDestinationName);
            Assert.IsTrue(flag);

            // Get
            var getfhirDestination = await _fhirDestinationCollection.GetAsync(fhirDestinationName);
            ValidateHealthcareApisIotFhirDestination(getfhirDestination.Value.Data, fhirDestinationName);

            // GetAll
            var list = await _fhirDestinationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateHealthcareApisIotFhirDestination(list.FirstOrDefault().Data, fhirDestinationName);

            // Delete
            await fhirDestination.DeleteAsync(WaitUntil.Completed);
            flag = await _fhirDestinationCollection.ExistsAsync(fhirDestinationName);
            Assert.IsFalse(flag);
        }

        private async Task<HealthcareApisIotFhirDestinationResource> CreateHealthcareApisIotFhirDestination(string fhirDestinationName)
        {
            HealthcareApisIotMappingProperties fhirMapping = new HealthcareApisIotMappingProperties()
            {
                Content = BinaryData.FromString("{\"templateType\": \"CollectionFhirTemplate\",\"template\": []}")
            };
            var data = new HealthcareApisIotFhirDestinationData(HealthcareApisIotIdentityResolutionType.Create, _fhirServiceResourceId, fhirMapping)
            {
                Location = DefaultLocation,
            };
            var fhirDestinationLro = await _fhirDestinationCollection.CreateOrUpdateAsync(WaitUntil.Completed, fhirDestinationName, data);
            return fhirDestinationLro.Value;
        }

        private void ValidateHealthcareApisIotFhirDestination(HealthcareApisIotFhirDestinationData fhirDestination, string fhirDestinationName)
        {
            Assert.IsNotNull(fhirDestination);
            Assert.IsNotNull(fhirDestination.ETag);
            Assert.IsNotNull(fhirDestination.FhirMappingContent);
            Assert.AreEqual(fhirDestinationName, fhirDestination.Id.Name);
            Assert.AreEqual(DefaultLocation, fhirDestination.Location);
            Assert.AreEqual("Create", fhirDestination.ResourceIdentityResolutionType.ToString());
            Assert.AreEqual("Microsoft.HealthcareApis/workspaces/iotconnectors/fhirdestinations", fhirDestination.ResourceType.ToString());
        }
    }
}
