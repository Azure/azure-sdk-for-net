// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
{
    /// <summary>
    /// </summary>
    public class ExtractedLabeledTable : ExtractedTable
    {
        internal ExtractedLabeledTable(DataTable_internal table, ReadResult_internal readResult, int pageNumber)
            :  base(table, readResult)
        {
            PageNumber = pageNumber;
        }

        /// <summary>
        /// </summary>
        public int PageNumber { get; }
    }
}
