// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public void CreateContentUnderstandingClient()
        {
            #region Snippet:CreateContentUnderstandingClient
#if SNIPPET
            // Example: https://your-foundry.services.ai.azure.com/
            string endpoint = "<endpoint>";
            var credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            var credential = TestEnvironment.Credential;
#endif
            var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
            #endregion
        }

        // Method kept for snippet extraction, but not run as a test
        public void CreateContentUnderstandingClientApiKey()
        {
            #region Snippet:CreateContentUnderstandingClientApiKey
#if SNIPPET
            // Example: https://your-foundry.services.ai.azure.com/
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion
        }
    }
}
