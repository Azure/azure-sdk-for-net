// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    public class FlattenedResourceIdentifierCompatibilityTests
    {
        [Test]
        public void KeyVaultSourceVaultIdRetainsGaAccessors()
        {
            var property = typeof(KeyVaultKeyReference).GetProperty(nameof(KeyVaultKeyReference.SourceVaultId));

            Assert.IsNotNull(property);
            Assert.AreEqual(typeof(ResourceIdentifier), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void KeyVaultSourceVaultIdPreservesWireBacking(string format)
        {
            var id = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/test/providers/Microsoft.KeyVault/vaults/test");
            var model = new KeyVaultKeyReference(new Uri("https://test.vault.azure.net/keys/key/version"))
            {
                SourceVaultId = id
            };
            var options = new ModelReaderWriterOptions(format);
            var data = ModelReaderWriter.Write(model, options);

            using var document = JsonDocument.Parse(data);
            Assert.AreEqual(id.ToString(), document.RootElement.GetProperty("sourceVault").GetProperty("id").GetString());
            Assert.IsFalse(document.RootElement.TryGetProperty("sourceVaultId", out _));
            Assert.AreEqual(id, ModelReaderWriter.Read<KeyVaultKeyReference>(data, options).SourceVaultId);

            model.SourceVaultId = null;
            Assert.IsNull(model.SourceVaultId);
        }

        public static IEnumerable<TestCaseData> FlattenedIdProperties()
        {
            yield return new TestCaseData(typeof(AvailabilitySetData), nameof(AvailabilitySetData.ProximityPlacementGroupId), true);
            yield return new TestCaseData(typeof(DiskImageData), nameof(DiskImageData.SourceVirtualMachineId), true);
            yield return new TestCaseData(typeof(AvailabilitySetPatch), nameof(AvailabilitySetPatch.ProximityPlacementGroupId), true);
            yield return new TestCaseData(typeof(CapacityReservationProfile), nameof(CapacityReservationProfile.CapacityReservationGroupId), true);
            yield return new TestCaseData(typeof(DataDisksToAttach), nameof(DataDisksToAttach.DiskEncryptionSetId), true);
            yield return new TestCaseData(typeof(DefaultVirtualMachineScaleSetInfo), nameof(DefaultVirtualMachineScaleSetInfo.DefaultVirtualMachineScaleSetId), false);
            yield return new TestCaseData(typeof(DiskImagePatch), nameof(DiskImagePatch.SourceVirtualMachineId), true);
            yield return new TestCaseData(typeof(ImageDisk), nameof(ImageDisk.SnapshotId), true);
            yield return new TestCaseData(typeof(ImageDisk), nameof(ImageDisk.ManagedDiskId), true);
            yield return new TestCaseData(typeof(ImageDisk), nameof(ImageDisk.DiskEncryptionSetId), true);
            yield return new TestCaseData(typeof(InterconnectGroupProfile), nameof(InterconnectGroupProfile.InterconnectGroupId), true);
            yield return new TestCaseData(typeof(KeyVaultKeyReference), nameof(KeyVaultKeyReference.SourceVaultId), true);
            yield return new TestCaseData(typeof(KeyVaultSecretReference), nameof(KeyVaultSecretReference.SourceVaultId), true);
            yield return new TestCaseData(typeof(MigrateToVirtualMachineScaleSetInput), nameof(MigrateToVirtualMachineScaleSetInput.VirtualMachineScaleSetFlexibleId), false);
            yield return new TestCaseData(typeof(RestorePointEncryption), nameof(RestorePointEncryption.DiskEncryptionSetId), true);
            yield return new TestCaseData(typeof(VaultSecretGroup), nameof(VaultSecretGroup.SourceVaultId), true);
            yield return new TestCaseData(typeof(VirtualMachineDiskSecurityProfile), nameof(VirtualMachineDiskSecurityProfile.DiskEncryptionSetId), true);
            yield return new TestCaseData(typeof(VirtualMachineManagedDisk), nameof(VirtualMachineManagedDisk.DiskEncryptionSetId), true);
            yield return new TestCaseData(typeof(VirtualMachineNetworkInterfaceConfiguration), nameof(VirtualMachineNetworkInterfaceConfiguration.NetworkSecurityGroupId), true);
            yield return new TestCaseData(typeof(VirtualMachineNetworkInterfaceConfiguration), nameof(VirtualMachineNetworkInterfaceConfiguration.DscpConfigurationId), true);
            yield return new TestCaseData(typeof(VirtualMachineNetworkInterfaceIPConfiguration), nameof(VirtualMachineNetworkInterfaceIPConfiguration.SubnetId), true);
            yield return new TestCaseData(typeof(VirtualMachinePatch), nameof(VirtualMachinePatch.AvailabilitySetId), true);
            yield return new TestCaseData(typeof(VirtualMachinePatch), nameof(VirtualMachinePatch.VirtualMachineScaleSetId), true);
            yield return new TestCaseData(typeof(VirtualMachinePatch), nameof(VirtualMachinePatch.ProximityPlacementGroupId), true);
            yield return new TestCaseData(typeof(VirtualMachinePatch), nameof(VirtualMachinePatch.HostId), true);
            yield return new TestCaseData(typeof(VirtualMachinePatch), nameof(VirtualMachinePatch.HostGroupId), true);
            yield return new TestCaseData(typeof(VirtualMachinePublicIPAddressConfiguration), nameof(VirtualMachinePublicIPAddressConfiguration.PublicIPPrefixId), true);
            yield return new TestCaseData(typeof(VirtualMachineScaleSetManagedDisk), nameof(VirtualMachineScaleSetManagedDisk.DiskEncryptionSetId), true);
            yield return new TestCaseData(typeof(VirtualMachineScaleSetMigrationInfo), nameof(VirtualMachineScaleSetMigrationInfo.MigrateToVirtualMachineScaleSetId), false);
            yield return new TestCaseData(typeof(VirtualMachineScaleSetNetworkConfiguration), nameof(VirtualMachineScaleSetNetworkConfiguration.NetworkSecurityGroupId), true);
            yield return new TestCaseData(typeof(VirtualMachineScaleSetPatchProperties), nameof(VirtualMachineScaleSetPatchProperties.ProximityPlacementGroupId), true);
            yield return new TestCaseData(typeof(VirtualMachineScaleSetProperties), nameof(VirtualMachineScaleSetProperties.ProximityPlacementGroupId), true);
            yield return new TestCaseData(typeof(VirtualMachineScaleSetProperties), nameof(VirtualMachineScaleSetProperties.HostGroupId), true);
            yield return new TestCaseData(typeof(VirtualMachineScaleSetPublicIPAddressConfiguration), nameof(VirtualMachineScaleSetPublicIPAddressConfiguration.PublicIPPrefixId), true);
            yield return new TestCaseData(typeof(VirtualMachineScaleSetUpdateNetworkConfiguration), nameof(VirtualMachineScaleSetUpdateNetworkConfiguration.NetworkSecurityGroupId), true);
            yield return new TestCaseData(typeof(VirtualMachineScaleSetUpdatePublicIPAddressConfiguration), nameof(VirtualMachineScaleSetUpdatePublicIPAddressConfiguration.PublicIPPrefixId), true);
            yield return new TestCaseData(typeof(VirtualMachineScaleSetVmProperties), nameof(VirtualMachineScaleSetVmProperties.AvailabilitySetId), true);
            yield return new TestCaseData(typeof(VirtualMachineData), nameof(VirtualMachineData.AvailabilitySetId), true);
            yield return new TestCaseData(typeof(VirtualMachineData), nameof(VirtualMachineData.VirtualMachineScaleSetId), true);
            yield return new TestCaseData(typeof(VirtualMachineData), nameof(VirtualMachineData.ProximityPlacementGroupId), true);
            yield return new TestCaseData(typeof(VirtualMachineData), nameof(VirtualMachineData.HostId), true);
            yield return new TestCaseData(typeof(VirtualMachineData), nameof(VirtualMachineData.HostGroupId), true);
        }

        [TestCaseSource(nameof(FlattenedIdProperties))]
        public void FlattenedIdRetainsGaAccessors(Type type, string name, bool hadPublicSetter)
        {
            var property = type.GetProperty(name);

            // Adding virtual is compatible; preserve the public accessors shipped in GA.
            Assert.IsNotNull(property);
            Assert.AreEqual(typeof(ResourceIdentifier), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            if (hadPublicSetter)
            {
                Assert.IsNotNull(property.SetMethod);
                Assert.IsTrue(property.SetMethod.IsPublic);
            }
        }

        [Test]
        public void WritableSubResourceIdRemainsVirtual()
        {
            var property = typeof(ComputeWriteableSubResourceData).GetProperty(nameof(ComputeWriteableSubResourceData.Id));

            Assert.IsTrue(property.GetMethod.IsVirtual);
            Assert.IsTrue(property.SetMethod.IsVirtual);

            ComputeWriteableSubResourceData model = new OverriddenSubResource();
            var id = new ResourceIdentifier(ResourceId);
            model.Id = id;
            Assert.AreSame(id, model.Id);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void DiskEncryptionSetIdPreservesInheritedWireBacking(string format)
        {
            var id = new ResourceIdentifier(ResourceId);
            var model = new VirtualMachineManagedDisk { DiskEncryptionSetId = id };
            var options = new ModelReaderWriterOptions(format);
            var data = ModelReaderWriter.Write(model, options);

            using var document = JsonDocument.Parse(data);
            Assert.AreEqual(id.ToString(), document.RootElement.GetProperty("diskEncryptionSet").GetProperty("id").GetString());
            Assert.IsFalse(document.RootElement.TryGetProperty("diskEncryptionSetId", out _));
            Assert.AreEqual(id, ModelReaderWriter.Read<VirtualMachineManagedDisk>(data, options).DiskEncryptionSetId);

            model.DiskEncryptionSetId = null;
            Assert.IsNull(model.DiskEncryptionSetId);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ProximityPlacementGroupIdPreservesNestedWireBacking(string format)
        {
            var id = new ResourceIdentifier(ResourceId);
            var model = new AvailabilitySetPatch { ProximityPlacementGroupId = id };
            var options = new ModelReaderWriterOptions(format);
            var data = ModelReaderWriter.Write(model, options);

            using var document = JsonDocument.Parse(data);
            Assert.AreEqual(id.ToString(), document.RootElement.GetProperty("properties").GetProperty("proximityPlacementGroup").GetProperty("id").GetString());
            Assert.IsFalse(document.RootElement.TryGetProperty("proximityPlacementGroupId", out _));
            Assert.AreEqual(id, ModelReaderWriter.Read<AvailabilitySetPatch>(data, options).ProximityPlacementGroupId);

            model.ProximityPlacementGroupId = null;
            Assert.IsNull(model.ProximityPlacementGroupId);
        }

        private const string ResourceId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/test/providers/Microsoft.Compute/disks/test";

        private sealed class OverriddenSubResource : ComputeWriteableSubResourceData
        {
            public override ResourceIdentifier Id { get; set; }
        }
    }
}
