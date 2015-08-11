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
    /// Operations for managing data factory linkedServices.
    /// </summary>
    internal partial class LinkedServiceOperations : IServiceOperations<DataFactoryManagementClient>, ILinkedServiceOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        /// <summary>
        /// Initializes a new instance of the LinkedServiceOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the internal service client.
        /// </param>
        internal LinkedServiceOperations(DataFactoryManagementClient client) 
        {
            this.Client = client;
            this.Converter = new LinkedServiceConverter();
        } 
        
        public async Task<LinkedServiceCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            LinkedServiceCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            Core.Models.LinkedServiceCreateOrUpdateParameters internalParameters = this.ValidateAndConvert(parameters);
            
            Core.Models.LinkedServiceCreateOrUpdateResponse response =
                await this.Client.InternalClient.LinkedServices.BeginCreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    internalParameters,
                    cancellationToken);

            return new LinkedServiceCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<LinkedServiceCreateOrUpdateResponse> BeginCreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string linkedServiceName,
            LinkedServiceCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            Ensure.IsNotNull(parameters, "parameters");
            Ensure.IsNotNull(parameters.Content, "parameters.Content");

            var internalParameters =
                new Core.Models.LinkedServiceCreateOrUpdateWithRawJsonContentParameters(parameters.Content);

            Core.Models.LinkedServiceCreateOrUpdateResponse response =
                await this.Client.InternalClient.LinkedServices.BeginCreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    linkedServiceName,
                    internalParameters,
                    cancellationToken);

            return new LinkedServiceCreateOrUpdateResponse(response, this.Client);   
        }

        public async Task<LongRunningOperationResponse> BeginDeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string linkedServiceName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.LinkedServices.BeginDeleteAsync(
                resourceGroupName,
                dataFactoryName,
                linkedServiceName,
                cancellationToken);
        }

        public async Task<LinkedServiceCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            LinkedServiceCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            Core.Models.LinkedServiceCreateOrUpdateParameters internalParameters = this.ValidateAndConvert(parameters);

            Core.Models.LinkedServiceCreateOrUpdateResponse response =
                await this.Client.InternalClient.LinkedServices.CreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    internalParameters,
                    cancellationToken);

            return new LinkedServiceCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<LinkedServiceCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string linkedServiceName,
            LinkedServiceCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            var internalParameters =
                new Core.Models.LinkedServiceCreateOrUpdateWithRawJsonContentParameters(parameters.Content);

            Core.Models.LinkedServiceCreateOrUpdateResponse response =
                await this.Client.InternalClient.LinkedServices.CreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    linkedServiceName,
                    internalParameters,
                    cancellationToken);

            return new LinkedServiceCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<LongRunningOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string linkedServiceName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.LinkedServices.DeleteAsync(
                resourceGroupName,
                dataFactoryName,
                linkedServiceName,
                cancellationToken);
        }

        public async Task<LinkedServiceGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            string linkedServiceName,
            CancellationToken cancellationToken)
        {
            Core.Models.LinkedServiceGetResponse response =
                await this.Client.InternalClient.LinkedServices.GetAsync(
                    resourceGroupName,
                    dataFactoryName,
                    linkedServiceName,
                    cancellationToken);

            return new LinkedServiceGetResponse(response, this.Client);
        }

        public async Task<LinkedServiceCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            string operationStatusLink,
            CancellationToken cancellationToken)
        {
            Ensure.IsNotNull(operationStatusLink, "operationStatusLink");

            Core.Models.LinkedServiceCreateOrUpdateResponse internalResponse =
                await this.Client.InternalClient.LinkedServices.GetCreateOrUpdateStatusAsync(
                    operationStatusLink,
                    cancellationToken);

            var response = new LinkedServiceCreateOrUpdateResponse(internalResponse, this.Client);

            if (response.LinkedService != null && response.LinkedService.Properties != null
                && response.LinkedService.Properties.ProvisioningState != null)
            {
                response.Status = response.LinkedService.Properties.ProvisioningState.ToOperationStatus();
            }

            return response;
        }

        public async Task<LinkedServiceListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            CancellationToken cancellationToken)
        {
            Core.Models.LinkedServiceListResponse response = 
                await this.Client.InternalClient.LinkedServices.ListAsync(
                    resourceGroupName,
                    dataFactoryName,
                    cancellationToken);

            return new LinkedServiceListResponse(response, this.Client);
        }

        public async Task<LinkedServiceListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            // Validate
            Ensure.IsNotNull(nextLink, "nextLink");

            Core.Models.LinkedServiceListResponse response =
                await this.Client.InternalClient.LinkedServices.ListNextAsync(nextLink, cancellationToken);
            return new LinkedServiceListResponse(response, this.Client); 
        }

        private Core.Models.LinkedServiceCreateOrUpdateParameters ValidateAndConvert(LinkedServiceCreateOrUpdateParameters parameters)
        {
            // Validate
            Ensure.IsNotNull(parameters, "parameters");
            Ensure.IsNotNull(parameters.LinkedService, "parameters.LinkedService");
            this.ValidateObject(parameters.LinkedService);

            // Convert
            Core.Models.LinkedService internalLinkedService = this.Converter.ToCoreType(parameters.LinkedService);

            return new Core.Models.LinkedServiceCreateOrUpdateParameters() { LinkedService = internalLinkedService };
        }
    }
}