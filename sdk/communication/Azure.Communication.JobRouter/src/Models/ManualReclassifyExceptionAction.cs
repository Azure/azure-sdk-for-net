// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ManualReclassifyExceptionAction : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of ManualReclassifyExceptionAction. </summary>
        public ManualReclassifyExceptionAction()
        {
            Kind = "manual-reclassify";
        }

        /// <summary> Updated QueueId. </summary>
        public string QueueId { get; set; }

        /// <summary> Updated Priority. </summary>
        public int? Priority { get; set; }

        /// <summary> Updated WorkerSelectors. </summary>
        public IList<RouterWorkerSelector> WorkerSelectors { get; } = new List<RouterWorkerSelector>();

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(QueueId))
            {
                writer.WritePropertyName("queueId"u8);
                writer.WriteStringValue(QueueId);
            }
            if (Optional.IsDefined(Priority))
            {
                writer.WritePropertyName("priority"u8);
                writer.WriteNumberValue(Priority.Value);
            }
            if (Optional.IsCollectionDefined(WorkerSelectors))
            {
                writer.WritePropertyName("workerSelectors"u8);
                writer.WriteStartArray();
                foreach (var item in WorkerSelectors)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
