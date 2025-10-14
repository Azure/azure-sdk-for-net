// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecretsStoreExtension.Models;

using static Azure.ResourceManager.SecretsStoreExtension.Tests.SseTestData;

namespace Azure.ResourceManager.SecretsStoreExtension.Tests
{
    // Primary constructor takes objects which are used to manage RP objects.
    internal class SecretSyncTests(
        ArmClient client, SubscriptionResource subscription,
        ResourceGroupResource rg, SecretSyncCollection ssc,
        SecretsStoreExtensionManagementTestEnvironment te, Func<int, Task> delay)
    {
        internal async Task TestCreateAsync()
        {
            await CreateAsync();
            await TestExistsAndGetAsync(true);
        }

        internal async Task TestDeleteAsync()
        {
            await DeleteAsync();
            await TestExistsAndGetAsync(false);
        }

        // Create a SecretSync via the RP API.
        private async Task CreateAsync()
        {
            var location = new AzureLocation(te.SpcLocation);
            var secretType = new KubernetesSecretType("Opaque");
            KubernetesSecretObjectMapping[] oms = {
                new(sourcePath: RpSecretName1, targetKey: RpSecretName1)
            };

            var ssData = new SecretSyncData(location)
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    Name = $"/subscriptions/{te.SpcSubscriptionId}/resourceGroups/{te.ClusterResourceGroup}/providers/microsoft.extendedlocation/customLocations/{CustomLocationName}",
                    ExtendedLocationType = new("CustomLocation")
                },
                Properties = new SecretSyncProperties(SpcName, ServiceAccountName, secretType, oms)
            };

