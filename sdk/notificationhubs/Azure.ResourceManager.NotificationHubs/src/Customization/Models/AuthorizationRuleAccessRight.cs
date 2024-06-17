// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    /// <summary> The AuthorizationRuleAccessRight. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AuthorizationRuleAccessRight
    {
        /// <summary> Manage. </summary>
        Manage,
        /// <summary> Send. </summary>
        Send,
        /// <summary> Listen. </summary>
        Listen
    }
}
