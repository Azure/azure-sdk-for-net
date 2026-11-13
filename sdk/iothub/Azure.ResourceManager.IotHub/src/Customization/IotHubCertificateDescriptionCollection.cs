// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // Certificate create/update also exposed If-Match as string in the previous GA surface. The TypeSpec
    // generated method correctly models the header as ETag, but keeping this adapter avoids a source
    // break for existing callers and keeps the compatibility behavior scoped to method overloads rather
    // than changing the generated model or REST operation.
    /// <summary>
    /// A class representing a collection of <see cref="IotHubCertificateDescriptionResource"/> and their operations.
    /// Each <see cref="IotHubCertificateDescriptionResource"/> in the collection will belong to the same instance of <see cref="IotHubDescriptionResource"/>.
    /// To get a <see cref="IotHubCertificateDescriptionCollection"/> instance call the GetIotHubCertificateDescriptions method from an instance of <see cref="IotHubDescriptionResource"/>.
    /// </summary>
    public partial class IotHubCertificateDescriptionCollection
    {
        /// <summary>
        /// Adds new or replaces existing certificate.
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
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="certificateName"> The name of the certificate. </param>
        /// <param name="data"> The certificate body. </param>
        /// <param name="ifMatch"> ETag of the Certificate. Do not specify for creating a brand new certificate. Required to update an existing certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<IotHubCertificateDescriptionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string certificateName, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, certificateName, data, ToETag(ifMatch), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Adds new or replaces existing certificate.
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
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="certificateName"> The name of the certificate. </param>
        /// <param name="data"> The certificate body. </param>
        /// <param name="ifMatch"> ETag of the Certificate. Do not specify for creating a brand new certificate. Required to update an existing certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<IotHubCertificateDescriptionResource> CreateOrUpdate(WaitUntil waitUntil, string certificateName, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, certificateName, data, ToETag(ifMatch), cancellationToken);

        private static ETag? ToETag(string value) => value is null ? default(ETag?) : new ETag(value);
    }
}
