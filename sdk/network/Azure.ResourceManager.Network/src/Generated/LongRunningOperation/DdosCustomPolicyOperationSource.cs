// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    internal class DdosCustomPolicyOperationSource : IOperationSource<DdosCustomPolicyResource>
    {
        private readonly ArmClient _client;

        internal DdosCustomPolicyOperationSource(ArmClient client)
        {
            _client = client;
        }

        DdosCustomPolicyResource IOperationSource<DdosCustomPolicyResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<DdosCustomPolicyData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
            return new DdosCustomPolicyResource(_client, data);
        }

        async ValueTask<DdosCustomPolicyResource> IOperationSource<DdosCustomPolicyResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<DdosCustomPolicyData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerNetworkContext.Default);
            return await Task.FromResult(new DdosCustomPolicyResource(_client, data)).ConfigureAwait(false);
        }
    }
}
