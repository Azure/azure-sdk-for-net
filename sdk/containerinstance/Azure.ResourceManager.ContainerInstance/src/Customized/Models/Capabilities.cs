// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Corrected copy of Generated/Models/Capabilities.cs
// Renamed Capabilities property to SupportedCapabilities to avoid CS0542.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> The regional capabilities. </summary>
    public partial class Capabilities
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="Models.Capabilities"/>. </summary>
        internal Capabilities()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Models.Capabilities"/>. </summary>
        /// <param name="resourceType"> The resource type that this capability describes. </param>
        /// <param name="osType"> The OS type that this capability describes. </param>
        /// <param name="location"> The resource location. </param>
        /// <param name="ipAddressType"> The ip address type that this capability describes. </param>
        /// <param name="gpu"> The GPU sku that this capability describes. </param>
        /// <param name="capabilities"> The supported capabilities. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal Capabilities(string resourceType, string osType, string location, string ipAddressType, string gpu, CapabilitiesCapabilities capabilities, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            ResourceType = resourceType;
            OsType = osType;
            Location = location;
            IpAddressType = ipAddressType;
            Gpu = gpu;
            SupportedCapabilities = capabilities;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The resource type that this capability describes. </summary>
        public string ResourceType { get; }

        /// <summary> The OS type that this capability describes. </summary>
        public string OsType { get; }

        /// <summary> The resource location. </summary>
        public string Location { get; }

        /// <summary> The ip address type that this capability describes. </summary>
        public string IpAddressType { get; }

        /// <summary> The GPU sku that this capability describes. </summary>
        public string Gpu { get; }

        /// <summary> The supported capabilities. </summary>
        public CapabilitiesCapabilities SupportedCapabilities { get; }
    }
}
