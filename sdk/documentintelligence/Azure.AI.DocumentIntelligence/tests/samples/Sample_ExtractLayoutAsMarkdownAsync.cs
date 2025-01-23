// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.DocumentIntelligence.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public async Task ExtractLayoutAsMarkdownAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), TestEnvironment.Credential);

            #region Snippet:DocumentIntelligenceExtractLayoutAsMarkdownAsync
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif

            var options = new AnalyzeDocumentOptions("prebuilt-layout", uriSource)
            {
                OutputContentFormat = DocumentContentFormat.Markdown
            };

            Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
            AnalyzeResult result = operation.Value;

            Console.WriteLine(result.Content);
            #endregion
        }
    }
}
