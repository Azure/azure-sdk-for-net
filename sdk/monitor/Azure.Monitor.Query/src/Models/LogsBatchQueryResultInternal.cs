// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("logQueryResult")]
    internal partial class LogsBatchQueryResultInternal: LogsQueryResult
    {
        internal ErrorInfo Error { get; }

        // TODO, remove after https://github.com/Azure/azure-sdk-for-net/issues/21655 is fixed
        internal static LogsBatchQueryResultInternal DeserializeLogsBatchQueryResultInternal(JsonElement element)
        {
            Optional<ErrorInfo> error = default;
            IReadOnlyList<LogsQueryResultTable> tables = default;
            Optional<JsonElement> statistics = default;
            Optional<JsonElement> render = default;

            // This is the workaround to remove the double-encoding
            if (element.ValueKind == JsonValueKind.String)
            {
                try
                {
                    using var document = JsonDocument.Parse(element.GetString());
                    element = document.RootElement.Clone();
                }
                catch
                {
                    // ignore
                }
            }

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("error"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    error = ErrorInfo.DeserializeErrorInfo(property.Value);
                    continue;
                }
                if (property.NameEquals("tables"))
                {
                    List<LogsQueryResultTable> array = new List<LogsQueryResultTable>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(LogsQueryResultTable.DeserializeLogsQueryResultTable(item));
                    }
                    tables = array;
                    continue;
                }
                if (property.NameEquals("statistics"))
                {
                    statistics = property.Value.Clone();
                    continue;
                }
                if (property.NameEquals("render"))
                {
                    render = property.Value.Clone();
                    continue;
                }
            }
            return new LogsBatchQueryResultInternal(tables, statistics, render, error.Value);
        }
    }
}