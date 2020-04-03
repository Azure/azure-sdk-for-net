// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormWord : FormContent
    {
        internal FormWord(TextWord_internal textWord)
            : base(textWord.Text, new BoundingBox(textWord.BoundingBox), 0 /* "TODO" */)
        {
            Confidence = textWord.Confidence;
        }

        /// <summary>
        /// </summary>
        public float? Confidence { get; }

    }
}
