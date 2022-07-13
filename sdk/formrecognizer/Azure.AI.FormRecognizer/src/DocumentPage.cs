// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentPage")]
    public partial class DocumentPage
    {
        /// <summary>
        /// Initializes a new instance of DocumentPage. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal DocumentPage(DocumentPageKind kind, int pageNumber, float? angle, float? width, float? height, LengthUnit? unit, IReadOnlyList<DocumentSpan> spans, IReadOnlyList<DocumentWord> words, IReadOnlyList<DocumentSelectionMark> selectionMarks, IReadOnlyList<DocumentLine> lines)
        {
            Kind = kind;
            PageNumber = pageNumber;
            Angle = angle;
            Width = width;
            Height = height;
            Unit = unit;
            Spans = spans;
            Words = words;
            SelectionMarks = selectionMarks;
            Lines = lines;
        }

        /// <summary>
        /// The unit used by the width, height and <see cref="BoundingPolygon"/> properties. For images, the unit is
        /// pixel. For PDF, the unit is inch.
        /// </summary>
        public LengthUnit? Unit { get; private set; }

        private IReadOnlyList<DocumentImage> Images { get; }

        [CodeGenMember("Unit")]
        private V3LengthUnit? UnitPrivate
        {
            get => throw new InvalidOperationException();
            set
            {
                if (value == V3LengthUnit.Inch)
                {
                    Unit = LengthUnit.Inch;
                }
                else if (value == V3LengthUnit.Pixel)
                {
                    Unit = LengthUnit.Pixel;
                }
                else
                {
                    Unit = null;
                }
            }
        }
    }
}
