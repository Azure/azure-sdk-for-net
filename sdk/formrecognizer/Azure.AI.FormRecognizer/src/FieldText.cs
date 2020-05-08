// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// A form content element representing text that is part of a <see cref="FormField"/>.
    /// This includes the location of the text in the form and a collection of the content
    /// elements that make up the text.
    /// </summary>
    public class FieldText : FormContent
    {
        /// <summary>
        /// </summary>
        /// <param name="formContent"></param>
        /// <param name="pageNumber"></param>
        /// <param name="boundingBox"></param>
        /// <param name="text"></param>
        internal FieldText(string text, int pageNumber, BoundingBox boundingBox, IReadOnlyList<FormContent> formContent)
            : base(boundingBox, pageNumber, text)
        {
            TextContent = formContent;
        }

        /// <summary>
        /// When <see cref="RecognizeOptions.IncludeTextContent"/> is set to <c>true</c>, a list of references to
        /// the text elements constituting this <see cref="FieldText"/>. An empty list otherwise. For calls to
        /// recognize content, this list is always populated.
        /// </summary>
        public IReadOnlyList<FormContent> TextContent { get; }

        /// <summary>
        /// Implicitly converts a <see cref="FieldText"/> instance into a <see cref="string"/>, using the
        /// value returned by <see cref="FormContent.Text"/>.
        /// </summary>
        /// <param name="text">The instance to be converted into a <see cref="string"/>.</param>
        /// <returns>The <see cref="string"/> corresponding to the recognized text.</returns>
        public static implicit operator string(FieldText text) => text.Text;
    }
}
