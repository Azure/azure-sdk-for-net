// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core.Serialization;
using static Azure.DigitalTwins.Core.Samples.SampleLogger;
using static Azure.DigitalTwins.Core.Samples.UniqueIdHelper;

namespace Azure.DigitalTwins.Core.Samples
{
    internal class ComponentSamples
    {
        private DigitalTwinsClient DigitalTwinsClient { get; }

        public ComponentSamples(DigitalTwinsClient dtClient)
        {
            DigitalTwinsClient = dtClient;
        }

        /// <summary>
        /// Creates a digital twin with Component and upates Component
        /// </summary>
        public async Task RunSamplesAsync()
        {
            PrintHeader("COMPONENT SAMPLE");

            // For the purpose of this example we will create temporary models using a random model Ids.
            // We have to make sure these model Ids are unique within the DT instance.

            string componentModelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryComponentModelPrefix, DigitalTwinsClient).ConfigureAwait(false);
            string modelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryModelPrefix, DigitalTwinsClient).ConfigureAwait(false);
            string twinId = await GetUniqueTwinIdAsync(SamplesConstants.TemporaryTwinPrefix, DigitalTwinsClient).ConfigureAwait(false);

            string newComponentModelPayload = SamplesConstants.TemporaryComponentModelPayload
                .Replace(SamplesConstants.ComponentId, componentModelId);

            string newModelPayload = SamplesConstants.TemporaryModelPayload
                .Replace(SamplesConstants.ModelId, modelId)
                .Replace(SamplesConstants.ComponentId, componentModelId);

            // Then we create models
            await DigitalTwinsClient.CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload }).ConfigureAwait(false);
            Console.WriteLine($"Successfully created models with Ids: {componentModelId}, {modelId}");

            // Create digital twin with Component payload
            string twinPayload = SamplesConstants.TemporaryTwinPayload
                .Replace(SamplesConstants.ModelId, modelId)
                .Replace(SamplesConstants.ComponentId, componentModelId);

            await DigitalTwinsClient.CreateDigitalTwinAsync(twinId, twinPayload).ConfigureAwait(false);
            Console.WriteLine($"Created digital twin {twinId}.");

            #region Snippet:DigitalTwinsSampleUpdateComponent

            // Update Component with replacing property value
            string propertyPath = "/ComponentProp1";
            string propValue = "New Value";

            var componentUpdateUtility = new UpdateOperationsUtility();
            componentUpdateUtility.AppendReplaceOp(propertyPath, propValue);

            Response<string> response = await DigitalTwinsClient.UpdateComponentAsync(twinId, SamplesConstants.ComponentPath, componentUpdateUtility.Serialize());

            #endregion Snippet:DigitalTwinsSampleUpdateComponent

            Console.WriteLine($"Updated component for digital twin {twinId}. Update response status: {response.GetRawResponse().Status}");

            // Get Component

            #region Snippet:DigitalTwinsSampleGetComponent

            response = await DigitalTwinsClient.GetComponentAsync(twinId, SamplesConstants.ComponentPath).ConfigureAwait(false);

            #endregion Snippet:DigitalTwinsSampleGetComponent

            Console.WriteLine($"Get component for digital twin: \n{response.Value}. Get response status: {response.GetRawResponse().Status}");

            // Now delete a Twin
            await DigitalTwinsClient.DeleteDigitalTwinAsync(twinId).ConfigureAwait(false);

            // Delete models
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
