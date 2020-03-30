// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormTableCell : FormContent
    {
#pragma warning disable CA1801
        internal FormTableCell(DataTableCell_internal dataTableCell, ReadResult_internal readResult, ICollection<string> references)
            : base(dataTableCell.Text, new BoundingBox(dataTableCell.BoundingBox), 0  /* TODO */)
#pragma warning restore CA1801
        {
            ColumnIndex = dataTableCell.ColumnIndex;
            ColumnSpan = dataTableCell.ColumnSpan ?? 1;
            Confidence = dataTableCell.Confidence;
            IsFooter = dataTableCell.IsFooter ?? false;
            IsHeader = dataTableCell.IsHeader ?? false;
            RowIndex = dataTableCell.RowIndex;
            RowSpan = dataTableCell.RowSpan ?? 1;

            if (references != null)
            {
                //TextElements = FormField.ConvertTextReferences(readResult, references);
            }
        }

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
        public IReadOnlyList<FormContent> TextContent { get; internal set; }
    }
}
