// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    internal class DistributedAvailabilityGroupOperationSource : IOperationSource<DistributedAvailabilityGroupResource>
    {
        private readonly ArmClient _client;

        internal DistributedAvailabilityGroupOperationSource(ArmClient client)
        {
            _client = client;
        }

        DistributedAvailabilityGroupResource IOperationSource<DistributedAvailabilityGroupResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<DistributedAvailabilityGroupData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerSqlContext.Default);
            return new DistributedAvailabilityGroupResource(_client, data);
        }

        async ValueTask<DistributedAvailabilityGroupResource> IOperationSource<DistributedAvailabilityGroupResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<DistributedAvailabilityGroupData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerSqlContext.Default);
            return await Task.FromResult(new DistributedAvailabilityGroupResource(_client, data)).ConfigureAwait(false);
        }
    }
}
