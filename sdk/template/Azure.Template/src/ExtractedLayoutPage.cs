// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer
{
    public class ExtractedLayoutPage
    {
        public ExtractedLayoutPage(PageResult_internal pageResult)
        {
            PageNumber = pageResult.Page;
            Tables = SetTables(pageResult.Tables);
        }

        public int PageNumber { get; }

        public IReadOnlyList<ExtractedTable> Tables { get; }

        //public RawExtractedPageInfo RawPageInfo { get; }

        private static IReadOnlyList<ExtractedTable> SetTables(ICollection<DataTable_internal> tablesResult)
        {
            List<ExtractedTable> tables = new List<ExtractedTable>();

            foreach (var result in tablesResult)
            {
                tables.Add(new ExtractedTable(result));
            }

            return tables.AsReadOnly();
        }
    }
}
