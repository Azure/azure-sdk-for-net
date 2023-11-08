// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ClassificationPolicy: IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of ClassificationPolicy. </summary>
        /// <param name="classificationPolicyId"> Id of the policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        public ClassificationPolicy(string classificationPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            Id = classificationPolicyId;
        }

        /// <summary> The queue selector attachments used to resolve a queue for a given job. </summary>
        public IList<QueueSelectorAttachment> QueueSelectorAttachments { get; } = new List<QueueSelectorAttachment>();

        /// <summary> The worker selector attachments used to attach worker selectors to a given job. </summary>
        public IList<WorkerSelectorAttachment> WorkerSelectorAttachments { get; } = new List<WorkerSelectorAttachment>();

        /// <summary> (Optional) The name of the classification policy. </summary>
        public string Name { get; set; }

        /// <summary> The fallback queue to select if the queue selector attachments fail to resolve a queue for a given job. </summary>
        public string FallbackQueueId { get; set; }

        /// <summary>
        /// A rule of one of the following types:
        ///
        /// StaticRule:  A rule providing static rules that always return the same result, regardless of input.
        /// DirectMapRule:  A rule that return the same labels as the input labels.
        /// ExpressionRule: A rule providing inline expression rules.
        /// AzureFunctionRule: A rule providing a binding to an HTTP Triggered Azure Function.
        /// WebhookRule: A rule providing a binding to a webserver following OAuth2.0 authentication protocol.
        /// Please note <see cref="RouterRule"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="FunctionRouterRule"/>, <see cref="DirectMapRouterRule"/>, <see cref="ExpressionRouterRule"/>, <see cref="StaticRouterRule"/> and <see cref="WebhookRouterRule"/>.
        /// </summary>
        public RouterRule PrioritizationRule { get; set; }

        [CodeGenMember("Etag")]
        internal string _etag
        {
            get
            {
                return ETag.ToString();
            }
            set
            {
                ETag = new ETag(value);
            }
        }

        /// <summary> Concurrency Token. </summary>
        public ETag ETag { get; internal set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(FallbackQueueId))
            {
                writer.WritePropertyName("fallbackQueueId"u8);
                writer.WriteStringValue(FallbackQueueId);
            }
            if (Optional.IsCollectionDefined(QueueSelectorAttachments))
            {
                writer.WritePropertyName("queueSelectorAttachments"u8);
                writer.WriteStartArray();
                foreach (var item in QueueSelectorAttachments)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PrioritizationRule))
            {
                writer.WritePropertyName("prioritizationRule"u8);
                writer.WriteObjectValue(PrioritizationRule);
            }
            if (Optional.IsCollectionDefined(WorkerSelectorAttachments))
            {
                writer.WritePropertyName("workerSelectorAttachments"u8);
                writer.WriteStartArray();
                foreach (var item in WorkerSelectorAttachments)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(ETag.ToString());
            }
            writer.WriteEndObject();
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
