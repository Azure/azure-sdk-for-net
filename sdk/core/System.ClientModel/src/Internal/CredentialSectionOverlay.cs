// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace System.ClientModel.Primitives;

/// <summary>
/// Builds a writable <see cref="IConfigurationSection"/> wrapper backed by an
/// in-memory dictionary that is initialized from the original credential
/// section. Writes go to the dictionary; reads return the merged view.
/// Setting a key to <see langword="null"/> removes it (standard
/// <see cref="IConfiguration"/> semantics).
/// </summary>
internal static class CredentialSectionOverlay
{
    public static IConfigurationSection CreateOverlay(IConfigurationSection original)
    {
        var data = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
        if (original is not null)
        {
            CopySection(original, data, string.Empty);
        }
        return new MutableSection(data, string.Empty, key: original?.Key ?? string.Empty);
    }

    private static void CopySection(IConfigurationSection section, Dictionary<string, string?> target, string path)
    {
        string? value = section.Value;
        if (value is not null)
        {
            target[path.Length == 0 ? string.Empty : path] = value;
        }

        foreach (IConfigurationSection child in section.GetChildren())
        {
            string childPath = path.Length == 0 ? child.Key : path + ":" + child.Key;
            CopySection(child, target, childPath);
        }
    }

    private sealed class MutableSection : IConfigurationSection
    {
        private readonly Dictionary<string, string?> _data;
        private readonly string _path;

        public MutableSection(Dictionary<string, string?> data, string path, string key)
        {
            _data = data;
            _path = path;
            Key = key;
        }

        public string Key { get; }

        public string Path => _path;

        public string? Value
        {
            get => _data.TryGetValue(_path, out string? v) ? v : null;
            set
            {
                if (value is null)
                {
                    _data.Remove(_path);
                }
                else
                {
                    _data[_path] = value;
                }
            }
        }

        public string? this[string key]
        {
            get
            {
                string full = Combine(_path, key);
                return _data.TryGetValue(full, out string? v) ? v : null;
            }
            set
            {
                string full = Combine(_path, key);
                if (value is null)
                {
                    _data.Remove(full);
                }
                else
                {
                    _data[full] = value;
                }
            }
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            string prefix = _path.Length == 0 ? string.Empty : _path + ":";
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string key in _data.Keys)
            {
                if (prefix.Length > 0)
                {
                    if (!key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                }
                else if (key.Length == 0)
                {
                    continue;
                }
                string remainder = prefix.Length == 0 ? key : key.Substring(prefix.Length);
                int colon = remainder.IndexOf(':');
                string segment = colon < 0 ? remainder : remainder.Substring(0, colon);
                if (segment.Length == 0)
                {
                    continue;
                }
                if (seen.Add(segment))
                {
                    yield return new MutableSection(_data, Combine(_path, segment), segment);
                }
            }
        }

        public IChangeToken GetReloadToken() => NullChangeToken.Singleton;

        public IConfigurationSection GetSection(string key)
            => new MutableSection(_data, Combine(_path, key), key);

        private static string Combine(string parent, string key)
            => parent.Length == 0 ? key : parent + ":" + key;
    }

    private sealed class NullChangeToken : IChangeToken
    {
        public static readonly NullChangeToken Singleton = new();
        public bool ActiveChangeCallbacks => false;
        public bool HasChanged => false;
        public IDisposable RegisterChangeCallback(Action<object?> callback, object? state) => NullDisposable.Instance;

        private sealed class NullDisposable : IDisposable
        {
            public static readonly NullDisposable Instance = new();
            public void Dispose() { }
        }
    }
}
