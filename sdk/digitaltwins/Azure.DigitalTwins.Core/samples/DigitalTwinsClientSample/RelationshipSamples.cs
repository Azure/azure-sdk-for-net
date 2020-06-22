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

            // Create a building digital twin model.
            string buildingModelPayload = SamplesConstants.TemporaryModelWithRelationshipPayload
                .Replace(SamplesConstants.ModelId, "dtmi:samples:SampleBuilding;1")
                .Replace(SamplesConstants.ModelDisplayName, "Building")
                .Replace(SamplesConstants.RelationshipName, "contains")
                .Replace(SamplesConstants.RelationshipTargetModelId, "dtmi:samples:SampleFloor;1");

            await client.CreateModelsAsync(
                new[]
                {
                    buildingModelPayload
                });
            Console.WriteLine($"Created model 'dtmi:samples:SampleBuilding;1'.");

            // Create a floor digital twin model.
            string floorModelPayload = SamplesConstants.TemporaryModelWithRelationshipPayload
                .Replace(SamplesConstants.ModelId, "dtmi:samples:SampleFloor;1")
                .Replace(SamplesConstants.ModelDisplayName, "Floor")
                .Replace(SamplesConstants.RelationshipName, "containedIn")
                .Replace(SamplesConstants.RelationshipTargetModelId, "dtmi:samples:SampleBuilding;1");

            await client.CreateModelsAsync(new[] { floorModelPayload });
            Console.WriteLine($"Created model 'dtmi:samples:SampleFloor;1.'");

            // Create a building digital twin.
            var buildingDigitalTwin = new BasicDigitalTwin
            {
                Id = "buildingTwinId",
                Metadata = { ModelId = "dtmi:samples:SampleBuilding;1" }
            };

            string buildingDigitalTwinPayload = JsonSerializer.Serialize(buildingDigitalTwin);
            await client.CreateDigitalTwinAsync("buildingTwinId", buildingDigitalTwinPayload);
            Console.WriteLine($"Created twin 'buildingTwinId'.");

            // Create a floor digital.
            var floorDigitalTwin = new BasicDigitalTwin
            {
                Id = "floorTwinId",
                Metadata = { ModelId = "dtmi:samples:SampleFloor;1" }
            };

            string floorDigitalTwinPayload = JsonSerializer.Serialize(floorDigitalTwin);
            await client.CreateDigitalTwinAsync("floorTwinId", floorDigitalTwinPayload);
            Console.WriteLine($"Created twin 'floorTwinId'.");

            // Create a relationship between building and floor using the BasicRelationship serialization helper.

            #region Snippet:DigitalTwinsSampleCreateBasicRelationship

            var buildingFloorRelationshipPayload = new BasicRelationship
            {
                Id = "buildingFloorRelationshipId",
                SourceId = "buildingTwinId",
                TargetId = "floorTwinId",
                Name = "contains",
                CustomProperties =
                {
                    { "Prop1", "Prop1 value" },
                    { "Prop2", 6 }
                }
            };

            string serializedRelationship = JsonSerializer.Serialize(buildingFloorRelationshipPayload);
            await client.CreateRelationshipAsync("buildingTwinId", "buildingFloorRelationshipId", serializedRelationship);
            Console.WriteLine($"Created a digital twin relationship 'buildingFloorRelationshipId' from twin 'buildingTwinId' to twin 'floorTwinId'.");

            #endregion Snippet:DigitalTwinsSampleCreateBasicRelationship

            // You can get a relationship and deserialize it into a BasicRelationship.

            #region Snippet:DigitalTwinsSampleGetBasicRelationship

            Response<string> getBasicRelationshipResponse = await client.GetRelationshipAsync("buildingTwinId", "buildingFloorRelationshipId");
            if (getBasicRelationshipResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
            {
                BasicRelationship basicRelationship = JsonSerializer.Deserialize<BasicRelationship>(getBasicRelationshipResponse.Value);
                Console.WriteLine($"Retrieved relationship '{basicRelationship.Id}' from twin {basicRelationship.SourceId}.\n\t" +
                    $"Prop1: {basicRelationship.CustomProperties["Prop1"]}\n\t" +
                    $"Prop2: {basicRelationship.CustomProperties["Prop2"]}");
            }

            #endregion Snippet:DigitalTwinsSampleGetBasicRelationship

            // Alternatively, you can create your own custom data types to serialize and deserialize your relationships.
            // This requires less code or knowledge of the type for interaction.

            // Create a relationship between floorTwinId and buildingTwinId using a custom data type.

            #region Snippet:DigitalTwinsSampleCreateCustomRelationship

            var floorBuildingRelationshipPayload = new CustomRelationship
            {
                Id = "floorBuildingRelationshipId",
                SourceId = "floorTwinId",
                TargetId = "buildingTwinId",
                Name = "containedIn",
                Prop1 = "Prop1 val",
                Prop2 = 4
            };
            string serializedCustomRelationship = JsonSerializer.Serialize(floorBuildingRelationshipPayload);

            Response<string> createCustomRelationshipResponse = await client.CreateRelationshipAsync("floorTwinId", "floorBuildingRelationshipId", serializedCustomRelationship);
            Console.WriteLine($"Created a digital twin relationship 'floorBuildingRelationshipId' from twin 'floorTwinId' to twin 'buildingTwinId'.");

            #endregion Snippet:DigitalTwinsSampleCreateCustomRelationship

            // Getting and deserializing a relationship into a custom data type is extremely easy.

            #region Snippet:DigitalTwinsSampleGetCustomRelationship

            Response<string> getCustomRelationshipResponse = await client.GetRelationshipAsync("floorTwinId", "floorBuildingRelationshipId");
            CustomRelationship getCustomRelationship = JsonSerializer.Deserialize<CustomRelationship>(getCustomRelationshipResponse.Value);
            Console.WriteLine($"Retrieved and deserialized relationship '{getCustomRelationship.Id}' from twin '{getCustomRelationship.SourceId}'.\n\t" +
                $"Prop1: {getCustomRelationship.Prop1}\n\t" +
                $"Prop2: {getCustomRelationship.Prop2}");

            #endregion Snippet:DigitalTwinsSampleGetCustomRelationship

            // Get all relationships in the graph where buildingTwinId is the source of the relationship.

            #region Snippet:DigitalTwinsSampleGetAllRelationships

            AsyncPageable<string> relationships = client.GetRelationshipsAsync("buildingTwinId");
            await foreach (var relationshipJson in relationships)
            {
                BasicRelationship relationship = JsonSerializer.Deserialize<BasicRelationship>(relationshipJson);
                Console.WriteLine($"Retrieved relationship '{relationship.Id}' with source {relationship.SourceId}' and " +
                    $"target {relationship.TargetId}.\n\t" +
                    $"Prop1: {relationship.CustomProperties["Prop1"]}\n\t" +
                    $"Prop2: {relationship.CustomProperties["Prop2"]}");
            }

            #endregion Snippet:DigitalTwinsSampleGetAllRelationships

            // Get all incoming relationships in the graph where buildingTwinId is the target of the relationship.

            #region Snippet:DigitalTwinsSampleGetIncomingRelationships

            AsyncPageable<IncomingRelationship> incomingRelationships = client.GetIncomingRelationshipsAsync("buildingTwinId");

            await foreach (IncomingRelationship incomingRelationship in incomingRelationships)
            {
                Console.WriteLine($"Found an incoming relationship '{incomingRelationship.RelationshipId}' from '{incomingRelationship.SourceId}'.");
            }

            #endregion Snippet:DigitalTwinsSampleGetIncomingRelationships

            // Delete the contains relationship, created earlier in the sample code, from building to floor.

            #region Snippet:DigitalTwinsSampleDeleteRelationship

            await client.DeleteRelationshipAsync("buildingTwinId", "buildingFloorRelationshipId");
            Console.WriteLine($"Deleted relationship 'buildingFloorRelationshipId'.");

            #endregion Snippet:DigitalTwinsSampleDeleteRelationship

            // Delete the containedIn relationship, created earlier in the sample code, from floor to building.
            await client.DeleteRelationshipAsync("floorTwinId", "floorBuildingRelationshipId");
            Console.WriteLine($"Deleted relationship 'floorBuildingRelationshipId'.");

            // Clean up.
            try
            {
                // Delete all twins
                await client.DeleteDigitalTwinAsync("buildingTwinId");
                await client.DeleteDigitalTwinAsync("floorTwinId");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete twin due to {ex}.");
            }

            try
            {
                await client.DeleteModelAsync("dtmi:samples:SampleBuilding;1");
                await client.DeleteModelAsync("dtmi:samples:SampleFloor;1");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete model due to {ex}.");
            }
        }
    }
}
