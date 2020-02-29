// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer
{
    public class ExtractedForm
    {
        internal ExtractedForm(AnalyzeResult_internal analyzeResult)
        {
            Pages = SetPages(analyzeResult.PageResults);
        }

        public string LearnedFormId { get; internal set; }

        public IReadOnlyList<ExtractedPage> Pages { get; }

        private IReadOnlyList<ExtractedPage> SetPages(ICollection<PageResult_internal> pageResults)
        {
            List<ExtractedPage> pages = new List<ExtractedPage>();
            foreach (var pageResult in pageResults)
            {
                SetLearnedFormId(pageResult.ClusterId);

                ExtractedPage page = new ExtractedPage(pageResult);
                pages.Add(page);
            }

            return pages.AsReadOnly();
        }

        private void SetLearnedFormId(int? clusterId)
        {
            // TODO: Provide IFormatProvider
#pragma warning disable CA1305 // Specify IFormatProvider
            string formId = clusterId?.ToString();
#pragma warning restore CA1305 // Specify IFormatProvider

            // TODO: Does this make sense?
            if (formId != null)
            {
                Debug.Assert(LearnedFormId == formId, "Multiple form types found in ExtractedForm.");
                LearnedFormId = formId;
            }
        }
    }
}
