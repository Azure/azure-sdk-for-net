// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// This class definition overrides serialization implementation in order to turn a raw response
    /// from Time Series Insights into a InstancesBatchResponse object.
    /// </summary>
    [CodeGenModel("InstancesBatchResponse")]
    public partial class InstancesBatchResponse
    {
        // The purpose of overriding this method is to protect against an InvalidOperationException
        // that is being thrown by the generated code. More specifically, the exception is being thrown
        // when trying to deserialize the "delete" property. A coveration has started with the Time Series
        // Insights team on take a closer look on the thrown exception.

        internal static InstancesBatchResponse DeserializeInstancesBatchResponse(JsonElement element)
        {
            Optional<IReadOnlyList<InstancesOperationResult>> @get = default;
            Optional<IReadOnlyList<InstancesOperationResult>> put = default;
            Optional<IReadOnlyList<InstancesOperationResult>> update = default;
            Optional<IReadOnlyList<TimeSeriesOperationError>> delete = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("get"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<InstancesOperationResult> array = new List<InstancesOperationResult>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        array.Add(InstancesOperationResult.DeserializeInstancesOperationResult(item));
                    }
                    @get = array;
                    continue;
                }
                if (property.NameEquals("put"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<InstancesOperationResult> array = new List<InstancesOperationResult>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        array.Add(InstancesOperationResult.DeserializeInstancesOperationResult(item));
                    }
                    put = array;
                    continue;
                }
                if (property.NameEquals("update"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<InstancesOperationResult> array = new List<InstancesOperationResult>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        array.Add(InstancesOperationResult.DeserializeInstancesOperationResult(item));
                    }
                    update = array;
                    continue;
                }
                if (property.NameEquals("delete"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<TimeSeriesOperationError> array = new List<TimeSeriesOperationError>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        array.Add(item.ValueKind != JsonValueKind.Null ? TimeSeriesOperationError.DeserializeTimeSeriesOperationError(item) : null);
                    }
                    delete = array;
                    continue;
                }
            }
            return new InstancesBatchResponse(Optional.ToList(@get), Optional.ToList(put), Optional.ToList(update), Optional.ToList(delete));
        }
    }
}
