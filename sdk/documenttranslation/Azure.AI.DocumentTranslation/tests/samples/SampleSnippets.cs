// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.DocumentTranslation.Tests;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class SampleSnippets : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        public void CreateDocumentTranslationClient()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:CreateDocumentTranslationClient
            //@@ string endpoint = "<endpoint>";
            //@@ string apiKey = "<apiKey>";
            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion
        }

        [Test]
        public void CreateDocumentTranslationClientTokenCredential()
        {
            string endpoint = TestEnvironment.Endpoint;

            #region Snippet:CreateDocumentTranslationClientTokenCredential
            //@@ string endpoint = "<endpoint>";
            var client = new DocumentTranslationClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion
        }
    }
}
