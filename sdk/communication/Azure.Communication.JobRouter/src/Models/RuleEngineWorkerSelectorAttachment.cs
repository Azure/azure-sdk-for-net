// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class RuleEngineWorkerSelectorAttachment
    {
        /// <summary> Initializes a new instance of RuleEngineWorkerSelectorAttachment. </summary>
        /// <param name="rule">
        /// A rule of one of the following types:
        ///
        /// StaticRule:  A rule
        /// providing static rules that always return the same result, regardless of
        /// input.
        /// DirectMapRule:  A rule that return the same labels as the input
        /// labels.
        /// ExpressionRule: A rule providing inline expression
        /// rules.
        /// FunctionRule: A rule providing a binding to an HTTP Triggered Azure
        /// Function.
        /// WebhookRule: A rule providing a binding to a webserver following
        /// OAuth2.0 authentication protocol.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="rule"/> is null. </exception>
        public RuleEngineWorkerSelectorAttachment(RouterRule rule)
        {
            Argument.AssertNotNull(rule, nameof(rule));

            Kind = WorkerSelectorAttachmentKind.RuleEngine;
            Rule = rule;
        }
    }
}
