// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.MySql
{
    internal class MySqlServerAdministratorOperationSource : IOperationSource<MySqlServerAdministratorResource>
    {
        private readonly ArmClient _client;

        internal MySqlServerAdministratorOperationSource(ArmClient client)
        {
            _client = client;
        }

        MySqlServerAdministratorResource IOperationSource<MySqlServerAdministratorResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<MySqlServerAdministratorData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerMySqlContext.Default);
            return new MySqlServerAdministratorResource(_client, data);
        }

        async ValueTask<MySqlServerAdministratorResource> IOperationSource<MySqlServerAdministratorResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<MySqlServerAdministratorData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerMySqlContext.Default);
            return await Task.FromResult(new MySqlServerAdministratorResource(_client, data)).ConfigureAwait(false);
        }
    }
}