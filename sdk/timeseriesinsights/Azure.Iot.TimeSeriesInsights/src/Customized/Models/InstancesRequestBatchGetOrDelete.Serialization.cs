// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// foo.
    /// </summary>
    public partial class InstancesRequestBatchGetOrDelete : IUtf8JsonSerializable
    {
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(TimeSeriesIds))
            {
                writer.WritePropertyName("timeSeriesIds");
                writer.WriteStartArray();
                foreach (var item in TimeSeriesIds)
                {
                    writer.WriteStartArray();
                    foreach (var item0 in item.ToArray())
                    {
                        writer.WriteObjectValue(item0);
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Names))
            {
                writer.WritePropertyName("names");
                writer.WriteStartArray();
                foreach (var item in Names)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
    }
}
