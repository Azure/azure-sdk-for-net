// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    /// <summary> Description of a NotificationHub PNS Credentials. </summary>
    public partial class NotificationHubPnsCredentials : TrackedResourceData
    {
        /// <summary> The sku of the created namespace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NotificationHubSku Sku { get; set; }
    }
}
