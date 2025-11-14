// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.ClientModel.TestFramework.TestProxy;
using System.ClientModel;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Represents a test recording session that can record, playback, or run live test interactions.
/// This class manages the lifecycle of test recordings and provides utilities for generating
/// deterministic test data during playback scenarios.
/// </summary>
public class TestRecording : IAsyncDisposable
{
    private const string RandomSeedVariableKey = "RandomSeed";
    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    // cspell: disable-next-line
    private const string charsLower = "abcdefghijklmnopqrstuvwxyz0123456789";
    private const string Sanitized = "Sanitized";
    private SortedDictionary<string, string> _variables = new();
    private readonly AsyncLocal<EntryRecordModel> _disableRecording = new AsyncLocal<EntryRecordModel>();
    private readonly string _sessionFile;
    private TestRandom? _random;
    private DateTimeOffset? _now; // The moment in time that this test is being run.
    private readonly TestProxyProcess? _proxy;
    private readonly RecordedTestBase _recordedTestBase;

    internal TestRecordingMismatchException? MismatchException;
    internal const string DateTimeOffsetNowVariableKey = "DateTimeOffsetNow";

    /// <summary>
    /// A collection of variables used in the test recording.
    /// </summary>
    public SortedDictionary<string, string> Variables => _variables;

    /// <summary>
    /// Gets a value indicating whether this recording session has processed any HTTP requests.
    /// </summary>
    public bool HasRequests { get; internal set; }

    /// <summary>
    /// Gets the current recording mode (Live, Record, or Playback).
    /// </summary>
    public RecordedTestMode Mode { get; }

