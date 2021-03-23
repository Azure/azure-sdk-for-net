// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public void BadRequestSnippet()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var credentials = new AzureKeyCredential(apiKey);
            var client = new DocumentTranslationClient(new Uri(endpoint), credentials);

            var invalidConfiguration = new TranslationConfiguration(new TranslationSource(new Uri(endpoint)), new List<TranslationTarget>());

            #region Snippet:BadRequest
            try
            {
                DocumentTranslationOperation operation = client.StartTranslation(invalidConfiguration);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        [Test]
        public void DocumentTranslationInput()
        {
            Uri sourceSasUri = new Uri("");
            Uri frenchTargetSasUri = new Uri("");
            Uri arabicTargetSasUri = new Uri("");
            Uri spanishGlossarySasUri = new Uri("");
            Uri spanishTargetSasUri = new Uri("");

            #region Snippet:DocumentTranslationSingleInput
            var input = new TranslationConfiguration(sourceSasUri, frenchTargetSasUri, "fr");
            input.AddTarget(arabicTargetSasUri, "ar");
            input.AddTarget(spanishTargetSasUri, "es", new TranslationGlossary(spanishGlossarySasUri));
            #endregion

            Uri source1SasUri = new Uri("");
            Uri source2SasUri = new Uri("");

            #region Snippet:DocumentTranslationMultipleInputs
            var inputs = new List<TranslationConfiguration>
            {
                new TranslationConfiguration(source1SasUri, spanishTargetSasUri, "es"),
                new TranslationConfiguration(
                    source: new TranslationSource(source2SasUri),
                    targets: new List<TranslationTarget>
                    {
                        new TranslationTarget(frenchTargetSasUri, "fr"),
                        new TranslationTarget(spanishTargetSasUri, "es")
                    }),
                new TranslationConfiguration(source1SasUri, spanishTargetSasUri, "es", new TranslationGlossary(spanishGlossarySasUri)),
            };
            #endregion
        }
    }
}
