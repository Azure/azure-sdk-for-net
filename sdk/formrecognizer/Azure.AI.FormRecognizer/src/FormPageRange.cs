// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormPageRange
    {
        internal FormPageRange(int first, int last)
        {
            FirstPageNumber = first;
            LastPageNumber = last;
        }

        /// <summary>
        /// </summary>
        public int FirstPageNumber { get; internal set; }

        /// <summary>
        /// </summary>
        public int LastPageNumber { get; internal set; }
    }
}
