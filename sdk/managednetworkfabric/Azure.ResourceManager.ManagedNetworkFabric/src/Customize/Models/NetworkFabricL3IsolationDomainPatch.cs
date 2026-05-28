// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkFabricL3IsolationDomainPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkFabricL3IsolationDomainPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkFabricL3IsolationDomainPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The L3 Isolation Domain patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricL3IsolationDomainPatchContent instead.")]
    public partial class NetworkFabricL3IsolationDomainPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricL3IsolationDomainPatch"/>. </summary>
        public NetworkFabricL3IsolationDomainPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricL3IsolationDomainPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> L3 Isolation Domain resource patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkFabricL3IsolationDomainPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, L3IsolationDomainPatchProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> L3 Isolation Domain resource patch properties. </summary>
        internal L3IsolationDomainPatchProperties Properties { get; set; }

        /// <summary> The managed service identities assigned to this resource. </summary>
        public NetworkFabricManagedServiceIdentityPatch Identity { get; set; }

        /// <summary> Switch configuration description. </summary>
        public string Annotation
        {
            get
            {
                return Properties is null ? default : Properties.Annotation;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L3IsolationDomainPatchProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> Advertise Connected Subnets. Ex: "True" | "False". </summary>
        public RedistributeConnectedSubnet? RedistributeConnectedSubnets
        {
            get
            {
                return Properties is null ? default : Properties.RedistributeConnectedSubnets;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L3IsolationDomainPatchProperties();
                }
                Properties.RedistributeConnectedSubnets = value;
            }
        }

        /// <summary> Advertise Static Routes. Ex: "True" | "False". </summary>
        public RedistributeStaticRoute? RedistributeStaticRoutes
        {
            get
            {
                return Properties is null ? default : Properties.RedistributeStaticRoutes;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L3IsolationDomainPatchProperties();
                }
                Properties.RedistributeStaticRoutes = value;
            }
        }

        /// <summary> Aggregate route configurations. </summary>
        public AggregateRouteConfiguration AggregateRouteConfiguration
        {
            get
            {
                return Properties is null ? default : Properties.AggregateRouteConfiguration;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L3IsolationDomainPatchProperties();
                }
                Properties.AggregateRouteConfiguration = value;
            }
        }

        /// <summary> Connected Subnet RoutePolicy. </summary>
        public ConnectedSubnetRoutePolicy ConnectedSubnetRoutePolicy
        {
            get
            {
                return Properties is null ? default : Properties.ConnectedSubnetRoutePolicy;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L3IsolationDomainPatchProperties();
                }
                Properties.ConnectedSubnetRoutePolicy = value;
            }
        }

        /// <summary> IPv4 VRF Limit configuration. </summary>
        public RoutePrefixLimitPatchProperties V4RoutePrefixLimit
        {
            get
            {
                return Properties is null ? default : Properties.V4RoutePrefixLimit;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L3IsolationDomainPatchProperties();
                }
                Properties.V4RoutePrefixLimit = value;
            }
        }

        /// <summary> IPv6 VRF Limit configuration. </summary>
        public RoutePrefixLimitPatchProperties V6RoutePrefixLimit
        {
            get
            {
                return Properties is null ? default : Properties.V6RoutePrefixLimit;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L3IsolationDomainPatchProperties();
                }
                Properties.V6RoutePrefixLimit = value;
            }
        }

        /// <summary> Array of ARM Resource ID of the RoutePolicies. </summary>
        public L3ExportRoutePolicyPatch StaticRouteExportRoutePolicy
        {
            get
            {
                return Properties is null ? default : Properties.StaticRouteExportRoutePolicy;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L3IsolationDomainPatchProperties();
                }
                Properties.StaticRouteExportRoutePolicy = value;
            }
        }

        /// <summary> Export Policy for the BGP Monitoring Protocol (BMP) Configuration. </summary>
        public IList<BmpExportPolicy> ExportPolicies
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new L3IsolationDomainPatchProperties();
                }
                return Properties.ExportPolicies;
            }
        }
    }
}
