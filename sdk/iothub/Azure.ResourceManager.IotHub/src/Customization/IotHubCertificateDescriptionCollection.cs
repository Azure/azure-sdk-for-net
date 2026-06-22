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
    // Certificate create/update also exposed If-Match as string in the previous GA surface. The TypeSpec
    // generated method correctly models the header as ETag, but keeping this adapter avoids a source
    // break for existing callers and keeps the compatibility behavior scoped to method overloads rather
    // than changing the generated model or REST operation.
    public partial class IotHubCertificateDescriptionCollection
    {
        public virtual async Task<ArmOperation<IotHubCertificateDescriptionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string certificateName, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, certificateName, data, ToETag(ifMatch), cancellationToken).ConfigureAwait(false);

        public virtual ArmOperation<IotHubCertificateDescriptionResource> CreateOrUpdate(WaitUntil waitUntil, string certificateName, IotHubCertificateDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, certificateName, data, ToETag(ifMatch), cancellationToken);

        private static ETag? ToETag(string value) => value is null ? default(ETag?) : new ETag(value);
    }
}

#pragma warning restore CS1591
