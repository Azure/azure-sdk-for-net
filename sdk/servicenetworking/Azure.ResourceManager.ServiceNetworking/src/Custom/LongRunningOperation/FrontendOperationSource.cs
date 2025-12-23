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
    internal class FrontendOperationSource : IOperationSource<FrontendResource>
    {
        private readonly ArmClient _client;

        internal FrontendOperationSource(ArmClient client)
        {
            _client = client;
        }

        FrontendResource IOperationSource<FrontendResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = FrontendData.DeserializeFrontendData(document.RootElement);
            return new FrontendResource(_client, data);
        }

        async ValueTask<FrontendResource> IOperationSource<FrontendResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = FrontendData.DeserializeFrontendData(document.RootElement);
            return new FrontendResource(_client, data);
        }
    }
}
