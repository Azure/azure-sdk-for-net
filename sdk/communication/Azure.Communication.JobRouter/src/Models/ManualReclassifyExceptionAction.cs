// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ManualReclassifyExceptionAction")]
    [CodeGenSuppress("ManualReclassifyExceptionAction")]
    [CodeGenSuppress("ManualReclassifyExceptionAction", typeof(string))]
    public partial class ManualReclassifyExceptionAction : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of ManualReclassifyExceptionAction. </summary>
        public ManualReclassifyExceptionAction() : this(null, null, null, Array.Empty<RouterWorkerSelector>().ToList())
        {
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
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
