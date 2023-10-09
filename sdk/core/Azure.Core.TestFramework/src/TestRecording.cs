// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework.Models;
using Azure.Core.Tests.TestFramework;

namespace Azure.Core.TestFramework
{
    public class TestRecording : IAsyncDisposable
    {
        private const string RandomSeedVariableKey = "RandomSeed";
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        // cspell: disable-next-line
        private const string charsLower = "abcdefghijklmnopqrstuvwxyz0123456789";
        private const string Sanitized = "Sanitized";
        internal const string DateTimeOffsetNowVariableKey = "DateTimeOffsetNow";

        public SortedDictionary<string, string> Variables => _variables;
        private SortedDictionary<string, string> _variables = new();

        private TestRecording(RecordedTestMode mode, string sessionFile, TestProxy proxy, RecordedTestBase recordedTestBase)
        {
            Mode = mode;
            _sessionFile = sessionFile;
            _proxy = proxy;
            _recordedTestBase = recordedTestBase;
        }

        public static async Task<TestRecording> CreateAsync(RecordedTestMode mode, string sessionFile, TestProxy proxy, RecordedTestBase recordedTestBase)
        {
            var recording = new TestRecording(mode, sessionFile, proxy, recordedTestBase);
            await recording.InitializeProxySettingsAsync();
            return recording;
        }

        internal async Task InitializeProxySettingsAsync()
        {
            var assetsJson = _recordedTestBase.AssetsJsonPath;

            switch (Mode)
            {
                case RecordedTestMode.Record:
                    var recordResponse = await _proxy.Client.StartRecordAsync(new StartInformation(_sessionFile) { XRecordingAssetsFile = assetsJson });
                    RecordingId = recordResponse.Headers.XRecordingId;
                    await AddProxySanitizersAsync();

                    break;
                case RecordedTestMode.Playback:
                    ResponseWithHeaders<IReadOnlyDictionary<string, string>, TestProxyStartPlaybackHeaders> playbackResponse = null;
                    try
                    {
                        playbackResponse = await _proxy.Client.StartPlaybackAsync(new StartInformation(_sessionFile) { XRecordingAssetsFile = assetsJson });
                    }
                    catch (RequestFailedException ex)
                        when (ex.Status == 404)
                    {
                        // We don't throw the exception here because Playback only tests that are testing the
                        // recording infrastructure itself will not have session records.
                        MismatchException = new TestRecordingMismatchException(ex.Message, ex);
                        return;
                    }

                    _variables = new SortedDictionary<string, string>((Dictionary<string, string>)playbackResponse.Value);
                    RecordingId = playbackResponse.Headers.XRecordingId;
                    await AddProxySanitizersAsync();

                    // temporary until Azure.Core fix is shipped that makes HttpWebRequestTransport consistent with HttpClientTransport
                    var excludedHeaders = new List<string>(_recordedTestBase.LegacyExcludedHeaders)
                    {
                        "Content-Type",
                        "Content-Length",
                        "Connection"
                    };

                    await _proxy.Client.AddCustomMatcherAsync(new CustomDefaultMatcher
                    {
                        ExcludedHeaders = string.Join(",", excludedHeaders),
                        IgnoredHeaders = _recordedTestBase.IgnoredHeaders.Count > 0 ? string.Join(",", _recordedTestBase.IgnoredHeaders) : null,
                        IgnoredQueryParameters = _recordedTestBase.IgnoredQueryParameters.Count > 0 ? string.Join(",", _recordedTestBase.IgnoredQueryParameters) : null,
                        CompareBodies = _recordedTestBase.CompareBodies
                    });

                    foreach (HeaderTransform transform in _recordedTestBase.HeaderTransforms)
                    {
                        await _proxy.Client.AddHeaderTransformAsync(transform, RecordingId);
                    }
                    break;
            }
        }

