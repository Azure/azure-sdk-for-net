// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// An email hook is the channel for anomaly alerts to be sent to email addresses specified in the Email to section.
    /// Two types of alert emails will be sent: Data feed not available alerts, and Incident reports which contain one or multiple anomalies.
    /// </summary>
    [CodeGenModel("EmailHookInfo")]
    [CodeGenSuppress(nameof(EmailNotificationHook), typeof(string), typeof(EmailHookParameter))]
    public partial class EmailNotificationHook : NotificationHook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotificationHook"/> class.
        /// <param name="name">The name to assign to the hook.</param>
        /// <param name="emailsToAlert">The list of e-mail addresses to alert.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="emailsToAlert"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        /// </summary>
        public EmailNotificationHook(string name, IList<string> emailsToAlert)
            : base(name)
        {
            Argument.AssertNotNull(emailsToAlert, nameof(emailsToAlert));

            HookParameter = new EmailHookParameter(emailsToAlert);
            HookType = HookType.Email;
        }

        internal EmailNotificationHook(HookType hookType, string id, string name, string description, string externalLink, IReadOnlyList<string> administrators, EmailHookParameter hookParameter)
            : base(hookType, id, name, description, externalLink, administrators)
        {
            HookParameter = hookParameter;
            HookType = hookType;
        }

        /// <summary>
        /// The list of e-mail addresses to alert.
        /// </summary>
        public IList<string> EmailsToAlert => HookParameter.ToList;

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal EmailHookParameter HookParameter { get; }
    }
}
