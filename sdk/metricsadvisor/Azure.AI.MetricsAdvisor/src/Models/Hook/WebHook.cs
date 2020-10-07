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
        /// <summary>
        /// </summary>
        public WebHook(string name, string endpoint)
            : base(name)
        {
            Argument.AssertNotNullOrEmpty(endpoint, nameof(endpoint));

            HookParameter = new WebhookHookParameter(endpoint, default, default, new ChangeTrackingDictionary<string, string>(), default, default);

            HookType = HookType.Webhook;
        }

        internal WebHook(HookType hookType, string id, string name, string description, string externalLink, IReadOnlyList<string> administrators, WebhookHookParameter hookParameter)
            : base(hookType, id, name, description, externalLink, administrators)
        {
            HookParameter = hookParameter;
            HookType = hookType;
        }

        /// <summary>
        /// </summary>
        public string Endpoint { get => HookParameter.Endpoint; }

        /// <summary>
        /// </summary>
        public string Username { get => HookParameter.Username; set => HookParameter.Username = value; }

        /// <summary>
        /// </summary>
        public string Password { get => HookParameter.Password; set => HookParameter.Password = value; }

        /// <summary>
        /// </summary>
        public string CertificateKey { get => HookParameter.CertificateKey; set => HookParameter.CertificateKey = value; }

        /// <summary>
        /// </summary>
        public string CertificatePassword { get => HookParameter.Username; set => HookParameter.Username = value; }

        /// <summary>
        /// </summary>
        public IDictionary<string, string> Headers
        {
            get => HookParameter.Headers;
            set
            {
                Argument.AssertNotNull(value, nameof(Headers));
                HookParameter.Headers = value;
            }
        }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal WebhookHookParameter HookParameter { get; private set; }
    }
}
