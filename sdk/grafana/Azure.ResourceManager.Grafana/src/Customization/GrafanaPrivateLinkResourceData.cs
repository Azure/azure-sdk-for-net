// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Grafana.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Grafana
{
    /// <summary>
    /// A class representing the GrafanaPrivateLinkResource data model.
    /// A private link resource
    /// </summary>
    public partial class GrafanaPrivateLinkResourceData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="GrafanaPrivateLinkResourceData"/>. </summary>
        public GrafanaPrivateLinkResourceData()
        {
            RequiredMembers = new ChangeTrackingList<string>();
            RequiredZoneNames = new ChangeTrackingList<string>();
        }
        /// <summary> The private link resource required member names. </summary>
        public IReadOnlyList<string> RequiredMembers { get; }
        /// <summary> The private link resource Private link DNS zone name. </summary>
        public IList<string> RequiredZoneNames { get; }
    }
}
