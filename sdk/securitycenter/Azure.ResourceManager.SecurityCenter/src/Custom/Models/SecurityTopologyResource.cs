// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
    /// <summary>
    /// Provides a compatibility shim for the SecurityTopologyResource class.
    /// </summary>
    public partial class SecurityTopologyResource : ResourceData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityTopologyResource"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityTopologyResource() { }

        internal SecurityTopologyResource(SecurityTopologyResourceData data) : base(data?.Id, data?.Name, data?.ResourceType ?? default, data?.SystemData)
        {
            Location = data?.Location;
            CalculatedOn = data?.CalculatedOn;
            TopologyResources = data?.TopologyResources;
        }

        /// <summary> Location where the resource is stored. </summary>
        public AzureLocation? Location { get; }

        /// <summary> The UTC time on which the topology was calculated. </summary>
        public DateTimeOffset? CalculatedOn { get; }

        /// <summary> Azure resources which are part of this topology resource. </summary>
        public IReadOnlyList<TopologySingleResource> TopologyResources { get; }
    }
}
