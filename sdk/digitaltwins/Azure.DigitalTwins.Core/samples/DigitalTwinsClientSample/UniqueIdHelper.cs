// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;

namespace Azure.DigitalTwins.Core.Samples
{
    internal static class UniqueIdHelper
    {
        private static readonly Random s_random = new Random();

        internal static async Task<string> GetUniqueModelIdAsync(string baseName, DigitalTwinsClient client)
        {
            return await GetUniqueIdAsync(baseName, (modelId) => client.GetModelAsync(modelId));
        }

        internal static async Task<string> GetUniqueTwinIdAsync(string baseName, DigitalTwinsClient client)
        {
            return await GetUniqueIdAsync(baseName, (twinId) => client.GetDigitalTwinAsync(twinId));
        }

        internal static async Task<string> GetUniqueRelationshipIdAsync(string twinId, string baseName, DigitalTwinsClient client)
        {
            return await GetUniqueIdWithinTwinAsync(twinId, baseName, (twinId, relationshipId) => client.GetRelationshipAsync(twinId, relationshipId));
        }

        private static async Task<string> GetUniqueIdAsync(string baseName, Func<string, Task> getResource)
        {
            const int maxAttempts = 10;
            const int maxVal = 10000;
            var id = $"{baseName}{s_random.Next(maxVal)}";

            for (int attemptsMade = 0; attemptsMade < maxAttempts; attemptsMade++)
            {
                try
                {
                    await getResource(id);
                }
                catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
                {
                    return id;
                }
                id = $"{baseName}{s_random.Next(maxVal)}";
            }

            throw new Exception($"Unique Id could not be found with base {baseName}");
        }

        private static async Task<string> GetUniqueIdWithinTwinAsync(string twinId, string baseName, Func<string, string, Task> getResource)
        {
            const int maxAttempts = 10;
            const int maxVal = 10000;
            var id = $"{baseName}{s_random.Next(maxVal)}";

            for (int attemptsMade = 0; attemptsMade < maxAttempts; attemptsMade++)
            {
                try
                {
                    await getResource(twinId, id);
                }
                catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
                {
                    return id;
                }
                id = $"{baseName}{s_random.Next(maxVal)}";
            }

            throw new Exception($"Unique Id within a twin could not be found with base {baseName}");
        }
    }
}
