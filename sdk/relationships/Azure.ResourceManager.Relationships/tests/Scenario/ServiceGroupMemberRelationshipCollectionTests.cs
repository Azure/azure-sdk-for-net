// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.Relationships.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceGroups;
using NUnit.Framework;

namespace Azure.ResourceManager.Relationships.Tests.Scenario
{
    /// <summary>
    /// Tests for ServiceGroupMember relationships.
    /// A ServiceGroupMember relationship makes an ARM resource (resource group, subscription, etc.)
    /// a member of a Service Group. The relationship is created ON the member resource,
    /// with targetId pointing to the Service Group.
    /// </summary>
    public class ServiceGroupMemberRelationshipCollectionTests : RelationshipsManagementTestBase
    {
        private ServiceGroupMemberRelationshipResource _relationship;
        // _source is the ARM resource that becomes a member of the Service Group (relationship scope).
        private ArmResource _source;
        // _target is the Service Group that the member resource joins.
        private ArmResource _target;
        // _cleanupRG holds a resource group that must be deleted when the source lives inside one
        // (e.g. a Key Vault member is cleaned up by deleting its containing resource group).
#pragma warning disable CS0169 // field used by commented-out KeyVault-scoped tests
        private ResourceGroupResource _cleanupRG;
#pragma warning restore CS0169

        public ServiceGroupMemberRelationshipCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TearDown]
        public async Task CleanUp()
        {
            // Delete relationship before member resource group and service group.
            if (_relationship != null)
            {
                await _relationship.DeleteAsync(WaitUntil.Completed);
                _relationship = null;
            }
            if (_source is ResourceGroupResource sourceRg)
                await sourceRg.DeleteAsync(WaitUntil.Completed);
            _source = null;
            if (_target is ServiceGroupResource targetSg)
                await targetSg.DeleteAsync(WaitUntil.Completed);
            _target = null;
            if (_cleanupRG != null)
            {
                await _cleanupRG.DeleteAsync(WaitUntil.Completed);
                _cleanupRG = null;
            }
        }

        private ServiceGroupMemberRelationshipData CreateServiceGroupMemberRelationshipData(ResourceIdentifier sourceId, ResourceIdentifier targetId)
        {
            return new ServiceGroupMemberRelationshipData
            {
                Properties = ArmRelationshipsModelFactory.ServiceGroupMemberRelationshipProperties(sourceId, targetId)
            };
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            // ServiceGroupMember: source resource group becomes a member of target service group.
            // The relationship is PUT on the source resource's scope, targeting the Service Group.
            _target = await CreateServiceGroup("sg-");
            _source = await CreateResourceGroup(DefaultSubscription, "rg-member-", AzureLocation.WestUS);

            var collection = Client.GetServiceGroupMemberRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("sgm-rel-");

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, CreateServiceGroupMemberRelationshipData(_source.Id, _target.Id));
            _relationship = lro.Value;

