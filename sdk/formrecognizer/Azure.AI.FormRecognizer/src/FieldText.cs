// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents either a key or a value in the key-value pair that constitutes
    /// the corresponding <see cref="FormField"/> recognized from the input document.
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
        /// A list of refereces to the text elements constituting this <see cref="FieldText"/>.
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
