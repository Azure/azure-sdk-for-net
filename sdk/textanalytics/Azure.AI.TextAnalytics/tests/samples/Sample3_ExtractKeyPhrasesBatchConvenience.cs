// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void ExtractKeyPhrasesBatchConvenience()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Text Analytics is one of the Azure Cognitive Services.",
                "My cat might need to see a veterinarian.",
            };

            #region Snippet:TextAnalyticsSample3ExtractKeyPhrasesConvenience
            ExtractKeyPhrasesResultCollection results = client.ExtractKeyPhrasesBatch(documents);
            #endregion

            Debug.WriteLine($"Extracted key phrases for each document are:");
            int i = 0;
            foreach (ExtractKeyPhrasesResult result in results)
            {
                Debug.WriteLine($"For document: \"{documents[i++]}\",");
                Debug.WriteLine($"the following {result.KeyPhrases.Count()} key phrases were found: ");

                foreach (string keyPhrase in result.KeyPhrases)
                {
                    Debug.WriteLine($"    {keyPhrase}");
                }
            }

            // Illustrate Warnings
            var longDocuments = new List<string>
            {
                "Thisisaveryveryverylongtextwhichgoesonforalongtimeandwhichalmostdoesn'tseemtostopatanygivenpointintime.ThereasonforthistestistotryandseewhathappenswhenwesubmitaveryveryverylongtexttoLanguage.Thisshouldworkjustfinebutjustincaseitisalwaysgoodtohaveatestcase.ThisallowsustotestwhathappensifitisnotOK.Ofcourseitisgoingtobeokbutthenagainitisalsobettertobesure!"
            };

            ExtractKeyPhrasesResultCollection longDocumentResults = client.ExtractKeyPhrasesBatch(longDocuments);

            Debug.WriteLine($"Extracted key phrases for each document are:");
            i = 0;
            foreach (ExtractKeyPhrasesResult result in longDocumentResults)
            {
                Debug.WriteLine($"For document: \"{longDocumentResults[i++]}\",");

                if (result.HasWarnings)
                {
                    foreach (TextAnalyticsWarning warning in result.Warnings)
                    {
                        Debug.WriteLine($"    Warning: Code: {warning.Code}, Message: {warning.Message}");
                    }
                }

                Debug.WriteLine($"the following {result.KeyPhrases.Count()} key phrases were found: ");

                foreach (string keyPhrase in result.KeyPhrases)
                {
                    Debug.WriteLine($"    {keyPhrase}");
                }
            }
        }
    }
}
