// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework.Models;
using Azure.Core.Tests.TestFramework;

namespace Azure.Core.TestFramework
{
    public class TestRecording : IDisposable
    {
        private const string RandomSeedVariableKey = "RandomSeed";
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        // cspell: disable-next-line
        private const string charsLower = "abcdefghijklmnopqrstuvwxyz0123456789";
        private const string Sanitized = "Sanitized";
        internal const string DateTimeOffsetNowVariableKey = "DateTimeOffsetNow";
        public SortedDictionary<string, string> Variables { get; } = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public TestRecording(RecordedTestMode mode, string sessionFile, RecordedTestSanitizer sanitizer)
        {
            Mode = mode;
            _sessionFile = sessionFile;
            _sanitizer = sanitizer;
            var options = ClientOptions.Default;
            _testProxyClient = new TestProxyRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), new Uri("https://localhost:5001"));

            switch (Mode)
            {
                case RecordedTestMode.Record:
                    ResponseWithHeaders<TestProxyStartRecordHeaders> recordResponse = _testProxyClient.StartRecord(_sessionFile);
                    RecordingId = recordResponse.Headers.XRecordingId;
                    break;
                case RecordedTestMode.Playback:
                    ResponseWithHeaders<IReadOnlyDictionary<string, string>, TestProxyStartPlaybackHeaders> playbackResponse = _testProxyClient.StartPlayback(_sessionFile);
                    Variables = new SortedDictionary<string, string>((Dictionary<string, string>) playbackResponse.Value);
                    RecordingId = playbackResponse.Headers.XRecordingId;
                    foreach (string header in _sanitizer.SanitizedHeaders)
                    {
                        _testProxyClient.AddHeaderSanitizer(new HeaderRegexSanitizer(header, Sanitized));
                    }

                    foreach (string jsonPath in _sanitizer.JsonPathSanitizers.Select(s => s.JsonPath))
                    {
                        _testProxyClient.AddBodySanitizer(new BodyKeySanitizer(jsonPath, Sanitized));
                    }
                    break;
                case RecordedTestMode.Live:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public RecordedTestMode Mode { get; }

        private readonly AsyncLocal<EntryRecordModel> _disableRecording = new AsyncLocal<EntryRecordModel>();

        private readonly string _sessionFile;

        private readonly RecordedTestSanitizer _sanitizer;

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

        private readonly TestProxyRestClient _testProxyClient;
        public string RecordingId { get; }

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

        public void Dispose(bool save)
        {
            if (Mode == RecordedTestMode.Record && save)
            {
                _testProxyClient.StopRecord(RecordingId, Variables);
            }
        }

        public void Dispose()
        {
            Dispose(true);
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

        // public bool HasRequests => _sessionInternal?.Entries.Count > 0;

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
