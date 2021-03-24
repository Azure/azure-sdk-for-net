// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    internal class UpdateResourceGroupOperation : ValueArmOperation<ResourceGroup>, IOperationSource<ResourceGroup>
    {
        private readonly ArmOperationHelpers<ResourceGroup> _operation;

        public UpdateResourceGroupOperation()
        {
        }

        ResourceGroup IOperationSource<ResourceGroup>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return ResourceGroup.DeserializeGalleryImage(document.RootElement);
        }

        async ValueTask<ResourceGroup> IOperationSource<ResourceGroup>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return ResourceGroup.DeserializeGalleryImage(document.RootElement);
        }
    }
}