            Assert.IsNotNull(_relationship);
            Assert.IsNotNull(_relationship.Data);
            Assert.AreEqual(relationshipName, _relationship.Data.Name);
            Assert.AreEqual(ServiceGroupMemberRelationshipResource.ResourceType, _relationship.Data.ResourceType);
            Assert.AreEqual(_source.Id, _relationship.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, _relationship.Data.Properties.TargetId);
        }

        [RecordedTest]
        public async Task Get()
        {
            _target = await CreateServiceGroup("sg-");
            _source = await CreateResourceGroup(DefaultSubscription, "rg-member-", AzureLocation.WestUS);

            var collection = Client.GetServiceGroupMemberRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("sgm-rel-");

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, CreateServiceGroupMemberRelationshipData(_source.Id, _target.Id));
            _relationship = lro.Value;

            var relationship = await collection.GetAsync(relationshipName);

            Assert.IsNotNull(relationship);
            Assert.IsNotNull(relationship.Value.Data);
            Assert.AreEqual(relationshipName, relationship.Value.Data.Name);
            Assert.AreEqual(ServiceGroupMemberRelationshipResource.ResourceType, relationship.Value.Data.ResourceType);
            Assert.AreEqual(_source.Id, relationship.Value.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, relationship.Value.Data.Properties.TargetId);
        }

        [RecordedTest]
        public async Task Exists()
        {
            _target = await CreateServiceGroup("sg-");
            _source = await CreateResourceGroup(DefaultSubscription, "rg-member-", AzureLocation.WestUS);

            var collection = Client.GetServiceGroupMemberRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("sgm-rel-");

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, CreateServiceGroupMemberRelationshipData(_source.Id, _target.Id));
            _relationship = lro.Value;

            bool exists = await collection.ExistsAsync(relationshipName);
            Assert.IsTrue(exists);

            bool notExists = await collection.ExistsAsync("nonexistent-relationship");
            Assert.IsFalse(notExists);
        }

        /// <summary>
        /// Verifies that a ServiceGroupMember relationship can be created scoped to a subscription,
        /// making the subscription itself a member of a Service Group.
        /// </summary>
        [RecordedTest]
        public async Task CreateOrUpdate_OnSubscription()
        {
            _target = await CreateServiceGroup("sg-sub-");

            // The relationship is PUT on the subscription's scope.
            var collection = Client.GetServiceGroupMemberRelationships(DefaultSubscription.Id);
            string relationshipName = Recording.GenerateAssetName("sgm-sub-");

            var lro = await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                relationshipName,
                CreateServiceGroupMemberRelationshipData(DefaultSubscription.Id, _target.Id));
            _relationship = lro.Value;

            Assert.IsNotNull(_relationship);
            Assert.AreEqual(relationshipName, _relationship.Data.Name);
            Assert.AreEqual(ServiceGroupMemberRelationshipResource.ResourceType, _relationship.Data.ResourceType);
            Assert.AreEqual(DefaultSubscription.Id, _relationship.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, _relationship.Data.Properties.TargetId);
        }

        /// <summary>
        /// Verifies that a ServiceGroupMember relationship can be created scoped to a specific ARM resource
        /// (a Key Vault in this case), making that vault a member of a Service Group.
        /// The vault is cleaned up by deleting its containing resource group in TearDown.
        /// </summary>
        [RecordedTest]
        public async Task CreateOrUpdate_OnKeyVaultResource()
        {
            _target = await CreateServiceGroup("sg-kv-");
            _cleanupRG = await CreateResourceGroup(DefaultSubscription, "rg-kv-", AzureLocation.WestUS);
            KeyVaultResource vault = await CreateKeyVault(_cleanupRG, "kv-member-");

            // The relationship is PUT on the vault resource's scope.
            var collection = Client.GetServiceGroupMemberRelationships(vault.Id);
            string relationshipName = Recording.GenerateAssetName("sgm-kv-");

            var lro = await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                relationshipName,
                CreateServiceGroupMemberRelationshipData(vault.Id, _target.Id));
            _relationship = lro.Value;

            Assert.IsNotNull(_relationship);
            Assert.AreEqual(relationshipName, _relationship.Data.Name);
            Assert.AreEqual(ServiceGroupMemberRelationshipResource.ResourceType, _relationship.Data.ResourceType);
            Assert.AreEqual(vault.Id, _relationship.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, _relationship.Data.Properties.TargetId);
        }

        /// <summary>
        /// The service rejects a ServiceGroupMember relationship whose targetId does not point to a
        /// Service Group resource (InvalidTargetScope).
        /// Corresponds to service-side test: Put_TargetIsNotAServiceGroup_BadRequestAsync.
        /// </summary>
        [RecordedTest]
        public async Task CreateOrUpdate_WithNonServiceGroupTarget_ThrowsRequestFailedException()
        {
            _source = await CreateResourceGroup(DefaultSubscription, "rg-member-", AzureLocation.WestUS);

            var collection = Client.GetServiceGroupMemberRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("sgm-bad-target-");

            // Pass a resource group ID as targetId — only Service Group IDs are valid targets.
            var data = new ServiceGroupMemberRelationshipData
            {
                Properties = ArmRelationshipsModelFactory.ServiceGroupMemberRelationshipProperties(_source.Id, _source.Id)
            };

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, data));
            Assert.AreEqual(400, ex.Status);
        }

        /// <summary>
        /// The service rejects a ServiceGroupMember relationship whose targetId points to a
        /// Service Group that does not exist (ServiceGroupNotExist).
        /// Corresponds to service-side test: Put_ServiceGroupNotExist_BadRequestAsync.
        /// </summary>
        [RecordedTest]
        public async Task CreateOrUpdate_WithNonExistentServiceGroup_ThrowsRequestFailedException()
        {
            _source = await CreateResourceGroup(DefaultSubscription, "rg-member-", AzureLocation.WestUS);

            // Construct a well-formed Service Group resource ID that does not actually exist.
            var nonExistentSgId = new ResourceIdentifier("/providers/Microsoft.Management/serviceGroups/nonexistent-sg-sdk-test");

            var collection = Client.GetServiceGroupMemberRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("sgm-no-sg-");

            var data = new ServiceGroupMemberRelationshipData
            {
                Properties = ArmRelationshipsModelFactory.ServiceGroupMemberRelationshipProperties(_source.Id, nonExistentSgId)
            };

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, data));
            Assert.AreEqual(403, ex.Status);
        }
    }
}
