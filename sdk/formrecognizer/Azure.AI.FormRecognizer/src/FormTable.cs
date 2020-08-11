// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a table recognized from the input document.
    /// </summary>
    public class FormTable
    {
        internal FormTable(DataTable table, IReadOnlyList<ReadResult> readResults, int pageIndex)
        {
            ReadResult readResult = readResults[pageIndex];

            PageNumber = readResult.Page;
            ColumnCount = table.Columns;
            RowCount = table.Rows;
            Cells = ConvertCells(table.Cells, readResults, readResult.Page);
        }

        /// <summary>
        /// The 1-based number of the page in which this table is present.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// A list of cells contained in this table.
        /// </summary>
        public IReadOnlyList<FormTableCell> Cells { get; }

        /// <summary>
        /// The number of columns in this table.
        /// </summary>
        public int ColumnCount { get; }

        /// <summary>
        /// The number of rows in this table.
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

        private static IReadOnlyList<FormTableCell> ConvertCells(IReadOnlyList<DataTableCell> cellsResult, IReadOnlyList<ReadResult> readResults, int pageNumber)
        {
            List<FormTableCell> cells = new List<FormTableCell>();

            foreach (var cellResult in cellsResult)
            {
                cells.Add(new FormTableCell(cellResult, readResults, pageNumber));
            }

            return cells;
        }
    }
}
