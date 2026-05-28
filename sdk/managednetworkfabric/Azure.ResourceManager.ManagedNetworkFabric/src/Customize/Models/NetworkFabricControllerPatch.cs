// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkFabricControllerPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkFabricControllerPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkFabricControllerPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The Network Fabric Controller Patch payload definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricControllerPatchContent instead.")]
    public partial class NetworkFabricControllerPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricControllerPatch"/>. </summary>
        public NetworkFabricControllerPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricControllerPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Network Fabric Controller patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkFabricControllerPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NetworkFabricControllerPatchProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> Network Fabric Controller patch properties. </summary>
        internal NetworkFabricControllerPatchProperties Properties { get; set; }

        /// <summary> The managed service identities assigned to this resource. </summary>
        public NetworkFabricManagedServiceIdentityPatch Identity { get; set; }

        /// <summary> As part of an update, the Infrastructure ExpressRoute CircuitID should be provided to create and Provision a NFC. This Express route is dedicated for Infrastructure services. (This is a Mandatory attribute). </summary>
        public IList<ExpressRouteConnectionInformation> InfrastructureExpressRouteConnections
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricControllerPatchProperties();
                }
                return Properties.InfrastructureExpressRouteConnections;
            }
        }

        /// <summary> As part of an update, the workload ExpressRoute CircuitID should be provided to create and Provision a NFC. This Express route is dedicated for Workload services. (This is a Mandatory attribute). </summary>
        public IList<ExpressRouteConnectionInformation> WorkloadExpressRouteConnections
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricControllerPatchProperties();
                }
                return Properties.WorkloadExpressRouteConnections;
            }
        }
    }
}
