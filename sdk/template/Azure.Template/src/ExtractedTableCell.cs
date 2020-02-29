// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer
{
    public class ExtractedTableCell
    {
        public float[] BoundingBox { get; }
        public int ColumnIndex { get; }
        public int ColumnSpan { get; }
        public float Confidence { get; }
        public bool IsFooter { get; }
        public bool IsHeader { get; }

        // Reason to hold these in parallel is that we could make this a struct then? (Or could we?)
        //public IReadOnlyList<RawExtractedLine> RawTableCellExtraction { get; }
        public int RowIndex { get; }
        public int RowSpan { get; }
        public string Text { get; }
    }
}
