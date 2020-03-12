// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    // Maps to PageResult
    public class ExtractedPage
    {
        // Unsupervised
        internal ExtractedPage(PageResult_internal pageResult, ReadResult_internal readResult)
        {
            PageNumber = pageResult.Page;
            Fields = ConvertFields(pageResult.KeyValuePairs, readResult);
            Tables = ExtractedLayoutPage.ConvertTables(pageResult.Tables, readResult);

            if (readResult != null)
            {
                RawExtractedPage = new RawExtractedPage(readResult);
            }
        }

        public int PageNumber { get; }

        public IReadOnlyList<ExtractedField> Fields { get; }

        public IReadOnlyList<ExtractedTable> Tables { get; }

        public RawExtractedPage RawExtractedPage { get; }

        // TODO: Unmerge Convert Fields
        private static IReadOnlyList<ExtractedField> ConvertFields(ICollection<KeyValuePair_internal> keyValuePairs, ReadResult_internal readResult)
        {
            List<ExtractedField> fields = new List<ExtractedField>();
            foreach (var kvp in keyValuePairs)
            {
                ExtractedField field = new ExtractedField(kvp, readResult);
                fields.Add(field);
            }
            return fields;
        }
    }
}
