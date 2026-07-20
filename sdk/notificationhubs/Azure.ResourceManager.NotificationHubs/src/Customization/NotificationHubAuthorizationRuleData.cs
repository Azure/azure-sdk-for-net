// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    // Backward-compat: Sku and Rights properties existed in baseline but are not in the spec.
    // Required by ApiCompat.
    public partial class NotificationHubAuthorizationRuleData
    {
        /// <summary> The sku of the created namespace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NotificationHubSku Sku { get; set; }
        /// <summary> The rights associated with the rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<AuthorizationRuleAccessRight> Rights { get => AccessRights.Select(p => p.ToString().ToAuthorizationRuleAccessRight()).ToList(); }
    }
}
