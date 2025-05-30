// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Speech.BatchTranscription;

/// <summary> FileProperties. </summary>
public partial class FileProperties
{
    /// <summary> The total duration of the file in case this file is an audio file. </summary>
    public TimeSpan Duration
    {
        get
        {
            return TimeSpan.FromMilliseconds(DurationMilliseconds);
        }
    }

    /// <summary> The total duration in milliseconds of the file in case this file is an audio file. </summary>
    internal int DurationMilliseconds { get; }
}
