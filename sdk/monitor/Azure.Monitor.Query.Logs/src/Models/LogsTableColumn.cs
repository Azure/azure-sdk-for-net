// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Monitor.Query.Logs.Models
{
    [CodeGenType("LogsTableColumn")]
    public partial class LogsTableColumn
    {
        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Name} ({Type})";
        }

        internal static Dictionary<string, int> GetColumnMapFromColumns(IEnumerable<LogsTableColumn> columns)
        {
            Dictionary<string, int> columnMap = new();
            var columnsList = columns.ToArray();
            for (var index = 0; index < columnsList.Length; index++)
            {
                columnMap[columnsList[index].Name] = index;
            }
            return columnMap;
        }
    }
}
