// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // Certificate update on the resource type needs the same string If-Match compatibility as collection
    // create/update. The overload is intentionally implemented by converting to ETag and forwarding to the
    // generated method, which means future generator changes to polling, diagnostics, or request creation
    // are still picked up automatically.
    /// <summary>
    /// A class representing a IotHubCertificateDescription along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="IotHubCertificateDescriptionResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource <see cref="IotHubDescriptionResource"/> using the GetIotHubCertificateDescriptions method.
    /// </summary>
    public partial class IotHubCertificateDescriptionResource
    {
        /// <summary>
        /// Update a IotHubCertificateDescription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CertificateDescriptions_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="IotHubCertificateDescriptionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The certificate body. </param>
        /// <param name="ifMatch"> ETag of the Certificate. Do not specify for creating a brand new certificate. Required to update an existing certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<IotHubCertificateDescriptionResource>> UpdateAsync(WaitUntil waitUntil, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, data, ToETag(ifMatch), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update a IotHubCertificateDescription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}/certificates/{certificateName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CertificateDescriptions_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-03-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="IotHubCertificateDescriptionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The certificate body. </param>
        /// <param name="ifMatch"> ETag of the Certificate. Do not specify for creating a brand new certificate. Required to update an existing certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<IotHubCertificateDescriptionResource> Update(WaitUntil waitUntil, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => Update(waitUntil, data, ToETag(ifMatch), cancellationToken);

        private static ETag? ToETag(string value) => value is null ? default(ETag?) : new ETag(value);
    }
}
