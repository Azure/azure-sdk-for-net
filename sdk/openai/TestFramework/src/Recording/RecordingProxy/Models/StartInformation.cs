// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace OpenAI.TestFramework.Recording.RecordingProxy.Models;

/// <summary>
/// Information for starting a recoring or playback session with the recording test proxy.
/// </summary>
public class StartInformation
{
    /// <summary>
    /// Gets or sets the file to save recordings to, or to play back requests from.
    /// </summary>
    [JsonPropertyName("x-recording-file")]
    required public string RecordingFile { get; set; }

    /// <summary>
    /// Gets or sets the file that controls where the test recordings are restored from, or pushed to.
    /// </summary>
    [JsonPropertyName("x-recording-assets-file")]
    public string? AssetsFile { get; set; }
}
