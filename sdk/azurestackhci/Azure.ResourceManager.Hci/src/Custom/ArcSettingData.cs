// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    // Because of breaking changes in autogen, we need to add this property manually.
    public partial class ArcSettingData
    {
        /// <summary> contains connectivity related configuration for ARC resources. </summary>
        [WirePath("properties.connectivityProperties")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData ConnectivityProperties { get; set; }
    }
}
