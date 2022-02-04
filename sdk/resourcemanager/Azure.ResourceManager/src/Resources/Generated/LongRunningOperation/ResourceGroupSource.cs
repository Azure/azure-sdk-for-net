// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

internal class ResourceGroupSource : IOperationSource<ResourceGroup>
{
    private readonly ArmClient _client;

    internal ResourceGroupSource(ArmClient client)
    {
        _client = client;
    }

    ResourceGroup IOperationSource<ResourceGroup>.CreateResult(Response response, CancellationToken cancellationToken)
    {
        using var document = JsonDocument.Parse(response.ContentStream);
        var data = ResourceGroupData.DeserializeResourceGroupData(document.RootElement);
        return new ResourceGroup(_client, data);
    }

    async ValueTask<ResourceGroup> IOperationSource<ResourceGroup>.CreateResultAsync(Response response, CancellationToken cancellationToken)
    {
        using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
        var data = ResourceGroupData.DeserializeResourceGroupData(document.RootElement);
        return new ResourceGroup(_client, data);
    }
}
