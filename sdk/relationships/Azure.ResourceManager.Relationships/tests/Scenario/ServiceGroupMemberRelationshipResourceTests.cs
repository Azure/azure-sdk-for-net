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
    /// Tests for ServiceGroupMember relationship resource operations.
    /// A ServiceGroupMember relationship makes an ARM resource a member of a Service Group.
    /// The relationship is created ON the member resource, with targetId pointing to the Service Group.
    /// </summary>
    public class ServiceGroupMemberRelationshipResourceTests : RelationshipsManagementTestBase
    {
        private ServiceGroupMemberRelationshipResource _relationship;
        private ServiceGroupMemberRelationshipCollection _collection;
        // _source is the ARM resource that becomes a member of the Service Group (relationship scope).
        private ArmResource _source;
        // _target is the Service Group that the member resource joins.
        private ArmResource _target;
        // _cleanupRG holds a resource group that must be deleted when the source lives inside one
        // (e.g. a Key Vault member is cleaned up by deleting its containing resource group).
        private ResourceGroupResource _cleanupRG;

        public ServiceGroupMemberRelationshipResourceTests(bool isAsync)
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

        private async Task<ServiceGroupMemberRelationshipResource> CreateRelationshipAsync(
            ServiceGroupMemberRelationshipCollection collection,
            string name,
            ResourceIdentifier sourceId,
            ResourceIdentifier targetId)
        {
            var data = new ServiceGroupMemberRelationshipData
            {
                Properties = ArmRelationshipsModelFactory.ServiceGroupMemberRelationshipProperties(sourceId, targetId, null, null, null, null)
            };
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            return lro.Value;
        }

        [RecordedTest]
        public async Task Get()
        {
            // source resource group becomes a member of target service group.
            // The relationship lives on the source resource's scope.
            _target = await CreateServiceGroup("sg-");
            _source = await CreateResourceGroup(DefaultSubscription, "rg-member-", AzureLocation.WestUS);

            _collection = Client.GetServiceGroupMemberRelationships(_source.Id);

            string relationshipName = Recording.GenerateAssetName("sgm-rel-");
            _relationship = await CreateRelationshipAsync(_collection, relationshipName, _source.Id, _target.Id);

            var retrieved = await _relationship.GetAsync();

            Assert.IsNotNull(retrieved.Value);
            Assert.IsNotNull(retrieved.Value.Data);
            Assert.AreEqual(relationshipName, retrieved.Value.Data.Name);
            Assert.AreEqual(ServiceGroupMemberRelationshipResource.ResourceType, retrieved.Value.Data.ResourceType);
            Assert.AreEqual(_source.Id, retrieved.Value.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, retrieved.Value.Data.Properties.TargetId);
        }

        [RecordedTest]
        public async Task Delete()
        {
            _target = await CreateServiceGroup("sg-");
            _source = await CreateResourceGroup(DefaultSubscription, "rg-member-", AzureLocation.WestUS);
            _collection = Client.GetServiceGroupMemberRelationships(_source.Id);

            string relationshipName = Recording.GenerateAssetName("sgm-rel-");
            _relationship = await CreateRelationshipAsync(_collection, relationshipName, _source.Id, _target.Id);

            bool existsBefore = await _collection.ExistsAsync(relationshipName);
            Assert.IsTrue(existsBefore);

            await _relationship.DeleteAsync(WaitUntil.Completed);
            _relationship = null; // Set to null so TearDown does not attempt to delete again.

            bool existsAfter = await _collection.ExistsAsync(relationshipName);
            Assert.IsFalse(existsAfter);
        }

        /// <summary>
        /// Verifies Get on a ServiceGroupMember relationship scoped to a subscription,
        /// where the subscription itself is the member.
        /// </summary>
        [RecordedTest]
        public async Task Get_OnSubscription()
        {
            _target = await CreateServiceGroup("sg-sub-");
            _collection = Client.GetServiceGroupMemberRelationships(DefaultSubscription.Id);

            string relationshipName = Recording.GenerateAssetName("sgm-sub-");
            _relationship = await CreateRelationshipAsync(_collection, relationshipName, DefaultSubscription.Id, _target.Id);

            var retrieved = await _relationship.GetAsync();

            Assert.IsNotNull(retrieved.Value);
            Assert.AreEqual(relationshipName, retrieved.Value.Data.Name);
            Assert.AreEqual(ServiceGroupMemberRelationshipResource.ResourceType, retrieved.Value.Data.ResourceType);
            Assert.AreEqual(DefaultSubscription.Id, retrieved.Value.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, retrieved.Value.Data.Properties.TargetId);
        }

        /// <summary>
        /// Verifies Get on a ServiceGroupMember relationship scoped to a Key Vault resource,
        /// where the vault is the member. The vault is cleaned up via _cleanupRG in TearDown.
        /// </summary>
        [RecordedTest]
        public async Task Get_OnKeyVaultResource()
        {
            _target = await CreateServiceGroup("sg-kv-");
            _cleanupRG = await CreateResourceGroup(DefaultSubscription, "rg-kv-", AzureLocation.WestUS);
            var vault = await CreateKeyVault(_cleanupRG, "kv-member-");

            _collection = Client.GetServiceGroupMemberRelationships(vault.Id);
            string relationshipName = Recording.GenerateAssetName("sgm-kv-");
            _relationship = await CreateRelationshipAsync(_collection, relationshipName, vault.Id, _target.Id);

            var retrieved = await _relationship.GetAsync();

            Assert.IsNotNull(retrieved.Value);
            Assert.AreEqual(relationshipName, retrieved.Value.Data.Name);
            Assert.AreEqual(ServiceGroupMemberRelationshipResource.ResourceType, retrieved.Value.Data.ResourceType);
            Assert.AreEqual(vault.Id, retrieved.Value.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, retrieved.Value.Data.Properties.TargetId);
        }
    }
}
