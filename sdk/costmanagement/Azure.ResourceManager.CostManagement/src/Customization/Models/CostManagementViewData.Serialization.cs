// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.CostManagement.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CostManagement
{
    public partial class CostManagementViewData : IUtf8JsonSerializable
    {
        internal static CostManagementViewData DeserializeCostManagementViewData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ETag> eTag = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<string> displayName = default;
            Optional<ResourceIdentifier> scope = default;
            Optional<DateTimeOffset> createdOn = default;
            Optional<DateTimeOffset> modifiedOn = default;
            Optional<string> dateRange = default;
            Optional<string> currency = default;
            Optional<ViewChartType> chart = default;
            Optional<AccumulatedType> accumulated = default;
            Optional<ViewMetricType> metric = default;
            Optional<IList<ViewKpiProperties>> kpis = default;
            Optional<IList<ViewPivotProperties>> pivots = default;
            Optional<ViewReportType> type0 = default;
            Optional<ReportTimeframeType> timeframe = default;
            Optional<ReportConfigTimePeriod> timePeriod = default;
            Optional<ReportConfigDataset> dataSet = default;
            Optional<bool> includeMonetaryCommitment = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("eTag"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    eTag = new ETag(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("displayName"u8))
                        {
                            displayName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("scope"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            scope = property.Value.GetString().StartsWith("/") ? new ResourceIdentifier(property.Value.GetString()) : new ResourceIdentifier($"/{property.Value.GetString()}");
                            continue;
                        }
                        if (property0.NameEquals("createdOn"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            createdOn = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("modifiedOn"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            modifiedOn = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("dateRange"u8))
                        {
                            dateRange = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("currency"u8))
                        {
                            currency = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("chart"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            chart = new ViewChartType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("accumulated"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            accumulated = new AccumulatedType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("metric"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            metric = new ViewMetricType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("kpis"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ViewKpiProperties> array = new List<ViewKpiProperties>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ViewKpiProperties.DeserializeViewKpiProperties(item));
                            }
                            kpis = array;
                            continue;
                        }
                        if (property0.NameEquals("pivots"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ViewPivotProperties> array = new List<ViewPivotProperties>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ViewPivotProperties.DeserializeViewPivotProperties(item));
                            }
                            pivots = array;
                            continue;
                        }
                        if (property0.NameEquals("query"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                if (property1.NameEquals("type"u8))
                                {
                                    if (property1.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        continue;
                                    }
                                    type0 = new ViewReportType(property1.Value.GetString());
                                    continue;
                                }
                                if (property1.NameEquals("timeframe"u8))
                                {
                                    if (property1.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        continue;
                                    }
                                    timeframe = new ReportTimeframeType(property1.Value.GetString());
                                    continue;
                                }
                                if (property1.NameEquals("timePeriod"u8))
                                {
                                    if (property1.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        continue;
                                    }
                                    timePeriod = ReportConfigTimePeriod.DeserializeReportConfigTimePeriod(property1.Value);
                                    continue;
                                }
                                if (property1.NameEquals("dataSet"u8))
                                {
                                    if (property1.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        continue;
                                    }
                                    dataSet = ReportConfigDataset.DeserializeReportConfigDataset(property1.Value);
                                    continue;
                                }
                                if (property1.NameEquals("includeMonetaryCommitment"u8))
                                {
                                    if (property1.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        continue;
                                    }
                                    includeMonetaryCommitment = property1.Value.GetBoolean();
                                    continue;
                                }
                            }
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new CostManagementViewData(id, name, type, systemData.Value, displayName.Value, scope.Value, Optional.ToNullable(createdOn), Optional.ToNullable(modifiedOn), dateRange.Value, currency.Value, Optional.ToNullable(chart), Optional.ToNullable(accumulated), Optional.ToNullable(metric), Optional.ToList(kpis), Optional.ToList(pivots), Optional.ToNullable(type0), Optional.ToNullable(timeframe), timePeriod.Value, dataSet.Value, Optional.ToNullable(includeMonetaryCommitment), Optional.ToNullable(eTag));
        }
    }
}
