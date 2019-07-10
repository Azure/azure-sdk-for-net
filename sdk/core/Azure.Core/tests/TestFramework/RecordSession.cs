// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core.Http;

namespace Azure.Core.Testing
{
    public class RecordSession
    {
        public List<RecordEntry> Entries { get; } = new List<RecordEntry>();

        public SortedDictionary<string, string> Variables { get; } = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public void Serialize(Utf8JsonWriter jsonWriter)
        {
            jsonWriter.WriteStartObject();
            jsonWriter.WriteStartArray(nameof(Entries));
            foreach (RecordEntry record in Entries)
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
            if (element.TryGetProperty(nameof(Entries), out JsonElement property))
            {
                foreach (JsonElement item in property.EnumerateArray())
                {
                    session.Entries.Add(RecordEntry.Deserialize(item));
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
            lock (Entries)
            {
                Entries.Add(entry);
            }
        }

        public RecordEntry Lookup(Request request, RecordMatcher matcher)
        {
            lock (Entries)
            {
                RecordEntry entry = matcher.FindMatch(request, Entries);
                Entries.Remove(entry);
                return entry;
            }

        }

        public void Sanitize(RecordedTestSanitizer sanitizer)
        {
            lock (Entries)
            {
                foreach (RecordEntry entry in Entries)
                {
                    entry.Sanitize(sanitizer);
                }
            }
        }
    }
}
