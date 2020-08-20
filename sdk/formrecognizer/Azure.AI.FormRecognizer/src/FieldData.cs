// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// A form element representing text that is part of a <see cref="FormField"/>.
    /// This includes the location of the text in the form and a collection of the form
    /// elements that make up the text.
    /// </summary>
    public class FieldData : FormElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldData"/> class.
        /// </summary>
        /// <param name="boundingBox">The quadrilateral bounding box that outlines the text of this element.</param>
        /// <param name="pageNumber">The 1-based number of the page in which this element is present.</param>
        /// <param name="text">The text of this form element.</param>
        /// <param name="fieldElements">A list of references to the field elements constituting this data.</param>
        internal FieldData(FieldBoundingBox boundingBox, int pageNumber, string text, IReadOnlyList<FormElement> fieldElements)
            : base(boundingBox, pageNumber, text)
        {
            FieldElements = fieldElements;
        }

        /// <summary>
        /// When 'IncludeFieldElements' is set to <c>true</c>, a list of references to
        /// the field elements constituting this <see cref="FieldData"/>. An empty list otherwise. For calls to
        /// recognize content, this list is always populated.
        /// </summary>
        public IReadOnlyList<FormElement> FieldElements { get; }

        /// <summary>
        /// Implicitly converts a <see cref="FieldData"/> instance into a <see cref="string"/>, using the
        /// value returned by <see cref="FormElement.Text"/>.
        /// </summary>
        /// <param name="text">The instance to be converted into a <see cref="string"/>.</param>
        /// <returns>The <see cref="string"/> corresponding to the recognized text.</returns>
        public static implicit operator string(FieldData text) => text.Text;
    }
}
