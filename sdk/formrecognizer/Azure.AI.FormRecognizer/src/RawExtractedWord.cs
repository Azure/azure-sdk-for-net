// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class WordTextElement : FormTextElement
    {
        internal WordTextElement(TextWord_internal textWord)
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

        public static implicit operator string(WordTextElement word) => word.Text;
    }
}
