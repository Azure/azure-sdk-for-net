// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.DigitalTwins.Samples;
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
            string sampleBuildingModelId = "dtmi:com:samples:SampleBuilding;1";
            string sampleFloorModelId = "dtmi:com:samples:SampleFloor;1";
            await ModelLifecycleSamples.TryDeleteModelAsync(client, sampleBuildingModelId);
            await ModelLifecycleSamples.TryDeleteModelAsync(client, sampleFloorModelId);

            // Create a building digital twin model.
            string buildingModelPayload = SamplesConstants.TemporaryModelWithRelationshipPayload
                .Replace(SamplesConstants.RelationshipTargetModelId, sampleFloorModelId)
                .Replace(SamplesConstants.ModelId, sampleBuildingModelId)
                .Replace(SamplesConstants.ModelDisplayName, "Building")
                .Replace(SamplesConstants.RelationshipName, "contains");

            await client.CreateModelsAsync(
                new[]
                {
                    buildingModelPayload
                });
            Console.WriteLine($"Created model '{sampleBuildingModelId}'.");

            // Create a floor digital twin model.
            string floorModelPayload = SamplesConstants.TemporaryModelWithRelationshipPayload
                .Replace(SamplesConstants.RelationshipTargetModelId, sampleBuildingModelId)
                .Replace(SamplesConstants.ModelId, sampleFloorModelId)
                .Replace(SamplesConstants.ModelDisplayName, "Floor")
                .Replace(SamplesConstants.RelationshipName, "containedIn");

            await client.CreateModelsAsync(new[] { floorModelPayload });

            // Get the model we just created
            Response<DigitalTwinsModelData> getFloorModelResponse = await client.GetModelAsync(sampleFloorModelId).ConfigureAwait(false);
            Console.WriteLine($"Created model '{getFloorModelResponse.Value.Id}'");

            // Create a building digital twin.
            var buildingDigitalTwin = new BasicDigitalTwin
            {
                Id = "buildingTwinId",
                Metadata = { ModelId = sampleBuildingModelId }
            };

            Response<BasicDigitalTwin> createDigitalTwinResponse = await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>("buildingTwinId", buildingDigitalTwin);
            Console.WriteLine($"Created twin '{createDigitalTwinResponse.Value.Id}'.");

            // Create a floor digital.
            var floorDigitalTwin = new BasicDigitalTwin
            {
                Id = "floorTwinId",
                Metadata = { ModelId = sampleFloorModelId }
            };

            Response<BasicDigitalTwin> createFloorDigitalTwinResponse = await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>("floorTwinId", floorDigitalTwin);
            Console.WriteLine($"Created twin '{createFloorDigitalTwinResponse.Value.Id}'.");

            // Create a relationship between building and floor using the BasicRelationship serialization helper.

            #region Snippet:DigitalTwinsSampleCreateBasicRelationship

            var buildingFloorRelationshipPayload = new BasicRelationship
            {
                Id = "buildingFloorRelationshipId",
                SourceId = "buildingTwinId",
                TargetId = "floorTwinId",
                Name = "contains",
                Properties =
                {
                    { "Prop1", "Prop1 value" },
                    { "Prop2", 6 }
                }
            };

            Response<BasicRelationship> createBuildingFloorRelationshipResponse = await client
                .CreateOrReplaceRelationshipAsync<BasicRelationship>("buildingTwinId", "buildingFloorRelationshipId", buildingFloorRelationshipPayload);
            Console.WriteLine($"Created a digital twin relationship '{createBuildingFloorRelationshipResponse.Value.Id}' " +
                $"from twin '{createBuildingFloorRelationshipResponse.Value.SourceId}' to twin '{createBuildingFloorRelationshipResponse.Value.TargetId}'.");

            #endregion Snippet:DigitalTwinsSampleCreateBasicRelationship

            // You can get a relationship as a BasicRelationship type.

            #region Snippet:DigitalTwinsSampleGetBasicRelationship

            Response<BasicRelationship> getBasicRelationshipResponse = await client.GetRelationshipAsync<BasicRelationship>(
                "buildingTwinId",
                "buildingFloorRelationshipId");
            if (getBasicRelationshipResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
            {
                BasicRelationship basicRelationship = getBasicRelationshipResponse.Value;
                Console.WriteLine($"Retrieved relationship '{basicRelationship.Id}' from twin {basicRelationship.SourceId}.\n\t" +
                    $"Prop1: {basicRelationship.Properties["Prop1"]}\n\t" +
                    $"Prop2: {basicRelationship.Properties["Prop2"]}");
            }

            #endregion Snippet:DigitalTwinsSampleGetBasicRelationship

            // Alternatively, you can create your own custom data types and use these types when calling into the APIs.
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

            Response<CustomRelationship> createCustomRelationshipResponse = await client
                .CreateOrReplaceRelationshipAsync<CustomRelationship>("floorTwinId", "floorBuildingRelationshipId", floorBuildingRelationshipPayload);
            Console.WriteLine($"Created a digital twin relationship '{createCustomRelationshipResponse.Value.Id}' " +
                $"from twin '{createCustomRelationshipResponse.Value.SourceId}' to twin '{createCustomRelationshipResponse.Value.TargetId}'.");

            #endregion Snippet:DigitalTwinsSampleCreateCustomRelationship

            // Getting a relationship as a custom data type is extremely easy.

            #region Snippet:DigitalTwinsSampleGetCustomRelationship

            Response<CustomRelationship> getCustomRelationshipResponse = await client.GetRelationshipAsync<CustomRelationship>(
                "floorTwinId",
                "floorBuildingRelationshipId");
            CustomRelationship getCustomRelationship = getCustomRelationshipResponse.Value;
            Console.WriteLine($"Retrieved and deserialized relationship '{getCustomRelationship.Id}' from twin '{getCustomRelationship.SourceId}'.\n\t" +
                $"Prop1: {getCustomRelationship.Prop1}\n\t" +
                $"Prop2: {getCustomRelationship.Prop2}");

            #endregion Snippet:DigitalTwinsSampleGetCustomRelationship

            // Get all relationships in the graph where buildingTwinId is the source of the relationship.

            #region Snippet:DigitalTwinsSampleGetAllRelationships

            AsyncPageable<BasicRelationship> relationships = client.GetRelationshipsAsync<BasicRelationship>("buildingTwinId");
            await foreach (BasicRelationship relationship in relationships)
            {
                Console.WriteLine($"Retrieved relationship '{relationship.Id}' with source {relationship.SourceId}' and " +
                    $"target {relationship.TargetId}.\n\t" +
                    $"Prop1: {relationship.Properties["Prop1"]}\n\t" +
                    $"Prop2: {relationship.Properties["Prop2"]}");
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
                await client.DeleteModelAsync(sampleBuildingModelId);
                await client.DeleteModelAsync(sampleFloorModelId);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete model due to {ex}.");
            }
        }
    }
}
