// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a Selection mark recognized from the input document.
    /// </summary>
    public class FormSelectionMark : FormElement
    {
        internal FormSelectionMark(SelectionMark selectionMark, int pageNumber)
            : base(new FieldBoundingBox(selectionMark.BoundingBox), pageNumber)
        {
            Confidence = selectionMark.Confidence;
            State = selectionMark.State;
        }

        internal FormSelectionMark(FieldBoundingBox boundingBox, int pageNumber, string text, float confidence, SelectionMarkState state)
            : base(boundingBox, pageNumber, text)
        {
            Confidence = confidence;
            State = state;
        }

        /// <summary>
        /// Measures the degree of certainty of the recognition result. Value is between [0.0, 1.0].
        /// </summary>
        public float Confidence { get; }

        /// <summary>
        /// Selection mark state value, like Selected or Unselected.
        /// </summary>
        public SelectionMarkState State { get; }
    }
}
