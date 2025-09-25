// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.HealthBot.Models;

namespace Azure.ResourceManager.HealthBot
{
    // Add this method back due to breaking change: PATCH operation is now LRO
    public partial class HealthBotResource
    {
        /// <summary>
        /// Patch a HealthBot.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthBot/healthBots/{botName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bots_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-08-24</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="HealthBotResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The parameters to provide for the required Azure Health Bot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<HealthBotResource>> UpdateAsync(HealthBotPatch patch, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return operation.GetRawResponse() is Response rawResponse
                ? Response.FromValue(operation.Value, rawResponse)
                : throw new InvalidOperationException("Failed to get raw response.");
        }

        /// <summary>
        /// Patch a HealthBot.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HealthBot/healthBots/{botName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bots_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-08-24</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="HealthBotResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The parameters to provide for the required Azure Health Bot. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<HealthBotResource> Update(HealthBotPatch patch, CancellationToken cancellationToken = default)
        {
            var operation = Update(WaitUntil.Completed, patch, cancellationToken);
            return operation.GetRawResponse() is Response rawResponse
                ? Response.FromValue(operation.Value, rawResponse)
                : throw new InvalidOperationException("Failed to get raw response.");
        }
    }
}
