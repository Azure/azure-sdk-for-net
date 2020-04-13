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
        public IReadOnlyList<FormTable> Tables { get; }

        /// <summary>
        /// </summary>
        public RawExtractedPage RawExtractedPage { get; }

        internal static IReadOnlyList<FormTable> ConvertTables(IReadOnlyList<DataTable_internal> tablesResult, ReadResult_internal readResult)
        {
            List<FormTable> tables = new List<FormTable>();

            foreach (var result in tablesResult)
            {
                tables.Add(new FormTable(result, readResult));
            }

            return tables;
        }
    }
}
