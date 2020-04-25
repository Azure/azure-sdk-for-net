// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a page interval from the input document. Page numbers are 1-based.
    /// </summary>
    public class FormPageRange
    {
        internal FormPageRange(int first, int last)
        {
            FirstPageNumber = first;
            LastPageNumber = last;
        }

        /// <summary>
        /// The first page number of the range.
        /// </summary>
        public int FirstPageNumber { get; internal set; }

        /// <summary>
        /// The last page number of the range.
        /// </summary>
        public int LastPageNumber { get; internal set; }
    }
}
