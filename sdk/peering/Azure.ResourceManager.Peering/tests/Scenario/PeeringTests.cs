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
    internal class PeeringTests : PeeringManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private PeeringCollection _peeringCollection => _resourceGroup.GetPeerings();

        public PeeringTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
        }

        [RecordedTest]
        [Ignore("ASN validation can take up to 3 business days after submitting PeerASN request.")]
        public async Task CreateOrUpdate()
        {
            // Create a PeerAsn. status of PeerASN: Pending
            string peerAsnName = Recording.GenerateAssetName("asn");
            var peerAsn = await CreatePeerAsn(peerAsnName);

            // Create. 400 PeerAsn is not approved for the subscription. Waiting PeerASN approved
            string peeringName = Recording.GenerateAssetName("peering");
            var peeringSku = new PeeringSku()
            {
                Name = "Basic_Direct_Free"
            };
            var data = new PeeringData(_resourceGroup.Data.Location, peeringSku, PeeringKind.Direct);
            data.PeeringLocation = "Seattle";
            data.Direct = new DirectPeeringProperties();
            data.Direct.Connections.Add(new PeeringDirectConnection()
            {
                BandwidthInMbps = 10000,
                SessionAddressProvider = PeeringSessionAddressProvider.Peer,
                UseForPeeringService = false,
                PeeringDBFacilityId = 99999,
                ConnectionIdentifier = Guid.NewGuid().ToString(),
                BgpSession = new PeeringBgpSession()
                {
                    SessionPrefixV4 = "94.54.173.0/30",
                    MaxPrefixesAdvertisedV4 = 20000
                }
            });
            data.Direct.PeerAsnId = peerAsn.Data.Id;
            data.Direct.DirectPeeringType = DirectPeeringType.Edge;
            var peering = await _peeringCollection.CreateOrUpdateAsync(WaitUntil.Completed, peeringName, data);
            Assert.IsNotNull(peering);
            Assert.AreEqual(peeringName, peering.Value.Data.Name);

            // Exist
            bool flag = await _peeringCollection.ExistsAsync(peeringName);
            Assert.IsTrue(flag);

            // Get
            var getResponse = await _peeringCollection.GetAsync(peeringName);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(peeringName, getResponse.Value.Data.Name);

            // GetAll
            var list = await _peeringCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsNotNull(list.First(item => item.Data.Name == peeringName));

            // Delete
            await peering.Value.DeleteAsync(WaitUntil.Completed);
            flag = await _peeringCollection.ExistsAsync(peeringName);
            Assert.IsFalse(flag);
        }
    }
}
