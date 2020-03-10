// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    public class PageRange
    {
        internal PageRange(ICollection<int> pageRange)
        {
            Debug.Assert(pageRange.Count == 2);

            StartPageNumber = pageRange.First();
            EndPageNumber = pageRange.Last();
        }

        public int EndPageNumber { get; }

        public int StartPageNumber { get; }
    }
}
