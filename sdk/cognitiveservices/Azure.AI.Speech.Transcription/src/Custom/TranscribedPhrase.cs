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

    /// <summary> The 0-based channel index. Only present if channel separation is enabled. </summary>
    internal int? Channel { get; }
    /// <summary> The start offset of the phrase in milliseconds. </summary>
    internal int OffsetMilliseconds { get; }
    /// <summary> The duration of the phrase in milliseconds. </summary>
    internal int DurationMilliseconds { get; }
}
