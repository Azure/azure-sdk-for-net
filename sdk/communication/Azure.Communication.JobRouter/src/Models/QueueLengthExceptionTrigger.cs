// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary> Trigger for an exception action on exceeding queue length. </summary>
    public partial class QueueLengthExceptionTrigger : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of QueueLengthExceptionTrigger. </summary>
        /// <param name="threshold"> Threshold of number of jobs queued to for this trigger. Must be greater than 0</param>
        public QueueLengthExceptionTrigger(int threshold)
            : this(ExceptionTriggerKind.QueueLength, new Dictionary<string, BinaryData>(), threshold)
        {
        }

        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("threshold"u8);
            writer.WriteNumberValue(Threshold);
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToString());
            writer.WriteEndObject();
        }
    }
}
