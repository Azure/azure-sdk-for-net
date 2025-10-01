// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary> Options of live transcription. </summary>
    public partial class TranscriptionOptions
    {
        /// <summary> Initializes a new instance of TranscriptionOptions. </summary>
        /// <param name="transportUri"> Transport URL for live transcription. </param>
        /// <param name="locale"> Defines the locale for the data e.g en-CA, en-AU. </param>
        /// <param name="startTranscription"> Determines if the transcription should be started immediately after call is answered or not. </param>
        /// <param name="transcriptionTransport"> The type of transport to be used for live transcription, eg. Websocket. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="transportUri"/> or <paramref name="locale"/> is null. </exception>
        public TranscriptionOptions(Uri transportUri, string locale, bool? startTranscription = null, TranscriptionTransport transcriptionTransport = default)
        {
            Argument.AssertNotNull(transportUri, nameof(transportUri));
            Argument.AssertNotNull(locale, nameof(locale));

            TransportUri = transportUri;
            TranscriptionTransport = transcriptionTransport;
            Locale = locale;
            StartTranscription = startTranscription;
        }

        /// <summary> Transport URL for live transcription. </summary>
        public Uri TransportUri { get; }
        /// <summary> The type of transport to be used for live transcription, eg. Websocket. </summary>
        public TranscriptionTransport TranscriptionTransport { get; }
        /// <summary> Defines the locale for the data e.g en-CA, en-AU. </summary>
        public string Locale { get; }
        /// <summary> Determines if the transcription should be started immediately after call is answered or not. </summary>
        public bool? StartTranscription { get; }
        /// <summary> Endpoint where the custom model was deployed. </summary>
        public string SpeechRecognitionModelEndpointId { get; set; }
        /// <summary> Enables intermediate results for the transcribed speech. </summary>
        public bool? EnableIntermediateResults { get; set; }
        /// <summary> PII redaction configuration options. </summary>
        public PiiRedactionOptions PiiRedactionOptions { get; set; }
        /// <summary> Indicating if sentiment analysis should be used. </summary>
        public bool? IsSentimentAnalysisEnabled { get; set; }
        /// <summary>  List of locales for Language Identification. Supports upto 4 locales in the format: ["en-us", "fr-fr", "hi-in"] etc. </summary>
        public IList<string> Locales { get; set; }
        /// <summary> Summarization configuration options. </summary>
        public SummarizationOptions SummarizationOptions { get; set; }
    }
}
