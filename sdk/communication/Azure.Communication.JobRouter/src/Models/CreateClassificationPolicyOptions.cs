// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating classification policy.
    /// </summary>
    public class CreateClassificationPolicyOptions
    {
        /// <summary>
        /// Initializes a new instance of CreateClassificationPolicyOptions.
        /// </summary>
        /// <param name="classificationPolicyId"> Id of a classification policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        public CreateClassificationPolicyOptions(string classificationPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            ClassificationPolicyId = classificationPolicyId;
        }

        /// <summary>
        /// Id of a classification policy.
        /// </summary>
        public string ClassificationPolicyId { get; }

        /// <summary> Friendly name of this policy. </summary>
        public string Name { get; set; }

        /// <summary> Id of a fallback queue to select if queue selector attachments doesn't find a match. </summary>
        public string FallbackQueueId { get; set; }

        /// <summary>
        /// A rule to determine a priority score for a job.
        /// </summary>
        public RouterRule PrioritizationRule { get; set; }

        /// <summary> Queue selector attachments used to resolve a queue for a job. </summary>
        public IList<QueueSelectorAttachment> QueueSelectorAttachments { get; } = new List<QueueSelectorAttachment>();

        /// <summary> Worker selector attachments used to attach worker selectors to a job. </summary>
        public IList<WorkerSelectorAttachment> WorkerSelectorAttachments { get; } = new List<WorkerSelectorAttachment>();

        /// <summary>
        /// The content to send as the request conditions of the request.
        /// </summary>
        public RequestConditions RequestConditions { get; set; } = new();
    }
}
