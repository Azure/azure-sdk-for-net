// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class EmailTemplateTests : ApiManagementManagementTestBase
    {
        public EmailTemplateTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementEmailTemplates();

            var emailTemplates = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(emailTemplates);
            Assert.AreEqual(14, emailTemplates.Count);

            var firstTemplate = emailTemplates.First();
            Assert.NotNull(firstTemplate);
            Assert.NotNull(firstTemplate.Data.Name);
            Assert.NotNull(firstTemplate.Data.Subject);
            Assert.NotNull(firstTemplate.Data.Title);
            Assert.IsTrue(firstTemplate.Data.IsDefault);

            var content = new ApiManagementEmailTemplateCreateOrUpdateContent()
            {
                Subject = "New Subject"
            };
            var publisherEmailTemplate = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, firstTemplate.Data.Name, content)).Value;
            Assert.NotNull(publisherEmailTemplate);

            var publisherEmailTemplateResponse = (await collection.GetAsync(publisherEmailTemplate.Data.Name)).Value;
            Assert.NotNull(publisherEmailTemplateResponse);
            Assert.AreEqual("New Subject", publisherEmailTemplateResponse.Data.Subject);
            Assert.IsFalse(publisherEmailTemplateResponse.Data.IsDefault);
            Assert.NotNull(publisherEmailTemplateResponse.Data.Body);
            Assert.NotNull(publisherEmailTemplateResponse.Data.Parameters);

            content = new ApiManagementEmailTemplateCreateOrUpdateContent()
            {
                Subject = "Updated Subject"
            };
            var updatePublisherEmailTemplate = (await publisherEmailTemplateResponse.UpdateAsync(ETag.All, content)).Value;
            var updatePublisherEmailTemplateResponse = (await updatePublisherEmailTemplate.GetAsync()).Value;
            Assert.NotNull(updatePublisherEmailTemplateResponse);
            Assert.AreEqual("Updated Subject", updatePublisherEmailTemplateResponse.Data.Subject);

            // reset the template to default
            await updatePublisherEmailTemplateResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            publisherEmailTemplate = (await collection.GetAsync(publisherEmailTemplate.Data.Name)).Value;
            Assert.NotNull(publisherEmailTemplate);
            Assert.IsTrue(publisherEmailTemplate.Data.IsDefault);
        }
    }
}
