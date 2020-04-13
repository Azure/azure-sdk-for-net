// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
{
    /// <summary>
    /// </summary>
    public class ExtractedLabeledTable : FormTable
    {
        internal ExtractedLabeledTable(DataTable_internal table, ReadResult_internal readResult)
            :  base(table, readResult)
        {
        }
    }
}
