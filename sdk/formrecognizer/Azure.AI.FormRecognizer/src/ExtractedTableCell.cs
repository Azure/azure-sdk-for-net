// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedTableCell
    {
        internal ExtractedTableCell(DataTableCell_internal dataTableCell, ReadResult_internal readResult, ICollection<string> references)
        {
            BoundingBox = new BoundingBox(dataTableCell.BoundingBox);
            ColumnIndex = dataTableCell.ColumnIndex;
            ColumnSpan = dataTableCell.ColumnSpan ?? 1;
            Confidence = dataTableCell.Confidence;
            IsFooter = dataTableCell.IsFooter ?? false;
            IsHeader = dataTableCell.IsHeader ?? false;
            RowIndex = dataTableCell.RowIndex;
            RowSpan = dataTableCell.RowSpan ?? 1;
            Text = dataTableCell.Text;

            if (references != null)
            {
                RawExtractedItems = ExtractedField.ConvertTextReferences(readResult, references);
            }
        }

        public BoundingBox BoundingBox { get; }
        public int ColumnIndex { get; }
        public int ColumnSpan { get; }
        public float Confidence { get; }
        public bool IsFooter { get; }
        public bool IsHeader { get; }
        public int RowIndex { get; }
        public int RowSpan { get; }
        public string Text { get; }

        public IReadOnlyList<RawExtractedItem> RawExtractedItems { get; internal set; }
    }
}
