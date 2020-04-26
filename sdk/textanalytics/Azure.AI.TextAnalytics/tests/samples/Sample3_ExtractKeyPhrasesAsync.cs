﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task ExtractKeyPhrasesAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string document = "My cat might need to see a veterinarian.";

            Response<IReadOnlyCollection<string>> keyPhrases = await client.ExtractKeyPhrasesAsync(document);

            Console.WriteLine($"Extracted {keyPhrases.Value.Count} key phrases:");
            foreach (string keyPhrase in keyPhrases.Value)
            {
                Console.WriteLine(keyPhrase);
            }
        }
    }
}
