// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices
{
    public partial class CognitiveServicesProjectResource : ArmResource
    {
        // This method is used to support the mitigation solution of using a single data model for both CapabilityHost and ProjectCapabilityHost resources.
        /// <summary> Gets a collection of CognitiveServicesProjectCapabilityHostResources in the CognitiveServicesProject. </summary>
        /// <returns> An object representing collection of CognitiveServicesProjectCapabilityHostResources and their operations over a CognitiveServicesProjectCapabilityHostResource. </returns>
        public virtual CognitiveServicesProjectCapabilityHostCollection GetCognitiveServicesProjectCapabilityHosts()
        {
            return GetCachedClient(client => new CognitiveServicesProjectCapabilityHostCollection(client, Id));
        }

        // This method is used to support the mitigation solution of using a single data model for both CapabilityHost and ProjectCapabilityHost resources.
        /// <summary>
        /// Get project capabilityHost.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProjectCapabilityHosts_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CognitiveServicesProjectCapabilityHostResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityHostName"> The name of the capability host associated with the Cognitive Services Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityHostName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="capabilityHostName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<CognitiveServicesProjectCapabilityHostResource>> GetCognitiveServicesProjectCapabilityHostAsync(string capabilityHostName, CancellationToken cancellationToken = default)
        {
            return await GetCognitiveServicesProjectCapabilityHosts().GetAsync(capabilityHostName, cancellationToken).ConfigureAwait(false);
        }

        // This method is used to support the mitigation solution of using a single data model for both CapabilityHost and ProjectCapabilityHost resources.
        /// <summary>
        /// Get project capabilityHost.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{accountName}/projects/{projectName}/capabilityHosts/{capabilityHostName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProjectCapabilityHosts_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CognitiveServicesProjectCapabilityHostResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="capabilityHostName"> The name of the capability host associated with the Cognitive Services Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityHostName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="capabilityHostName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<CognitiveServicesProjectCapabilityHostResource> GetCognitiveServicesProjectCapabilityHost(string capabilityHostName, CancellationToken cancellationToken = default)
        {
            return GetCognitiveServicesProjectCapabilityHosts().Get(capabilityHostName, cancellationToken);
        }
    }
}
