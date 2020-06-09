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
            string newRelationshipPayload = SamplesConstants.TemporaryRelationsshipPayload
                .Replace(SamplesConstants.RelationshipId, relationshipId)
                .Replace(SamplesConstants.TargetId, targetDtId)
                .Replace(SamplesConstants.SourceId, sourceDtId);

            #region Snippet:DigitalTwinsSampleCreateRelationship

            Response<string> createRelationshipResponse = await client.CreateRelationshipAsync(sourceDtId, relationshipId, newRelationshipPayload);
            Console.WriteLine($"Created a digital twin relationship with Id {relationshipId} from digital twin with Id {sourceDtId} to digital twin with Id {targetDtId}. " +
                $"Response status: {createRelationshipResponse.GetRawResponse().Status}.");

            #endregion Snippet:DigitalTwinsSampleCreateRelationship
        }
    }
}
