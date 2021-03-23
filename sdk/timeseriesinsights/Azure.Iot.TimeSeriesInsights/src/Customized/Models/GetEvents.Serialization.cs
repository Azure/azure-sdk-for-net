// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// This class definition overrides serialization and deserialization implementation in
    /// order to turn Time Series Ids from a strongly typed object to an list of objects that
    /// the service can understand, and vice versa.
    /// </summary>
    public partial class GetEvents : IUtf8JsonSerializable
    {
        // The use of fully qualified name for IUtf8JsonSerializable is a work around until this
        // issue is fixed: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("timeSeriesId");
            writer.WriteStartArray();
            foreach (string item in TimeSeriesId.ToArray())
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("searchSpan");
            writer.WriteObjectValue(SearchSpan);
            if (Optional.IsDefined(Filter))
            {
                writer.WritePropertyName("filter");
                writer.WriteObjectValue(Filter);
            }
            if (Optional.IsCollectionDefined(ProjectedProperties))
            {
                writer.WritePropertyName("projectedProperties");
                writer.WriteStartArray();
                foreach (EventProperty item in ProjectedProperties)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Take))
            {
                writer.WritePropertyName("take");
                writer.WriteNumberValue(Take.Value);
            }
            writer.WriteEndObject();
        }
    }
}
