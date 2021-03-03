// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Iot.TimeSeriesInsights;

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// This class definition overrides serialization implementation in order to turn a raw response
    /// from Time Series insights into a <see cref="InstancesBatchResponse"/> object.
    /// </summary>
    [CodeGenModel("InstancesBatchResponse")]
    public partial class InstancesBatchResponse
    {
        internal static InstancesBatchResponse DeserializeInstancesBatchResponse(JsonElement element)
        {
            Optional<IReadOnlyList<InstancesOperationResult>> @get = default;
            Optional<IReadOnlyList<InstancesOperationResult>> put = default;
            Optional<IReadOnlyList<InstancesOperationResult>> update = default;
            Optional<IReadOnlyList<InstancesOperationError>> delete = default;
            foreach (var property in element.EnumerateObject())
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
                    List<InstancesOperationError> array = new List<InstancesOperationError>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        array.Add(item.ValueKind != JsonValueKind.Null ? InstancesOperationError.DeserializeInstancesOperationError(item) : null);
                    }
                    delete = array;
                    continue;
                }
            }
            return new InstancesBatchResponse(Optional.ToList(@get), Optional.ToList(put), Optional.ToList(update), Optional.ToList(delete));
        }
    }
}
