// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable SCME0001

namespace Azure.AI.Projects.OpenAI;

public partial class ExtraDataDictionary : IDictionary<string, BinaryData>
{
    private readonly ResponseCreationOptions _parentOptions;
    private readonly ReadOnlyMemory<byte> _rootPathBytes;

    internal ExtraDataDictionary()
    {
    }

    internal ExtraDataDictionary(ResponseCreationOptions parentOptions, ReadOnlySpan<byte> rootPathBytes)
    {
        _parentOptions = parentOptions;
        _rootPathBytes = new(rootPathBytes.ToArray());
    }

    public BinaryData this[string key]
    {
        get => TryGetValue(key, out BinaryData value) ? value : throw new KeyNotFoundException();
        set => _parentOptions.Patch.Set(GetPathBytes(key), value);
    }

    public BinaryData this[ReadOnlySpan<byte> key]
    {
        get => TryGetValue(key, out BinaryData value) ? value : throw new KeyNotFoundException();
        set => _parentOptions.Patch.Set(GetPathBytes(key), value);
    }

    public ICollection<string> Keys => GetFullParsedDictionary().Keys;

    public ICollection<BinaryData> Values => GetFullParsedDictionary().Values;

    public int Count => GetFullParsedDictionary().Count;

    public bool IsReadOnly => false;

    public void Add(string key, BinaryData value) => this[key] = value;

    public void Add(KeyValuePair<string, BinaryData> item) => this[item.Key] = item.Value;

    public void Add(string key, string value) => this[key] = BinaryData.FromString(JsonValue.Create(value).ToJsonString());

    public void Add(string key, int value) => this[key] = BinaryData.FromString($"{value}");

    public void Add(string key, bool value) => this[key] = BinaryData.FromString($"{value}".ToLowerInvariant());

    public void Clear()
    {
        foreach (string key in Keys)
        {
            Remove(key);
        }
    }

    public bool Contains(KeyValuePair<string, BinaryData> item) => TryGetValue(item.Key, out BinaryData value) && item.Value == value;

    public bool ContainsKey(string key) => TryGetValue(key, out var _);

    public void CopyTo(KeyValuePair<string, BinaryData>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    IEnumerator<KeyValuePair<string, BinaryData>> IEnumerable<KeyValuePair<string, BinaryData>>.GetEnumerator() => GetFullParsedDictionary().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetFullParsedDictionary().GetEnumerator();

    public bool Remove(string key)
    {
        if (TryGetValue(key, out var _))
        {
            _parentOptions.Patch.Remove(GetPathBytes(key));
            return true;
        }
        return false;
    }

    public bool Remove(KeyValuePair<string, BinaryData> item) => Remove(item.Key);

    public bool TryGetValue(ReadOnlySpan<byte> key, out BinaryData value)
    {
        // Try/catch: temporary SCM 1.8.0 workaround for TryGetJson
        try
        {
            if (_parentOptions.Patch.TryGetJson(GetPathBytes(key), out ReadOnlyMemory<byte> jsonValueBytes)
                && !jsonValueBytes.IsEmpty)
            {
                value = BinaryData.FromBytes(jsonValueBytes);
                return true;
            }
        }
        catch { }
        value = null;
        return false;
    }

    public bool TryGetValue(string key, out BinaryData value)
        => TryGetValue(Encoding.UTF8.GetBytes(key), out value);

    private Dictionary<string, BinaryData> GetFullParsedDictionary()
    {
        ReadOnlySpan<byte> rootPathBytes = GetPathBytes();
        Dictionary<string, BinaryData> result = new();
        if (_parentOptions.Patch.Contains(rootPathBytes)
            && !_parentOptions.Patch.IsRemoved(rootPathBytes)
            && _parentOptions.Patch.TryGetJson(rootPathBytes, out ReadOnlyMemory<byte> jsonValueBytes)
            && !jsonValueBytes.IsEmpty)
        {
            try
            {
                using JsonDocument document = JsonDocument.Parse(jsonValueBytes);
                if (document.RootElement.ValueKind == JsonValueKind.Object)
                {
                    foreach (JsonProperty property in document.RootElement.EnumerateObject())
                    {
                        result.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    }
                }
            }
            catch (JsonException)
            { }
        }
        return result;
    }

    private ReadOnlySpan<byte> GetPathBytes(string subPath = null)
        => subPath is null ? _rootPathBytes.Span : GetPathBytes(Encoding.UTF8.GetBytes(subPath));

    private ReadOnlySpan<byte> GetPathBytes(ReadOnlySpan<byte> subPathSpan)
    {
        if (subPathSpan.IsEmpty)
        {
            return _rootPathBytes.Span;
        }

        ReadOnlySpan<byte> indexerStartSpan = "['"u8;
        ReadOnlySpan<byte> indexerEndSpan = "']"u8;

        Span<byte> concatenatedSpan = new byte[_rootPathBytes.Length + indexerStartSpan.Length + subPathSpan.Length + indexerEndSpan.Length].AsSpan();

        _rootPathBytes.Span.CopyTo(concatenatedSpan);
        indexerStartSpan.CopyTo(concatenatedSpan.Slice(_rootPathBytes.Length));
        subPathSpan.CopyTo(concatenatedSpan.Slice(_rootPathBytes.Length + indexerStartSpan.Length));
        indexerEndSpan.CopyTo(concatenatedSpan.Slice(_rootPathBytes.Length + indexerStartSpan.Length + subPathSpan.Length));

        return concatenatedSpan;
    }
}
