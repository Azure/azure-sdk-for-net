// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// PostProcessingOptions base class
    /// </summary>
    public partial class PostProcessingOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostProcessingOptions"/> class.
        /// </summary>
        public PostProcessingOptions(
            TranscriptionSettings transcription
        )
        {
            this.Transcription = transcription;
        }

        /// <summary>
        /// The identifier of the Cognitive Service resource assigned to the post recording processing.
        /// The Cognitive Service resource will be used by the summarization feature.
        /// </summary>
        public string CognitiveServicesEndpoint { get; set; }
        /// <summary> Define options of the transcription for the post recording processing. </summary>
        public TranscriptionSettings Transcription { get; }
        /// <summary> Define options of the summarization for the post recording processing. </summary>
        public SummarizationSettings Summarization { get; set; }
    }
}