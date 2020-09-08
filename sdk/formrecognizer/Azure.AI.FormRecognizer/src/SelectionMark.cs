// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a Selection mark recognized from the input document.
    /// </summary>
    public class SelectionMark : FormElement
    {
        internal SelectionMark(SelectionMark_internal selectionMark, int pageNumber)
            : base(new FieldBoundingBox(selectionMark.BoundingBox), pageNumber, selectionMark.State.ToString())
        {
            Confidence = selectionMark.Confidence;
            State = selectionMark.State;
        }

        /// <summary> Confidence value. </summary>
        public float Confidence { get; }
        /// <summary> State of the selection mark. </summary>
        public SelectionMarkState State { get; }
    }
}
