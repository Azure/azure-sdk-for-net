// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentLine")]
    public partial class DocumentLine
    {
        /// <summary>
        /// The quadrilateral bounding box that outlines the content of this line. Units are in pixels for
        /// images and inches for PDF. The <see cref="LengthUnit"/> type of a recognized page can be found
        /// at <see cref="DocumentPage.Unit"/>.
        /// </summary>
        public BoundingBox BoundingBox { get; private set; }

        /// <summary>
        /// The words that make up this line.
        /// </summary>
        public IReadOnlyList<DocumentWord> Words => ClientCommon.GetWords(Page, Spans);

        /// <summary>
        /// The page in which this element is located. Used only for the convenience
        /// <see cref="Words"/> property.
        /// </summary>
        internal DocumentPage Page { get; set; }

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
