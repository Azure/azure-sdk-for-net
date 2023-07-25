﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for updating classification policy.
    /// </summary>
    public class UpdateClassificationPolicyOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="classificationPolicyId"> The id of this policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        public UpdateClassificationPolicyOptions(string classificationPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            ClassificationPolicyId = classificationPolicyId;
        }

        /// <summary>
        /// Unique key that identifies this policy.
        /// </summary>
        public string ClassificationPolicyId { get; }

        /// <summary> Friendly name of this policy. </summary>
        public string Name { get; set; }

        /// <summary> The fallback queue to select if the queue selector does not find a match. </summary>
        public string FallbackQueueId { get; set; }

        /// <summary>
        /// A rule of one of the following types:
        ///
        /// StaticRule:  A rule providing static rules that always return the same result, regardless of input.
        /// DirectMapRule:  A rule that return the same labels as the input labels.
        /// ExpressionRule: A rule providing inline expression rules.
        /// AzureFunctionRule: A rule providing a binding to an HTTP Triggered Azure Function.
        /// </summary>
        public RouterRule PrioritizationRule { get; set; }

        /// <summary> The queue selectors to resolve a queue for a given job. </summary>
        public List<QueueSelectorAttachment> QueueSelectors { get; } = new List<QueueSelectorAttachment>();

        /// <summary> The worker label selectors to attach to a given job. </summary>
        public List<WorkerSelectorAttachment> WorkerSelectors { get; } = new List<WorkerSelectorAttachment>();
    }
}
