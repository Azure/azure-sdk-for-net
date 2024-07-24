// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Recording.Common;

/// <summary>
/// Options used for various recordings.
/// </summary>
public static class Default
{
    private static JsonSerializerOptions? _recordingJsonOptions = null;
    private static JsonSerializerOptions? _testProxyJsonOptions = null;
    private static TimeSpan? _testProxyWaitTime = null;

    /// <summary>
    /// Gets the default value to replace matches with while sanitizing.
    /// </summary>
    public const string SanitizedValue = "Sanitized";

    /// <summary>
    /// Gets the JSON serialization options to use for recording sanitizers, matchers, and transforms.
    /// </summary>
    public static JsonSerializerOptions RecordingJsonOptions => _recordingJsonOptions ??= new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
#if NET
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
#else
        IgnoreNullValues = true,
#endif
        Converters =
        {
            new Utf8JsonSerializableConverter()
        }
    };

    /// <summary>
    /// Gets the JSON serialization options to use for the test proxy
    /// </summary>
    public static JsonSerializerOptions TestProxyJsonOptions => _testProxyJsonOptions ??= new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
#if NET
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
#else
        IgnoreNullValues = true,
#endif
    };

    /// <summary>
    /// The name of the assets JSON file that contains the information needed for the test proxy to save
    /// and restore recordings.
    /// </summary>
    public static string AssetsJson => "assets.json";

    /// <summary>
    /// The default maximum amount of time to wait to for the test proxy operations to finish (e.g. start up
    /// and configuration, or saving a recording and teardown).
    /// </summary>
    public static TimeSpan TestProxyWaitTime => _testProxyWaitTime ??= TimeSpan.FromMinutes(2);
}
