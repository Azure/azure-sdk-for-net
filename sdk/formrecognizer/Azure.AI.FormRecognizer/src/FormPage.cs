// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a page recognized from the input document. Contains lines, words, tables and page metadata.
    /// </summary>
    public class FormPage
    {
        internal FormPage(PageResult_internal pageResult, IReadOnlyList<ReadResult_internal> readResults, int pageIndex)
        {
            ReadResult_internal readResult = readResults[pageIndex];

            PageNumber = readResult.Page;
            TextAngle = readResult.Angle;
            Width = readResult.Width;
            Height = readResult.Height;
            Unit = readResult.Unit;
            Lines = readResult.Lines != null
                ? ConvertLines(readResult.Lines, readResult.Page)
                : new List<FormLine>();
            Tables = pageResult?.Tables != null
                ? ConvertTables(pageResult, readResults, pageIndex)
                : new List<FormTable>();
        }

        /// <summary>
        /// The 1-based page number in the input document.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// The general orientation of the text in clockwise direction, measured in degrees between (-180, 180].
        /// </summary>
        public float TextAngle { get; set; }

        /// <summary>
        /// The width of the image/PDF in pixels/inches, respectively.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// The height of the image/PDF in pixels/inches, respectively.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// The unit used by the width, height and <see cref="BoundingBox"/> properties. For images, the unit is
        /// &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;.
        /// </summary>
        public LengthUnit Unit { get; set; }

        /// <summary>
        /// When <see cref="RecognizeOptions.IncludeTextContent"/> is set to <c>true</c>, a list of recognized lines of text.
        /// An empty list otherwise. For calls to recognize content, this list is always populated. The maximum number of
        /// lines returned is 300 per page. The lines are sorted top to bottom, left to right, although in certain cases
        /// proximity is treated with higher priority. As the sorting order depends on the detected text, it may change across
        /// images and OCR version updates. Thus, business logic should be built upon the actual line location instead of order.
        /// </summary>
        public IReadOnlyList<FormLine> Lines { get; set; }

        /// <summary>
        /// A list of extracted tables contained in a page.
        /// </summary>
        public IReadOnlyList<FormTable> Tables { get; }

        private static IReadOnlyList<FormLine> ConvertLines(IReadOnlyList<TextLine_internal> textLines, int pageNumber)
        {
            List<FormLine> rawLines = new List<FormLine>();

            foreach (TextLine_internal textLine in textLines)
            {
                rawLines.Add(new FormLine(textLine, pageNumber));
            }

            return rawLines;
        }

        private static IReadOnlyList<FormTable> ConvertTables(PageResult_internal pageResult, IReadOnlyList<ReadResult_internal> readResults, int pageIndex)
        {
            List<FormTable> tables = new List<FormTable>();

            foreach (var table in pageResult.Tables)
            {
                tables.Add(new FormTable(table, readResults, pageIndex));
            }

            return tables;
        }
    }
}
