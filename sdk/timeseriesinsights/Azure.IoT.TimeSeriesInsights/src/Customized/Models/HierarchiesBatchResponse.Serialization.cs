// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// This class definition overrides serialization implementation in order to turn a raw response
    /// from Time Series Insights into a HierarchiesBatchResponse object.
    /// </summary>
    [CodeGenModel("HierarchiesBatchResponse")]
    internal partial class HierarchiesBatchResponse
    {
        // The purpose of overriding this method is to protect against an InvalidOperationException
        // that is being thrown by the generated code. More specifically, the exception is being thrown
        // when trying to deserialize the "delete" property. A coversation has started with the Time Series
        // Insights team on take a closer look on the thrown exception.
        internal static HierarchiesBatchResponse DeserializeHierarchiesBatchResponse(JsonElement element)
        {
            IReadOnlyList<TimeSeriesHierarchyOperationResult> @get = default;
            IReadOnlyList<TimeSeriesHierarchyOperationResult> put = default;
            IReadOnlyList<TimeSeriesOperationError> delete = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("get"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<TimeSeriesHierarchyOperationResult> array = new List<TimeSeriesHierarchyOperationResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TimeSeriesHierarchyOperationResult.DeserializeTimeSeriesHierarchyOperationResult(item));
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
                    List<TimeSeriesHierarchyOperationResult> array = new List<TimeSeriesHierarchyOperationResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TimeSeriesHierarchyOperationResult.DeserializeTimeSeriesHierarchyOperationResult(item));
                    }
                    put = array;
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
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.ValueKind != JsonValueKind.Null ? TimeSeriesOperationError.DeserializeTimeSeriesOperationError(item) : null);
                    }
                    delete = array;
                    continue;
                }
            }
            return new HierarchiesBatchResponse(@get ?? new ChangeTrackingList<TimeSeriesHierarchyOperationResult>(), put ?? new ChangeTrackingList<TimeSeriesHierarchyOperationResult>(), delete ?? new ChangeTrackingList<TimeSeriesOperationError>());
        }
    }
}
