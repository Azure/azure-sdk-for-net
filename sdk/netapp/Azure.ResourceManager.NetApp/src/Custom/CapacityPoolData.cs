// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A class representing the CapacityPool data model.
    /// Capacity pool resource
    /// </summary>
    public partial class CapacityPoolData : TrackedResourceData
    {
        // Backward-compat: v1.15.0 GA exposed `CustomThroughputMibps` typed as `float?`;
        // the new spec models it as `int?` (see Generated/Models/PoolProperties.cs:
        // `public int? CustomThroughputMibps`). We expose two properties:
        //
        //   - `CustomThroughputMibps` (float?)  — preserves the GA signature (browsable)
        //   - `CustomThroughputMibpsInt` (int?) — exposes the actual underlying type as a
        //                                          new alias (hidden from IntelliSense)
        //
        // Both wrap the same generated property. The float? overload is lossy on write
        // (truncated to int) and returns int → float on read, which matches the GA
        // behavior since the wire value has always been integer-valued. If/when the
        // ApiCompat baseline is bumped past v1.15.0 the float? wrapper can be deleted
        // and we keep only the generated `int?` property surface.
        /// <summary> Maximum throughput in MiB/s that can be achieved by this pool and this will be accepted as input only for manual qosType pool with Flexible service level. </summary>
        public float? CustomThroughputMibps
        {
            get
            {
                return Properties is null ? null : (Properties.CustomThroughputMibps.HasValue ? (float?)Properties.CustomThroughputMibps.Value : null);
            }
            set
            {
                if (Properties is null)
                    Properties = new PoolProperties();
                Properties.CustomThroughputMibps = value.HasValue ? (int)value.Value : null;
            }
        }

        /// <summary> Maximum throughput in MiB/s (integer). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CustomThroughputMibpsInt
        {
            get => Properties?.CustomThroughputMibps;
            set
            {
                if (Properties is null)
                    Properties = new PoolProperties();
                Properties.CustomThroughputMibps = value;
            }
        }
    }
}
