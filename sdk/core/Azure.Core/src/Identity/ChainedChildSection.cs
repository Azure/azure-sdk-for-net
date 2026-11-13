// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Azure.Identity
{
    /// <summary>
    /// Wraps a credential <see cref="IConfigurationSection"/> and overlays
    /// <see cref="TokenCredentialOptions.IsChainedCredential"/> = <c>"true"</c>.
    /// Used by <see cref="AzureCredentialResolver"/> when handing a
    /// <c>Sources[]</c> entry to a third-party resolver so that resolver builds
    /// a credential which surfaces transient failures as
    /// <c>CredentialUnavailableException</c> (required for
    /// <c>ChainedTokenCredential</c> fall-through).
    /// </summary>
    /// <remarks>
    /// The overlay is surfaced through both the indexer and <see cref="GetChildren"/>
    /// so it is visible to the resolver engine's section-content cache key. A view
    /// that only intercepted the indexer would hash identically to the unwrapped
    /// section and let the cache return a non-chained provider for a chained entry.
    /// </remarks>
    internal sealed class ChainedChildSection : IConfigurationSection
    {
        private const string ChainedKey = nameof(TokenCredentialOptions.IsChainedCredential);

        private readonly IConfigurationSection _inner;

        public ChainedChildSection(IConfigurationSection inner)
        {
            _inner = inner;
        }

        public string Key => _inner.Key;

        public string Path => _inner.Path;

        public string? Value
        {
            get => _inner.Value;
            set => _inner.Value = value;
        }

        public string? this[string key]
        {
            get => string.Equals(key, ChainedKey, StringComparison.OrdinalIgnoreCase) ? "true" : _inner[key];
            set => _inner[key] = value;
        }

        public IConfigurationSection GetSection(string key)
            => string.Equals(key, ChainedKey, StringComparison.OrdinalIgnoreCase)
                ? new LeafSection(ChainedKey, Combine(_inner.Path, ChainedKey), "true")
                : _inner.GetSection(key);

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            bool overlaid = false;
            foreach (IConfigurationSection child in _inner.GetChildren())
            {
                if (string.Equals(child.Key, ChainedKey, StringComparison.OrdinalIgnoreCase))
                {
                    overlaid = true;
                    yield return new LeafSection(child.Key, child.Path, "true");
                }
                else
                {
                    yield return child;
                }
            }

            if (!overlaid)
            {
                yield return new LeafSection(ChainedKey, Combine(_inner.Path, ChainedKey), "true");
            }
        }

        public IChangeToken GetReloadToken() => _inner.GetReloadToken();

        private static string Combine(string parent, string key)
            => string.IsNullOrEmpty(parent) ? key : parent + ":" + key;

        private sealed class LeafSection : IConfigurationSection
        {
            public LeafSection(string key, string path, string? value)
            {
                Key = key;
                Path = path;
                Value = value;
            }

            public string Key { get; }

            public string Path { get; }

            public string? Value { get; set; }

            public string? this[string key]
            {
                get => null;
                set => throw new NotSupportedException();
            }

            public IConfigurationSection GetSection(string key)
                => new LeafSection(key, string.IsNullOrEmpty(Path) ? key : Path + ":" + key, null);

            public IEnumerable<IConfigurationSection> GetChildren() => Array.Empty<IConfigurationSection>();

            public IChangeToken GetReloadToken() => NullChangeToken.Instance;
        }

        private sealed class NullChangeToken : IChangeToken
        {
            public static readonly NullChangeToken Instance = new();

            public bool HasChanged => false;

            public bool ActiveChangeCallbacks => false;

            public IDisposable RegisterChangeCallback(Action<object?> callback, object? state) => NullDisposable.Instance;

            private sealed class NullDisposable : IDisposable
            {
                public static readonly NullDisposable Instance = new();

                public void Dispose()
                {
                }
            }
        }
    }
}
