// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core.Models;
using Azure.DigitalTwins.Core.Serialization;
using static Azure.DigitalTwins.Core.Samples.SampleLogger;
using static Azure.DigitalTwins.Core.Samples.UniqueIdHelper;

namespace Azure.DigitalTwins.Core.Samples
{
    internal class RelationshipSamples
    {
        /// <summary>
        /// Creates source and target digital twins, and connect them with a relationship.
        /// </summary>
        public async Task RunSamplesAsync(DigitalTwinsClient client)
        {
            PrintHeader("RELATIONSHIP SAMPLE");

            // Create digital twin model to be used for the source and target digital twins.
            string modelId = await GetUniqueModelIdAsync(SamplesConstants.TemporaryModelPrefix, client);
            string modelPayload = SamplesConstants.TemporaryModelWithRelationshipPayload
                .Replace(SamplesConstants.ModelId, modelId)
                .Replace(SamplesConstants.RelationshipTargetModelId, modelId);

            Response<IReadOnlyList<Models.ModelData>> createModelsResponse = await client.CreateModelsAsync(
                new[]
                {
                    modelPayload
                });
            Console.WriteLine($"Created model with Id {modelId}. Response status: {createModelsResponse.GetRawResponse().Status}.");

            // Create a digital twin instance to be used as the source of the relationship.
            string sourceDtId = await GetUniqueTwinIdAsync(SamplesConstants.TemporaryTwinPrefix, client);
            var sourceBasicTwin = new BasicDigitalTwin
            {
                Id = sourceDtId,
                Metadata = { ModelId = modelId }
            };

            string sourceDtPayload = JsonSerializer.Serialize(sourceBasicTwin);
            Response<string> createSourceDtResponse = await client.CreateDigitalTwinAsync(sourceDtId, sourceDtPayload);
            Console.WriteLine($"Created a digital twin with Id {sourceDtId}. Response status: {createSourceDtResponse.GetRawResponse().Status}.");

            // Setup a digital twin instance to be used as the target of the relationship.
            string targetDtId = await GetUniqueTwinIdAsync(SamplesConstants.TemporaryTwinPrefix, client);
            var targetTwin = new BasicDigitalTwin
            {
                Id = targetDtId,
                Metadata = { ModelId = modelId }
            };

            string targetDtPayload = JsonSerializer.Serialize(targetTwin);
            Response<string> createTargetDtResponse = await client.CreateDigitalTwinAsync(targetDtId, targetDtPayload);
            Console.WriteLine($"Created a digital twin with Id {targetDtId}. Response status: {createTargetDtResponse.GetRawResponse().Status}.");

            // Setup a relationship between the source and target digital twins
            string relationshipId = await GetUniqueRelationshipIdAsync(sourceDtId, SamplesConstants.TemporaryRelationshipIdPrefix, client);

            #region Snippet:DigitalTwinsSampleCreateRelationship

            var basicRelationship = new BasicRelationship()
            {
                Id = relationshipId,
                TargetId = targetDtId,
                SourceId = sourceDtId,
                Name = "related"
            };

            string serializedRelationship = JsonSerializer.Serialize(basicRelationship);
            Response<string> createRelationshipResponse = await client.CreateRelationshipAsync(sourceDtId, relationshipId, serializedRelationship);
            Console.WriteLine($"Created a digital twin relationship with Id {relationshipId} from digital twin with Id {sourceDtId} to digital twin with Id {targetDtId}. " +
                $"Response status: {createRelationshipResponse.GetRawResponse().Status}.");

            #endregion Snippet:DigitalTwinsSampleCreateRelationship

            // Get all incoming relationships for a digital twin.
            #region Snippet:DigitalTwinsSampleGetIncomingRelationships

            AsyncPageable<IncomingRelationship> incomingRelationships = client.GetIncomingRelationshipsAsync(targetDtId);

            await foreach (IncomingRelationship incomingRelationship in incomingRelationships)
            {
                Console.WriteLine($"Found an incoming relationship with Id {incomingRelationship.RelationshipId} coming from a digital twin with Id {incomingRelationship.SourceId}.");
            }

            #endregion Snippet:DigitalTwinsSampleGetIncomingRelationships

            // Get all relationships in a digital twin graph.
            #region Snippet:DigitalTwinsSampleGetRelationships

            AsyncPageable<string> relationships = client.GetRelationshipsAsync(sourceDtId);

            await foreach (var relationshipJson in relationships)
            {
                BasicRelationship relationship = JsonSerializer.Deserialize<BasicRelationship>(relationshipJson);
                Console.WriteLine($"Found relationship with Id {relationship.Id} with a digital twin source Id {relationship.SourceId} and " +
                    $"a digital twin target Id {relationship.TargetId}.");
            }

            #endregion Snippet:DigitalTwinsSampleGetRelationships

            // Delete all relationships in a digital twin graph.
            #region Snippet:DigitalTwinsSampleDeleteAllRelationships

            AsyncPageable<string> relationshipsToDelete = client.GetRelationshipsAsync(sourceDtId);

            await foreach (var relationshipToDelete in relationshipsToDelete)
            {
                BasicRelationship relationship = JsonSerializer.Deserialize<BasicRelationship>(relationshipToDelete);
                Response deleteRelationshipResponse = await client.DeleteRelationshipAsync(relationship.SourceId, relationship.Id);
                Console.WriteLine($"Deleted relationship with Id {relationship.Id}. Status response: {deleteRelationshipResponse.Status}.");
            }

            #endregion Snippet:DigitalTwinsSampleDeleteAllRelationships

            // Clean up.
            try
            {
                await client.DeleteDigitalTwinAsync(sourceDtId);
                await client.DeleteDigitalTwinAsync(targetDtId);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete digital twin due to {ex}.");
            }

            try
            {
                await client.DeleteModelAsync(modelId);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to delete model due to {ex}.");
            }
        }
    }
}
