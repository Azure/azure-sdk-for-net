// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormWord : FormContent
    {
        internal FormWord(TextWord_internal textWord)
            : base(textWord.Text, new BoundingBox(textWord.BoundingBox))
        {
            Confidence = textWord.Confidence;
        }

        /// <summary>
        /// </summary>
        public float? Confidence { get; }

        /// <summary>
        /// </summary>
        public FormTextStyle Style { get; internal set; }

    }
}
