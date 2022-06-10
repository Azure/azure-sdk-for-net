// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentSelectionMark")]
    public partial class DocumentSelectionMark
    {
        /// <summary>
        /// Initializes a new instance of DocumentSelectionMark. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal DocumentSelectionMark(SelectionMarkState state, BoundingPolygon boundingPolygon, DocumentSpan span, float confidence)
        {
            State = state;
            BoundingPolygon = boundingPolygon;
            Span = span;
            Confidence = confidence;
        }

        /// <summary>
        /// The polygon that outlines the content of this selection mark. Coordinates are specified relative to the
        /// top-left of the page, and points are ordered clockwise from the left relative to the selection mark
        /// orientation. Units are in pixels for images and inches for PDF. The <see cref="LengthUnit"/>
        /// type of a recognized page can be found at <see cref="DocumentPage.Unit"/>.
        /// </summary>
        public BoundingPolygon BoundingPolygon { get; private set; }

        /// <summary>
        /// Selection mark state value, like Selected or Unselected.
        /// </summary>
        public SelectionMarkState State { get; private set; }

        private IReadOnlyList<float> Polygon
        {
            get => throw new InvalidOperationException();
            set
            {
                BoundingPolygon = new BoundingPolygon(value);
            }
        }

        [CodeGenMember("State")]
        private V3SelectionMarkState StatePrivate
        {
            get => throw new InvalidOperationException();
            set
            {
                if (value == V3SelectionMarkState.Selected)
                {
                    State = SelectionMarkState.Selected;
                }
                else if (value == V3SelectionMarkState.Unselected)
                {
                    State = SelectionMarkState.Unselected;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Unknown {nameof(SelectionMarkState)} value: {value}");
                }
            }
        }
    }
}
