// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void DetectLanguageBatch()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSample1DetectLanguageBatch
            string documentA = @"Este documento está escrito en un idioma diferente al Inglés. Tiene como objetivo demostrar cómo invocar el método de Detección de idioma del servicio de Text Analytics en Microsoft Azure.
También muestra cómo acceder a la información retornada por el servicio. Esta capacidad es útil para los sistemas de contenido que recopilan texto arbitrario, donde el idioma es desconocido.
La característica Detección de idioma puede detectar una amplia gama de idiomas, variantes, dialectos y algunos idiomas regionales o culturales.";

            string documentB = @"This document is written in a language different than Spanish. It's objective is to demonstrate how to call the Detect Language method from the Microsoft Azure Text Analytics service.
It also shows how to access the information returned from the service. This capability is useful for content stores that collect arbitrary text, where language is unknown.
The Language Detection feature can detect a wide range of languages, variants, dialects, and some regional or cultural languages.";

            string documentC = @"Ce document est rédigé dans une langue différente de l'espagnol. Son objectif est de montrer comment appeler la méthode Detect Language à partir du service Microsoft Azure Text Analytics.
Il montre également comment accéder aux informations renvoyées par le service. Cette capacité est utile pour les magasins de contenu qui collectent du texte arbitraire dont la langue est inconnue.
La fonctionnalité Détection de langue peut détecter une grande variété de langues, de variantes, de dialectes, et certaines langues régionales ou de culture.";

            var documents = new List<DetectLanguageInput>
            {
                new DetectLanguageInput("1", documentA)
                {
                     CountryHint = "us",
                },
                new DetectLanguageInput("2", documentB)
                {
                     CountryHint = "fr",
                },
                new DetectLanguageInput("3", documentC)
                {
                     CountryHint = "es",
                },
                new DetectLanguageInput("4", ":) :( :D")
                {
                     CountryHint = DetectLanguageInput.None,
                }
            };

            DetectLanguageResultCollection results = client.DetectLanguageBatch(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });
            #endregion

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Detect Language\" Model, version: \"{results.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (DetectLanguageResult result in results)
            {
                DetectLanguageInput document = documents[i++];

                Debug.WriteLine($"On document (Id={document.Id}, CountryHint=\"{document.CountryHint}\", Text=\"{document.Text}\"):");

                if (result.HasError)
                {
                    Debug.WriteLine($"    Document error code: {result.Error.ErrorCode}.");
                    Debug.WriteLine($"    Message: {result.Error.Message}.");
                }
                else
                {
                    Debug.WriteLine($"    Detected language {result.PrimaryLanguage.Name} with confidence score {result.PrimaryLanguage.ConfidenceScore}.");

                    Debug.WriteLine($"    Document statistics:");
                    Debug.WriteLine($"        Character count (in Unicode graphemes): {result.Statistics.CharacterCount}");
                    Debug.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                    Debug.WriteLine("");
                }
            }

            Debug.WriteLine($"Batch operation statistics:");
            Debug.WriteLine($"    Document count: {results.Statistics.DocumentCount}");
            Debug.WriteLine($"    Valid document count: {results.Statistics.ValidDocumentCount}");
            Debug.WriteLine($"    Invalid document count: {results.Statistics.InvalidDocumentCount}");
            Debug.WriteLine($"    Transaction count: {results.Statistics.TransactionCount}");
            Debug.WriteLine("");
        }
    }
}
