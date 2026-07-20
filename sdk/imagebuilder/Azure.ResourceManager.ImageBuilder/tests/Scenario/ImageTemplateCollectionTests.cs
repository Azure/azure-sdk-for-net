// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ImageBuilder.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ImageBuilder.Tests.Scenario
{
    public class ImageTemplateCollectionTests : ImageBuilderManagementTestBase
    {
        public ImageTemplateCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateImageTemplate()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroup(DefaultSubscription, "sdktest-imgbuilder", AzureLocation.WestUS2);

            // Image Builder requires a user-assigned managed identity on the template.
            ResourceIdentifier userAssignedIdentityId = await CreateUserAssignedIdentity(resourceGroup, "sdktest-uami", AzureLocation.WestUS2);

            ImageTemplateCollection collection = resourceGroup.GetImageTemplates();

            string templateName = Recording.GenerateAssetName("template");
            ImageTemplateIdentity identity = new ImageTemplateIdentity { Type = ImageBuilderIdentityType.UserAssigned };
            identity.UserAssignedIdentities.Add(userAssignedIdentityId, new UserAssignedIdentity());

            ImageTemplateData data = new ImageTemplateData(AzureLocation.WestUS2, identity)
            {
                Source = new ImageTemplatePlatformImageSource
                {
                    Publisher = "Canonical",
                    Offer = "0001-com-ubuntu-server-jammy",
                    Sku = "22_04-lts",
                    Version = "latest",
                },
                Distribute =
                {
                    new ImageTemplateManagedImageDistributor(
                        "managedImageOutput",
                        new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.Compute/images/sdktestImage"),
                        AzureLocation.WestUS2),
                },
            };

            ArmOperation<ImageTemplateResource> operation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, templateName, data);
            ImageTemplateResource imageTemplate = operation.Value;

            Assert.That(imageTemplate, Is.Not.Null);
            Assert.That(imageTemplate.Data.Name, Is.EqualTo(templateName));
            Assert.That(imageTemplate.Data.Location, Is.EqualTo(AzureLocation.WestUS2));
        }

        private async Task<ResourceIdentifier> CreateUserAssignedIdentity(ResourceGroupResource resourceGroup, string namePrefix, AzureLocation location)
        {
            string identityName = Recording.GenerateAssetName(namePrefix);
            ResourceIdentifier identityId = new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}");
            GenericResourceData data = new GenericResourceData(location);
            var lro = await Client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, identityId, data);
            return lro.Value.Id;
        }
    }
}
