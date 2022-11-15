// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class AnswersOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(QnaId))
            {
                writer.WritePropertyName("qnaId");
                writer.WriteNumberValue(QnaId.Value);
            }
            if (Optional.IsDefined(Question))
            {
                writer.WritePropertyName("question");
                writer.WriteStringValue(Question);
            }
            if (Optional.IsDefined(Top))
            {
                writer.WritePropertyName("top");
                writer.WriteNumberValue(Top.Value);
            }
            if (Optional.IsDefined(UserId))
            {
                writer.WritePropertyName("userId");
                writer.WriteStringValue(UserId);
            }
            if (Optional.IsDefined(ConfidenceThreshold))
            {
                writer.WritePropertyName("confidenceScoreThreshold");
                writer.WriteNumberValue(ConfidenceThreshold.Value);
            }
            if (Optional.IsDefined(AnswerContext))
            {
                writer.WritePropertyName("context");
                writer.WriteObjectValue(AnswerContext);
            }
            if (Optional.IsDefined(RankerKind))
            {
                writer.WritePropertyName("rankerType");
                writer.WriteStringValue(RankerKind.Value.ToString());
            }
            if (Optional.IsDefined(Filters))
            {
                writer.WritePropertyName("filters");
                writer.WriteObjectValue(Filters);
            }
            if (Optional.IsDefined(ShortAnswerOptions))
            {
                writer.WritePropertyName("answerSpanRequest");
                writer.WriteObjectValue(ShortAnswerOptions);
            }
            if (Optional.IsDefined(IncludeUnstructuredSources))
            {
                writer.WritePropertyName("includeUnstructuredSources");
                writer.WriteBooleanValue(IncludeUnstructuredSources.Value);
            }
            writer.WriteEndObject();
        }
    }
}
