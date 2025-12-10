// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    // Because of breaking changes in autogen, we need to add this property manually.
    public partial class ArcSettingPatch
    {
        /// <summary> contains connectivity related configuration for ARC resources. </summary>
        [WirePath("properties.connectivityProperties")]
        public BinaryData ConnectivityProperties { get; set; }
    }
}
