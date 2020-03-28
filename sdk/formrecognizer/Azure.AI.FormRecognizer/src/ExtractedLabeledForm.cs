// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RecognizedForm
    {
#pragma warning disable CA1801 // Remove unused parameter
        internal RecognizedForm(DocumentResult_internal documentResult, IList<PageResult_internal> pageResults, IList<ReadResult_internal> readResults)
#pragma warning restore CA1801 // Remove unused parameter
        {
            // Supervised
            FormType = documentResult.DocType;
            PageRange = new FormPageRange(documentResult.PageRange);

            //Fields = ConvertFields(documentResult.Fields, readResults);
            //Tables = ConvertLabeledTables(pageResults, readResults);

            //// TODO: Populate CheckBoxes

            //if (readResults != null)
            //{
            //    PageText = ConvertPageText(readResults);
            //}
        }

        /// <summary>
        /// </summary>
        // Convert clusterId to a string (ex. "FormType1").
        public string FormType { get; }

        /// <summary>
        /// </summary>
        public float? FormTypeConfidence { get; }

        /// <summary>
        /// </summary>
        public FormPageRange PageRange { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormField> Fields { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormPage> Pages { get; }

        /// <summary>
        /// Return the first field of the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool TryGetFieldValue(string name, out FormField field)
        {
            field = Fields.Where(f => f.Name == name).FirstOrDefault();

            return field != default;
        }

        //private static IReadOnlyList<LabeledFormField> ConvertFields(IDictionary<string, FieldValue_internal> fields, IList<ReadResult_internal> readResults)
        //{
        //    List<LabeledFormField> list = new List<LabeledFormField>();
        //    foreach (var field in fields)
        //    {
        //        list.Add(new LabeledFormField(field, readResults));
        //    }
        //    return list;
        //}


        //internal static IReadOnlyList<FormPageElements> ConvertPageText(IList<ReadResult_internal> readResults)
        //{
        //    List<FormPageElements> pageTexts = new List<FormPageElements>();
        //    foreach (var readResult in readResults)
        //    {
        //        if (readResult.Lines != null)
        //        {
        //            pageTexts.Add(new FormPageElements(readResult));
        //        }
        //    }
        //    return pageTexts;
        //}

        //internal static IReadOnlyList<LabeledFormTable> ConvertLabeledTables(IList<PageResult_internal> pageResults, IList<ReadResult_internal> readResults)
        //{
        //    List<LabeledFormTable> tables = new List<LabeledFormTable>();

        //    foreach (var pageResult in pageResults)
        //    {
        //        foreach (var table in pageResult.Tables)
        //        {
        //            tables.Add(new LabeledFormTable(table, readResults[pageResult.Page - 1], pageResult.Page));
        //        }
        //    }

        //    return tables;
        //}
    }
}
