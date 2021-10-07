// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.Core.TestFramework
{
    public class RecordSession
    {
        public List<RecordEntry> Entries { get; } = new List<RecordEntry>();

        public SortedDictionary<string, string> Variables { get; } = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        //Used only for deserializing track 1 session record files
        public Dictionary<string, Queue<string>> Names { get; set; } = new Dictionary<string, Queue<string>>();

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

            if (element.TryGetProperty(nameof(Names), out property))
            {
                foreach (JsonProperty item in property.EnumerateObject())
                {
                    var queue = new Queue<string>();
                    foreach (JsonElement subItem in item.Value.EnumerateArray())
                    {
                        queue.Enqueue(subItem.GetString());
                    }
                    session.Names[item.Name] = queue;
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

        public RecordEntry Lookup(RecordEntry requestEntry, RecordMatcher matcher, RecordedTestSanitizer sanitizer)
        {
            sanitizer.Sanitize(requestEntry);

            lock (Entries)
            {
                RecordEntry entry = matcher.FindMatch(requestEntry, Entries);
                Entries.Remove(entry);
                return entry;
            }
        }

        public void Sanitize(RecordedTestSanitizer sanitizer)
        {
            lock (Entries)
            {
                sanitizer.Sanitize(this);
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="RecordSession"/> has any <see cref="Entries"/> or <see cref="Variables"/>.
        /// </summary>
        public bool IsEmpty => Entries.Count == 0 && Variables.Count == 0;
    }
}
