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
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.Azure.Management.DataFactories.Registration.Models;

namespace Microsoft.Azure.Management.DataFactories
{
#if ADF_INTERNAL
    public class ComputeTypeOperations : IServiceOperations<DataFactoryManagementClient>, 
                                         IComputeTypeOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal ComputeTypeConverter Converter { get; private set; }

        internal ComputeTypeOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
            this.Converter = new ComputeTypeConverter();
        }

        public async Task<LongRunningOperationResponse> BeginDeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string computeTypeName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.InternalComputeTypes.BeginDeleteAsync(
                    resourceGroupName,
                    dataFactoryName,
                    computeTypeName,
                    cancellationToken);
        }

        public async Task<ComputeTypeCreateOrUpdateResponse> CreateOrUpdateAsync(
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeCreateOrUpdateParameters parameters,
            CancellationToken cancellationToken)
        {
            Ensure.IsNotNull(parameters, "parameters");
            Ensure.IsNotNull(parameters.ComputeType, "parameters.ComputeType");

            InternalComputeType internalComputeType = this.Converter.ToCoreType(parameters.ComputeType);

            InternalComputeTypeCreateOrUpdateResponse response =
                await this.Client.InternalClient.InternalComputeTypes.CreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    new InternalComputeTypeCreateOrUpdateParameters(internalComputeType));

            return new ComputeTypeCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<ComputeTypeCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            string resourceGroupName,
            string dataFactoryName,
            string computeTypeName,
            ComputeTypeCreateOrUpdateWithRawJsonContentParameters parameters,
            CancellationToken cancellationToken)
        {
            InternalComputeTypeCreateOrUpdateResponse response = 
                await this.Client.InternalClient.InternalComputeTypes.CreateOrUpdateWithRawJsonContentAsync(
                    resourceGroupName,
                    dataFactoryName,
                    computeTypeName,
                    parameters,
                    cancellationToken);

            return new ComputeTypeCreateOrUpdateResponse(response, this.Client);
        }

        public async Task<LongRunningOperationResponse> DeleteAsync(
            string resourceGroupName,
            string dataFactoryName,
            string computeTypeName,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.InternalComputeTypes.DeleteAsync(
                    resourceGroupName,
                    dataFactoryName,
                    computeTypeName,
                    cancellationToken);
        }

        public async Task<ComputeTypeGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeGetParameters parameters,
            CancellationToken cancellationToken)
        {
            InternalComputeTypeGetResponse response =
                await this.Client.InternalClient.InternalComputeTypes.GetAsync(
                    resourceGroupName,
                    dataFactoryName,
                    parameters,
                    cancellationToken);

            return new ComputeTypeGetResponse(response, this.Client);
        }

        public async Task<ComputeTypeListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeListParameters parameters,
            CancellationToken cancellationToken)
        {
            InternalComputeTypeListResponse response =
                await this.Client.InternalClient.InternalComputeTypes.ListAsync(
                    resourceGroupName,
                    dataFactoryName,
                    parameters,
                    cancellationToken);

            return new ComputeTypeListResponse(response, this.Client);
        }

        public async Task<ComputeTypeListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            // Validate
            Ensure.IsNotNull(nextLink, "nextLink");

            InternalComputeTypeListResponse response =
                await this.Client.InternalClient.InternalComputeTypes.ListNextAsync(nextLink, cancellationToken);

            return new ComputeTypeListResponse(response, this.Client);
        }
    }
#endif
}
