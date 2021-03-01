// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// An alert notification to be triggered after an anomaly is detected by Metrics Advisor.
    /// </summary>
    [CodeGenModel("HookInfo")]
    [CodeGenSuppress(nameof(NotificationHook), typeof(string))]
    public partial class NotificationHook
    {
        internal NotificationHook()
        {
        }

        /// <summary>
        /// The unique identifier for the hook.
        /// </summary>
        [CodeGenMember("HookId")]
        public string Id { get; }

        /// <summary>
        /// The name of the hook.
        /// </summary>
        [CodeGenMember("HookName")]
        public string Name { get; set; }

        /// <summary>
        /// The list of user e-mails with administrative rights to manage this hook.
        /// </summary>
        [CodeGenMember("Admins")]
        public IReadOnlyList<string> Administrators { get; }

        /// <summary> The hook type. </summary>
        internal HookType HookType { get; set; }

        /// <summary> The hook description. </summary>
        public string Description { get; set; }

        /// <summary> Optional field which enables a customized redirect, such as for troubleshooting notes. </summary>
        public string ExternalLink { get; set; }

        internal static HookInfoPatch GetPatchModel(NotificationHook hook)
        {
            return hook switch
            {
                EmailNotificationHook h => new EmailHookInfoPatch() { HookName = h.Name, Description = h.Description, ExternalLink = h.ExternalLink, HookParameter = h.HookParameter, Admins = h.Administrators },
                WebNotificationHook h => new WebhookHookInfoPatch() { HookName = h.Name, Description = h.Description, ExternalLink = h.ExternalLink, HookParameter = h.HookParameter, Admins = h.Administrators },
                _ => throw new InvalidOperationException("Unknown AlertingHook type.")
            };
        }
    }
}
