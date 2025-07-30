// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Start transcription Request.
    /// </summary>
    public class StartTranscriptionOptions
    {
        /// <summary>
        /// Constructor for StartTranscriptionOptions.
        /// </summary>
        /// <param name="locales">Defines the list locale for the language identification e.g en-CA, en-AU.</param>
        public StartTranscriptionOptions(IEnumerable<string> locales)
        {
            this.Locales = locales.ToList<string>();
        }
        /// <summary> Defines Locale for the transcription e,g en-US. </summary>
        public string Locale { get; set; }
        /// <summary> Endpoint where the custom model was deployed. </summary>
        public string SpeechRecognitionModelEndpointId { get; set; }
        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }
        /// <summary>
        /// Set a callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public Uri OperationCallbackUri { get; set; }

        /// <summary> PII redaction configuration options. </summary>
        public PiiRedactionOptions PiiRedactionOptions { get; set; }
        /// <summary> Indicating if sentiment analysis should be used. </summary>
        public bool? EnableSentimentAnalysis { get; set; }
        /// <summary> List of languages for Language Identification. </summary>
        internal IList<string> Locales { get; }
        /// <summary> Summarization configuration options. </summary>
        public SummarizationOptions SummarizationOptions { get; set; }
    }
}
