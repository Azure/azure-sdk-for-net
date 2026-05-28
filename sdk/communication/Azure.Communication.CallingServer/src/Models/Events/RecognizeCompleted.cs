// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Communication.CallingServer.Converters;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The play completed event.
    /// </summary>
    [CodeGenModel("RecognizeCompleted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class RecognizeCompleted : CallAutomationEventBase
    {
        /// <summary>
        /// The recognition type.
        /// </summary>
        [CodeGenMember("RecognitionType")]
        [JsonConverter(typeof(EquatableEnumJsonConverter<CallMediaRecognitionType>))]
        public CallMediaRecognitionType RecognitionType { get; set; }

        /// <summary>
        /// Deserialize <see cref="RecognizeCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeCompleted"/> object.</returns>
        public static RecognizeCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeRecognizeCompleted(element);
        }
    }
}
