// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedLayoutPage
    {
        internal ExtractedLayoutPage(PageResult_internal pageResult, ReadResult_internal readResult)
        {
            PageNumber = pageResult.Page;
            Tables = ConvertTables(pageResult.Tables, readResult);

            if (readResult != null)
            {
                RawExtractedPage = new RawExtractedPage(readResult);
            }
        }

        public int PageNumber { get; }

        public IReadOnlyList<ExtractedTable> Tables { get; }

        public RawExtractedPage RawExtractedPage { get; }

        internal static IReadOnlyList<ExtractedTable> ConvertTables(ICollection<DataTable_internal> tablesResult, ReadResult_internal readResult)
        {
            List<ExtractedTable> tables = new List<ExtractedTable>();

            foreach (var result in tablesResult)
            {
                tables.Add(new ExtractedTable(result, readResult));
            }

            return tables;
        }
    }
}
