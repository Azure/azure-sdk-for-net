// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    public class Page<T> : Model
        where T : Model
    {
        private T[] _items;
        private Uri _nextLink;
        private Func<T> _itemFactory;

        internal Page(Func<T> itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public ReadOnlySpan<T> Items { get => _items.AsSpan(); }

        public Uri NextLink { get => _nextLink; }

        internal override void ReadProperties(JsonElement json)
        {
            if (json.TryGetProperty("value", out JsonElement value))
            {
                _items = new T[value.GetArrayLength()];

                int index = 0;

                foreach (var elem in value.EnumerateArray())
                {
                    _items[index] = _itemFactory();

                    _items[index].ReadProperties(elem);

                    index++;
                }
            }

            if (json.TryGetProperty("nextLink", out JsonElement nextLink))
            {
                var nextLinkUrl = nextLink.GetString();

                if (!string.IsNullOrEmpty(nextLinkUrl))
                {
                    _nextLink = new Uri(nextLinkUrl);
                }
            }
        }

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            // serialization is not needed this type is only in responses 
            throw new NotImplementedException();
        }
    }
}
