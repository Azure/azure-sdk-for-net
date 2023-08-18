// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable AZC0014 // No STJ in public APIs
    public class ChangeList
    {
        private readonly List<ChangeListChange> _changes;
        private readonly ChangeListElement _rootElement;

        public ChangeList()
        {
            // TODO: allocate lazily
            _changes = new List<ChangeListChange>();

            // TODO: allocate lazily
            _rootElement = new ChangeListElement(this, string.Empty);
        }

        public ChangeListElement RootElement { get => _rootElement; }

        internal void AddChange(string path, object? value)
        {
            _changes.Add(new ChangeListChange(path, value));
        }

        public void WriteMergePatch(Utf8JsonWriter writer)
        {
            // TODO: Write this correctly
            // TODO: Add nesting
            writer.WriteStartObject();
            foreach (ChangeListChange change in _changes)
            {
                writer.WritePropertyName(change.Path);
                WriteValue(writer, change.Value);
            }
            writer.WriteEndObject();
        }

        private static void WriteValue(Utf8JsonWriter writer, object? value)
        {
            switch (value)
            {
                case int i:
                    writer.WriteNumberValue(i);
                    break;
                case string s:
                    writer.WriteStringValue(s);
                    break;
                case DateTimeOffset d:
                    // TODO: use model formatter
                    writer.WriteStringValue(d);
                    break;
                case null:
                    writer.WriteNullValue();
                    break;
                case IChangeWriteable c:
                    c.Write(writer);
                    break;
                default:
                    throw new NotImplementedException($"Unknown value type: '{value.GetType()}'.");
            }
        }
    }
#pragma warning restore AZC0014
#pragma warning restore CS1591
}
