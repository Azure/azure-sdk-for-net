﻿// 
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
    public static class PipelineOperationsExtensions
    {
        /// <summary>
        /// Create or update a pipeline instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a pipeline.
        /// </param>
        /// <returns>
        /// The create or update pipeline operation response.
        /// </returns>
        public static PipelineCreateOrUpdateResponse BeginCreateOrUpdate(
            this IPipelineOperations operations, 
            string resourceGroupName,
            string dataFactoryName, 
            PipelineCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, dataFactoryName, parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update a pipeline instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a pipeline.
        /// </param>
        /// <returns>
        /// The create or update pipeline operation response.
        /// </returns>
        public static Task<PipelineCreateOrUpdateResponse> BeginCreateOrUpdateAsync(
            this IPipelineOperations operations, 
            string resourceGroupName, 
            string dataFactoryName,
            PipelineCreateOrUpdateParameters parameters)
        {
            return operations.BeginCreateOrUpdateAsync(
                resourceGroupName,
                dataFactoryName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Create a new pipeline instance with raw JSON content.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. A unique pipeline instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create a pipeline.
        /// </param>
        /// <returns>
        /// The create or update pipeline operation response.
        /// </returns>
        public static PipelineCreateOrUpdateResponse BeginCreateOrUpdateWithRawJsonContent(
            this IPipelineOperations operations, 
            string resourceGroupName,
            string dataFactoryName, 
            string dataPipelineName,
            PipelineCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).BeginCreateOrUpdateWithRawJsonContentAsync(
                        resourceGroupName,
                        dataFactoryName,
                        dataPipelineName,
                        parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a new pipeline instance with raw JSON content.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. A unique pipeline instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create a pipeline.
        /// </param>
        /// <returns>
        /// The create or update pipeline operation response.
        /// </returns>
        public static Task<PipelineCreateOrUpdateResponse> BeginCreateOrUpdateWithRawJsonContentAsync(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            PipelineCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return operations.BeginCreateOrUpdateWithRawJsonContentAsync(
                resourceGroupName,
                dataFactoryName,
                dataPipelineName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Delete a pipeline instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse BeginDelete(
            this IPipelineOperations operations, 
            string resourceGroupName, 
            string dataFactoryName,
            string dataPipelineName)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).BeginDeleteAsync(resourceGroupName, dataFactoryName, dataPipelineName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a pipeline instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> BeginDeleteAsync(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName)
        {
            return operations.BeginDeleteAsync(
                resourceGroupName,
                dataFactoryName,
                dataPipelineName,
                CancellationToken.None);
        }

        /// <summary>
        /// Create or update a pipeline instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a pipeline.
        /// </param>
        /// <returns>
        /// The create or update pipeline operation response.
        /// </returns>
        public static PipelineCreateOrUpdateResponse CreateOrUpdate(
            this IPipelineOperations operations, 
            string resourceGroupName, 
            string dataFactoryName, 
            PipelineCreateOrUpdateParameters parameters)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).CreateOrUpdateAsync(resourceGroupName, dataFactoryName, parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update a pipeline instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a pipeline.
        /// </param>
        /// <returns>
        /// The create or update pipeline operation response.
        /// </returns>
        public static Task<PipelineCreateOrUpdateResponse> CreateOrUpdateAsync(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            PipelineCreateOrUpdateParameters parameters)
        {
            return operations.CreateOrUpdateAsync(
                resourceGroupName,
                dataFactoryName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Create a new pipeline instance with raw JSON content.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. A unique pipeline instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a pipeline.
        /// </param>
        /// <returns>
        /// The create or update pipeline operation response.
        /// </returns>
        public static PipelineCreateOrUpdateResponse CreateOrUpdateWithRawJsonContent(
            this IPipelineOperations operations, 
            string resourceGroupName,
            string dataFactoryName, 
            string dataPipelineName, 
            PipelineCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).CreateOrUpdateWithRawJsonContentAsync(
                        resourceGroupName,
                        dataFactoryName,
                        dataPipelineName,
                        parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a new pipeline instance with raw JSON content.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. A unique pipeline instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to create or update a pipeline.
        /// </param>
        /// <returns>
        /// The create or update pipeline operation response.
        /// </returns>
        public static Task<PipelineCreateOrUpdateResponse> CreateOrUpdateWithRawJsonContentAsync(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            PipelineCreateOrUpdateWithRawJsonContentParameters parameters)
        {
            return operations.CreateOrUpdateWithRawJsonContentAsync(
                resourceGroupName,
                dataFactoryName,
                dataPipelineName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Delete a pipeline instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse Delete(
            this IPipelineOperations operations,
            string resourceGroupName, 
            string dataFactoryName, 
            string dataPipelineName)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).DeleteAsync(resourceGroupName, dataFactoryName, dataPipelineName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a pipeline instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> DeleteAsync(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName)
        {
            return operations.DeleteAsync(resourceGroupName, dataFactoryName, dataPipelineName, CancellationToken.None);
        }

        /// <summary>
        /// Gets a pipeline instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <returns>
        /// The Get pipeline operation response.
        /// </returns>
        public static PipelineGetResponse Get(
            this IPipelineOperations operations, 
            string resourceGroupName, 
            string dataFactoryName, 
            string dataPipelineName)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).GetAsync(resourceGroupName, dataFactoryName, dataPipelineName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a pipeline instance.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <returns>
        /// The Get pipeline operation response.
        /// </returns>
        public static Task<PipelineGetResponse> GetAsync(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName)
        {
            return operations.GetAsync(resourceGroupName, dataFactoryName, dataPipelineName, CancellationToken.None);
        }

        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// The create or update pipeline operation response.
        /// </returns>
        public static PipelineCreateOrUpdateResponse GetCreateOrUpdateStatus(this IPipelineOperations operations, string operationStatusLink)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).GetCreateOrUpdateStatusAsync(operationStatusLink),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// The create or update pipeline operation response.
        /// </returns>
        public static Task<PipelineCreateOrUpdateResponse> GetCreateOrUpdateStatusAsync(
            this IPipelineOperations operations,
            string operationStatusLink)
        {
            return operations.GetCreateOrUpdateStatusAsync(operationStatusLink, CancellationToken.None);
        }

        /// <summary>
        /// Gets the first page of pipeline instances with the link to the next
        /// page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <returns>
        /// The List pipeline operation response.
        /// </returns>
        public static PipelineListResponse List(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).ListAsync(resourceGroupName, dataFactoryName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the first page of pipeline instances with the link to the next
        /// page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <returns>
        /// The List pipeline operation response.
        /// </returns>
        public static Task<PipelineListResponse> ListAsync(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName)
        {
            return operations.ListAsync(resourceGroupName, dataFactoryName, CancellationToken.None);
        }

        /// <summary>
        /// Gets the next page of pipeline instances with the link to the next
        /// page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next pipelines page.
        /// </param>
        /// <returns>
        /// The List pipeline operation response.
        /// </returns>
        public static PipelineListResponse ListNext(this IPipelineOperations operations, string nextLink)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).ListNextAsync(nextLink),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the next page of pipeline instances with the link to the next
        /// page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The url to the next pipelines page.
        /// </param>
        /// <returns>
        /// The List pipeline operation response.
        /// </returns>
        public static Task<PipelineListResponse> ListNextAsync(this IPipelineOperations operations, string nextLink)
        {
            return operations.ListNextAsync(nextLink, CancellationToken.None);
        }

        /// <summary>
        /// Resume a suspended pipeline.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static AzureOperationResponse Resume(
            this IPipelineOperations operations, 
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).ResumeAsync(resourceGroupName, dataFactoryName, dataPipelineName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Resume a suspended pipeline.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<AzureOperationResponse> ResumeAsync(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName)
        {
            return operations.ResumeAsync(resourceGroupName, dataFactoryName, dataPipelineName, CancellationToken.None);
        }

        /// <summary>
        /// Sets the active period of a pipeline.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>ume
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters required to set the active period of a
        /// pipeline.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static AzureOperationResponse SetActivePeriod(
            this IPipelineOperations operations, 
            string resourceGroupName, 
            string dataFactoryName, 
            string dataPipelineName,
            PipelineSetActivePeriodParameters parameters)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).SetActivePeriodAsync(
                        resourceGroupName,
                        dataFactoryName,
                        dataPipelineName,
                        parameters),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sets the active period of a pipeline.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters required to set the active period of a
        /// pipeline.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<AzureOperationResponse> SetActivePeriodAsync(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName,
            PipelineSetActivePeriodParameters parameters)
        {
            return operations.SetActivePeriodAsync(
                resourceGroupName,
                dataFactoryName,
                dataPipelineName,
                parameters,
                CancellationToken.None);
        }

        /// <summary>
        /// Suspend a running pipeline.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static AzureOperationResponse Suspend(
            this IPipelineOperations operations, 
            string resourceGroupName, 
            string dataFactoryName, 
            string dataPipelineName)
        {
            return Task.Factory.StartNew(
                    s => ((IPipelineOperations)s).SuspendAsync(resourceGroupName, dataFactoryName, dataPipelineName),
                    operations,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Suspend a running pipeline.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.IPipelineOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='dataPipelineName'>
        /// Required. Name of the data pipeline.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public static Task<AzureOperationResponse> SuspendAsync(
            this IPipelineOperations operations,
            string resourceGroupName,
            string dataFactoryName,
            string dataPipelineName)
        {
            return operations.SuspendAsync(resourceGroupName, dataFactoryName, dataPipelineName, CancellationToken.None);
        }
    }
}
