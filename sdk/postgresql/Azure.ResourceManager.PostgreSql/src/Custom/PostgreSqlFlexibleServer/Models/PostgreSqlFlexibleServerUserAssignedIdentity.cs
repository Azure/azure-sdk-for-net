// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class PostgreSqlFlexibleServerUserAssignedIdentity
    {
        /// <summary> Map of user assigned managed identities (internal, uses spec type). </summary>
        [CodeGenMember("UserAssignedIdentities")]
        [WirePath("userAssignedIdentities")]
        internal IDictionary<string, UserIdentity> InternalUserAssignedIdentities { get; set; }

        /// <summary> Map of user assigned managed identities. </summary>
        [WirePath("userAssignedIdentities")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, UserAssignedIdentity> UserAssignedIdentities
        {
            get => new UserIdentityDictionaryWrapper(InternalUserAssignedIdentities);
        }

        /// <summary> Wrapper to convert between UserIdentity and UserAssignedIdentity dictionaries. </summary>
        private sealed class UserIdentityDictionaryWrapper : IDictionary<string, UserAssignedIdentity>
        {
            private readonly IDictionary<string, UserIdentity> _inner;

            internal UserIdentityDictionaryWrapper(IDictionary<string, UserIdentity> inner)
            {
                _inner = inner ?? new Dictionary<string, UserIdentity>();
            }

            private static UserAssignedIdentity Convert(UserIdentity u)
            {
                if (u is null) return null;
                var data = ModelReaderWriter.Write(u, new ModelReaderWriterOptions("J"), AzureResourceManagerPostgreSqlContext.Default);
                return ModelReaderWriter.Read<UserAssignedIdentity>(data, new ModelReaderWriterOptions("J"), AzureResourceManagerContext.Default);
            }

            private static UserIdentity ConvertBack(UserAssignedIdentity u)
            {
                if (u is null) return new UserIdentity();
                return new UserIdentity() { PrincipalId = u.PrincipalId?.ToString(), ClientId = u.ClientId?.ToString() };
            }

            public UserAssignedIdentity this[string key]
            {
                get => Convert(_inner[key]);
                set => _inner[key] = ConvertBack(value);
            }

            public ICollection<string> Keys => _inner.Keys;
            public ICollection<UserAssignedIdentity> Values => _inner.Values.Select(Convert).ToList();
            public int Count => _inner.Count;
            public bool IsReadOnly => _inner.IsReadOnly;

            public void Add(string key, UserAssignedIdentity value) => _inner.Add(key, ConvertBack(value));
            public void Add(KeyValuePair<string, UserAssignedIdentity> item) => _inner.Add(item.Key, ConvertBack(item.Value));
            public void Clear() => _inner.Clear();
            public bool Contains(KeyValuePair<string, UserAssignedIdentity> item) => _inner.ContainsKey(item.Key);
            public bool ContainsKey(string key) => _inner.ContainsKey(key);
            public void CopyTo(KeyValuePair<string, UserAssignedIdentity>[] array, int arrayIndex)
            {
                foreach (var kvp in _inner)
                    array[arrayIndex++] = new KeyValuePair<string, UserAssignedIdentity>(kvp.Key, Convert(kvp.Value));
            }
            public IEnumerator<KeyValuePair<string, UserAssignedIdentity>> GetEnumerator() => _inner.Select(kvp => new KeyValuePair<string, UserAssignedIdentity>(kvp.Key, Convert(kvp.Value))).GetEnumerator();
            public bool Remove(string key) => _inner.Remove(key);
            public bool Remove(KeyValuePair<string, UserAssignedIdentity> item) => _inner.Remove(item.Key);
            public bool TryGetValue(string key, out UserAssignedIdentity value)
            {
                if (_inner.TryGetValue(key, out var inner))
                {
                    value = Convert(inner);
                    return true;
                }
                value = default;
                return false;
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
