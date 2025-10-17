// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ContainerRegistry
{
    internal class ContainerRegistryRunOperationSource : IOperationSource<ContainerRegistryRunResource>
    {
        private readonly ArmClient _client;

        internal ContainerRegistryRunOperationSource(ArmClient client)
        {
            _client = client;
        }

        ContainerRegistryRunResource IOperationSource<ContainerRegistryRunResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<ContainerRegistryRunData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerContainerRegistryContext.Default);
            return new ContainerRegistryRunResource(_client, data);
        }

        async ValueTask<ContainerRegistryRunResource> IOperationSource<ContainerRegistryRunResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<ContainerRegistryRunData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerContainerRegistryContext.Default);
            return await Task.FromResult(new ContainerRegistryRunResource(_client, data)).ConfigureAwait(false);
        }
    }
}
