// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class PartnerNamespaceTests : EventGridManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private PartnerNamespaceCollection _partnerNamespaceCollection;

        public PartnerNamespaceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            _partnerNamespaceCollection = _resourceGroup.GetPartnerNamespaces();
        }

        private async Task<PartnerNamespaceResource> CreatePartnerNamespace(string namespaceName)
        {
            var registration = await CreatePartnerRegistration(_resourceGroup, Recording.GenerateAssetName("PartnerRegistration"));
            var data = new PartnerNamespaceData(_resourceGroup.Data.Location)
            {
                PartnerRegistrationFullyQualifiedId = registration.Data.Id,
                IsLocalAuthDisabled = true,
                PublicNetworkAccess = EventGridPublicNetworkAccess.Enabled,
                PartnerTopicRoutingMode = PartnerTopicRoutingMode.ChannelNameHeader,
            };
            var partnerNamespace = await _partnerNamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, data);
            return partnerNamespace.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            var partnerNamespace = await CreatePartnerNamespace(partnerNamespaceName);
            ValidatePartnerNamespace(partnerNamespace, partnerNamespaceName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            await CreatePartnerNamespace(partnerNamespaceName);
            bool flag = await _partnerNamespaceCollection.ExistsAsync(partnerNamespaceName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            await CreatePartnerNamespace(partnerNamespaceName);
            var partnerNamespace = await _partnerNamespaceCollection.GetAsync(partnerNamespaceName);
            ValidatePartnerNamespace(partnerNamespace, partnerNamespaceName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            await CreatePartnerNamespace(partnerNamespaceName);
            var list = await _partnerNamespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePartnerNamespace(list.First(item => item.Data.Name == partnerNamespaceName), partnerNamespaceName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            var partnerNamespace = await CreatePartnerNamespace(partnerNamespaceName);
            bool flag = await _partnerNamespaceCollection.ExistsAsync(partnerNamespaceName);
            Assert.IsTrue(flag);

            await partnerNamespace.DeleteAsync(WaitUntil.Completed);
            flag = await _partnerNamespaceCollection.ExistsAsync(partnerNamespaceName);
            Assert.IsFalse(flag);
        }

        private void ValidatePartnerNamespace(PartnerNamespaceResource partnerNamespace, string partnerNamespaceName)
        {
            Assert.IsNotNull(partnerNamespace);
            Assert.IsNotNull(partnerNamespace.Data.Id);
            Assert.AreEqual(partnerNamespaceName, partnerNamespace.Data.Name);
            Assert.IsTrue(partnerNamespace.Data.IsLocalAuthDisabled);
            Assert.AreEqual(_resourceGroup.Data.Location, partnerNamespace.Data.Location);
            Assert.AreEqual(PartnerTopicRoutingMode.ChannelNameHeader,partnerNamespace.Data.PartnerTopicRoutingMode);
            Assert.AreEqual(EventGridPublicNetworkAccess.Enabled, partnerNamespace.Data.PublicNetworkAccess);
            Assert.AreEqual("Succeeded", partnerNamespace.Data.ProvisioningState.ToString());
            Assert.AreEqual("Microsoft.EventGrid/partnerNamespaces", partnerNamespace.Data.ResourceType.ToString());
        }
    }
}
