// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
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
            await client.CreateModelsAsync(
                new[]
                {
                    newComponentModelPayload,
                    newModelPayload
                });

            // Get the models we just created
            AsyncPageable<DigitalTwinsModelData> models = client.GetModelsAsync();
            await foreach (DigitalTwinsModelData model in models)
            {
                Console.WriteLine($"Created model {model.Id}.");
            }

            #region Snippet:DigitalTwinsSampleCreateBasicTwin

            // Create digital twin with component payload using the BasicDigitalTwin serialization helper

            var basicTwin = new BasicDigitalTwin
            {
                Id = basicDtId,
                // model Id of digital twin
                Metadata =
                {
                    ModelId = modelId,
                    PropertyMetadata = new Dictionary<string, DigitalTwinPropertyMetadata>
                    {
                        {
                            "Prop2",
                            new DigitalTwinPropertyMetadata
                            {
                                // must always be serialized as ISO 8601
                                SourceTime = DateTimeOffset.UtcNow,
                            }
                        }
                    },
                },
                Contents =
                {
                    // digital twin properties
                    { "Prop1", "Value1" },
                    { "Prop2", 987 },
                    // component
                    {
                        "Component1",
                        new BasicDigitalTwinComponent
                        {
                            // writeable component metadata
                            Metadata =  new Dictionary<string, DigitalTwinPropertyMetadata>
                            {
                                {
                                    "ComponentProp2",
                                    new DigitalTwinPropertyMetadata
                                    {
                                        // must always be serialized as ISO 8601
                                        SourceTime = DateTimeOffset.UtcNow,
                                    }
                                }
                            },
                            // component properties
                            Contents =
                            {
                                { "ComponentProp1", "Component value 1" },
                                { "ComponentProp2", 123 },
                            },
                        }
                    },
                },
            };

            Response<BasicDigitalTwin> createDigitalTwinResponse = await client.CreateOrReplaceDigitalTwinAsync(basicDtId, basicTwin);
            Console.WriteLine($"Created digital twin '{createDigitalTwinResponse.Value.Id}'.");

            #endregion Snippet:DigitalTwinsSampleCreateBasicTwin

            // You can also get a digital twin as a BasicDigitalTwin type.
            // It works well for basic stuff, but as you can see it gets more difficult when delving into
            // more complex properties, like components.

            #region Snippet:DigitalTwinsSampleGetBasicDigitalTwin

            Response<BasicDigitalTwin> getBasicDtResponse = await client.GetDigitalTwinAsync<BasicDigitalTwin>(basicDtId);
            BasicDigitalTwin basicDt = getBasicDtResponse.Value;

            // Must cast Component1 as a JsonElement and get its raw text in order to deserialize it as a dictionary
            string component1RawText = ((JsonElement)basicDt.Contents["Component1"]).GetRawText();
            var component1 = JsonSerializer.Deserialize<BasicDigitalTwinComponent>(component1RawText);

            Console.WriteLine($"Retrieved and deserialized digital twin {basicDt.Id}:\n\t" +
                $"ETag: {basicDt.ETag}\n\t" +
                $"ModelId: {basicDt.Metadata.ModelId}\n\t" +
                $"LastUpdatedOn: {basicDt.LastUpdatedOn}\n\t" +
                $"Prop1: {basicDt.Contents["Prop1"]}, last updated on {basicDt.Metadata.PropertyMetadata["Prop1"].LastUpdatedOn}\n\t" +
                $"Prop2: {basicDt.Contents["Prop2"]}, last updated on {basicDt.Metadata.PropertyMetadata["Prop2"].LastUpdatedOn} and sourced at {basicDt.Metadata.PropertyMetadata["Prop2"].SourceTime}\n\t" +
                $"Component1.LastUpdatedOn: {component1.LastUpdatedOn}\n\t" +
                $"Component1.Prop1: {component1.Contents["ComponentProp1"]}, last updated on: {component1.Metadata["ComponentProp1"].LastUpdatedOn}\n\t" +
                $"Component1.Prop2: {component1.Contents["ComponentProp2"]}, last updated on: {component1.Metadata["ComponentProp2"].LastUpdatedOn} and sourced at: {component1.Metadata["ComponentProp2"].SourceTime}");

            #endregion Snippet:DigitalTwinsSampleGetBasicDigitalTwin

            string customDtId = await GetUniqueTwinIdAsync(SamplesConstants.TemporaryTwinPrefix, client);

            // Alternatively, you can create your own custom data types to serialize and deserialize your digital twins.
            // By specifying your properties and types directly, it requires less code or knowledge of the type for
            // interaction.

            #region Snippet:DigitalTwinsSampleCreateCustomTwin

            var customTwin = new CustomDigitalTwin
            {
                Id = customDtId,
                Metadata = { ModelId = modelId },
                Prop1 = "Prop1 val",
                Prop2 = 987,
                Component1 = new MyCustomComponent
                {
                    ComponentProp1 = "Component prop1 val",
                    ComponentProp2 = 123,
                },
            };
            Response<CustomDigitalTwin> createCustomDigitalTwinResponse = await client.CreateOrReplaceDigitalTwinAsync(customDtId, customTwin);
            Console.WriteLine($"Created digital twin '{createCustomDigitalTwinResponse.Value.Id}'.");

            #endregion Snippet:DigitalTwinsSampleCreateCustomTwin

            // Getting a digital twin as a custom data type is extremely easy.
            // Custom types provide the best possible experience.

            #region Snippet:DigitalTwinsSampleGetCustomDigitalTwin

            Response<CustomDigitalTwin> getCustomDtResponse = await client.GetDigitalTwinAsync<CustomDigitalTwin>(customDtId);
            CustomDigitalTwin customDt = getCustomDtResponse.Value;
            Console.WriteLine($"Retrieved and deserialized digital twin {customDt.Id}:\n\t" +
                $"ETag: {customDt.ETag}\n\t" +
                $"ModelId: {customDt.Metadata.ModelId}\n\t" +
                $"Prop1: [{customDt.Prop1}] last updated on {customDt.Metadata.Prop1.LastUpdatedOn}\n\t" +
                $"Prop2: [{customDt.Prop2}] last updated on {customDt.Metadata.Prop2.LastUpdatedOn}\n\t" +
                $"ComponentProp1: [{customDt.Component1.ComponentProp1}] last updated {customDt.Component1.Metadata.ComponentProp1.LastUpdatedOn}\n\t" +
                $"ComponentProp2: [{customDt.Component1.ComponentProp2}] last updated {customDt.Component1.Metadata.ComponentProp2.LastUpdatedOn}");

            #endregion Snippet:DigitalTwinsSampleGetCustomDigitalTwin

            #region Snippet:DigitalTwinsSampleUpdateComponent

            // Update Component1 by replacing the property ComponentProp1 value,
            // using an optional utility to build the payload.
            var componentJsonPatchDocument = new JsonPatchDocument();
            componentJsonPatchDocument.AppendReplace("/ComponentProp1", "Some new value");
            await client.UpdateComponentAsync(basicDtId, "Component1", componentJsonPatchDocument);
            Console.WriteLine($"Updated component for digital twin '{basicDtId}'.");

            #endregion Snippet:DigitalTwinsSampleUpdateComponent

            // Get Component

            #region Snippet:DigitalTwinsSampleGetComponent

            await client.GetComponentAsync<MyCustomComponent>(basicDtId, SamplesConstants.ComponentName);
            Console.WriteLine($"Retrieved component for digital twin '{basicDtId}'.");

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
