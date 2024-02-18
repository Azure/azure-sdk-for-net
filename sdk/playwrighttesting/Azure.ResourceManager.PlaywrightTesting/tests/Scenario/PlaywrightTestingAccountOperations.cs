// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PlaywrightTesting.Models;
using Azure.ResourceManager.PlaywrightTesting.Tests.Helper;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PlaywrightTesting.Tests.Scenario
{
    public class PlaywrightTestingAccountOperations : PlaywrightTestingManagementTestBase
    {
        private PlaywrightTestingAccountCollection _accountCollection { get; set; }
        private PlaywrightTestingAccountResource _accountResource { get; set; }
        private PlaywrightTestingAccountData _accountData { get; set; }

        public PlaywrightTestingAccountOperations(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }

            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            _accountCollection = (await CreateResourceGroup(subscription, ResourceHelper.RESOURCE_GROUP_NAME, ResourceHelper.RESOURCE_LOCATION)).GetPlaywrightTestingAccounts();

            _accountData = new PlaywrightTestingAccountData(ResourceHelper.RESOURCE_LOCATION);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task AccountOperationTests()
        {
            //Create API
            ArmOperation<PlaywrightTestingAccountResource> createResponse = await _accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, ResourceHelper.WORKSPACE_NAME, _accountData);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, createResponse.Value.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, createResponse.Value.Data.Location.Name);
            Assert.AreEqual(PlaywrightTestingProvisioningState.Succeeded, createResponse.Value.Data.ProvisioningState);

            //GET API
            Response<PlaywrightTestingAccountResource> getResponse = await _accountCollection.GetAsync(ResourceHelper.WORKSPACE_NAME);
            PlaywrightTestingAccountResource accountResource = getResponse.Value;

            Assert.IsNotNull(accountResource);
            Assert.IsTrue(accountResource.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, accountResource.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, accountResource.Data.Location.Name);
            Assert.AreEqual(PlaywrightTestingProvisioningState.Succeeded, accountResource.Data.ProvisioningState);

            //GETALL API
            List<PlaywrightTestingAccountResource> getAllResponse = await _accountCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(getAllResponse);
            Assert.IsNotNull(getAllResponse);
            foreach (PlaywrightTestingAccountResource resource in getAllResponse)
            {
                Assert.IsNotNull(resource);
                Assert.IsTrue(resource.HasData);
                Assert.IsNotNull(resource.Data.Id);
                Assert.IsNotNull(resource.Data.Name);
                Assert.AreEqual(PlaywrightTestingProvisioningState.Succeeded, resource.Data.ProvisioningState);
            }

            //GET RESOURCE GROUP API
            Response<PlaywrightTestingAccountResource> getRGResponse = await createResponse.Value.GetAsync();
            accountResource = getRGResponse.Value;

            Assert.IsNotNull(accountResource);
            Assert.IsTrue(accountResource.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, accountResource.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, accountResource.Data.Location.Name);
            Assert.AreEqual(PlaywrightTestingProvisioningState.Succeeded, accountResource.Data.ProvisioningState);

            //UPDATE API
            PlaywrightTestingAccountPatch resourcePatchPayload = new PlaywrightTestingAccountPatch
            {
                RegionalAffinity= EnablementStatus.Enabled,
            };

            Response<PlaywrightTestingAccountResource> updateResponse = await accountResource.UpdateAsync(resourcePatchPayload);
            PlaywrightTestingAccountResource updateResponseValue = updateResponse.Value;
            Assert.IsNotNull(updateResponseValue);
            Assert.IsTrue(updateResponseValue.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, updateResponseValue.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, updateResponseValue.Data.Location.Name);
            Assert.AreEqual(PlaywrightTestingProvisioningState.Succeeded, updateResponseValue.Data.ProvisioningState);
            Assert.IsTrue(updateResponseValue.Data.RegionalAffinity == EnablementStatus.Enabled);

            //DELETE API
            ArmOperation deleteResponse = await updateResponseValue.DeleteAsync(WaitUntil.Completed);
            await deleteResponse.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
