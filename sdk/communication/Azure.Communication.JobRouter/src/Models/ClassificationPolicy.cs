// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ClassificationPolicy : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of ClassificationPolicy. </summary>
        /// <param name="classificationPolicyId"> Id of a classification policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        public ClassificationPolicy(string classificationPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            Id = classificationPolicyId;
        }

        /// <summary> Queue selector attachments used to resolve a queue for a job. </summary>
        public IList<QueueSelectorAttachment> QueueSelectorAttachments { get; } = new List<QueueSelectorAttachment>();

        /// <summary> Worker selector attachments used to attach worker selectors to a job. </summary>
        public IList<WorkerSelectorAttachment> WorkerSelectorAttachments { get; } = new List<WorkerSelectorAttachment>();

        /// <summary> Friendly name of this policy. </summary>
        public string Name { get; set; }

        /// <summary> Id of a fallback queue to select if queue selector attachments doesn't find a match. </summary>
        public string FallbackQueueId { get; set; }

        /// <summary>
        /// A rule to determine a priority score for a job.
        /// </summary>
        public RouterRule PrioritizationRule { get; set; }

        /// <summary> The entity tag for this resource. </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
