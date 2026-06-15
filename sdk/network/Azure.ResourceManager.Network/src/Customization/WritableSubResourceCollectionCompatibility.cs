// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS0612, CS0618, CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    internal static class WritableSubResourceCollectionCompatibility
    {
        public static IReadOnlyList<WritableSubResource> AsReadOnlyList(IReadOnlyList<NetworkSubResource> source) => source is null ? default : new ReadOnlyNetworkSubResourceList(source);
        public static IReadOnlyList<WritableSubResource> AsReadOnlyList(IReadOnlyList<WritableSubResource> source) => source;
        public static IList<WritableSubResource> AsList(IList<NetworkSubResource> source) => source is null ? default : new NetworkSubResourceList(source);
        public static IList<WritableSubResource> AsList(IList<WritableSubResource> source) => source;
        public static Guid? ParseGuid(string value) => ResourceGuidCompatibility.Parse(value);
        public static Guid? ParseGuid(Guid? value) => value;
        public static Guid? FormatGuid(Guid? value) => value;
        public static Uri ParseUri(string value) => Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out Uri uri) ? uri : default;
        public static Uri ParseUri(Uri value) => value;
        public static Uri FormatUri(Uri value) => value;
        public static BinaryData ParseBinaryData(string value) => value is null ? default : BinaryData.FromString(value);
        public static BinaryData ParseBinaryData(BinaryData value) => value;
        public static BinaryData FormatBinaryData(BinaryData value) => value;

        private static WritableSubResource ToWritable(NetworkSubResource value) => value is null ? default : new WritableSubResource { Id = value.Id };
        private static NetworkSubResource ToNetwork(WritableSubResource value) => value is null ? default : new NetworkSubResource { Id = value.Id };

        private sealed class ReadOnlyNetworkSubResourceList : IReadOnlyList<WritableSubResource>
        {
            private readonly IReadOnlyList<NetworkSubResource> _source;
            public ReadOnlyNetworkSubResourceList(IReadOnlyList<NetworkSubResource> source) => _source = source;
            public int Count => _source.Count;
            public WritableSubResource this[int index] => ToWritable(_source[index]);
            public IEnumerator<WritableSubResource> GetEnumerator()
            {
                foreach (NetworkSubResource item in _source)
                {
                    yield return ToWritable(item);
                }
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private sealed class NetworkSubResourceList : IList<WritableSubResource>
        {
            private readonly IList<NetworkSubResource> _source;
            public NetworkSubResourceList(IList<NetworkSubResource> source) => _source = source;
            public int Count => _source.Count;
            public bool IsReadOnly => _source.IsReadOnly;
            public WritableSubResource this[int index] { get => ToWritable(_source[index]); set => _source[index] = ToNetwork(value); }
            public void Add(WritableSubResource item) => _source.Add(ToNetwork(item));
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
                foreach (NetworkSubResource item in _source)
                {
                    yield return ToWritable(item);
                }
            }
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
            public void Insert(int index, WritableSubResource item) => _source.Insert(index, ToNetwork(item));
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
        }
    }
}

#pragma warning restore CS0612, CS0618, CS1591
