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


using Hyak.Common;
using Microsoft.Azure.Management.DataFactories.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataFactories
{
    internal class ActivityWindowOperations : IServiceOperations<DataFactoryManagementClient>, IActivityWindowOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal ActivityWindowOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
        }

        public async Task<ActivityWindowListResponse> ListAsync(ActivityWindowsByDataFactoryListParameters parameters, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.ActivityWindows.ListByDataFactoryAsync(parameters, cancellationToken);
        }

        public async Task<ActivityWindowListResponse> ListAsync(ActivityWindowsByDatasetListParameters parameters, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.ActivityWindows.ListByDatasetAsync(parameters, cancellationToken);
        }

        public async Task<ActivityWindowListResponse> ListAsync(ActivityWindowsByPipelineListParameters parameters, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.ActivityWindows.ListByPipelineAsync(parameters, cancellationToken);
        }

        public async Task<ActivityWindowListResponse> ListAsync(ActivityWindowsByActivityListParameters parameters, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.ActivityWindows.ListByPipelineActivityAsync(parameters, cancellationToken);
        }

        public async Task<ActivityWindowListResponse> ListNextAsync(string nextLink, ActivityWindowsByDataFactoryListParameters parameters, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.ActivityWindows.ListNextByDataFactoryAsync(nextLink, parameters, cancellationToken);
        }

        public async Task<ActivityWindowListResponse> ListNextAsync(string nextLink, ActivityWindowsByDatasetListParameters parameters, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.ActivityWindows.ListNextByDatasetAsync(nextLink, parameters, cancellationToken);
        }

        public async Task<ActivityWindowListResponse> ListNextAsync(string nextLink, ActivityWindowsByPipelineListParameters parameters, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.ActivityWindows.ListNextByPipelineAsync(nextLink, parameters, cancellationToken);
        }

        public async Task<ActivityWindowListResponse> ListNextAsync(string nextLink, ActivityWindowsByActivityListParameters parameters, CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.ActivityWindows.ListNextByPipelineActivityAsync(nextLink, parameters, cancellationToken);
        }
    }
}
