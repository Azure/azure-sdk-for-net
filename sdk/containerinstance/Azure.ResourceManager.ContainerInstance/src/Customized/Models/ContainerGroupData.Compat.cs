// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;
using Azure.ResourceManager.Models;

// Backward-compat constructor and property shims for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance
{
    public partial class ContainerGroupData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers)
            : this(default, default, default, default, default, location, default, default, default, default)
        {
        }

        /// <summary> Initializes a new instance of <see cref="ContainerGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers. </param>
        /// <param name="osType"> The operating system type. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers, ContainerInstanceOperatingSystemType osType)
            : this(default, default, default, default, default, location, default, default, default, default)
        {
        }

        /// <summary> The IP address of the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupIPAddress IPAddress { get => IpAddress; set => IpAddress = value; }

        /// <summary> The operating system type required by the containers in the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceOperatingSystemType OSType
        {
            get => OsType ?? default;
            set => OsType = value;
        }

        /// <summary> The operating system type required by the containers in the container group (nullable). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceOperatingSystemType? ContainerGroupOSType { get => OsType; set => OsType = value; }

        /// <summary> The provisioning state of the container group (typed). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupProvisioningState? ContainerGroupProvisioningState
        {
            get
            {
                var state = Properties?.ProvisioningState;
                return state != null ? new ContainerGroupProvisioningState(state) : null;
            }
        }

        /// <summary> The provisioning state of the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => Properties?.ProvisioningState;

        /// <summary> The identity of the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedServiceIdentity Identity
        {
            get => null;
            set { }
        }

        /// <summary> The init containers for a container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<InitContainerDefinitionContent> InitContainers
        {
            get
            {
                if (Properties is null)
                    Properties = new ContainerGroupPropertiesProperties();
                return new InitContainerListWrapper(Properties.InitContainers);
            }
        }

        private sealed class InitContainerListWrapper : IList<InitContainerDefinitionContent>
        {
            private readonly IList<InitContainerDefinition> _inner;
            internal InitContainerListWrapper(IList<InitContainerDefinition> inner) => _inner = inner;

            public InitContainerDefinitionContent this[int index]
            {
                get => _inner[index] is InitContainerDefinitionContent c ? c : WrapItem(_inner[index]);
                set => _inner[index] = value;
            }

            public int Count => _inner.Count;
            public bool IsReadOnly => _inner.IsReadOnly;
            public void Add(InitContainerDefinitionContent item) => _inner.Add(item);
            public void Clear() => _inner.Clear();
            public bool Contains(InitContainerDefinitionContent item) => _inner.Contains(item);
            public void CopyTo(InitContainerDefinitionContent[] array, int arrayIndex)
            {
                for (int i = 0; i < _inner.Count; i++)
                    array[arrayIndex + i] = _inner[i] is InitContainerDefinitionContent c ? c : WrapItem(_inner[i]);
            }
            public int IndexOf(InitContainerDefinitionContent item) => _inner.IndexOf(item);
            public void Insert(int index, InitContainerDefinitionContent item) => _inner.Insert(index, item);
            public bool Remove(InitContainerDefinitionContent item) => _inner.Remove(item);
            public void RemoveAt(int index) => _inner.RemoveAt(index);
            public IEnumerator<InitContainerDefinitionContent> GetEnumerator()
            {
                foreach (var item in _inner)
                    yield return item is InitContainerDefinitionContent c ? c : WrapItem(item);
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

            private static InitContainerDefinitionContent WrapItem(InitContainerDefinition item)
                => new InitContainerDefinitionContent(item.Name);
        }
    }
}
