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
    /// Tests for DependencyOf relationships.
    /// A DependencyOf relationship declares that one Service Group depends on another Service Group.
    /// The relationship is created on the source Service Group, pointing to the target Service Group.
    /// </summary>
    public class DependencyOfRelationshipCollectionTests : RelationshipsManagementTestBase
    {
        private DependencyOfRelationshipResource _relationship;
        // _source is the ARM resource on whose scope the relationship is PUT (source of the dependency).
        private ArmResource _source;
        // _target is the ARM resource that the dependency points to.
        private ArmResource _target;
        // _cleanupRG holds a resource group that must be deleted when the source/target lives inside one
        // (e.g. a Key Vault source is cleaned up by deleting its containing resource group).
        private ResourceGroupResource _cleanupRG;

        public DependencyOfRelationshipCollectionTests(bool isAsync) : base(isAsync)
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

            // Workaround to cast while deleting because source and target are typed as ArmResource, but DeleteAsync is not defined on ArmResource.
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

        private DependencyOfRelationshipData CreateDependencyOfRelationshipData(ResourceIdentifier sourceId, ResourceIdentifier targetId)
        {
            return new DependencyOfRelationshipData
            {
                Properties = ArmRelationshipsModelFactory.DependencyOfRelationshipProperties(sourceId, targetId)
            };
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
        public async Task GetRelationship()
        {
            // Use Key Vault → Key Vault, matching the documented example in the Relationships dogfood docs.
            // Source and target are both regular ARM resources inside a shared resource group.
            _cleanupRG = await CreateResourceGroup(DefaultSubscription, "rg-dep-get-", AzureLocation.WestUS2);
            _source = await CreateKeyVault(_cleanupRG, "kv-src-");
            _target = await CreateKeyVault(_cleanupRG, "kv-tgt-");

            var collection = Client.GetDependencyOfRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("dep-rel-");

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, CreateDependencyOfRelationshipData(_source.Id, _target.Id));
            _relationship = lro.Value;

            var relationship = await collection.GetAsync(relationshipName);

            Assert.IsNotNull(relationship);
            Assert.IsNotNull(relationship.Value.Data);
            Assert.AreEqual(relationshipName, relationship.Value.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, relationship.Value.Data.ResourceType);
        }

        [RecordedTest]
        public async Task RelationshipExists()
        {
            _source = await CreateResourceGroup(DefaultSubscription, "rg-source-", AzureLocation.WestUS2);
            _target = await CreateServiceGroup("sg-target-");

            var collection = Client.GetDependencyOfRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("dep-rel-");

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, CreateDependencyOfRelationshipData(_source.Id, _target.Id));
            _relationship = lro.Value;

            bool exists = await collection.ExistsAsync(relationshipName);
            Assert.IsTrue(exists);

            bool notExists = await collection.ExistsAsync("nonexistent-relationship");
            Assert.IsFalse(notExists);
        }

        /// <summary>
        /// Verifies that a DependencyOf relationship can be created scoped to a subscription.
        /// The subscription itself is the source; targetId points to a Service Group.
        /// </summary>
        [RecordedTest]
        public async Task CreateOrUpdate_OnSubscription()
        {
            _target = await CreateServiceGroup("sg-sub-target-");

            // The relationship is PUT on the subscription's scope.
            var collection = Client.GetDependencyOfRelationships(DefaultSubscription.Id);
            string relationshipName = Recording.GenerateAssetName("dep-sub-");

            var lro = await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                relationshipName,
                CreateDependencyOfRelationshipData(DefaultSubscription.Id, _target.Id));
            _relationship = lro.Value;

            Assert.IsNotNull(_relationship);
            Assert.AreEqual(relationshipName, _relationship.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, _relationship.Data.ResourceType);
            Assert.AreEqual(DefaultSubscription.Id, _relationship.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, _relationship.Data.Properties.TargetId);
        }

        /// <summary>
        /// Verifies that a DependencyOf relationship can target a subscription — not just a Service Group.
        /// DependencyOf allows any target scope (subscription, resource group, management group, resource).
        /// Corresponds to valid target scope coverage in service-side test: ValidPutSent_SuccessfulResponse.
        /// </summary>
        [RecordedTest]
        public async Task CreateOrUpdate_WithSubscriptionTarget()
        {
            _source = await CreateResourceGroup(DefaultSubscription, "rg-dep-src-", AzureLocation.WestUS2);

            var collection = Client.GetDependencyOfRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("dep-sub-tgt-");

            var lro = await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                relationshipName,
                CreateDependencyOfRelationshipData(_source.Id, DefaultSubscription.Id));
            _relationship = lro.Value;

            Assert.IsNotNull(_relationship);
            Assert.AreEqual(relationshipName, _relationship.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, _relationship.Data.ResourceType);
            Assert.AreEqual(_source.Id, _relationship.Data.Properties.SourceId);
            Assert.AreEqual(DefaultSubscription.Id, _relationship.Data.Properties.TargetId);
        }

        /// <summary>
        /// Verifies that a DependencyOf relationship can be created scoped to a specific ARM resource
        /// (a Key Vault in this case). The vault is the source; targetId points to a Service Group.
        /// </summary>
        [RecordedTest]
        public async Task CreateOrUpdate_OnKeyVaultResource()
        {
            _target = await CreateServiceGroup("sg-kv-target-");
            _cleanupRG = await CreateResourceGroup(DefaultSubscription, "rg-kv-", AzureLocation.WestUS2);
            KeyVaultResource vault = await CreateKeyVault(_cleanupRG, "kv-src-");

            // The relationship is PUT on the vault resource's scope.
            var collection = Client.GetDependencyOfRelationships(vault.Id);
            string relationshipName = Recording.GenerateAssetName("dep-kv-");

            var lro = await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                relationshipName,
                CreateDependencyOfRelationshipData(vault.Id, _target.Id));
            _relationship = lro.Value;

            Assert.IsNotNull(_relationship);
            Assert.AreEqual(relationshipName, _relationship.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, _relationship.Data.ResourceType);
            Assert.AreEqual(vault.Id, _relationship.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, _relationship.Data.Properties.TargetId);
        }

        [RecordedTest]
        public async Task CreateOrUpdate_OnResourceGroup()
        {
            // DependencyOf: source resource group depends on target service group.
            // The relationship is PUT on the source resource's scope.
            _source = await CreateResourceGroup(DefaultSubscription, "rg-source-", AzureLocation.WestUS2);
            _target = await CreateServiceGroup("sg-target-");

            var collection = Client.GetDependencyOfRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("dep-rel-");

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, CreateDependencyOfRelationshipData(_source.Id, _target.Id));
            _relationship = lro.Value;

            Assert.IsNotNull(_relationship);
            Assert.IsNotNull(_relationship.Data);
            Assert.AreEqual(relationshipName, _relationship.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, _relationship.Data.ResourceType);
            Assert.AreEqual(_source.Id, _relationship.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, _relationship.Data.Properties.TargetId);
        }

        /// <summary>
        /// Verifies that a DependencyOf relationship can target a resource group — not just a Service Group.
        /// DependencyOf allows any target scope.
        /// Corresponds to valid target scope coverage in service-side test: ValidPutSent_SuccessfulResponse.
        /// </summary>
        [RecordedTest]
        public async Task CreateOrUpdate_WithResourceGroupTarget()
        {
            _source = await CreateResourceGroup(DefaultSubscription, "rg-dep-src-", AzureLocation.WestUS2);
            _target = await CreateResourceGroup(DefaultSubscription, "rg-dep-tgt-", AzureLocation.WestUS2);

            var collection = Client.GetDependencyOfRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("dep-rg-tgt-");

            var lro = await collection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                relationshipName,
                CreateDependencyOfRelationshipData(_source.Id, _target.Id));
            _relationship = lro.Value;

            Assert.IsNotNull(_relationship);
            Assert.AreEqual(relationshipName, _relationship.Data.Name);
            Assert.AreEqual(DependencyOfRelationshipResource.ResourceType, _relationship.Data.ResourceType);
            Assert.AreEqual(_source.Id, _relationship.Data.Properties.SourceId);
            Assert.AreEqual(_target.Id, _relationship.Data.Properties.TargetId);
        }

        /// <summary>
        /// The service rejects a DependencyOf relationship where the sourceId and targetId are identical.
        /// Corresponds to service-side test: TargetSourceSame_BadRequestAsync.
        /// </summary>
        [RecordedTest]
        public async Task CreateOrUpdate_SameSourceAndTarget_ThrowsRequestFailedException()
        {
            _source = await CreateResourceGroup(DefaultSubscription, "rg-source-", AzureLocation.WestUS2);

            var collection = Client.GetDependencyOfRelationships(_source.Id);
            string relationshipName = Recording.GenerateAssetName("dep-same-");

            // Set targetId equal to the source resource group — the service must reject this.
            var data = new DependencyOfRelationshipData
            {
                Properties = ArmRelationshipsModelFactory.DependencyOfRelationshipProperties(_source.Id, _source.Id)
            };

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await collection.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, data));
            Assert.AreEqual(400, ex.Status);
        }
    }
}
