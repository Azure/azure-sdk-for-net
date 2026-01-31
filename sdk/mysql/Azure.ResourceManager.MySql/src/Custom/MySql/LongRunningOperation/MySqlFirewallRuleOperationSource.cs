// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.MySql
{
    internal class MySqlFirewallRuleOperationSource : IOperationSource<MySqlFirewallRuleResource>
    {
        private readonly ArmClient _client;

        internal MySqlFirewallRuleOperationSource(ArmClient client)
        {
            _client = client;
        }

        MySqlFirewallRuleResource IOperationSource<MySqlFirewallRuleResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<MySqlFirewallRuleData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerMySqlContext.Default);
            return new MySqlFirewallRuleResource(_client, data);
        }

        async ValueTask<MySqlFirewallRuleResource> IOperationSource<MySqlFirewallRuleResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<MySqlFirewallRuleData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerMySqlContext.Default);
            return await Task.FromResult(new MySqlFirewallRuleResource(_client, data)).ConfigureAwait(false);
        }
    }
}