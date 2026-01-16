// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Speech.Transcription;

public partial class TranscribedWord
{
    /// <summary> The start offset of the word. </summary>
    public TimeSpan Offset
    {
        get
        {
            return TimeSpan.FromMilliseconds(OffsetMilliseconds);
        }
    }

    /// <summary> The duration of the word. </summary>
    public TimeSpan Duration
    {
        get
        {
            return TimeSpan.FromMilliseconds(DurationMilliseconds);
        }
    }

    /// <summary> The start offset of the word in milliseconds. </summary>
    internal int OffsetMilliseconds { get; }
    /// <summary> The duration of the word in milliseconds. </summary>
    internal int DurationMilliseconds { get; }
}
