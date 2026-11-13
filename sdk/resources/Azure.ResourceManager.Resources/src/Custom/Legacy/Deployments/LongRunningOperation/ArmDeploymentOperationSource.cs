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
    [Obsolete("Use Azure.ResourceManager.Resources.Deployments instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ArmDeploymentOperationSource : IOperationSource<ArmDeploymentResource>
    {
        private readonly ArmClient _client;

        internal ArmDeploymentOperationSource(ArmClient client)
        {
            _client = client;
        }

        ArmDeploymentResource IOperationSource<ArmDeploymentResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<ArmDeploymentData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerResourcesContext.Default);
            return new ArmDeploymentResource(_client, data);
        }

        async ValueTask<ArmDeploymentResource> IOperationSource<ArmDeploymentResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<ArmDeploymentData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerResourcesContext.Default);
            return await Task.FromResult(new ArmDeploymentResource(_client, data)).ConfigureAwait(false);
        }
    }
}
