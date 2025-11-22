// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.MySql
{
    internal class MySqlServerKeyOperationSource : IOperationSource<MySqlServerKeyResource>
    {
        private readonly ArmClient _client;

        internal MySqlServerKeyOperationSource(ArmClient client)
        {
            _client = client;
        }

        MySqlServerKeyResource IOperationSource<MySqlServerKeyResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<MySqlServerKeyData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerMySqlContext.Default);
            return new MySqlServerKeyResource(_client, data);
        }

        async ValueTask<MySqlServerKeyResource> IOperationSource<MySqlServerKeyResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<MySqlServerKeyData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerMySqlContext.Default);
            return await Task.FromResult(new MySqlServerKeyResource(_client, data)).ConfigureAwait(false);
        }
    }
}