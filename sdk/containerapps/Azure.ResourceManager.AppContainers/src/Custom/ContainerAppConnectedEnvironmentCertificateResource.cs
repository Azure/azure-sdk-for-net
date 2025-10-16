// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AppContainers.Models;

namespace Azure.ResourceManager.AppContainers
{
    public partial class ContainerAppConnectedEnvironmentCertificateResource
    {
        /// <summary>
        /// Patches a certificate. Currently only patching of tags is supported
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConnectedEnvironmentsCertificates_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerAppConnectedEnvironmentCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Properties of a certificate that need to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<Azure.ResourceManager.AppContainers.ContainerAppConnectedEnvironmentCertificateResource> Update(ContainerAppCertificatePatch patch, CancellationToken cancellationToken = default)
        {
            var lro = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(lro.Value, lro.GetRawResponse());
        }

        /// <summary>
        /// Patches a certificate. Currently only patching of tags is supported
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/connectedEnvironments/{connectedEnvironmentName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConnectedEnvironmentsCertificates_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-07-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ContainerAppConnectedEnvironmentCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Properties of a certificate that need to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<Azure.ResourceManager.AppContainers.ContainerAppConnectedEnvironmentCertificateResource>> UpdateAsync(ContainerAppCertificatePatch patch, CancellationToken cancellationToken = default)
        {
            var lro = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(lro.Value, lro.GetRawResponse());
        }
    }
}
