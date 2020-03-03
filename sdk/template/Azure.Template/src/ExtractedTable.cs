// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedTable
    {
        internal ExtractedTable(DataTable_internal result, ReadResult_internal readResult)
        {
            ColumnCount = result.Columns;
            RowCount = result.Rows;
            Cells = ConvertCells(result.Cells, readResult);
        }

        public IReadOnlyList<ExtractedTableCell> Cells { get; }
        public int ColumnCount { get; }
        public int RowCount { get; }

        // TODO: implement table indexer
        // TODO: Handling column-span?

        //public ExtractedTableCell this[int i, int j] { get; set; }

        private static IReadOnlyList<ExtractedTableCell> ConvertCells(ICollection<DataTableCell_internal> cellsResult, ReadResult_internal readResult)
        {
            List<ExtractedTableCell> cells = new List<ExtractedTableCell>();
            foreach (var result in cellsResult)
            {
                cells.Add(new ExtractedTableCell(result, readResult, result.Elements));
            }

            return cells.AsReadOnly();
        }
    }
}
