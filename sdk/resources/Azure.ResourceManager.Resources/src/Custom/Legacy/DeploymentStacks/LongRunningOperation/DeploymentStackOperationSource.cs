// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Resources
{
    [Obsolete("Use Azure.ResourceManager.Resources.DeploymentStacks instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class DeploymentStackOperationSource : IOperationSource<DeploymentStackResource>
    {
        private readonly ArmClient _client;

        internal DeploymentStackOperationSource(ArmClient client)
        {
            _client = client;
        }

        DeploymentStackResource IOperationSource<DeploymentStackResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<DeploymentStackData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerResourcesContext.Default);
            return new DeploymentStackResource(_client, data);
        }

        async ValueTask<DeploymentStackResource> IOperationSource<DeploymentStackResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<DeploymentStackData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerResourcesContext.Default);
            return await Task.FromResult(new DeploymentStackResource(_client, data)).ConfigureAwait(false);
        }
    }
}
