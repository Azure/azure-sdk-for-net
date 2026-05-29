// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.ClientModel.Tests.ModelReaderWriterTests;
using System.Collections.Generic;
using System.Text.Json;
using ClientModel.Tests.ClientShared;

namespace System.ClientModel.Tests.Client.Models.ResourceManager.Compute
{
    /// <summary>
    /// V2 of AvailabilitySetData with an enhanced PropagateGet that handles array-level paths
    /// by serializing the CLR collection, enabling EnumerateArray to work without round-trip.
    /// </summary>
    public partial class AvailabilitySetDataV2 : TrackedResourceData, IJsonModel<AvailabilitySetDataV2>
    {
        internal AvailabilitySetDataV2() { }

        public AvailabilitySetDataV2(string location) : base(location)
        {
            VirtualMachines = new OptionalList<WritableSubResource>();
            Statuses = new OptionalList<InstanceViewStatus>();
        }

#pragma warning disable SCME0001
        internal AvailabilitySetDataV2(string id, string name, string resourceType, SystemData systemData, IDictionary<string, string> tags, string location, ComputeSku sku, int? platformUpdateDomainCount, int? platformFaultDomainCount, IList<WritableSubResource> virtualMachines, WritableSubResource proximityPlacementGroup, IReadOnlyList<InstanceViewStatus> statuses, in JsonPatch jsonPatch) : base(id, name, resourceType, systemData, tags, location, jsonPatch)
        {
            Sku = sku;
            PlatformUpdateDomainCount = platformUpdateDomainCount;
            PlatformFaultDomainCount = platformFaultDomainCount;
            VirtualMachines = virtualMachines;
            ProximityPlacementGroup = proximityPlacementGroup;
            Statuses = statuses;
            Patch.SetPropagators(PropagateSet, PropagateGet);
        }
#pragma warning restore SCME0001

        public ComputeSku Sku { get; set; }
        public int? PlatformUpdateDomainCount { get; set; }
        public int? PlatformFaultDomainCount { get; set; }
        public IList<WritableSubResource> VirtualMachines { get; }
        internal WritableSubResource ProximityPlacementGroup { get; set; }
        public IReadOnlyList<InstanceViewStatus> Statuses { get; }

#pragma warning disable SCME0001
        private bool PropagateSet(ReadOnlySpan<byte> jsonPath, JsonPatch.EncodedValue value)
        {
            ReadOnlySpan<byte> local = jsonPath.SliceToStartOfPropertyName();

            if (local.StartsWith("sku"u8))
            {
                Sku.Patch.Set([.. "$"u8, .. local.Slice("sku"u8.Length)], value);
                return true;
            }
            else if (local.StartsWith("properties.virtualMachines"u8))
            {
                int propertyLength = "properties.virtualMachines"u8.Length;
                ReadOnlySpan<byte> indexSlice = local.Slice(propertyLength);
                if (!SerializationHelpers.TryGetIndex(indexSlice, out int index, out int bytesConsumed))
                    return false;

                if (VirtualMachines.Count > index)
                {
                    VirtualMachines[index].Patch.Set([.. "$"u8, .. indexSlice.Slice(bytesConsumed + 2)], value);
                    return true;
                }
            }

            return false;
        }

        private bool PropagateGet(ReadOnlySpan<byte> jsonPath, out JsonPatch.EncodedValue value)
        {
            ReadOnlySpan<byte> local = jsonPath.SliceToStartOfPropertyName();
            value = default;

            if (local.StartsWith("sku"u8))
            {
                return Sku.Patch.TryGetEncodedValue([.. "$"u8, .. local.Slice("sku"u8.Length)], out value);
            }
            else if (local.StartsWith("properties.virtualMachines"u8))
            {
                int propertyLength = "properties.virtualMachines"u8.Length;
                ReadOnlySpan<byte> indexSlice = local.Slice(propertyLength);

                // Enhanced: handle array-level path (no index) by serializing CLR collection
                if (indexSlice.IsEmpty)
                {
                    return TryResolveVirtualMachinesArray(out value);
                }

                if (!SerializationHelpers.TryGetIndex(indexSlice, out int index, out int bytesConsumed))
                    return false;

                if (VirtualMachines.Count > index)
                {
                    return VirtualMachines[index].Patch.TryGetEncodedValue([.. "$"u8, .. indexSlice.Slice(bytesConsumed + 2)], out value);
                }
            }

            return false;
        }

        /// <summary>
        /// Writes the non-removed VirtualMachines CLR items as array elements to the writer.
        /// Used by Serialize which also appends patch items via WriteTo.
        /// </summary>
        private void WriteVirtualMachineItems(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (!OptionalProperty.IsCollectionDefined(VirtualMachines))
                return;

            for (int i = 0; i < VirtualMachines.Count; i++)
            {
                if (!VirtualMachines[i].Patch.IsRemoved("$"u8))
                    ((IJsonModel<WritableSubResource>)VirtualMachines[i]).Write(writer, options);
            }
        }

        /// <summary>
        /// Serializes the VirtualMachines CLR collection into a JSON array using
        /// ModelReaderWriter.Write which internally uses pooled buffers.
        /// Only includes CLR items — patch-level appends are handled separately
        /// by ResolveArray's append merge logic.
        /// </summary>
        private bool TryResolveVirtualMachinesArray(out JsonPatch.EncodedValue value)
        {
            value = default;

            // Use "J" format directly to avoid the empty-collection "W" format error
            // and skip the double-enumeration that "W" requires to probe the first item.
            BinaryData data = ModelReaderWriter.Write(ActiveVirtualMachines(), new ModelReaderWriterOptions("J"));

            // Set on a temp patch to produce an EncodedValue via public API.
            // EncodedValue constructors are internal so this is the only way
            // from SDK (non-InternalsVisibleTo) code.
            var tempPatch = new JsonPatch();
            tempPatch.Set("$"u8, data.ToMemory().Span);
            return tempPatch.TryGetEncodedValue("$"u8, out value);
        }

        private IEnumerable<WritableSubResource> ActiveVirtualMachines()
        {
            if (!OptionalProperty.IsCollectionDefined(VirtualMachines))
                yield break;

            for (int i = 0; i < VirtualMachines.Count; i++)
            {
                if (!VirtualMachines[i].Patch.IsRemoved("$"u8))
                    yield return VirtualMachines[i];
            }
        }
#pragma warning restore SCME0001
    }
}
