// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// Options used for various recordings.
/// </summary>
public static class Default
{
    private static JsonSerializerOptions? _recordingJsonOptions;
    private static JsonSerializerOptions? _innerRecordingJsonOptions;
    private static JsonSerializerOptions? _testProxyJsonOptions;
    private static TimeSpan? _testProxyWaitTime;
    private static TimeSpan? _requestRetryDelay;
    private static TimeSpan? _debuggerTestTimeout;
    private static TimeSpan? _defaultTestTimeout;

    /// <summary>
    /// Gets the default value to replace matches with while sanitizing.
    /// </summary>
    public const string SanitizedValue = "Sanitized";

    /// <summary>
    /// Gets the JSON serialization options to use for recording sanitizers, matchers, and transforms child instances.
    /// </summary>
    public static JsonSerializerOptions InnerRecordingJsonOptions => _innerRecordingJsonOptions ??= new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    /// <summary>
    /// Gets the JSON serialization options to use for recording sanitizers, matchers, and transforms.
    /// </summary>
    public static JsonSerializerOptions RecordingJsonOptions
    {
        get
        {
            if (_recordingJsonOptions == null)
            {
                _recordingJsonOptions = InnerRecordingJsonOptions.Clone();
                _recordingJsonOptions.Converters.Add(

#if !NET7_0_OR_GREATER
                    // System.Text.Json 6.0.9 seems to have a weird bug here. This is not needed for .Net 7+
                    new Utf8JsonSerializableConverterFactory()
#else
                    new Utf8JsonSerializableConverter()
#endif
                );
            }

            return _recordingJsonOptions;
        }
    }


    /// <summary>
    /// Gets the JSON serialization options to use for the test proxy
    /// </summary>
    public static JsonSerializerOptions TestProxyJsonOptions => _testProxyJsonOptions ??= new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    /// <summary>
    /// The default maximum amount of time to wait to for the test proxy operations to finish (e.g. start up
    /// and configuration, or saving a recording and teardown).
    /// </summary>
    public static TimeSpan TestProxyWaitTime => _testProxyWaitTime ??= TimeSpan.FromMinutes(2);

    /// <summary>
    /// Gets the maximum number of times to retry requests
    /// </summary>
    public const int MaxRequestRetries = 3;

    /// <summary>
    /// The amount of time to wait between requests.
    /// </summary>
    public static TimeSpan RequestRetryDelay => _requestRetryDelay ??= TimeSpan.FromSeconds(0.8);

    /// <summary>
    /// The amount of time to wait when the debugger is attached. This is much higher than normal to allow for more time while debugging.
    /// </summary>
    public static TimeSpan DebuggerAttachedTestTimeout => _debuggerTestTimeout ??= TimeSpan.FromMinutes(15);

    /// <summary>
    /// The default test timeout.
    /// </summary>
    public static TimeSpan TestTimeout => _defaultTestTimeout ??= TimeSpan.FromSeconds(15);
}
