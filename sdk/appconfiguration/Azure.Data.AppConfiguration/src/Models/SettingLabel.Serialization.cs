// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    public partial class SettingLabel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, ModelSerializationExtensions.WireOptions);
            writer.WriteEndObject();
        }

        internal static SettingLabel DeserializeLabel(JsonElement element)
        {
            return DeserializeSettingLabel(element, ModelSerializationExtensions.WireOptions);
        }
    }
}
