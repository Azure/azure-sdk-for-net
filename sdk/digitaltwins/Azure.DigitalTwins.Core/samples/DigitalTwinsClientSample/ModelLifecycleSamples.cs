// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core;
using Azure.DigitalTwins.Core.Samples;
using static Azure.DigitalTwins.Core.Samples.SampleLogger;
using static Azure.DigitalTwins.Core.Samples.UniqueIdHelper;

namespace Azure.DigitalTwins.Samples
{
    internal class ModelLifecycleSamples
    {
        /// <summary>
        /// Creates a new model with a random Id
        /// Decommission the newly created model and check for success
        /// </summary>
        public async Task RunSamplesAsync(DigitalTwinsClient client)
        {
            PrintHeader("MODEL LIFECYCLE SAMPLE");

            // For the purpose of this example we will create temporary models using random model Ids and then decommission a model.
            // We have to make sure these model Ids are unique within the DT instance.

            string componentModelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryComponentModelPrefix, client);
            string sampleModelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryModelPrefix, client);

            string newComponentModelPayload = SamplesConstants.TemporaryComponentModelPayload
                .Replace(SamplesConstants.ComponentId, componentModelId);

            string newModelPayload = SamplesConstants.TemporaryModelWithComponentPayload
                .Replace(SamplesConstants.ModelId, sampleModelId)
                .Replace(SamplesConstants.ComponentId, componentModelId);

            // Then we create the model

            try
            {
                #region Snippet:DigitalTwinsSampleCreateModels

                await client.CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload });
                Console.WriteLine($"Created models '{componentModelId}' and '{sampleModelId}'.");

                #endregion Snippet:DigitalTwinsSampleCreateModels
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Conflict)
            {
                Console.WriteLine($"One or more models already existed.");
            }
            catch (Exception ex)
            {
                FatalError($"Failed to create models due to:\n{ex}");
            }

            // Get Model
            try
            {
                #region Snippet:DigitalTwinsSampleGetModel

                Response<DigitalTwinsModelData> sampleModelResponse = await client.GetModelAsync(sampleModelId);
                Console.WriteLine($"Retrieved model '{sampleModelResponse.Value.Id}'.");

                #endregion Snippet:DigitalTwinsSampleGetModel
            }
            catch (Exception ex)
            {
                FatalError($"Failed to get a model due to:\n{ex}");
            }

            // Now we decommission the model

            #region Snippet:DigitalTwinsSampleDecommisionModel

            try
            {
                await client.DecommissionModelAsync(sampleModelId);
                Console.WriteLine($"Decommissioned model '{sampleModelId}'.");
            }
            catch (RequestFailedException ex)
            {
                FatalError($"Failed to decommision model '{sampleModelId}' due to:\n{ex}");
            }

            #endregion Snippet:DigitalTwinsSampleDecommisionModel

            // Now delete created model

            #region Snippet:DigitalTwinsSampleDeleteModel

            try
            {
                await client.DeleteModelAsync(sampleModelId);
                Console.WriteLine($"Deleted model '{sampleModelId}'.");
            }
            catch (Exception ex)
            {
                FatalError($"Failed to delete model '{sampleModelId}' due to:\n{ex}");
            }

            #endregion Snippet:DigitalTwinsSampleDeleteModel
        }

        /// <summary>
        /// Try to delete a model, but don't fail if the model does not exist. Useful in setting up or tearing down after running a sample if the
        /// sample re-uses the same model Id each time
        /// </summary>
        /// <param name="client">The client to use when deleting the model</param>
        /// <param name="modelId">The id of the model to delete</param>
        /// <returns>An empty task once the model has been deleted.</returns>
        public static async Task TryDeleteModelAsync(DigitalTwinsClient client, string modelId)
        {
            try
            {
                Console.WriteLine($"Deleting model Id '{modelId}' if it exists.");
                await client.DeleteModelAsync(modelId);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                // Model did not exist yet, and that's fine
            }
        }
    }
}
