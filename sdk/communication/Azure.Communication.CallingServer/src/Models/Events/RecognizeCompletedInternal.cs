// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Communication.CallingServer.Converters;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The recognize completed event internal
    /// </summary>
    [CodeGenModel("RecognizeCompleted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    internal partial class RecognizeCompletedInternal
    {
        /// <summary>
        /// The recognition type.
        /// </summary>
        [CodeGenMember("RecognitionType")]
        [JsonConverter(typeof(EquatableEnumJsonConverter<CallMediaRecognitionType>))]
        public CallMediaRecognitionType RecognitionType { get; set; }
    }
}
