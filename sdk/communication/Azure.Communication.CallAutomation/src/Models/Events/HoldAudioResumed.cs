// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The HoldAudioResumed event.
    /// </summary>
    [CodeGenModel("HoldAudioResumed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    internal partial class HoldAudioResumed : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary>
        /// Deserialize <see cref="HoldAudioResumed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="HoldAudioResumed"/> object.</returns>
        public static HoldAudioResumed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeHoldAudioResumed(element);
        }

        internal static HoldAudioResumed DeserializeHoldAudioResumed(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string callConnectionId = default;
            string serverCallId = default;
            string correlationId = default;
            string operationContext = default;
            ResultInformation resultInformation = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("callConnectionId"u8))
                {
                    callConnectionId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("serverCallId"u8))
                {
                    serverCallId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("correlationId"u8))
                {
                    correlationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("operationContext"u8))
                {
                    operationContext = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("resultInformation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resultInformation = ResultInformation.DeserializeResultInformation(property.Value);
                    continue;
                }
            }
            return new HoldAudioResumed(callConnectionId, serverCallId, correlationId, operationContext, resultInformation);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static HoldAudioResumed FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeHoldAudioResumed(document.RootElement);
        }
    }
}
