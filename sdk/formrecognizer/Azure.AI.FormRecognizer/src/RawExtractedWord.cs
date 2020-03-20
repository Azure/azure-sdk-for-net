// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RawExtractedWord : RawExtractedItem
    {
        internal RawExtractedWord(TextWord_internal textWord)
        {
            BoundingBox = new BoundingBox(textWord.BoundingBox);
            Confidence = textWord.Confidence;
            Text = textWord.Text;
        }
        /// <summary>
        /// </summary>

        public float? Confidence { get; }

        /// <summary>
        /// </summary>

        public static implicit operator string(RawExtractedWord word) => word.Text;
    }
}
