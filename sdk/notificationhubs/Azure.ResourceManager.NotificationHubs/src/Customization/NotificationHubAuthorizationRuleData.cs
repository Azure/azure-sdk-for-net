// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Collections.Generic;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NotificationHubs.Models;
using System.Linq;

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
        /// <summary> The rights associated with the rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<AuthorizationRuleAccessRight> Rights { get => AccessRights.Select(p => p.ToString().ToAuthorizationRuleAccessRight()).ToList(); }
    }
}
