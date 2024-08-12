// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ConditionalWorkerSelectorAttachment
    {
        /// <summary> Initializes a new instance of ConditionalWorkerSelectorAttachment. </summary>
        /// <param name="condition">
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
        public ConditionalWorkerSelectorAttachment(RouterRule condition)
        {
            Argument.AssertNotNull(condition, nameof(condition));

            Kind = WorkerSelectorAttachmentKind.Conditional;
            Condition = condition;
        }

        /// <summary> The queue selectors to attach. </summary>
        public IList<RouterWorkerSelector> WorkerSelectors { get; } = new List<RouterWorkerSelector>();
    }
}
