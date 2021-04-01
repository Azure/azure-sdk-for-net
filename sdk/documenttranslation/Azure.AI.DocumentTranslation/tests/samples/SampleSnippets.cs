// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.Translator.DocumentTranslation.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translator.DocumentTranslation.Samples
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
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:CreateDocumentTranslationClient
            //@@ string endpoint = "<endpoint>";
            //@@ string apiKey = "<apiKey>";
            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion
        }

        [Test]
        [Ignore("Samples not working yet")]
        public void BadRequestSnippet()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var credentials = new AzureKeyCredential(apiKey);
            var client = new DocumentTranslationClient(new Uri(endpoint), credentials);

            var invalidInput = new DocumentTranslationInput(new TranslationSource(new Uri(endpoint)), new List<TranslationTarget>());

            #region Snippet:BadRequest

            //@@ var invalidInput = new DocumentTranslationInput(new TranslationSource(sourceSasUri, new List<TranslationTarget>());

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
            Uri sourceSasUri = new Uri("<source SAS URI>");
            Uri frenchTargetSasUri = new Uri("<french target SAS URI>");
            Uri arabicTargetSasUri = new Uri("<arabic target SAS URI>");
            Uri spanishTargetSasUri = new Uri("<spanish target SAS URI>");

            #region Snippet:DocumentTranslationSingleInput
            //@@ Uri sourceSasUri = <source SAS URI>;
            //@@ Uri frenchTargetSasUri = <french target SAS URI>;
            //@@ Uri arabicTargetSasUri = <arabic target SAS URI>;
            //@@ Uri spanishTargetSasUri = <spanish target SAS URI>;

            var input = new DocumentTranslationInput(sourceSasUri, frenchTargetSasUri, "fr");
            input.AddTarget(arabicTargetSasUri, "ar");
            input.AddTarget(spanishTargetSasUri, "es");
            #endregion

            Uri source1SasUri = new Uri("<source1 SAS URI>");
            Uri source2SasUri = new Uri("<source2 SAS URI>");

            #region Snippet:DocumentTranslationMultipleInputs
            //@@ Uri source1SasUri = <source1 SAS URI>;
            //@@ Uri source2SasUri = <source2 SAS URI>;

            var inputs = new List<DocumentTranslationInput>
            {
                new DocumentTranslationInput(source1SasUri, spanishTargetSasUri, "es"),
                new DocumentTranslationInput(
                    source: new TranslationSource(source2SasUri),
                    targets: new List<TranslationTarget>
                    {
                        new TranslationTarget(frenchTargetSasUri, "fr"),
                        new TranslationTarget(spanishTargetSasUri, "es")
                    }),
            };
            #endregion
        }
    }
}
