// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
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

        /// <summary>
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<ExtractedTable> Tables { get; }

        /// <summary>
        /// </summary>
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
