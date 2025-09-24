// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Speech.Transcription;

public partial class TranscriptionResult
{
    /// <summary> The duration of the audio. </summary>
    public TimeSpan Duration
    {
        get
        {
            return TimeSpan.FromMilliseconds(DurationMilliseconds);
        }
    }

    private IEnumerable<TranscribedPhrases> _TranscribedPhrases;

    /// <summary> The transcripted phrases by their channel. </summary>
    public IEnumerable<TranscribedPhrases> PhrasesByChannel
    {
        get
        {
            if (_TranscribedPhrases != null)
            {
                return _TranscribedPhrases;
            }
            var TranscribedPhrases = new List<TranscribedPhrases>();

            var CombinedPhrases = this.CombinedPhrases.ToDictionary((phrase) => phrase.Channel ?? -1);
            var Phrases = this.Phrases.GroupBy((phrase) => phrase.Channel).ToDictionary((e) => e.Key ?? -1, (e) => e.ToList());
            foreach (var key in CombinedPhrases.Keys)
            {
                var CombinedPhrase = CombinedPhrases[key];
                var Phrase = Phrases[key];
                TranscribedPhrases.Add(new TranscribedPhrases(key == -1 ? null : key, CombinedPhrase.Text, Phrase));
            }

            _TranscribedPhrases = TranscribedPhrases;
            return _TranscribedPhrases;
        }
    }

    /// <summary> The duration of the audio in milliseconds. </summary>
    internal int DurationMilliseconds { get; }

    /// <summary> The full transcript for each channel. </summary>
    internal IReadOnlyList<ChannelCombinedPhrases> CombinedPhrases { get; }
    /// <summary> The transcription results segmented into phrases. </summary>
    internal IReadOnlyList<TranscribedPhrase> Phrases { get; }
}
