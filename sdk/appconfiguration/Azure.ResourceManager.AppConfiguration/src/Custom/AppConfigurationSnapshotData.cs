// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.AppConfiguration
{
    public partial class AppConfigurationSnapshotData
    {
        /// <summary> The type of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public string SnapshotType => ResourceType.ToString();
    }
}
