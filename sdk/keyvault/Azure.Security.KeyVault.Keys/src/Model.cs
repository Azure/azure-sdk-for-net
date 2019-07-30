// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using System;
using System.IO;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Defines helpers for deserialize and serialize.
    /// </summary>
    public abstract class Model
    {
        internal void Deserialize(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content, default))
            {
                this.ReadProperties(json.RootElement);
            }
        }

        internal ReadOnlyMemory<byte> Serialize()
        {
            var writer = new ArrayBufferWriter<byte>();

            using (var json = new Utf8JsonWriter(writer))
            {
                json.WriteStartObject();

                WriteProperties(json);

                json.WriteEndObject();
                json.Flush();
            }

            return writer.WrittenMemory;
        }

        internal abstract void WriteProperties(Utf8JsonWriter json);

        internal abstract void ReadProperties(JsonElement json);
    }
}
