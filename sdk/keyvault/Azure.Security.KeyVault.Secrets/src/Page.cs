// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
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
                if(value.ValueKind != JsonValueKind.Null)
                {
                    _items = new T[value.GetArrayLength()];

                    int i = 0;

                    foreach (var elem in value.EnumerateArray())
                    {
                        _items[i] = _itemFactory();

                        _items[i].ReadProperties(elem);

                        i++;
                    }
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

        internal override void WriteProperties(ref Utf8JsonWriter json)
        {
            // serialization is not needed this type is only in responses
            throw new NotImplementedException();
        }
    }
}
