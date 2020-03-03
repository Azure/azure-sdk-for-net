// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.FormRecognizer.Models
{
    public class RawExtractedWord : RawExtractedItem
    {
        public RawExtractedWord(TextWord_internal textWord)
        {
            BoundingBox = new BoundingBox(textWord.BoundingBox);
            Confidence = textWord.Confidence;
            Text = textWord.Text;
        }

        public float? Confidence { get; }

        public static implicit operator string(RawExtractedWord word) => word.Text;
    }
}
