// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormPageText
    {
        internal FormPageText(ICollection<TextLine_internal> lines)
        {
            Lines = ConvertLines(lines);
        }

        /// <summary> When includeTextDetails is set to true, a list of recognized text lines. The maximum number of lines returned is 300 per page. The lines are sorted top to bottom, left to right, although in certain cases proximity is treated with higher priority. As the sorting order depends on the detected text, it may change across images and OCR version updates. Thus, business logic should be built upon the actual line location instead of order. </summary>
        public ICollection<LineTextElement> Lines { get; set; }

        private static ICollection<LineTextElement> ConvertLines(ICollection<TextLine_internal> textLines)
        {
            List<LineTextElement> rawLines = new List<LineTextElement>();

            foreach (TextLine_internal textLine in textLines)
            {
                rawLines.Add(new LineTextElement(textLine));
            }

            return rawLines;
        }
    }
}
