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
        internal FormPageRange(IReadOnlyList<int> pageRange)
        {
            // TODO: validate that PageRange.Length == 2.
            // https://github.com/Azure/azure-sdk-for-net/issues/10547
            FirstPageNumber = pageRange[0];
            LastPageNumber = pageRange[1];
        }

        /// <summary>
        /// </summary>
        public int FirstPageNumber { get; internal set; }

        /// <summary>
        /// </summary>
        public int LastPageNumber { get; internal set; }
    }
}
