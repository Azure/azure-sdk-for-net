// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#nullable enable

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("StartTranscriptionRequest")]
    internal partial class StartTranscriptionRequestInternal
    {
        public string? SpeechRecognitionModelEndpointId { get; set; }
    }
}
