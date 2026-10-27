// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Globalization;
using System.Text.Json;
using System.Xml;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    [CodeGenSerialization(nameof(Duration), DeserializationValueHook = nameof(DeserializeDuration))]
    public partial class DataProtectionBackupJobProperties
    {
        private static void DeserializeDuration(JsonProperty property, ref TimeSpan? duration)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }

            string value = property.Value.GetString();
            try
            {
                duration = XmlConvert.ToTimeSpan(value);
            }
            catch (FormatException)
            {
                duration = TimeSpan.ParseExact(value, "c", CultureInfo.InvariantCulture);
            }
        }
    }
}
