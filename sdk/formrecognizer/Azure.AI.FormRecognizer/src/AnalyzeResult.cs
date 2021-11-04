// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// Represents one or more documents that have been analyzed by a trained or prebuilt model.
    /// </summary>
    [CodeGenModel("AnalyzeResult")]
    public partial class AnalyzeResult
    {
        internal AnalyzeResult(ApiVersion apiVersion, string modelId, StringIndexType stringIndexType, string content, IReadOnlyList<DocumentPage> pages, IReadOnlyList<DocumentTable> tables, IReadOnlyList<DocumentKeyValuePair> keyValuePairs, IReadOnlyList<DocumentEntity> entities, IReadOnlyList<DocumentStyle> styles, IReadOnlyList<AnalyzedDocument> documents)
        {
            ApiVersion = apiVersion;
            ModelId = modelId;
            StringIndexType = stringIndexType;
            Content = content;
            Pages = pages;
            Tables = tables;
            KeyValuePairs = keyValuePairs;
            Entities = entities;
            Styles = styles;
            Documents = documents;

            // Set page references for the 'Words' convenience properties.

            foreach (DocumentPage page in Pages)
            {
                foreach (DocumentLine line in page.Lines)
                {
                    line.Page = page;
                }
            }

            foreach (DocumentTable table in Tables)
            {
                table.Pages = Pages;

                foreach (DocumentTableCell cell in table.Cells)
                {
                    cell.Pages = Pages;
                }
            }

            foreach (DocumentKeyValuePair kvp in KeyValuePairs)
            {
                kvp.Key.Pages = Pages;
                kvp.Value.Pages = Pages;
            }

            foreach (DocumentEntity entity in Entities)
            {
                entity.Pages = Pages;
            }

            foreach (AnalyzedDocument document in Documents)
            {
                document.Pages = Pages;

                foreach (DocumentField field in document.Fields.Values)
                {
                    field.Pages = Pages;
                }
            }
        }

        private ApiVersion ApiVersion { get; }

        private StringIndexType StringIndexType { get; }
    }
}
