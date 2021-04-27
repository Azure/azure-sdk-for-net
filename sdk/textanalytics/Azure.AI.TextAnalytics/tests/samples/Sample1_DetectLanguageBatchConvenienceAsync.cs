// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
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
        public async Task DetectLanguageBatchConvenienceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string documentA = @"Este documento está escrito en un idioma diferente al Inglés. Tiene como objetivo demostrar
                                cómo invocar el método de Detección de idioma del servicio de Text Analytics en Microsoft Azure.
                                También muestra cómo acceder a la información retornada por el servicio. Esta capacidad es útil
                                para los sistemas de contenido que recopilan texto arbitrario, donde el idioma es desconocido.
                                La característica Detección de idioma puede detectar una amplia gama de idiomas, variantes,
                                dialectos y algunos idiomas regionales o culturales.";

            string documentB = @"This document is written in a language different than Spanish. It's objective is to demonstrate
                                how to call the Detect Language method from the Microsoft Azure Text Analytics service.
                                It also shows how to access the information returned from the service. This capability is useful
                                for content stores that collect arbitrary text, where language is unknown.
                                The Language Detection feature can detect a wide range of languages, variants, dialects, and some
                                regional or cultural languages.";

            string documentC = @"Ce document est rédigé dans une langue différente de l'espagnol. Son objectif est de montrer comment
                                appeler la méthode Detect Language à partir du service Microsoft Azure Text Analytics.
                                Il montre également comment accéder aux informations renvoyées par le service. Cette capacité est
                                utile pour les magasins de contenu qui collectent du texte arbitraire dont la langue est inconnue.
                                La fonctionnalité Détection de langue peut détecter une grande variété de langues, de variantes,
                                de dialectes, et certaines langues régionales ou de culture.";

            string documentD = string.Empty;

            var documents = new List<string>
            {
                documentA,
                documentB,
                documentC,
                documentD
            };

            Response<DetectLanguageResultCollection> response = await client.DetectLanguageBatchAsync(documents);
            DetectLanguageResultCollection documentsLanguage = response.Value;

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Detect Language\" Model, version: \"{documentsLanguage.ModelVersion}\"");
            Console.WriteLine("");

            foreach (DetectLanguageResult documentLanguage in documentsLanguage)
            {
                Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
                Console.WriteLine("");
                if (documentLanguage.HasError)
                {
                    Console.WriteLine("  Error!");
                    Console.WriteLine($"  Document error code: {documentLanguage.Error.ErrorCode}.");
                    Console.WriteLine($"  Message: {documentLanguage.Error.Message}");
                }
                else
                {
                    Console.WriteLine($"  Detected language: {documentLanguage.PrimaryLanguage.Name}");
                    Console.WriteLine($"  Confidence score: {documentLanguage.PrimaryLanguage.ConfidenceScore}");
                }
                Console.WriteLine("");
            }
        }
    }
}
