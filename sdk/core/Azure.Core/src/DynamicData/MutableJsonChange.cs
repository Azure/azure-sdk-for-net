// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

#nullable enable

namespace Azure.Core.Json
{
    internal struct MutableJsonChange
    {
        public MutableJsonChange(string path,
            int index,
            object? value,
            MutableJsonChangeKind changeKind,
            string? addedPropertyName)
        {
            Path = path;
            Index = index;
            Value = value;
            ChangeKind = changeKind;
            AddedPropertyName = addedPropertyName;
        }

        public string Path { get; }

        public int Index { get; }

        public object? Value { get; }

        public string? AddedPropertyName { get; }

        public MutableJsonChangeKind ChangeKind { get; }

        public readonly JsonValueKind ValueKind => Value switch
        {
            null => JsonValueKind.Null,
            bool b => b ? JsonValueKind.True : JsonValueKind.False,
            string => JsonValueKind.String,
            DateTime => JsonValueKind.String,
            DateTimeOffset => JsonValueKind.String,
            Guid => JsonValueKind.String,
            byte => JsonValueKind.Number,
            sbyte => JsonValueKind.Number,
            short => JsonValueKind.Number,
            ushort => JsonValueKind.Number,
            int => JsonValueKind.Number,
            uint => JsonValueKind.Number,
            long => JsonValueKind.Number,
            ulong => JsonValueKind.Number,
            float => JsonValueKind.Number,
            double => JsonValueKind.Number,
            decimal => JsonValueKind.Number,
            JsonElement e => e.ValueKind,
            _ => throw new InvalidOperationException($"Unrecognized change type '{Value.GetType()}'.")
        };

        internal readonly void EnsureString()
        {
            if (ValueKind != JsonValueKind.String)
            {
                throw new InvalidOperationException($"Expected a 'String' kind but was '{ValueKind}'.");
            }
        }

        internal readonly void EnsureNumber()
        {
            if (ValueKind != JsonValueKind.Number)
            {
                throw new InvalidOperationException($"Expected a 'Number' kind but was '{ValueKind}'.");
            }
        }

        internal readonly void EnsureArray()
        {
            if (ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException($"Expected an 'Array' kind but was '{ValueKind}'.");
            }
        }

        internal readonly int GetArrayLength()
        {
            EnsureArray();

            if (Value is JsonElement e)
            {
                return e.GetArrayLength();
            }

            throw new InvalidOperationException($"Expected an 'Array' kind but was '{ValueKind}'.");
        }

        internal bool IsDescendant(string path)
        {
            return IsDescendant(path.AsSpan());
        }

        internal bool IsDescendant(ReadOnlySpan<char> ancestorPath)
        {
            return IsDescendant(ancestorPath, Path.AsSpan());
        }

        internal static bool IsDescendant(ReadOnlySpan<char> ancestorPath, ReadOnlySpan<char> descendantPath)
        {
            if (ancestorPath.Length == 0)
            {
                return descendantPath.Length > 0;
            }

            return descendantPath.Length > ancestorPath.Length &&
                descendantPath.StartsWith(ancestorPath) &&
                // Restrict matches (e.g. so we don't think 'a' is a parent of 'abc').
                descendantPath[ancestorPath.Length] == MutableJsonDocument.ChangeTracker.Delimiter;
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

        internal bool IsLessThan(ReadOnlySpan<char> otherPath)
        {
            return Path.AsSpan().SequenceCompareTo(otherPath) < 0;
        }

        internal bool IsGreaterThan(ReadOnlySpan<char> otherPath)
        {
            return Path.AsSpan().SequenceCompareTo(otherPath) > 0;
        }

        internal string AsString()
        {
            if (Value is null)
            {
                return "null";
            }

            return Value.ToString()!;
        }

        public override string ToString()
        {
            return $"Path={Path}; Value={Value}; Kind={ValueKind}; ChangeKind={ChangeKind}";
        }
    }
}
