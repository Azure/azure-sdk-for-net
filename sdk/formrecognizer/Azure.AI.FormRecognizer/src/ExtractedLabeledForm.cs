// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedLabeledForm
    {
        internal ExtractedLabeledForm(DocumentResult_internal documentResult, ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            // Supervised
            FormType = documentResult.DocType;

            // TODO: validate that PageRange.Length == 2.
            // https://github.com/Azure/azure-sdk-for-net/issues/10547
            StartPageNumber = documentResult.PageRange.First();
            EndPageNumber = documentResult.PageRange.Last();
            // TODO:
            Fields = ConvertFields(documentResult, pageResults, readResults);
        }

        public string FormType { get; internal set; }

        public int StartPageNumber { get; internal set; }

        public int EndPageNumber { get; internal set; }

        public IReadOnlyList<ExtractedField> Fields { get; }

        private static IReadOnlyList<ExtractedLabeledPage> ConvertPages(DocumentResult_internal documentResult, ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            List<ExtractedLabeledPage> pages = new List<ExtractedLabeledPage>();

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
                var page = new ExtractedLabeledPage(pageNumber, pageFields.Value, pageResults.ElementAt(pageNumber - 1), readResults.ElementAt(pageNumber - 1));
                pages.Add(page);
            }

            return pages;
        }
    }
}
