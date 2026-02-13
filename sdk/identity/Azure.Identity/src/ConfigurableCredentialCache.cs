// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Azure.Identity
{
    [Experimental("SCME0002")]
    internal class ConfigurableCredentialCache
    {
        private readonly ConcurrentDictionary<string, ConfigurableCredential> _cache = new();

        public ConfigurableCredential GetOrAdd(string key, Func<ConfigurableCredential> factory)
        {
            return _cache.GetOrAdd(key, _ => factory());
        }

        /// <summary>
        /// Creates a deterministic cache key from the content of an <see cref="IConfigurationSection"/>.
        /// Two sections at different paths but with identical values will produce the same key.
        /// The key is a SHA256 hash to avoid leaking secrets that may be present in configuration values.
        /// </summary>
        internal static string CreateKey(IConfigurationSection section)
        {
            string basePath = section.Path;
            int prefixLength = basePath.Length > 0 ? basePath.Length + 1 : 0; // +1 for the ':' separator

            StringBuilder sb = new();
            foreach (KeyValuePair<string, string> kvp in section.AsEnumerable()
                .Where(kvp => kvp.Value is not null)
                .OrderBy(kvp => kvp.Key, StringComparer.Ordinal))
            {
                string relativeKey = kvp.Key.Length > prefixLength
                    ? kvp.Key.Substring(prefixLength)
                    : string.Empty;

                sb.Append(relativeKey).Append('=').Append(kvp.Value).Append(';');
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
