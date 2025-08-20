// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    internal class SqlServerCommunicationLinkOperationSource : IOperationSource<SqlServerCommunicationLinkResource>
    {
        private readonly ArmClient _client;

        internal SqlServerCommunicationLinkOperationSource(ArmClient client)
        {
            _client = client;
        }

        SqlServerCommunicationLinkResource IOperationSource<SqlServerCommunicationLinkResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<SqlServerCommunicationLinkData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerSqlContext.Default);
            return new SqlServerCommunicationLinkResource(_client, data);
        }

        async ValueTask<SqlServerCommunicationLinkResource> IOperationSource<SqlServerCommunicationLinkResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<SqlServerCommunicationLinkData>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerSqlContext.Default);
            return await Task.FromResult(new SqlServerCommunicationLinkResource(_client, data)).ConfigureAwait(false);
        }
    }
}
