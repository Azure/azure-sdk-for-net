// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A web hook is the entry point for all the information available from the Metrics Advisor service, and calls a user-provided API when an alert is triggered.
    /// All alerts can be sent through a web hook.
    /// </summary>
    [CodeGenModel("WebhookHookInfo")]
    [CodeGenSuppress(nameof(WebNotificationHook), typeof(string), typeof(WebhookHookParameter))]
    public partial class WebNotificationHook : NotificationHook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebNotificationHook"/> class.
        /// <param name="name">The name to assign to the hook.</param>
        /// <param name="endpoint">The API address to be called when an alert is triggered.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="endpoint"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="endpoint"/> is empty.</exception>
        /// </summary>
        public WebNotificationHook(string name, string endpoint)
            : base(name)
        {
            Argument.AssertNotNullOrEmpty(endpoint, nameof(endpoint));

            HookParameter = new WebhookHookParameter(endpoint, default, default, new ChangeTrackingDictionary<string, string>(), default, default);

            HookType = HookType.Webhook;
        }

        internal WebNotificationHook(HookType hookType, string id, string name, string description, string externalLink, IReadOnlyList<string> administrators, WebhookHookParameter hookParameter)
            : base(hookType, id, name, description, externalLink, administrators)
        {
            HookParameter = hookParameter;
            HookType = hookType;
        }

        /// <summary>
        /// The API address to be called when an alert is triggered.
        /// </summary>
        public string Endpoint { get => HookParameter.Endpoint; }

        /// <summary>
        /// The username for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// </summary>
        public string Username { get => HookParameter.Username; set => HookParameter.Username = value; }

        /// <summary>
        /// The password for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// </summary>
        public string Password { get => HookParameter.Password; set => HookParameter.Password = value; }

        /// <summary>
        /// The certificate key for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// </summary>
        public string CertificateKey { get => HookParameter.CertificateKey; set => HookParameter.CertificateKey = value; }

        /// <summary>
        /// The certificate password for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// </summary>
        public string CertificatePassword { get => HookParameter.CertificatePassword; set => HookParameter.CertificatePassword = value; }

        /// <summary>
        /// Custom headers to send in the API call.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value assigned to <see cref="Headers"/> is null.</exception>
#pragma warning disable CA2227 // Collection properties should be readonly
        public IDictionary<string, string> Headers
        {
            get => HookParameter.Headers;
            set
            {
                Argument.AssertNotNull(value, nameof(Headers));
                HookParameter.Headers = value;
            }
        }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal WebhookHookParameter HookParameter { get; private set; }
    }
}
