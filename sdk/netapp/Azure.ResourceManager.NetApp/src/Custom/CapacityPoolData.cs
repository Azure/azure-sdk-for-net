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

        /// <summary> If enabled (true) the pool can contain cool Access enabled volumes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsCoolAccessEnabled
        {
            get => Properties?.IsCoolAccessEnabled;
            set
            {
                if (Properties is null)
                    Properties = new PoolProperties();
                Properties.IsCoolAccessEnabled = value;
            }
        }
    }
}
