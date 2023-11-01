// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class PassThroughQueueSelectorAttachment : IUtf8JsonSerializable
    {
        /// <summary> Describes how the value of the label is compared to the value pass through. </summary>
        public LabelOperator LabelOperator { get; internal set; }

        /// <summary> Initializes a new instance of PassThroughQueueSelectorAttachment. </summary>
        /// <param name="key"> The label key to query against. </param>
        /// <param name="labelOperator"> Describes how the value of the label is compared to the value pass through. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public PassThroughQueueSelectorAttachment(string key, LabelOperator labelOperator): this("pass-through", key, labelOperator)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));
            Argument.AssertNotNull(labelOperator, nameof(labelOperator));
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("key"u8);
            writer.WriteStringValue(Key);
            writer.WritePropertyName("labelOperator"u8);
            writer.WriteStringValue(LabelOperator.ToString());
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
