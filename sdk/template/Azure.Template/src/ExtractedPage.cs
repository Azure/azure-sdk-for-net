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
        internal ExtractedPage(PageResult_internal pageResult)
        {
            PageNumber = pageResult.Page;
            Fields = SetFields(pageResult.KeyValuePairs);
            Tables = ExtractedLayoutPage.ConvertTables(pageResult.Tables);
        }

        // Supervised
        internal ExtractedPage(int pageNumber, List<ExtractedField> fields, PageResult_internal pageResult)
        {
            PageNumber = pageNumber;
            Fields = ConvertFields(fields);
            Tables = ExtractedLayoutPage.ConvertTables(pageResult.Tables);
        }

        public int PageNumber { get; }

        public IReadOnlyList<ExtractedField> Fields { get; }
        public IReadOnlyList<ExtractedTable> Tables { get; }

        //public RawExtractedPageInfo RawPageInfo { get; }

        private IReadOnlyList<ExtractedField> SetFields(ICollection<KeyValuePair_internal> keyValuePairs)
        {
            List<ExtractedField> fields = new List<ExtractedField>();
            foreach (var kvp in keyValuePairs)
            {
                ExtractedField field = new ExtractedField()
                {
                    Confidence = kvp.Confidence,
                    Label = kvp.Key.Text,
                    // TODO: Better way to handle nulls here?
                    LabelOutline = kvp.Key.BoundingBox == null ? null : new BoundingBox(kvp.Key.BoundingBox),
                    Value = kvp.Value.Text,
                    ValueOutline = new BoundingBox(kvp.Value.BoundingBox)
                };
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
