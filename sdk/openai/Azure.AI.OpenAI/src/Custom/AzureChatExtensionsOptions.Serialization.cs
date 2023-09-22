// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    public partial class AzureChatExtensionsOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            // CUSTOM CODE NOTE: dataSources deserialize directly into the parent options payload.
            writer.WritePropertyName("dataSources");
            writer.WriteStartArray();
            foreach (AzureChatExtensionConfiguration dataSource in Extensions)
            {
                (dataSource as IUtf8JsonSerializable).Write(writer);
            }
            writer.WriteEndArray();
        }
    }
}
