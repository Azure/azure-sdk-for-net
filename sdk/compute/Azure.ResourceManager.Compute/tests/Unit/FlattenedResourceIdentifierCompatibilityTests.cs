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
        public void KeyVaultSourceVaultIdRemainsNonVirtual()
        {
            var property = typeof(KeyVaultKeyReference).GetProperty(nameof(KeyVaultKeyReference.SourceVaultId));

            Assert.IsFalse(property.GetMethod.IsVirtual);
            Assert.IsFalse(property.SetMethod.IsVirtual);
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
            yield return new TestCaseData(typeof(AvailabilitySetData), nameof(AvailabilitySetData.ProximityPlacementGroupId));
            yield return new TestCaseData(typeof(DiskImageData), nameof(DiskImageData.SourceVirtualMachineId));
            yield return new TestCaseData(typeof(AvailabilitySetPatch), nameof(AvailabilitySetPatch.ProximityPlacementGroupId));
            yield return new TestCaseData(typeof(CapacityReservationProfile), nameof(CapacityReservationProfile.CapacityReservationGroupId));
            yield return new TestCaseData(typeof(DataDisksToAttach), nameof(DataDisksToAttach.DiskEncryptionSetId));
            yield return new TestCaseData(typeof(DefaultVirtualMachineScaleSetInfo), nameof(DefaultVirtualMachineScaleSetInfo.DefaultVirtualMachineScaleSetId));
            yield return new TestCaseData(typeof(DiskImagePatch), nameof(DiskImagePatch.SourceVirtualMachineId));
            yield return new TestCaseData(typeof(ImageDisk), nameof(ImageDisk.SnapshotId));
            yield return new TestCaseData(typeof(ImageDisk), nameof(ImageDisk.ManagedDiskId));
            yield return new TestCaseData(typeof(ImageDisk), nameof(ImageDisk.DiskEncryptionSetId));
            yield return new TestCaseData(typeof(InterconnectGroupProfile), nameof(InterconnectGroupProfile.InterconnectGroupId));
            yield return new TestCaseData(typeof(KeyVaultKeyReference), nameof(KeyVaultKeyReference.SourceVaultId));
            yield return new TestCaseData(typeof(KeyVaultSecretReference), nameof(KeyVaultSecretReference.SourceVaultId));
            yield return new TestCaseData(typeof(MigrateToVirtualMachineScaleSetInput), nameof(MigrateToVirtualMachineScaleSetInput.VirtualMachineScaleSetFlexibleId));
            yield return new TestCaseData(typeof(RestorePointEncryption), nameof(RestorePointEncryption.DiskEncryptionSetId));
            yield return new TestCaseData(typeof(VaultSecretGroup), nameof(VaultSecretGroup.SourceVaultId));
            yield return new TestCaseData(typeof(VirtualMachineDiskSecurityProfile), nameof(VirtualMachineDiskSecurityProfile.DiskEncryptionSetId));
            yield return new TestCaseData(typeof(VirtualMachineManagedDisk), nameof(VirtualMachineManagedDisk.DiskEncryptionSetId));
            yield return new TestCaseData(typeof(VirtualMachineNetworkInterfaceConfiguration), nameof(VirtualMachineNetworkInterfaceConfiguration.NetworkSecurityGroupId));
            yield return new TestCaseData(typeof(VirtualMachineNetworkInterfaceConfiguration), nameof(VirtualMachineNetworkInterfaceConfiguration.DscpConfigurationId));
            yield return new TestCaseData(typeof(VirtualMachineNetworkInterfaceIPConfiguration), nameof(VirtualMachineNetworkInterfaceIPConfiguration.SubnetId));
            yield return new TestCaseData(typeof(VirtualMachinePatch), nameof(VirtualMachinePatch.AvailabilitySetId));
            yield return new TestCaseData(typeof(VirtualMachinePatch), nameof(VirtualMachinePatch.VirtualMachineScaleSetId));
            yield return new TestCaseData(typeof(VirtualMachinePatch), nameof(VirtualMachinePatch.ProximityPlacementGroupId));
            yield return new TestCaseData(typeof(VirtualMachinePatch), nameof(VirtualMachinePatch.HostId));
            yield return new TestCaseData(typeof(VirtualMachinePatch), nameof(VirtualMachinePatch.HostGroupId));
            yield return new TestCaseData(typeof(VirtualMachinePublicIPAddressConfiguration), nameof(VirtualMachinePublicIPAddressConfiguration.PublicIPPrefixId));
            yield return new TestCaseData(typeof(VirtualMachineScaleSetManagedDisk), nameof(VirtualMachineScaleSetManagedDisk.DiskEncryptionSetId));
            yield return new TestCaseData(typeof(VirtualMachineScaleSetMigrationInfo), nameof(VirtualMachineScaleSetMigrationInfo.MigrateToVirtualMachineScaleSetId));
            yield return new TestCaseData(typeof(VirtualMachineScaleSetNetworkConfiguration), nameof(VirtualMachineScaleSetNetworkConfiguration.NetworkSecurityGroupId));
            yield return new TestCaseData(typeof(VirtualMachineScaleSetPatchProperties), nameof(VirtualMachineScaleSetPatchProperties.ProximityPlacementGroupId));
            yield return new TestCaseData(typeof(VirtualMachineScaleSetProperties), nameof(VirtualMachineScaleSetProperties.ProximityPlacementGroupId));
            yield return new TestCaseData(typeof(VirtualMachineScaleSetProperties), nameof(VirtualMachineScaleSetProperties.HostGroupId));
            yield return new TestCaseData(typeof(VirtualMachineScaleSetPublicIPAddressConfiguration), nameof(VirtualMachineScaleSetPublicIPAddressConfiguration.PublicIPPrefixId));
            yield return new TestCaseData(typeof(VirtualMachineScaleSetUpdateNetworkConfiguration), nameof(VirtualMachineScaleSetUpdateNetworkConfiguration.NetworkSecurityGroupId));
            yield return new TestCaseData(typeof(VirtualMachineScaleSetUpdatePublicIPAddressConfiguration), nameof(VirtualMachineScaleSetUpdatePublicIPAddressConfiguration.PublicIPPrefixId));
            yield return new TestCaseData(typeof(VirtualMachineScaleSetVmProperties), nameof(VirtualMachineScaleSetVmProperties.AvailabilitySetId));
            yield return new TestCaseData(typeof(VirtualMachineData), nameof(VirtualMachineData.AvailabilitySetId));
            yield return new TestCaseData(typeof(VirtualMachineData), nameof(VirtualMachineData.VirtualMachineScaleSetId));
            yield return new TestCaseData(typeof(VirtualMachineData), nameof(VirtualMachineData.ProximityPlacementGroupId));
            yield return new TestCaseData(typeof(VirtualMachineData), nameof(VirtualMachineData.HostId));
            yield return new TestCaseData(typeof(VirtualMachineData), nameof(VirtualMachineData.HostGroupId));
        }

        [TestCaseSource(nameof(FlattenedIdProperties))]
        public void FlattenedIdRemainsNonVirtual(Type type, string name)
        {
            var property = type.GetProperty(name);

            Assert.IsFalse(property.GetMethod.IsVirtual);
            if (property.SetMethod != null)
            {
                Assert.IsFalse(property.SetMethod.IsVirtual);
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
