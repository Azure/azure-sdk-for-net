// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataBox.Models
{
    public partial class MitigateJobContent : IUtf8JsonSerializable
    {
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(_customerResolutionCode))
            {
                writer.WritePropertyName("customerResolutionCode"u8);
                writer.WriteStringValue(_customerResolutionCode.Value.ToSerialString());
            }
            writer.WritePropertyName("customerResolutionCode"u8);

            writer.WriteStringValue(CustomerResolutionCode.ToSerialString());
            if (Optional.IsCollectionDefined(SerialNumberCustomerResolutionMap))
            {
                writer.WritePropertyName("serialNumberCustomerResolutionMap"u8);
                writer.WriteStartObject();
                foreach (var item in SerialNumberCustomerResolutionMap)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value.ToSerialString());
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
    }
}
