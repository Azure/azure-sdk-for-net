// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    public class ExtractedForm
    {
        internal ExtractedForm(ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            // Unsupervised
            Pages = SetPages(pageResults, readResults);

            // TODO: how to set PageRange?
        }

        internal ExtractedForm(DocumentResult_internal documentResult, ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            // Supervised
            LearnedFormType = documentResult.DocType;
            PageRange = new PageRange(documentResult.PageRange);
            Pages = ConvertPages(documentResult, pageResults, readResults);
        }

        public string LearnedFormType { get; internal set; }

        public PageRange PageRange { get; internal set; }

        public IReadOnlyList<ExtractedPage> Pages { get; }

        private IReadOnlyList<ExtractedPage> SetPages(ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            // TODO: Are OCR results better at the form level?
            // TODO: How bad is the perf here, manipulating collections with Linq?
            Debug.Assert(pageResults.Count == readResults.Count);

            List<ExtractedPage> pages = new List<ExtractedPage>();

            List<PageResult_internal> pageResultList = pageResults.ToList();
            List<ReadResult_internal> readResultList = readResults.ToList();

            //foreach (var result in pageResults)
            for (int i = 0; i < pageResultList.Count; i++)
            {
                PageResult_internal pageResult = pageResultList[i];
                ReadResult_internal rawExtractedPage = readResultList[i];

                SetLearnedFormType(pageResult.ClusterId);

                ExtractedPage page = new ExtractedPage(pageResult, rawExtractedPage);
                pages.Add(page);
            }

            return pages.AsReadOnly();
        }

        private static IReadOnlyList<ExtractedPage> ConvertPages(DocumentResult_internal documentResult, ICollection<PageResult_internal> pageResults, ICollection<ReadResult_internal> readResults)
        {
            List<ExtractedPage> pages = new List<ExtractedPage>();
            List<PageResult_internal> pageResultsList = pageResults.ToList();
            List<ReadResult_internal> readResultsList = readResults.ToList();

            // TODO: improve performance here
            Dictionary<int, List<ExtractedField>> fieldsByPage = new Dictionary<int, List<ExtractedField>>();
            foreach (var field in documentResult.Fields)
            {
                // TODO: page 0 if null, can we do better?
                // TODO: How should we handle the multiple values per field and the strongly-typed ones?
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
                var page = new ExtractedPage(pageNumber, pageFields.Value, pageResultsList[pageNumber - 1], readResultsList[pageNumber - 1]);
                pages.Add(page);
            }

            return pages.AsReadOnly();
        }

        //private static IReadOnlyList<ExtractedPage> SetPages(DocumentResult_internal documentResult)
        //{
        //    List<ExtractedPage> pages = new List<ExtractedPage>();

        //    // TODO: improve performance here
        //    Dictionary<int, List<KeyValuePair<string, FieldValue_internal>>> fieldsByPage = new Dictionary<int, List<KeyValuePair<string, FieldValue_internal>>>();
        //    foreach (var field in documentResult.Fields)
        //    {
        //        // TODO: page 0 if null, can we do better?
        //        int pageNumber = field.Value.Page ?? 0;

        //        // TODO: How should we handle the multiple values per field and the strongly-typed ones?
        //        List<KeyValuePair<string, FieldValue_internal>> list;
        //        if (!fieldsByPage.TryGetValue(pageNumber, out list))
        //        {
        //            fieldsByPage[pageNumber] = new List<KeyValuePair<string, FieldValue_internal>>();
        //        }

        //        fieldsByPage[pageNumber].Add(field);
        //    }

        //    foreach (var pageFields in fieldsByPage)
        //    {
        //        var page = new ExtractedPage(pageFields.Key, pageFields.Value);
        //        pages.Add(page);
        //    }

        //    return pages.AsReadOnly();
        //}

        private void SetLearnedFormType(int? clusterId)
        {
            // TODO: Provide IFormatProvider
#pragma warning disable CA1305 // Specify IFormatProvider
            string formId = clusterId?.ToString();
#pragma warning restore CA1305 // Specify IFormatProvider

            // TODO: Does this make sense?
            if (formId != null)
            {
                Debug.Assert(LearnedFormType == formId, "Multiple form types found in ExtractedForm.");
                LearnedFormType = formId;
            }
        }
    }
}
