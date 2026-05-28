// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// An email hook is the channel for anomaly alerts to be sent to e-mail addresses. In order to be notified when
    /// an alert is fired, you must create an <see cref="EmailNotificationHook"/> and pass its ID to an
    /// <see cref="AnomalyAlertConfiguration"/>.
    /// </summary>
    /// <remarks>
    /// In order to create an e-mail hook, you must add at least one e-mail address to <see cref="EmailsToAlert"/>,
    /// and pass this instance to the method <see cref="MetricsAdvisorAdministrationClient.CreateHookAsync"/>.
    /// </remarks>
    [CodeGenModel("EmailHookInfo")]
    [CodeGenSuppress(nameof(EmailNotificationHook), typeof(string), typeof(EmailHookParameter))]
    public partial class EmailNotificationHook : NotificationHook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotificationHook"/> class.
        /// </summary>
        /// <param name="name">The name of the hook.</param>
        public EmailNotificationHook(string name) : base(name)
        {
            HookKind = NotificationHookKind.Email;
            EmailsToAlert = new ChangeTrackingList<string>();
        }

        internal EmailNotificationHook(NotificationHookKind hookType, string id, string name, string description, string externalLink, IList<string> administrators, EmailHookParameter hookParameter)
            : base(hookType, id, name, description, externalLink, administrators)
        {
            HookKind = hookType;
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
