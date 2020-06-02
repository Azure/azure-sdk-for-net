// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core;
using Azure.DigitalTwins.Core.Samples;
using static Azure.DigitalTwins.Core.Samples.SampleLogger;
using static Azure.DigitalTwins.Core.Samples.UniqueIdHelper;

namespace Azure.DigitalTwins.Samples
{
    internal class PublishTelemetrySamples
    {
        private DigitalTwinsClient DigitalTwinsClient { get; }

        public PublishTelemetrySamples(DigitalTwinsClient dtClient)
        {
            DigitalTwinsClient = dtClient;
        }

        /// <summary>
        /// Create a temporary component model, twin model and digital twin instance.
        /// Publish a telemetry message and a component telemetry message to the digital twin instance.
        /// </summary>
        public async Task RunSamplesAsync()
        {
            PrintHeader("PUBLISH TELEMETRY MESSAGE SAMPLE");

            // For the purpose of this example we will create temporary models using a random model Ids.
            // We will also create temporary twin instances to publish the telemetry to.

            string componentModelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryComponentModelPrefix, DigitalTwinsClient).ConfigureAwait(false);
            string modelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryModelPrefix, DigitalTwinsClient).ConfigureAwait(false);
            string twinId = await GetUniqueTwinIdAsync(SamplesConstants.TemporaryTwinPrefix, DigitalTwinsClient).ConfigureAwait(false);

            string newComponentModelPayload = SamplesConstants.TemporaryComponentModelPayload
                .Replace(SamplesConstants.ComponentId, componentModelId);

            string newModelPayload = SamplesConstants.TemporaryModelPayload
                .Replace(SamplesConstants.ModelId, modelId)
                .Replace(SamplesConstants.ComponentId, componentModelId);

            // Then we create the models.
            await DigitalTwinsClient.CreateModelsAsync(new[] {
                newComponentModelPayload,
                newModelPayload
            }).ConfigureAwait(false);

            Console.WriteLine($"Successfully created models with Ids: {componentModelId}, {modelId}");

            // Create digital twin with Component payload
            string twinPayload = SamplesConstants.TemporaryTwinPayload
                .Replace(SamplesConstants.ModelId, modelId)
                .Replace(SamplesConstants.ComponentId, componentModelId);

            await DigitalTwinsClient.CreateDigitalTwinAsync(twinId, twinPayload).ConfigureAwait(false);
            Console.WriteLine($"Created digital twin {twinId}.");

            try
            {
                #region Snippet:DigitalTwinSamplePublishTelemetry

                Response publishTelemetryResponse = await DigitalTwinsClient.PublishTelemetryAsync(twinId, "\"telemetry\": {\"Telemetry1\": 5}");

                #endregion Snippet:DigitalTwinSamplePublishTelemetry

                Console.WriteLine($"Successfully published telemetry message, status: {publishTelemetryResponse.Status}");

                #region Snippet:DigitalTwinSamplePublishComponentTelemetry

                Response publishTelemetryToComponentResponse = await DigitalTwinsClient.PublishComponentTelemetryAsync(twinId, "Component1", "\"telemetry\": {\"ComponentTelementry1\": 9}");

                #endregion Snippet:DigitalTwinSamplePublishComponentTelemetry

                Console.WriteLine($"Successfully published component telemetry message, status: {publishTelemetryToComponentResponse.Status}");
            }
            finally
            {
                // Delete the twin.
                await DigitalTwinsClient.DeleteDigitalTwinAsync(twinId).ConfigureAwait(false);

                // Delete the models.
                try
                {
                    await DigitalTwinsClient.DeleteModelAsync(modelId).ConfigureAwait(false);
                    await DigitalTwinsClient.DeleteModelAsync(componentModelId).ConfigureAwait(false);
                }
                catch (RequestFailedException ex)
                {
                    Console.WriteLine($"Failed to delete models due to {ex}");
                }
            }
        }
    }
}
