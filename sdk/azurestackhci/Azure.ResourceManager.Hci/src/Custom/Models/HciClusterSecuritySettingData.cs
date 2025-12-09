// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Hci
{
    // Because of breaking changes in autogen, we need to add this property manually.
    public partial class HciClusterSecuritySettingData
    {
        /// <summary> The status of the last operation. </summary>
        [WirePath("properties.provisioningState")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HciProvisioningState? ProvisioningState { get; set; }
    }
}
