// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class AccountSasContent
    {
        /// <summary> Backward-compatible alias for SharedAccessExpiryOn. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("signedExpiry")]
        public DateTimeOffset SharedAccessExpireOn
        {
            get => SharedAccessExpiryOn;
        }
    }
}
