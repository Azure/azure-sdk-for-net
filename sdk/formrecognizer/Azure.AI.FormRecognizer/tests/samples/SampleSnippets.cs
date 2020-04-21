// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    [LiveOnly]
    public partial class Snippets : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public void CreateFormRecognizerClient()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:CreateFormRecognizerClient
            //@@ string endpoint = "<endpoint>";
            //@@ string apiKey = "<apiKey>";
            var credential = new AzureKeyCredential(apiKey);
            var client = new FormRecognizerClient(new Uri(endpoint), credential);
            #endregion
        }

        [Test]
        public async Task BadRequestSnippet()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var credential = new AzureKeyCredential(apiKey);
            var client = new FormRecognizerClient(new Uri(endpoint), credential);

            #region Snippet:FormRecognizerBadRequest
            try
            {
                Response<IReadOnlyList<RecognizedReceipt>> receipts = await client.StartRecognizeReceiptsFromUri(new Uri("http://invalid.uri")).WaitForCompletionAsync();
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }
    }
}
