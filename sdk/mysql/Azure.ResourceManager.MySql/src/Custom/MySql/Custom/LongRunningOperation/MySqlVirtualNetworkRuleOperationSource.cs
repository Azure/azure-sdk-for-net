// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.MySql
{
    internal class MySqlVirtualNetworkRuleOperationSource : IOperationSource<MySqlVirtualNetworkRuleResource>
    {
        private readonly ArmClient _client;

        internal MySqlVirtualNetworkRuleOperationSource(ArmClient client)
        {
            _client = client;
        }

        MySqlVirtualNetworkRuleResource IOperationSource<MySqlVirtualNetworkRuleResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<MySqlVirtualNetworkRuleData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerMySqlContext.Default);
            return new MySqlVirtualNetworkRuleResource(_client, data);
        }

        async ValueTask<MySqlVirtualNetworkRuleResource> IOperationSource<MySqlVirtualNetworkRuleResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<MySqlVirtualNetworkRuleData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerMySqlContext.Default);
            return await Task.FromResult(new MySqlVirtualNetworkRuleResource(_client, data)).ConfigureAwait(false);
        }
    }
}