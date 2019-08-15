// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Defines a page in Azure responses.
    /// </summary>
    /// <typeparam name="T">Type of the page content items</typeparam>
    internal class KeyVaultPage<T> : Model
        where T : Model
    {
        private T[] _items;
        private Uri _nextLink;
        private Func<T> _itemFactory;

        internal KeyVaultPage(Func<T> itemFactory)
        {
            _itemFactory = itemFactory;
        }

        /// <summary>
        /// Gets the content items.
        /// </summary>
        public ReadOnlySpan<T> Items { get => _items.AsSpan(); }

        /// <summary>
        /// Gets the link to the next page.
        /// </summary>
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
