// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ServiceNetworking
{
    [Obsolete("This class is now deprecated.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class AssociationOperationSource : IOperationSource<AssociationResource>
    {
        private readonly ArmClient _client;

        internal AssociationOperationSource(ArmClient client)
        {
            _client = client;
        }

        AssociationResource IOperationSource<AssociationResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = AssociationData.DeserializeAssociationData(document.RootElement);
            return new AssociationResource(_client, data);
        }

        async ValueTask<AssociationResource> IOperationSource<AssociationResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = AssociationData.DeserializeAssociationData(document.RootElement);
            return new AssociationResource(_client, data);
        }
    }
}
