// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("batchQueryResults")]
    public partial class LogsBatchQueryResult: LogsQueryResult
    {
        internal int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the query id.
        /// </summary>
        public string Id { get; internal set; }

        // TODO, remove after https://github.com/Azure/azure-sdk-for-net/issues/21655 is fixed
        internal static LogsBatchQueryResult DeserializeLogsBatchQueryResult(JsonElement element)
        {
            JsonElement error = default;
            IReadOnlyList<LogsTable> tables = default;
            JsonElement statistics = default;
            JsonElement render = default;

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
                    error = property.Value.Clone();
                    continue;
                }
                if (property.NameEquals("tables"))
                {
                    List<LogsTable> array = new List<LogsTable>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(LogsTable.DeserializeLogsTable(item));
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
            return new LogsBatchQueryResult(tables, statistics, render, error, serializedAdditionalRawData: null);
        }
    }
}
