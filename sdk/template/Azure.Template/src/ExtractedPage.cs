// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedPage
    {
        // Unsupervised
        internal ExtractedPage(PageResult_internal pageResult, RawExtractedPage rawExtractedPage)
        {
            PageNumber = pageResult.Page;
            Fields = ConvertFields(pageResult.KeyValuePairs);
            Tables = ExtractedLayoutPage.ConvertTables(pageResult.Tables);
            RawExtractedPage = rawExtractedPage;
        }

        // Supervised
        internal ExtractedPage(int pageNumber, List<ExtractedField> fields, PageResult_internal pageResult, RawExtractedPage rawExtractedPage)
        {
            PageNumber = pageNumber;
            Fields = ConvertFields(fields);
            Tables = ExtractedLayoutPage.ConvertTables(pageResult.Tables);
            RawExtractedPage = rawExtractedPage;
        }

        public int PageNumber { get; }

        public IReadOnlyList<ExtractedField> Fields { get; }
        public IReadOnlyList<ExtractedTable> Tables { get; }

        public RawExtractedPage RawExtractedPage { get; }

        private static IReadOnlyList<ExtractedField> ConvertFields(ICollection<KeyValuePair_internal> keyValuePairs)
        {
            List<ExtractedField> fields = new List<ExtractedField>();
            foreach (var kvp in keyValuePairs)
            {
                ExtractedField field = new ExtractedField(kvp);
                fields.Add(field);
            }
            return fields.AsReadOnly();
        }

        private static IReadOnlyList<ExtractedField> ConvertFields(List<ExtractedField> fields)
        {
            List<ExtractedField> list = new List<ExtractedField>();
            foreach (var field in fields)
            {
                list.Add(field);
            }
            return list.AsReadOnly();
        }
    }
}
