// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core.Models;
using Azure.DigitalTwins.Core.Serialization;
using static Azure.DigitalTwins.Core.Samples.SampleLogger;

namespace Azure.DigitalTwins.Core.Samples
{
    internal class RelationshipSamples
    {
        /// <summary>
        /// Creates two digital twins, and connect them with relationships.
        /// </summary>
        public async Task RunSamplesAsync(DigitalTwinsClient client)
        {
            // For the purpose of keeping code snippets readable to the user, hardcoded string literals are used in place of assigned variables, eg Ids.
            // Despite not being a good code practice, this prevents code snippets from being out of context for the user when making API calls that accept Ids as parameters.

            PrintHeader("RELATIONSHIP SAMPLE");

            // Create digital twin model to be used for the creating digital twins.
            string modelPayload = SamplesConstants.TemporaryModelWithRelationshipPayload
                .Replace(SamplesConstants.ModelId, "dtmi:samples:TempModel;1")
                .Replace(SamplesConstants.RelationshipTargetModelId, "dtmi:samples:TempModel;1");

            Response<IReadOnlyList<Models.ModelData>> createModelsResponse = await client.CreateModelsAsync(
                new[]
                {
                    modelPayload
                });
            Console.WriteLine($"Created model with Id dtmi:samples:TempModel;1. Response status: {createModelsResponse.GetRawResponse().Status}.");

            // Create a digital twin instance to be used as one end of a relationship.
            var digitalTwin1 = new BasicDigitalTwin
            {
                Id = "sampleTwin1Id",
                Metadata = { ModelId = "dtmi:samples:TempModel;1" }
            };

            string digitalTwin1Payload = JsonSerializer.Serialize(digitalTwin1);
            Response<string> createDigitalTwin1Response = await client.CreateDigitalTwinAsync("sampleTwin1Id", digitalTwin1Payload);
            Console.WriteLine($"Created a digital twin with Id sampleTwin1Id. Response status: {createDigitalTwin1Response.GetRawResponse().Status}.");

            // Create a digital twin instance to be used as another end of a relationship.
            var digitalTwin2 = new BasicDigitalTwin
            {
                Id = "sampleTwin2Id",
                Metadata = { ModelId = "dtmi:samples:TempModel;1" }
            };

            string digitalTwin2Payload = JsonSerializer.Serialize(digitalTwin2);
            Response<string> createDigitalTwin2Response = await client.CreateDigitalTwinAsync("sampleTwin2Id", digitalTwin2Payload);
            Console.WriteLine($"Created a digital twin with Id sampleTwin2Id. Response status: {createDigitalTwin2Response.GetRawResponse().Status}.");

            // Create a relationship between sampleTwin1Id and sampleTwin2Id using the BasicRelationship serialization helper.
            #region Snippet:DigitalTwinsSampleCreateBasicRelationship

            var basicRelationshipPayload = new BasicRelationship
            {
                Id = "sampleRelationship1Id",
                SourceId = "sampleTwin1Id",
                TargetId = "sampleTwin2Id",
                Name = "related",
                CustomProperties =
                {
                    { "Prop1", "Prop1 value" },
                    { "Prop2", 6 }
                }
            };

            string serializedRelationship = JsonSerializer.Serialize(basicRelationshipPayload);
            Response<string> createRelationshipResponse = await client.CreateRelationshipAsync("sampleTwin1Id", "sampleRelationship1Id", serializedRelationship);
            Console.WriteLine($"Created a digital twin relationship with Id sampleRelationship1Id from digital twin with Id sampleTwin1Id to digital twin with Id sampleTwin2Id. " +
                $"Response status: {createRelationshipResponse.GetRawResponse().Status}.");

            #endregion Snippet:DigitalTwinsSampleCreateBasicRelationship

            // You can get a relationship and deserialize it into a BasicRelationship.
            #region Snippet:DigitalTwinsSampleGetBasicRelationship

            Response<string> getBasicRelationshipResponse = await client.GetRelationshipAsync("sampleTwin1Id", "sampleRelationship1Id");
            if (getBasicRelationshipResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
            {
                BasicRelationship basicRelationship = JsonSerializer.Deserialize<BasicRelationship>(getBasicRelationshipResponse.Value);
                Console.WriteLine($"Retrieved relationship with Id {basicRelationship.Id} from digital twin with Id {basicRelationship.SourceId}. " +
                    $"Response status: {getBasicRelationshipResponse.GetRawResponse().Status}.\n\t" +
                    $"Prop1: {basicRelationship.CustomProperties["Prop1"]}\n\t" +
                    $"Prop2: {basicRelationship.CustomProperties["Prop2"]}");
            }

            #endregion Snippet:DigitalTwinsSampleGetBasicRelationship

            // Alternatively, you can create your own custom data types to serialize and deserialize your relationships.
            // This requires less code or knowledge of the type for interaction.

            // Create a relationship between sampleTwin2Id and sampleTwin1Id using a custom data type.
            #region Snippet:DigitalTwinsSampleCreateCustomRelationship

            var customRelationshipPayload = new CustomRelationship
            {
                Id = "sampleRelationship2Id",
                SourceId = "sampleTwin2Id",
                TargetId = "sampleTwin1Id",
                Name = "related",
                Prop1 = "Prop1 val",
                Prop2 = 4
            };
            string serializedCustomRelationship = JsonSerializer.Serialize(customRelationshipPayload);

            Response<string> createCustomRelationshipResponse = await client.CreateRelationshipAsync("sampleTwin2Id", "sampleRelationship2Id", serializedCustomRelationship);
            Console.WriteLine($"Created a digital twin relationship with Id sampleRelationship2Id from digital twin with Id sampleTwin2Id to digital twin with Id sampleTwin1Id. " +
                $"Response status: {createCustomRelationshipResponse.GetRawResponse().Status}.");

            #endregion Snippet:DigitalTwinsSampleCreateCustomRelationship

            // Getting and deserializing a relationship into a custom data type is extremely easy.
            #region Snippet:DigitalTwinsSampleGetCustomRelationship

            Response<string> getCustomRelationshipResponse = await client.GetRelationshipAsync("sampleTwin2Id", "sampleRelationship2Id");
            if (getCustomRelationshipResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
            {
                CustomRelationship getCustomRelationship = JsonSerializer.Deserialize<CustomRelationship>(getCustomRelationshipResponse.Value);
                Console.WriteLine($"Retrieved and deserialized relationship with Id {getCustomRelationship.Id} from digital twin with Id {getCustomRelationship.SourceId}. " +
                    $"Response status: {getCustomRelationshipResponse.GetRawResponse().Status}.\n\t" +
                    $"Prop1: {getCustomRelationship.Prop1}\n\t" +
                    $"Prop2: {getCustomRelationship.Prop2}");
            }

            #endregion Snippet:DigitalTwinsSampleGetCustomRelationship

            // Get all relationships in the graph where sampleTwin1 is the source of the relationship.
            #region Snippet:DigitalTwinsSampleGetAllRelationships

            AsyncPageable<string> relationships = client.GetRelationshipsAsync("sampleTwin1Id");

            await foreach (var relationshipJson in relationships)
            {
                BasicRelationship relationship = JsonSerializer.Deserialize<BasicRelationship>(relationshipJson);
                Console.WriteLine($"Found relationship with Id {relationship.Id} with a digital twin source Id {relationship.SourceId} and " +
                    $"a digital twin target Id {relationship.TargetId}. \n\t " +
                    $"Prop1: {relationship.CustomProperties["Prop1"]}\n\t" +
                    $"Prop2: {relationship.CustomProperties["Prop2"]}");
            }

            #endregion Snippet:DigitalTwinsSampleGetAllRelationships

            // Get all incoming relationships in the graph where sampleTwin1 is the target of the relationship.
            #region Snippet:DigitalTwinsSampleGetIncomingRelationships

            AsyncPageable<IncomingRelationship> incomingRelationships = client.GetIncomingRelationshipsAsync("sampleTwin1Id");

            await foreach (IncomingRelationship incomingRelationship in incomingRelationships)
            {
                Console.WriteLine($"Found an incoming relationship with Id {incomingRelationship.RelationshipId} coming from a digital twin with Id {incomingRelationship.SourceId}.");
            }

            #endregion Snippet:DigitalTwinsSampleGetIncomingRelationships

            #region Snippet:DigitalTwinsSampleDeleteAllRelationships
            
            // Delete all relationships from sampleTwin1 to sampleTwin2. These relationships were created using the BasicRelationship type.
            AsyncPageable<string> twin1RelationshipsToDelete = client.GetRelationshipsAsync("sampleTwin1Id");
            await foreach (var relationshipToDelete in twin1RelationshipsToDelete)
            {
                BasicRelationship relationship = JsonSerializer.Deserialize<BasicRelationship>(relationshipToDelete);
                Response deleteRelationshipResponse = await client.DeleteRelationshipAsync(relationship.SourceId, relationship.Id);
                Console.WriteLine($"Deleted relationship with Id {relationship.Id}. Status response: {deleteRelationshipResponse.Status}.");
            }

            // Delete all relationships from sampleTwin2 to sampleTwin1. These relationships were created using the CustomRelationship type.
            AsyncPageable<string> twin2RelationshipsToDelete = client.GetRelationshipsAsync("sampleTwin2Id");
            await foreach (var relationshipToDelete in twin2RelationshipsToDelete)
            {
                CustomRelationship relationship = JsonSerializer.Deserialize<CustomRelationship>(relationshipToDelete);
                Response deleteRelationshipResponse = await client.DeleteRelationshipAsync(relationship.SourceId, relationship.Id);
                Console.WriteLine($"Deleted relationship with Id {relationship.Id}. Status response: {deleteRelationshipResponse.Status}.");
            }

            #endregion Snippet:DigitalTwinsSampleDeleteAllRelationships

            // Clean up.
            try
            {
                // Delete all twins
                await client.DeleteDigitalTwinAsync("sampleTwin1Id");
                await client.DeleteDigitalTwinAsync("sampleTwin2Id");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete digital twin due to {ex}.");
            }

            try
            {
                await client.DeleteModelAsync("dtmi:samples:TempModel;1");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete model due to {ex}.");
            }
        }
    }
}
