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

        public bool IsEquivalent(RecordSession session, RecordMatcher matcher)
        {
            if (session == null)
            {
                return false;
            }

            // The DateTimeOffsetNow variable is updated any time it's used so
            // we only care that both sessions use it or both sessions don't.
            var now = TestRecording.DateTimeOffsetNowVariableKey;
            return session.Variables.TryGetValue(now, out string _) == Variables.TryGetValue(now, out string _) &&
                   session.Variables.Where(v => v.Key != now).SequenceEqual(Variables.Where(v => v.Key != now)) &&
                   session.Entries.SequenceEqual(Entries, new EntryEquivalentComparer(matcher));
        }

        private class EntryEquivalentComparer : IEqualityComparer<RecordEntry>
        {
            private readonly RecordMatcher _matcher;

            public EntryEquivalentComparer(RecordMatcher matcher)
            {
                _matcher = matcher;
            }

            public bool Equals(RecordEntry x, RecordEntry y)
            {
                return _matcher.IsEquivalentRecord(x, y);
            }

            public int GetHashCode(RecordEntry obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
