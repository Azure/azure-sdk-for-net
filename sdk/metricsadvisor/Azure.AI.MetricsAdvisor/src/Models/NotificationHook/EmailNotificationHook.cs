// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// An email hook is the channel for anomaly alerts to be sent to email addresses specified in the Email to section.
    /// Two types of alert emails will be sent: Data feed not available alerts, and Incident reports which contain one or multiple anomalies.
    /// </summary>
    [CodeGenModel("EmailHookInfo")]
    [CodeGenSuppress(nameof(EmailNotificationHook), typeof(string))]
    public partial class EmailNotificationHook : NotificationHook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotificationHook"/> class.
        /// </summary>
        public EmailNotificationHook()
        {
            HookType = HookType.Email;
            EmailsToAlert = new ChangeTrackingList<string>();
        }

        internal EmailNotificationHook(HookType hookType, string id, string name, string description, string externalLink, IReadOnlyList<string> administrators, EmailHookParameter hookParameter)
            : base(hookType, id, name, description, externalLink, administrators)
        {
            HookType = hookType;
            EmailsToAlert = hookParameter.ToList;
        }

        /// <summary>
        /// The list of e-mail addresses to alert.
        /// </summary>
        public IList<string> EmailsToAlert { get; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal EmailHookParameter HookParameter => new EmailHookParameter(EmailsToAlert);
    }
}
