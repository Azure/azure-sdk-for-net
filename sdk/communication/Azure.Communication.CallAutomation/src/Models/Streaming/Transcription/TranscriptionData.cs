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
            Format = ConvertToTextFormatEnum(format);
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
        public string Text { get; set; }

        /// <summary>
        /// The format of text
        /// </summary>
        public TextFormat Format { get; set; }

        /// <summary>
        /// Confidence of recognition of the whole phrase, from 0.0 (no confidence) to 1.0 (full confidence)
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// The position of this payload
        /// </summary>

        public TimeSpan Offset { get; set; }

        /// <summary>
        /// Duration in ticks. 1 tick = 100 nanoseconds.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// The result for each word of the phrase
        /// </summary>
        public IEnumerable<WordData> Words { get; set; }

        /// <summary>
        /// The identified speaker based on participant raw ID
        /// </summary>
        public CommunicationIdentifier Participant { get; set; }

        /// <summary>
        /// Status of the result of transcription
        /// </summary>
        public TranscriptionResultState ResultState { get; set; }

        /// <summary>
        /// ConvertToTextFormatEnum
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static TextFormat ConvertToTextFormatEnum(string format)
        {
            if (TextFormat.Display.ToString().Equals(format, StringComparison.OrdinalIgnoreCase))
                return TextFormat.Display;
            else
                throw new NotSupportedException(format);
        }

        private static IEnumerable<WordData> ConvertToWordData(IEnumerable<WordDataInternal> wordData)
        {
            return wordData.Select(w => new WordData(w.Text, w.Offset, w.Duration));
        }
    }
}
