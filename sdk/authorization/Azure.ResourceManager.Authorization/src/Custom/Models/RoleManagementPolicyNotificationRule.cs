// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Authorization.Models
{
    public partial class RoleManagementPolicyNotificationRule
    {
        // The generated property uses the reviewed boolean name while this hidden wrapper preserves the shipped GA API.
        /// <summary> Determines if the notification will be sent to the recipient type specified in the policy rule. </summary>
        [WirePath("isDefaultRecipientsEnabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsDefaultRecipientsEnabled instead.")]
        public bool? AreDefaultRecipientsEnabled
        {
            get => IsDefaultRecipientsEnabled;
            set => IsDefaultRecipientsEnabled = value;
        }
    }
}
