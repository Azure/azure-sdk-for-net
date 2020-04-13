// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormTable
    {
        internal FormTable(DataTable_internal table, ReadResult_internal readResult)
        {
            PageNumber = readResult.Page;
            ColumnCount = table.Columns;
            RowCount = table.Rows;
            Cells = ConvertCells(table.Cells, readResult);
        }

        /// <summary>
        /// The 1-based page number in the input document.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormTableCell> Cells { get; }

        /// <summary>
        /// </summary>
        public int ColumnCount { get; }

        /// <summary>
        /// </summary>
        public int RowCount { get; }

        // TODO: implement table indexer
        // TODO: Handling column-span?
        // https://github.com/Azure/azure-sdk-for-net/issues/9975

        /// <summary>
        /// </summary>
#pragma warning disable CA1822 // Mark as static
        internal FormTableCell this[int row, int column]
#pragma warning restore CA1822 // Mark as static
        {
            get
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                throw new NotImplementedException();
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private static IReadOnlyList<FormTableCell> ConvertCells(IReadOnlyList<DataTableCell_internal> cellsResult, ReadResult_internal readResult)
        {
            List<FormTableCell> cells = new List<FormTableCell>();
            foreach (var result in cellsResult)
            {
                cells.Add(new FormTableCell(result, readResult, result.Elements));
            }

            return cells;
        }
    }
}
