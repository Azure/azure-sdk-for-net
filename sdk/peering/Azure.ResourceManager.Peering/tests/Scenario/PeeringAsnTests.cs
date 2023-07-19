// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Peering.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Peering.Tests
{
    internal class PeeringAsnTests : PeeringManagementTestBase
    {
        private SubscriptionResource _subscription;
        private Random _random => new Random();
        private PeerAsnCollection _peerAsnCollection => _subscription.GetPeerAsns();

        public PeeringAsnTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string peerAsnName = Recording.GenerateAssetName("peerAsn");
            var peerAsn = await CreatePeerAsn(peerAsnName);
            ValidatePeeringService(peerAsn, peerAsnName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string peerAsnName = Recording.GenerateAssetName("peerAsn");
            await CreatePeerAsn(peerAsnName);
            bool flag = await _peerAsnCollection.ExistsAsync(peerAsnName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string peerAsnName = Recording.GenerateAssetName("peerAsn");
            await CreatePeerAsn(peerAsnName);
            var peerAsn = await _peerAsnCollection.GetAsync(peerAsnName);
            ValidatePeeringService(peerAsn, peerAsnName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string peerAsnName = Recording.GenerateAssetName("peerAsn");
            await CreatePeerAsn(peerAsnName);
            var list = await _peerAsnCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePeeringService(list.First(item => item.Data.Name == peerAsnName), peerAsnName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string peerAsnName = Recording.GenerateAssetName("peerAsn");
            var peerAsn = await CreatePeerAsn(peerAsnName);
            bool flag = await _peerAsnCollection.ExistsAsync(peerAsnName);
            Assert.IsTrue(flag);

            await peerAsn.DeleteAsync(WaitUntil.Completed);
            flag = await _peerAsnCollection.ExistsAsync(peerAsnName);
            Assert.IsFalse(flag);
        }

        private void ValidatePeeringService(PeerAsnResource peerAsn, string peerAsnName)
        {
            Assert.IsNotNull(peerAsn);
            Assert.AreEqual(peerAsnName, peerAsn.Data.Name);
            Assert.AreEqual(peerAsnName, peerAsn.Data.PeerName);
            Assert.IsTrue(peerAsn.Data.PeerAsn >= 1);
            Assert.AreEqual("Microsoft.Peering/peerAsns", peerAsn.Data.ResourceType.ToString());
            Assert.AreEqual("Pending", peerAsn.Data.ValidationState.ToString());
            Assert.AreEqual("noc65003@contoso.com", peerAsn.Data.PeerContactDetail.FirstOrDefault().Email);
            Assert.AreEqual("8888988888", peerAsn.Data.PeerContactDetail.FirstOrDefault().Phone);
            Assert.AreEqual("Noc", peerAsn.Data.PeerContactDetail.FirstOrDefault().Role.ToString());
        }
    }
}
