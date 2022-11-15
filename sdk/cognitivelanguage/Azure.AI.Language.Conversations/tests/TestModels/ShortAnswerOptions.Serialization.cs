// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ShortAnswerOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("enable");
            writer.WriteBooleanValue(Enable);
            if (Optional.IsDefined(ConfidenceThreshold))
            {
                writer.WritePropertyName("confidenceScoreThreshold");
                writer.WriteNumberValue(ConfidenceThreshold.Value);
            }
            if (Optional.IsDefined(Top))
            {
                writer.WritePropertyName("topAnswersWithSpan");
                writer.WriteNumberValue(Top.Value);
            }
            writer.WriteEndObject();
        }
    }
}
