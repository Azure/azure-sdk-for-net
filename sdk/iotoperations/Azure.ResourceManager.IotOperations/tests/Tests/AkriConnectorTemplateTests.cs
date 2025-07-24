// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class AkriConnectorTemplateTests : IotOperationsManagementClientBase
    {
        public AkriConnectorTemplateTests(bool isAsync) : base(isAsync) { }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
                await InitializeClients();
        }

        [TestCase]
        [RecordedTest]
        public async Task TestAkriConnectorTemplates()
        {
            // List AkriConnectorTemplates by InstanceResource
            var templateCollection = await GetAkriConnectorTemplateResourceCollectionAsync(ResourceGroup);
            var templates = await templateCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(templates);

            // Get an existing AkriConnectorTemplate
            var templateResource = await templateCollection.GetAsync(AkriConnectorTemplateName);
            Assert.IsNotNull(templateResource);
            Assert.IsNotNull(templateResource.Value.Data);
            Assert.AreEqual(templateResource.Value.Data.Name, AkriConnectorTemplateName);

            // Create or Update AkriConnectorTemplate
            var templateData = CreateAkriConnectorTemplateResourceData(templateResource.Value);
            var resp = await templateCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "sdk-test-akriconnector-template",
                templateData
            );
            var createdTemplate = resp.Value;
            Assert.IsNotNull(createdTemplate);
            Assert.IsNotNull(createdTemplate.Data);
            Assert.IsNotNull(createdTemplate.Data.Properties);

            // Delete AkriConnectorTemplate
            await createdTemplate.DeleteAsync(WaitUntil.Completed);

            // Verify AkriConnectorTemplate is deleted
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await createdTemplate.GetAsync()
            );
        }

        private AkriConnectorTemplateResourceData CreateAkriConnectorTemplateResourceData(
            AkriConnectorTemplateResource templateResource
        )
        {
            return new AkriConnectorTemplateResourceData
            {
                ExtendedLocation = templateResource.Data.ExtendedLocation,
                Properties = templateResource.Data.Properties
            };
        }
    }
}