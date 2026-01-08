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
            Assert.That(flag, Is.True);
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
            Assert.That(list, Is.Not.Empty);
            ValidatePeeringService(list.First(item => item.Data.Name == peerAsnName), peerAsnName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string peerAsnName = Recording.GenerateAssetName("peerAsn");
            var peerAsn = await CreatePeerAsn(peerAsnName);
            bool flag = await _peerAsnCollection.ExistsAsync(peerAsnName);
            Assert.That(flag, Is.True);

            await peerAsn.DeleteAsync(WaitUntil.Completed);
            flag = await _peerAsnCollection.ExistsAsync(peerAsnName);
            Assert.That(flag, Is.False);
        }

        private void ValidatePeeringService(PeerAsnResource peerAsn, string peerAsnName)
        {
            Assert.That(peerAsn, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(peerAsn.Data.Name, Is.EqualTo(peerAsnName));
                Assert.That(peerAsn.Data.PeerName, Is.EqualTo(peerAsnName));
                Assert.That(peerAsn.Data.PeerAsn, Is.GreaterThanOrEqualTo(1));
                Assert.That(peerAsn.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Peering/peerAsns"));
                Assert.That(peerAsn.Data.ValidationState.ToString(), Is.EqualTo("Pending"));
                Assert.That(peerAsn.Data.PeerContactDetail.FirstOrDefault().Email, Is.EqualTo("noc65003@contoso.com"));
                Assert.That(peerAsn.Data.PeerContactDetail.FirstOrDefault().Phone, Is.EqualTo("8888988888"));
                Assert.That(peerAsn.Data.PeerContactDetail.FirstOrDefault().Role.ToString(), Is.EqualTo("Noc"));
            });
        }
    }
}
