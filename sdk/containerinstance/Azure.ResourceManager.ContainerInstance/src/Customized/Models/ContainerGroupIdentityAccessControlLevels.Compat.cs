// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

// Backward-compat constructor and property shims for TypeSpec migration (ApiCompat).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupIdentityAccessControlLevels
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupIdentityAccessControlLevels"/> for mocking. </summary>
        public ContainerGroupIdentityAccessControlLevels()
        {
        }

        /// <summary> The default access level. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupIdentityAccessLevel? DefaultAccess
        {
            get => DefaultAccessValue.HasValue ? new ContainerGroupIdentityAccessLevel(DefaultAccessValue.Value.ToString()) : (ContainerGroupIdentityAccessLevel?)null;
            set => DefaultAccessValue = value.HasValue ? new IdentityAccessLevel(value.Value.ToString()) : (IdentityAccessLevel?)null;
        }

        /// <summary> The access control levels for each identity. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ContainerGroupIdentityAccessControl> Acls
        {
            get => new AclListWrapper(AclsInternal);
        }

        private sealed class AclListWrapper : IList<ContainerGroupIdentityAccessControl>
        {
            private readonly IList<IdentityAccessControl> _inner;
            internal AclListWrapper(IList<IdentityAccessControl> inner) => _inner = inner;

            public ContainerGroupIdentityAccessControl this[int index]
            {
                get => _inner[index] is ContainerGroupIdentityAccessControl c ? c : new ContainerGroupIdentityAccessControl();
                set => _inner[index] = value;
            }

            public int Count => _inner.Count;
            public bool IsReadOnly => _inner.IsReadOnly;
            public void Add(ContainerGroupIdentityAccessControl item) => _inner.Add(item);
            public void Clear() => _inner.Clear();
            public bool Contains(ContainerGroupIdentityAccessControl item) => _inner.Contains(item);
            public void CopyTo(ContainerGroupIdentityAccessControl[] array, int arrayIndex)
            {
                for (int i = 0; i < _inner.Count; i++)
                    array[arrayIndex + i] = _inner[i] is ContainerGroupIdentityAccessControl c ? c : new ContainerGroupIdentityAccessControl();
            }
            public int IndexOf(ContainerGroupIdentityAccessControl item) => _inner.IndexOf(item);
            public void Insert(int index, ContainerGroupIdentityAccessControl item) => _inner.Insert(index, item);
            public bool Remove(ContainerGroupIdentityAccessControl item) => _inner.Remove(item);
            public void RemoveAt(int index) => _inner.RemoveAt(index);
            public IEnumerator<ContainerGroupIdentityAccessControl> GetEnumerator()
            {
                foreach (var item in _inner)
                    yield return item is ContainerGroupIdentityAccessControl c ? c : new ContainerGroupIdentityAccessControl();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
