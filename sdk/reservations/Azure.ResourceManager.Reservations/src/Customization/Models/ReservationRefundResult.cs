// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    // Justification: GA exposed ReservationRefundResult as the body of the synchronous Return
    // operation. The new generator models Return as an LRO whose final state is
    // ReservationOrderResource and never surfaces the RefundResponse body type. This shim
    // reintroduces the GA model so the GA-shape Return overloads can return it.
    public partial class ReservationRefundResult
    {
        internal ReservationRefundResult()
        {
        }

        internal ReservationRefundResult(string id, ReservationRefundResponseProperties properties)
        {
            Id = id;
            Properties = properties;
        }

        public string Id { get; }

        public ReservationRefundResponseProperties Properties { get; }

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
