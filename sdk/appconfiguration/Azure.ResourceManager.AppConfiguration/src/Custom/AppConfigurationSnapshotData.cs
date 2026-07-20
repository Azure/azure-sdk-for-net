// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.AppConfiguration.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppConfiguration
{
    // add back a removed property due to generator update
    // Suppress generation of the internal parameterless deserialization constructor so it
    // doesn't conflict with the public obsolete compatibility constructor defined below.
    [CodeGenSuppress("AppConfigurationSnapshotData")]
    public partial class AppConfigurationSnapshotData
    {
        /// <summary> The type of the resource. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public string SnapshotType => ResourceType.ToString();

        // The 2025-08-01-preview spec update made `filters` a required constructor argument.
        // This parameterless constructor is kept as a compatibility shim so existing callers
        // don't get a breaking change; it initializes an empty filter list.
        /// <summary> Initializes a new instance of <see cref="AppConfigurationSnapshotData"/>. </summary>
        /// <remarks> This constructor is deprecated and it will be removed in a future version. Please use <see cref="AppConfigurationSnapshotData(IEnumerable{SnapshotKeyValueFilter})"/> instead. </remarks>
        [Obsolete("This constructor is deprecated and it will be removed in a future version. Please use AppConfigurationSnapshotData(IEnumerable<SnapshotKeyValueFilter> filters) instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AppConfigurationSnapshotData() : this(new List<SnapshotKeyValueFilter>())
        {
        }
    }
}
