// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework;

/// <summary>
/// The recording mode.
/// </summary>
public enum RecordedTestMode
{
    /// <summary>
    /// Talk to live services. No recording or playback is used.
    /// </summary>
    Live,

    /// <summary>
    /// Record the test and overwrite any existing recordings.
    /// </summary>
    Record,

    /// <summary>
    /// Playback the test from a recording.
    /// </summary>
    Playback,
}
