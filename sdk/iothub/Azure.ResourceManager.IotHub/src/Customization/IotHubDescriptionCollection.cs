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
    // The generated ARM method uses Azure.Core.ETag for If-Match, which is the preferred Azure SDK type.
    // The previous GA IoT Hub package exposed the same header as string on hub create/update, so removing
    // the string overload would force existing callers to change source. This overload is a thin adapter:
    // it converts string to nullable ETag and delegates to generated code so request construction,
    // diagnostics, and long-running-operation handling stay centralized.
    public partial class IotHubDescriptionCollection
    {
        public virtual async Task<ArmOperation<IotHubDescriptionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string resourceName, IotHubDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, resourceName, data, ToETag(ifMatch), cancellationToken).ConfigureAwait(false);

        public virtual ArmOperation<IotHubDescriptionResource> CreateOrUpdate(WaitUntil waitUntil, string resourceName, IotHubDescriptionData data, string ifMatch, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, resourceName, data, ToETag(ifMatch), cancellationToken);

        private static ETag? ToETag(string value) => value is null ? default(ETag?) : new ETag(value);
    }
}

#pragma warning restore CS1591
