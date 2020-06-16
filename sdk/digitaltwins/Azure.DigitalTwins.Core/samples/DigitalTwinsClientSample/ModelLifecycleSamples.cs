// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core;
using Azure.DigitalTwins.Core.Models;
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

                Response<IReadOnlyList<ModelData>> response = await client.CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload });
                Console.WriteLine($"Created models with Ids {componentModelId} and {sampleModelId}. Response status: {response.GetRawResponse().Status}");

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

                Response<ModelData> sampleModel = await client.GetModelAsync(sampleModelId);
                Console.WriteLine($"Retrieved model with Id {sampleModelId}. Response status: {sampleModel.GetRawResponse().Status}");

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
                Response decommissionModelResponse = await client.DecommissionModelAsync(sampleModelId);
                Console.WriteLine($"Decommissioned model with Id {sampleModelId}. Response status: {decommissionModelResponse.Status}");
            }
            catch (RequestFailedException ex)
            {
                FatalError($"Failed to decommision model with Id {sampleModelId} due to:\n{ex}");
            }

            #endregion Snippet:DigitalTwinsSampleDecommisionModel

            // Now delete created model

            #region Snippet:DigitalTwinsSampleDeleteModel

            try
            {
                Response deleteModelResponse = await client.DeleteModelAsync(sampleModelId);
                Console.WriteLine($"Deleted model with Id {sampleModelId}. Response status: {deleteModelResponse.Status}");
            }
            catch (Exception ex)
            {
                FatalError($"Failed to delete model with Id {sampleModelId} due to:\n{ex}");
            }

            #endregion Snippet:DigitalTwinsSampleDeleteModel
        }
    }
}
