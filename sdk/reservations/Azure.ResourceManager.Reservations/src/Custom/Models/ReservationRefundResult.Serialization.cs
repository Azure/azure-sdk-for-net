// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Reservations.Models
{
    public partial class ReservationRefundResult
    {
        internal static ReservationRefundResult DeserializeReservationRefundResult(BinaryData data)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            JsonElement element = document.RootElement;
            string id = default;
            ReservationRefundResponseProperties properties = default;
            if (element.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in element.EnumerateObject())
                {
                    if (property.Name == "id" && property.Value.ValueKind == JsonValueKind.String)
                    {
                        id = property.Value.GetString();
                    }
                    else if (property.Name == "properties" && property.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = System.ClientModel.Primitives.ModelReaderWriter.Read<ReservationRefundResponseProperties>(
                            BinaryData.FromString(property.Value.GetRawText()), System.ClientModel.Primitives.ModelReaderWriterOptions.Json, AzureResourceManagerReservationsContext.Default);
                    }
                }
            }
            return new ReservationRefundResult(id, properties);
        }
    }
}
