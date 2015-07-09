// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
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
    /// Operations for managing pipelines.
    /// </summary>
    internal partial class PipelineOperations : IServiceOperations<DataFactoryManagementClient>, IPipelineOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal PipelineOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
            this.Converter = new PipelineConverter();
        }

        public async Task<PipelineCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            PipelineCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            Core.Models.PipelineCreateOrUpdateParameters internalParameters = this.ValidateAndConvert(parameters);

            Core.Models.PipelineCreateOrUpdateResponse response = 
                await this.Client.InternalClient.Pipelines.BeginCreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    internalParameters,
                    cancellationToken);

            return new PipelineCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<PipelineCreateOrUpdateResponse> BeginCreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            PipelineCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            Ensure.IsNotNull(parameters, "parameters");
            Ensure.IsNotNull(parameters.Content, "parameters.Content");

            var internalParameters =
                new Core.Models.PipelineCreateOrUpdateWithRawJsonContentParameters(parameters.Content);

            Core.Models.PipelineCreateOrUpdateResponse response =
                await this.Client.InternalClient.Pipelines.BeginCreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    dataPipelineName,
                    internalParameters,
                    cancellationToken);

            return new PipelineCreateOrUpdateResponse(response, this.Client); 
        }

        public async Task<LongRunningOperationResponse> BeginDeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Pipelines.BeginDeleteAsync(
                    resourceGroupName,
                    dataFactoryName,
                    dataPipelineName,
                    cancellationToken);
        }

        public async Task<PipelineCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            PipelineCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            Core.Models.PipelineCreateOrUpdateParameters internalParameters = this.ValidateAndConvert(parameters);

            Core.Models.PipelineCreateOrUpdateResponse response =
                await this.Client.InternalClient.Pipelines.CreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    internalParameters,
                    cancellationToken);

            return new PipelineCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<PipelineCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            PipelineCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            var internalParameters =
                new Core.Models.PipelineCreateOrUpdateWithRawJsonContentParameters(parameters.Content);

            Core.Models.PipelineCreateOrUpdateResponse response =
                await this.Client.InternalClient.Pipelines.CreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    dataPipelineName,
                    internalParameters,
                    cancellationToken);

            return new PipelineCreateOrUpdateResponse(response, this.Client);
        }

        public Task<LongRunningOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            CancellationToken cancellationToken)
        {
            return this.Client.InternalClient.Pipelines.DeleteAsync(
                resourceGroupName,
                dataFactoryName,
                dataPipelineName,
                cancellationToken);
        }

        public async Task<PipelineGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            CancellationToken cancellationToken)
        {
            Core.Models.PipelineGetResponse response =
                await this.Client.InternalClient.Pipelines.GetAsync(
                    resourceGroupName,
                    dataFactoryName,
                    dataPipelineName,
                    cancellationToken);

            return new PipelineGetResponse(response, this.Client);
        }

        public async Task<PipelineCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            string operationStatusLink,
            CancellationToken cancellationToken)
        {
            Ensure.IsNotNull(operationStatusLink, "operationStatusLink");

            Core.Models.PipelineCreateOrUpdateResponse internalResponse =
                await this.Client.InternalClient.Pipelines.GetCreateOrUpdateStatusAsync(
                    operationStatusLink,
                    cancellationToken);

            var response = new PipelineCreateOrUpdateResponse(internalResponse, this.Client);

            if (response.Pipeline != null && response.Pipeline.Properties != null
                && response.Pipeline.Properties.ProvisioningState != null)
            {
                response.Status = response.Pipeline.Properties.ProvisioningState.ToOperationStatus();
            }

            return response;
        }

        public async Task<PipelineListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            CancellationToken cancellationToken)
        {
            Core.Models.PipelineListResponse response =
                await this.Client.InternalClient.Pipelines.ListAsync(
                    resourceGroupName,
                    dataFactoryName,
                    cancellationToken);

            return new PipelineListResponse(response, this.Client);
        }

        public async Task<PipelineListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            // Validate
            Ensure.IsNotNull(nextLink, "nextLink");

            Core.Models.PipelineListResponse response =
                await this.Client.InternalClient.Pipelines.ListNextAsync(nextLink, cancellationToken);
            return new PipelineListResponse(response, this.Client); 
        }

        public async Task<AzureOperationResponse> ResumeAsync(
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Pipelines.ResumeAsync(
                resourceGroupName,
                dataFactoryName,
                dataPipelineName,
                cancellationToken);
        }

        public async Task<AzureOperationResponse> SuspendAsync(
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Pipelines.SuspendAsync(
                    resourceGroupName,
                    dataFactoryName,
                    dataPipelineName,
                    cancellationToken);
        }

        public async Task<AzureOperationResponse> SetActivePeriodAsync(
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            PipelineSetActivePeriodParameters parameters,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.Pipelines.SetActivePeriodAsync(
                    resourceGroupName,
                    dataFactoryName,
                    dataPipelineName,
                    parameters,
                    cancellationToken);
        }

        private Core.Models.PipelineCreateOrUpdateParameters ValidateAndConvert(PipelineCreateOrUpdateParameters parameters)
        {
            // Validate
            Ensure.IsNotNull(parameters, "parameters");
            Ensure.IsNotNull(parameters.Pipeline, "parameters.Pipeline");
            this.ValidateObject(parameters.Pipeline);

            // Convert
            Core.Models.Pipeline internalPipeline = this.Converter.ToCoreType(parameters.Pipeline);

            return new Core.Models.PipelineCreateOrUpdateParameters() { Pipeline = internalPipeline };
        }
    }
}
