// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentWord")]
    public partial class DocumentWord
    {
        /// <summary>
        /// Initializes a new instance of DocumentWord. Use for the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal DocumentWord(string content, BoundingBox boundingBox, DocumentSpan span, float confidence)
        {
            Content = content;
            BoundingBox = boundingBox;
            Span = span;
            Confidence = confidence;
        }

        /// <summary>
        /// The quadrilateral bounding box that outlines the text of this word. Units are in pixels for
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
