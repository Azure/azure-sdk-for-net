// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class HciClusterDeploymentInfo
    {
        /// <summary> Storage configuration mode. </summary>
        [Obsolete("This property is no longer supported in the current API version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("storage.configurationMode")]
        public string StorageConfigurationMode { get; set; }
    }
}
