// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    /// <summary>
    /// A class representing the NotificationHubAuthorizationRule data model.
    /// Description of a Namespace AuthorizationRules.
    /// </summary>
    public partial class NotificationHubAuthorizationRuleData : TrackedResourceData
    {
        /// <summary> The sku of the created namespace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NotificationHubSku Sku { get; set; }
    }
}
