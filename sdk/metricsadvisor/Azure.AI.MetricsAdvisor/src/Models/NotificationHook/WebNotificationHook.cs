// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A web hook is the entry point for all the information available from the Metrics Advisor service, and calls a user-provided API when an alert is triggered.
    /// All alerts can be sent through a web hook.
    /// </summary>
    [CodeGenModel("WebhookHookInfo")]
    [CodeGenSuppress(nameof(WebNotificationHook), typeof(string))]
    public partial class WebNotificationHook : NotificationHook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebNotificationHook"/> class.
        /// </summary>
        public WebNotificationHook()
        {
            HookType = HookType.Webhook;
            Headers = new ChangeTrackingDictionary<string, string>();
        }

        internal WebNotificationHook(HookType hookType, string id, string name, string description, string externalLink, IReadOnlyList<string> administrators, WebhookHookParameter hookParameter)
            : base(hookType, id, name, description, externalLink, administrators)
        {
            HookType = hookType;
            Endpoint = hookParameter.Endpoint;
            Username = hookParameter.Username;
            Password = hookParameter.Password;
            CertificateKey = hookParameter.CertificateKey;
            CertificatePassword = hookParameter.CertificatePassword;
            Headers = hookParameter.Headers;
        }

        /// <summary>
        /// The API address to be called when an alert is triggered.
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// The username for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The certificate key for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// </summary>
        public string CertificateKey { get; set; }

        /// <summary>
        /// The certificate password for authenticating to the API address. Leave this blank if authentication isn't needed.
        /// </summary>
        public string CertificatePassword { get; set; }

        /// <summary>
        /// Custom headers to send in the API call.
        /// </summary>
        public IDictionary<string, string> Headers { get; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal WebhookHookParameter HookParameter => new WebhookHookParameter(Endpoint)
        {
            Username = Username,
            Password = Password,
            CertificateKey = CertificateKey,
            CertificatePassword = CertificatePassword,
            Headers = Headers
        };
    }
}
