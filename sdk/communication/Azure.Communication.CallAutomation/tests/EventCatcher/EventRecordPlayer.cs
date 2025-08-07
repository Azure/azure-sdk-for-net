// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation.Tests.EventCatcher
{
    internal class EventRecordPlayer : IDisposable, IAsyncDisposable
    {
        private static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        private string _sessionFilePath;
        private PersistedEventRecording _recording;
        private SemaphoreSlim? _semaphore;
        private const int MaxDepth = 16;
        public bool IsRecording { get; private set; }
        public IEnumerable<RecordedServiceBusReceivedMessage> Entries => _recording.Entries;

        public List<string> KeysToSanitize { get; } = new List<string>() { "rawId", "id", "botAppId", "ivrContext", "callerDisplayName", "incomingCallContext" };

        public EventRecordPlayer(string sessionFilePath)
        {
            _sessionFilePath = sessionFilePath;
            _recording = new PersistedEventRecording();
        }

        public EventRecordPlayer SetupForRecording()
        {
            IsRecording = true;
            InitializeFile(_sessionFilePath);
            _semaphore = new SemaphoreSlim(1);
            return this;
        }

        public EventRecordPlayer SetupForPlayback()
        {
            LoadEvents();
            return this;
        }

        public void Record(RecordedServiceBusReceivedMessage receivedMessage)
        {
            // maintain order in recording
            _semaphore?.Wait();
            _recording.Entries.Add(receivedMessage);
            _semaphore?.Release();
        }

        private void LoadEvents()
        {
            var recordingExists = File.Exists(_sessionFilePath);
            if (recordingExists)
            {
                Task.Run(async () =>
                {
                    using FileStream openStream =
                        new FileStream(_sessionFilePath, FileMode.Open, FileAccess.Read, FileShare.None);
                    PersistedEventRecording? recording = await JsonSerializer.DeserializeAsync<PersistedEventRecording>(openStream, JsonSerializerOptions);
                    if (recording != null)
                    {
                        _recording = recording;
                    }
                }).Wait();
            }
        }

        private void InitializeFile(string sessionFilePath)
        {
            var recordingExists = File.Exists(sessionFilePath);
            if (recordingExists)
            {
                File.Delete(sessionFilePath);
            }

            InitializeDirectory(sessionFilePath);
            using var fileStream =  File.Create(sessionFilePath);
            fileStream.Dispose();
        }

        private void InitializeDirectory(string sessionFilePath)
        {
            var directoryPath = Path.GetDirectoryName(sessionFilePath);
            var directoryExists = Directory.Exists(directoryPath);
            if (!directoryExists)
            {
                if (directoryPath != null)
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
        }

        /// <inheritdoc />
        public async ValueTask DisposeAsync()
        {
            if (IsRecording)
            {
                using FileStream recorderFileStream = new FileStream(_sessionFilePath, FileMode.Append, FileAccess.Write, FileShare.None);
                var scrubbedRecording = new List<RecordedServiceBusReceivedMessage>();
                _recording.Entries
                    .ForEach(entry =>
                    {
                        entry.Body = SanitizeRecordedEvent(entry.Body);
                        scrubbedRecording.Add(entry);
                    });
                await JsonSerializer.SerializeAsync(recorderFileStream, new PersistedEventRecording(){ Entries = scrubbedRecording }, JsonSerializerOptions);
                recorderFileStream.Dispose();
                _semaphore?.Dispose();
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (IsRecording)
            {
                using FileStream recorderFileStream = new FileStream(_sessionFilePath, FileMode.Append, FileAccess.Write, FileShare.None);
                Task.Run(async () =>
                {
                    var scrubbedRecording = new List<RecordedServiceBusReceivedMessage>();
                    _recording.Entries
                        .ForEach(entry =>
                        {
                            entry.Body = SanitizeRecordedEvent(entry.Body);
                            scrubbedRecording.Add(entry);
                        });
                    await JsonSerializer.SerializeAsync(recorderFileStream, new PersistedEventRecording() { Entries = scrubbedRecording }, JsonSerializerOptions);
                }).Wait();
                recorderFileStream.Dispose();
                _semaphore?.Dispose();
            }
        }

        private string SanitizeRecordedEvent(string message)
        {
            JsonDocument document = JsonDocument.Parse(message);
            var rootElement = document.RootElement;
            switch (rootElement.ValueKind)
            {
                case JsonValueKind.Object:
                    var objEnumerator = document.RootElement.EnumerateObject();
                    var result = new Dictionary<string, object?>();
                    while (objEnumerator.MoveNext())
                    {
                        if (KeysToSanitize.Contains(objEnumerator.Current.Name))
                        {
                            result.Add(objEnumerator.Current.Name, "Sanitized");
                        }
                        else
                        {
                            result.Add(objEnumerator.Current.Name, Scrub(objEnumerator.Current.Value, 0, MaxDepth));
                        }
                    }

                    var resultAsString = JsonSerializer.Serialize(result);
                    return resultAsString;
                case JsonValueKind.Array:
                    var arrayEnumerator = document.RootElement.EnumerateArray();
                    var arrResult = new List<object?>();
                    while (arrayEnumerator.MoveNext())
                    {
                        arrResult.Add(Scrub(arrayEnumerator.Current, 1, MaxDepth));
                    }

                    var arrResultAsString = JsonSerializer.Serialize(arrResult);
                    return arrResultAsString;
                default:
                    return rootElement.GetRawText();
            }
        }

        private object? Scrub(JsonElement element, int depth, int maxDepth)
        {
            if (depth > maxDepth)
                throw new JsonException("Max recursion depth exceeded.");
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    var objEnum = element.EnumerateObject();
                    var obj = new Dictionary<string, object?>();
                    while (objEnum.MoveNext())
                    {
                        var currentName = objEnum.Current.Name;
                        if (KeysToSanitize.Contains(currentName))
                        {
                            obj.Add(objEnum.Current.Name, "Sanitized");
                        }
                        else
                        {
                            obj.Add(objEnum.Current.Name, Scrub(objEnum.Current.Value, depth + 1, maxDepth));
                        }
                    }

                    return obj;
                case JsonValueKind.Array:
                    var arrEnum = element.EnumerateArray();
                    var arr = new List<object?>();
                    while (arrEnum.MoveNext())
                    {
                        arr.Add(Scrub(arrEnum.Current, depth + 1, maxDepth));
                    }

                    return arr;
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    return element.GetDouble();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                default:
                    return null;
            }
        }
    }
}
