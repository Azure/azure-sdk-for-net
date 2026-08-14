// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.EdgeOrder.Models;

namespace Azure.ResourceManager.EdgeOrder
{
    // Manually add to maintain its backward compatibility
    public partial class EdgeOrderAddressResource
    {
        /// <summary>
        /// Updates the properties of an existing address.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses/{addressName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateAddress</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="EdgeOrderAddressResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Address update parameters from request body. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The patch will be performed only if the ETag of the job on the server matches this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<EdgeOrderAddressResource>> UpdateAsync(WaitUntil waitUntil, EdgeOrderAddressPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, patch, new ETag(ifMatch), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the properties of an existing address.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses/{addressName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>UpdateAddress</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="EdgeOrderAddressResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> Address update parameters from request body. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The patch will be performed only if the ETag of the job on the server matches this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<EdgeOrderAddressResource> Update(WaitUntil waitUntil, EdgeOrderAddressPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, patch, new ETag(ifMatch), cancellationToken);
        }
    }
}
