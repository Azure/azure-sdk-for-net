// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RecognizedForm
    {
        internal RecognizedForm(PageResult_internal pageResult, IReadOnlyList<ReadResult_internal> readResults)
        {
            // Recognized form from a model trained without labels.
            FormType = $"form-{pageResult.ClusterId}";
            PageRange = new FormPageRange(pageResult.Page, pageResult.Page);
            Fields = ConvertFields(pageResult.Page, pageResult.KeyValuePairs, readResults);
            Pages = ConvertPages(new List<PageResult_internal>() { pageResult }, readResults);
        }

        internal RecognizedForm(DocumentResult_internal documentResult, IReadOnlyList<PageResult_internal> pageResults, IReadOnlyList<ReadResult_internal> readResults)
        {
            // Recognized form from a model trained with labels.
            FormType = documentResult.DocType;

            // TODO: validate that PageRange.Length == 2.
            // https://github.com/Azure/azure-sdk-for-net/issues/10547

            PageRange = new FormPageRange(documentResult.PageRange[0], documentResult.PageRange[1]);
            Fields = ConvertFields(documentResult.Fields, readResults);
            Pages = ConvertPages(pageResults, readResults);
        }

        /// <summary>
        /// </summary>
        // Convert clusterId to a string (ex. "FormType1").
        public string FormType { get; }

        /// <summary>
        /// </summary>
        public FormPageRange PageRange { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyDictionary<string, FormField> Fields { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormPage> Pages { get; }

        private static IReadOnlyDictionary<string, FormField> ConvertFields(int pageNumber, IReadOnlyList<KeyValuePair_internal> keyValuePairs, IReadOnlyList<ReadResult_internal> readResults)
        {
            Dictionary<string, FormField> fieldDictionary = new Dictionary<string, FormField>();

            int i = 0;
            foreach (var keyValuePair in keyValuePairs)
            {
                var fieldName = keyValuePair.Label ?? $"field-{i++}";
                fieldDictionary[fieldName] = new FormField(fieldName, pageNumber, keyValuePair, readResults);
            }

            return fieldDictionary;
        }

        private static IReadOnlyDictionary<string, FormField> ConvertFields(IReadOnlyDictionary<string, FieldValue_internal> fields, IReadOnlyList<ReadResult_internal> readResults)
        {
            Dictionary<string, FormField> fieldDictionary = new Dictionary<string, FormField>();

            foreach (var field in fields)
            {
                fieldDictionary[field.Key] = new FormField(field.Key, field.Value, readResults);
            }

            return fieldDictionary;
        }

        private static IReadOnlyList<FormPage> ConvertPages(IReadOnlyList<PageResult_internal> pageResults, IReadOnlyList<ReadResult_internal> readResults)
        {
            List<FormPage> pages = new List<FormPage>();

            for (int i = 0; i < readResults.Count; i++)
            {
                pages.Add(new FormPage(pageResults != null ? pageResults[i] : null, readResults, i));
            }

            return pages;
        }
    }
}
