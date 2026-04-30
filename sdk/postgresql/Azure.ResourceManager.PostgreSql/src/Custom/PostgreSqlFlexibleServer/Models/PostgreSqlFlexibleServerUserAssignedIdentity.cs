// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class PostgreSqlFlexibleServerUserAssignedIdentity
    {
        /// <summary> Represents user assigned identities map. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("userAssignedIdentities")]
        public IDictionary<string, UserAssignedIdentity> UserAssignedIdentities
        {
            get
            {
                if (UserAssignedIdentitiesInternal is null)
                    return null;
                return new UserAssignedIdentitiesDictionary(UserAssignedIdentitiesInternal);
            }
        }

        [CodeGenMember("UserAssignedIdentities")]
        internal IDictionary<string, UserIdentity> UserAssignedIdentitiesInternal { get; }

        private sealed class UserAssignedIdentitiesDictionary : IDictionary<string, UserAssignedIdentity>
        {
            private readonly IDictionary<string, UserIdentity> _inner;

            public UserAssignedIdentitiesDictionary(IDictionary<string, UserIdentity> inner)
            {
                _inner = inner;
            }

            public UserAssignedIdentity this[string key]
            {
                get => _inner.ContainsKey(key) ? new UserAssignedIdentity() : throw new KeyNotFoundException();
                set => _inner[key] = new UserIdentity();
            }

            public ICollection<string> Keys => _inner.Keys;
            public ICollection<UserAssignedIdentity> Values => _inner.Keys.Select(_ => new UserAssignedIdentity()).ToList();
            public int Count => _inner.Count;
            public bool IsReadOnly => _inner.IsReadOnly;

            public void Add(string key, UserAssignedIdentity value) => _inner.Add(key, new UserIdentity());
            public void Add(KeyValuePair<string, UserAssignedIdentity> item) => Add(item.Key, item.Value);
            public void Clear() => _inner.Clear();
            public bool Contains(KeyValuePair<string, UserAssignedIdentity> item) => _inner.ContainsKey(item.Key);
            public bool ContainsKey(string key) => _inner.ContainsKey(key);
            public void CopyTo(KeyValuePair<string, UserAssignedIdentity>[] array, int arrayIndex)
            {
                foreach (var item in this)
                {
                    array[arrayIndex++] = item;
                }
            }
            public IEnumerator<KeyValuePair<string, UserAssignedIdentity>> GetEnumerator() => _inner.Keys.Select(key => new KeyValuePair<string, UserAssignedIdentity>(key, new UserAssignedIdentity())).GetEnumerator();
            public bool Remove(string key) => _inner.Remove(key);
            public bool Remove(KeyValuePair<string, UserAssignedIdentity> item) => _inner.Remove(item.Key);
            public bool TryGetValue(string key, out UserAssignedIdentity value)
            {
                if (_inner.ContainsKey(key))
                {
                    value = new UserAssignedIdentity();
                    return true;
                }
                value = null;
                return false;
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
