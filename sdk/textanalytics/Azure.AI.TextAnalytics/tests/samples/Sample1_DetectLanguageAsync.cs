// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task DetectLanguageAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DetectLanguageAsync
            string document = @"Este documento está escrito en un idioma diferente al Inglés. Tiene como objetivo demostrar
                                cómo invocar el método de Detección de idioma del servicio de Text Analytics en Microsoft Azure.
                                También muestra cómo acceder a la información retornada por el servicio. Esta capacidad es útil
                                para los sistemas de contenido que recopilan texto arbitrario, donde el idioma es desconocido.
                                La característica Detección de idioma puede detectar una amplia gama de idiomas, variantes,
                                dialectos y algunos idiomas regionales o culturales.";

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
