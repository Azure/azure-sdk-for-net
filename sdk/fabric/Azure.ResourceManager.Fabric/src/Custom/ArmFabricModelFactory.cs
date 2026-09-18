// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.Fabric.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("FabricCapacityPatch", typeof(FabricSku), typeof(IDictionary<string, string>), typeof(FabricCapacityUpdateProperties))]
    public static partial class ArmFabricModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.FabricCapacityProperties"/>. </summary>
        /// <param name="provisioningState"> The current deployment state of Microsoft Fabric resource. The provisioningState is to indicate states for resource provisioning. </param>
        /// <param name="state"> The current state of Microsoft Fabric resource. The state is to indicate more states outside of resource provisioning. </param>
        /// <param name="administrationMembers"> The capacity administration. </param>
        /// <returns> A new <see cref="Models.FabricCapacityProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FabricCapacityProperties FabricCapacityProperties(FabricProvisioningState? provisioningState, FabricResourceState? state, IEnumerable<string> administrationMembers)
        {
            return new FabricCapacityProperties(provisioningState, state, default, administrationMembers is null ? default : new FabricCapacityAdministration((administrationMembers ?? new ChangeTrackingList<string>()).ToList(), default), default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.FabricCapacityPatch"/>. </summary>
        /// <param name="sku"> The SKU details. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="fabricCapacityUpdateAdministrationMembers"> An array of administrator user identities. </param>
        /// <returns> A new <see cref="Models.FabricCapacityPatch"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FabricCapacityPatch FabricCapacityPatch(FabricSku sku = default, IDictionary<string, string> tags = default, IEnumerable<string> fabricCapacityUpdateAdministrationMembers = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new FabricCapacityPatch(sku, tags, fabricCapacityUpdateAdministrationMembers is null ? default : new FabricCapacityUpdateProperties(default, new FabricCapacityAdministration(fabricCapacityUpdateAdministrationMembers.ToList(), default), default), default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.FabricCapacityPatch"/>. </summary>
        /// <param name="sku"> The SKU details. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="properties"> The resource-specific properties for this resource. </param>
        /// <returns> A new <see cref="Models.FabricCapacityPatch"/> instance for mocking. </returns>
        public static FabricCapacityPatch FabricCapacityPatchWithProperties(FabricSku sku = default, IDictionary<string, string> tags = default, FabricCapacityUpdateProperties properties = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new FabricCapacityPatch(sku, tags, properties, default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.FabricCapacityUpdateProperties"/>. </summary>
        /// <param name="administrationMembers"> An array of administrator user identities. </param>
        /// <returns> A new <see cref="Models.FabricCapacityUpdateProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FabricCapacityUpdateProperties FabricCapacityUpdateProperties(IEnumerable<string> administrationMembers)
        {
            return new FabricCapacityUpdateProperties(default, administrationMembers is null ? default : new FabricCapacityAdministration((administrationMembers ?? new ChangeTrackingList<string>()).ToList(), default), default);
        }
    }
}