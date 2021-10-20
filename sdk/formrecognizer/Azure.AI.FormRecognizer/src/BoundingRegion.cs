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
        /// The quadrilateral bounding box that outlines this region. Units are in pixels for
        /// images and inches for PDF. The <see cref="LengthUnit"/> type of a recognized page can be found
        /// at <see cref="DocumentPage.Unit"/>.
        /// </summary>
        public BoundingBox BoundingBox { get; private set; }

        [CodeGenMember("BoundingBox")]
        private IReadOnlyList<float> BoundingBoxPrivate
        {
            get => throw new InvalidOperationException();
            set
            {
                BoundingBox = new BoundingBox(value);
            }
        }
    }
}
