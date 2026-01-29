// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Speech.Transcription
{
    /// <summary> Model factory for models. </summary>
    public static partial class AISpeechTranscriptionModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="TranscriptionResult"/>. </summary>
        /// <param name="durationMilliseconds"> The duration of the audio in milliseconds. </param>
        /// <returns> A new <see cref="TranscriptionResult"/> instance for mocking. </returns>
        public static TranscriptionResult TranscriptionResult(int durationMilliseconds = default)
        {
            return new TranscriptionResult(durationMilliseconds, new List<ChannelCombinedPhrases>(), new List<TranscribedPhrase>(), serializedAdditionalRawData: null);
        }
    }
}
