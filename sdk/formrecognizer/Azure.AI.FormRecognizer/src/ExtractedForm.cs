// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedForm
    {
        internal ExtractedForm(ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            // Unsupervised
            Pages = SetPages(pageResults, readResults);

            // TODO: Set page range from page numbers in pageResults
            // https://github.com/Azure/azure-sdk-for-net/issues/10365
        }

        internal ExtractedForm(DocumentResult_internal documentResult, ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            // Supervised
            LearnedFormType = documentResult.DocType;
            StartPageNumber = documentResult.PageRange.First();
            EndPageNumber = documentResult.PageRange.Last();
            Pages = ConvertPages(documentResult, pageResults, readResults);
        }

        public string LearnedFormType { get; internal set; }

        public int StartPageNumber { get; internal set; }

        public int EndPageNumber { get; internal set; }

        public IReadOnlyList<ExtractedPage> Pages { get; }

        private IReadOnlyList<ExtractedPage> SetPages(ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            // TODO: Add validation and appropriate exception if these don't match.
            // https://github.com/Azure/azure-sdk-for-net/issues/10366
            Debug.Assert(pageResults.Count == readResults.Count);

            List<ExtractedPage> pages = new List<ExtractedPage>();

            for (int i = 0; i < pageResults.Count; i++)
            {
                PageResult_internal pageResult = pageResults.ElementAt(i);
                ReadResult_internal rawExtractedPage = readResults.ElementAt(i);

                SetLearnedFormType(pageResult.ClusterId);

                ExtractedPage page = new ExtractedPage(pageResult, rawExtractedPage);
                pages.Add(page);
            }

            return pages;
        }

        private static IReadOnlyList<ExtractedPage> ConvertPages(DocumentResult_internal documentResult, ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            List<ExtractedPage> pages = new List<ExtractedPage>();

            Dictionary<int, List<ExtractedField>> fieldsByPage = new Dictionary<int, List<ExtractedField>>();
            foreach (var field in documentResult.Fields)
            {
                // TODO: We are currently setting the field page to 0 if field.Value.Page comes back as null.
                // https://github.com/Azure/azure-sdk-for-net/issues/10369

                // TODO: How should we handle the multiple values per field and the strongly-typed ones?
                // https://github.com/Azure/azure-sdk-for-net/issues/10333

                List<ExtractedField> list;
                if (!fieldsByPage.TryGetValue(field.Value.Page ?? 0, out list))
                {
                    fieldsByPage[field.Value.Page ?? 0] = new List<ExtractedField>();
                }

                fieldsByPage[field.Value.Page ?? 0].Add(new ExtractedField(field));
            }

            foreach (var pageFields in fieldsByPage)
            {
                int pageNumber = pageFields.Key;
                var page = new ExtractedPage(pageNumber, pageFields.Value, pageResults.ElementAt(pageNumber - 1), readResults.ElementAt(pageNumber - 1));
                pages.Add(page);
            }

            return pages;
        }

        private void SetLearnedFormType(int? clusterId)
        {
            // TODO: Provide IFormatProvider
            // https://github.com/Azure/azure-sdk-for-net/issues/10376
#pragma warning disable CA1305 // Specify IFormatProvider
            string formId = clusterId?.ToString();
#pragma warning restore CA1305 // Specify IFormatProvider

            if (formId != null)
            {
                // TODO: is it possible that multiple pages in a page result could have different page numbers?
                // https://github.com/Azure/azure-sdk-for-net/issues/10377
                Debug.Assert(LearnedFormType == formId, "Multiple form types found in ExtractedForm.");
                LearnedFormType = formId;
            }
        }
    }
}
