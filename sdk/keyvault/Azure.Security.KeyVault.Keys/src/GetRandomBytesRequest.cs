// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    internal class GetRandomBytesRequest : IJsonSerializable
    {
        private static readonly JsonEncodedText s_countPropertyNameBytes = JsonEncodedText.Encode("count");

        public GetRandomBytesRequest(int count)
        {
            Count = count;
        }

        public int Count { get; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            json.WriteNumber(s_countPropertyNameBytes, Count);
        }
    }
}
