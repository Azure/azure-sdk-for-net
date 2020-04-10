// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
{
    /// <summary>
    /// </summary>
    public class ExtractedLabeledForm
    {
        internal ExtractedLabeledForm(DocumentResult_internal documentResult, IReadOnlyList<PageResult_internal> pageResults, IReadOnlyList<ReadResult_internal> readResults)
        {
            // Supervised
            FormType = documentResult.DocType;

            // TODO: validate that PageRange.Length == 2.
            // https://github.com/Azure/azure-sdk-for-net/issues/10547
            StartPageNumber = documentResult.PageRange[0];
            EndPageNumber = documentResult.PageRange[documentResult.PageRange.Count - 1];

            Fields = ConvertFields(documentResult.Fields, readResults);

            Tables = ConvertLabeledTables(pageResults, readResults);

            if (readResults != null)
            {
                RawExtractedPages = ConvertRawPages(readResults);
            }
        }

        /// <summary>
        /// </summary>
        public string FormType { get; internal set; }

        /// <summary>
        /// </summary>
        public int StartPageNumber { get; internal set; }

        /// <summary>
        /// </summary>
        public int EndPageNumber { get; internal set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<ExtractedLabeledField> Fields { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<ExtractedLabeledTable> Tables { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<RawExtractedPage> RawExtractedPages { get; }

        /// <summary>
        /// Return the field value text for a given label.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public string GetFieldValue(string label)
        {
            var field = Fields.Where(f => f.Label == label).FirstOrDefault();
            if (field == default)
            {
                throw new FieldNotFoundException($"Field '{label}' not found on form.");
            }

            return field.Value;
        }

        private static IReadOnlyList<ExtractedLabeledField> ConvertFields(IReadOnlyDictionary<string, FieldValue_internal> fields, IReadOnlyList<ReadResult_internal> readResults)
        {
            List<ExtractedLabeledField> list = new List<ExtractedLabeledField>();
            foreach (var field in fields)
            {
                list.Add(new ExtractedLabeledField(field, readResults));
            }
            return list;
        }

        private static IReadOnlyList<RawExtractedPage> ConvertRawPages(IReadOnlyList<ReadResult_internal> readResults)
        {
            List<RawExtractedPage> rawPages = new List<RawExtractedPage>();
            foreach (var readResult in readResults)
            {
                rawPages.Add(new RawExtractedPage(readResult));
            }
            return rawPages;
        }

        internal static IReadOnlyList<ExtractedLabeledTable> ConvertLabeledTables(IReadOnlyList<PageResult_internal> pageResults, IReadOnlyList<ReadResult_internal> readResults)
        {
            List<ExtractedLabeledTable> tables = new List<ExtractedLabeledTable>();

            foreach (var pageResult in pageResults)
            {
                foreach (var table in pageResult.Tables)
                {
                    tables.Add(new ExtractedLabeledTable(table, readResults[pageResult.Page - 1]));
                }
            }

            return tables;
        }
    }
}
