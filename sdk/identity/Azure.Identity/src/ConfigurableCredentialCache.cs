// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity
{
    [Experimental("SCME0002")]
    internal static class ConfigurableCredentialCache
    {
        private static ConcurrentDictionary<string, ConfigurableCredential>? s_cache;
        private static ConcurrentDictionary<string, ConfigurableCredential> Cache =>
            LazyInitializer.EnsureInitialized(ref s_cache, static () => new ConcurrentDictionary<string, ConfigurableCredential>())!;

        public static ConfigurableCredential GetOrAdd(IConfigurationSection credentialSection, Func<ConfigurableCredential> factory)
        {
            string key = CreateKey(credentialSection);
            return Cache.GetOrAdd(key, _ => factory());
        }

        /// <summary>
        /// Creates a deterministic cache key from the content of an <see cref="IConfigurationSection"/>.
        /// Two sections at different paths but with identical values will produce the same key.
        /// The key is a SHA256 hash to avoid leaking secrets that may be present in configuration values.
        /// </summary>
        private static string CreateKey(IConfigurationSection section)
        {
            string basePath = section.Path;
            int prefixLength = basePath.Length > 0 ? basePath.Length + 1 : 0; // +1 for the ':' separator

            IEnumerable<KeyValuePair<string, string?>> entries = section.AsEnumerable()
                .Where(kvp => kvp.Value is not null)
                .OrderBy(kvp => kvp.Key, StringComparer.Ordinal);

            StringBuilder sb = new();
            foreach (KeyValuePair<string, string?> kvp in entries)
            {
                sb.Append(kvp.Key, prefixLength, kvp.Key.Length - prefixLength);
                sb.Append('=').Append(kvp.Value).Append(';');
            }

            byte[] inputBytes = Encoding.UTF8.GetBytes(sb.ToString());
#if NETSTANDARD2_0
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
#else
            byte[] hash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(hash);
#endif
        }
    }
}
