// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridNamespaceTests : EventGridManagementTestBase
    {
        public EventGridNamespaceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private EventGridNamespaceCollection NamespaceCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }

        // Pre-generated Key Vault Certificate URL for testing purposes. This URL is sanitized in the test environment. To run the test cases in Live/Record mode,
        // replace the SANITIZED_CERTIFICATE_URL with the actual URL of a valid certificate in your Key Vault.
        // Go to Azure Portal -> Key Vault -> Select sdk-eg-pre-generated-kv -> Certificates -> sdk-eventgrid-test-certificate -> Properties -> Certificate URL
        private const string KeyVaultCertificateUrl = "https://sdk-eg-pre-generated-kv.vault.azure.net/certificates/sdk-eventgrid-test-certificate/SANITIZED_CERTIFICATE_URL";

        // AAD Application ID. This is sanitized in the test environment. To run the test cases in Live/Record mode,
        // replace the SANITIZED_APPLICATION_ID with the actual AAD Application ID used in your Azure Active Directory.
        // Go to Azure Portal -> Microsoft Entra ID -> App registrations -> EventGridWebhookAuthenticationApp -> Overview -> Application (client) ID
        private const string AzureActiveDirectoryApplicationId = "api://SANITIZED_APPLICATION_ID";

        // AAD Tenant ID. This is sanitized in the test environment. To run the test cases in Live/Record mode,
        // replace the SANITIZED_TENANT_ID with the actual AAD Tenant ID used in your Azure Active Directory.
        // Go to Azure Portal -> Microsoft Entra ID -> App registrations -> EventGridWebhookAuthenticationApp -> Overview -> Directory (Tenant) ID
        private const string AzureActiveDirectoryTenantId = "SANITIZED_TENANT_ID";

        // Event subscription destination endpoint. This endpoint URL is sanitized in the test environment. To run the test cases in Live/Record mode,
        // replace the sig parameter with the actual signature from your Azure Logic App.
        // Go to Azure Portal -> Logic Apps -> sdk-test-logic-app -> Overview -> Workflow URL
        private const string EventSubscriptionDestinationEndpoint = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY";

        private AzureLocation location = new AzureLocation("eastus2", "eastus2");

        private async Task SetCollection()
        {
            ResourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), DefaultLocation);
            NamespaceCollection = ResourceGroup.GetEventGridNamespaces();
        }

        [Test]
        public async Task NamespaceCreateGetUpdateDelete()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                // Skip the test in playback mode as it it taking more time
                Assert.Ignore("Skipping test in playback mode.");
            }
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceName2 = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceName3 = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };

            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true
            };

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.That(createNamespaceResponse, Is.Not.Null);
            Assert.That(createNamespaceResponse.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createNamespaceResponse.Data.Name, Is.Not.Null);
                Assert.That(namespaceName, Is.EqualTo(createNamespaceResponse.Data.Name));
            });

            // Get the created namespace
            var getNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.That(getNamespaceResponse, Is.Not.Null);
            Assert.That(getNamespaceResponse.Data, Is.Not.Null);
            Assert.That(getNamespaceResponse.Data.ProvisioningState, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getNamespaceResponse.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));
                Assert.That(getNamespaceResponse.Data.Tags, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(getNamespaceResponse.Data.Tags.Keys.Contains("originalTag1"), Is.True);
                Assert.That(getNamespaceResponse.Data.Tags["originalTag1"], Is.EqualTo("originalValue1"));
                Assert.That(getNamespaceResponse.Data.Tags.Keys.Contains("originalTag2"), Is.True);
                Assert.That(getNamespaceResponse.Data.Tags["originalTag2"], Is.EqualTo("originalValue2"));
                Assert.That(getNamespaceResponse.Data.Sku, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(getNamespaceResponse.Data.Sku.Name, Is.Not.Null);
                Assert.That(namespaceSkuName, Is.EqualTo(getNamespaceResponse.Data.Sku.Name.Value.ToString()));
                Assert.That(getNamespaceResponse.Data.Sku.Capacity, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(getNamespaceResponse.Data.Sku.Capacity.Value, Is.EqualTo(1));
                Assert.That(getNamespaceResponse.Data.IsZoneRedundant.Value, Is.True);
            });

            // Validate original tags
            var tagsAfterCreate = getNamespaceResponse.Data.Tags;
            Assert.That(tagsAfterCreate, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(tagsAfterCreate["originalTag1"], Is.EqualTo("originalValue1"));
                Assert.That(tagsAfterCreate["originalTag2"], Is.EqualTo("originalValue2"));
            });

            // update the tags and capacity
            namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 2,
            };
            EventGridNamespacePatch namespacePatch = new EventGridNamespacePatch()
            {
                Tags = {
                    {"updatedTag1", "updatedValue1"},
                    {"updatedTag2", "updatedValue2"}
                },
                Sku = namespaceSku,
            };

            var updateNamespaceResponse = (await getNamespaceResponse.UpdateAsync(WaitUntil.Completed, namespacePatch)).Value;
            Assert.That(updateNamespaceResponse, Is.Not.Null);
            Assert.That(updateNamespaceResponse.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(updateNamespaceResponse.Data.Name, Is.Not.Null);
                Assert.That(namespaceName, Is.EqualTo(updateNamespaceResponse.Data.Name));
            });

            // Get the updated namespace
            var getUpdatedNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.That(getUpdatedNamespaceResponse, Is.Not.Null);
            Assert.That(getUpdatedNamespaceResponse.Data, Is.Not.Null);
            Assert.That(getUpdatedNamespaceResponse.Data.ProvisioningState, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getUpdatedNamespaceResponse.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));
                Assert.That(getUpdatedNamespaceResponse.Data.Tags, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(getUpdatedNamespaceResponse.Data.Tags.Keys.Contains("updatedTag1"), Is.True);
                Assert.That(getUpdatedNamespaceResponse.Data.Tags["updatedTag1"], Is.EqualTo("updatedValue1"));
                Assert.That(getUpdatedNamespaceResponse.Data.Tags.Keys.Contains("updatedTag2"), Is.True);
                Assert.That(getUpdatedNamespaceResponse.Data.Tags["updatedTag2"], Is.EqualTo("updatedValue2"));
                Assert.That(getUpdatedNamespaceResponse.Data.Sku, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(getUpdatedNamespaceResponse.Data.Sku.Name, Is.Not.Null);
                Assert.That(namespaceSkuName, Is.EqualTo(getUpdatedNamespaceResponse.Data.Sku.Name.Value.ToString()));
                Assert.That(getUpdatedNamespaceResponse.Data.Sku.Capacity, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(getUpdatedNamespaceResponse.Data.Sku.Capacity.Value, Is.EqualTo(2));
                Assert.That(getUpdatedNamespaceResponse.Data.IsZoneRedundant.Value, Is.True);
            });

            // Validate updated tags
            var tagsAfterUpdate = getUpdatedNamespaceResponse.Data.Tags;
            Assert.That(tagsAfterUpdate, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(tagsAfterUpdate["updatedTag1"], Is.EqualTo("updatedValue1"));
                Assert.That(tagsAfterUpdate["updatedTag2"], Is.EqualTo("updatedValue2"));
            });

            //Create 2nd and 3rd Namespace
            var createNamespaceResponse2 = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName2, nameSpace)).Value;
            Assert.That(createNamespaceResponse2, Is.Not.Null);
            Assert.That(createNamespaceResponse2.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createNamespaceResponse2.Data.Name, Is.Not.Null);
                Assert.That(namespaceName2, Is.EqualTo(createNamespaceResponse2.Data.Name));
            });
            var createNamespaceResponse3 = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName3, nameSpace)).Value;
            Assert.That(createNamespaceResponse3, Is.Not.Null);
            Assert.That(createNamespaceResponse3.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createNamespaceResponse3.Data.Name, Is.Not.Null);
                Assert.That(namespaceName3, Is.EqualTo(createNamespaceResponse3.Data.Name));
            });

            // Get the created namespaces
            var getNamespace2Response = (await NamespaceCollection.GetAsync(namespaceName2)).Value;
            Assert.That(getNamespace2Response, Is.Not.Null);
            Assert.That(getNamespace2Response.Data, Is.Not.Null);
            Assert.That(getNamespace2Response.Data.ProvisioningState, Is.Not.Null);
            Assert.That(getNamespace2Response.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));
            var getNamespace3Response = (await NamespaceCollection.GetAsync(namespaceName3)).Value;
            Assert.That(getNamespace3Response, Is.Not.Null);
            Assert.That(getNamespace3Response.Data, Is.Not.Null);
            Assert.That(getNamespace3Response.Data.ProvisioningState, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getNamespace3Response.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));

                // Validate created namespaces
                Assert.That(namespaceName2, Is.EqualTo(getNamespace2Response.Data.Name));
                Assert.That(namespaceName3, Is.EqualTo(getNamespace3Response.Data.Name));
                Assert.That(getNamespace2Response.Data.Tags, Is.Not.Null);
                Assert.That(getNamespace2Response.Data.Sku, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(getNamespace2Response.Data.Sku.Name, Is.Not.Null);
                Assert.That(namespaceSkuName, Is.EqualTo(getNamespace2Response.Data.Sku.Name.Value.ToString()));
                Assert.That(getNamespace3Response.Data.Tags, Is.Not.Null);
                Assert.That(getNamespace3Response.Data.Sku, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(getNamespace3Response.Data.Sku.Name, Is.Not.Null);
                Assert.That(namespaceSkuName, Is.EqualTo(getNamespace3Response.Data.Sku.Name.Value.ToString()));
                Assert.That(getNamespace2Response.Data.Sku.Capacity, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(getNamespace2Response.Data.Sku.Capacity.Value, Is.EqualTo(1));
                Assert.That(getNamespace3Response.Data.Sku.Capacity, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(getNamespace3Response.Data.Sku.Capacity.Value, Is.EqualTo(1));
                Assert.That(getNamespace2Response.Data.IsZoneRedundant.Value, Is.True);
                Assert.That(getNamespace3Response.Data.IsZoneRedundant.Value, Is.True);
                Assert.That(getNamespace2Response.Data.Tags.Keys.Contains("originalTag1"), Is.True);
                Assert.That(getNamespace2Response.Data.Tags["originalTag1"], Is.EqualTo("originalValue1"));
                Assert.That(getNamespace3Response.Data.Tags.Keys.Contains("originalTag1"), Is.True);
                Assert.That(getNamespace3Response.Data.Tags["originalTag1"], Is.EqualTo("originalValue1"));
            });

            // Tag operations
            var addTagResponse = await getNamespaceResponse.AddTagAsync("env", "test");
            Assert.That(addTagResponse, Is.Not.Null);
            Assert.That(addTagResponse.Value, Is.Not.Null);
            Assert.That(addTagResponse.Value.Data, Is.Not.Null);
            Assert.That(addTagResponse.Value.Data.Tags, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(addTagResponse.Value.Data.Tags.ContainsKey("env"), Is.True);
                Assert.That(addTagResponse.Value.Data.Tags["env"], Is.EqualTo("test"));
            });

            addTagResponse = await getNamespaceResponse.SetTagsAsync(new Dictionary<string, string> { { "project", "sdk" } });
            Assert.Multiple(() =>
            {
                Assert.That(addTagResponse.Value.Data.Tags.ContainsKey("project"), Is.True);
                Assert.That(addTagResponse.Value.Data.Tags.ContainsKey("env"), Is.False);
            });

            addTagResponse = await getNamespaceResponse.RemoveTagAsync("project");
            Assert.That(addTagResponse.Value.Data.Tags.ContainsKey("project"), Is.False);

            // List Shared Access Keys and Regenerate keys
            var sharedAccessKeys = (await getNamespaceResponse.GetSharedAccessKeysAsync()).Value;
            var sharedAccessKey1Before = sharedAccessKeys.Key1;
            var sharedAccessKey2Before = sharedAccessKeys.Key2;
            NamespaceRegenerateKeyContent namespaceRegenerateKeyContent = new NamespaceRegenerateKeyContent("key1");
            var regenKeysResponse = (await getNamespaceResponse.RegenerateKeyAsync(WaitUntil.Completed, namespaceRegenerateKeyContent)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(sharedAccessKey1Before, Is.Not.EqualTo(regenKeysResponse.Key1));
                Assert.That(sharedAccessKey2Before, Is.EqualTo(regenKeysResponse.Key2));
            });

            // List all namespaces
            var namespacesInResourceGroup = await NamespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(namespacesInResourceGroup, Is.Not.Null);
            Assert.That(namespacesInResourceGroup, Has.Count.EqualTo(3));

            // Check Exists method
            var namespaceExists = await NamespaceCollection.ExistsAsync(namespaceName3);
            Assert.That((bool)namespaceExists, Is.True);

            // Delete namespace3
            await getNamespace3Response.DeleteAsync(WaitUntil.Completed);

            // List all namespaces under resourc group again to check updated number of namespaces.
            var namespacesInResourceGroupUpdated = await NamespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(namespacesInResourceGroupUpdated, Is.Not.Null);
            Assert.That(namespacesInResourceGroupUpdated, Has.Count.EqualTo(2));

            // Get all namespaces created within the subscription irrespective of the resourceGroup
            var namespacesInAzureSubscription = await DefaultSubscription.GetEventGridNamespacesAsync().ToEnumerableAsync();
            Assert.That(namespacesInAzureSubscription, Is.Not.Null);
            Assert.That(namespacesInAzureSubscription.Count, Is.GreaterThanOrEqualTo(1));
            var falseFlag = false;
            foreach (var item in namespacesInAzureSubscription)
            {
                if (item.Data.Name == namespaceName)
                {
                    falseFlag = true;
                    break;
                }
            }
            Assert.That(falseFlag, Is.True);

            // Delete all namespaces
            await getNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await getNamespace2Response.DeleteAsync(WaitUntil.Completed);
            var namespace1Exists = await NamespaceCollection.ExistsAsync(namespaceName);
            Assert.That((bool)namespace1Exists, Is.False);
            var namespace2Exists = await NamespaceCollection.ExistsAsync(namespaceName2);
            Assert.That((bool)namespace2Exists, Is.False);

            // List all namespaces under resource group again to check updated number of namespaces.
            var namespacesInResourceGroupDeleted = await NamespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(namespacesInResourceGroupDeleted, Is.Not.Null);
            Assert.Multiple(async () =>
            {
                Assert.That(namespacesInResourceGroupDeleted.Count, Is.EqualTo(0));

                Assert.That((bool)await NamespaceCollection.ExistsAsync(namespaceName), Is.False);
                Assert.That((bool)await NamespaceCollection.ExistsAsync(namespaceName2), Is.False);
                Assert.That((await NamespaceCollection.GetAllAsync().ToEnumerableAsync()).Count, Is.EqualTo(0));
            });

            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task NamespaceCustomDomainsCreateGetUpdateDelete()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned),
                IsZoneRedundant = true
            };
            nameSpace.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_centraleaup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"), userAssignedIdentity);

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createNamespaceResponse, Is.Not.Null);
                Assert.That(namespaceName, Is.EqualTo(createNamespaceResponse.Data.Name));
            });

            // Get the created namespace
            var getNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.That(getNamespaceResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getNamespaceResponse.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));
                Assert.That(getNamespaceResponse.Data.Tags.Keys.Contains("originalTag1"), Is.True);
                Assert.That(getNamespaceResponse.Data.Tags["originalTag1"], Is.EqualTo("originalValue1"));
                Assert.That(getNamespaceResponse.Data.Tags.Keys.Contains("originalTag2"), Is.True);
                Assert.That(getNamespaceResponse.Data.Tags["originalTag2"], Is.EqualTo("originalValue2"));
                Assert.That(namespaceSkuName, Is.EqualTo(getNamespaceResponse.Data.Sku.Name.Value.ToString()));
                Assert.That(getNamespaceResponse.Data.Sku.Capacity.Value, Is.EqualTo(1));
                Assert.That(getNamespaceResponse.Data.IsZoneRedundant.Value, Is.True);
            });

            // update the tags and capacity
            namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 2,
            };

            EventGridNamespacePatch namespacePatch = new EventGridNamespacePatch()
            {
                Tags = {
                    {"updatedTag1", "updatedValue1"},
                    {"updatedTag2", "updatedValue2"}
                },
                Sku = namespaceSku,
                TopicsConfiguration = new UpdateTopicsConfigurationInfo(),
            };

            // Validate Custom Domain Ownership
            var customDomainValidationResponse = await createNamespaceResponse.ValidateCustomDomainOwnershipAsync(
              WaitUntil.Completed,
             new CancellationToken()
            ).ConfigureAwait(false);

            Assert.That(customDomainValidationResponse, Is.Not.Null);
            Assert.That(customDomainValidationResponse.Value, Is.Not.Null);
            namespacePatch.TopicsConfiguration.CustomDomains.Add(new CustomDomainConfiguration()
            {
                FullyQualifiedDomainName = "www.contoso.com",
                Identity = new CustomDomainIdentity()
                {
                    IdentityType = CustomDomainIdentityType.UserAssigned,
                    UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_centraleaup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"
                },
                CertificateUri = new Uri("https://sdk-centraleuap-testakv.vault.azure.net/certificates/test-custom-domain/"),
            });
            var updateNamespaceResponse = (await getNamespaceResponse.UpdateAsync(WaitUntil.Completed, namespacePatch)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(updateNamespaceResponse, Is.Not.Null);
                Assert.That(namespaceName, Is.EqualTo(updateNamespaceResponse.Data.Name));
            });

            // Get the updated namespace
            var getUpdatedNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.That(getUpdatedNamespaceResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getUpdatedNamespaceResponse.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));
                Assert.That(getUpdatedNamespaceResponse.Data.Tags.Keys.Contains("updatedTag1"), Is.True);
                Assert.That(getUpdatedNamespaceResponse.Data.Tags["updatedTag1"], Is.EqualTo("updatedValue1"));
                Assert.That(getUpdatedNamespaceResponse.Data.Tags.Keys.Contains("updatedTag2"), Is.True);
                Assert.That(getUpdatedNamespaceResponse.Data.Tags["updatedTag2"], Is.EqualTo("updatedValue2"));
                Assert.That(namespaceSkuName, Is.EqualTo(getUpdatedNamespaceResponse.Data.Sku.Name.Value.ToString()));
                Assert.That(getUpdatedNamespaceResponse.Data.Sku.Capacity.Value, Is.EqualTo(2));
                // verify custom domain
                Assert.That(getUpdatedNamespaceResponse.Data.TopicsConfiguration.CustomDomains, Is.Not.Null);
            });
            Assert.That(getUpdatedNamespaceResponse.Data.TopicsConfiguration.CustomDomains, Has.Count.EqualTo(1));
            Assert.That(getUpdatedNamespaceResponse.Data.TopicsConfiguration.CustomDomains.FirstOrDefault().FullyQualifiedDomainName, Is.EqualTo("www.contoso.com"));

            // Delete 1st custom domain
            namespacePatch.TopicsConfiguration.CustomDomains.RemoveAt(0);
            var updateNamespaceResponse2 = (await getUpdatedNamespaceResponse.UpdateAsync(WaitUntil.Completed, namespacePatch)).Value;
            Assert.That(updateNamespaceResponse2, Is.Not.Null);
            Assert.That(updateNamespaceResponse2.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));

            var getUpdatedNamespaceResponse2 = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            // verify 1st custom domain is deleted
            Assert.That(getUpdatedNamespaceResponse2.Data.TopicsConfiguration.CustomDomains, Is.Not.Null);
            Assert.That(getUpdatedNamespaceResponse2.Data.TopicsConfiguration.CustomDomains.Count, Is.EqualTo(0));

            // Delete all namespaces
            await getNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            var namespace1Exists = await NamespaceCollection.ExistsAsync(namespaceName);
            Assert.That((bool)namespace1Exists, Is.False);

            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        // Enabling CustomJwtAuthenticationSettings feature for 2025-04-01-preview API version
        [Test]
        public async Task NamespaceCustomJwtAuthCreateGetUpdateDelete()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };

            // Enable managed identity for the namespace
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned) // Enable SystemAssigned managed identity
            };

            // Add the user-assigned identity
            nameSpace.Identity.UserAssignedIdentities.Add(
                new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-eventgrid-test-userAssignedManagedIdentity"),
                new UserAssignedIdentity()
            );

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createNamespaceResponse, Is.Not.Null);
                Assert.That(namespaceName, Is.EqualTo(createNamespaceResponse.Data.Name));
            });

            // Get the created namespace
            var getNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.That(getNamespaceResponse, Is.Not.Null);
            Assert.That(getNamespaceResponse.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));

            // Update the tags and capacity
            namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 2,
            };

            EventGridNamespacePatch namespacePatch = new EventGridNamespacePatch()
            {
                Tags = {
                    {"updatedTag1", "updatedValue1"},
                    {"updatedTag2", "updatedValue2"}
                },
                Sku = namespaceSku,
                TopicSpacesConfiguration = new UpdateTopicSpacesConfigurationInfo(),
            };
            namespacePatch.TopicSpacesConfiguration.ClientAuthentication = new ClientAuthenticationSettings();
            namespacePatch.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication = new CustomJwtAuthenticationSettings()
            {
                TokenIssuer = "sts.windows.net",
                IssuerCertificates =
                {
                    new IssuerCertificateInfo()
                    {
                        CertificateUri = new Uri(KeyVaultCertificateUrl),
                        Identity = new CustomJwtAuthenticationManagedIdentity(CustomJwtAuthenticationManagedIdentityType.UserAssigned)
                        {
                            UserAssignedIdentity = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-eventgrid-test-userAssignedManagedIdentity")
                        }
                    }
                }
            };

            var updateNamespaceResponse = (await getNamespaceResponse.UpdateAsync(WaitUntil.Completed, namespacePatch)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(updateNamespaceResponse, Is.Not.Null);
                Assert.That(namespaceName, Is.EqualTo(updateNamespaceResponse.Data.Name));
            });

            // Get the updated namespace
            var getUpdatedNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.That(getUpdatedNamespaceResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getUpdatedNamespaceResponse.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));

                // Verify custom JWT authentication
                Assert.That(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication, Is.Not.Null);
            });
            Assert.That(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication.IssuerCertificates, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication.IssuerCertificates.FirstOrDefault().CertificateUri.AbsoluteUri, Is.EqualTo(KeyVaultCertificateUrl));
                Assert.That("sts.windows.net", Is.EqualTo(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication.TokenIssuer));
                Assert.That(CustomJwtAuthenticationManagedIdentityType.UserAssigned, Is.EqualTo(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.CustomJwtAuthentication.IssuerCertificates.FirstOrDefault().Identity.IdentityType));
            });

            // Delete all namespaces
            await getNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            var namespace1Exists = await NamespaceCollection.ExistsAsync(namespaceName);
            Assert.That((bool)namespace1Exists, Is.False);

            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        // Test case for WebhookAuthentication. This feature is added in 2025-04-01-preview API version
        [Test]
        public async Task NamespaceCustomWebhookAuthCreateGetUpdateDelete()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };

            // Enable managed identity for the namespace
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned) // Enable SystemAssigned managed identity
            };

            // Add the user-assigned identity
            nameSpace.Identity.UserAssignedIdentities.Add(
                new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-eventgrid-test-userAssignedManagedIdentity"),
                new UserAssignedIdentity()
            );

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.That(createNamespaceResponse, Is.Not.Null);
            Assert.That(namespaceName, Is.EqualTo(createNamespaceResponse.Data.Name));

            // Get the created namespace
            var getNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.That(getNamespaceResponse, Is.Not.Null);
            Assert.That(getNamespaceResponse.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));

            // Update the tags and capacity
            namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 2,
            };

            EventGridNamespacePatch namespacePatch = new EventGridNamespacePatch()
            {
                Tags = {
                    {"updatedTag1", "updatedValue1"},
                    {"updatedTag2", "updatedValue2"}
                },
                Sku = namespaceSku,
                TopicSpacesConfiguration = new UpdateTopicSpacesConfigurationInfo(),
            };
            namespacePatch.TopicSpacesConfiguration.ClientAuthentication = new ClientAuthenticationSettings();
            namespacePatch.TopicSpacesConfiguration.ClientAuthentication.WebhookAuthentication = new WebhookAuthenticationSettings()
            {
                Identity = new CustomWebhookAuthenticationManagedIdentity()
                {
                    IdentityType = CustomWebhookAuthenticationManagedIdentityType.UserAssigned,
                    UserAssignedIdentity = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-eventgrid-test-userAssignedManagedIdentity")
                },
                EndpointUri = new Uri(EventSubscriptionDestinationEndpoint),
                AzureActiveDirectoryApplicationIdOrUri = new Uri(AzureActiveDirectoryApplicationId),
                AzureActiveDirectoryTenantId = AzureActiveDirectoryTenantId
            };

            var updateNamespaceResponse = (await getNamespaceResponse.UpdateAsync(WaitUntil.Completed, namespacePatch)).Value;
            Assert.That(updateNamespaceResponse, Is.Not.Null);
            Assert.That(namespaceName, Is.EqualTo(updateNamespaceResponse.Data.Name));

            // Get the updated namespace
            var getUpdatedNamespaceResponse = (await NamespaceCollection.GetAsync(namespaceName)).Value;
            Assert.That(getUpdatedNamespaceResponse, Is.Not.Null);

                Assert.That(getUpdatedNamespaceResponse.Data.ProvisioningState, Is.EqualTo(NamespaceProvisioningState.Succeeded));

            // Verify custom Webhook authentication
            Assert.That(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.WebhookAuthentication, Is.Not.Null);
            Assert.That(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.WebhookAuthentication.EndpointUri, Is.EqualTo(new Uri(EventSubscriptionDestinationEndpoint)));
            Assert.That(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.WebhookAuthentication.AzureActiveDirectoryApplicationIdOrUri, Is.EqualTo(new Uri(AzureActiveDirectoryApplicationId)));
            Assert.That(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.WebhookAuthentication.AzureActiveDirectoryTenantId, Is.EqualTo(AzureActiveDirectoryTenantId));
            Assert.That(getUpdatedNamespaceResponse.Data.TopicSpacesConfiguration.ClientAuthentication.WebhookAuthentication.Identity.IdentityType, Is.EqualTo(CustomWebhookAuthenticationManagedIdentityType.UserAssigned));
            // Delete all namespaces
            await getNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            var namespace1Exists = await NamespaceCollection.ExistsAsync(namespaceName);
            Assert.That((bool)namespace1Exists, Is.False);

            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        // Please run this test in live mode if you make any change, this doesn't work in playback mode due to expiry date field
        [Test]
        [Ignore("Please run this test in live mode if you make any change, this doesn't work in playback mode due to expiry date field")]
        public async Task NamespaceTopicsSubscriptionWithDeadletterCreateUpdateDelete()
        {
            await SetCollection();
            var topicCollection = ResourceGroup.GetEventGridTopics();

            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceTopicName = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceTopicSubscriptionName1 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    { "originalTag1", "originalValue1" },
                    { "originalTag2", "originalValue2" }
                },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };

            nameSpace.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"), userAssignedIdentity);
            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.That(createNamespaceResponse, Is.Not.Null);
            Assert.That(namespaceName, Is.EqualTo(createNamespaceResponse.Data.Name));

            // create namespace topics
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.That(namespaceTopicsCollection, Is.Not.Null);
            var namespaceTopic = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopicsResponse1 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName, namespaceTopic)).Value;
            Assert.That(namespaceTopicsResponse1, Is.Not.Null);
            Assert.That(NamespaceTopicProvisioningState.Succeeded, Is.EqualTo(namespaceTopicsResponse1.Data.ProvisioningState));
            Assert.That(namespaceTopicsResponse1.Data.EventRetentionInDays, Is.EqualTo(1));

            // create subscriptions
            var subscriptionsCollection = namespaceTopicsResponse1.GetNamespaceTopicEventSubscriptions();
            var deadLetterDestination = new DeadLetterWithResourceIdentity()
            {
                Identity = new EventSubscriptionIdentity()
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                },
                DeadLetterDestination = new StorageBlobDeadLetterDestination()
                {
                    ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk_test_easteuap/providers/Microsoft.Storage/storageAccounts/testcontosso2"),
                    BlobContainerName = "contosocontainer",
                }
            };
            deadLetterDestination.Identity.UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity";

            DeliveryConfiguration deliveryConfiguration = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Queue.ToString(),
                // instead of queue info create push info with event hub destination
                Queue = new QueueInfo()
                {
                    EventTimeToLive = TimeSpan.FromDays(1),
                    MaxDeliveryCount = 5,
                    ReceiveLockDurationInSeconds = 120,
                    DeadLetterDestinationWithResourceIdentity = deadLetterDestination
                }
            };
            DateTimeOffset expirationTime = DateTime.UtcNow.AddHours(8);
            NamespaceTopicEventSubscriptionData subscriptionData = new NamespaceTopicEventSubscriptionData()
            {
                DeliveryConfiguration = deliveryConfiguration,
                ExpireOn = expirationTime,
            };
            var createEventsubscription1 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName1, subscriptionData)).Value;
            Assert.That(createEventsubscription1, Is.Not.Null);
            Assert.That(SubscriptionProvisioningState.Succeeded, Is.EqualTo(createEventsubscription1.Data.ProvisioningState));

            // Validate get event subscription
            var getEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.That(getEventSubscription1, Is.Not.Null);
            Assert.That(namespaceTopicSubscriptionName1, Is.EqualTo(getEventSubscription1.Data.Name));
            Assert.That(DeliveryMode.Queue.ToString(), Is.EqualTo(getEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString()));
            Assert.AreEqual(getEventSubscription1.Data.DeliveryConfiguration.Queue.EventTimeToLive, TimeSpan.FromDays(1));
            Assert.AreEqual(5, getEventSubscription1.Data.DeliveryConfiguration.Queue.MaxDeliveryCount);

            //update event subscription
            DeliveryConfiguration deliveryConfiguration2 = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Queue.ToString(),
                Queue = new QueueInfo()
                {
                    EventTimeToLive = TimeSpan.FromDays(0.5),
                    MaxDeliveryCount = 6,
                    ReceiveLockDurationInSeconds = 120
                }
            };
            NamespaceTopicEventSubscriptionPatch subscriptionPatch = new NamespaceTopicEventSubscriptionPatch()
            {
                DeliveryConfiguration = deliveryConfiguration2
            };
            var updateEventSubscription1 = (await createEventsubscription1.UpdateAsync(WaitUntil.Completed, subscriptionPatch)).Value;
            Assert.That(updateEventSubscription1, Is.Not.Null);
            Assert.AreEqual(updateEventSubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var getUpdatedEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.That(getUpdatedEventSubscription1, Is.Not.Null);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Queue.ToString());
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.Queue.EventTimeToLive, TimeSpan.FromDays(0.5));
            Assert.AreEqual(6, getUpdatedEventSubscription1.Data.DeliveryConfiguration.Queue.MaxDeliveryCount);

            // List all event subscriptions
            var listAllSubscriptionsBefore = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsBefore, Is.Not.Null);
            Assert.AreEqual(1, listAllSubscriptionsBefore.Count);

            // Delete event subscriptions
            await getUpdatedEventSubscription1.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfter = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsAfter, Is.Not.Null);
            Assert.AreEqual(0, listAllSubscriptionsAfter.Count);

            // delete all resources
            await namespaceTopicsResponse1.DeleteAsync(WaitUntil.Completed);
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task NamespaceSubscriptionToEventHubCRUD()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceTopicName = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceTopicSubscriptionName1 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceTopicSubscriptionName2 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceTopicSubscriptionName3 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                {"originalTag1", "originalValue1"},
                {"originalTag2", "originalValue2"}
            },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };
            nameSpace.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"), userAssignedIdentity);

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createNamespaceResponse, Is.Not.Null);
                Assert.That(namespaceName, Is.EqualTo(createNamespaceResponse.Data.Name));
            });

            // create namespace topics
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.That(namespaceTopicsCollection, Is.Not.Null);
            var namespaceTopic = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopicsResponse1 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName, namespaceTopic)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(namespaceTopicsResponse1, Is.Not.Null);
                Assert.That(NamespaceTopicProvisioningState.Succeeded, Is.EqualTo(namespaceTopicsResponse1.Data.ProvisioningState));
            });
            Assert.That(namespaceTopicsResponse1.Data.EventRetentionInDays, Is.EqualTo(1));

            // create subscriptions
            var subscriptionsCollection = namespaceTopicsResponse1.GetNamespaceTopicEventSubscriptions();

            DeliveryConfiguration deliveryConfiguration = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Push.ToString(),
                Push = new PushInfo()
                {
                    DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity()
                    {
                        Identity = new EventSubscriptionIdentity
                        {
                            IdentityType = EventSubscriptionIdentityType.UserAssigned,
                            UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity",
                        },
                        Destination = new EventHubEventSubscriptionDestination()
                        {
                            ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk_test_easteuap/providers/Microsoft.EventHub/namespaces/testsdk-eh-namespace/eventhubs/eh1"),
                        },
                    }
                }
            };

            NamespaceTopicEventSubscriptionData subscriptionData = new NamespaceTopicEventSubscriptionData()
            {
                DeliveryConfiguration = deliveryConfiguration
            };
            var createEventsubscription1 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName1, subscriptionData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createEventsubscription1, Is.Not.Null);
                Assert.That(SubscriptionProvisioningState.Succeeded, Is.EqualTo(createEventsubscription1.Data.ProvisioningState));
            });

            var createEventsubscription2 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName2, subscriptionData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createEventsubscription2, Is.Not.Null);
                Assert.That(SubscriptionProvisioningState.Succeeded, Is.EqualTo(createEventsubscription2.Data.ProvisioningState));
            });

            var createEventsubscription3 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName3, subscriptionData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createEventsubscription3, Is.Not.Null);
                Assert.That(SubscriptionProvisioningState.Succeeded, Is.EqualTo(createEventsubscription3.Data.ProvisioningState));
            });

            // Validate get event subscription
            var getEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(getEventSubscription1, Is.Not.Null);
                Assert.That(namespaceTopicSubscriptionName1, Is.EqualTo(getEventSubscription1.Data.Name));
                Assert.That(DeliveryMode.Push.ToString(), Is.EqualTo(getEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString()));
            });

            //update event subscription
            DeliveryConfiguration deliveryConfiguration2 = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Push.ToString(),
                Push = new PushInfo()
                {
                    DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity()
                    {
                        Identity = new EventSubscriptionIdentity
                        {
                            IdentityType = EventSubscriptionIdentityType.UserAssigned,
                            UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity",
                        },
                        Destination = new EventHubEventSubscriptionDestination()
                        {
                            ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk_test_easteuap/providers/Microsoft.EventHub/namespaces/testsdk-eh-namespace/eventhubs/eh1"),
                        },
                    }
                }
            };
            NamespaceTopicEventSubscriptionPatch subscriptionPatch = new NamespaceTopicEventSubscriptionPatch()
            {
                DeliveryConfiguration = deliveryConfiguration2
            };
            var updateEventSubscription1 = (await createEventsubscription1.UpdateAsync(WaitUntil.Completed, subscriptionPatch)).Value;
            Assert.That(updateEventSubscription1, Is.Not.Null);
            Assert.AreEqual(updateEventSubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var getUpdatedEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.That(getUpdatedEventSubscription1, Is.Not.Null);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Push.ToString());

            // List all event subscriptions
            var listAllSubscriptionsBefore = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsBefore, Is.Not.Null);
            Assert.AreEqual(3, listAllSubscriptionsBefore.Count);

            // Delete event subscriptions
            await getUpdatedEventSubscription1.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfter = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsAfter, Is.Not.Null);
            Assert.AreEqual(2, listAllSubscriptionsAfter.Count);

            // delete all resources
            await createEventsubscription2.DeleteAsync(WaitUntil.Completed);
            await createEventsubscription3.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfterAllDeleted = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsAfterAllDeleted, Is.Not.Null);
            Assert.AreEqual(0, listAllSubscriptionsAfterAllDeleted.Count);
            await namespaceTopicsResponse1.DeleteAsync(WaitUntil.Completed);
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task NamespaceSubscriptionToWebhook()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceTopicName = Recording.GenerateAssetName("sdk-Namespace-Topic");
            var namespaceTopicSubscriptionName1 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceTopicSubscriptionName2 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceTopicSubscriptionName3 = Recording.GenerateAssetName("sdk-Namespace-Topic-Subscription");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity();
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                {"originalTag1", "originalValue1"},
                {"originalTag2", "originalValue2"}
            },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };
            nameSpace.Identity.UserAssignedIdentities.Add(new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity"), userAssignedIdentity);

            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createNamespaceResponse, Is.Not.Null);
                Assert.That(namespaceName, Is.EqualTo(createNamespaceResponse.Data.Name));
            });

            // create namespace topics
            var namespaceTopicsCollection = createNamespaceResponse.GetNamespaceTopics();
            Assert.That(namespaceTopicsCollection, Is.Not.Null);
            var namespaceTopic = new NamespaceTopicData()
            {
                EventRetentionInDays = 1
            };
            var namespaceTopicsResponse1 = (await namespaceTopicsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicName, namespaceTopic)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(namespaceTopicsResponse1, Is.Not.Null);
                Assert.That(NamespaceTopicProvisioningState.Succeeded, Is.EqualTo(namespaceTopicsResponse1.Data.ProvisioningState));
            });
            Assert.That(namespaceTopicsResponse1.Data.EventRetentionInDays, Is.EqualTo(1));

            // create subscriptions
            var subscriptionsCollection = namespaceTopicsResponse1.GetNamespaceTopicEventSubscriptions();

            DeliveryConfiguration deliveryConfiguration = new DeliveryConfiguration
            {
                DeliveryMode = DeliveryMode.Push,
                Push = new PushInfo
                {
                    // Event subscription destination endpoint. This endpoint URL is sanitized in the test environment. To run the test cases in Live/Record mode,
                    // replace the sig parameter with the actual signature from your Azure Logic App.
                    // Go to Azure Portal -> Logic Apps -> sdk-test-logic-app -> Overview -> Workflow URL
                    Destination = new WebHookEventSubscriptionDestination
                    {
                        Endpoint = new Uri(EventSubscriptionDestinationEndpoint),
                    }
                }
            };
            NamespaceTopicEventSubscriptionData subscriptionData = new NamespaceTopicEventSubscriptionData()
            {
                DeliveryConfiguration = deliveryConfiguration,
                EventDeliverySchema = DeliverySchema.CloudEventSchemaV10,
            };
            var createEventsubscription1 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName1, subscriptionData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createEventsubscription1, Is.Not.Null);
                Assert.That(SubscriptionProvisioningState.Succeeded, Is.EqualTo(createEventsubscription1.Data.ProvisioningState));
            });

            var createEventsubscription2 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName2, subscriptionData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createEventsubscription2, Is.Not.Null);
                Assert.That(SubscriptionProvisioningState.Succeeded, Is.EqualTo(createEventsubscription2.Data.ProvisioningState));
            });

            var createEventsubscription3 = (await subscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceTopicSubscriptionName3, subscriptionData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createEventsubscription3, Is.Not.Null);
                Assert.That(SubscriptionProvisioningState.Succeeded, Is.EqualTo(createEventsubscription3.Data.ProvisioningState));
            });

            // Validate get event subscription
            var getEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(getEventSubscription1, Is.Not.Null);
                Assert.That(namespaceTopicSubscriptionName1, Is.EqualTo(getEventSubscription1.Data.Name));
                Assert.That(DeliveryMode.Push.ToString(), Is.EqualTo(getEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString()));
            });
            // test for full uri of event subscription
            var eventSubscription1FullUri = (await getEventSubscription1.GetFullUriAsync());
            Assert.That(eventSubscription1FullUri, Is.Not.Null);

            //update event subscription
            DeliveryConfiguration deliveryConfiguration2 = new DeliveryConfiguration()
            {
                DeliveryMode = DeliveryMode.Push.ToString(),
                Push = new PushInfo()
                {
                    DeliveryWithResourceIdentity = new DeliveryWithResourceIdentity()
                    {
                        Identity = new EventSubscriptionIdentity
                        {
                            IdentityType = EventSubscriptionIdentityType.UserAssigned,
                            UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk_test_easteuap/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test_identity",
                        },
                        Destination = new EventHubEventSubscriptionDestination()
                        {
                            ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk_test_easteuap/providers/Microsoft.EventHub/namespaces/testsdk-eh-namespace/eventhubs/eh1"),
                        },
                    }
                }
            };
            NamespaceTopicEventSubscriptionPatch subscriptionPatch = new NamespaceTopicEventSubscriptionPatch()
            {
                DeliveryConfiguration = deliveryConfiguration2
            };
            var updateEventSubscription1 = (await createEventsubscription1.UpdateAsync(WaitUntil.Completed, subscriptionPatch)).Value;
            Assert.That(updateEventSubscription1, Is.Not.Null);
            Assert.AreEqual(updateEventSubscription1.Data.ProvisioningState, SubscriptionProvisioningState.Succeeded);

            var getUpdatedEventSubscription1 = (await subscriptionsCollection.GetAsync(namespaceTopicSubscriptionName1)).Value;
            Assert.That(getUpdatedEventSubscription1, Is.Not.Null);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.Name, namespaceTopicSubscriptionName1);
            Assert.AreEqual(getUpdatedEventSubscription1.Data.DeliveryConfiguration.DeliveryMode.ToString(), DeliveryMode.Push.ToString());

            // List all event subscriptions
            var listAllSubscriptionsBefore = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsBefore, Is.Not.Null);
            Assert.AreEqual(3, listAllSubscriptionsBefore.Count);

            // Delete event subscriptions
            await getUpdatedEventSubscription1.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfter = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsAfter, Is.Not.Null);
            Assert.AreEqual(2, listAllSubscriptionsAfter.Count);

            // delete all resources
            await createEventsubscription2.DeleteAsync(WaitUntil.Completed);
            await createEventsubscription3.DeleteAsync(WaitUntil.Completed);
            var listAllSubscriptionsAfterAllDeleted = await subscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listAllSubscriptionsAfterAllDeleted, Is.Not.Null);
            Assert.AreEqual(0, listAllSubscriptionsAfterAllDeleted.Count);
            await namespaceTopicsResponse1.DeleteAsync(WaitUntil.Completed);
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task NamespaceMQTTOperations()
        {
            await SetCollection();
            var namespaceName = Recording.GenerateAssetName("sdk-Namespace-");
            var namespaceSkuName = "Standard";
            var namespaceSku = new NamespaceSku()
            {
                Name = namespaceSkuName,
                Capacity = 1,
            };
            var nameSpace = new EventGridNamespaceData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                Sku = namespaceSku,
                IsZoneRedundant = true,
                TopicSpacesConfiguration = new TopicSpacesConfiguration()
                {
                    State = TopicSpacesConfigurationState.Enabled
                },
            };
            var createNamespaceResponse = (await NamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, nameSpace)).Value;

            // Create CA certificates
            var caCertificatesCollection = createNamespaceResponse.GetCaCertificates();
            // Use the following encoded certificate for testing purposes
            // "-----BEGIN CERTIFICATE-----\r\nMIIDQTCCAimgAwIBAgITBmyfz5m/jAo54vB4ikPmljZbyjANBgkqhkiG9w0BAQsFADA5MQswCQYDVQQGEwJVUzEPMA0GA1UEChMGQW1hem9uMRkwFwYDVQQDExBBbWF6b24gUm9vdCBDQSAxMB4XDTE1MDUyNjAwMDAwMFoXDTM4MDExNzAwMDAwMFowOTELMAkGA1UEBhMCVVMxDzANBgNVBAoTBkFtYXpvbjEZMBcGA1UEAxMQQW1hem9uIFJvb3QgQ0EgMTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALJ4gHHKeNXjca9HgFB0fW7Y14h29Jlo91ghYPl0hAEvrAIthtOgQ3pOsqTQNroBvo3bSMgHFzZM9O6II8c+6zf1tRn4SWiw3te5djgdYZ6k/oI2peVKVuRF4fn9tBb6dNqcmzU5L/qwIFAGbHrQgLKm+a/sRxmPUDgH3KKHOVj4utWp+UhnMJbulHheb4mjUcAwhmahRWa6VOujw5H5SNz/0egwLX0tdHA114gk957EWW67c4cX8jJGKLhD+rcdqsq08p8kDi1L93FcXmn/6pUCyziKrlA4b9v7LWIbxcceVOF34GfID5yHI9Y/QCB/IIDEgEw+OyQmjgSubJrIqg0CAwEAAaNCMEAwDwYDVR0TAQH/BAUwAwEB/zAOBgNVHQ8BAf8EBAMCAYYwHQYDVR0OBBYEFIQYzIU07LwMlJQuCFmcx7IQTgoIMA0GCSqGSIb3DQEBCwUAA4IBAQCY8jdaQZChGsV2USggNiMOruYou6r4lK5IpDB/G/wkjUu0yKGX9rbxenDIU5PMCCjjmCXPI6T53iHTfIUJrU6adTrCC2qJeHZERxhlbI1Bjjt/msv0tadQ1wUsN+gDS63pYaACbvXy8MWy7Vu33PqUXHeeE6V/Uq2V8viTO96LXFvKWlJbYK8U90vvo/ufQJVtMVT8QtPHRh8jrdkPSHCa2XV4cdFyQzR1bldZwgJcJmApzyMZFo6IQ6XU5MsI+yMRQ+hDKXJioaldXgjUkK642M4UwtBV8ob2xJNDd2ZhwLnoQdeXeGADbkpyrqXRfboQnoZsG4q5WTP468SQvvG5\r\n-----END CERTIFICATE-----";
            // TODO : Remove the origiinal certificate from the comment.
            var encodedCertificate = "SANITIZED_ENCODED_CERTIFICATE";

            var caCertificateData1 = new CaCertificateData()
            {
                Description = "TestCertificate1",
                EncodedCertificate = encodedCertificate
            };
            var caCertificateData2 = new CaCertificateData()
            {
                Description = "TestCertificate2",
                EncodedCertificate = encodedCertificate
            };
            var caCertificateData3 = new CaCertificateData()
            {
                Description = "TestCertificate3",
                EncodedCertificate = encodedCertificate
            };

            var createCaCertificateResponse1 = (await caCertificatesCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testCertificate1", caCertificateData1)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createCaCertificateResponse1, Is.Not.Null);
                Assert.That(CaCertificateProvisioningState.Succeeded, Is.EqualTo(createCaCertificateResponse1.Data.ProvisioningState));
            });

            var createCaCertificateResponse2 = (await caCertificatesCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testCertificate2", caCertificateData2)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createCaCertificateResponse2, Is.Not.Null);
                Assert.That(CaCertificateProvisioningState.Succeeded, Is.EqualTo(createCaCertificateResponse2.Data.ProvisioningState));
            });

            var createCaCertificateResponse3 = (await caCertificatesCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testCertificate3", caCertificateData3)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createCaCertificateResponse3, Is.Not.Null);
                Assert.That(CaCertificateProvisioningState.Succeeded, Is.EqualTo(createCaCertificateResponse3.Data.ProvisioningState));
            });

            //Get CaCertificate
            var getCaCertificate1Response = (await caCertificatesCollection.GetAsync("testCertificate1")).Value;
            Assert.That(getCaCertificate1Response, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getCaCertificate1Response.Data.Name, Is.EqualTo("testCertificate1"));
                Assert.That(caCertificateData1.EncodedCertificate, Is.EqualTo(getCaCertificate1Response.Data.EncodedCertificate));
            });

            //List CaCertificates
            var listCaCertificatesBeforeDeletion = await caCertificatesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listCaCertificatesBeforeDeletion, Is.Not.Null);
            Assert.That(listCaCertificatesBeforeDeletion, Has.Count.EqualTo(3));

            await getCaCertificate1Response.DeleteAsync(WaitUntil.Completed);

            var listCaCertificatesAfterDeletion = await caCertificatesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listCaCertificatesAfterDeletion, Is.Not.Null);
            Assert.That(listCaCertificatesAfterDeletion, Has.Count.EqualTo(2));

            // Update certificate by deleting and recreating with a new description
            await createCaCertificateResponse1.DeleteAsync(WaitUntil.Completed);
            var updatedCaCertData = new CaCertificateData()
            {
                Description = "UpdatedDescription",
                EncodedCertificate = encodedCertificate
            };
            var recreateCaCertResponse = (await caCertificatesCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testCertificate1", updatedCaCertData)).Value;
            Assert.That(recreateCaCertResponse, Is.Not.Null);
            Assert.That(recreateCaCertResponse.Data.Description, Is.EqualTo("UpdatedDescription"));

            await recreateCaCertResponse.DeleteAsync(WaitUntil.Completed);
            await createCaCertificateResponse2.DeleteAsync(WaitUntil.Completed);
            await createCaCertificateResponse3.DeleteAsync(WaitUntil.Completed);

            var listCaCertificatesAfterAllDeleted = await caCertificatesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listCaCertificatesAfterAllDeleted, Is.Not.Null);
            Assert.That(listCaCertificatesAfterAllDeleted.Count, Is.EqualTo(0));

            // create clients
            var clientCollection = createNamespaceResponse.GetEventGridNamespaceClients();
            string clientName1 = "clientName1";
            string clientName2 = "clientName2";
            var clientCertificateAuthentication = new ClientCertificateAuthentication()
            {
                ValidationScheme = ClientCertificateValidationScheme.ThumbprintMatch,
            };
            clientCertificateAuthentication.AllowedThumbprints.Add("934367bf1c97033f877db0f15cb1b586957d313");
            EventGridNamespaceClientData clientData = new EventGridNamespaceClientData()
            {
                ClientCertificateAuthentication = clientCertificateAuthentication,
                Description = "Before"
            };

            var createClientResponse1 = (await clientCollection.CreateOrUpdateAsync(WaitUntil.Completed, clientName1, clientData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createClientResponse1, Is.Not.Null);
                Assert.That(clientName1, Is.EqualTo(createClientResponse1.Data.Name));
                Assert.That(EventGridNamespaceClientProvisioningState.Succeeded, Is.EqualTo(createClientResponse1.Data.ProvisioningState));
            });
            var createClientResponse2 = (await clientCollection.CreateOrUpdateAsync(WaitUntil.Completed, clientName2, clientData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createClientResponse2, Is.Not.Null);
                Assert.That(clientName2, Is.EqualTo(createClientResponse2.Data.Name));
                Assert.That(EventGridNamespaceClientProvisioningState.Succeeded, Is.EqualTo(createClientResponse2.Data.ProvisioningState));
            });

            //update client
            EventGridNamespaceClientData updatedClientData = new EventGridNamespaceClientData()
            {
                ClientCertificateAuthentication = clientCertificateAuthentication,
                Description = "After"
            };
            var updateClientResponse = (await createClientResponse1.UpdateAsync(WaitUntil.Completed, updatedClientData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(updateClientResponse, Is.Not.Null);
                Assert.That(EventGridNamespaceClientProvisioningState.Succeeded, Is.EqualTo(updateClientResponse.Data.ProvisioningState));
            });

            // Get updated client
            var getClientResponse = (await updateClientResponse.GetAsync()).Value;
            Assert.Multiple(() =>
            {
                Assert.That(getClientResponse, Is.Not.Null);
                Assert.That(EventGridNamespaceClientProvisioningState.Succeeded, Is.EqualTo(getClientResponse.Data.ProvisioningState));
                Assert.That(clientName1, Is.EqualTo(getClientResponse.Data.Name));
            });
            Assert.That(getClientResponse.Data.Description, Is.EqualTo("After"));

            // List clients
            var getAllClientsBeforeDeletion = await clientCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(getAllClientsBeforeDeletion, Is.Not.Null);
            Assert.That(getAllClientsBeforeDeletion, Has.Count.EqualTo(2));
            await getClientResponse.DeleteAsync(WaitUntil.Completed);
            await createClientResponse2.DeleteAsync(WaitUntil.Completed);
            var getAllClientsAfterDeletion = await clientCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(getAllClientsAfterDeletion, Is.Not.Null);
            Assert.That(getAllClientsAfterDeletion.Count, Is.EqualTo(0));

            //create client groups
            var clientGroupCollection = createNamespaceResponse.GetEventGridNamespaceClientGroups();
            string clientGroupName1 = "clientGroupName1";
            string clientGroupName2 = "clientGroupName2";
            EventGridNamespaceClientGroupData clientGroupData = new EventGridNamespaceClientGroupData()
            {
                Query = "attributes.testType = 'synthetics'"
            };

            var createClientGroupResponse1 = (await clientGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, clientGroupName1, clientGroupData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createClientGroupResponse1, Is.Not.Null);
                Assert.That(clientGroupName1, Is.EqualTo(createClientGroupResponse1.Data.Name));
                Assert.That(ClientGroupProvisioningState.Succeeded, Is.EqualTo(createClientGroupResponse1.Data.ProvisioningState));
            });
            var createClientGroupResponse2 = (await clientGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, clientGroupName2, clientGroupData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(createClientGroupResponse2, Is.Not.Null);
                Assert.That(clientGroupName2, Is.EqualTo(createClientGroupResponse2.Data.Name));
                Assert.That(ClientGroupProvisioningState.Succeeded, Is.EqualTo(createClientGroupResponse2.Data.ProvisioningState));
            });

            //Get Client Group
            var getClientGroup1Response = (await clientGroupCollection.GetAsync("clientGroupName1")).Value;
            Assert.That(getClientGroup1Response, Is.Not.Null);
            Assert.That(getClientGroup1Response.Data.Name, Is.EqualTo("clientGroupName1"));

            //List Client Groups ==> Note : 1 extra default client group is added by the service.
            var listCientGroupBeforeDeletion = await clientGroupCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listCientGroupBeforeDeletion, Is.Not.Null);
            Assert.That(listCientGroupBeforeDeletion, Has.Count.EqualTo(3));

            await getClientGroup1Response.DeleteAsync(WaitUntil.Completed);

            var listCientGroupAfterDeletion = await clientGroupCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listCientGroupAfterDeletion, Is.Not.Null);
            Assert.That(listCientGroupAfterDeletion, Has.Count.EqualTo(2));

            // Create topic spaces
            var topicSpacesCollection = createNamespaceResponse.GetTopicSpaces();
            var topicSpaceName1 = "topicSpace1";
            var topicSpaceName2 = "topicSpace2";
            TopicSpaceData topicSpaceData = new TopicSpaceData();
            topicSpaceData.TopicTemplates.Add("testTopicTemplate1");
            var topicSpaceResponse1 = (await topicSpacesCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicSpaceName1, topicSpaceData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(topicSpaceResponse1, Is.Not.Null);
                Assert.That(TopicSpaceProvisioningState.Succeeded, Is.EqualTo(topicSpaceResponse1.Data.ProvisioningState));
                Assert.That(topicSpaceName1, Is.EqualTo(topicSpaceResponse1.Data.Name));
            });
            var topicSpaceResponse2 = (await topicSpacesCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicSpaceName2, topicSpaceData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(topicSpaceResponse2, Is.Not.Null);
                Assert.That(TopicSpaceProvisioningState.Succeeded, Is.EqualTo(topicSpaceResponse2.Data.ProvisioningState));
                Assert.That(topicSpaceName2, Is.EqualTo(topicSpaceResponse2.Data.Name));
            });

            // get topic spaces
            var getTopicSpaceResponse1 = (await topicSpacesCollection.GetAsync(topicSpaceName1)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(getTopicSpaceResponse1, Is.Not.Null);
                Assert.That(TopicSpaceProvisioningState.Succeeded, Is.EqualTo(getTopicSpaceResponse1.Data.ProvisioningState));
                Assert.That(topicSpaceName1, Is.EqualTo(getTopicSpaceResponse1.Data.Name));
            });
            Assert.That(getTopicSpaceResponse1.Data.TopicTemplates, Has.Count.EqualTo(1));

            // update topic spaces
            TopicSpaceData updateTopicSpaceData = new TopicSpaceData();
            updateTopicSpaceData.TopicTemplates.Add("testTopicTemplate1");
            updateTopicSpaceData.TopicTemplates.Add("testTopicTemplate2");
            var updateTopicSpaceResponse = (await getTopicSpaceResponse1.UpdateAsync(WaitUntil.Completed, updateTopicSpaceData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(updateTopicSpaceResponse, Is.Not.Null);
                Assert.That(TopicSpaceProvisioningState.Succeeded, Is.EqualTo(updateTopicSpaceResponse.Data.ProvisioningState));
                Assert.That(topicSpaceName1, Is.EqualTo(updateTopicSpaceResponse.Data.Name));
            });
            Assert.That(updateTopicSpaceResponse.Data.TopicTemplates, Has.Count.EqualTo(2));

            //List topic spaces
            var listTopicSpacesBeforeDeletion = await topicSpacesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listTopicSpacesBeforeDeletion, Is.Not.Null);
            Assert.That(listTopicSpacesBeforeDeletion, Has.Count.EqualTo(2));
            await getTopicSpaceResponse1.DeleteAsync(WaitUntil.Completed);
            var listTopicSpacesAfterDeletion = await topicSpacesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listTopicSpacesAfterDeletion, Is.Not.Null);
            Assert.That(listTopicSpacesAfterDeletion, Has.Count.EqualTo(1));

            // Create Permission Bindings
            var permissionBindingsCollection = createNamespaceResponse.GetEventGridNamespacePermissionBindings();
            var PermissionBindingName1 = "PermissionBinding1";
            var PermissionBindingName2 = "PermissionBinding2";
            EventGridNamespacePermissionBindingData permissionBindingData = new EventGridNamespacePermissionBindingData()
            {
                TopicSpaceName = topicSpaceName2,
                ClientGroupName = clientGroupName2,
                Permission = PermissionType.Subscriber
            };
            var permissionBindingResponse1 = (await permissionBindingsCollection.CreateOrUpdateAsync(WaitUntil.Completed, PermissionBindingName1, permissionBindingData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(permissionBindingResponse1, Is.Not.Null);
                Assert.That(PermissionBindingProvisioningState.Succeeded, Is.EqualTo(permissionBindingResponse1.Data.ProvisioningState));
                Assert.That(PermissionBindingName1, Is.EqualTo(permissionBindingResponse1.Data.Name));
                Assert.That(PermissionType.Subscriber, Is.EqualTo(permissionBindingResponse1.Data.Permission));
            });

            var permissionBindingResponse2 = (await permissionBindingsCollection.CreateOrUpdateAsync(WaitUntil.Completed, PermissionBindingName2, permissionBindingData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(permissionBindingResponse2, Is.Not.Null);
                Assert.That(PermissionBindingProvisioningState.Succeeded, Is.EqualTo(permissionBindingResponse2.Data.ProvisioningState));
                Assert.That(PermissionBindingName2, Is.EqualTo(permissionBindingResponse2.Data.Name));
            });

            // udpate permission bindings
            EventGridNamespacePermissionBindingData permissionBindingDataAfter = new EventGridNamespacePermissionBindingData()
            {
                TopicSpaceName = topicSpaceName2,
                ClientGroupName = clientGroupName2,
                Permission = PermissionType.Publisher
            };
            var updatePermissionBindingResponse = (await permissionBindingResponse1.UpdateAsync(WaitUntil.Completed, permissionBindingDataAfter)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(updatePermissionBindingResponse, Is.Not.Null);
                Assert.That(PermissionBindingProvisioningState.Succeeded, Is.EqualTo(updatePermissionBindingResponse.Data.ProvisioningState));
            });

            // get permission bindings
            var getPermissionBindingResponse = (await permissionBindingsCollection.GetAsync(PermissionBindingName1)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(getPermissionBindingResponse, Is.Not.Null);
                Assert.That(PermissionBindingName1, Is.EqualTo(getPermissionBindingResponse.Data.Name));
                Assert.That(PermissionType.Publisher, Is.EqualTo(getPermissionBindingResponse.Data.Permission));
            });

            // list permission bindings
            var getAllPermissionBindingsBeforeDelete = await permissionBindingsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(getAllPermissionBindingsBeforeDelete, Is.Not.Null);
            Assert.That(getAllPermissionBindingsBeforeDelete, Has.Count.EqualTo(2));

            // delete permission bindings
            await getPermissionBindingResponse.DeleteAsync(WaitUntil.Completed);
            await permissionBindingResponse2.DeleteAsync(WaitUntil.Completed);

            var getAllPermissionBindingsAfterDelete = await permissionBindingsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(getAllPermissionBindingsAfterDelete, Is.Not.Null);
            Assert.That(getAllPermissionBindingsAfterDelete.Count, Is.EqualTo(0));

            //Delete client, client group and topic space
            await createClientResponse2.DeleteAsync(WaitUntil.Completed);
            await createClientGroupResponse2.DeleteAsync(WaitUntil.Completed);
            var listCientGroupAfterAllDeleted = await clientGroupCollection.GetAllAsync().ToEnumerableAsync();
            var listClientsAfterAllDeleted = await clientCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listClientsAfterAllDeleted, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(listClientsAfterAllDeleted.Count, Is.EqualTo(0));
                Assert.That(listCientGroupAfterAllDeleted, Is.Not.Null);
            });
            Assert.That(listCientGroupAfterAllDeleted, Has.Count.EqualTo(1));

            await topicSpaceResponse2.DeleteAsync(WaitUntil.Completed);
            var listTopicSpaceAfterAllDeleted = await topicSpacesCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listTopicSpaceAfterAllDeleted, Is.Not.Null);
            Assert.That(listTopicSpaceAfterAllDeleted.Count, Is.EqualTo(0));

            // delete namespace and resource group
            await createNamespaceResponse.DeleteAsync(WaitUntil.Completed);
            await ResourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
