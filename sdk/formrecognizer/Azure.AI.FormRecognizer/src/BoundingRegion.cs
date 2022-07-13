// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("BoundingRegion")]
    public partial class BoundingRegion
    {
        /// <summary>
        /// Initializes a new instance of BoundingRegion. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal BoundingRegion(int pageNumber, BoundingPolygon boundingPolygon)
        {
            PageNumber = pageNumber;
            BoundingPolygon = boundingPolygon;
        }

        /// <summary>
        /// The bounding polygon that outlines this region. Units are in pixels for images and inches for
        /// PDF. The <see cref="LengthUnit"/> type of a recognized page can be found at <see cref="DocumentPage.Unit"/>.
        /// </summary>
        public BoundingPolygon BoundingPolygon { get; private set; }

        private IReadOnlyList<float> Polygon
        {
            get => throw new InvalidOperationException();
            set
            {
                BoundingPolygon = new BoundingPolygon(value);
            }
        }
    }
}
