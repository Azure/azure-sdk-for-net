// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.OpenAI;

/// <summary>
/// Specifies the available audio timestamp granularities when providing timing information in transcription operations.
/// </summary>
/// <remarks>
/// Multiple values may be combined with the single-pipe | operator, with e.g.
/// <code><see cref="AudioTimestampGranularity.Word"/> | <see cref="AudioTimestampGranularity.Segment"/></code>
/// requesting both word- and segment-level timestamps.
/// </remarks>
[Flags]
public enum AudioTimestampGranularity
{
    /// <summary>
    /// The value when no flags are specified and default granularities will be assumed.
    /// </summary>
    /// <remarks>
    /// For audio transcription, segment-level timing will be provided by default.
    /// </remarks>
    Default = 0,
    /// <summary>
    /// The flag value specifying that word-level timing information should be requested.
    /// </summary>
    Word = 1,
    /// <summary>
    /// The flag value specifying that segment-level timing information should be requested.
    /// </summary>
    /// <remarks>
    /// Note that segment-level timing information is requested by default for audio transcription and does not need
    /// to be explicitly requested unless combined with another granularity.
    /// </remarks>
    Segment = 2,
}
