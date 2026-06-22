// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

#pragma warning disable CS1591 // Compatibility overloads mirror existing generated API documentation.

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // Certificate update on the resource type needs the same string If-Match compatibility as collection
    // create/update. The overload is intentionally implemented by converting to ETag and forwarding to the
    // generated method, which means future generator changes to polling, diagnostics, or request creation
    // are still picked up automatically.
    public partial class IotHubCertificateDescriptionResource
    {
        public virtual async Task<ArmOperation<IotHubCertificateDescriptionResource>> UpdateAsync(WaitUntil waitUntil, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, data, ToETag(ifMatch), cancellationToken).ConfigureAwait(false);

        public virtual ArmOperation<IotHubCertificateDescriptionResource> Update(WaitUntil waitUntil, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => Update(waitUntil, data, ToETag(ifMatch), cancellationToken);

        private static ETag? ToETag(string value) => value is null ? default(ETag?) : new ETag(value);
    }
}

#pragma warning restore CS1591
