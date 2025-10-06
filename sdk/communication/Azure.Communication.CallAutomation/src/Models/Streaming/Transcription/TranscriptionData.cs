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
        internal TranscriptionData(string text, string format, double confidence, long offset, long duration, IEnumerable<WordDataInternal> words, string participantRawID, TranscriptionResultState resultState)
        {
            Text = text;
            Format = format;
            Confidence = confidence;
            Offset = TimeSpan.FromTicks(offset);
            Duration = TimeSpan.FromTicks(duration);
            if (words != null)
                Words = ConvertToWordData(words);
            if (participantRawID != null)
            {
                Participant = CommunicationIdentifier.FromRawId(participantRawID);
            }
            ResultState = resultState;
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

        private static IEnumerable<WordData> ConvertToWordData(IEnumerable<WordDataInternal> wordData)
        {
            return wordData.Select(w => new WordData(w.Text, w.Offset, w.Duration));
        }
    }
}
