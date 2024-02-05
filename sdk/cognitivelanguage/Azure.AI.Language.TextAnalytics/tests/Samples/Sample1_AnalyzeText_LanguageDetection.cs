// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.Text;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample1_AnalyzeText_LanguageDetection: SamplesBase<TextAnalyticsClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public async void LanguageDetection()
        {
            #region Snippet:Sample1_AnalyzeTextAsync_LanguageDetection
            Uri endpoint = new("<endpoint>");
            AzureKeyCredential credential = new("<apiKey>");
            Text.Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");

            string documentA =
                "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
                + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
                + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
                + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
                + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
                + " algunos idiomas regionales o culturales.";

            string documentB =
                "This document is written in English. Its objective is to demonstrate how to call the language"
                + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
                + " information returned by the service. This functionality is useful for applications that collect"
                + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
                + " of languages, variants, dialects, and some regional or cultural languages.";

            string documentC =
                "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
                + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
                + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
                + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
                + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
                + " dialectes et certaines langues régionales ou culturelles.";

            try
            {
                AnalyzeTextTask body = new AnalyzeTextLanguageDetectionInput()
                {
                    AnalysisInput = new LanguageDetectionAnalysisInput()
                    {
                        Documents =
                        {
                            new LanguageInput("A", documentA),
                            new LanguageInput("B", documentB),
                            new LanguageInput("C", documentC),
                        }
                    }
                };

                Response<AnalyzeTextTaskResult> response = await client.AnalyzeTextAsync(body);
                LanguageDetectionTaskResult languageDetectionTaskResult = (LanguageDetectionTaskResult)response.Value;

                foreach (LanguageDetectionDocumentResult document in languageDetectionTaskResult.Results.Documents)
                {
                    Console.WriteLine($"For Document ID: {document.Id} detected language is {document.DetectedLanguage.Name} with a confidence score of {document.DetectedLanguage.ConfidenceScore}.");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        [SyncOnly]
        public async void LanguageDetection_CountryHint()
        {
            #region Snippet:Sample1_AnalyzeTextAsync_LanguageDetection_CountryHint
            Uri endpoint = new("<endpoint>");
            AzureKeyCredential credential = new("<apiKey>");
            Text.Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");

            string documentA =
                "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
                + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
                + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
                + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
                + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
                + " algunos idiomas regionales o culturales.";

            string documentB =
                "This document is written in English. Its objective is to demonstrate how to call the language"
                + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
                + " information returned by the service. This functionality is useful for applications that collect"
                + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
                + " of languages, variants, dialects, and some regional or cultural languages.";

            string documentC =
                "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
                + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
                + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
                + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
                + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
                + " dialectes et certaines langues régionales ou culturelles.";

            try
            {
                AnalyzeTextTask body = new AnalyzeTextLanguageDetectionInput()
                {
                    AnalysisInput = new LanguageDetectionAnalysisInput()
                    {
                        Documents =
                        {
                            new LanguageInput("A", documentA, "es"),
                            new LanguageInput("B", documentB, "us"),
                            new LanguageInput("C", documentC, "fr"),
                        }
                    }
                };

                Response<AnalyzeTextTaskResult> response = await client.AnalyzeTextAsync(body);
                LanguageDetectionTaskResult languageDetectionTaskResult = (LanguageDetectionTaskResult)response.Value;

                foreach (LanguageDetectionDocumentResult document in languageDetectionTaskResult.Results.Documents)
                {
                    Console.WriteLine($"For Document ID: {document.Id} detected language is {document.DetectedLanguage.Name} with a confidence score of {document.DetectedLanguage.ConfidenceScore}.");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }
    }
}
