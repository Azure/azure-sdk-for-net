// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("TranscriptionUpdate", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class TranscriptionUpdate
    {
        /// <summary> Initializes a new instance of <see cref="TranscriptionUpdate"/>. </summary>
        /// <param name="transcriptionStatus"></param>
        /// <param name="transcriptionStatusDetails"></param>
        internal TranscriptionUpdate(TranscriptionStatus? transcriptionStatus, TranscriptionStatusDetails? transcriptionStatusDetails)
        {
            TranscriptionStatus = transcriptionStatus;
            TranscriptionStatusDetails = transcriptionStatusDetails;
        }
    }
}
