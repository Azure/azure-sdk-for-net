// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a cell contained in a table recognized from the input document.
    /// </summary>
    public class FormTableCell : FormElement
    {
        internal FormTableCell(DataTableCell_internal dataTableCell, IReadOnlyList<ReadResult_internal> readResults, int pageNumber)
            : base(new BoundingBox(dataTableCell.BoundingBox), pageNumber, dataTableCell.Text)
        {
            ColumnIndex = dataTableCell.ColumnIndex;
            ColumnSpan = dataTableCell.ColumnSpan ?? 1;
            Confidence = dataTableCell.Confidence;
            IsFooter = dataTableCell.IsFooter ?? false;
            IsHeader = dataTableCell.IsHeader ?? false;
            RowIndex = dataTableCell.RowIndex;
            RowSpan = dataTableCell.RowSpan ?? 1;
            FieldElements = dataTableCell.Elements != null
                ? FormField.ConvertTextReferences(dataTableCell.Elements, readResults)
                : new List<FormElement>();
        }

        /// <summary>
        /// The column index of the cell.
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// The number of columns spanned by this cell.
        /// </summary>
        public int ColumnSpan { get; }

        /// <summary>
        /// Measures the degree of certainty of the recognition result. Value is between [0.0, 1.0].
        /// </summary>
        public float Confidence { get; }

        /// <summary>
        /// <c>true</c> if this cell is a footer cell. Otherwise, <c>false</c>.
        /// </summary>
        public bool IsFooter { get; }

        /// <summary>
        /// <c>true</c> if this cell is a header cell. Otherwise, <c>false</c>.
        /// </summary>
        public bool IsHeader { get; }

        /// <summary>
        /// The row index of this cell.
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// The number of rows spanned by this cell.
        /// </summary>
        public int RowSpan { get; }

        /// <summary>
        /// When <see cref="RecognizeOptions.IncludeFieldElements"/> is set to <c>true</c>, a list of references to
        /// the field elements constituting this cell is returned. An empty list otherwise. For calls to recognize content, this
        /// list is always populated.
        /// </summary>
        public IReadOnlyList<FormElement> FieldElements { get; }
    }
}
