// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Represents a form that has been recognized by a trained model.
    /// </summary>
    public class RecognizedForm
    {
        internal RecognizedForm(PageResult pageResult, IReadOnlyList<ReadResult> readResults, int pageIndex, string modelId)
        {
            // Recognized form from a model trained without labels.
            FormType = $"form-{pageResult.ClusterId}";
            PageRange = new FormPageRange(pageResult.Page, pageResult.Page);
            Fields = ConvertUnsupervisedFields(pageResult.Page, pageResult.KeyValuePairs, readResults);

            // For models trained without labels, the service treats every page as a separate form, so
            // we end up with a single page per form.

            Pages = new List<FormPage> { new FormPage(pageResult, readResults, pageIndex) };
            ModelId = modelId;
            // Form type confidence doesn't apply for a model trained without labels.
            FormTypeConfidence = null;
        }

        internal RecognizedForm(DocumentResult documentResult, IReadOnlyList<PageResult> pageResults, IReadOnlyList<ReadResult> readResults, string modelId)
        {
            // Recognized form from a model trained with labels.
            FormType = documentResult.DocType;

            PageRange = new FormPageRange(documentResult.PageRange[0], documentResult.PageRange[1]);

            // documentResult.Fields is required and not null, according to the swagger file, but it's not
            // present when a blank receipt is submitted for recognition.

            Fields = documentResult.Fields == null
                ? new Dictionary<string, FormField>()
                : ConvertSupervisedFields(documentResult.Fields, readResults);
            Pages = ConvertSupervisedPages(pageResults, readResults);
            ModelId = documentResult.ModelId.HasValue ? documentResult.ModelId.Value.ToString() : modelId;
            FormTypeConfidence = documentResult.DocTypeConfidence ?? Constants.DefaultConfidenceValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizedForm"/> class.
        /// </summary>
        /// <param name="formType">The type of form the model identified the submitted form to be.</param>
        /// <param name="pageRange">The range of pages this form spans.</param>
        /// <param name="fields">A dictionary of the fields recognized from the input document.</param>
        /// <param name="pages">A list of pages describing the recognized form elements present in the input document.</param>
        /// <param name="modelId">Model identifier of model used to analyze form if not using a prebuilt model.</param>
        /// <param name="confidence">Confidence on the type of form the model identified the submitted form to be.</param>
        internal RecognizedForm(string formType, FormPageRange pageRange, IReadOnlyDictionary<string, FormField> fields, IReadOnlyList<FormPage> pages, string modelId, float? confidence)
        {
            FormType = formType;
            PageRange = pageRange;
            Fields = fields;
            Pages = pages;
            ModelId = modelId;
            FormTypeConfidence = confidence;
        }

        /// <summary>
        /// The type of form the model identified the submitted form to be.
        /// </summary>
        // Convert clusterId to a string (ex. "FormType1").
        public string FormType { get; }

        /// <summary>
        /// Model identifier of model used to analyze form if not using a prebuilt model.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// Confidence on the type of form the model identified the submitted form to be.
        /// Value is 1.0 when recognition is done against a single labeled model.
        /// If recognition is based on a composed model, value is between [0.0, 1.0].
        /// </summary>
        public float? FormTypeConfidence { get; }

        /// <summary>
        /// The range of pages this form spans.
        /// </summary>
        public FormPageRange PageRange { get; }

        /// <summary>
        /// A dictionary of the fields recognized from the input document. The key is
        /// the <see cref="FormField.Name"/> of the field. For models trained with labels,
        /// this is the training-time label of the field. For models trained with forms
        /// only, a unique name is generated for each field.
        /// </summary>
        public IReadOnlyDictionary<string, FormField> Fields { get; }

        /// <summary>
        /// A list of pages describing the recognized form elements present in the input
        /// document.
        /// </summary>
        public IReadOnlyList<FormPage> Pages { get; }

        private static IReadOnlyDictionary<string, FormField> ConvertUnsupervisedFields(int pageNumber, IReadOnlyList<KeyValuePair> keyValuePairs, IReadOnlyList<ReadResult> readResults)
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

        private static IReadOnlyDictionary<string, FormField> ConvertSupervisedFields(IReadOnlyDictionary<string, FieldValue_internal> fields, IReadOnlyList<ReadResult> readResults)
        {
            Dictionary<string, FormField> fieldDictionary = new Dictionary<string, FormField>();

            foreach (var field in fields)
            {
                fieldDictionary[field.Key] = field.Value == null
                    ? null
                    : new FormField(field.Key, field.Value, readResults);
            }

            return fieldDictionary;
        }

        private IReadOnlyList<FormPage> ConvertSupervisedPages(IReadOnlyList<PageResult> pageResults, IReadOnlyList<ReadResult> readResults)
        {
            List<FormPage> pages = new List<FormPage>();

            for (int i = 0; i < readResults.Count; i++)
            {
                // Check range here so only pages that are part of this form are added. Avoid "pageNumber = i + 1"
                // because it is not safe to assume the pages will always be in order.

                var pageNumber = readResults[i].Page;

                if (pageNumber >= PageRange.FirstPageNumber && pageNumber <= PageRange.LastPageNumber)
                {
                    pages.Add(new FormPage(pageResults.Any() ? pageResults[i] : null, readResults, i));
                }
            }

            return pages;
        }
    }
}
