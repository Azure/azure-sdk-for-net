// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns
{
    internal sealed class DnsSubResourceInfoList : IList<WritableSubResource>
    {
        private readonly IList<DnsSubResourceInfo> _source;

        public DnsSubResourceInfoList(IList<DnsSubResourceInfo> source) => _source = source;

        public int Count => _source.Count;

        public bool IsReadOnly => _source.IsReadOnly;

        public WritableSubResource this[int index]
        {
            get => ToWritableSubResource(_source[index]);
            set => _source[index] = ToDnsSubResourceInfo(value);
        }

        public void Add(WritableSubResource item) => _source.Add(ToDnsSubResourceInfo(item));

        public void Clear() => _source.Clear();

        public bool Contains(WritableSubResource item) => IndexOf(item) >= 0;

        public void CopyTo(WritableSubResource[] array, int arrayIndex)
        {
            foreach (WritableSubResource item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        public IEnumerator<WritableSubResource> GetEnumerator()
        {
            foreach (DnsSubResourceInfo item in _source)
            {
                yield return ToWritableSubResource(item);
            }
        }

        public int IndexOf(WritableSubResource item)
        {
            for (int i = 0; i < _source.Count; i++)
            {
                if (Equals(ToWritableSubResource(_source[i])?.Id, item?.Id))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, WritableSubResource item) => _source.Insert(index, ToDnsSubResourceInfo(item));

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

        public void RemoveAt(int index) => _source.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static WritableSubResource ToWritableSubResource(DnsSubResourceInfo value)
            => value is null ? default : new WritableSubResource { Id = value.Id };

        private static DnsSubResourceInfo ToDnsSubResourceInfo(WritableSubResource value)
            => value is null ? default : new DnsSubResourceInfo { Id = value.Id };
    }
}
