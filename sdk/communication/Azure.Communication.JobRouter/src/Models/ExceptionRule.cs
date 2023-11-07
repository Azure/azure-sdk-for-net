// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ExceptionRule : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of ExceptionRule. </summary>
        /// <param name="id"> Id of the exception rule. </param>
        /// <param name="trigger"> The trigger for this exception rule. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="trigger"/>. </exception>
        public ExceptionRule(string id, ExceptionTrigger trigger)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Trigger = trigger ?? throw new ArgumentNullException(nameof(trigger));
        }

        /// <summary> A dictionary collection of actions to perform once the exception is triggered. Key is the Id of each exception action. </summary>
        public IList<ExceptionAction> Actions { get; } = new List<ExceptionAction>();

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("trigger"u8);
            writer.WriteObjectValue(Trigger);
            writer.WritePropertyName("actions"u8);
            writer.WriteStartArray();
            foreach (var item in Actions)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
