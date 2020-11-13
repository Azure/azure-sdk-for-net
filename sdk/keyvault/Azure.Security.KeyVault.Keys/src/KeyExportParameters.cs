// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    internal class KeyExportParameters : IJsonSerializable
    {
        private static readonly JsonEncodedText s_environmentPropertyNameBytes = JsonEncodedText.Encode("env");

        internal KeyExportParameters(string environment)
        {
            Environment = environment;
        }

        public string Environment { get; }

        public void WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(s_environmentPropertyNameBytes, Environment);
        }
    }
}
