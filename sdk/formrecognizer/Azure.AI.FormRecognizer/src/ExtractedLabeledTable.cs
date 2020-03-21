// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class LabeledFormTable : FormTable
    {
        internal LabeledFormTable(DataTable_internal table, ReadResult_internal readResult, int pageNumber)
            :  base(table, readResult)
        {
            PageNumber = pageNumber;
        }

        /// <summary>
        /// </summary>
        public int PageNumber { get; }
    }
}
