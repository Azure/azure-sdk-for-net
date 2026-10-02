// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.ResourceManager.ElasticSan.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ElasticSan.Tests
{
    public class BackwardCompatibilityTests
    {
        private static readonly ResourceIdentifier ManagedById = new("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Compute/virtualMachines/test");

        [Test]
        public void VolumeDataManagedByResourceIdBridgesManagedBy()
        {
            ElasticSanVolumeData data = new(100)
            {
                ManagedByResourceId = ManagedById
            };

            Assert.AreEqual(ManagedById, data.ManagedByResourceId);
            Assert.AreEqual(1, data.ManagedBy.Count);
            Assert.AreEqual(ManagedById, data.ManagedBy[0].ResourceIds[0]);

            data.ManagedByResourceId = null;

            Assert.IsNull(data.ManagedByResourceId);
            Assert.IsEmpty(data.ManagedBy);
        }

        [Test]
        public void VolumePatchManagedByResourceIdBridgesManagedBy()
        {
            ElasticSanVolumePatch patch = new()
            {
                ManagedByResourceId = ManagedById
            };

            Assert.AreEqual(ManagedById, patch.ManagedByResourceId);
            Assert.AreEqual(1, patch.ManagedBy.Count);
            Assert.AreEqual(ManagedById, patch.ManagedBy[0].ResourceIds[0]);

            patch.ManagedByResourceId = null;

            Assert.IsNull(patch.ManagedByResourceId);
            Assert.IsEmpty(patch.ManagedBy);
        }

        [Test]
        public void ModelFactoryVolumeDataPreservesManagedByResourceId()
        {
            ElasticSanVolumeData data = ArmElasticSanModelFactory.ElasticSanVolumeData(null, null, default, null, null, null, 100, null, ElasticSanProvisioningState.Succeeded, ManagedById);

            Assert.AreEqual(ManagedById, data.ManagedByResourceId);
            Assert.AreEqual(1, data.ManagedBy.Count);
            Assert.AreEqual(ElasticSanProvisioningState.Succeeded, data.ProvisioningState);

            data = ArmElasticSanModelFactory.ElasticSanVolumeData(null, null, default, null, null, null, 100, null, ManagedById, ElasticSanProvisioningState.Succeeded);

            Assert.AreEqual(ManagedById, data.ManagedByResourceId);
            Assert.AreEqual(1, data.ManagedBy.Count);
            Assert.AreEqual(ElasticSanProvisioningState.Succeeded, data.ProvisioningState);
        }

        [Test]
        public void ModelFactoryVolumePatchPreservesManagedByResourceId()
        {
            ElasticSanVolumePatch patch = ArmElasticSanModelFactory.ElasticSanVolumePatch(10, ManagedById);

            Assert.AreEqual(10, patch.SizeGiB);
            Assert.AreEqual(ManagedById, patch.ManagedByResourceId);
            Assert.AreEqual(1, patch.ManagedBy.Count);

            patch = ArmElasticSanModelFactory.ElasticSanVolumePatch(10, null);

            Assert.AreEqual(10, patch.SizeGiB);
            Assert.IsNull(patch.ManagedByResourceId);
            Assert.IsEmpty(patch.ManagedBy);
        }

        [Test]
        public void ModelFactoryOverloadsAreUnambiguousForUntypedNull()
        {
            ElasticSanVolumeData data = ArmElasticSanModelFactory.ElasticSanVolumeData(null, null, default, null, null, null, 100, null, null, ElasticSanProvisioningState.Succeeded);

            Assert.AreEqual(100, data.SizeGiB);
            Assert.IsNull(data.ManagedByResourceId);
            Assert.IsEmpty(data.ManagedBy);
            Assert.AreEqual(ElasticSanProvisioningState.Succeeded, data.ProvisioningState);

            ElasticSanVolumePatch patch = ArmElasticSanModelFactory.ElasticSanVolumePatch(10, null);

            Assert.AreEqual(10, patch.SizeGiB);
            Assert.IsEmpty(patch.ManagedBy);
        }

        [Test]
        public void ModelFactoryListBasedOverloadsProduceMutableManagedBy()
        {
            ElasticSanVolumeData data = ArmElasticSanModelFactory.ElasticSanVolumeData(null, null, default, null, null, null, 100, null, ElasticSanProvisioningState.Succeeded);

            Assert.IsEmpty(data.ManagedBy);
            data.ManagedBy.Add(ArmElasticSanModelFactory.ElasticSanManagedByInfo(resourceIds: new[] { ManagedById }));
            Assert.AreEqual(ManagedById, data.ManagedByResourceId);

            ElasticSanVolumePatch patch = ArmElasticSanModelFactory.ElasticSanVolumePatch(10);

            Assert.AreEqual(10, patch.SizeGiB);
            Assert.IsEmpty(patch.ManagedBy);
            patch.ManagedBy.Add(ArmElasticSanModelFactory.ElasticSanManagedByInfo(resourceIds: new[] { ManagedById }));
            Assert.AreEqual(ManagedById, patch.ManagedByResourceId);
        }

        [Test]
        public void VolumeDataAcceptsLegacyAndCurrentManagedByShapes()
        {
            ElasticSanVolumeData legacy = ModelReaderWriter.Read<ElasticSanVolumeData>(BinaryData.FromString(
                $"{{\"properties\":{{\"sizeGiB\":100,\"managedBy\":{{\"resourceId\":\"{ManagedById}\"}}}}}}"));

            Assert.AreEqual(1, legacy.ManagedBy.Count);
            Assert.AreEqual(ManagedById, legacy.ManagedByResourceId);

            ElasticSanVolumeData current = ModelReaderWriter.Read<ElasticSanVolumeData>(BinaryData.FromString(
                $"{{\"properties\":{{\"sizeGiB\":100,\"managedBy\":[{{\"resourceIds\":[\"{ManagedById}\"]}}]}}}}"));

            Assert.AreEqual(1, current.ManagedBy.Count);
            Assert.AreEqual(ManagedById, current.ManagedByResourceId);
        }

        [Test]
        public void VolumePatchAcceptsLegacyAndCurrentManagedByShapes()
        {
            ElasticSanVolumePatch legacy = ModelReaderWriter.Read<ElasticSanVolumePatch>(BinaryData.FromString(
                $"{{\"properties\":{{\"sizeGiB\":100,\"managedBy\":{{\"resourceId\":\"{ManagedById}\"}}}}}}"));

            Assert.AreEqual(1, legacy.ManagedBy.Count);
            Assert.AreEqual(ManagedById, legacy.ManagedByResourceId);

            ElasticSanVolumePatch current = ModelReaderWriter.Read<ElasticSanVolumePatch>(BinaryData.FromString(
                $"{{\"properties\":{{\"sizeGiB\":100,\"managedBy\":[{{\"resourceIds\":[\"{ManagedById}\"]}}]}}}}"));

            Assert.AreEqual(1, current.ManagedBy.Count);
            Assert.AreEqual(ManagedById, current.ManagedByResourceId);
        }

        [Test]
        public void SnapshotDataCreationInfoConstructorSerializesSourceId()
        {
            ResourceIdentifier volumeId = new("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.ElasticSan/elasticSans/san/volumegroups/vg/volumes/vol");

            ElasticSanSnapshotData data = new(new SnapshotCreationInfo(volumeId));

            Assert.AreEqual(volumeId, data.CreationDataSourceId);
            string json = ModelReaderWriter.Write(data).ToString();
            StringAssert.Contains("\"creationData\"", json);
            StringAssert.Contains(volumeId.ToString(), json);

            ElasticSanSnapshotData deserialized = ModelReaderWriter.Read<ElasticSanSnapshotData>(BinaryData.FromString(json));
            Assert.AreEqual(volumeId, deserialized.CreationDataSourceId);

            ResourceIdentifier otherVolumeId = new(volumeId.Parent + "/volumes/other");
            data.CreationDataSourceId = otherVolumeId;
            StringAssert.Contains(otherVolumeId.ToString(), ModelReaderWriter.Write(data).ToString());
        }

        [Test]
        public void VolumeGroupDataDeleteRetentionPolicyRoundTripsThroughWire()
        {
            ElasticSanVolumeGroupData data = new()
            {
                DeleteRetentionPolicy = new ElasticSanDeleteRetentionPolicy
                {
                    PolicyState = ElasticSanDeleteRetentionPolicyState.Enabled,
                    RetentionPeriodDays = 7
                }
            };

            BinaryData json = ModelReaderWriter.Write(data);
            StringAssert.Contains("\"deleteRetentionPolicy\"", json.ToString());

            ElasticSanVolumeGroupData deserialized = ModelReaderWriter.Read<ElasticSanVolumeGroupData>(json);

            Assert.IsNotNull(deserialized.DeleteRetentionPolicy);
            Assert.AreEqual(ElasticSanDeleteRetentionPolicyState.Enabled, deserialized.DeleteRetentionPolicy.PolicyState);
            Assert.AreEqual(7, deserialized.DeleteRetentionPolicy.RetentionPeriodDays);
        }

        [Test]
        public void VolumeGroupPatchDeleteRetentionPolicyIsSerialized()
        {
            ElasticSanVolumeGroupPatch patch = new();
            Assert.IsNull(patch.DeleteRetentionPolicy);

            patch.DeleteRetentionPolicy = new ElasticSanDeleteRetentionPolicy
            {
                PolicyState = ElasticSanDeleteRetentionPolicyState.Enabled,
                RetentionPeriodDays = 7
            };

            string json = ModelReaderWriter.Write(patch).ToString();
            StringAssert.Contains("\"deleteRetentionPolicy\"", json);
            StringAssert.Contains("\"retentionPeriodDays\":7", json);

            ElasticSanVolumeGroupPatch deserialized = ModelReaderWriter.Read<ElasticSanVolumeGroupPatch>(BinaryData.FromString(json));
            Assert.AreEqual(7, deserialized.DeleteRetentionPolicy.RetentionPeriodDays);
        }
    }
}
