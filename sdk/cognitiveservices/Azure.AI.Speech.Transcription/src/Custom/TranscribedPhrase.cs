// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Speech.Transcription;

public partial class TranscribedPhrase
{
    /// <summary> The start offset of the phrase. </summary>
    public TimeSpan Offset
    {
        get
        {
            return TimeSpan.FromMilliseconds(OffsetMilliseconds);
        }
    }

    /// <summary> The duration of the phrase. </summary>
    public TimeSpan Duration
    {
        get
        {
            return TimeSpan.FromMilliseconds(DurationMilliseconds);
        }
    }
}
