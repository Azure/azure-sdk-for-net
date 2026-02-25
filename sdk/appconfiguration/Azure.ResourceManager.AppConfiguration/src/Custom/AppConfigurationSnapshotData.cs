// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.AppConfiguration
{
    // add back a removed property due to generator update
    public partial class AppConfigurationSnapshotData
    {
        /// <summary> The type of the resource. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public string SnapshotType => ResourceType.ToString();
    }
}
