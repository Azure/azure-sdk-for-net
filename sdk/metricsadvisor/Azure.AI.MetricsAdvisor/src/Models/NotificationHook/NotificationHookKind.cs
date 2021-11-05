// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The <see cref="NotificationHookKind"/>. See each specific kind for a description of each.
    /// </summary>
    [CodeGenModel("HookType")]
    public readonly partial struct NotificationHookKind
    {
        /// <summary>
        /// A web hook is the entry point for all the information available from the Metrics Advisor service, and calls a
        /// user-provided API when an alert is triggered.
        /// </summary>
        public static NotificationHookKind Webhook { get; } = new NotificationHookKind(WebhookValue);

        /// <summary>
        /// An email hook is the channel for anomaly alerts to be sent to user-provided email addresses.
        /// </summary>
        public static NotificationHookKind Email { get; } = new NotificationHookKind(EmailValue);
    }
}
