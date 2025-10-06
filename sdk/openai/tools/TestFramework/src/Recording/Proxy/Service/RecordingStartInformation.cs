// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace OpenAI.TestFramework.Recording.Proxy.Service;

/// <summary>
/// Information for starting a recording or playback session with the recording test proxy.
/// </summary>
public class RecordingStartInformation
{
    /// <summary>
    /// Gets or sets the file to save recordings to, or to play back requests from.
    /// </summary>
    [JsonPropertyName("x-recording-file")]
    required public string RecordingFile { get; set; }

    /// <summary>
    /// Gets or sets the path to the "assets.json" file to use for integration with external Git
    /// repositories. This enables the proxy to work against repositories that do not emplace their
    /// test recordings directly alongside their test implementations.
    /// </summary>
    /// <remarks>
    /// Please refer to the documentation for more information:
    /// https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/documentation/asset-sync/README.md
    /// </remarks>
    [JsonPropertyName("x-recording-assets-file")]
    public string? AssetsFile { get; set; }
}
