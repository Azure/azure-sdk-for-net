// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class CustomLabeledForm
    {
        internal CustomLabeledForm(DocumentResult_internal documentResult, IList<PageResult_internal> pageResults, IList<ReadResult_internal> readResults)
        {
            // Supervised
            FormType = documentResult.DocType;

            // TODO: validate that PageRange.Length == 2.
            // https://github.com/Azure/azure-sdk-for-net/issues/10547
            StartPageNumber = documentResult.PageRange.First();
            EndPageNumber = documentResult.PageRange.Last();

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
        public IReadOnlyList<LabeledFormField> Fields { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<LabeledFormTable> Tables { get; }

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

        private static IReadOnlyList<LabeledFormField> ConvertFields(IDictionary<string, FieldValue_internal> fields, IList<ReadResult_internal> readResults)
        {
            List<LabeledFormField> list = new List<LabeledFormField>();
            foreach (var field in fields)
            {
                list.Add(new LabeledFormField(field, readResults));
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

        internal static IReadOnlyList<LabeledFormTable> ConvertLabeledTables(IList<PageResult_internal> pageResults, IList<ReadResult_internal> readResults)
        {
            List<LabeledFormTable> tables = new List<LabeledFormTable>();

            foreach (var pageResult in pageResults)
            {
                foreach (var table in pageResult.Tables)
                {
                    tables.Add(new LabeledFormTable(table, readResults[pageResult.Page - 1], pageResult.Page));
                }
            }

            return tables;
        }
    }
}
