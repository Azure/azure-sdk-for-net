// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Monitor.Query.Logs.Models
{
    /// <summary> Contains the columns and rows for one table in a query response. </summary>
    [CodeGenType("LogsTable")]
    public partial class LogsTable
    {
        private IReadOnlyList<LogsTableRow> _rows;

        [CodeGenMember("Rows")]
        private JsonElement InternalRows { get; }

        /// <summary>
        /// Gets the rows of the result table.
        /// </summary>
        public IReadOnlyList<LogsTableRow> Rows => _rows ??= CreateRows();

        /// <summary>
        /// The list of columns in this table.
        /// </summary>
        public IReadOnlyList<LogsTableColumn> Columns { get; }

        private IReadOnlyList<LogsTableRow> CreateRows()
        {
            Dictionary<string, int> columnDictionary = new();

            for (var index = 0; index < Columns.Count; index++)
            {
                columnDictionary[Columns[index].Name] = index;
            }

            List<LogsTableRow> rows = new List<LogsTableRow>();

            foreach (var row in InternalRows.EnumerateArray())
            {
                rows.Add(new LogsTableRow(columnDictionary, Columns, row));
            }

            return rows;
        }
    }
}
