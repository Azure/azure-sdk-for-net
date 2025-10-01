// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    public partial class SettingLabel
    {
        internal static SettingLabel DeserializeLabel(JsonElement element)
        {
            return DeserializeSettingLabel(element, ModelSerializationExtensions.WireOptions);
        }
    }
}
