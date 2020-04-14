// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormTableCell : FormContent
    {
        internal FormTableCell(DataTableCell_internal dataTableCell, ReadResult_internal readResult)
            : base(new BoundingBox(dataTableCell.BoundingBox), readResult.Page, dataTableCell.Text)
        {
            ColumnIndex = dataTableCell.ColumnIndex;
            ColumnSpan = dataTableCell.ColumnSpan ?? 1;
            Confidence = dataTableCell.Confidence;
            IsFooter = dataTableCell.IsFooter ?? false;
            IsHeader = dataTableCell.IsHeader ?? false;
            RowIndex = dataTableCell.RowIndex;
            RowSpan = dataTableCell.RowSpan ?? 1;
            TextContent = dataTableCell.Elements != null
                ? ConvertTextReferences(readResult, dataTableCell.Elements)
                : new List<FormContent>();
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
        public IReadOnlyList<FormContent> TextContent { get; }

        // TODO: Refactor to move OCR code to a common file, rather than it living in this file.
        //       Code may be duplicated in FormField.
        private static IReadOnlyList<FormContent> ConvertTextReferences(ReadResult_internal readResult, IReadOnlyCollection<string> references)
        {
            List<FormContent> extractedTexts = new List<FormContent>();

            foreach (var reference in references)
            {
                extractedTexts.Add(ResolveTextReference(readResult, reference));
            }

            return extractedTexts;
        }

        // TODO: Refactor to move OCR code to a common file, rather than it living in this file.
        //       Code may be duplicated in FormField.
        private static FormContent ResolveTextReference(ReadResult_internal readResult, string reference)
        {
            // Method content is dummy.

            if (readResult == null || reference == null)
            {
                return null;
            }

            return null;
        }
    }
}
