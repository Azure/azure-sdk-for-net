// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    // Backward-compat: Sku property existed in baseline but is not in the spec.
    // Required by ApiCompat.
    public partial class NotificationHubPnsCredentials
    {
        /// <summary> The sku of the created namespace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NotificationHubSku Sku { get; set; }
    }
}
