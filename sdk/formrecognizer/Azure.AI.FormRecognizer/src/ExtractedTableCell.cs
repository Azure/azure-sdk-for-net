// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.FormRecognizer.Custom;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
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

        /// <summary>
        /// </summary>
        public BoundingBox BoundingBox { get; }

        /// <summary>
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// </summary>
        public int ColumnSpan { get; }

        /// <summary>
        /// </summary>
        public float Confidence { get; }

        /// <summary>
        /// </summary>
        public bool IsFooter { get; }

        /// <summary>
        /// </summary>
        public bool IsHeader { get; }

        /// <summary>
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// </summary>
        public int RowSpan { get; }

        /// <summary>
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<RawExtractedItem> RawExtractedItems { get; internal set; }
    }
}
