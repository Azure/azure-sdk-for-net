// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormText : FormTextElement
    {
        internal FormText(string text, BoundingBox boundingBox, float? confidence)
            : base(text, boundingBox, confidence)
        {
            //Confidence = confidence;
            //BoundingBox = boundingBox;
            //Text = text;
        }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormText> TextElements { get; internal set; }

        ///// <summary>
        ///// </summary>
        //public float? Confidence { get; }

        ///// <summary>
        ///// </summary>
        //public BoundingBox BoundingBox { get; }

        ///// <summary>
        ///// </summary>
        //public string Text { get; }

        ///// <summary>
        ///// </summary>
        ///// <param name="text"></param>
        //public static implicit operator string(FormText text) => text.Text;
    }
}
