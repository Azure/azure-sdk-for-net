// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormWord : FormContent
    {
        internal FormWord(TextWord_internal textWord, int pageNumber)
            : base(new BoundingBox(textWord.BoundingBox), pageNumber, textWord.Text)
        {
            Confidence = textWord.Confidence;
        }

        /// <summary>
        /// </summary>
        public float? Confidence { get; }
    }
}
