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
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    /// <summary>
    /// Operations for managing data slices.
    /// </summary>
    internal class DataSliceOperations : IServiceOperations<DataFactoryManagementClient>, IDataSliceOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal DataSliceOperations(DataFactoryManagementClient client) 
        {
            this.Client = client;
        } 

        public async Task<DataSliceListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            DataSliceListParameters parameters,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.DataSlices.ListAsync(
                    resourceGroupName,
                    dataFactoryName,
                    tableName,
                    parameters,
                    cancellationToken);
        }

        public async Task<DataSliceListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.DataSlices.ListNextAsync(nextLink, cancellationToken);
        }

        public async Task<AzureOperationResponse> SetStatusAsync(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            DataSliceSetStatusParameters parameters,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.DataSlices.SetStatusAsync(
                    resourceGroupName,
                    dataFactoryName,
                    tableName,
                    parameters,
                    cancellationToken);
        }
    }
}