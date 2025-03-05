// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Speech.Transcription;

public partial class TranscribeResult
{
    /// <summary> The duration of the audio. </summary>
    public TimeSpan Duration
    {
        get
        {
            return TimeSpan.FromMilliseconds(DurationMilliseconds);
        }
    }

    private ILookup<int, TranscribedPhrase> _PhrasesByChannel;

    /// <summary> The transcripted phrases by their channel. </summary>
    public ILookup<int, TranscribedPhrase> PhrasesByChannel {
        get
        {
            if (_PhrasesByChannel != null)
            {
                return _PhrasesByChannel;
            }
            _PhrasesByChannel = Phrases.ToLookup((phrase) => phrase.Channel ?? 0);
            return _PhrasesByChannel;
        }
    }
}
