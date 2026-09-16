// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ServiceBus
{
    public partial class ServiceBusNamespace
    {
        // The TypeSpec provisioning generator models private endpoint connections as child resources.
        // Keep that new resource-based API under a distinct name so the shipped data-model API can coexist.
        /// <summary> Gets or sets the private endpoint connection resources. </summary>
        [CodeGenMember("PrivateEndpointConnections")]
        public BicepList<ServiceBusPrivateEndpointConnection> PrivateEndpointConnectionResources
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new SBNamespaceProperties();
                }
                return Properties.PrivateEndpointConnectionResources;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new SBNamespaceProperties();
                }
                Properties.PrivateEndpointConnectionResources = value;
            }
        }

        // Preserve the old flattened data-model list for callers compiled against Azure.Provisioning.ServiceBus 1.1.0.
        /// <summary>
        /// Gets or sets the private endpoint connection data models.
        /// This compatibility property preserves the previous generated model shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointConnectionResources instead.")]
#pragma warning disable CS0618 // ServiceBusPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
        public BicepList<ServiceBusPrivateEndpointConnectionData> PrivateEndpointConnections
#pragma warning restore CS0618
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new SBNamespaceProperties();
                }
                return Properties.PrivateEndpointConnections;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new SBNamespaceProperties();
                }
                Properties.PrivateEndpointConnections = value;
            }
        }

        public static partial class ResourceVersions
        {
            // Preserve historical API versions that shipped from the reflection-based provisioning generator.
            /// <summary> API version "2014-09-01". </summary>
            public static readonly string V2014_09_01 = "2014-09-01";
            /// <summary> API version "2015-08-01". </summary>
            public static readonly string V2015_08_01 = "2015-08-01";
            /// <summary> API version "2017-04-01". </summary>
            public static readonly string V2017_04_01 = "2017-04-01";
            /// <summary> API version "2021-11-01". </summary>
            public static readonly string V2021_11_01 = "2021-11-01";
            /// <summary> API version "2024-01-01". </summary>
            public static readonly string V2024_01_01 = "2024-01-01";
        }
    }
}
