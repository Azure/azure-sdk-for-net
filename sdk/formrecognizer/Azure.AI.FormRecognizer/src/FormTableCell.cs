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
        internal FormTableCell(DataTableCell dataTableCell, IReadOnlyList<ReadResult> readResults, int pageNumber)
            : base(new FieldBoundingBox(dataTableCell.BoundingBox), pageNumber, dataTableCell.Text)
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
        /// Initializes a new instance of the <see cref="FormTableCell"/> class.
        /// </summary>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the text of this element.</param>
        /// <param name="pageNumber">The 1-based number of the page in which this element is present.</param>
        /// <param name="text">The text of this form element.</param>
        /// <param name="columnIndex">The column index of the cell.</param>
        /// <param name="rowIndex">The row index of the cell.</param>
        /// <param name="columnSpan">The number of columns spanned by this cell.</param>
        /// <param name="rowSpan">The number of rows spanned by this cell.</param>
        /// <param name="isHeader"><c>true</c> if this cell is a header cell. Otherwise, <c>false</c>.</param>
        /// <param name="isFooter"><c>true</c> if this cell is a footer cell. Otherwise, <c>false</c>.</param>
        /// <param name="confidence">Measures the degree of certainty of the recognition result.</param>
        /// <param name="fieldElements">A list of references to the field elements constituting this cell.</param>
        internal FormTableCell(FieldBoundingBox boundingBox, int pageNumber, string text, int columnIndex, int rowIndex, int columnSpan, int rowSpan, bool isHeader, bool isFooter, float confidence, IReadOnlyList<FormElement> fieldElements)
            : base(boundingBox, pageNumber, text)
        {
            ColumnIndex = columnIndex;
            RowIndex = rowIndex;
            ColumnSpan = columnSpan;
            RowSpan = rowSpan;
            IsHeader = isHeader;
            IsFooter = isFooter;
            Confidence = confidence;
            FieldElements = fieldElements;
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
        /// When 'IncludeFieldElements' is set to <c>true</c>, a list of references to
        /// the field elements constituting this cell is returned. An empty list otherwise. For calls to Recognize Content, this
        /// list is always populated.
        /// </summary>
        public IReadOnlyList<FormElement> FieldElements { get; }
    }
}
