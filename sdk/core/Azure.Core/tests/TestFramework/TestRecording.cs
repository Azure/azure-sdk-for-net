// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class TestRecording : IDisposable
    {
        private const string RandomSeedVariableKey = "RandomSeed";
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
                    _session = new RecordSession();
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
                    _session = Load();
                    break;
            }
        }

        public RecordedTestMode Mode { get; }

        private readonly AsyncLocal<bool> _disableRecording = new AsyncLocal<bool>();

        private readonly string _sessionFile;

        private readonly RecordedTestSanitizer _sanitizer;

        private readonly RecordMatcher _matcher;

        private readonly RecordSession _session;

        private RecordSession _previousSession;

        private Random _random;

        public Random Random
        {
            get
            {
                if (_random == null)
                {
                    switch (Mode)
                    {
                        case RecordedTestMode.Live:
                            _random = new Random();
                            break;
                        case RecordedTestMode.Record:
                            // Try get the seed from existing session
                            if (!(_previousSession != null &&
                                  _previousSession.Variables.TryGetValue(RandomSeedVariableKey, out string seedString) &&
                                  int.TryParse(seedString, out int seed)
                                ))
                            {
                                _random = new Random();
                                seed = _random.Next();
                            }
                            _session.Variables[RandomSeedVariableKey] = seed.ToString();
                            _random = new Random(seed);
                            break;
                        case RecordedTestMode.Playback:
                            _random = new Random(int.Parse(_session.Variables[RandomSeedVariableKey]));
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
                            _session.Variables[DateTimeOffsetNowVariableKey] = _now.Value.ToString("O"); // Use the "Round-Trip Format"
                            break;
                        case RecordedTestMode.Playback:
                            _now = DateTimeOffset.Parse(_session.Variables[DateTimeOffsetNowVariableKey]);
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
                var directory = Path.GetDirectoryName(_sessionFile);
                Directory.CreateDirectory(directory);

                _session.Sanitize(_sanitizer);
                if (_session.IsEquivalent(_previousSession, _matcher))
                {
                    return;
                }

                using FileStream fileStream = File.Create(_sessionFile);
                var utf8JsonWriter = new Utf8JsonWriter(fileStream, new JsonWriterOptions()
                {
                    Indented = true
                });
                _session.Serialize(utf8JsonWriter);
                utf8JsonWriter.Flush();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public T InstrumentClientOptions<T>(T clientOptions) where T : ClientOptions
        {
            clientOptions.Transport = CreateTransport(clientOptions.Transport);
            return clientOptions;
        }

        public HttpPipelineTransport CreateTransport(HttpPipelineTransport currentTransport)
        {
            return Mode switch
            {
                RecordedTestMode.Live => currentTransport,
                RecordedTestMode.Record => new RecordTransport(_session, currentTransport, entry => !_disableRecording.Value, Random),
                RecordedTestMode.Playback => new PlaybackTransport(_session, _matcher, Random),
                _ => throw new ArgumentOutOfRangeException(nameof(Mode), Mode, null),
            };
        }

        public string GenerateId()
        {
            return Random.Next().ToString();
        }

        public string GetConnectionStringFromEnvironment(string variableName)
        {
            var environmentVariableValue = Environment.GetEnvironmentVariable(variableName);
            switch (Mode)
            {
                case RecordedTestMode.Record:
                    ConnectionString s = ConnectionString.Parse(environmentVariableValue);
                    _sanitizer.SanitizeConnectionString(s);
                    _session.Variables[variableName] = s.ToString();
                    return environmentVariableValue;
                case RecordedTestMode.Live:
                    return environmentVariableValue;
                case RecordedTestMode.Playback:
                    return _session.Variables[variableName];
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetVariableFromEnvironment(string variableName)
        {
            var environmentVariableValue = Environment.GetEnvironmentVariable(variableName);
            switch (Mode)
            {
                case RecordedTestMode.Record:
                    _session.Variables[variableName] = environmentVariableValue;
                    return environmentVariableValue;
                case RecordedTestMode.Live:
                    return environmentVariableValue;
                case RecordedTestMode.Playback:
                    return _session.Variables[variableName];
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetVariable(string variableName, string defaultValue)
        {
            switch (Mode)
            {
                case RecordedTestMode.Record:
                    _session.Variables[variableName] = defaultValue;
                    return defaultValue;
                case RecordedTestMode.Live:
                    return defaultValue;
                case RecordedTestMode.Playback:
                    return _session.Variables[variableName];
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public TokenCredential GetCredential(TokenCredential defaultCredential)
        {
            return Mode == RecordedTestMode.Playback ? new TestCredential() : defaultCredential;
        }

        public void DisableIdReuse()
        {
            _previousSession = null;
        }

        private class TestCredential : TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken("TEST TOKEN " + string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue);
            }
        }

        public DisableRecordingScope DisableRecording()
        {
            return new DisableRecordingScope(this);
        }

        public struct DisableRecordingScope : IDisposable
        {
            private readonly TestRecording _testRecording;

            public DisableRecordingScope(TestRecording testRecording)
            {
                _testRecording = testRecording;
                _testRecording._disableRecording.Value = true;
            }

            public void Dispose()
            {
                _testRecording._disableRecording.Value = false;
            }
        }
    }
}
