using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing the availability set data model.
    /// </summary>
    public class AvailabilitySetData : TrackedResource<ResourceGroupResourceIdentifier, Azure.ResourceManager.Compute.Models.AvailabilitySet>
    {
        /// <summary>
        /// Gets the resource type definition for an availability set.
        /// </summary>
        public static ResourceType ResourceType => "Microsoft.Compute/availabilitySets";

        /// <summary>
        /// Initializes a new instance of the <see cref="AvailabilitySetData"/> class.
        /// </summary>
        /// <param name="aset"> The availability set to initialize. </param>
        public AvailabilitySetData(Azure.ResourceManager.Compute.Models.AvailabilitySet aset)
            : base(aset.Id, aset.Location, aset)
        {
        }

        /// <summary> Resource tags. </summary>
        public override IDictionary<string, string> Tags => Model.Tags;

        /// <summary> Resource name. </summary>
        public override string Name => Model.Name;

        /// <summary> Sku of the availability set, only name is required to be set. See AvailabilitySetSkuTypes for possible set of values. Use &apos;Aligned&apos; for virtual machines with managed disks and &apos;Classic&apos; for virtual machines with unmanaged disks. Default value is &apos;Classic&apos;. </summary>
        public Azure.ResourceManager.Compute.Models.Sku Sku
        {
            get => Model.Sku;
            set => Model.Sku = value;
        }

        /// <summary> The number of update domains that the availaility set can span. </summary>
        public int? PlatformUpdateDomainCount
        {
            get => Model.PlatformUpdateDomainCount;
            set => Model.PlatformUpdateDomainCount = value;
        }

        /// <summary> The number of fault domains that the availaility set can span. </summary>
        public int? PlatformFaultDomainCount
        {
            get => Model.PlatformFaultDomainCount;
            set => Model.PlatformFaultDomainCount = value;
        }

        /// <summary> A list of references to all virtual machines in the availability set. </summary>
        public IList<SubResource> VirtualMachines
        {
            get => Model.VirtualMachines;
        }

        /// <summary> Specifies information about the proximity placement group that the availability set should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01. </summary>
        public SubResource ProximityPlacementGroup
        {
            get => Model.ProximityPlacementGroup;
            set => Model.ProximityPlacementGroup = value;
        }

        /// <summary> The resource status information. </summary>
        public IReadOnlyList<InstanceViewStatus> Statuses => Model.Statuses;
    }
}
