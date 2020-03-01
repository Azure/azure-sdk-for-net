// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedTable
    {
        public IReadOnlyList<ExtractedTableCell> Cells { get; }
        public int ColumnCount { get; }
        public int RowCount { get; }

        // TODO: implement table indexer

        //public ExtractedTableCell this[int i, int j] { get; set; }
    }
}
