// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming Transcription.
    /// </summary>
    public class TranscriptionData : StreamingData
    {
        internal TranscriptionData(TranscriptionDataInternal transcriptionDataInternal)
        {
            Text = transcriptionDataInternal.Text;
            Format = transcriptionDataInternal.Format;
            Confidence = transcriptionDataInternal.Confidence;
            Offset = TimeSpan.FromTicks(transcriptionDataInternal.Offset);
            Duration = TimeSpan.FromTicks(transcriptionDataInternal.Duration);
            if (transcriptionDataInternal.Words != null)
                Words = ConvertToWordData(transcriptionDataInternal.Words);
            if (transcriptionDataInternal.ParticipantRawID != null)
            {
                Participant = CommunicationIdentifier.FromRawId(transcriptionDataInternal.ParticipantRawID);
            }
            ResultState = transcriptionDataInternal.ResultState;
            SentimentAnalysisResult = transcriptionDataInternal.SentimentAnalysisResult;
            LanguageIdentified = transcriptionDataInternal.LanguageIdentified;
        }

        /// <summary>
        /// The display form of the recognized word
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The format of text
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// Confidence of recognition of the whole phrase, from 0.0 (no confidence) to 1.0 (full confidence)
        /// </summary>
        public double Confidence { get; }

        /// <summary>
        /// The position of this payload
        /// </summary>

        public TimeSpan Offset { get;}

        /// <summary>
        /// Duration in ticks. 1 tick = 100 nanoseconds.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// The result for each word of the phrase
        /// </summary>
        public IEnumerable<WordData> Words { get; }

        /// <summary>
        /// The identified speaker based on participant raw ID
        /// </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Status of the result of transcription
        /// </summary>
        public TranscriptionResultState ResultState { get; }

        /// <summary>
        /// SentimentAnalysisResult result.
        /// </summary>
        public SentimentAnalysisResult SentimentAnalysisResult { get; internal set; }

        /// <summary>
        /// Language identified
        /// </summary>
        public string LanguageIdentified { get; internal set; }

        private static IEnumerable<WordData> ConvertToWordData(IEnumerable<WordDataInternal> wordData)
        {
            return wordData.Select(w => new WordData(w.Text, w.Offset, w.Duration));
        }
    }
}
