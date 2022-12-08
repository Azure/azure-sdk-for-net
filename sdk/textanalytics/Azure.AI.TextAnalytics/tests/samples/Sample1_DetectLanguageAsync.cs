// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task DetectLanguageAsync()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

            #region Snippet:DetectLanguageAsync
            string document =
                "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
                + " invocar el método de Detección de Lenguaje del servicio de Text Analytics en Microsoft Azure."
                + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
                + " útil para los sistemas de contenido que recopilan texto arbitrario, donde el lenguaje no se conoce"
                + " de antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
                + " algunos idiomas regionales o culturales.";

            try
            {
                Response<DetectedLanguage> response = await client.DetectLanguageAsync(document);
                DetectedLanguage language = response.Value;
                Console.WriteLine($"Detected language {language.Name} with confidence score {language.ConfidenceScore}.");
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
