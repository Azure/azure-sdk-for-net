// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// A web hook is a notification channel that uses an endpoint provided by the customer. In order to be
    /// notified when an alert is fired, you must create a <see cref="WebNotificationHook"/> and pass its
    /// ID to an <see cref="AnomalyAlertConfiguration"/>. Check the <see href="https://aka.ms/metricsadvisor/webhook">
    /// documentation</see> for more details about the alerts sent.
    /// </summary>
    /// <remarks>
    /// In order to create a web hook, you must pass this instance to the method
    /// <see cref="MetricsAdvisorAdministrationClient.CreateHookAsync"/>. When a web hook is created or modified,
    /// the <see cref="Endpoint"/> will be called as a test with an empty request body. Your API needs to return
    /// a 200 HTTP code to successfully pass the validation.
    /// </remarks>
    [CodeGenModel("WebhookHookInfo")]
    [CodeGenSuppress(nameof(WebNotificationHook), typeof(string), typeof(WebhookHookParameter))]
    public partial class WebNotificationHook : NotificationHook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebNotificationHook"/> class.
        /// </summary>
        /// <param name="name">The name of the hook.</param>
        /// <param name="endpoint">The API address to be called when an alert is triggered.</param>
        public WebNotificationHook(string name, Uri endpoint) : base(name)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            Endpoint = endpoint;
            HookKind = NotificationHookKind.Webhook;
            Headers = new ChangeTrackingDictionary<string, string>();
        }

        internal WebNotificationHook(NotificationHookKind hookType, string id, string name, string description, string externalLink, IList<string> administrators, WebhookHookParameter hookParameter)
            : base(hookType, id, name, description, externalLink, administrators)
        {
            HookKind = hookType;
            Endpoint = new Uri(hookParameter.Endpoint);
            Username = hookParameter.Username;
            Password = hookParameter.Password;
            CertificateKey = hookParameter.CertificateKey;
            CertificatePassword = hookParameter.CertificatePassword;
            Headers = hookParameter.Headers;
        }

        /// <summary>
        /// The API address to be called when an alert is triggered.
        /// </summary>
        public Uri Endpoint { get; set; }

        /// <summary>
        /// The username for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// Defaults to an empty string.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public string Username { get; set; }

        /// <summary>
        /// The password for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// Defaults to an empty string.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public string Password { get; set; }

        /// <summary>
        /// The certificate key for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// Defaults to an empty string.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public string CertificateKey { get; set; }

        /// <summary>
        /// The certificate password for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// Defaults to an empty string.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public string CertificatePassword { get; set; }

        /// <summary>
        /// Custom headers to send in the API call.
        /// </summary>
        public IDictionary<string, string> Headers { get; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal WebhookHookParameter HookParameter => new WebhookHookParameter(Endpoint.AbsoluteUri)
        {
            Username = Username,
            Password = Password,
            CertificateKey = CertificateKey,
            CertificatePassword = CertificatePassword,
            Headers = Headers
        };
    }
}
