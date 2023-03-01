// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Data.AppConfiguration
{
    internal class ConfigurationSettingJsonConverter : JsonConverter<ConfigurationSetting>
    {
        public override ConfigurationSetting Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return ConfigurationServiceSerializer.ReadSetting(ref reader);
        }

        public override void Write(Utf8JsonWriter writer, ConfigurationSetting value, JsonSerializerOptions options)
        {
            ConfigurationServiceSerializer.WriteSetting(writer, value);
        }
    }
}
