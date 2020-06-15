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

            // For the purpose of keeping code snippets readable to the user, hardcoded string literals are used in
            // place of assigned variables, e.g. Ids. Despite not being a good code practice, this prevents code
            // snippets from being out of context for the user when making API calls that accept Ids as parameters.

            // Load in model information and insert Ids for use by this sample.
            string newComponentModelPayload = SamplesConstants.TemporaryComponentModelPayload
                .Replace(SamplesConstants.ComponentId, "sampleComponentModel-123-Id");

            string newModelPayload = SamplesConstants.TemporaryModelWithComponentPayload
                .Replace(SamplesConstants.ModelId, "sampleModel-123-Id")
                .Replace(SamplesConstants.ComponentId, "sampleComponentModel-123-Id");

            // Then create models
            try
            {
                Response<IReadOnlyList<Models.ModelData>> createModelsResponse = await client.CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload });
                Console.WriteLine($"Created models with Ids {createModelsResponse.Value[0].Id} and {createModelsResponse.Value[1].Id}. Response status: {createModelsResponse.GetRawResponse().Status}.");
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Conflict)
            {
                Console.WriteLine("Warning: Required models already exist. Proceeding optimistically.");
            }
            catch (Exception ex)
            {
                FatalError($"Unable to run sample due to errors in model creation. Check the digital twins instance models' status to eliminate model Id conflicts. Error: {ex}");
            }

            #region Snippet:DigitalTwinsSampleDigitalTwinsLifecycle

            // Create digital twin with component payload using the BasicDigitalTwin serialization helper,
            // based on the model defined at https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples/DigitalTwinsClientSample/SamplesConstants.cs#L66.

            var basicTwin = new BasicDigitalTwin
            {
                Id = "basicDigitalTwin-123-Id",
                Metadata = { ModelId = "sampleModel-123-Id" },
                CustomProperties =
                {
                    // digital twin properties
                    { "Prop1", "Value1" },
                    { "Prop2", 987 },
                    // component
                    {
                        "Component1",
                        new ModelProperties
                        {
                            // component properties
                            CustomProperties =
                            {
                                { "ComponentProp1", "Component value 1" },
                                { "ComponentProp2", 123 },
                            },
                        }
                    },
                },
            };

            string basicDtPayload = JsonSerializer.Serialize(basicTwin);

            Response<string> createBasicDtResponse = await client.CreateDigitalTwinAsync("basicDigitalTwin-123-Id", basicDtPayload);
            Console.WriteLine($"Created digital twin with Id 'basicDigitalTwin-123-Id'. Response status: {createBasicDtResponse.GetRawResponse().Status}.");

            // You can also get a digital twin and deserialize it into a BasicDigitalTwin.
            // It works well for basic stuff, but as you can see it gets more difficult when delving into
            // more complex properties, like components.

            Response<string> getBasicDtResponse = await client.GetDigitalTwinAsync("basicDigitalTwin-123-Id");
            if (getBasicDtResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
            {
                BasicDigitalTwin basicDt = JsonSerializer.Deserialize<BasicDigitalTwin>(getBasicDtResponse.Value);

                // Must cast Component1 as a JsonElement and get its raw text in order to deserialize it as a dictionary
                string component1RawText = ((JsonElement)basicDt.CustomProperties["Component1"]).GetRawText();
                IDictionary<string, object> component1 = JsonSerializer.Deserialize<IDictionary<string, object>>(component1RawText);

                Console.WriteLine($"Retrieved and deserialized digital twin {basicDt.Id}:\n\t" +
                    $"ETag: {basicDt.ETag}\n\t" +
                    $"Prop1: {basicDt.CustomProperties["Prop1"]}\n\t" +
                    $"Prop2: {basicDt.CustomProperties["Prop2"]}\n\t" +
                    $"ComponentProp1: {component1["ComponentProp1"]}\n\t" +
                    $"ComponentProp2: {component1["ComponentProp2"]}");
            }

            // Alternatively, you can create your own custom data types to serialize and deserialize your digital twins.
            // By specifying your properties and types directly, it requires less code or knowledge of the type for
            // interaction.

            var customTwin = new CustomDigitalTwin
            {
                Id = "customDigitalTwin-123-Id",
                Metadata = { ModelId = "sampleModel-123-Id" },
                Prop1 = "Prop1 val",
                Prop2 = 987,
                Component1 = new Component1
                {
                    ComponentProp1 = "Component prop1 val",
                    ComponentProp2 = 123,
                }
            };
            string customDtPayload = JsonSerializer.Serialize(customTwin);

            Response<string> createCustomDtResponse = await client.CreateDigitalTwinAsync("customDigitalTwin-123-Id", customDtPayload);
            Console.WriteLine($"Created digital twin with Id 'customDigitalTwin-123-Id'. Response status: {createCustomDtResponse.GetRawResponse().Status}.");

            // Getting and deserializing a digital twin into a custom data type is extremely easy.
            // Custom types provide the best possible experience.
            Response<string> getCustomDtResponse = await client.GetDigitalTwinAsync("customDigitalTwin-123-Id");
            if (getCustomDtResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
            {
                CustomDigitalTwin customDt = JsonSerializer.Deserialize<CustomDigitalTwin>(getCustomDtResponse.Value);
                Console.WriteLine($"Retrieved and deserialized digital twin {customDt.Id}:\n\t" +
                    $"ETag: {customDt.ETag}\n\t" +
                    $"Prop1: {customDt.Prop1}\n\t" +
                    $"Prop2: {customDt.Prop2}\n\t" +
                    $"ComponentProp1: {customDt.Component1.ComponentProp1}\n\t" +
                    $"ComponentProp2: {customDt.Component1.ComponentProp2}");
            }

            // Update Component1 by replacing the property ComponentProp1 value
            var componentUpdateUtility = new UpdateOperationsUtility();
            componentUpdateUtility.AppendReplaceOp("/ComponentProp1", "Some new value");
            string updatePayload = componentUpdateUtility.Serialize();
            Response<string> response = await client.UpdateComponentAsync("customDigitalTwin-123-Id", "Component1", updatePayload);
            Console.WriteLine($"Updated component for digital twin with Id 'customDigitalTwin-123-Id'. Response status: {response.GetRawResponse().Status}");

            // Get Component
            response = await client.GetComponentAsync("basicDigitalTwin-123-Id", SamplesConstants.ComponentPath);
            Console.WriteLine($"Retrieved component for digital twin with Id 'basicDigitalTwin-123-Id'. Response status: {response.GetRawResponse().Status}");

            // Clean up

            try
            {
                await client.DeleteDigitalTwinAsync("basicDigitalTwin-123-Id");
                await client.DeleteDigitalTwinAsync("customDigitalTwin-123-Id");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete digital twin due to {ex}");
            }

            #endregion Snippet:DigitalTwinsSampleDigitalTwinsLifecycle

            try
            {
                await client.DeleteModelAsync("sampleModel-123-Id");
                await client.DeleteModelAsync("sampleComponentModel-123-Id");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete models due to {ex}");
            }
        }
    }
}
