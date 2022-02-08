// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;
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

        public SortedDictionary<string, string> Variables => _useLegacyTransport ? Session.Variables : _variables;
        private SortedDictionary<string, string> _variables = new();

        public TestRecording(RecordedTestMode mode, string sessionFile, RecordedTestSanitizer sanitizer, RecordMatcher matcher, TestProxy proxy = default, bool useLegacyTransport = false)
        {
            Mode = mode;
            _sessionFile = sessionFile;
            _sanitizer = sanitizer;
            _matcher = matcher;

            _useLegacyTransport = useLegacyTransport;
            _proxy = proxy;

            if (_useLegacyTransport)
            {
                switch (Mode)
                {
                    case RecordedTestMode.Record:
                        Session = new RecordSession();
                        if (File.Exists(_sessionFile))
                        {
                            try
                            {
                                _previousSession = Load();
                            }
                            catch (Exception)
                            {
                                // ignore
                            }
                        }

                        break;
                    case RecordedTestMode.Playback:
                        try
                        {
                            Session = Load();
                        }
                        catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                        {
                            MismatchException = new TestRecordingMismatchException(ex.Message, ex);
                        }

                        break;
                }
            }
        }

        internal async Task InitializeProxySettingsAsync()
        {
            if (_useLegacyTransport)
            {
                return;
            }

            switch (Mode)
            {
                case RecordedTestMode.Record:
                    var recordResponse = await _proxy.Client.StartRecordAsync(new StartInformation(_sessionFile));
                    RecordingId = recordResponse.Headers.XRecordingId;
                    await AddProxySanitizersAsync();

                    break;
                case RecordedTestMode.Playback:
                    ResponseWithHeaders<IReadOnlyDictionary<string, string>, TestProxyStartPlaybackHeaders> playbackResponse = null;
                    try
                    {
                        playbackResponse = await _proxy.Client.StartPlaybackAsync(new StartInformation(_sessionFile));
                    }
                    catch (RequestFailedException ex)
                        when (ex.Status == 404)
                    {
                        MismatchException = new TestRecordingMismatchException(ex.Message, ex);
                        return;
                    }

                    _variables = new SortedDictionary<string, string>((Dictionary<string, string>)playbackResponse.Value);
                    RecordingId = playbackResponse.Headers.XRecordingId;
                    await AddProxySanitizersAsync();

                    // temporary until Azure.Core fix is shipped that makes HttpWebRequestTransport consistent with HttpClientTransport
                    // if (!_matcher.CompareBodies)
                    // {
                    //     _proxy.Client.AddBodilessMatcher(RecordingId);
                    // }
                    var excludedHeaders = new List<string>(_matcher.LegacyExcludedHeaders)
                    {
                        "Content-Type",
                        "Content-Length",
                        "Connection"
                    };

                    await _proxy.Client.AddCustomMatcherAsync(new CustomDefaultMatcher
                    {
                        ExcludedHeaders = string.Join(",", excludedHeaders),
                        IgnoredHeaders = _matcher.IgnoredHeaders.Count > 0 ? string.Join(",", _matcher.IgnoredHeaders) : null,
                        IgnoredQueryParameters = _matcher.IgnoredQueryParameters.Count > 0 ? string.Join(",", _matcher.IgnoredQueryParameters): null,
                        CompareBodies = _matcher.CompareBodies
                    });

                    foreach (HeaderTransform transform in _sanitizer.HeaderTransforms)
                    {
                        await _proxy.Client.AddHeaderTransformAsync(transform, RecordingId);
                    }
                    break;
            }
        }

        private async Task AddProxySanitizersAsync()
        {
            foreach (string header in _sanitizer.SanitizedHeaders)
            {
                await _proxy.Client.AddHeaderSanitizerAsync(new HeaderRegexSanitizer(header, Sanitized), RecordingId);
            }

            foreach (var header in _sanitizer.HeaderRegexSanitizers)
            {
                await _proxy.Client.AddHeaderSanitizerAsync(header, RecordingId);
            }

            foreach (string jsonPath in _sanitizer.JsonPathSanitizers.Select(s => s.JsonPath))
            {
                await _proxy.Client.AddBodyKeySanitizerAsync(new BodyKeySanitizer(Sanitized) { JsonPath = jsonPath }, RecordingId);
            }

            foreach (UriRegexSanitizer sanitizer in _sanitizer.UriRegexSanitizers)
            {
                await _proxy.Client.AddUriSanitizerAsync(sanitizer, RecordingId);
            }

            foreach (BodyKeySanitizer sanitizer in _sanitizer.BodyKeySanitizers)
            {
                await _proxy.Client.AddBodyKeySanitizerAsync(sanitizer, RecordingId);
            }

            foreach (BodyRegexSanitizer sanitizer in _sanitizer.BodyRegexSanitizers)
            {
                await _proxy.Client.AddBodyRegexSanitizerAsync(sanitizer, RecordingId);
            }
        }

        public RecordedTestMode Mode { get; }

        private readonly AsyncLocal<EntryRecordModel> _disableRecording = new AsyncLocal<EntryRecordModel>();

        private readonly string _sessionFile;

        private readonly RecordedTestSanitizer _sanitizer;

        private readonly RecordMatcher _matcher;
        private RecordSession _sessionInternal;
        private RecordSession Session
        {
            get
            {
                return MismatchException switch
                {
                    null => _sessionInternal,
                    _ => throw MismatchException
                };
            }
            set
            {
                _sessionInternal = value;
            }
        }

        internal TestRecordingMismatchException MismatchException;

        private RecordSession _previousSession;

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
                            // Try get the seed from existing session
                            if (!(_previousSession != null &&
                                  _previousSession.Variables.TryGetValue(RandomSeedVariableKey, out string seedString) &&
                                  int.TryParse(seedString, out int seed)
                                ))
                            {
                                _random = new TestRandom(Mode);
                                seed = _random.Next();
                            }
                            Variables[RandomSeedVariableKey] = seed.ToString();
                            _random = new TestRandom(Mode, seed);
                            break;
                        case RecordedTestMode.Playback:
                            if (IsTrack1SessionRecord())
                            {
                                //random is not really used for track 1 playback, so randomly pick one as seed
                                _random = new TestRandom(Mode, (int)DateTime.UtcNow.Ticks);
                            }
                            else
                            {
                                _random = new TestRandom(Mode, int.Parse(Variables[RandomSeedVariableKey]));
                            }

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

        private readonly bool _useLegacyTransport;

        private readonly TestProxy _proxy;

        public string RecordingId { get; private set; }

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

        private RecordSession Load()
        {
            using FileStream fileStream = File.OpenRead(_sessionFile);
            using JsonDocument jsonDocument = JsonDocument.Parse(fileStream);
            return RecordSession.Deserialize(jsonDocument.RootElement);
        }

        public async ValueTask DisposeAsync(bool save)
        {
            if (_useLegacyTransport)
            {
                if (Mode == RecordedTestMode.Record && save && !Session.IsEmpty)
                {
                    var directory = Path.GetDirectoryName(_sessionFile);
                    Directory.CreateDirectory(directory);

                    Session.Sanitize(_sanitizer);

                    using FileStream fileStream = File.Create(_sessionFile);
                    var utf8JsonWriter = new Utf8JsonWriter(fileStream, new JsonWriterOptions()
                    {
                        Indented = true
                    });
                    Session.Serialize(utf8JsonWriter);
                    utf8JsonWriter.Flush();
                }
            }

            else if (Mode == RecordedTestMode.Record && save)
            {
                await _proxy.Client.StopRecordAsync(RecordingId, Variables);
            }
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
        }

        public HttpPipelineTransport CreateTransport(HttpPipelineTransport currentTransport)
        {
            if (!_useLegacyTransport && Mode != RecordedTestMode.Live)
            {
                return new ProxyTransport(_proxy, currentTransport, this, () => _disableRecording.Value);
            }
            return Mode switch
            {
                RecordedTestMode.Live => currentTransport,
                RecordedTestMode.Record => new RecordTransport(Session, currentTransport, entry => _disableRecording.Value, Random),
                RecordedTestMode.Playback => new PlaybackTransport(Session, _matcher, _sanitizer, Random,
                    entry => _disableRecording.Value == EntryRecordModel.RecordWithoutRequestBody),
                _ => throw new ArgumentOutOfRangeException(nameof(Mode), Mode, null),
            };
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
            if (Mode == RecordedTestMode.Playback && IsTrack1SessionRecord())
            {
                return Session.Names[callerMethodName].Dequeue();
            }
            else
            {
                return prefix + Random.Next(9999);
            }
        }

        public bool IsTrack1SessionRecord()
        {
            return Session?.Entries.FirstOrDefault()?.IsTrack1Recording ?? false;
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
                    if (Variables.Count == 0)
                    {
                        throw new TestRecordingMismatchException("The recording contains no variables.");
                    }
                    Variables.TryGetValue(variableName, out string value);
                    return value;
                default:
                    throw new ArgumentOutOfRangeException();
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

        public void DisableIdReuse()
        {
            _previousSession = null;
        }

        public bool HasRequests => _sessionInternal?.Entries.Count > 0;

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
