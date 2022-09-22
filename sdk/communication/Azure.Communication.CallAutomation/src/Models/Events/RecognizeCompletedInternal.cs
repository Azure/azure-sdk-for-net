// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.CallAutomation.Converters;
using System.Text.Json.Serialization;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation.Models.Events
{
    [CodeGenModel("RecognizeCompleted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    internal partial class RecognizeCompletedInternal : CallAutomationEventBase
    {
        /// <summary>
        /// The recognition type.
        /// </summary>
        [CodeGenMember("RecognitionType")]
        [JsonConverter(typeof(EquatableEnumJsonConverter<CallMediaRecognitionType>))]
        public CallMediaRecognitionType RecognitionType { get; set; }

        /// <summary>
        /// Deserialize <see cref="RecognizeCompletedInternal"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeCompletedInternal"/> object.</returns>
        public static RecognizeCompletedInternal Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeRecognizeCompletedInternal(element);
        }
    }
}
