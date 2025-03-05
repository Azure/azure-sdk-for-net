// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecretsStoreExtension.Models;
using NUnit.Framework;

using static Azure.ResourceManager.SecretsStoreExtension.Tests.SseTestData;

namespace Azure.ResourceManager.SecretsStoreExtension.Tests
{
    // Primary constructor takes objects which are used to manage RP objects.
    internal class SecretProviderClassTests(
        ArmClient client, SubscriptionResource subscription, ResourceGroupResource rg,
        SecretsStoreExtensionManagementTestEnvironment te)
    {
        // This is used from multiple methods so store as an instance variable for ease of access.
        private AzureKeyVaultSecretProviderClassCollection _akvspcc;

        // Create, view, update, tag, and delete an SPC.
        // The SPC and SS tests both require an SPC.  Uses the GoF strategy pattern to avoid duplication.
        internal async Task DoSecretProviderClassTestAsync(Func<Task> act = null)
        {
            _akvspcc = rg.GetAzureKeyVaultSecretProviderClasses();

            await CreateAsync();
            await TestExistsAndGetAsync(true);

            // Test SPC.
            if (act is null)
            {
                await TestUpdate();
                await TestTags();
                await TestExtensionAsync();
            }
            // Non-SPC (i.e., SecretSync) test.
            else
            {
                await act.Invoke();
            }

            await DeleteAsync();
            await TestExistsAndGetAsync(false);
        }

        // Create the SPC via the RP API.
        private async Task CreateAsync()
        {
            var location = new AzureLocation(te.SpcLocation);

            AzureKeyVaultSecretProviderClassData data = new(location)
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    Name = $"/subscriptions/{te.SpcSubscriptionId}/resourceGroups/{te.ClusterResourceGroup}/providers/microsoft.extendedlocation/customLocations/{CustomLocationName}",
                    ExtendedLocationType = new("CustomLocation")
                },
                Properties = new AzureKeyVaultSecretProviderClassProperties(te.SpcKeyVaultName, te.SpcClientId, te.SpcTenantId)
                {
                    Objects = CreateObjectString(RpSecretName1, RpSecretName2)
                },
                Tags = { }
            };

