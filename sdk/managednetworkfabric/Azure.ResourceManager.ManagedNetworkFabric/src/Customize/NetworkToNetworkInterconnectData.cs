// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkToNetworkInterconnectData
    {
        // Backward compatibility shim for the TypeSpec migration. The current generated property
        // is OptionBLayer3Settings and uses the shared OptionBLayer3Configuration model directly.
        /// <summary> Common properties for Layer3Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use OptionBLayer3Settings instead.")]
        public NetworkToNetworkInterconnectOptionBLayer3Configuration OptionBLayer3Configuration
        {
            get => NetworkToNetworkInterconnectOptionBLayer3Configuration.FromOptionBLayer3Configuration(OptionBLayer3Settings);
            set => OptionBLayer3Settings = value;
        }
    }
}
