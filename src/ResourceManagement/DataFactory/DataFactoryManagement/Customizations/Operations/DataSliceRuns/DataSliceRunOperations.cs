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
    /// Operations for managing data slice runs.
    /// </summary>
    internal class DataSliceRunOperations : IServiceOperations<DataFactoryManagementClient>, IDataSliceRunOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal DataSliceRunOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
        }

        public async Task<DataSliceRunGetLogsResponse> GetLogsAsync(
            string resourceGroupName,
            string dataFactoryName,
            string dataSliceRunId,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.DataSliceRuns.GetLogsAsync(
                resourceGroupName,
                dataFactoryName,
                dataSliceRunId,
                cancellationToken);
        }

        public async Task<DataSliceRunListResponse> ListAsync(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            DataSliceRunListParameters parameters,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.DataSliceRuns.ListAsync(
                resourceGroupName,
                dataFactoryName,
                tableName,
                parameters,
                cancellationToken);
        }

        public async Task<DataSliceRunListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.DataSliceRuns.ListNextAsync(nextLink, cancellationToken);
        }

        public async Task<DataSliceRunGetResponse> GetAsync(string resourceGroupName, string dataFactoryName, string runId, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.DataSliceRuns.GetAsync(resourceGroupName, 
                dataFactoryName, 
                runId, 
                cancellationToken);
        }
    }
}
