// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class DocumentPage
    {
        /// <summary> Initializes a new instance of DocumentPage. </summary>
        /// <param name="pageNumber"> 1-based page number in the input document. </param>
        /// <param name="angle"> The general orientation of the content in clockwise direction, measured in degrees between (-180, 180]. </param>
        /// <param name="width"> The width of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="height"> The height of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="unitPrivate"> The unit used by the width, height, and polygon properties. For images, the unit is &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;. </param>
        /// <param name="spans"> Location of the page in the reading order concatenated content. </param>
        /// <param name="words"> Extracted words from the page. </param>
        /// <param name="selectionMarks"> Extracted selection marks from the page. </param>
        /// <param name="lines"> Extracted lines from the page, potentially containing both textual and visual elements. </param>
        /// <param name="barcodes"> Extracted barcodes from the page. </param>
        /// <param name="formulas"> Extracted formulas from the page. </param>
        internal DocumentPage(int pageNumber, float? angle, float? width, float? height, V3LengthUnit? unitPrivate, IReadOnlyList<DocumentSpan> spans, IReadOnlyList<DocumentWord> words, IReadOnlyList<DocumentSelectionMark> selectionMarks, IReadOnlyList<DocumentLine> lines, IReadOnlyList<DocumentBarcode> barcodes, IReadOnlyList<DocumentFormula> formulas)
        {
            PageNumber = pageNumber;
            Angle = angle;
            Width = width;
            Height = height;
            UnitPrivate = unitPrivate;
            Spans = spans;
            Words = words;
            SelectionMarks = selectionMarks;
            Lines = lines;
            Barcodes = barcodes;
            Formulas = formulas;

            foreach (DocumentLine line in Lines)
            {
                line.ContainingPage = this;
            }
        }

        /// <summary>
        /// Initializes a new instance of DocumentPage. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal DocumentPage(int pageNumber, float? angle, float? width, float? height, DocumentPageLengthUnit? unit, IReadOnlyList<DocumentSpan> spans, IReadOnlyList<DocumentWord> words, IReadOnlyList<DocumentSelectionMark> selectionMarks, IReadOnlyList<DocumentLine> lines, IReadOnlyList<DocumentBarcode> barcodes, IReadOnlyList<DocumentFormula> formulas)
        {
            PageNumber = pageNumber;
            Angle = angle;
            Width = width;
            Height = height;
            Unit = unit;
            Spans = spans;
            Words = words;
            SelectionMarks = selectionMarks;
            Lines = lines;
            Barcodes = barcodes;
            Formulas = formulas;

            foreach (DocumentLine line in Lines)
            {
                line.ContainingPage = this;
            }
        }

        /// <summary>
        /// The unit used by the Width, Height and BoundingPolygon properties. For images, the unit is
        /// pixel. For PDF, the unit is inch.
        /// </summary>
        public DocumentPageLengthUnit? Unit { get; private set; }

        [CodeGenMember("Unit")]
        private V3LengthUnit? UnitPrivate
        {
            get => throw new InvalidOperationException();
            set
            {
                if (value == V3LengthUnit.Inch)
                {
                    Unit = DocumentPageLengthUnit.Inch;
                }
                else if (value == V3LengthUnit.Pixel)
                {
                    Unit = DocumentPageLengthUnit.Pixel;
                }
                else
                {
                    Unit = null;
                }
            }
        }
    }
}
