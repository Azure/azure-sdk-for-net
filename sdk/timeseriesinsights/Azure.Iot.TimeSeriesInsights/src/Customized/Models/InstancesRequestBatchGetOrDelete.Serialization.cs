// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// This class definition overrides serialization implementation in order to turn Time
    /// Series Ids from a strongly typed object to an list of objects that the service can understand.
    /// </summary>
    public partial class InstancesRequestBatchGetOrDelete : IUtf8JsonSerializable
    {
        // This class declaration overrides the logic that serializes the object. More specifically, to
        // serialize "timeSeriesIds". Since TimeSeriesIds changed from a list of objects to a strongly
        // typed object, serialization is handled differently.

        // The use of fully qualified name for IUtf8JsonSerializable is a work around until this
        // issue is fixed: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(TimeSeriesIds))
            {
                writer.WritePropertyName("timeSeriesIds");
                writer.WriteStartArray();
                foreach (TimeSeriesId item in TimeSeriesIds)
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
