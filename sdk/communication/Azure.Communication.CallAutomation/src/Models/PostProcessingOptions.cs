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
            string cognitiveServicesEndpoint,
            SummarizationSettings summarization = null,
            TranscriptionSettings transcription = null)
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
        /// <summary> Define options of the transcription for the post recording processing. </summary>
        internal TranscriptionSettings Transcription { get; private set;}
        /// <summary> Define options of the summarization for the post recording processing. </summary>
        internal SummarizationSettings Summarization { get; private set; }

        /// <summary>
        /// Set the transcription settings for the post recording processing.
        /// </summary>
        /// <param name="enableTranscription"></param>
        public void setTranscriptionSettings(bool enableTranscription)
        {
            this.Transcription = new TranscriptionSettings(enableTranscription);
        }

        /// <summary>
        /// Set the summarization settings for the post recording processing.
        /// </summary>
        /// <param name="enableSummarization"></param>
        public void setSummarizationSettings(bool enableSummarization)
        {
            this.Summarization = new SummarizationSettings(enableSummarization);
        }
    }
}