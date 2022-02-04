// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

internal class GenericResourceSource : IOperationSource<GenericResource>
{
    private readonly ArmClient _client;

    internal GenericResourceSource(ArmClient client)
    {
        _client = client;
    }

    GenericResource IOperationSource<GenericResource>.CreateResult(Response response, CancellationToken cancellationToken)
    {
        using var document = JsonDocument.Parse(response.ContentStream);
        var data = GenericResourceData.DeserializeGenericResourceData(document.RootElement);
        return new GenericResource(_client, data);
    }

    async ValueTask<GenericResource> IOperationSource<GenericResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
    {
        using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
        var data = GenericResourceData.DeserializeGenericResourceData(document.RootElement);
        return new GenericResource(_client, data);
    }
}
