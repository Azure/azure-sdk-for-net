// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedLayoutPage
    {
        internal ExtractedLayoutPage(PageResult_internal pageResult, RawExtractedPage rawExtractedPage)
        {
            PageNumber = pageResult.Page;
            Tables = ConvertTables(pageResult.Tables);
            RawExtractedPage = rawExtractedPage;
        }

        public int PageNumber { get; }

        public IReadOnlyList<ExtractedTable> Tables { get; }

        public RawExtractedPage RawExtractedPage { get; }

        internal static IReadOnlyList<ExtractedTable> ConvertTables(ICollection<DataTable_internal> tablesResult)
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
