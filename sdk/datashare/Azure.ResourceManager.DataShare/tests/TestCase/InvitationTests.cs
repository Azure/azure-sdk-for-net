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
    public class InvitationTests : DataShareManagementTestBase
    {
        public InvitationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DataShareInvitationCollection> GetInvitationCollectionAsync()
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
            return invitationCollection;
        }

        private async Task<DataShareInvitationResource> GetInvitationResourceAsync()
        {
            var collection = await GetInvitationCollectionAsync();
            var invitationName = Recording.GenerateAssetName("TestInvitation-");
            var invitationInput = ResourceDataHelpers.GetInvitationData();
            var lros = await collection.CreateOrUpdateAsync(WaitUntil.Completed, invitationName, invitationInput);
            var setresource = lros.Value;
            return setresource;
        }

        [TestCase]
        [RecordedTest]
        public async Task InvitationApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetInvitationCollectionAsync();
            var name = Recording.GenerateAssetName("TestInvitation-");
            var name2 = Recording.GenerateAssetName("TestInvitation-");
            var name3 = Recording.GenerateAssetName("TestInvitation-");
            var input = ResourceDataHelpers.GetInvitationData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataShareInvitationResource invitation1 = lro.Value;
            Assert.AreEqual(name, invitation1.Data.Name);
            //2.Get
            DataShareInvitationResource invitation2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertInvitationData(invitation1.Data, invitation2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            //_ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            //_ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //ResourceTests
            //5.Get
            DataShareInvitationResource invitation3 = await invitation1.GetAsync();
            ResourceDataHelpers.AssertInvitationData(invitation1.Data, invitation3.Data);
            //6.Delete
            await invitation1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
