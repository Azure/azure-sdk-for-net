// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Speech.Transcription;

/// <summary>
/// Represents the result of a transcription operation.
/// </summary>
/// <remarks>
/// Collections exposed by this class (such as CombinedPhrases and Phrases) use IList
/// for compatibility but should be treated as read-only. Modifying collection contents
/// may lead to unexpected behavior and is not supported.
/// </remarks>
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

    /// <summary> The duration of the audio in milliseconds. </summary>
    internal int DurationMilliseconds { get; }
}
