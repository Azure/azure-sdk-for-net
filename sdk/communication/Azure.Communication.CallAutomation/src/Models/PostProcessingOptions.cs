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
            TranscriptionSettings transcription,
            SummarizationSettings summarization,
            string cognitiveServicesEndpoint)
        {
            this.CognitiveServicesEndpoint = cognitiveServicesEndpoint;
            this.Summarization = summarization;
            this.Transcription = transcription;
        }

        /// <summary>
        /// The identifier of the Cognitive Service resource assigned to the post recording processing.
        /// The Cognitive Service resource will be used by the summarization feature.
        /// </summary>
        public string CognitiveServicesEndpoint { get; set; }
    }
}