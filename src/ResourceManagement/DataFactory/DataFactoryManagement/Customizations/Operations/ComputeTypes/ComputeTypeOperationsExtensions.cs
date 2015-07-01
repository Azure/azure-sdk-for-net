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
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Registration.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    public static class ComputeTypeOperationsExtensions
    {
        /// <summary>
        /// Delete an ComputeType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='computeTypeName'>
        /// Required. The name of the computeType.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse BeginDelete(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string computeTypeName)
        {
            return Task.Factory.StartNew(
                s =>
                    ((IComputeTypeOperations)s).BeginDeleteAsync(resourceGroupName, dataFactoryName, computeTypeName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete an ComputeType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='computeTypeName'>
        /// Required. The name of the computeType.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> BeginDeleteAsync(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string computeTypeName)
        {
            return operations.BeginDeleteAsync(
                resourceGroupName,
                dataFactoryName,
                computeTypeName,
                CancellationToken.None);
        }

        /// <summary>
        /// Create or update an ComputeType.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update an
        /// ComputeType definition.
        /// </param>
        /// <returns>
        /// The create or update ComputeType operation response.
        /// </returns>
        public static ComputeTypeCreateOrUpdateResponse CreateOrUpdate(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                s =>
                    ((IComputeTypeOperations)s).CreateOrUpdateAsync(resourceGroupName, dataFactoryName, parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update an ComputeType.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update an
        /// ComputeType definition.
        /// </param>
        /// <returns>
        /// The create or update ComputeType operation response.
        /// </returns>
        public static Task<ComputeTypeCreateOrUpdateResponse> CreateOrUpdateAsync(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeCreateOrUpdateParameters parameters)
        {
            return operations.CreateOrUpdateAsync(
                resourceGroupName,
                dataFactoryName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Create or update an ComputeType.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='computeTypeName'>
        /// Required. An ComputeType name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update an
        /// ComputeType definition.
        /// </param>
        /// <returns>
        /// The create or update ComputeType operation response.
        /// </returns>
        public static ComputeTypeCreateOrUpdateResponse CreateOrUpdateWithRawJsonContent(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string computeTypeName,
            ComputeTypeCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return Task.Factory.StartNew(
                s =>
                    ((IComputeTypeOperations)s).CreateOrUpdateWithRawJsonContentAsync(
                        resourceGroupName,
                        dataFactoryName,
                        computeTypeName,
                        parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update an ComputeType.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='computeTypeName'>
        /// Required. An ComputeType name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update an
        /// ComputeType definition.
        /// </param>
        /// <returns>
        /// The create or update ComputeType operation response.
        /// </returns>
        public static Task<ComputeTypeCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string computeTypeName,
            ComputeTypeCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return operations.CreateOrUpdateWithRawJsonContentAsync(
                resourceGroupName,
                dataFactoryName,
                computeTypeName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Delete an ComputeType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='computeTypeName'>
        /// Required. The name of the computeType.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse Delete(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string computeTypeName)
        {
            return Task.Factory.StartNew(
                s => ((IComputeTypeOperations)s).DeleteAsync(resourceGroupName, dataFactoryName, computeTypeName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete an ComputeType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='computeTypeName'>
        /// Required. The name of the computeType.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> DeleteAsync(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string computeTypeName)
        {
            return operations.DeleteAsync(resourceGroupName, dataFactoryName, computeTypeName, CancellationToken.None);
        }

        /// <summary>
        /// Gets an ComputeType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters specifying how to get an ComputeType
        /// definition.
        /// </param>
        /// <returns>
        /// The Get ComputeType operation response.
        /// </returns>
        public static ComputeTypeGetResponse Get(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeGetParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IComputeTypeOperations)s).GetAsync(resourceGroupName, dataFactoryName, parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets an ComputeType instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters specifying how to get an ComputeType
        /// definition.
        /// </param>
        /// <returns>
        /// The Get ComputeType operation response.
        /// </returns>
        public static Task<ComputeTypeGetResponse> GetAsync(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeGetParameters parameters)
        {
            return operations.GetAsync(resourceGroupName, dataFactoryName, parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the first page of ComputeType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters specifying how to return a list of
        /// ComputeType definitions.
        /// </param>
        /// <returns>
        /// The List ComputeType operation response.
        /// </returns>
        public static ComputeTypeListResponse List(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeListParameters parameters)
        {
            return Task.Factory.StartNew(
                s => ((IComputeTypeOperations)s).ListAsync(resourceGroupName, dataFactoryName, parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the first page of ComputeType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. The name of the data factory.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters specifying how to return a list of
        /// ComputeType definitions.
        /// </param>
        /// <returns>
        /// The List ComputeType operation response.
        /// </returns>
        public static Task<ComputeTypeListResponse> ListAsync(
            this IComputeTypeOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            ComputeTypeListParameters parameters)
        {
            return operations.ListAsync(resourceGroupName, dataFactoryName, parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the next page of ComputeType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next ComputeTypes page.
        /// </param>
        /// <returns>
        /// The List ComputeType operation response.
        /// </returns>
        public static ComputeTypeListResponse ListNext(this IComputeTypeOperations operations, string nextLink)
        {
            return Task.Factory.StartNew(
                s => ((IComputeTypeOperations)s).ListNextAsync(nextLink),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the next page of ComputeType instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IComputeTypeOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next ComputeTypes page.
        /// </param>
        /// <returns>
        /// The List ComputeType operation response.
        /// </returns>
        public static Task<ComputeTypeListResponse> ListNextAsync(
            this IComputeTypeOperations operations,
            string nextLink)
        {
            return operations.ListNextAsync(nextLink, CancellationToken.None);
        }
    }
}
