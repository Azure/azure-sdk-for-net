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
        /// The quadrilateral bounding box that outlines this selection mark. Units are in pixels for
        /// images and inches for PDF. The <see cref="LengthUnit"/> type of a recognized page can be found
        /// at <see cref="DocumentPage.Unit"/>.
        /// </summary>
        public BoundingBox BoundingBox { get; private set; }

        /// <summary>
        /// Selection mark state value, like Selected or Unselected.
        /// </summary>
        public SelectionMarkState State { get; private set; }

        [CodeGenMember("BoundingBox")]
        private IReadOnlyList<float> BoundingBoxPrivate
        {
            get => throw new InvalidOperationException();
            set
            {
                BoundingBox = new BoundingBox(value);
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
