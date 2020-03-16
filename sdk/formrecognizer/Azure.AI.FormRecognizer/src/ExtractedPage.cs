// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
{
    /// <summary>
    /// </summary>
    // Maps to PageResult
    public class ExtractedPage
    {
        // Unsupervised
        internal ExtractedPage(PageResult_internal pageResult, ReadResult_internal readResult)
        {
            PageNumber = pageResult.Page;
            FormTypeId = pageResult.ClusterId;
            Fields = ConvertFields(pageResult.KeyValuePairs, readResult);
            Tables = ExtractedLayoutPage.ConvertTables(pageResult.Tables, readResult);

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
        public int? FormTypeId { get; }

        /// <summary>
        /// </summary>

        public IReadOnlyList<ExtractedField> Fields { get; }

        /// <summary>
        /// </summary>

        public IReadOnlyList<ExtractedTable> Tables { get; }

        /// <summary>
        /// </summary>
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
    }
}
