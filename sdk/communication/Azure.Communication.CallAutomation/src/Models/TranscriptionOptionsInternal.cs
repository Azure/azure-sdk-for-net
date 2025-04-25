// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#nullable enable

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("TranscriptionOptions")]
    internal partial class TranscriptionOptionsInternal
    {
        /// <summary>Optional speech model endpoint to use for the transcription.</summary>
        public string? SpeechRecognitionModelEndpointId { get; set; }
    }
}