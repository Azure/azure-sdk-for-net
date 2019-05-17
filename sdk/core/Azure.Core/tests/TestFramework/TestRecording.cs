// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class TestRecording
    {
        private const string RandomSeedVariableKey = "RandomSeed";

        public TestRecording(RecordedTestMode mode, string sessionFile, RecordedTestSanitizer sanitizer)
        {
            Mode = mode;
            _sessionFile = sessionFile;
            _sanitizer = sanitizer;
        }

        public RecordedTestMode Mode { get; }

        private readonly string _sessionFile;

        private readonly RecordedTestSanitizer _sanitizer;

        private RecordSession _session;

        private Random _random;

        public Random Random
        {
            get
            {
                if (_random == null)
                {
                    switch (Mode)
                    {
                        case RecordedTestMode.None:
                            _random = new Random();
                            break;
                        case RecordedTestMode.Record:
                            _random = new Random();
                            int seed = _random.Next();
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

        public void Start()
        {
            switch (Mode)
            {
                case RecordedTestMode.Record:
                    _session = new RecordSession();
                    break;
                case RecordedTestMode.Playback:
                    _session = Load();
                    break;
            }
        }

        public void Stop()
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
        public HttpPipelineTransport CreateTransport(HttpPipelineTransport currentTransport)
        {
            switch (Mode)
            {
                case RecordedTestMode.None:
                    return currentTransport;
                case RecordedTestMode.Record:
                    return new RecordTransport(_session, currentTransport);
                case RecordedTestMode.Playback:
                    return new PlaybackTransport(_session, _sanitizer);
                default:
                    throw new ArgumentOutOfRangeException(nameof(Mode), Mode, null);
            }
        }

        public void SetConnectionString(string name, string connectionString)
        {
            ConnectionString s = ConnectionString.Parse(connectionString);
            _sanitizer.SanitizeConnectionString(s);
            _session.Variables[name] = s.ToString();
        }

        public string GetConnectionString(string name)
        {
            return _session.Variables[name];
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
                    SetConnectionString(variableName, environmentVariableValue);
                    return environmentVariableValue;
                case RecordedTestMode.None:
                    return environmentVariableValue;
                case RecordedTestMode.Playback:
                    return GetConnectionString(variableName);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
