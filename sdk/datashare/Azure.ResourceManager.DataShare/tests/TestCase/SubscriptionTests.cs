// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.DataShare.Models;
using Azure.ResourceManager.DataShare.Tests.Helper;
using NUnit.Framework;

namespace Azure.ResourceManager.DataShare.Tests.TestCase
{
    public class SubscriptionTests : DataShareManagementTestBase
    {
        public SubscriptionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        #region invitaton
        private async Task<DataShareInvitationResource> GetInvitationResourceIdAsync()
        {
            var collection = (await CreateResourceGroupAsync()).GetDataShareAccounts();
            var accoutnName = Recording.GenerateAssetName("TestAccount-");
            var accountInput = ResourceDataHelpers.GetAccount();
            var lroa = await collection.CreateOrUpdateAsync(WaitUntil.Completed, accoutnName, accountInput);
            DataShareAccountResource accountResource = lroa.Value;
            DataShareCollection datashareCollection = accountResource.GetDataShares();
            var shareName = Recording.GenerateAssetName("TestShare-");
            var shareInput = ResourceDataHelpers.GetShareData();
            var lros = await datashareCollection.CreateOrUpdateAsync(WaitUntil.Completed, shareName, shareInput);
            var shareresource = lros.Value;
            var invitationCollection = shareresource.GetDataShareInvitations();
            var invitationName = Recording.GenerateAssetName("TestInvitation-");
            var invitationInput = ResourceDataHelpers.GetInvitationData();
            var lroi = await invitationCollection.CreateOrUpdateAsync(WaitUntil.Completed, invitationName, invitationInput);
            var setresource = lroi.Value;
            return setresource;
        }
        #endregion

        private async Task<ShareSubscriptionCollection> GetSubscriptionCollectionAsync()
        {
            var collection = (await CreateResourceGroupAsync()).GetDataShareAccounts();
            var accoutnName = Recording.GenerateAssetName("TestAccount-");
            var accountInput = ResourceDataHelpers.GetAccount();
            var lroa = await collection.CreateOrUpdateAsync(WaitUntil.Completed, accoutnName, accountInput);
            DataShareAccountResource accountResource = lroa.Value;
            var subscriptionCollection = accountResource.GetShareSubscriptions();
            return subscriptionCollection;
        }

        /*private async Task<ShareSubscriptionResource> GetSubscriptionResourceAsync()
        {
            var collection = await GetSubscriptionCollectionAsync();
            var setName = Recording.GenerateAssetName("TestShareSubscription-");
            var setInput = ResourceDataHelpers.GetSubscriptionData();
            var lros = await collection.CreateOrUpdateAsync(WaitUntil.Completed, setName, setInput);
            var setresource = lros.Value;
            return setresource;
        }*/

        [TestCase]
        [RecordedTest]
        [Ignore("No invitation found for this tenant and objectId")]
        public async Task SubscriptionApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetSubscriptionCollectionAsync();
            var name = Recording.GenerateAssetName("TestInvitation-");
            var name2 = Recording.GenerateAssetName("TestInvitation-");
            var name3 = Recording.GenerateAssetName("TestInvitation-");
            var invitation = await GetInvitationResourceIdAsync();
            string invitationId = invitation.Data.InvitationId.ToString();
            var input = ResourceDataHelpers.GetSubscriptionData(new Guid(invitationId));
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            ShareSubscriptionResource subscription1 = lro.Value;
            Assert.AreEqual(name, subscription1.Data.Name);
            //2.Get
            ShareSubscriptionResource subscription2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertSubscriptionData(subscription1.Data, subscription2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //ResourceTests
            //5.Get
            ShareSubscriptionResource subscription3 = await subscription1.GetAsync();
            ResourceDataHelpers.AssertSubscriptionData(subscription1.Data, subscription3.Data);
            //6.Delete
            await subscription1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
