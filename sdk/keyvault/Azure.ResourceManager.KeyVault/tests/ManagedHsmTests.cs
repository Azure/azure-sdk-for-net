// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.KeyVault.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    [NonParallelizable]
    public class ManagedHsmTests : VaultOperationsTestsBase
    {
        public ManagedHsmTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await Initialize().ConfigureAwait(false);
            }
        }

        // The MHSM is very expensive and only allow to have 5 MHSM instance per retion.
        // So before running live / record please make sure the test region have the capacity for create a new one.
        [PlaybackOnly("Live test for MHSM is not necessary")]
        [RecordedTest]
        public async Task ManagedHsmFull()
        {
            ManagedHsmData parameters = new ManagedHsmData(Location)
            {
                Sku = new ManagedHsmSku(ManagedHsmSkuFamily.B, ManagedHsmSkuName.StandardB1),
                Properties = ManagedHsmProperties
            };
            parameters.Tags.InitializeFrom(Tags);

            // Create a MHSM
            ArmOperation<ManagedHsmResource> managedHsm = await ManagedHsmCollection.CreateOrUpdateAsync(WaitUntil.Completed, MHSMName, parameters).ConfigureAwait(false);
            Assert.NotNull(managedHsm.Value);
            Assert.NotNull(managedHsm.Value.Id);
            ValidateVault(managedHsm.Value.Data,
                MHSMName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                ManagedHsmSkuFamily.B,
                ManagedHsmSkuName.StandardB1,
                false,
                true,
                new List<string> { ObjectId },
                ManagedHsmProperties.NetworkRuleSet,
                ManagedHsmPublicNetworkAccess.Disabled,
                DefSoftDeleteRetentionInDays,
                Tags);

            // List
            AsyncPageable<ManagedHsmResource> vaults = ManagedHsmCollection.GetAllAsync();
            int count = 0;
            await foreach (ManagedHsmResource v in vaults)
            {
                if (v.Id == managedHsm.Value.Id)
                {
                    count++;
                    break;
                }
            }
            Assert.True(count == 1);

            // Update
            ManagedHsmProperties.PublicNetworkAccess = ManagedHsmPublicNetworkAccess.Enabled;
            ManagedHsmProperties.NetworkRuleSet.DefaultAction = "Allow";
            parameters = new ManagedHsmData(Location)
            {
                Sku = new ManagedHsmSku(ManagedHsmSkuFamily.B, ManagedHsmSkuName.StandardB1),
                Properties = ManagedHsmProperties
            };
            parameters.Tags.InitializeFrom(Tags);

            ManagedHsmResource updateManagedHsm = null;
            if (Mode == RecordedTestMode.Record)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        updateManagedHsm = (await ManagedHsmCollection.CreateOrUpdateAsync(WaitUntil.Completed, MHSMName, parameters).ConfigureAwait(false)).Value;
                        break;
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(120000);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        updateManagedHsm = (await ManagedHsmCollection.CreateOrUpdateAsync(WaitUntil.Completed, MHSMName, parameters).ConfigureAwait(false)).Value;
                        break;
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            // Get
            Response<ManagedHsmResource> retrievedVault = await ManagedHsmCollection.GetAsync(MHSMName);
            ValidateVault(retrievedVault.Value.Data,
                MHSMName,
                ResGroupName,
                TestEnvironment.SubscriptionId,
                TenantIdGuid,
                Location,
                ManagedHsmSkuFamily.B,
                ManagedHsmSkuName.StandardB1,
                false,
                true,
                new List<string> { ObjectId },
                ManagedHsmProperties.NetworkRuleSet,
                ManagedHsmPublicNetworkAccess.Enabled,
                DefSoftDeleteRetentionInDays,
                Tags);

            // Delete
            await retrievedVault.Value.DeleteAsync(WaitUntil.Completed);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await ManagedHsmCollection.GetAsync(MHSMName);
            });

            // Try to purge
            try
            {
                Response<DeletedManagedHsmResource> deletedMhsm = await Subscription.GetDeletedManagedHsmAsync(Location, MHSMName);
                Assert.NotNull(deletedMhsm.Value);
                Assert.NotNull(deletedMhsm.Value.Data.Properties.DeletedOn);
                await deletedMhsm.Value.PurgeDeletedAsync(WaitUntil.Completed);
            }
            catch (Exception)
            {
            }
        }

        [Ignore("Recover is not working, add back when it's verified")]
        [PlaybackOnly("One location only support one MHSM")]
        [RecordedTest]
        public async Task ManagedHsmRecoverDeletedVault()
        {
            ManagedHsmData parameters = new ManagedHsmData(Location)
            {
                Sku = new ManagedHsmSku(ManagedHsmSkuFamily.B, ManagedHsmSkuName.StandardB1),
                Properties = ManagedHsmProperties
            };
            parameters.Tags.InitializeFrom(Tags);

            ArmOperation<ManagedHsmResource> managedHsm = await ManagedHsmCollection.CreateOrUpdateAsync(WaitUntil.Completed, MHSMName, parameters).ConfigureAwait(false);

            // Delete
            await managedHsm.Value.DeleteAsync(WaitUntil.Completed);

            // Get deleted vault
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await ManagedHsmCollection.GetAsync(MHSMName);
            });

            parameters.Properties.CreateMode = ManagedHsmCreateMode.Recover;

            // Recover in recover mode
            ArmOperation<ManagedHsmResource> recoveredVault2 = await ManagedHsmCollection.CreateOrUpdateAsync(WaitUntil.Completed, MHSMName, parameters).ConfigureAwait(false);

            Assert.True(recoveredVault2.Value.Data.IsEqual(managedHsm.Value.Data));

            // Get recovered vault
            Response<ManagedHsmResource> getResult = await ManagedHsmCollection.GetAsync(MHSMName);

            // Delete
            await getResult.Value.DeleteAsync(WaitUntil.Completed);
        }

        private void ValidateVault(
            ManagedHsmData managedHsmData,
            string expectedVaultName,
            string expectedResourceGroupName,
            string expectedSubId,
            Guid expectedTenantId,
            AzureLocation expectedLocation,
            ManagedHsmSkuFamily expectedSkuFamily,
            ManagedHsmSkuName expectedSkuName,
            bool expectedEnablePurgeProtection,
            bool expectedEnableSoftDelete,
            List<string> expectedInitialAdminObjectIds,
            ManagedHsmNetworkRuleSet expectedNetworkAcls,
            ManagedHsmPublicNetworkAccess expectedPublicNetworkAccess,
            int expectedSoftDeleteRetentionInDays,
            Dictionary<string, string> expectedTags)
        {
            Assert.NotNull(managedHsmData);
            Assert.NotNull(managedHsmData.Properties);

            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.KeyVault/managedHSMs/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedResourceGroupName, expectedVaultName);
            string expectedHsmUri = $"https://{expectedVaultName}.managedhsm.azure.net/";

            Assert.AreEqual(expectedResourceId, managedHsmData.Id.ToString());
            Assert.AreEqual(expectedLocation.ToString(), managedHsmData.Location.ToString());
            Assert.AreEqual(Mode == RecordedTestMode.Live ? expectedTenantId : Guid.Empty, managedHsmData.Properties.TenantId);
            Assert.AreEqual(expectedVaultName, managedHsmData.Name);
            Assert.AreEqual(expectedSkuFamily, managedHsmData.Sku.Family);
            Assert.AreEqual(expectedSkuName, managedHsmData.Sku.Name);
            Assert.AreEqual(expectedEnablePurgeProtection, managedHsmData.Properties.EnablePurgeProtection);
            Assert.AreEqual(expectedEnableSoftDelete, managedHsmData.Properties.EnableSoftDelete);
            Assert.AreEqual(expectedHsmUri, managedHsmData.Properties.HsmUri.ToString());
            Assert.AreEqual(expectedInitialAdminObjectIds, managedHsmData.Properties.InitialAdminObjectIds);
            Assert.AreEqual(expectedNetworkAcls.Bypass, managedHsmData.Properties.NetworkRuleSet.Bypass);
            Assert.AreEqual(expectedNetworkAcls.DefaultAction, managedHsmData.Properties.NetworkRuleSet.DefaultAction);
            Assert.AreEqual(expectedPublicNetworkAccess, managedHsmData.Properties.PublicNetworkAccess);
            Assert.AreEqual(expectedSoftDeleteRetentionInDays, managedHsmData.Properties.SoftDeleteRetentionInDays);
            Assert.True(expectedTags.DictionaryEqual(managedHsmData.Tags));
        }
    }
}
