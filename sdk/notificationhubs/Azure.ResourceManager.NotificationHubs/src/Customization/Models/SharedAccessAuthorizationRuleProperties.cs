// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    /// <summary> SharedAccessAuthorizationRule properties. </summary>
    public partial class SharedAccessAuthorizationRuleProperties
    {
        /// <summary> Initializes a new instance of <see cref="SharedAccessAuthorizationRuleProperties"/>. </summary>
        public SharedAccessAuthorizationRuleProperties()
        {
            AccessRights = new ChangeTrackingList<AuthorizationRuleAccessRightExt>();
        }

        /// <summary> The rights associated with the rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<AuthorizationRuleAccessRight> Rights { get => AccessRights.Select(p => p.ToString().ToAuthorizationRuleAccessRight()).ToList(); }
    }
}
