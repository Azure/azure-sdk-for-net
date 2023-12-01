// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ExceptionRule")]
    public partial class ExceptionRule : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of ExceptionRule. </summary>
        /// <param name="trigger"> The trigger for this exception rule. </param>
        /// <param name="actions"> A dictionary collection of actions to perform once the exception is triggered. Key is the Id of each exception action. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="trigger"/> or <paramref name="actions"/> is null. </exception>
        public ExceptionRule(ExceptionTrigger trigger, IDictionary<string, ExceptionAction?> actions)
        {
            Trigger = trigger ?? throw new ArgumentNullException(nameof(trigger));
            Actions = actions ?? throw new ArgumentNullException(nameof(actions));
        }

        /// <summary> A dictionary collection of actions to perform once the exception is triggered. Key is the Id of each exception action. </summary>
        public IDictionary<string, ExceptionAction?> Actions { get; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("trigger"u8);
            writer.WriteObjectValue(Trigger);
            writer.WritePropertyName("actions"u8);
            writer.WriteStartObject();
            foreach (var item in Actions)
            {
                writer.WritePropertyName(item.Key);
#pragma warning disable CS8604 // Null requires to be sent as payload as well
                writer.WriteObjectValue(item.Value);
#pragma warning restore CS8604
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
