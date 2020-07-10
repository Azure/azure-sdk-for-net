// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a word recognized from the input document.
    /// </summary>
    public class FormWord : FormElement
    {
        internal FormWord(TextWord_internal textWord, int pageNumber)
            : base(new BoundingBox(textWord.BoundingBox), pageNumber, textWord.Text)
        {
            Confidence = textWord.Confidence != null ? textWord.Confidence.Value : Constants.DefaultConfidenceValue;
        }

        /// <summary>
        /// Measures the degree of certainty of the recognition result. Value is between [0.0, 1.0].
        /// </summary>
        public float Confidence { get; }
    }
}
