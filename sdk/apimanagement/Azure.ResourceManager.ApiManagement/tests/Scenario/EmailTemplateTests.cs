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
            Assert.That(emailTemplates, Is.Not.Null);
            Assert.That(emailTemplates.Count, Is.EqualTo(14));

            var firstTemplate = emailTemplates.First();
            Assert.That(firstTemplate, Is.Not.Null);
            Assert.That(firstTemplate.Data.Name, Is.Not.Null);
            Assert.That(firstTemplate.Data.Subject, Is.Not.Null);
            Assert.That(firstTemplate.Data.Title, Is.Not.Null);
            Assert.That(firstTemplate.Data.IsDefault, Is.True);

            var content = new ApiManagementEmailTemplateCreateOrUpdateContent()
            {
                Subject = "New Subject"
            };
            var publisherEmailTemplate = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, firstTemplate.Data.Name, content)).Value;
            Assert.That(publisherEmailTemplate, Is.Not.Null);

            var publisherEmailTemplateResponse = (await collection.GetAsync(publisherEmailTemplate.Data.Name)).Value;
            Assert.That(publisherEmailTemplateResponse, Is.Not.Null);
            Assert.That(publisherEmailTemplateResponse.Data.Subject, Is.EqualTo("New Subject"));
            Assert.That(publisherEmailTemplateResponse.Data.IsDefault, Is.False);
            Assert.That(publisherEmailTemplateResponse.Data.Body, Is.Not.Null);
            Assert.That(publisherEmailTemplateResponse.Data.Parameters, Is.Not.Null);

            content = new ApiManagementEmailTemplateCreateOrUpdateContent()
            {
                Subject = "Updated Subject"
            };
            var updatePublisherEmailTemplate = (await publisherEmailTemplateResponse.UpdateAsync(ETag.All, content)).Value;
            var updatePublisherEmailTemplateResponse = (await updatePublisherEmailTemplate.GetAsync()).Value;
            Assert.That(updatePublisherEmailTemplateResponse, Is.Not.Null);
            Assert.That(updatePublisherEmailTemplateResponse.Data.Subject, Is.EqualTo("Updated Subject"));

            // reset the template to default
            await updatePublisherEmailTemplateResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            publisherEmailTemplate = (await collection.GetAsync(publisherEmailTemplate.Data.Name)).Value;
            Assert.That(publisherEmailTemplate, Is.Not.Null);
            Assert.That(publisherEmailTemplate.Data.IsDefault, Is.True);
        }
    }
}
