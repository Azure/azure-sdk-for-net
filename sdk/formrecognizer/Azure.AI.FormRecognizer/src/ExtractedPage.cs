// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
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

        // Supervised
        internal ExtractedPage(int pageNumber, List<ExtractedField> fields, PageResult_internal pageResult, ReadResult_internal readResult)
        {
            PageNumber = pageNumber;
            Fields = ConvertFields(fields);
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

        private static IReadOnlyList<ExtractedField> ConvertFields(List<ExtractedField> fields)
        {
            List<ExtractedField> list = new List<ExtractedField>();
            foreach (var field in fields)
            {
                list.Add(field);
            }
            return list;
        }
    }
}
