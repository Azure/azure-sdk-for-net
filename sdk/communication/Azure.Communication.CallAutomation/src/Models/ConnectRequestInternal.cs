// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("ConnectRequest")]
    internal partial class ConnectRequestInternal
    {
        /// <summary> Gets the transcription status. </summary>
        public TranscriptionStatus TranscriptionStatus { get; }
        /// <summary> Gets the transcription status details. </summary>
        public TranscriptionStatusDetails TranscriptionStatusDetails { get; }
    }
}
