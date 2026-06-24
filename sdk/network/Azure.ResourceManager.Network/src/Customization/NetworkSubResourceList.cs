// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    internal sealed class NetworkSubResourceList : IList<WritableSubResource>
    {
        private readonly IList<NetworkSubResource> _source;

        /// <summary> Initializes a new instance of the NetworkSubResourceList class. </summary>
        public NetworkSubResourceList(IList<NetworkSubResource> source) => _source = source;
        /// <summary> Gets or sets the Count compatibility property. </summary>
        public int Count => _source.Count;
        /// <summary> Gets or sets the IsReadOnly compatibility property. </summary>
        public bool IsReadOnly => _source.IsReadOnly;
        /// <summary> Gets or sets the this compatibility property. </summary>
        public WritableSubResource this[int index] { get => WritableSubResourceCollectionCompatibility.ToWritable(_source[index]); set => _source[index] = WritableSubResourceCollectionCompatibility.ToNetwork(value); }
        /// <summary> Invokes the Add compatibility operation. </summary>
        public void Add(WritableSubResource item) => _source.Add(WritableSubResourceCollectionCompatibility.ToNetwork(item));
        /// <summary> Invokes the Clear compatibility operation. </summary>
        public void Clear() => _source.Clear();
        /// <summary> Invokes the IndexOf compatibility operation. </summary>
        public bool Contains(WritableSubResource item) => IndexOf(item) >= 0;

        /// <summary> Invokes the CopyTo compatibility operation. </summary>
        public void CopyTo(WritableSubResource[] array, int arrayIndex)
        {
            foreach (WritableSubResource item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        /// <summary> Invokes the GetEnumerator compatibility operation. </summary>
        public IEnumerator<WritableSubResource> GetEnumerator()
        {
            foreach (NetworkSubResource item in _source)
            {
                yield return WritableSubResourceCollectionCompatibility.ToWritable(item);
            }
        }

        /// <summary> Invokes the IndexOf compatibility operation. </summary>
        public int IndexOf(WritableSubResource item)
        {
            for (int i = 0; i < _source.Count; i++)
            {
                if (Equals(_source[i]?.Id, item?.Id))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary> Invokes the Insert compatibility operation. </summary>
        public void Insert(int index, WritableSubResource item) => _source.Insert(index, WritableSubResourceCollectionCompatibility.ToNetwork(item));
        /// <summary> Invokes the Remove compatibility operation. </summary>
        public bool Remove(WritableSubResource item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            _source.RemoveAt(index);
            return true;
        }

        /// <summary> Invokes the RemoveAt compatibility operation. </summary>
        public void RemoveAt(int index) => _source.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
