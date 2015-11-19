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
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Management.DataFactories
{
    public static class DatasetOperationsExtensions
    {
        /// <summary>
        /// Create a new Dataset instance or update an existing instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a Dataset.
        /// </param>
        /// <returns>
        /// The CreateOrUpdate Dataset operation response.
        /// </returns>
        public static DatasetCreateOrUpdateResponse BeginCreateOrUpdate(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            DatasetCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                    s => ((IDatasetOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, dataFactoryName, parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a new Dataset instance or update an existing instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a Dataset.
        /// </param>
        /// <returns>
        /// The CreateOrUpdate Dataset operation response.
        /// </returns>
        public static Task<DatasetCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            DatasetCreateOrUpdateParameters parameters)
        {
            return operations.BeginCreateOrUpdateAsync(
                resourceGroupName,
                dataFactoryName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Create a new Dataset instance or update an existing instance 
        /// with raw JSON content.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='datasetName'>
        /// Required. A unique Dataset instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a Dataset.
        /// </param>
        /// <returns>
        /// The CreateOrUpdate Dataset operation response.
        /// </returns>
        public static DatasetCreateOrUpdateResponse BeginCreateOrUpdateWithRawJsonContent(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string datasetName,
            DatasetCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return Task.Factory.StartNew(
                    s => ((IDatasetOperations)s).BeginCreateOrUpdateWithRawJsonContentAsync(
                        resourceGroupName,
                        dataFactoryName,
                        datasetName,
                        parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a new Dataset instance or update an existing instance 
        /// with raw JSON content.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='datasetName'>
        /// Required. A unique Dataset instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a Dataset.
        /// </param>
        /// <returns>
        /// The CreateOrUpdate Dataset operation response.
        /// </returns>
        public static Task<DatasetCreateOrUpdateResponse> BeginCreateOrUpdateWithRawJsonContentAsync(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string datasetName,
            DatasetCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return operations.BeginCreateOrUpdateWithRawJsonContentAsync(
                resourceGroupName,
                dataFactoryName,
                datasetName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Delete a Dataset instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='datasetName'>
        /// Required. Name of the Dataset.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse BeginDelete(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string datasetName)
        {
            return Task.Factory.StartNew(
                    s => ((IDatasetOperations)s).BeginDeleteAsync(resourceGroupName, dataFactoryName, datasetName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a Dataset instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='datasetName'>
        /// Required. Name of the Dataset.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> BeginDeleteAsync(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string datasetName)
        {
            return operations.BeginDeleteAsync(resourceGroupName, dataFactoryName, datasetName, CancellationToken.None);
        }

        /// <summary>
        /// Create a new Dataset instance or update an existing instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a Dataset.
        /// </param>
        /// <returns>
        /// The CreateOrUpdate Dataset operation response.
        /// </returns>
        public static DatasetCreateOrUpdateResponse CreateOrUpdate(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            DatasetCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                    s => ((IDatasetOperations)s).CreateOrUpdateAsync(resourceGroupName, dataFactoryName, parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a new Dataset instance or update an existing instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a Dataset.
        /// </param>
        /// <returns>
        /// The CreateOrUpdate Dataset operation response.
        /// </returns>
        public static Task<DatasetCreateOrUpdateResponse> CreateOrUpdateAsync(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            DatasetCreateOrUpdateParameters parameters)
        {
            return operations.CreateOrUpdateAsync(
                resourceGroupName,
                dataFactoryName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Create a new Dataset instance or update an existing instance with raw
        /// json content.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='datasetName'>
        /// Required. A unique Dataset instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a Dataset.
        /// </param>
        /// <returns>
        /// The CreateOrUpdate Dataset operation response.
        /// </returns>
        public static DatasetCreateOrUpdateResponse CreateOrUpdateWithRawJsonContent(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string datasetName,
            DatasetCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return Task.Factory.StartNew(
                    s => ((IDatasetOperations)s).CreateOrUpdateWithRawJsonContentAsync(
                        resourceGroupName,
                        dataFactoryName,
                        datasetName,
                        parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a new Dataset instance or update an existing instance with raw
        /// json content.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='datasetName'>
        /// Required. A unique Dataset instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a Dataset.
        /// </param>
        /// <returns>
        /// The CreateOrUpdate Dataset operation response.
        /// </returns>
        public static Task<DatasetCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string datasetName,
            DatasetCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return operations.CreateOrUpdateWithRawJsonContentAsync(
                resourceGroupName,
                dataFactoryName,
                datasetName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Delete a Dataset instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='datasetName'>
        /// Required. Name of the Dataset.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse Delete(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string datasetName)
        {
            return Task.Factory.StartNew(
                    s => ((IDatasetOperations)s).DeleteAsync(resourceGroupName, dataFactoryName, datasetName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a Dataset instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='datasetName'>
        /// Required. Name of the Dataset.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> DeleteAsync(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string datasetName)
        {
            return operations.DeleteAsync(resourceGroupName, dataFactoryName, datasetName, CancellationToken.None);
        }

        /// <summary>
        /// Gets a Dataset instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='datasetName'>
        /// Required. Name of the Dataset.
        /// </param>
        /// <returns>
        /// The Get Dataset operation response.
        /// </returns>
        public static DatasetGetResponse Get(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string datasetName)
        {
            return Task.Factory.StartNew(
                    s => ((IDatasetOperations)s).GetAsync(resourceGroupName, dataFactoryName, datasetName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a Dataset instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='datasetName'>
        /// Required. Name of the Dataset.
        /// </param>
        /// <returns>
        /// The Get Dataset operation response.
        /// </returns>
        public static Task<DatasetGetResponse> GetAsync(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string datasetName)
        {
            return operations.GetAsync(resourceGroupName, dataFactoryName, datasetName, CancellationToken.None);
        }

        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// The CreateOrUpdate Dataset operation response.
        /// </returns>
        public static DatasetCreateOrUpdateResponse GetCreateOrUpdateStatus(
            this IDatasetOperations operations,
            string operationStatusLink)
        {
            return Task.Factory.StartNew(
                    s => ((IDatasetOperations)s).GetCreateOrUpdateStatusAsync(operationStatusLink),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// The CreateOrUpdate Dataset operation response.
        /// </returns>
        public static Task<DatasetCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            this IDatasetOperations operations,
            string operationStatusLink)
        {
            return operations.GetCreateOrUpdateStatusAsync(operationStatusLink, CancellationToken.None);
        }

        /// <summary>
        /// Gets all the Dataset instances in a data factory with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <returns>
        /// The List Datasets operation response.
        /// </returns>
        public static DatasetListResponse List(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName)
        {
            return Task.Factory.StartNew(
                    s => ((IDatasetOperations)s).ListAsync(resourceGroupName, dataFactoryName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets all the Dataset instances in a data factory with the link to the
        /// next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <returns>
        /// The List Datasets operation response.
        /// </returns>
        public static Task<DatasetListResponse> ListAsync(
            this IDatasetOperations operations,
            string resourceGroupName,
            string dataFactoryName)
        {
            return operations.ListAsync(resourceGroupName, dataFactoryName, CancellationToken.None);
        }

        /// <summary>
        /// Gets the next page of Dataset instances with the link to the next
        /// page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next Datasets page.
        /// </param>
        /// <returns>
        /// The List Datasets operation response.
        /// </returns>
        public static DatasetListResponse ListNext(this IDatasetOperations operations, string nextLink)
        {
            return Task.Factory.StartNew(
                    s => ((IDatasetOperations)s).ListNextAsync(nextLink),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the next page of Dataset instances with the link to the next
        /// page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IDatasetOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next Datasets page.
        /// </param>
        /// <returns>
        /// The List Datasets operation response.
        /// </returns>
        public static Task<DatasetListResponse> ListNextAsync(this IDatasetOperations operations, string nextLink)
        {
            return operations.ListNextAsync(nextLink, CancellationToken.None);
        }
    }
}
