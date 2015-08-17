//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    /// <summary>
    /// Operations for managing Tables.
    /// </summary>
    internal partial class TableOperations : IServiceOperations<DataFactoryManagementClient>, ITableOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal TableOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
            this.Converter = new TableConverter();
        }

        public async Task<TableCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            TableCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            Core.Models.TableCreateOrUpdateParameters internalParameters = this.ValidateAndConvert(parameters);

            var response = await this.Client.InternalClient.Tables.BeginCreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    internalParameters,
                    cancellationToken);

            return new TableCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<TableCreateOrUpdateResponse> BeginCreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            TableCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            Ensure.IsNotNull(parameters, "parameters");
            Ensure.IsNotNull(parameters.Content, "parameters.Content");

            var internalParameters =
                new Core.Models.TableCreateOrUpdateWithRawJsonContentParameters(parameters.Content);

            Core.Models.TableCreateOrUpdateResponse response =
                await this.Client.InternalClient.Tables.BeginCreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    tableName,
                    internalParameters,
                    cancellationToken);

            return new TableCreateOrUpdateResponse(response, this.Client); 
        }

        public async Task<LongRunningOperationResponse> BeginDeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Tables.BeginDeleteAsync(
                    resourceGroupName,
                    dataFactoryName,
                    tableName,
                    cancellationToken);
        }

        public async Task<TableCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            TableCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            Core.Models.TableCreateOrUpdateParameters internalParameters = this.ValidateAndConvert(parameters);

            Core.Models.TableCreateOrUpdateResponse response =
                await this.Client.InternalClient.Tables.CreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    internalParameters,
                    cancellationToken);

            return new TableCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<TableCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            TableCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            var internalParameters = new Core.Models.TableCreateOrUpdateWithRawJsonContentParameters(parameters.Content);

            Core.Models.TableCreateOrUpdateResponse response =
                await this.Client.InternalClient.Tables.CreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    tableName,
                    internalParameters,
                    cancellationToken);

            return new TableCreateOrUpdateResponse(response, this.Client);
        }

        public Task<LongRunningOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            CancellationToken cancellationToken)
        {
            return this.Client.InternalClient.Tables.DeleteAsync(
                resourceGroupName,
                dataFactoryName,
                tableName,
                cancellationToken);
        }

        public async Task<TableGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            CancellationToken cancellationToken)
        {
            Core.Models.TableGetResponse response = await this.Client.InternalClient.Tables.GetAsync(
                    resourceGroupName,
                    dataFactoryName,
                    tableName,
                    cancellationToken);

            return new TableGetResponse(response, this.Client);
        }

        public async Task<TableCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            string operationStatusLink,
            CancellationToken cancellationToken)
        {
            Ensure.IsNotNull(operationStatusLink, "operationStatusLink");

            Core.Models.TableCreateOrUpdateResponse internalResponse =
                await this.Client.InternalClient.Tables.GetCreateOrUpdateStatusAsync(
                    operationStatusLink,
                    cancellationToken);

            var response = new TableCreateOrUpdateResponse(internalResponse, this.Client);

            if (internalResponse.Table != null && internalResponse.Table.Properties != null
                && internalResponse.Table.Properties.ProvisioningState != null)
            {
                response.Status = internalResponse.Table.Properties.ProvisioningState.ToOperationStatus();
            }

            return response;
        }

        public async Task<TableListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            CancellationToken cancellationToken)
        {
            Core.Models.TableListResponse response = await this.Client.InternalClient.Tables.ListAsync(
                    resourceGroupName,
                    dataFactoryName,
                    cancellationToken);

            return new TableListResponse(response, this.Client);
        }

        public async Task<TableListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            // Validate
            Ensure.IsNotNull(nextLink, "nextLink");

            Core.Models.TableListResponse response =
                await this.Client.InternalClient.Tables.ListNextAsync(nextLink, cancellationToken);
            return new TableListResponse(response, this.Client);
        }

        private Core.Models.TableCreateOrUpdateParameters ValidateAndConvert(TableCreateOrUpdateParameters parameters)
        {
            // Validate
            Ensure.IsNotNull(parameters, "parameters");
            Ensure.IsNotNull(parameters.Table, "parameters.Table");
            this.ValidateObject(parameters.Table);

            // Convert
            Core.Models.Table internalTable = this.Converter.ToCoreType(parameters.Table);

            return new Core.Models.TableCreateOrUpdateParameters() { Table = internalTable };
        }
    }
}
