// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Qumulo.Models
{
    [CodeGenSerialization(nameof(ClusterLoginUri), "clusterLoginUri")]
    [CodeGenSerialization(nameof(PrivateIPs), "privateIPs")]
    public partial class FileSystemResourceUpdateProperties
    {
        /// <summary>
        /// File system Id of the resource.
        /// This property has been removed since api-version 2024-06-19
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri ClusterLoginUri { get; set; }

        /// <summary>
        /// Private IPs of the resource.
        /// This property has been removed since api-version 2024-06-19
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> PrivateIPs { get; }
    }
}
