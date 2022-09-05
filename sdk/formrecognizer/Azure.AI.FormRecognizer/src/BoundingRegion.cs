// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Drawing;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("BoundingRegion")]
    [CodeGenSuppress(nameof(BoundingRegion), typeof(int), typeof(IEnumerable<float>))]
    [CodeGenSuppress("Polygon")]
    public readonly partial struct BoundingRegion
    {
        /// <summary> Initializes a new instance of BoundingRegion. </summary>
        /// <param name="pageNumber"> 1-based page number of page containing the bounding region. </param>
        /// <param name="polygon"> Bounding polygon on the page, or the entire page if not specified. </param>
        internal BoundingRegion(int pageNumber, IReadOnlyList<float> polygon)
        {
            PageNumber = pageNumber;
            BoundingPolygon = ClientCommon.CovertToListOfPointF(polygon);
        }

        /// <summary>
        /// Initializes a new instance of BoundingRegion. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal BoundingRegion(int pageNumber, IReadOnlyList<PointF> boundingPolygon)
        {
            PageNumber = pageNumber;
            BoundingPolygon = boundingPolygon;
        }

        /// <summary>
        /// 1-based page number of page containing the bounding region.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// The bounding polygon that outlines this region. Units are in pixels for images and inches for
        /// PDF. The <see cref="LengthUnit"/> type of a recognized page can be found at <see cref="DocumentPage.Unit"/>.
        /// </summary>
        public IReadOnlyList<PointF> BoundingPolygon { get; }
    }
}
