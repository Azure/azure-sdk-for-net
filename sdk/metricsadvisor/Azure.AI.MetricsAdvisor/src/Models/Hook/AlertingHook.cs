// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("HookInfo")]
    public partial class AlertingHook
    {
        internal AlertingHook(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// </summary>
        [CodeGenMember("HookId")]
        public string Id { get; internal set; }

        /// <summary>
        /// </summary>
        [CodeGenMember("HookName")]
        public string Name { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("Admins")]
        public IReadOnlyList<string> Administrators { get; }

        internal static HookInfoPatch GetPatchModel(AlertingHook hook)
        {
            return hook switch
            {
                EmailHook h => new EmailHookInfoPatch() { HookName = h.Name, Description = h.Description, ExternalLink = h.ExternalLink, HookParameter = h.HookParameter, Admins = h.Administrators },
                WebHook h => new WebhookHookInfoPatch() { HookName = h.Name, Description = h.Description, ExternalLink = h.ExternalLink, HookParameter = h.HookParameter, Admins = h.Administrators },
                _ => throw new InvalidOperationException("Unknown AlertingHook type.")
            };
        }
    }
}
