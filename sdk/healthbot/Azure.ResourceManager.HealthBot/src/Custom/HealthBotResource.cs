// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.HealthBot.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.HealthBot
{
    /// <summary>
    /// A Class representing a HealthBot along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="HealthBotResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetHealthBotResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetHealthBot method.
    /// </summary>
    public partial class HealthBotResource : ArmResource
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<HealthBotResource>> UpdateAsync(HealthBotPatch patch, CancellationToken cancellationToken = default)
        {
            var response = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value, response.GetRawResponse());
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HealthBotResource> Update(HealthBotPatch patch, CancellationToken cancellationToken = default)
        {
            var response = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(response.Value, response.GetRawResponse());
        }
    }
}
