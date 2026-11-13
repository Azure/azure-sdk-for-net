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
    /// Tests for DependencyOf relationship resource operations.
    /// A DependencyOf relationship declares that one Service Group depends on another Service Group.
    /// </summary>
    public class DependencyOfRelationshipResourceTests : RelationshipsManagementTestBase
    {
        private DependencyOfRelationshipResource _relationship;
        private DependencyOfRelationshipCollection _collection;
        // _source is the ARM resource on whose scope the relationship is PUT (source of the dependency).
        private ArmResource _source;
        // _target is the ARM resource that the dependency points to.
        private ArmResource _target;
        // _cleanupRG holds a resource group that must be deleted when the source lives inside one
        // (e.g. a Key Vault source is cleaned up by deleting its containing resource group).
        private ResourceGroupResource _cleanupRG;

        public DependencyOfRelationshipResourceTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TearDown]
        public async Task CleanUp()
        {
            // Delete relationship before service groups — service groups cannot be deleted
            // while they have active relationships.
            if (_relationship != null)
            {
                await _relationship.DeleteAsync(WaitUntil.Completed);
                _relationship = null;
            }
            if (_source is ResourceGroupResource sourceRg)
                await sourceRg.DeleteAsync(WaitUntil.Completed);
            else if (_source is ServiceGroupResource sourceSg)
                await sourceSg.DeleteAsync(WaitUntil.Completed);
            _source = null;
            if (_target is ResourceGroupResource targetRg)
                await targetRg.DeleteAsync(WaitUntil.Completed);
            else if (_target is ServiceGroupResource targetSg)
                await targetSg.DeleteAsync(WaitUntil.Completed);
            _target = null;
            if (_cleanupRG != null)
            {
                await _cleanupRG.DeleteAsync(WaitUntil.Completed);
                _cleanupRG = null;
            }
        }

        private async Task<DependencyOfRelationshipResource> CreateRelationshipAsync(
            DependencyOfRelationshipCollection collection,
            string name,
            ResourceIdentifier sourceId,
            ResourceIdentifier targetId)
        {
            var data = new DependencyOfRelationshipData
            {
                Properties = ArmRelationshipsModelFactory.DependencyOfRelationshipProperties(sourceId, targetId)
            };
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            return lro.Value;
        }

        [RecordedTest]
        public async Task Get()
        {
            // DependencyOf does not allow a Service Group as source (InvalidSourceScope).
            // Use Key Vault → Key Vault, matching the documented example in the Relationships docs.
            _cleanupRG = await CreateResourceGroup(DefaultSubscription, "rg-dep-get-", AzureLocation.WestUS2);
            _source = await CreateKeyVault(_cleanupRG, "kv-src-");
            _target = await CreateKeyVault(_cleanupRG, "kv-tgt-");
            _collection = Client.GetDependencyOfRelationships(_source.Id);

            string relationshipName = Recording.GenerateAssetName("dep-rel-");
            _relationship = await CreateRelationshipAsync(_collection, relationshipName, _source.Id, _target.Id);

            var retrieved = await _relationship.GetAsync();

            Assert.IsNotNull(retrieved.Value);
            Assert.IsNotNull(retrieved.Value.Data);
            Assert.AreEqual(relationshipName, retrieved.Value.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, retrieved.Value.Data.ResourceType);
            Assert.AreEqual(_source.Id, retrieved.Value.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, retrieved.Value.Data.Properties.TargetId);
        }

        [RecordedTest]
        public async Task Delete()
        {
            _target = await CreateServiceGroup("sg-target-");
            _collection = Client.GetDependencyOfRelationships(DefaultSubscription.Id);

            string relationshipName = Recording.GenerateAssetName("dep-rel-");
            _relationship = await CreateRelationshipAsync(_collection, relationshipName, DefaultSubscription.Id, _target.Id);

            bool existsBefore = await _collection.ExistsAsync(relationshipName);
            Assert.IsTrue(existsBefore);

            await _relationship.DeleteAsync(WaitUntil.Completed);
            _relationship = null; // Set to null so TearDown does not attempt to delete again.

            bool existsAfter = await _collection.ExistsAsync(relationshipName);
            Assert.IsFalse(existsAfter);
        }

        /// <summary>
        /// Verifies Get on a DependencyOf relationship scoped to a subscription.
        /// </summary>
        [RecordedTest]
        public async Task Get_OnSubscription()
        {
            _target = await CreateServiceGroup("sg-sub-target-");
            _collection = Client.GetDependencyOfRelationships(DefaultSubscription.Id);

            string relationshipName = Recording.GenerateAssetName("dep-sub-");
            _relationship = await CreateRelationshipAsync(_collection, relationshipName, DefaultSubscription.Id, _target.Id);

            var retrieved = await _relationship.GetAsync();

            Assert.IsNotNull(retrieved.Value);
            Assert.AreEqual(relationshipName, retrieved.Value.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, retrieved.Value.Data.ResourceType);
            Assert.AreEqual(DefaultSubscription.Id, retrieved.Value.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, retrieved.Value.Data.Properties.TargetId);
        }

        /// <summary>
        /// Verifies Get on a DependencyOf relationship scoped to a Key Vault resource.
        /// The vault is cleaned up by deleting _cleanupRG in TearDown.
        /// </summary>
        [RecordedTest]
        public async Task Get_OnKeyVaultResource()
        {
            _target = await CreateServiceGroup("sg-kv-target-");
            _cleanupRG = await CreateResourceGroup(DefaultSubscription, "rg-kv-", AzureLocation.WestUS2);
            KeyVaultResource vault = await CreateKeyVault(_cleanupRG, "kv-src-");

            _collection = Client.GetDependencyOfRelationships(vault.Id);
            string relationshipName = Recording.GenerateAssetName("dep-kv-");
            _relationship = await CreateRelationshipAsync(_collection, relationshipName, vault.Id, _target.Id);

            var retrieved = await _relationship.GetAsync();

            Assert.IsNotNull(retrieved.Value);
            Assert.AreEqual(relationshipName, retrieved.Value.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, retrieved.Value.Data.ResourceType);
            Assert.AreEqual(vault.Id, retrieved.Value.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, retrieved.Value.Data.Properties.TargetId);
        }

        /// <summary>
        /// Verifies Get on a DependencyOf relationship where the target is a subscription
        /// rather than a Service Group. DependencyOf allows any target scope.
        /// Corresponds to valid target scope coverage in service-side test: ValidPutSent_SuccessfulResponse.
        /// </summary>
        [RecordedTest]
        public async Task Get_WithSubscriptionTarget()
        {
            _source = await CreateResourceGroup(DefaultSubscription, "rg-dep-src-", AzureLocation.WestUS2);
            _collection = Client.GetDependencyOfRelationships(_source.Id);

            string relationshipName = Recording.GenerateAssetName("dep-sub-tgt-");
            _relationship = await CreateRelationshipAsync(_collection, relationshipName, _source.Id, DefaultSubscription.Id);

            var retrieved = await _relationship.GetAsync();

            Assert.IsNotNull(retrieved.Value);
            Assert.AreEqual(relationshipName, retrieved.Value.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, retrieved.Value.Data.ResourceType);
            Assert.AreEqual(_source.Id, retrieved.Value.Data.Properties.SourceId);
            Assert.AreEqual(DefaultSubscription.Id, retrieved.Value.Data.Properties.TargetId);
        }

        /// <summary>
        /// Verifies Get on a DependencyOf relationship where the target is a resource group
        /// rather than a Service Group. DependencyOf allows any target scope.
        /// Corresponds to valid target scope coverage in service-side test: ValidPutSent_SuccessfulResponse.
        /// </summary>
        [RecordedTest]
        public async Task Get_WithResourceGroupTarget()
        {
            _source = await CreateResourceGroup(DefaultSubscription, "rg-dep-src-", AzureLocation.WestUS2);
            _target = await CreateResourceGroup(DefaultSubscription, "rg-dep-tgt-", AzureLocation.WestUS2);
            _collection = Client.GetDependencyOfRelationships(_source.Id);

            string relationshipName = Recording.GenerateAssetName("dep-rg-tgt-");
            _relationship = await CreateRelationshipAsync(_collection, relationshipName, _source.Id, _target.Id);

            var retrieved = await _relationship.GetAsync();

            Assert.IsNotNull(retrieved.Value);
            Assert.AreEqual(relationshipName, retrieved.Value.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, retrieved.Value.Data.ResourceType);
            Assert.AreEqual(_source.Id, retrieved.Value.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, retrieved.Value.Data.Properties.TargetId);
        }
    }
}
