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
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    public static partial class HubOperationsExtensions
    {
        /// <summary>
        /// Create a new hub instance or update an existing instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a hub.
        /// </param>
        /// <returns>
        /// The create or update hub operation response.
        /// </returns>
        public static HubCreateOrUpdateResponse BeginCreateOrUpdate(this IHubOperations operations, string resourceGroupName, string dataFactoryName, HubCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IHubOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, dataFactoryName, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Create a new hub instance or update an existing instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a hub.
        /// </param>
        /// <returns>
        /// The create or update hub operation response.
        /// </returns>
        public static Task<HubCreateOrUpdateResponse> BeginCreateOrUpdateAsync(this IHubOperations operations, string resourceGroupName, string dataFactoryName, HubCreateOrUpdateParameters parameters)
        {
            return operations.BeginCreateOrUpdateAsync(resourceGroupName, dataFactoryName, parameters, CancellationToken.None);
        }
        
        /// <summary>
        /// Delete a hub instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='hubName'>
        /// Required. The name of the hub.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse BeginDelete(this IHubOperations operations, string resourceGroupName, string dataFactoryName, string hubName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IHubOperations)s).BeginDeleteAsync(resourceGroupName, dataFactoryName, hubName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Delete a hub instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='hubName'>
        /// Required. The name of the hub.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> BeginDeleteAsync(this IHubOperations operations, string resourceGroupName, string dataFactoryName, string hubName)
        {
            return operations.BeginDeleteAsync(resourceGroupName, dataFactoryName, hubName, CancellationToken.None);
        }
        
        /// <summary>
        /// Create a new hub instance or update an existing instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a hub.
        /// </param>
        /// <returns>
        /// The create or update hub operation response.
        /// </returns>
        public static HubCreateOrUpdateResponse CreateOrUpdate(this IHubOperations operations, string resourceGroupName, string dataFactoryName, HubCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IHubOperations)s).CreateOrUpdateAsync(resourceGroupName, dataFactoryName, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Create a new hub instance or update an existing instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a hub.
        /// </param>
        /// <returns>
        /// The create or update hub operation response.
        /// </returns>
        public static Task<HubCreateOrUpdateResponse> CreateOrUpdateAsync(this IHubOperations operations, string resourceGroupName, string dataFactoryName, HubCreateOrUpdateParameters parameters)
        {
            return operations.CreateOrUpdateAsync(resourceGroupName, dataFactoryName, parameters, CancellationToken.None);
        }
        
        /// <summary>
        /// Create a new hub instance or update an existing instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='hubName'>
        /// Required. The name of the data factory hub to be created or updated.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a hub.
        /// </param>
        /// <returns>
        /// The create or update hub operation response.
        /// </returns>
        public static HubCreateOrUpdateResponse CreateOrUpdateWithRawJsonContent(this IHubOperations operations, string resourceGroupName, string dataFactoryName, string hubName, HubCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IHubOperations)s).CreateOrUpdateWithRawJsonContentAsync(resourceGroupName, dataFactoryName, hubName, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Create a new hub instance or update an existing instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='hubName'>
        /// Required. The name of the data factory hub to be created or updated.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a hub.
        /// </param>
        /// <returns>
        /// The create or update hub operation response.
        /// </returns>
        public static Task<HubCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(this IHubOperations operations, string resourceGroupName, string dataFactoryName, string hubName, HubCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return operations.CreateOrUpdateWithRawJsonContentAsync(resourceGroupName, dataFactoryName, hubName, parameters, CancellationToken.None);
        }
        
        /// <summary>
        /// Delete a hub instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='hubName'>
        /// Required. The name of the hub.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse Delete(this IHubOperations operations, string resourceGroupName, string dataFactoryName, string hubName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IHubOperations)s).DeleteAsync(resourceGroupName, dataFactoryName, hubName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Delete a hub instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='hubName'>
        /// Required. The name of the hub.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> DeleteAsync(this IHubOperations operations, string resourceGroupName, string dataFactoryName, string hubName)
        {
            return operations.DeleteAsync(resourceGroupName, dataFactoryName, hubName, CancellationToken.None);
        }
        
        /// <summary>
        /// Gets a hub instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='hubName'>
        /// Required. The name of the hub.
        /// </param>
        /// <returns>
        /// The get hub operation response.
        /// </returns>
        public static HubGetResponse Get(this IHubOperations operations, string resourceGroupName, string dataFactoryName, string hubName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IHubOperations)s).GetAsync(resourceGroupName, dataFactoryName, hubName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets a hub instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='hubName'>
        /// Required. The name of the hub.
        /// </param>
        /// <returns>
        /// The get hub operation response.
        /// </returns>
        public static Task<HubGetResponse> GetAsync(this IHubOperations operations, string resourceGroupName, string dataFactoryName, string hubName)
        {
            return operations.GetAsync(resourceGroupName, dataFactoryName, hubName, CancellationToken.None);
        }
        
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// The create or update hub operation response.
        /// </returns>
        public static HubCreateOrUpdateResponse GetCreateOrUpdateStatus(this IHubOperations operations, string operationStatusLink)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IHubOperations)s).GetCreateOrUpdateStatusAsync(operationStatusLink);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// The create or update hub operation response.
        /// </returns>
        public static Task<HubCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(this IHubOperations operations, string operationStatusLink)
        {
            return operations.GetCreateOrUpdateStatusAsync(operationStatusLink, CancellationToken.None);
        }
        
        /// <summary>
        /// Gets the first page of data factory hub instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <returns>
        /// The list hub operation response.
        /// </returns>
        public static HubListResponse List(this IHubOperations operations, string resourceGroupName, string dataFactoryName)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IHubOperations)s).ListAsync(resourceGroupName, dataFactoryName);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets the first page of data factory hub instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <returns>
        /// The list hub operation response.
        /// </returns>
        public static Task<HubListResponse> ListAsync(this IHubOperations operations, string resourceGroupName, string dataFactoryName)
        {
            return operations.ListAsync(resourceGroupName, dataFactoryName, CancellationToken.None);
        }
        
        /// <summary>
        /// Gets the next page of data factory hub instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next data factory hubs page.
        /// </param>
        /// <returns>
        /// The list hub operation response.
        /// </returns>
        public static HubListResponse ListNext(this IHubOperations operations, string nextLink)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IHubOperations)s).ListNextAsync(nextLink);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets the next page of data factory hub instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IHubOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next data factory hubs page.
        /// </param>
        /// <returns>
        /// The list hub operation response.
        /// </returns>
        public static Task<HubListResponse> ListNextAsync(this IHubOperations operations, string nextLink)
        {
            return operations.ListNextAsync(nextLink, CancellationToken.None);
        }
    }
}
