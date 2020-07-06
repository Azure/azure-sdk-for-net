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
        /// </summary>
        /// <param name="formElement"></param>
        /// <param name="pageNumber"></param>
        /// <param name="boundingBox"></param>
        /// <param name="text"></param>
        internal FieldData(string text, int pageNumber, BoundingBox boundingBox, IReadOnlyList<FormElement> formElement)
            : base(boundingBox, pageNumber, text)
        {
            FieldElements = formElement;
        }

        /// <summary>
        /// When <see cref="RecognizeOptions.IncludeFieldElements"/> is set to <c>true</c>, a list of references to
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
