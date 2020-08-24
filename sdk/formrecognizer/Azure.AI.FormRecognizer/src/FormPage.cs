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
        internal FormPage(PageResult pageResult, IReadOnlyList<ReadResult> readResults, int pageIndex)
        {
            ReadResult readResult = readResults[pageIndex];

            PageNumber = readResult.Page;

            // Workaround because the service can sometimes return angles between 180 and 360 (bug).
            // Currently tracked by: https://github.com/Azure/azure-sdk-for-net/issues/12319
            TextAngle = readResult.Angle <= 180.0f ? readResult.Angle : readResult.Angle - 360.0f;

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
        /// Initializes a new instance of the <see cref="FormPage"/> class.
        /// </summary>
        /// <param name="pageNumber">The 1-based page number in the input document.</param>
        /// <param name="width">The width of the image/PDF in pixels/inches, respectively.</param>
        /// <param name="height">The height of the image/PDF in pixels/inches, respectively.</param>
        /// <param name="textAngle">The general orientation of the text in clockwise direction, measured in degrees between (-180, 180].</param>
        /// <param name="unit">The unit used by the width, height and <see cref="FieldBoundingBox"/> properties. For images, the unit is &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;.</param>
        /// <param name="lines">A list of recognized lines of text.</param>
        /// <param name="tables">A list of recognized tables contained in this page.</param>
        internal FormPage(int pageNumber, float width, float height, float textAngle, LengthUnit unit, IReadOnlyList<FormLine> lines, IReadOnlyList<FormTable> tables)
        {
            PageNumber = pageNumber;
            Width = width;
            Height = height;
            TextAngle = textAngle;
            Unit = unit;
            Lines = lines;
            Tables = tables;
        }

        /// <summary>
        /// The 1-based page number in the input document.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// The general orientation of the text in clockwise direction, measured in degrees between (-180, 180].
        /// </summary>
        public float TextAngle { get; }

        /// <summary>
        /// The width of the image/PDF in pixels/inches, respectively.
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// The height of the image/PDF in pixels/inches, respectively.
        /// </summary>
        public float Height { get; }

        /// <summary>
        /// The unit used by the width, height and <see cref="FieldBoundingBox"/> properties. For images, the unit is
        /// &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;.
        /// </summary>
        public LengthUnit Unit { get; }

        /// <summary>
        /// When 'IncludeFieldElements' is set to <c>true</c>, a list of recognized lines of text.
        /// An empty list otherwise. For calls to recognize content, this list is always populated. The maximum number of
        /// lines returned is 300 per page. The lines are sorted top to bottom, left to right, although in certain cases
        /// proximity is treated with higher priority. As the sorting order depends on the detected text, it may change across
        /// images and OCR version updates. Thus, business logic should be built upon the actual line location instead of order.
        /// </summary>
        public IReadOnlyList<FormLine> Lines { get; }

        /// <summary>
        /// A list of recognized tables contained in this page.
        /// </summary>
        public IReadOnlyList<FormTable> Tables { get; }

        private static IReadOnlyList<FormLine> ConvertLines(IReadOnlyList<TextLine> textLines, int pageNumber)
        {
            List<FormLine> rawLines = new List<FormLine>();

            foreach (TextLine textLine in textLines)
            {
                rawLines.Add(new FormLine(textLine, pageNumber));
            }

            return rawLines;
        }

        private static IReadOnlyList<FormTable> ConvertTables(PageResult pageResult, IReadOnlyList<ReadResult> readResults, int pageIndex)
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
