// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Authorization.Models
{
#pragma warning disable CS0618 // This partial class intentionally exposes obsolete compatibility members.
    public partial class RoleManagementPolicyNotificationRule
    {
        // TypeSpec now generates the contextual property below. Keep the GA property as a
        // hidden wrapper over the same extensible-enum value.
        /// <summary> The type of notification. </summary>
        [WirePath("notificationType")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use RoleManagementNotificationDeliveryType instead.", false)]
        public NotificationDeliveryType? NotificationDeliveryType
        {
            get => RoleManagementNotificationDeliveryType.HasValue
                ? new NotificationDeliveryType(RoleManagementNotificationDeliveryType.Value)
                : default(NotificationDeliveryType?);
            set => RoleManagementNotificationDeliveryType = value.HasValue
                ? value.Value.Value
                : default(RoleManagementNotificationDeliveryType?);
        }

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
#pragma warning restore CS0618
}
