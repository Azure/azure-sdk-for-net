// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core.Serialization;
using static Azure.DigitalTwins.Core.Samples.SampleLogger;
using static Azure.DigitalTwins.Core.Samples.UniqueIdHelper;

namespace Azure.DigitalTwins.Core.Samples
{
    internal class ComponentSamples
    {
        /// <summary>
        /// Creates a digital twin with Component and upates Component
        /// </summary>
        public async Task RunSamplesAsync(DigitalTwinsClient client)
        {
            PrintHeader("COMPONENT SAMPLE");

            // For the purpose of this example we will create temporary models using a random model Ids.
            // We have to make sure these model Ids are unique within the DT instance.

            string componentModelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryComponentModelPrefix, client);
            string modelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryModelPrefix, client);
            string basicDtId = await GetUniqueTwinIdAsync(SamplesConstants.TemporaryTwinPrefix, client);

            string newComponentModelPayload = SamplesConstants.TemporaryComponentModelPayload
                .Replace(SamplesConstants.ComponentId, componentModelId);

            string newModelPayload = SamplesConstants.TemporaryModelWithComponentPayload
                .Replace(SamplesConstants.ModelId, modelId)
                .Replace(SamplesConstants.ComponentId, componentModelId);

            // Then we create models
            Response<IReadOnlyList<Models.ModelData>> createModelsResponse = await client
                .CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload })
                ;
            Console.WriteLine($"Successfully created models Ids {componentModelId} and {modelId} with response {createModelsResponse.GetRawResponse().Status}.");

            #region Snippet:DigitalTwinsSampleCreateBasicTwin

            // Create digital twin with component payload using the BasicDigitalTwin serialization helper

            var basicDigitalTwin = new BasicDigitalTwin
            {
                Id = basicDtId
            };
            basicDigitalTwin.Metadata.ModelId = modelId;
            basicDigitalTwin.CustomProperties.Add("Prop1", "Value1");
            basicDigitalTwin.CustomProperties.Add("Prop2", "Value2");

            var componentMetadata = new ModelProperties();
            componentMetadata.Metadata.ModelId = componentModelId;
            componentMetadata.CustomProperties.Add("ComponentProp1", "ComponentValue1");
            componentMetadata.CustomProperties.Add("ComponentProp2", "ComponentValue2");

            basicDigitalTwin.CustomProperties.Add("Component1", componentMetadata);

            string basicDtPayload = JsonSerializer.Serialize(basicDigitalTwin);

            Response<string> createBasicDtResponse = await client.CreateDigitalTwinAsync(basicDtId, basicDtPayload);
            Console.WriteLine($"Created digital twin {basicDtId} with response {createBasicDtResponse.GetRawResponse().Status}.");

            #endregion Snippet:DigitalTwinsSampleCreateBasicTwin

            // You can also get a digital twin and deserialize it into a BasicDigitalTwin.
            // It works well for basic stuff, but as you can see it gets more difficult when delving into
            // more complex properties, like components.

            #region Snippet:DigitalTwinsSampleGetBasicDigitalTwin

            Response<string> getBasicDtResponse = await client.GetDigitalTwinAsync(basicDtId);
            if (getBasicDtResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
            {
                BasicDigitalTwin basicDt = JsonSerializer.Deserialize<BasicDigitalTwin>(getBasicDtResponse.Value);

                // Must cast Component1 as a JsonElement and get its raw text in order to deserialize it as a dictionary
                string component1RawText = ((JsonElement)basicDt.CustomProperties["Component1"]).GetRawText();
                var component1 = JsonSerializer.Deserialize<IDictionary<string, object>>(component1RawText);

                Console.WriteLine($"Retrieved and deserialized digital twin {basicDt.Id}  with ETag {basicDt.ETag} " +
                    $"and Prop1 '{basicDt.CustomProperties["Prop1"]}', Prop2 '{basicDt.CustomProperties["Prop2"]}', " +
                    $"ComponentProp1 '{component1["ComponentProp1"]}', ComponentProp2 '{component1["ComponentProp2"]}'");
            }

            #endregion Snippet:DigitalTwinsSampleGetBasicDigitalTwin

            // Alternatively, you can create your own custom data types to serialize and deserialize your digital twins.
            // By specifying your properties and types directly, it requires less code or knowledge of the type for
            // interaction.

            #region Snippet:DigitalTwinsSampleCreateCustomTwin

            string customDtId = await GetUniqueTwinIdAsync(SamplesConstants.TemporaryTwinPrefix, client);
            var customDigitalTwin = new CustomDigitalTwin
            {
                Id = customDtId,
                Metadata = new CustomDigitalTwinMetadata { ModelId = modelId },
                Prop1 = "Prop1 val",
                Prop2 = "Prop2 val",
                Component1 = new Component1
                {
                    Metadata = new Component1Metadata { ModelId = componentModelId },
                    ComponentProp1 = "Component prop1 val",
                    ComponentProp2 = "Component prop2 val",
                }
            };
            string dt2Payload = JsonSerializer.Serialize(customDigitalTwin);

            Response<string> createCustomDtResponse = await client.CreateDigitalTwinAsync(customDtId, dt2Payload);
            Console.WriteLine($"Created digital twin {customDtId} with response {createCustomDtResponse.GetRawResponse().Status}.");

            #endregion Snippet:DigitalTwinsSampleCreateCustomTwin

            // Getting and deserializing a digital twin into a custom data type is extremely easy.
            // Custom types provide the best possible experience.

            #region Snippet:DigitalTwinsSampleGetCustomDigitalTwin

            Response<string> getCustomDtResponse = await client.GetDigitalTwinAsync(customDtId);
            if (getCustomDtResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
            {
                CustomDigitalTwin customDt = JsonSerializer.Deserialize<CustomDigitalTwin>(getCustomDtResponse.Value);
                Console.WriteLine($"Retrieved and deserialized digital twin {customDt.Id} with ETag {customDt.ETag} " +
                    $"and Prop1 '{customDt.Prop1}', Prop2 '{customDt.Prop2}', " +
                    $"ComponentProp1 '{customDt.Component1.ComponentProp1}, ComponentProp2 '{customDt.Component1.ComponentProp2}'");
            }

            #endregion Snippet:DigitalTwinsSampleGetCustomDigitalTwin

            #region Snippet:DigitalTwinsSampleUpdateComponent

            // Update Component1 by replacing the property ComponentProp1 value
            var componentUpdateUtility = new UpdateOperationsUtility();
            componentUpdateUtility.AppendReplaceOp("/ComponentProp1", "Some new value");
            string updatePayload = componentUpdateUtility.Serialize();

            Response<string> response = await client.UpdateComponentAsync(basicDtId, "Component1", updatePayload);

            Console.WriteLine($"Updated component for digital twin {basicDtId}. Update response status: {response.GetRawResponse().Status}");

            #endregion Snippet:DigitalTwinsSampleUpdateComponent

            // Get Component

            #region Snippet:DigitalTwinsSampleGetComponent

            response = await client.GetComponentAsync(basicDtId, SamplesConstants.ComponentPath);

            Console.WriteLine($"Get component for digital twin: \n{response.Value}. Get response status: {response.GetRawResponse().Status}");

            #endregion Snippet:DigitalTwinsSampleGetComponent

            // Clean up

            try
            {
                await client.DeleteDigitalTwinAsync(basicDtId);
                await client.DeleteDigitalTwinAsync(customDtId);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete digital twin due to {ex}");
            }

            try
            {
                await client.DeleteModelAsync(modelId);
                await client.DeleteModelAsync(componentModelId);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete models due to {ex}");
            }
        }
    }
}
