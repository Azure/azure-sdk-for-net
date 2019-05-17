// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Testing
{
    public class RecordSession
    {
        private readonly List<RecordEntry> _entries = new List<RecordEntry>();

        public SortedDictionary<string, string> Variables { get; } = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public void Serialize(Utf8JsonWriter jsonWriter)
        {
            jsonWriter.WriteStartObject();
            jsonWriter.WriteStartArray(nameof(_entries));
            foreach (RecordEntry record in _entries)
            {
                record.Serialize(jsonWriter);
            }
            jsonWriter.WriteEndArray();

            jsonWriter.WriteStartObject(nameof(Variables));
            foreach (KeyValuePair<string, string> variable in Variables)
            {
                jsonWriter.WriteString(variable.Key, variable.Value);
            }
            jsonWriter.WriteEndObject();

            jsonWriter.WriteEndObject();
        }

        public static RecordSession Deserialize(JsonElement element)
        {
            var session = new RecordSession();
            if (element.TryGetProperty(nameof(_entries), out JsonElement property))
            {
                foreach (JsonElement item in property.EnumerateArray())
                {
                    session._entries.Add(RecordEntry.Deserialize(item));
                }
            }

            if (element.TryGetProperty(nameof(Variables), out property))
            {
                foreach (JsonProperty item in property.EnumerateObject())
                {
                    session.Variables[item.Name] = item.Value.GetString();
                }
            }
            return session;
        }

        public void Record(RecordEntry entry)
        {
            lock (_entries)
            {
                _entries.Add(entry);
            }
        }

        public RecordEntry Lookup(Request request, RecordMatcher matcher)
        {
            lock (_entries)
            {
                var index = matcher.FindMatch(request, _entries);
                if (index == -1)
                {
                    throw new InvalidOperationException($"Unable to find recorded request with method {request.Method} and uri {request.UriBuilder.ToString()}");
                }

                var entry = _entries[index];
                _entries.RemoveAt(index);
                return entry;
            }

        }

        public void Sanitize(RecordedTestSanitizer sanitizer)
        {
            lock (_entries)
            {
                foreach (RecordEntry entry in _entries)
                {
                    entry.Sanitize(sanitizer);
                }
            }
        }
    }
}
