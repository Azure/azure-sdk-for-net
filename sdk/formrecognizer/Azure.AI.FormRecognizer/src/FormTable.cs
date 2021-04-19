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
            // Need to verify why Bounding Box is not returned from the service
            // https://github.com/Azure/azure-sdk-for-net/issues/16827
            BoundingBox = table.BoundingBox == null ? new FieldBoundingBox(new List<float>()) : new FieldBoundingBox(table.BoundingBox);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTable"/> class.
        /// </summary>
        /// <param name="pageNumber">The 1-based number of the page in which this table is present.</param>
        /// <param name="columnCount">The number of columns in this table.</param>
        /// <param name="rowCount">The number of rows in this table.</param>
        /// <param name="cells">A list of cells contained in this table.</param>
        internal FormTable(int pageNumber, int columnCount, int rowCount, IReadOnlyList<FormTableCell> cells)
        {
            PageNumber = pageNumber;
            ColumnCount = columnCount;
            RowCount = rowCount;
            Cells = cells;
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

        /// <summary> Bounding box of the table. </summary>
        public FieldBoundingBox BoundingBox { get; }

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
