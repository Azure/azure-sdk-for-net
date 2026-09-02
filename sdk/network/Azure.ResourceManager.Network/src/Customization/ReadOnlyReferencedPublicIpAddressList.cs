// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    internal sealed class ReadOnlyReferencedPublicIpAddressList : IReadOnlyList<SubResource>
    {
        private readonly IReadOnlyList<ReferencedPublicIpAddress> _source;

        public ReadOnlyReferencedPublicIpAddressList(IReadOnlyList<ReferencedPublicIpAddress> source) => _source = source;

        public int Count => _source.Count;

        public SubResource this[int index] => ToSubResource(_source[index]);

        public IEnumerator<SubResource> GetEnumerator()
        {
            foreach (ReferencedPublicIpAddress item in _source)
            {
                yield return ToSubResource(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static SubResource ToSubResource(ReferencedPublicIpAddress value) => value is null
            ? default
            : new ReferencedSubResource(value.Id is null ? default : new ResourceIdentifier(value.Id));

        private sealed class ReferencedSubResource : SubResource
        {
            public ReferencedSubResource(ResourceIdentifier id) : base(id)
            {
            }
        }
    }
}
