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
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    /// <summary>
    /// Operations for OAuth authorization.
    /// </summary>
    internal class OAuthOperations : IServiceOperations<DataFactoryManagementClient>, IOAuthOperations
    {
        public DataFactoryManagementClient Client { get; private set; }

        internal OAuthOperations(DataFactoryManagementClient client)
        {
            this.Client = client;
        }

        public async Task<AuthorizationSessionGetResponse> GetAsync(
            string resourceGroupName,
            string dataFactoryName,
            string linkedServiceType,
            CancellationToken cancellationToken)
        {
            return await this.Client.InternalClient.OAuth.GetAsync(
                resourceGroupName,
                dataFactoryName,
                linkedServiceType,
                cancellationToken);
        }
    }
}