    /// <summary>
    /// Gets a deterministic random number generator that produces consistent results during playback.
    /// The random seed is automatically recorded during record mode and restored during playback.
    /// </summary>
    public TestRandom Random
    {
        get
        {
            if (_random == null)
            {
                switch (Mode)
                {
                    case RecordedTestMode.Live:
#if NET6_0_OR_GREATER
                        var liveSeed = RandomNumberGenerator.GetInt32(int.MaxValue);
#else
                        var csp = new RNGCryptoServiceProvider();
                        var bytes = new byte[4];
                        csp.GetBytes(bytes);
                        var liveSeed = BitConverter.ToInt32(bytes, 0);
#endif
                        _random = new TestRandom(Mode, liveSeed);
                        break;
                    case RecordedTestMode.Record:
                        _random = new TestRandom(Mode);
                        int seed = _random.Next();
                        Variables[RandomSeedVariableKey] = seed.ToString();
                        _random = new TestRandom(Mode, seed);
                        break;
                    case RecordedTestMode.Playback:
                        ValidateVariables();
                        _random = new TestRandom(Mode, int.Parse(Variables[RandomSeedVariableKey]));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return _random;
        }
    }

    /// <summary>
    /// Gets the unique identifier for this recording session, assigned by the test proxy.
    /// </summary>
    public string? RecordingId { get; private set; }

    /// <summary>
    /// Gets the moment in time that this test is being run.  This is useful
    /// for any test recordings that capture the current time.
    /// </summary>
    public DateTimeOffset Now
    {
        get
        {
            if (_now == null)
            {
                switch (Mode)
                {
                    case RecordedTestMode.Live:
                        _now = DateTimeOffset.Now;
                        break;
                    case RecordedTestMode.Record:
                        // While we can cache DateTimeOffset.Now for playing back tests,
                        // a number of auth mechanisms are time sensitive and will require
                        // values in the present when re-recording
                        _now = DateTimeOffset.Now;
                        Variables[DateTimeOffsetNowVariableKey] = _now.Value.ToString("O"); // Use the "Round-Trip Format"
                        break;
                    case RecordedTestMode.Playback:
                        _now = DateTimeOffset.Parse(Variables[DateTimeOffsetNowVariableKey]);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return _now.Value;
        }
    }

    /// <summary>
    /// Gets the moment in time that this test is being run in UTC format.
    /// This is useful for any test recordings that capture the current time.
    /// </summary>
    public DateTimeOffset UtcNow => Now.ToUniversalTime();

    // For mocking
    internal TestRecording()
    {
        _sessionFile = string.Empty;
        _proxy = default!;
        _recordedTestBase = default!;
    }

    internal TestRecording(RecordedTestMode mode, string sessionFile, TestProxyProcess? proxy, RecordedTestBase recordedTestBase)
    {
        Mode = mode;
        _sessionFile = sessionFile;
        _proxy = proxy;
        _recordedTestBase = recordedTestBase;
    }

    /// <summary>
    /// Creates a new test recording instance asynchronously and initializes proxy settings.
    /// </summary>
    /// <param name="mode">The recording mode (Live, Record, or Playback).</param>
    /// <param name="sessionFile">The file path where the recording session will be stored or read from.</param>
    /// <param name="proxy">The test proxy process used for recording and playback operations.</param>
    /// <param name="recordedTestBase">The base test class containing sanitizers and configuration.</param>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    /// <returns>A configured TestRecording instance ready for use.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the proxy client is not initialized.</exception>
    /// <exception cref="TestRecordingMismatchException">Thrown when a playback recording file is not found.</exception>
    public static async Task<TestRecording> CreateAsync(RecordedTestMode mode, string sessionFile, TestProxyProcess? proxy, RecordedTestBase recordedTestBase, CancellationToken? cancellationToken = default)
    {
        var recording = new TestRecording(mode, sessionFile, proxy, recordedTestBase);
        await recording.InitializeProxySettingsAsync(cancellationToken ?? CancellationToken.None).ConfigureAwait(false);
        return recording;
    }

    /// <summary>
    /// Creates a transport pipeline that routes HTTP requests through the test proxy for recording or playback.
    /// </summary>
    /// <param name="currentTransport">The existing transport to wrap or use directly in live mode.</param>
    /// <returns>A transport configured for the current recording mode.</returns>
    /// <exception cref="InvalidOperationException">Thrown when attempting to instrument already instrumented options.</exception>
    public virtual PipelineTransport? CreateTransport(PipelineTransport? currentTransport)
    {
        if (Mode != RecordedTestMode.Live)
        {
            if (_proxy is null)
            {
                throw new InvalidOperationException("A test recording cannot be created because the test proxy has not been started.");
            }
            if (currentTransport is ProxyTransport)
            {
                throw new InvalidOperationException(
                    "The supplied options have already been instrumented. Each test must pass a unique options instance to " +
                    "InstrumentClientOptions.");
            }
            currentTransport ??= HttpClientPipelineTransport.Shared;
            return new ProxyTransport(_proxy, currentTransport, this, () => _disableRecording.Value);
        }

        return currentTransport;
    }

    /// <summary>
    /// Generates a deterministic unique identifier as a string.
    /// </summary>
    /// <returns>A string representation of a random integer.</returns>
    public virtual string GenerateId()
    {
        return Random.Next().ToString();
    }

    /// <summary>
    /// Generates a deterministic alphanumeric identifier with the specified prefix.
    /// </summary>
    /// <param name="prefix">The prefix to prepend to the generated identifier.</param>
    /// <param name="maxLength">Optional maximum length of the complete identifier (prefix + generated part).</param>
    /// <param name="useOnlyLowercase">If true, uses only lowercase letters and numbers.</param>
    /// <returns>An alphanumeric identifier string with the specified prefix.</returns>
    public virtual string GenerateAlphaNumericId(string prefix, int? maxLength = null, bool useOnlyLowercase = false)
    {
        var stringChars = new char[8];

        for (int i = 0; i < stringChars.Length; i++)
        {
            if (useOnlyLowercase)
            {
                stringChars[i] = charsLower[Random.Next(charsLower.Length)];
            }
            else
            {
                stringChars[i] = chars[Random.Next(chars.Length)];
            }
        }

        var finalString = new string(stringChars);
        if (maxLength.HasValue)
        {
            return $"{prefix}{finalString}".Substring(0, maxLength.Value);
        }
        else
        {
            return $"{prefix}{finalString}";
        }
    }

    /// <summary>
    /// Generates a deterministic identifier with the specified prefix, truncated to the maximum length.
    /// </summary>
    /// <param name="prefix">The prefix to prepend to the generated identifier.</param>
    /// <param name="maxLength">The maximum length of the complete identifier.</param>
    /// <returns>An identifier string that won't exceed the specified maximum length.</returns>
    public virtual string GenerateId(string prefix, int maxLength)
    {
        var id = $"{prefix}{Random.Next()}";
        return id.Length > maxLength ? id.Substring(0, maxLength) : id;
    }

    /// <summary>
    /// Generates a deterministic asset name for test resources using the calling method name.
    /// </summary>
    /// <param name="prefix">The prefix to prepend to the generated asset name.</param>
    /// <param name="callerMethodName">The name of the calling method (automatically populated).</param>
    /// <returns>A deterministic asset name suitable for test resources.</returns>
    public virtual string GenerateAssetName(string prefix, [CallerMemberName] string callerMethodName = "testframework_failed")
    {
        return prefix + Random.Next(9999);
    }

    /// <summary>
    /// Gets a variable value, recording it during record mode or retrieving it during playback.
    /// </summary>
    /// <param name="variableName">The name of the variable to get or record.</param>
    /// <param name="defaultValue">The value to use and record in record/live modes.</param>
    /// <param name="sanitizer">Optional function to sanitize the value before recording.</param>
    /// <returns>The variable value (defaultValue in record/live modes, recorded value in playback mode).</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown for invalid recording modes.</exception>
    /// <exception cref="TestRecordingMismatchException">Thrown when variables are missing in playback mode.</exception>
    public virtual string? GetVariable(string variableName, string defaultValue, Func<string, string>? sanitizer = default)
    {
        switch (Mode)
        {
            case RecordedTestMode.Record:
                Variables[variableName] = sanitizer == default ? defaultValue : sanitizer.Invoke(defaultValue);
                return defaultValue;
            case RecordedTestMode.Live:
                return defaultValue;
            case RecordedTestMode.Playback:
                ValidateVariables();
                Variables.TryGetValue(variableName, out string? value);
                return value;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void ValidateVariables()
    {
        if (Variables.Count == 0)
        {
            throw new TestRecordingMismatchException(
                "The record session does not exist or is missing the Variables section. If the test is " +
                "attributed with 'RecordedTest', it will be recorded automatically. Otherwise, set the " +
                "RecordedTestMode to 'Record' and attempt to record the test.");
        }
    }

    /// <summary>
    /// Sets a variable value during record mode. No-op in other modes.
    /// </summary>
    /// <param name="variableName">The name of the variable to set.</param>
    /// <param name="value">The value to record.</param>
    /// <param name="sanitizer">Optional function to sanitize the value before recording.</param>
    public virtual void SetVariable(string variableName, string? value, Func<string, string>? sanitizer = default)
    {
        value ??= string.Empty;
        switch (Mode)
        {
            case RecordedTestMode.Record:
                Variables[variableName] = sanitizer == default ? value : sanitizer.Invoke(value);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Creates a scope that disables recording for HTTP requests made within the scope.
    /// Useful for setup calls that shouldn't be part of the test recording.
    /// </summary>
    /// <returns>A disposable scope that disables recording.</returns>
    public virtual DisableRecordingScope DisableRecording()
    {
        return new DisableRecordingScope(this, EntryRecordModel.DoNotRecord);
    }

    /// <summary>
    /// Creates a scope that disables request body recording while still recording the request/response headers and metadata.
    /// Useful for requests with sensitive data in the body that should be excluded from recordings.
    /// </summary>
    /// <returns>A disposable scope that disables request body recording.</returns>
    public virtual DisableRecordingScope DisableRequestBodyRecording()
    {
        return new DisableRecordingScope(this, EntryRecordModel.RecordWithoutRequestBody);
    }

    /// <summary>
    /// Disposes the test recording asynchronously, stopping the recording or playback session.
    /// </summary>
    /// <param name="save">Whether to save the recording. If false, the recording is discarded.</param>
    /// <returns>A task representing the asynchronous disposal operation.</returns>
    public async ValueTask DisposeAsync(bool save)
    {
        if (_proxy is null || _proxy.ProxyClient is null)
        {
            return;
        }
        if (Mode == RecordedTestMode.Record)
        {
            await _proxy.ProxyClient.StopRecordAsync(RecordingId, Variables, save ? null : "request-response").ConfigureAwait(false);
        }
        else if (Mode == RecordedTestMode.Playback && HasRequests)
        {
            await _proxy.ProxyClient.StopPlaybackAsync(RecordingId).ConfigureAwait(false);
        }
    }

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true).ConfigureAwait(false);
    }

    /// <summary>
    /// A disposable scope that temporarily modifies recording behavior for HTTP requests.
    /// </summary>
    public struct DisableRecordingScope : IDisposable
    {
        private readonly TestRecording _testRecording;

        /// <summary>
        /// Initializes a new instance of the DisableRecordingScope struct.
        /// </summary>
        /// <param name="testRecording">The test recording instance to modify.</param>
        /// <param name="entryRecordModel">The recording behavior to apply within this scope.</param>
        public DisableRecordingScope(TestRecording testRecording, EntryRecordModel entryRecordModel)
        {
            _testRecording = testRecording;
            _testRecording._disableRecording.Value = entryRecordModel;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _testRecording._disableRecording.Value = EntryRecordModel.Record;
        }
    }

    internal async Task InitializeProxySettingsAsync(CancellationToken cancellationToken)
    {
        var assetsJson = _recordedTestBase.AssetsJsonPath;

        switch (Mode)
        {
            case RecordedTestMode.Record:
                if (_proxy is null)
                {
                    throw new InvalidOperationException("A test recording cannot be created because the test proxy has not been started.");
                }
                if (_proxy.ProxyClient == null)
                {
                    throw new InvalidOperationException("TestProxyProcess.ProxyClient is null. Ensure that the TestProxyProcess is started before attempting to create a TestRecording.");
                }

                ClientResult recordResponse = await _proxy.ProxyClient.StartRecordAsync(body: new TestProxyStartInformation(_sessionFile, assetsJson, null), cancellationToken).ConfigureAwait(false);
                var rawRecordResponse = recordResponse.GetRawResponse();
                rawRecordResponse.Headers.TryGetValue("x-recording-id", out string? recordRecordingId);
                RecordingId = recordRecordingId;
                await ApplySanitizersAsync(cancellationToken).ConfigureAwait(false);

                break;
            case RecordedTestMode.Playback:
                if (_proxy is null)
                {
                    throw new InvalidOperationException("A test recording cannot be created because the test proxy has not been started.");
                }
                if (_proxy.ProxyClient == null)
                {
                    throw new InvalidOperationException("TestProxyProcess.ProxyClient is null. Ensure that the TestProxyProcess is started before attempting to create a TestRecording.");
                }

                ClientResult<IReadOnlyDictionary<string, string>>? playbackResult;
                try
                {
                    playbackResult = await _proxy.ProxyClient.StartPlaybackAsync(new TestProxyStartInformation(_sessionFile, assetsJson, null), null, cancellationToken).ConfigureAwait(false);
                }
                catch (ClientResultException ex)
                    when (ex.Status == 404)
                {
                    // We don't throw the exception here because Playback only tests that are testing the
                    // recording infrastructure itself will not have session records.
                    MismatchException = new TestRecordingMismatchException(ex.Message, ex);
                    return;
                }

                _variables = new SortedDictionary<string, string>((Dictionary<string, string>)playbackResult);
                var response = playbackResult.GetRawResponse();
                response.Headers.TryGetValue("x-recording-id", out string? playbackRecordingId);
                RecordingId = playbackRecordingId;
                await ApplySanitizersAsync(cancellationToken).ConfigureAwait(false);

                var excludedHeaders = new List<string>()
                {
                    "Content-Type",
                    "Content-Length",
                    "Connection"
                };
                CustomDefaultMatcher defaultMatcher = new()
                {
                    ExcludedHeaders = string.Join(",", excludedHeaders),
                    IgnoredHeaders = _recordedTestBase.IgnoredHeaders.Count > 0 ? string.Join(",", _recordedTestBase.IgnoredHeaders) : null,
                    IgnoredQueryParameters = _recordedTestBase.IgnoredQueryParameters.Count > 0 ? string.Join(",", _recordedTestBase.IgnoredQueryParameters) : null,
                    CompareBodies = _recordedTestBase.CompareBodies
                };
                await _proxy.AdminClient.SetMatcherAsync(MatcherType.CustomDefaultMatcher, defaultMatcher).ConfigureAwait(false);

                break;
        }
    }

    private async Task ApplySanitizersAsync(CancellationToken cancellationToken)
    {
        if (_proxy is null)
        {
            throw new InvalidOperationException("A test recording cannot be created because the test proxy has not been started.");
        }
        if (_proxy.AdminClient == null)
        {
            throw new InvalidOperationException("TestProxyProcess.AdminClient is null. Ensure that the TestProxyProcess is started before attempting to create a TestRecording.");
        }

        List<SanitizerAddition> sanitizers = new();

        foreach (string header in _recordedTestBase.SanitizedHeaders)
        {
            sanitizers.Add(new HeaderRegexSanitizer(new HeaderRegexSanitizerBody(header)));
        }

        sanitizers.AddRange(_recordedTestBase.HeaderRegexSanitizers);

        foreach ((string header, string queryParameter) in _recordedTestBase.SanitizedQueryParametersInHeaders)
        {
            sanitizers.Add(HeaderRegexSanitizer.CreateWithQueryParameter(header, queryParameter, Sanitized));
        }

        sanitizers.AddRange(_recordedTestBase.UriRegexSanitizers);

        foreach (string queryParameter in _recordedTestBase.SanitizedQueryParameters)
        {
            sanitizers.Add(UriRegexSanitizer.CreateWithQueryParameter(queryParameter, Sanitized));
        }

        foreach (string path in _recordedTestBase.JsonPathSanitizers)
        {
            sanitizers.Add(new BodyKeySanitizer(new BodyKeySanitizerBody(path)));
        }

        sanitizers.AddRange(_recordedTestBase.BodyKeySanitizers);
        sanitizers.AddRange(_recordedTestBase.BodyRegexSanitizers);

        if (sanitizers.Count > 0)
        {
            await _proxy.AdminClient.AddSanitizersAsync(sanitizers, RecordingId, cancellationToken).ConfigureAwait(false);
        }

        if (_recordedTestBase.SanitizersToRemove.Count > 0)
        {
            var toRemove = new SanitizerList(new List<string>());
            foreach (var sanitizer in _recordedTestBase.SanitizersToRemove)
            {
                toRemove.Sanitizers.Add(sanitizer);
            }
            await _proxy.AdminClient.RemoveSanitizersAsync(toRemove, RecordingId, cancellationToken).ConfigureAwait(false);
        }
    }
}
