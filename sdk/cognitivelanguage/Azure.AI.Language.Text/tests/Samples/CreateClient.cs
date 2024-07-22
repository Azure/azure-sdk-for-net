// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Models;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class CreateClient : SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        public void CreateTextAnalysisClientForSpecificApiVersion()
        {
            #region Snippet:CreateTextAnalysisClientForSpecificApiVersion
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
            var client = new TextAnalysisClient(endpoint, credential, options);
            #endregion
        }

        [Test]
        public void CreateTextClient()
        {
            #region Snippet:CreateTextClient
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);
            #endregion
        }
    }
}
