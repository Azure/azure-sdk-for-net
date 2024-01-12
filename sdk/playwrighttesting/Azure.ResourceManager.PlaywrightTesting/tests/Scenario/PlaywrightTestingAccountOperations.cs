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
        private AccountCollection _accountCollection { get; set; }
        private AccountResource _accountResource { get; set; }
        private AccountData _accountData { get; set; }

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
            _accountCollection = (await CreateResourceGroup(subscription, ResourceHelper.RESOURCE_GROUP_NAME, ResourceHelper.RESOURCE_LOCATION)).GetAccounts();

            _accountData = new AccountData(ResourceHelper.RESOURCE_LOCATION);
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
            ArmOperation<AccountResource> createResponse = await _accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, ResourceHelper.WORKSPACE_NAME, _accountData);

            Assert.NotNull(createResponse);
            Assert.IsTrue(createResponse.HasCompleted);
            Assert.IsTrue(createResponse.HasValue);
            Assert.IsTrue(createResponse.Value.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, createResponse.Value.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, createResponse.Value.Data.Location.Name);
            Assert.AreEqual(ProvisioningState.Succeeded, createResponse.Value.Data.ProvisioningState);

            //GET API
            Response<AccountResource> getResponse = await _accountCollection.GetAsync(ResourceHelper.WORKSPACE_NAME);
            AccountResource accountResource = getResponse.Value;

            Assert.IsNotNull(accountResource);
            Assert.IsTrue(accountResource.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, accountResource.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, accountResource.Data.Location.Name);
            Assert.AreEqual(ProvisioningState.Succeeded, accountResource.Data.ProvisioningState);

            //GETALL API
            List<AccountResource> getAllResponse = await _accountCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(getAllResponse);
            Assert.IsNotNull(getAllResponse);
            foreach (AccountResource resource in getAllResponse)
            {
                Assert.IsNotNull(resource);
                Assert.IsTrue(resource.HasData);
                Assert.IsNotNull(resource.Data.Id);
                Assert.IsNotNull(resource.Data.Name);
                Assert.AreEqual(ProvisioningState.Succeeded, resource.Data.ProvisioningState);
            }

            //GET RESOURCE GROUP API
            Response<AccountResource> getRGResponse = await createResponse.Value.GetAsync();
            accountResource = getRGResponse.Value;

            Assert.IsNotNull(accountResource);
            Assert.IsTrue(accountResource.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, accountResource.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, accountResource.Data.Location.Name);
            Assert.AreEqual(ProvisioningState.Succeeded, accountResource.Data.ProvisioningState);

            //UPDATE API
            AccountPatch resourcePatchPayload = new AccountPatch
            {
                RegionalAffinity= EnablementStatus.Enabled,
            };

            Response<AccountResource> updateResponse = await accountResource.UpdateAsync(resourcePatchPayload);
            AccountResource updateResponseValue = updateResponse.Value;
            Assert.IsNotNull(updateResponseValue);
            Assert.IsTrue(updateResponseValue.HasData);
            Assert.AreEqual(ResourceHelper.WORKSPACE_NAME, updateResponseValue.Data.Name);
            Assert.AreEqual(ResourceHelper.RESOURCE_LOCATION, updateResponseValue.Data.Location.Name);
            Assert.AreEqual(ProvisioningState.Succeeded, updateResponseValue.Data.ProvisioningState);
            Assert.IsTrue(updateResponseValue.Data.RegionalAffinity == EnablementStatus.Enabled);

            //DELETE API
            ArmOperation deleteResponse = await updateResponseValue.DeleteAsync(WaitUntil.Completed);
            await deleteResponse.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
