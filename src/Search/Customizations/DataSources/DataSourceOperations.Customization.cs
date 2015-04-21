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

using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;

namespace Microsoft.Azure.Search
{
    internal partial class DataSourceOperations
    {
        public async Task<bool> ExistsAsync(string dataSourceName, CancellationToken cancellationToken)
        {
            try
            {
                // Get validates dataSourceName.
                await GetAsync(dataSourceName, cancellationToken);
                return true;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }
    }
}
