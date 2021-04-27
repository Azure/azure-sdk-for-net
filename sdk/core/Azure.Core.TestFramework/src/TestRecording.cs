// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Core.Tests.TestFramework;

namespace Azure.Core.TestFramework
{
    public class TestRecording : IDisposable
    {
        private const string RandomSeedVariableKey = "RandomSeed";
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const string charsLower = "abcdefghijklmnopqrstuvwxyz0123456789";
        internal const string DateTimeOffsetNowVariableKey = "DateTimeOffsetNow";

        public TestRecording(RecordedTestMode mode, string sessionFile, RecordedTestSanitizer sanitizer, RecordMatcher matcher)
        {
            Mode = mode;
            _sessionFile = sessionFile;
            _sanitizer = sanitizer;
            _matcher = matcher;

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
                        _mismatchException = new TestRecordingMismatchException(ex.Message, ex);
                    }
                    break;
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
                return _mismatchException switch
                {
                    null => _sessionInternal,
                    _ => throw _mismatchException
                };
            }
            set
            {
                _sessionInternal = value;
            }
        }

        private readonly TestRecordingMismatchException _mismatchException;

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
                            var csp = new RNGCryptoServiceProvider();
                            var bytes = new byte[4];
                            csp.GetBytes(bytes);
                            _random = new TestRandom(Mode, BitConverter.ToInt32(bytes, 0));
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
                            Session.Variables[RandomSeedVariableKey] = seed.ToString();
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
                                _random = new TestRandom(Mode, int.Parse(Session.Variables[RandomSeedVariableKey]));
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
                            Session.Variables[DateTimeOffsetNowVariableKey] = _now.Value.ToString("O"); // Use the "Round-Trip Format"
                            break;
                        case RecordedTestMode.Playback:
                            _now = DateTimeOffset.Parse(Session.Variables[DateTimeOffsetNowVariableKey]);
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

        public void Dispose()
        {
            Dispose(true);
        }

        public HttpPipelineTransport CreateTransport(HttpPipelineTransport currentTransport)
        {
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
            return Session.Entries.FirstOrDefault()?.IsTrack1Recording ?? false;
        }

        public string GetVariable(string variableName, string defaultValue)
        {
            switch (Mode)
            {
                case RecordedTestMode.Record:
                    Session.Variables[variableName] = defaultValue;
                    return defaultValue;
                case RecordedTestMode.Live:
                    return defaultValue;
                case RecordedTestMode.Playback:
                    Session.Variables.TryGetValue(variableName, out string value);
                    return value;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetVariable(string variableName, string value)
        {
            switch (Mode)
            {
                case RecordedTestMode.Record:
                    Session.Variables[variableName] = value;
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
            return new DisableRecordingScope(this, EntryRecordModel.DontRecord);
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
