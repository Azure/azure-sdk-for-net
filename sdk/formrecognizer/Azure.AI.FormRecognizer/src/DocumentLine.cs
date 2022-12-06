// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentLine")]
    public partial class DocumentLine
    {
        private readonly IReadOnlyList<DocumentWord> _mockWords;

        /// <summary>
        /// Initializes a new instance of DocumentLine. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal DocumentLine(string content, IReadOnlyList<PointF> boundingPolygon, IReadOnlyList<DocumentSpan> spans, IReadOnlyList<DocumentWord> words)
        {
            Content = content;
            BoundingPolygon = boundingPolygon;
            Spans = spans;
            _mockWords = words;
        }

        /// <summary>
        /// The polygon that outlines the content of this line. Coordinates are specified relative to the
        /// top-left of the page, and points are ordered clockwise from the left relative to the line
        /// orientation. Units are in pixels for images and inches for PDF. The <see cref="DocumentPageLengthUnit"/>
        /// type of a recognized page can be found at <see cref="DocumentPage.Unit"/>.
        /// </summary>
        public IReadOnlyList<PointF> BoundingPolygon { get; private set; }

        internal DocumentPage ContainingPage { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IReadOnlyList<float> Polygon
        {
            get => throw new InvalidOperationException();
            set
            {
                BoundingPolygon = ClientCommon.CovertToListOfPointF(value);
            }
        }

        /// <summary>
        /// Returns the list of <see cref="DocumentWord"/> that compose this line.
        /// </summary>
        /// <returns>The list of <see cref="DocumentWord"/> that compose this line.</returns>
        public IReadOnlyList<DocumentWord> GetWords()
        {
            if (_mockWords != null)
            {
                return _mockWords;
            }

            var words = new List<DocumentWord>();

            foreach (DocumentWord word in ContainingPage.Words)
            {
                DocumentSpan wordSpan = word.Span;

                foreach (DocumentSpan lineSpan in Spans)
                {
                    if (wordSpan.Index >= lineSpan.Index
                        && wordSpan.Index + wordSpan.Length <= lineSpan.Index + lineSpan.Length)
                    {
                        words.Add(word);
                    }
                }
            }

            return words;
        }
    }
}
