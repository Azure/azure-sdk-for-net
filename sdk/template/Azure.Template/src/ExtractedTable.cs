// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedTable
    {
        internal ExtractedTable(DataTable_internal result)
        {
            ColumnCount = result.Columns;
            RowCount = result.Rows;
            Cells = ConvertCells(result.Cells);
        }

        public IReadOnlyList<ExtractedTableCell> Cells { get; }
        public int ColumnCount { get; }
        public int RowCount { get; }

        // TODO: implement table indexer

        //public ExtractedTableCell this[int i, int j] { get; set; }


        private static IReadOnlyList<ExtractedTableCell> ConvertCells(ICollection<DataTableCell_internal> cellsResult)
        {
            List<ExtractedTableCell> cells = new List<ExtractedTableCell>();

            foreach (var result in cellsResult)
            {
                cells.Add(new ExtractedTableCell(result));
            }

            return cells.AsReadOnly();
        }
    }
}
