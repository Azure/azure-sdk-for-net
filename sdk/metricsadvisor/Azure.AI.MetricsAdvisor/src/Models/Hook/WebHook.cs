// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("WebhookHookInfo")]
    [CodeGenSuppress(nameof(WebHook), typeof(string), typeof(WebhookHookParameter))]
    public partial class WebHook : AlertingHook
    {
        private IDictionary<string, string> _headers;

        /// <summary>
        /// </summary>
        public WebHook(string name, string endpoint)
            : base(name)
        {
            Argument.AssertNotNullOrEmpty(endpoint, nameof(endpoint));

            Endpoint = endpoint;
            Headers = new ChangeTrackingDictionary<string, string>();
            HookType = HookType.Webhook;
        }

        internal WebHook(HookType hookType, string id, string name, string description, string externalLink, IReadOnlyList<string> administrators, WebhookHookParameter hookParameter)
            : base(hookType, id, name, description, externalLink, administrators)
        {
            Endpoint = hookParameter.Endpoint;
            Username = hookParameter.Username;
            Password = hookParameter.Password;
            CertificateKey = hookParameter.CertificateKey;
            CertificatePassword = hookParameter.CertificatePassword;
            Headers = hookParameter.Headers;
            HookType = hookType;
        }

        /// <summary>
        /// </summary>
        public string Endpoint { get; }

        /// <summary>
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// </summary>
        public string CertificateKey { get; set; }

        /// <summary>
        /// </summary>
        public string CertificatePassword { get; set; }

        /// <summary>
        /// </summary>
        public IDictionary<string, string> Headers
        {
            get => _headers;
            set
            {
                Argument.AssertNotNull(value, nameof(Headers));
                _headers = value;
            }
        }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal WebhookHookParameter HookParameter => new WebhookHookParameter(Endpoint, Username, Password, Headers, CertificateKey, CertificatePassword);
    }
}
