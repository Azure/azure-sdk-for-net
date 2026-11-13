// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    // Backward-compat: override AuthorizationRules from IReadOnlyList<T> to IList<T>
    // to match the baseline API contract.
    public partial class NotificationHubData
    {
        /// <summary> The AuthorizationRules of the created NotificationHub. </summary>
        public IList<SharedAccessAuthorizationRuleProperties> AuthorizationRules
        {
            get
            {
                if (Properties is null)
                    Properties = new NotificationHubProperties();
                return Properties.AuthorizationRules as IList<SharedAccessAuthorizationRuleProperties>;
            }
        }
    }
}
