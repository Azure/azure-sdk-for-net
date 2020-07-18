// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core;
using Azure.DigitalTwins.Core.Samples;
using static Azure.DigitalTwins.Core.Samples.SampleLogger;
using static Azure.DigitalTwins.Core.Samples.UniqueIdHelper;

namespace Azure.DigitalTwins.Samples
{
    internal class PublishTelemetrySamples
    {
        /// <summary>
        /// Create a temporary component model, twin model and digital twin instance.
        /// Publish a telemetry message and a component telemetry message to the digital twin instance.
        /// </summary>
        public async Task RunSamplesAsync(DigitalTwinsClient client)
        {
            PrintHeader("PUBLISH TELEMETRY MESSAGE SAMPLE");

            // For the purpose of this example we will create temporary models using a random model Ids.
            // We will also create temporary twin instances to publish the telemetry to.

            string componentModelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryComponentModelPrefix, client);
            string modelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryModelPrefix, client);
            string twinId = await GetUniqueTwinIdAsync(SamplesConstants.TemporaryTwinPrefix, client);

            string newComponentModelPayload = SamplesConstants.TemporaryComponentModelPayload
                .Replace(SamplesConstants.ComponentId, componentModelId);

            string newModelPayload = SamplesConstants.TemporaryModelWithComponentPayload
                .Replace(SamplesConstants.ModelId, modelId)
                .Replace(SamplesConstants.ComponentId, componentModelId);

            // Then we create the models.
            await client
                .CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload });

            Console.WriteLine($"Successfully created models '{componentModelId}' and '{modelId}'");

            // Create digital twin with Component payload.
            string twinPayload = SamplesConstants.TemporaryTwinPayload
                .Replace(SamplesConstants.ModelId, modelId);

            await client.CreateDigitalTwinAsync(twinId, twinPayload);
            Console.WriteLine($"Created digital twin '{twinId}'.");

            try
            {
                #region Snippet:DigitalTwinsSamplePublishTelemetry

                // construct your json telemetry payload by hand.
                await client.PublishTelemetryAsync(twinId, "{\"Telemetry1\": 5}");
                Console.WriteLine($"Published telemetry message to twin '{twinId}'.");

                #endregion Snippet:DigitalTwinsSamplePublishTelemetry

                #region Snippet:DigitalTwinsSamplePublishComponentTelemetry

                // construct your json telemetry payload by serializing a dictionary.
                var telemetryPayload = new Dictionary<string, int>
                {
                    { "ComponentTelemetry1", 9 }
                };
                await client.PublishComponentTelemetryAsync(
                    twinId,
                    "Component1",
                    JsonSerializer.Serialize(telemetryPayload));
                Console.WriteLine($"Published component telemetry message to twin '{twinId}'.");

                #endregion Snippet:DigitalTwinsSamplePublishComponentTelemetry
            }
            catch (Exception ex)
            {
                FatalError($"Failed to publish a telemetry message due to: {ex.Message}");
            }

            try
            {
                // Delete the twin.
                await client.DeleteDigitalTwinAsync(twinId);

                // Delete the models.
                await client.DeleteModelAsync(modelId);
                await client.DeleteModelAsync(componentModelId);
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
                // Digital twin or models do not exist.
            }
            catch (RequestFailedException ex)
            {
                FatalError($"Failed to delete due to: {ex.Message}");
            }
        }
    }
}
