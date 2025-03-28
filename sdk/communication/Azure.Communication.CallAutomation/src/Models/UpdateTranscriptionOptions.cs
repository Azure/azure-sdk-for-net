﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the stop transcription Request.
    /// </summary>
    public class UpdateTranscriptionOptions
    {
        /// <summary>
        /// Options for the Update Transcription operation.
        /// </summary>
        public UpdateTranscriptionOptions(string locale)
        {
            this.Locale = locale;
        }

        /// <summary> Defines Locale for the transcription e,g en-US. </summary>
        internal string Locale { get; set; }

        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }

        /// <summary> Endpoint where the custom model was deployed. </summary>
        public string SpeechRecognitionModelEndpointId { get; set; }
    }
}