        private async Task AddProxySanitizersAsync()
        {
            foreach (string header in _recordedTestBase.SanitizedHeaders)
            {
                await _proxy.Client.AddHeaderSanitizerAsync(new HeaderRegexSanitizer(header, Sanitized), RecordingId);
            }

            foreach (var header in _recordedTestBase.HeaderRegexSanitizers)
            {
                await _proxy.Client.AddHeaderSanitizerAsync(header, RecordingId);
            }

            foreach (var (header, queryParameter) in _recordedTestBase.SanitizedQueryParametersInHeaders)
            {
                await _proxy.Client.AddHeaderSanitizerAsync(
                    HeaderRegexSanitizer.CreateWithQueryParameter(header, queryParameter, Sanitized),
                    RecordingId);
            }

            foreach (UriRegexSanitizer sanitizer in _recordedTestBase.UriRegexSanitizers)
            {
                await _proxy.Client.AddUriSanitizerAsync(sanitizer, RecordingId);
            }

            foreach (string queryParameter in _recordedTestBase.SanitizedQueryParameters)
            {
                await _proxy.Client.AddUriSanitizerAsync(
                    UriRegexSanitizer.CreateWithQueryParameter(queryParameter, Sanitized),
                    RecordingId);
            }

            foreach (string path in _recordedTestBase.JsonPathSanitizers)
            {
                await _proxy.Client.AddBodyKeySanitizerAsync(new BodyKeySanitizer(Sanitized) { JsonPath = path }, RecordingId);
            }

            foreach (BodyKeySanitizer sanitizer in _recordedTestBase.BodyKeySanitizers)
            {
                await _proxy.Client.AddBodyKeySanitizerAsync(sanitizer, RecordingId);
            }

            foreach (BodyRegexSanitizer sanitizer in _recordedTestBase.BodyRegexSanitizers)
            {
                await _proxy.Client.AddBodyRegexSanitizerAsync(sanitizer, RecordingId);
            }
        }

        public RecordedTestMode Mode { get; }

        private readonly AsyncLocal<EntryRecordModel> _disableRecording = new AsyncLocal<EntryRecordModel>();

        private readonly string _sessionFile;

        internal TestRecordingMismatchException MismatchException;

        private TestRandom _random;

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
        /// The moment in time that this test is being run.
        /// </summary>
        private DateTimeOffset? _now;

        private readonly TestProxy _proxy;
        private readonly RecordedTestBase _recordedTestBase;

        public string RecordingId { get; private set; }

        /// <summary>
        /// Determines if the ClientRequestId that is sent as part of a request while in Record mode
        /// should use the default Guid format. The default Guid format contains hyphens.
        /// </summary>
        public bool UseDefaultGuidFormatForClientRequestId
        {
            get
            {
               return _recordedTestBase.UseDefaultGuidFormatForClientRequestId;
            }
        }

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

        public async ValueTask DisposeAsync(bool save)
        {
            if (Mode == RecordedTestMode.Record)
            {
                await _proxy.Client.StopRecordAsync(RecordingId, Variables, save ? null : "request-response");
            }
            else if (Mode == RecordedTestMode.Playback && HasRequests)
            {
                await _proxy.Client.StopPlaybackAsync(RecordingId);
            }
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
        }

        public HttpPipelineTransport CreateTransport(HttpPipelineTransport currentTransport)
        {
            if (Mode != RecordedTestMode.Live)
            {
                if (currentTransport is ProxyTransport)
                {
                    throw new InvalidOperationException(
                        "The supplied options have already been instrumented. Each test must pass a unique options instance to " +
                        "InstrumentClientOptions.");
                }
                return new ProxyTransport(_proxy, currentTransport, this, () => _disableRecording.Value);
            }

            return currentTransport;
        }

        public string GenerateId()
        {
            return Random.Next().ToString();
        }

        public string GenerateAlphaNumericId(string prefix, int? maxLength = null, bool useOnlyLowercase = false)
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

        public string GenerateId(string prefix, int maxLength)
        {
            var id = $"{prefix}{Random.Next()}";
            return id.Length > maxLength ? id.Substring(0, maxLength) : id;
        }

        public string GenerateAssetName(string prefix, [CallerMemberName] string callerMethodName = "testframework_failed")
        {
            return prefix + Random.Next(9999);
        }

        public string GetVariable(string variableName, string defaultValue, Func<string, string> sanitizer = default)
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
                    Variables.TryGetValue(variableName, out string value);
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

        public void SetVariable(string variableName, string value, Func<string, string> sanitizer = default)
        {
            switch (Mode)
            {
                case RecordedTestMode.Record:
                    Variables[variableName] = sanitizer == default ? value : sanitizer.Invoke(value);
                    break;
                default:
                    break;
            }
        }

        public bool HasRequests { get; internal set; }

        public DisableRecordingScope DisableRecording()
        {
            return new DisableRecordingScope(this, EntryRecordModel.DoNotRecord);
        }

        public DisableRecordingScope DisableRequestBodyRecording()
        {
            return new DisableRecordingScope(this, EntryRecordModel.RecordWithoutRequestBody);
        }

        public struct DisableRecordingScope : IDisposable
        {
            private readonly TestRecording _testRecording;

            public DisableRecordingScope(TestRecording testRecording, EntryRecordModel entryRecordModel)
            {
                _testRecording = testRecording;
                _testRecording._disableRecording.Value = entryRecordModel;
            }

            public void Dispose()
            {
                _testRecording._disableRecording.Value = EntryRecordModel.Record;
            }
        }
    }
}
