// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Core.Json
{
    internal struct MutableJsonChange
    {
        private readonly JsonSerializerOptions _serializerOptions;

        public MutableJsonChange(string path,
            int index,
            object? value,
            JsonValueKind? valueKind,
            JsonSerializerOptions options,
            // TODO: once proven, reorder parameters
            MutableJsonChangeKind changeKind,
            string? addedPropertyName)
        {
            Path = path;
            Index = index;
            Value = value;
            ValueKind = valueKind;
            _serializerOptions = options;
            ChangeKind = changeKind;
            AddedPropertyName = addedPropertyName;
        }

        public string Path { get; }

        public int Index { get; }

        public object? Value { get; }

        public JsonValueKind? ValueKind { get; }

        public string? AddedPropertyName {  get; }

        public MutableJsonChangeKind ChangeKind {  get; }

        internal bool IsDescendant(string path)
        {
            if (path.Length > 0)
            {
                // Restrict matches (e.g. so we don't think 'a' is a parent of 'abc').
                path += MutableJsonDocument.ChangeTracker.Delimiter;
            }

            return Path.StartsWith(path, StringComparison.Ordinal);
        }

        internal bool IsDirectDescendant(string path)
        {
            if (!IsDescendant(path))
            {
                return false;
            }

            string[] ancestorPath = path.Split(MutableJsonDocument.ChangeTracker.Delimiter);
            int ancestorPathLength = string.IsNullOrEmpty(ancestorPath[0]) ? 0 : ancestorPath.Length;
            int descendantPathLength = Path.Split(MutableJsonDocument.ChangeTracker.Delimiter).Length;

            return ancestorPathLength == (descendantPathLength - 1);
        }

        internal JsonElement AsJsonElement()
        {
            if (Value is JsonElement element)
            {
                return element;
            }

            if (Value is MutableJsonElement mje)
            {
                return mje.GetJsonElement();
            }

            // TODO: Handle other special cases, e.g. JsonDocument and MJD?

            // TODO: If it is a MutableJsonDocument, we need to account for changes
            // TODO: What if it is an object that changes after assignment?

            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(Value, _serializerOptions);
            return JsonDocument.Parse(bytes).RootElement;
        }

        internal string AsString()
        {
            return AsJsonElement().ToString() ?? "null";
        }

        public override string ToString()
        {
            return $"Path={Path}; Value={Value}; Kind={ValueKind}";
        }
    }
}
