﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("Table")]
    public partial class LogsQueryResultTable
    {
        private IReadOnlyList<LogsQueryResultRow> _rows;

        [CodeGenMember("Rows")]
        private JsonElement InternalRows { get; }

        /// <summary>
        /// Gets the rows of the result table.
        /// </summary>
        public IReadOnlyList<LogsQueryResultRow> Rows => _rows ??= CreateRows();

        private IReadOnlyList<LogsQueryResultRow> CreateRows()
        {
            Dictionary<string, int> columnDictionary = new();

            for (var index = 0; index < Columns.Count; index++)
            {
                columnDictionary[Columns[index].Name] = index;
            }

            List<LogsQueryResultRow> rows = new List<LogsQueryResultRow>();

            foreach (var row in InternalRows.EnumerateArray())
            {
                rows.Add(new LogsQueryResultRow(columnDictionary, Columns, row));
            }

            return rows;
        }

        /// <summary>
        /// Maps table rows to a model of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>Query results mapped to a type <typeparamref name="T"/>.</returns>
        public IReadOnlyList<T> Deserialize<T>()
        {
            return RowBinder.Shared.BindResults<T>(new[] { this });
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Name}: {Rows.Count} rows, {Columns.Count} columns";
        }
    }
}