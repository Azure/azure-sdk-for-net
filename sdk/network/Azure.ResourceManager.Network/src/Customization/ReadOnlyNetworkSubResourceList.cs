// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    internal sealed class ReadOnlyNetworkSubResourceList : IReadOnlyList<WritableSubResource>
    {
        private readonly IReadOnlyList<NetworkSubResource> _source;

        /// <summary> Initializes a new instance of the ReadOnlyNetworkSubResourceList class. </summary>
        public ReadOnlyNetworkSubResourceList(IReadOnlyList<NetworkSubResource> source) => _source = source;
        /// <summary> Gets or sets the Count compatibility property. </summary>
        public int Count => _source.Count;
        /// <summary> Gets or sets the this compatibility property. </summary>
        public WritableSubResource this[int index] => WritableSubResourceCollectionCompatibility.ToWritable(_source[index]);

        /// <summary> Invokes the GetEnumerator compatibility operation. </summary>
        public IEnumerator<WritableSubResource> GetEnumerator()
        {
            foreach (NetworkSubResource item in _source)
            {
                yield return WritableSubResourceCollectionCompatibility.ToWritable(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
