// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.Translation.Document.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class SampleSnippets : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        [Ignore("Samples not working yet")]
        public void CreateDocumentTranslationClient()
        {
            #region Snippet:CreateDocumentTranslationClient
#if SNIPPET
            string endpoint = "<endpoint>";
            string apiKey = "<apiKey>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif
            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion
        }

        [Test]
        [Ignore("Samples not working yet")]
        public void BadRequestSnippet()
        {
#if SNIPPET
            string endpoint = "<endpoint>";
#else
            string endpoint = TestEnvironment.Endpoint;
#endif
            string apiKey = TestEnvironment.ApiKey;

            var credentials = new AzureKeyCredential(apiKey);
            var client = new DocumentTranslationClient(new Uri(endpoint), credentials);

            #region Snippet:BadRequest
            var invalidInput = new DocumentTranslationInput(new TranslationSource(new Uri(endpoint)), new List<TranslationTarget>());

            try
            {
                DocumentTranslationOperation operation = client.StartTranslation(invalidInput);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        [Test]
        [Ignore("Samples not working yet")]
        public void DocumentTranslationInput()
        {
            #region Snippet:DocumentTranslationSingleInput
            Uri sourceSasUri = new Uri("<source SAS URI>");
            Uri frenchTargetSasUri = new Uri("<french target SAS URI>");

            var input = new DocumentTranslationInput(sourceSasUri, frenchTargetSasUri, "fr");
            #endregion

            #region Snippet:DocumentTranslationMultipleInputs
            Uri arabicTargetSasUri = new Uri("<arabic target SAS URI>");
            Uri spanishTargetSasUri = new Uri("<spanish target SAS URI>");
            Uri source1SasUri = new Uri("<source1 SAS URI>");
            Uri source2SasUri = new Uri("<source2 SAS URI>");

            var inputs = new List<DocumentTranslationInput>
            {
                new DocumentTranslationInput(source1SasUri, spanishTargetSasUri, "es"),
                new DocumentTranslationInput(
                    source: new TranslationSource(source2SasUri),
                    targets: new List<TranslationTarget>
                    {
                        new TranslationTarget(frenchTargetSasUri, "fr"),
                        new TranslationTarget(arabicTargetSasUri, "ar")
                    }),
            };
            #endregion
        }
    }
}
