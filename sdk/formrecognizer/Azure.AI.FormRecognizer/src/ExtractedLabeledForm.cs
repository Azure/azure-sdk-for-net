// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedLabeledForm
    {
        internal ExtractedLabeledForm(DocumentResult_internal documentResult, IList<PageResult_internal> pageResults, IList<ReadResult_internal> readResults)
        {
            // Supervised
            FormType = documentResult.DocType;

            // TODO: validate that PageRange.Length == 2.
            // https://github.com/Azure/azure-sdk-for-net/issues/10547
            StartPageNumber = documentResult.PageRange.First();
            EndPageNumber = documentResult.PageRange.Last();

            Fields = ConvertFields(documentResult.Fields, readResults);

            Tables = ExtractedLayoutPage.ConvertLabeledTables(pageResults, readResults);

            if (readResults != null)
            {
                RawExtractedPages = ConvertRawPages(readResults);
            }
        }

        public string FormType { get; internal set; }

        public int StartPageNumber { get; internal set; }

        public int EndPageNumber { get; internal set; }

        public IReadOnlyList<ExtractedLabeledField> Fields { get; }

        public IReadOnlyList<ExtractedLabeledTable> Tables { get; }

        public IReadOnlyList<RawExtractedPage> RawExtractedPages { get; }

        private static IReadOnlyList<ExtractedLabeledField> ConvertFields(IDictionary<string, FieldValue_internal> fields, IList<ReadResult_internal> readResults)
        {
            List<ExtractedLabeledField> list = new List<ExtractedLabeledField>();
            foreach (var field in fields)
            {
                list.Add(new ExtractedLabeledField(field, readResults));
            }
            return list;
        }

        private static IReadOnlyList<RawExtractedPage> ConvertRawPages(IList<ReadResult_internal> readResults)
        {
            List<RawExtractedPage> rawPages = new List<RawExtractedPage>();
            foreach (var readResult in readResults)
            {
                rawPages.Add(new RawExtractedPage(readResult));
            }
            return rawPages;
        }
    }
}
