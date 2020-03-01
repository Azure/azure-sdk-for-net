// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Resources;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedTableCell
    {
        public ExtractedTableCell(DataTableCell_internal result)
        {
            BoundingBox = new BoundingBox(result.BoundingBox);
            ColumnIndex = result.ColumnIndex;
            ColumnSpan = result.ColumnSpan.HasValue ? result.ColumnSpan.Value : 1;
            Confidence = result.Confidence;
            IsFooter = result.IsFooter.HasValue ? result.IsFooter.Value : false;
            IsHeader = result.IsHeader.HasValue ? result.IsHeader.Value : false;
            RowIndex = result.RowIndex;
            RowSpan = result.RowSpan.HasValue ? result.RowSpan.Value : 1;
            Text = result.Text;
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

        // Reason to hold these in parallel is that we could make this a struct then? (Or could we?)
        //public IReadOnlyList<RawExtractedLine> RawTableCellExtraction { get; }
    }
}
