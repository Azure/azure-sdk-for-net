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
    public class TestRecording: IDisposable
    {
        private const string RandomSeedVariableKey = "RandomSeed";

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

        private readonly string _sessionFile;

        private readonly RecordedTestSanitizer _sanitizer;

        private readonly RecordMatcher _matcher;

        private RecordSession _session;

        private RecordSession _previousSession;

        private readonly Random _nonReproducibleRandom = new Random();

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

        private RecordSession Load()
        {
            using FileStream fileStream = File.OpenRead(_sessionFile);
            using JsonDocument jsonDocument = JsonDocument.Parse(fileStream);
            return RecordSession.Deserialize(jsonDocument.RootElement);
        }

        public void Dispose()
        {
            if (Mode == RecordedTestMode.Record)
            {
                var directory = Path.GetDirectoryName(_sessionFile);
                Directory.CreateDirectory(directory);

                using FileStream fileStream = File.Create(_sessionFile);
                var utf8JsonWriter = new Utf8JsonWriter(fileStream, new JsonWriterOptions()
                {
                    Indented = true
                });
                _session.Sanitize(_sanitizer);
                _session.Serialize(utf8JsonWriter);
                utf8JsonWriter.Flush();
            }
        }

        public T InstrumentClientOptions<T>(T clientOptions) where T: HttpClientOptions
        {
            clientOptions.Transport = CreateTransport(clientOptions.Transport);
            return clientOptions;
        }

        public HttpPipelineTransport CreateTransport(HttpPipelineTransport currentTransport)
        {
            switch (Mode)
            {
                case RecordedTestMode.Live:
                    return currentTransport;
                case RecordedTestMode.Record:
                    return new RecordTransport(_session, currentTransport, Random);
                case RecordedTestMode.Playback:
                    return new PlaybackTransport(_session, _matcher);
                default:
                    throw new ArgumentOutOfRangeException(nameof(Mode), Mode, null);
            }
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
            public override ValueTask<string> GetTokenAsync(string[] scopes, CancellationToken cancellationToken)
            {
                return new ValueTask<string>(GetToken(scopes, cancellationToken));
            }

            public override string GetToken(string[] scopes, CancellationToken cancellationToken)
            {
                return "TEST TOKEN " + string.Join(",", scopes);
            }
        }
    }
}
