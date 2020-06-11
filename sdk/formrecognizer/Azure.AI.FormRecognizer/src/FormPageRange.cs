// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a page interval from the input document. Page numbers are 1-based.
    /// </summary>
    public struct FormPageRange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormPageRange"/> struct.
        /// </summary>
        /// <param name="first">The first page number of the range.</param>
        /// <param name="last">The last page number of the range.</param>
        internal FormPageRange(int first, int last)
        {
            FirstPageNumber = first;
            LastPageNumber = last;
        }

        /// <summary>
        /// The first page number of the range.
        /// </summary>
        public int FirstPageNumber { get; }

        /// <summary>
        /// The last page number of the range.
        /// </summary>
        public int LastPageNumber { get; }
    }
}