            await ssc.CreateOrUpdateAsync(WaitUntil.Completed, SsName, ssData);
        }

        // Tests whether the SecretSync exists and, if so, that it can be retrieved via various APIs
        // and contains the expected data.
        private async Task TestExistsAndGetAsync(bool shouldExist)
        {
            // SecretSyncCollection.ExistsAsync
            var exists = (await ssc.ExistsAsync(SsName)).Value;
            Assert.AreEqual(exists, shouldExist);

            // SecretSyncCollection.GetAsync
            if (shouldExist)
            {
                SecretSyncResource ss = (await ssc.GetAsync(SsName)).Value;
                CheckContents(ss);
            }

            // SecretSyncCollection.GetIfExistsAsync
            NullableResponse<SecretSyncResource> nr = await ssc.GetIfExistsAsync(SsName);
            Assert.AreEqual(nr.HasValue, shouldExist);
            if (shouldExist)
            {
                CheckContents(nr.Value);
                // SecretSyncResource.GetAsync
                SecretSyncResource ss = (await nr.Value.GetAsync()).Value;
                CheckContents(ss);
            }

            // SecretSyncCollection.GetAllAsync
            List<SecretSyncResource> secretSyncs = await ssc.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(secretSyncs.Any(), shouldExist);
            if (shouldExist)
            {
                Assert.AreEqual(secretSyncs.Count, 1);
                CheckContents(secretSyncs[0]);
            }
        }

        // Test the update API by changing the source path and target key.
        internal async Task TestUpdateAsync()
        {
            await SetSecretMappingAsync(RpSecretName2, RpSecretName2);
            await SetSecretMappingAsync(RpSecretName1, RpSecretName1);
        }

        // Helper function for TestUpdate updates the source path and target key,
        // and then tests the object contains the expected values.
        private async Task SetSecretMappingAsync(string sourcePath, string targetKey)
        {
            SecretSyncResource ss = await GetSecretSyncAsync();

            SecretSyncProperties props = ss.Data.Properties;
            KubernetesSecretObjectMapping[] oms = {
                new(sourcePath: sourcePath, targetKey: targetKey)
            };

            var patch = new SecretSyncPatch()
            {
                Properties = new SecretSyncUpdateProperties(
                    secretProviderClassName: props.SecretProviderClassName,
                    serviceAccountName: props.ServiceAccountName,
                    forceSynchronization: props.ForceSynchronization,
                    objectSecretMapping: oms,
                    serializedAdditionalRawData: null)
            };

            await ss.UpdateAsync(WaitUntil.Completed, patch);
            await GetAndCheckContentsAsync(expectedSourcePath: sourcePath, expectedTargetKey: targetKey);
        }

        // Add, remove, and replace tags.
        internal async Task TestTagsAsync()
        {
            SecretSyncResource ss = await GetSecretSyncAsync();

            // SecretSyncResource.SetTagsAsync
            var expectedTags = new Dictionary<string, string>();
            await ss.SetTagsAsync(expectedTags);
            ss = await GetAndCheckContentsAsync(expectedTags: expectedTags);

            // SecretSyncResource.AddTagAsync
            expectedTags.Add(Tag1Name, Tag1Value);
            await ss.AddTagAsync(Tag1Name, Tag1Value);
            ss = await GetAndCheckContentsAsync(expectedTags: expectedTags);

            // SecretSyncResource.AddTagAsync
            expectedTags.Add(Tag2Name, Tag2Value);
            await ss.AddTagAsync(Tag2Name, Tag2Value);
            ss = await GetAndCheckContentsAsync(expectedTags: expectedTags);

            // SecretSyncResource.RemoveTagAsync
            expectedTags.Remove(Tag1Name);
            await ss.RemoveTagAsync(Tag1Name);
            ss = await GetAndCheckContentsAsync(expectedTags: expectedTags);

            // SecretSyncResource.SetTagsAsync
            expectedTags = new Dictionary<string, string> { { Tag3Name, Tag3Value }, { Tag4Name, Tag4Value } };
            await ss.SetTagsAsync(expectedTags);
            await GetAndCheckContentsAsync(expectedTags: expectedTags);
        }

        // Test extension APIs which are defined in SecretsStoreExtensionExtensions.
        internal async Task TestExtensionsAsync()
        {
            // SecretsStoreExtensionExtensions.GetSecretSyncs (extends ResourceGroupResource)
            // is already called from DoTestSecretSyncCrudAsync.

            SecretSyncResource ss = await GetSecretSyncAsync();

            // SecretsStoreExtensionExtensions.GetSecretSyncResource (extends ArmClient).
            ss = client.GetSecretSyncResource(ss.Id);
            ss = (await ss.GetAsync()).Value;
            CheckContents(ss);

            // SecretsStoreExtensionExtensions.GetSecretSyncsAsync (extends ResourceGroupResource)
            ss = (await rg.GetSecretSyncAsync(SsName)).Value;
            CheckContents(ss);

            // SecretsStoreExtensionExtensions.GetSecretSyncsAsync (extends SubscriptionResource)
            List<SecretSyncResource> secretSyncsAsync = await subscription.GetSecretSyncsAsync().ToEnumerableAsync();
            Assert.AreEqual(secretSyncsAsync.Count, 1);
            CheckContents(secretSyncsAsync[0]);
        }

        // Delete the SecretSync via the RP API.
        private async Task DeleteAsync()
        {
            SecretSyncResource ss = await GetSecretSyncAsync();
            await ss.DeleteAsync(WaitUntil.Completed);
        }

        // Retrieve the latest version of the SecretSync.
        private async Task<SecretSyncResource> GetSecretSyncAsync()
        {
            return (await rg.GetSecretSyncAsync(SsName)).Value;
        }

        // Retrieve the latest version of the SecretSync and optionally check whether certain fields
        // contain the supplied expected values.
        private async Task<SecretSyncResource> GetAndCheckContentsAsync(
            string expectedSourcePath = null, string expectedTargetKey = null, Dictionary<string, string> expectedTags = null)
        {
            await delay(3);

            SecretSyncResource ss = await GetSecretSyncAsync();
            CheckContents(ss, expectedSourcePath, expectedTargetKey, expectedTags);
            return ss;
        }

        // Ensure the supplied SecretSync contains the expected data.
        private static void CheckContents(
            SecretSyncResource ss,
            string expectedSourcePath = null, string expectedTargetPath = null,
            Dictionary<string, string> expectedTags = null)
        {
            Assert.AreEqual(ss.Data.Name, SsName);
            Assert.AreEqual(ss.Data.Properties.SecretProviderClassName, SpcName);
            Assert.AreEqual(ss.Data.Properties.ServiceAccountName, ServiceAccountName);

            if (expectedSourcePath is not null && expectedTargetPath is not null)
            {
                var osm = ss.Data.Properties.ObjectSecretMapping;
                Assert.AreEqual(osm.Count, 1);
                Assert.AreEqual(osm[0].SourcePath, expectedSourcePath);
                Assert.AreEqual(osm[0].TargetKey, expectedTargetPath);
            }

            if (expectedTags is not null)
            {
                Assert.AreEqual(expectedTags.Count, ss.Data.Tags.Count);
                foreach (KeyValuePair<string, string> kv in ss.Data.Tags)
                {
                    Assert.IsTrue(expectedTags.ContainsKey(kv.Key));
                    Assert.AreEqual(expectedTags[kv.Key], kv.Value);
                }
            }
        }
    }
}
