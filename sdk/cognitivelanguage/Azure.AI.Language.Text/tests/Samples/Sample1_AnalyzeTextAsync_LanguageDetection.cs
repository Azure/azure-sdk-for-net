// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample1_AnalyzeTextAsync_LanguageDetection: SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task LanguageDetection()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample1_AnalyzeTextAsync_LanguageDetection
            string textA =
                "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
                + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
                + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
                + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
                + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
                + " algunos idiomas regionales o culturales.";

            string textB =
                "This document is written in English. Its objective is to demonstrate how to call the language"
                + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
                + " information returned by the service. This functionality is useful for applications that collect"
                + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
                + " of languages, variants, dialects, and some regional or cultural languages.";

            string textC =
                "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
                + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
                + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
                + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
                + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
                + " dialectes et certaines langues régionales ou culturelles.";

            try
            {
                AnalyzeTextInput body = new TextLanguageDetectionInput()
                {
                    TextInput = new LanguageDetectionTextInput()
                    {
                        LanguageInputs =
                        {
                            new LanguageInput("A", textA),
                            new LanguageInput("B", textB),
                            new LanguageInput("C", textC),
                        }
                    }
                };

                Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
                AnalyzeTextLanguageDetectionResult AnalyzeTextLanguageDetectionResult = (AnalyzeTextLanguageDetectionResult)response.Value;

                foreach (LanguageDetectionDocumentResult document in AnalyzeTextLanguageDetectionResult.Results.Documents)
                {
                    Console.WriteLine($"Result for document with Id = \"{document.Id}\":");
                    Console.WriteLine($"    Name: {document.DetectedLanguage.Name}");
                    Console.WriteLine($"    Iso6391Name: {document.DetectedLanguage.Iso6391Name}");
                    if (document.DetectedLanguage.ScriptName != null)
                    {
                        Console.WriteLine($"    ScriptName: {document.DetectedLanguage.ScriptName}");
                        Console.WriteLine($"    ScriptIso15924Code: {document.DetectedLanguage.ScriptIso15924Code}");
                    }
                    Console.WriteLine($"    ConfidenceScore: {document.DetectedLanguage.ConfidenceScore}");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error DocumentWarningCode: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task LanguageDetection_CountryHint()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample1_AnalyzeTextAsync_LanguageDetection_CountryHint
            string textA =
                "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
                + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
                + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
                + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
                + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
                + " algunos idiomas regionales o culturales.";

            string textB =
                "This document is written in English. Its objective is to demonstrate how to call the language"
                + " detection method of the Text Analytics service in Microsoft Azure. It also shows how to access the"
                + " information returned by the service. This functionality is useful for applications that collect"
                + " arbitrary text where the language is not known beforehand. It can be used to detect a wide range"
                + " of languages, variants, dialects, and some regional or cultural languages.";

            string textC =
                "Ce document est rédigé dans une langue autre que l'anglais. Son objectif est de montrer comment"
                + " appeler la méthode de détection de langue du service Text Analytics dans Microsoft Azure. Il"
                + " montre également comment accéder aux informations renvoyées par le service. Cette fonctionnalité"
                + " est utile pour les applications qui collectent du texte arbitraire dont la langue n'est pas connue"
                + " à l'avance. Il peut être utilisé pour détecter un large éventail de langues, de variantes, de"
                + " dialectes et certaines langues régionales ou culturelles.";

            try
            {
                AnalyzeTextInput body = new TextLanguageDetectionInput()
                {
                    TextInput = new LanguageDetectionTextInput()
                    {
                        LanguageInputs   =
                        {
                            new LanguageInput("A", textA) { CountryHint = "es" },
                            new LanguageInput("B", textB) { CountryHint = "us" },
                            new LanguageInput("C", textC) { CountryHint = "fr" },
                        }
                    }
                };

                Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
                AnalyzeTextLanguageDetectionResult AnalyzeTextLanguageDetectionResult = (AnalyzeTextLanguageDetectionResult)response.Value;

                foreach (LanguageDetectionDocumentResult document in AnalyzeTextLanguageDetectionResult.Results.Documents)
                {
                    Console.WriteLine($"Result for document with Id = \"{document.Id}\":");
                    Console.WriteLine($"    Name: {document.DetectedLanguage.Name}");
                    Console.WriteLine($"    Iso6391Name: {document.DetectedLanguage.Iso6391Name}");
                    if (document.DetectedLanguage.ScriptName != null)
                    {
                        Console.WriteLine($"    ScriptName: {document.DetectedLanguage.ScriptName}");
                        Console.WriteLine($"    ScriptIso15924Code: {document.DetectedLanguage.ScriptIso15924Code}");
                    }
                    Console.WriteLine($"    ConfidenceScore: {document.DetectedLanguage.ConfidenceScore}");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error DocumentWarningCode: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }
    }
}
