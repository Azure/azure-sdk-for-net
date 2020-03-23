// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

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
            PageRange = new FormPageRange(documentResult.PageRange);

            Fields = ConvertFields(documentResult.Fields, readResults);
            Tables = ConvertLabeledTables(pageResults, readResults);

            // TODO: Populate CheckBoxes

            if (readResults != null)
            {
                PageInfos = ConvertPageInfo(readResults);
                TextElements = ConvertPageText(readResults);
            }
        }

        /// <summary>
        /// </summary>
        public string FormType { get; }

        /// <summary>
        /// </summary>
        public float FormTypeConfidence { get; }

        /// <summary>
        /// </summary>
        public FormPageRange PageRange { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<LabeledFormField> Fields { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<LabeledFormTable> Tables { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<LabeledFormCheckBox> CheckBoxes { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormPageInfo> PageInfos { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormPageText> TextElements { get; }

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

        internal static IReadOnlyList<FormPageInfo> ConvertPageInfo(IList<ReadResult_internal> readResults)
        {
            List<FormPageInfo> pageInfos = new List<FormPageInfo>();
            foreach (var readResult in readResults)
            {
                pageInfos.Add(new FormPageInfo(readResult));
            }
            return pageInfos;
        }

        internal static IReadOnlyList<FormPageText> ConvertPageText(IList<ReadResult_internal> readResults)
        {
            List<FormPageText> pageTexts = new List<FormPageText>();
            foreach (var readResult in readResults)
            {
                if (readResult.Lines != null)
                {
                    pageTexts.Add(new FormPageText(readResult.Lines));
                }
            }
            return pageTexts;
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
