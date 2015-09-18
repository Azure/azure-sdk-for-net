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
    /// Operations for managing Datasets.
    /// </summary>
    internal partial class DatasetOperations : IServiceOperations<DataFactoryManagementClient>, IDatasetOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal DatasetOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
            this.Converter = new DatasetConverter();
        }

        public async Task<DatasetCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            DatasetCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            Core.Models.DatasetCreateOrUpdateParameters internalParameters = this.ValidateAndConvert(parameters);

            var response = await this.Client.InternalClient.Datasets.BeginCreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    internalParameters,
                    cancellationToken);

            return new DatasetCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<DatasetCreateOrUpdateResponse> BeginCreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string datasetName,
            DatasetCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            Ensure.IsNotNull(parameters, "parameters");
            Ensure.IsNotNull(parameters.Content, "parameters.Content");

            var internalParameters =
                new Core.Models.DatasetCreateOrUpdateWithRawJsonContentParameters(parameters.Content);

            Core.Models.DatasetCreateOrUpdateResponse response =
                await this.Client.InternalClient.Datasets.BeginCreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    datasetName,
                    internalParameters,
                    cancellationToken);

            return new DatasetCreateOrUpdateResponse(response, this.Client); 
        }

        public async Task<LongRunningOperationResponse> BeginDeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string datasetName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Datasets.BeginDeleteAsync(
                    resourceGroupName,
                    dataFactoryName,
                    datasetName,
                    cancellationToken);
        }

        public async Task<DatasetCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            DatasetCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            Core.Models.DatasetCreateOrUpdateParameters internalParameters = this.ValidateAndConvert(parameters);

            Core.Models.DatasetCreateOrUpdateResponse response =
                await this.Client.InternalClient.Datasets.CreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    internalParameters,
                    cancellationToken);

            return new DatasetCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<DatasetCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string datasetName,
            DatasetCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            var internalParameters = new Core.Models.DatasetCreateOrUpdateWithRawJsonContentParameters(parameters.Content);

            Core.Models.DatasetCreateOrUpdateResponse response =
                await this.Client.InternalClient.Datasets.CreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    datasetName,
                    internalParameters,
                    cancellationToken);

            return new DatasetCreateOrUpdateResponse(response, this.Client);
        }

        public Task<LongRunningOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string datasetName,
            CancellationToken cancellationToken)
        {
            return this.Client.InternalClient.Datasets.DeleteAsync(
                resourceGroupName,
                dataFactoryName,
                datasetName,
                cancellationToken);
        }

        public async Task<DatasetGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            string datasetName,
            CancellationToken cancellationToken)
        {
            Core.Models.DatasetGetResponse response = await this.Client.InternalClient.Datasets.GetAsync(
                    resourceGroupName,
                    dataFactoryName,
                    datasetName,
                    cancellationToken);

            return new DatasetGetResponse(response, this.Client);
        }

        public async Task<DatasetCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            string operationStatusLink,
            CancellationToken cancellationToken)
        {
            Ensure.IsNotNull(operationStatusLink, "operationStatusLink");

            Core.Models.DatasetCreateOrUpdateResponse internalResponse =
                await this.Client.InternalClient.Datasets.GetCreateOrUpdateStatusAsync(
                    operationStatusLink,
                    cancellationToken);

            var response = new DatasetCreateOrUpdateResponse(internalResponse, this.Client);

            if (internalResponse.Dataset != null && internalResponse.Dataset.Properties != null
                && internalResponse.Dataset.Properties.ProvisioningState != null)
            {
                response.Status = internalResponse.Dataset.Properties.ProvisioningState.ToOperationStatus();
            }

            return response;
        }

        public async Task<DatasetListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            CancellationToken cancellationToken)
        {
            Core.Models.DatasetListResponse response = await this.Client.InternalClient.Datasets.ListAsync(
                    resourceGroupName,
                    dataFactoryName,
                    cancellationToken);

            return new DatasetListResponse(response, this.Client);
        }

        public async Task<DatasetListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            // Validate
            Ensure.IsNotNull(nextLink, "nextLink");

            Core.Models.DatasetListResponse response =
                await this.Client.InternalClient.Datasets.ListNextAsync(nextLink, cancellationToken);
            return new DatasetListResponse(response, this.Client);
        }

        private Core.Models.DatasetCreateOrUpdateParameters ValidateAndConvert(DatasetCreateOrUpdateParameters parameters)
        {
            // Validate
            Ensure.IsNotNull(parameters, "parameters");
            Ensure.IsNotNull(parameters.Dataset, "parameters.Dataset");
            this.ValidateObject(parameters.Dataset);

            // Convert
            Core.Models.Dataset internalDataset = this.Converter.ToCoreType(parameters.Dataset);

            return new Core.Models.DatasetCreateOrUpdateParameters() { Dataset = internalDataset };
        }
    }
}
