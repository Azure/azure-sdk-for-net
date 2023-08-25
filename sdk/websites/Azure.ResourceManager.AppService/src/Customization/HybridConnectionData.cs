// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService
{
    public partial class HybridConnectionData
    {
        /// <summary> The ARM URI to the Service Bus relay. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release, please use `RelayArmId` instead", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri RelayArmUri { get; set; }
    }
}
