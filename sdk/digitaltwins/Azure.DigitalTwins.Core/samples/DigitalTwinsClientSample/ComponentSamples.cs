// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
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
            string dtId = await GetUniqueTwinIdAsync(SamplesConstants.TemporaryTwinPrefix, DigitalTwinsClient).ConfigureAwait(false);

            string newComponentModelPayload = SamplesConstants.TemporaryComponentModelPayload
                .Replace(SamplesConstants.ComponentId, componentModelId);

            string newModelPayload = SamplesConstants.TemporaryModelWithComponentPayload
                .Replace(SamplesConstants.ModelId, modelId)
                .Replace(SamplesConstants.ComponentId, componentModelId);

            // Then we create models
            Response<IReadOnlyList<Models.ModelData>> createModelsResponse = await DigitalTwinsClient
                .CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload })
                .ConfigureAwait(false);
            Console.WriteLine($"Successfully created models Ids {componentModelId} and {modelId} with response {createModelsResponse.GetRawResponse().Status}.");

            #region Snippet:DigitalTwinsSampleCreateBasicTwin

            // Create digital twin with Component payload using the BasicDigitalTwin serialization helper

            var basicDigitalTwin = new BasicDigitalTwin();
            basicDigitalTwin.Metadata.ModelId = modelId;
            basicDigitalTwin.CustomProperties.Add("Prop1", "Value1");
            basicDigitalTwin.CustomProperties.Add("Prop2", "Value2");

            var componentMetadata = new ModelProperties();
            componentMetadata.Metadata.ModelId = componentModelId;
            componentMetadata.CustomProperties.Add("ComponentProp1", "ComponentValue1");
            componentMetadata.CustomProperties.Add("ComponentProp2", "ComponentValue2");

            basicDigitalTwin.CustomProperties.Add("Component1", componentMetadata);

            string dtPayload = JsonSerializer.Serialize(basicDigitalTwin, new JsonSerializerOptions { IgnoreNullValues = true });

            Response<string> createDtResponse = await DigitalTwinsClient.CreateDigitalTwinAsync(dtId, dtPayload).ConfigureAwait(false);
            Console.WriteLine($"Created digital twin {dtId} with response {createDtResponse.GetRawResponse().Status}.");

            #endregion Snippet:DigitalTwinsSampleCreateBasicTwin

            #region Snippet:DigitalTwinsSampleUpdateComponent

            // Update Component1 by replacing the property ComponentProp1 value
            var componentUpdateUtility = new UpdateOperationsUtility();
            componentUpdateUtility.AppendReplaceOp("/ComponentProp1", "Some new value");
            string updatePayload = componentUpdateUtility.Serialize();

            Response<string> response = await DigitalTwinsClient.UpdateComponentAsync(dtId, "Component1", updatePayload);

            Console.WriteLine($"Updated component for digital twin {dtId}. Update response status: {response.GetRawResponse().Status}");

            #endregion Snippet:DigitalTwinsSampleUpdateComponent

            // Get Component

            #region Snippet:DigitalTwinsSampleGetComponent

            response = await DigitalTwinsClient.GetComponentAsync(dtId, SamplesConstants.ComponentPath).ConfigureAwait(false);

            Console.WriteLine($"Get component for digital twin: \n{response.Value}. Get response status: {response.GetRawResponse().Status}");

            #endregion Snippet:DigitalTwinsSampleGetComponent

            // Now delete a Twin
            await DigitalTwinsClient.DeleteDigitalTwinAsync(dtId).ConfigureAwait(false);

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
