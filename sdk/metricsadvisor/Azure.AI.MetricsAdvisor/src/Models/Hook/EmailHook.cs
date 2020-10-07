// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("EmailHookInfo")]
    [CodeGenSuppress(nameof(EmailHook), typeof(string), typeof(EmailHookParameter))]
    public partial class EmailHook : AlertingHook
    {
        /// <summary>
        /// </summary>
        public EmailHook(string name, IList<string> emailsToAlert)
            : base(name)
        {
            Argument.AssertNotNull(emailsToAlert, nameof(emailsToAlert));

            HookParameter = new EmailHookParameter(emailsToAlert);
            HookType = HookType.Email;
        }

        internal EmailHook(HookType hookType, string id, string name, string description, string externalLink, IReadOnlyList<string> administrators, EmailHookParameter hookParameter)
            : base(hookType, id, name, description, externalLink, administrators)
        {
            HookParameter = hookParameter;
            HookType = hookType;
        }

        /// <summary>
        /// </summary>
        public IList<string> EmailsToAlert => HookParameter.ToList;

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal EmailHookParameter HookParameter { get; }
    }
}
