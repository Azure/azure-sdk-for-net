// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Speech.Transcription;

/// <summary>
/// Represents a transcribed phrase with timing, speaker, and word-level details.
/// </summary>
/// <remarks>
/// Collections exposed by this class (such as Words) use IList for compatibility
/// but should be treated as read-only. Modifying collection contents may lead to
/// unexpected behavior and is not supported.
/// </remarks>
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
