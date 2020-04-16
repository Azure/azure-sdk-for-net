// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
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
        /// </summary>
        public IReadOnlyList<FormContent> TextContent { get; }

        /// <summary>
        /// </summary>
        /// <param name="text"></param>
        public static implicit operator string(FieldText text) => text.Text;
    }
}