            // AzureKeyVaultSecretProviderClassCollection.CreateOrUpdateAsync
            await _akvspcc.CreateOrUpdateAsync(WaitUntil.Completed, SpcName, data);
        }

        // Tests whether the SPC exists and, if so, that it can be retrieved via various APIs
        // and contains the expected data.
        private async Task TestExistsAndGetAsync(bool shouldExist)
        {
            // AzureKeyVaultSecretProviderClassCollection.ExistsAsync
            var exists = (await _akvspcc.ExistsAsync(SpcName)).Value;
            Assert.AreEqual(exists, shouldExist);

            // AzureKeyVaultSecretProviderClassCollection.GetAsync
            if (shouldExist)
            {
                AzureKeyVaultSecretProviderClassResource spc = (await _akvspcc.GetAsync(SpcName)).Value;
                CheckContents(spc);
            }

            // AzureKeyVaultSecretProviderClassCollection.GetIfExistsAsync
            NullableResponse<AzureKeyVaultSecretProviderClassResource> nr = await _akvspcc.GetIfExistsAsync(SpcName);
            Assert.AreEqual(nr.HasValue, shouldExist);
            if (shouldExist)
            {
                CheckContents(nr.Value);
                // AzureKeyVaultSecretProviderClassResource.GetAsync
                AzureKeyVaultSecretProviderClassResource spc = (await nr.Value.GetAsync()).Value;
                CheckContents(spc);
            }

            // AzureKeyVaultSecretProviderClassCollection.GetAllAsync
            List<AzureKeyVaultSecretProviderClassResource> spcs = await _akvspcc.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(spcs.Any(), shouldExist);
            if (shouldExist)
            {
                Assert.AreEqual(spcs.Count, 1);
                CheckContents(spcs[0]);
            }
        }

        // Exercise the update API by changing which AKV secrets are listed in the SPC.
        private async Task TestUpdate()
        {
            await SetSecretNames(RpSecretName3, RpSecretName4);
            await SetSecretNames(RpSecretName1, RpSecretName2);
        }

        // Helper function for UpdateSecretName sets secret names in the SPC, to test update API.
        private async Task SetSecretNames(string secretNameA, string secretNameB)
        {
            AzureKeyVaultSecretProviderClassResource spc = await GetSpc();

            var patch = new AzureKeyVaultSecretProviderClassPatch()
            {
                Properties = new AzureKeyVaultSecretProviderClassUpdateProperties()
                {
                    Objects = CreateObjectString(secretNameA, secretNameB)
                }
            };

            // AzureKeyVaultSecretProviderClassResource.UpdateAsync
            await spc.UpdateAsync(WaitUntil.Completed, patch);
            await GetAndCheckContentsAsync(expectedSecretName1: secretNameA, expectedSecretName2: secretNameB);
        }

        // Add, remove, and replace tags.
        private async Task TestTags()
        {
            AzureKeyVaultSecretProviderClassResource spc = await GetSpc();

            // SecretSyncResource.SetTagsAsync
            var expectedTags = new Dictionary<string, string>();
            await spc.SetTagsAsync(expectedTags);
            spc = await GetAndCheckContentsAsync(expectedTags: expectedTags);

            // AzureKeyVaultSecretProviderClassResource.AddTagAsync
            expectedTags = new Dictionary<string, string> { { Tag1Name, Tag1Value } };
            await spc.AddTagAsync(Tag1Name, Tag1Value);
            spc = await GetAndCheckContentsAsync(expectedTags: expectedTags);

            // AzureKeyVaultSecretProviderClassResource.AddTagAsync
            expectedTags.Add(Tag2Name, Tag2Value);
            await spc.AddTagAsync(Tag2Name, Tag2Value);
            spc = await GetAndCheckContentsAsync(expectedTags: expectedTags);

            // AzureKeyVaultSecretProviderClassResource.RemoveTagAsync
            expectedTags.Remove(Tag1Name);
            await spc.RemoveTagAsync(Tag1Name);
            spc = await GetAndCheckContentsAsync(expectedTags: expectedTags);

            // AzureKeyVaultSecretProviderClassResource.SetTagsAsync
            expectedTags = new Dictionary<string, string> { { Tag3Name, Tag3Value }, { Tag4Name, Tag4Value } };
            await spc.SetTagsAsync(expectedTags);
            await GetAndCheckContentsAsync(expectedTags: expectedTags);
        }

        // Test extension APIs which are defined in SecretsStoreExtensionExtensions.
        private async Task TestExtensionAsync()
        {
            // SecretsStoreExtensionExtensions.GetAzureKeyVaultSecretProviderClasses (extends ResourceGroupResource)
            // is already called from DoSecretProviderClassTestAsync.

            // SecretsStoreExtensionExtensions.GetAzureKeyVaultSecretProviderClassAsync (extends ResourceGroupResource).
            AzureKeyVaultSecretProviderClassResource spc = (await rg.GetAzureKeyVaultSecretProviderClassAsync(SpcName)).Value;
            CheckContents(spc);

            // SecretsStoreExtensionExtensions.GetAzureKeyVaultSecretProviderClassResource (extends ArmClient).
            spc = client.GetAzureKeyVaultSecretProviderClassResource(spc.Id);
            spc = (await spc.GetAsync()).Value;
            CheckContents(spc);

            // SecretsStoreExtensionExtensions.GetAzureKeyVaultSecretProviderClassesAsync (extends SubscriptionResource).
            List<AzureKeyVaultSecretProviderClassResource> spcsAsync = await subscription.GetAzureKeyVaultSecretProviderClassesAsync().ToEnumerableAsync();
            Assert.AreEqual(spcsAsync.Count, 1);
            CheckContents(spcsAsync[0]);
        }

        // Delete the SPC via the RP API.
        private async Task DeleteAsync()
        {
            AzureKeyVaultSecretProviderClassResource spc = await GetSpc();
            await spc.DeleteAsync(WaitUntil.Completed);

            var exists = (await _akvspcc.ExistsAsync(spc.Id.Name)).Value;
            Assert.IsFalse(exists);
        }

        // Retrieve the latest version of the SPC.
        private async Task<AzureKeyVaultSecretProviderClassResource> GetSpc()
        {
            return (await rg.GetAzureKeyVaultSecretProviderClassAsync(SpcName)).Value;
        }

        // Retrieve the latest version of the SPC and optionally check whether certain fields
        // contain the supplied expected values.
        private async Task<AzureKeyVaultSecretProviderClassResource> GetAndCheckContentsAsync(
            string expectedSecretName1 = null, string expectedSecretName2 = null,
            Dictionary<string, string> expectedTags = null)
        {
            // Short delay to allow server-side resources to update.
            var t = TimeSpan.FromSeconds(4);
            await Task.Delay(t).ConfigureAwait(false);

            AzureKeyVaultSecretProviderClassResource spc = await GetSpc();
            CheckContents(spc, expectedSecretName1, expectedSecretName2, expectedTags);
            return spc;
        }

        // Ensure the supplied SPC contains the expected data.
        private void CheckContents(
            AzureKeyVaultSecretProviderClassResource spc,
            string expectedSecretName1 = null, string expectedSecretName2 = null,
            Dictionary<string, string> expectedTags = null)
        {
            Assert.AreEqual(SpcName, spc.Data.Name);
            Assert.AreEqual(te.SpcKeyVaultName, spc.Data.Properties.KeyvaultName);

            Assert.AreEqual(te.SpcClientId, spc.Data.Properties.ClientId);
            Assert.AreEqual(te.SpcTenantId, spc.Data.Properties.TenantId);

            // Ensure the supplied object has the expected secret name.
            if (expectedSecretName1 is not null && expectedSecretName2 is not null)
            {
                string expectedObjects = CreateObjectString(expectedSecretName1, expectedSecretName2);
                Assert.AreEqual(spc.Data.Properties.Objects, expectedObjects);
            }

            // Ensure the supplied object has the expected tags.
            if (expectedTags is not null)
            {
                Assert.AreEqual(expectedTags.Count, spc.Data.Tags.Count);
                foreach (KeyValuePair<string, string> kv in spc.Data.Tags)
                {
                    Assert.IsTrue(expectedTags.ContainsKey(kv.Key));
                    Assert.AreEqual(expectedTags[kv.Key], kv.Value);
                }
            }
        }

        // Generate the string value for the objects field, which contains the secret names and types.
        private static string CreateObjectString(string secretName1, string secretName2)
        {
            return $"array:\n  - |\n    objectName: {secretName1}\n    objectType: secret\n  - |\n    objectName: {secretName2}\n    objectType: secret\n";
        }
    }
}
