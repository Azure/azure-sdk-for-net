// -----------------------------------------------------------------------------------------
// <copyright file="CloudTable.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using Windows.Foundation;

    /// <summary>
    /// Represents a Windows Azure Table.
    /// </summary>
    public sealed partial class CloudTable
    {
        #region TableOperation Execute Methods
        /// <summary>
        /// Executes the operation on a table.
        /// </summary>
        /// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
        /// <returns>A <see cref="TableResult"/> containing the result of executing the operation on the table.</returns>
        public IAsyncOperation<TableResult> ExecuteAsync(TableOperation operation)
        {
            return this.ExecuteAsync(operation, null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Executes the operation on a table, using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>.
        /// </summary>
        /// <param name="operation">A <see cref="TableOperation"/> object that represents the operation to perform.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="TableResult"/> containing the result of executing the operation on the table.</returns>
        public IAsyncOperation<TableResult> ExecuteAsync(TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNull("operation", operation);

            return operation.ExecuteAsync(this.ServiceClient, this.Name, requestOptions, operationContext);
        }
        #endregion

        #region TableBatchOperation Execute Methods
        /// <summary>
        /// Executes a batch operation on a table as an atomic operation.
        /// </summary>
        /// <param name="batch">The <see cref="TableBatchOperation"/> object representing the operations to execute on the table.</param>
        /// <returns>An enumerable collection of <see cref="TableResult"/> objects that contains the results, in order, of each operation in the <see cref="TableBatchOperation"/> on the table.</returns>
        public IAsyncOperation<IList<TableResult>> ExecuteBatchAsync(TableBatchOperation batch)
        {
            return this.ExecuteBatchAsync(batch, null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Executes a batch operation on a table as an atomic operation, using the specified <see cref="TableRequestOptions"/> and <see cref="OperationContext"/>.
        /// </summary>
        /// <param name="batch">The <see cref="TableBatchOperation"/> object representing the operations to execute on the table.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>An enumerable collection of <see cref="TableResult"/> objects that contains the results, in order, of each operation in the <see cref="TableBatchOperation"/> on the table.</returns>
        public IAsyncOperation<IList<TableResult>> ExecuteBatchAsync(TableBatchOperation batch, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNull("batch", batch);
            return batch.ExecuteAsync(this.ServiceClient, this.Name, requestOptions, operationContext);
        }
        #endregion

        #region TableQuery Execute Methods
        internal IEnumerable<DynamicTableEntity> ExecuteQuery(TableQuery query)
        {
            return this.ExecuteQuery(query, null /* RequestOptions */, null /* OperationContext */);
        }

        internal IEnumerable<DynamicTableEntity> ExecuteQuery(TableQuery query, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNull("query", query);
            return query.Execute(this.ServiceClient, this.Name, requestOptions, operationContext);
        }

        /// <summary>
        /// Executes a query in segmented mode with the specified <see cref="TableContinuationToken"/> continuation token.
        /// </summary>
        /// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
        /// <param name="token">A <see cref="ResultContinuation"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <returns>A <see cref="TableQuerySegment"/> object containing the results of executing the query.</returns>        
        public IAsyncOperation<TableQuerySegment> ExecuteQuerySegmentedAsync(TableQuery query, TableContinuationToken token)
        {
            return this.ExecuteQuerySegmentedAsync(query, token, null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Executes a query in segmented mode with the specified <see cref="TableContinuationToken"/> continuation token, <see cref="TableRequestOptions"/>, and <see cref="OperationContext"/>.
        /// </summary>
        /// <param name="query">A <see cref="TableQuery"/> representing the query to execute.</param>
        /// <param name="token">A <see cref="ResultContinuation"/> object representing a continuation token from the server when the operation returns a partial result.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A <see cref="TableQuerySegment"/> object containing the results of executing the query.</returns>        
        public IAsyncOperation<TableQuerySegment> ExecuteQuerySegmentedAsync(TableQuery query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNull("query", query);
            return query.ExecuteQuerySegmentedAsync(token, this.ServiceClient, this.Name, requestOptions, operationContext);
        }

        #endregion

        #region Create

        /// <summary>
        /// Creates the Table.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        public IAsyncAction CreateAsync()
        {
            return this.CreateAsync(null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Creates the Table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        public IAsyncAction CreateAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            DynamicTableEntity tblEntity = new DynamicTableEntity();
            tblEntity.Properties.Add(TableConstants.TableName, new EntityProperty(this.Name));
            TableOperation operation = new TableOperation(tblEntity, TableOperationType.Insert);
            operation.IsTableEntity = true;

            return this.ServiceClient.ExecuteAsync(TableConstants.TableServiceTablesName, operation, requestOptions, operationContext).AsTask().AsAsyncAction();
        }

        #endregion

        #region CreateIfNotExists

        /// <summary>
        /// Creates the table if it does not already exist.
        /// </summary>
        /// <returns><c>true</c> if table was created; otherwise, <c>false</c>.</returns>
        public IAsyncOperation<bool> CreateIfNotExistsAsync()
        {
            return this.CreateIfNotExistsAsync(null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Creates the table if it does not already exist.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>        
        /// <returns><c>true</c> if table was created; otherwise, <c>false</c>.</returns>
        public IAsyncOperation<bool> CreateIfNotExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (cancellationToken) =>
            {
                if (await this.ExistsAsync(requestOptions, operationContext).AsTask(cancellationToken))
                {
                    return false;
                }
                else
                {
                    try
                    {
                        await this.CreateAsync(requestOptions, operationContext).AsTask(cancellationToken);
                        return true;
                    }
                    catch (Exception)
                    {
                        StorageExtendedErrorInformation extendedInfo = operationContext.LastResult.ExtendedErrorInformation;
                        if (extendedInfo != null && extendedInfo.ErrorCode == TableErrorCodeStrings.TableNotFound)
                        {
                            return false;
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            });
        }
        #endregion

        #region Delete

        /// <summary>
        /// Deletes the Table.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        public IAsyncAction DeleteAsync()
        {
            return this.DeleteAsync(null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Deletes the Table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        public IAsyncAction DeleteAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            DynamicTableEntity tblEntity = new DynamicTableEntity();
            tblEntity.Properties.Add(TableConstants.TableName, new EntityProperty(this.Name));
            TableOperation operation = new TableOperation(tblEntity, TableOperationType.Delete);
            operation.IsTableEntity = true;

            return this.ServiceClient.ExecuteAsync(TableConstants.TableServiceTablesName, operation, requestOptions, operationContext).AsTask().AsAsyncAction();
        }
        #endregion

        #region DeleteIfExists

        /// <summary>
        /// Deletes the table if it already exists.
        /// </summary>
        /// <returns><c>true</c> if the table already existed and was deleted; otherwise, <c>false</c>.</returns>
        public IAsyncOperation<bool> DeleteIfExistsAsync()
        {
            return this.DeleteIfExistsAsync(null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Deletes the table if it already exists.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns><c>true</c> if the table already existed and was deleted; otherwise, <c>false</c>.</returns>
        public IAsyncOperation<bool> DeleteIfExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (cancellationToken) =>
            {
                if (!await this.ExistsAsync(requestOptions, operationContext).AsTask(cancellationToken))
                {
                    return false;
                }
                else
                {
                    try
                    {
                        await this.DeleteAsync(requestOptions, operationContext).AsTask(cancellationToken);
                        return true;
                    }
                    catch (Exception)
                    {
                        if (operationContext.CurrentResult.ExtendedErrorInformation != null &&
                            operationContext.CurrentResult.ExtendedErrorInformation.ErrorCode == TableErrorCodeStrings.TableNotFound)
                        {
                            return false;
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            });
        }
        #endregion

        #region Exists
        /// <summary>
        /// Creates the Table.
        /// </summary>
        /// <returns><c>true</c> if the table was created sucessfully; otherwise, <c>false</c>.</returns>
        public IAsyncOperation<bool> ExistsAsync()
        {
            return this.ExistsAsync(null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Creates the Table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns><c>true</c> if the table was created sucessfully; otherwise, <c>false</c>.</returns>
        public IAsyncOperation<bool> ExistsAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            DynamicTableEntity tblEntity = new DynamicTableEntity();
            tblEntity.Properties.Add(TableConstants.TableName, new EntityProperty(this.Name));
            TableOperation operation = new TableOperation(tblEntity, TableOperationType.Retrieve);
            operation.IsTableEntity = true;

            return AsyncInfo.Run(async (cancellationToken) =>
            {
                TableResult res = await this.ServiceClient.ExecuteAsync(TableConstants.TableServiceTablesName, operation, requestOptions, operationContext).AsTask(cancellationToken);

                // Only other option is not found, other status codes will throw prior to this.            
                return res.HttpStatusCode == (int)HttpStatusCode.OK;
            });
        }
        #endregion

        #region Permissions
        /// <summary>
        /// Sets permissions for the Table.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the Table.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        public IAsyncAction SetPermissionsAsync(TablePermissions permissions)
        {
            return this.SetPermissionsAsync(permissions, null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Sets permissions for the Table.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the Table.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        public IAsyncAction SetPermissionsAsync(TablePermissions permissions, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (cancellationToken) => await Executor.ExecuteAsyncNullReturn(
                                                                                    this.SetPermissionsImpl(permissions, modifiedOptions),
                                                                                    modifiedOptions.RetryPolicy,
                                                                                    operationContext,
                                                                                    cancellationToken));
        }

        /// <summary>
        /// Implementation for the SetPermissions method.
        /// </summary>
        /// <param name="acl">The permissions to set.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <returns>A <see cref="RESTCommand"/> that sets the permissions.</returns>
        private RESTCommand<NullType> SetPermissionsImpl(TablePermissions acl, TableRequestOptions requestOptions)
        {
            MemoryStream memoryStream = new MemoryStream();
            TableRequest.WriteSharedAccessIdentifiers(acl.SharedAccessPolicies, memoryStream);

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            requestOptions.ApplyToStorageCommand(putCmd);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildRequest = (cmd, cnt, ctx) => TableHttpRequestMessageFactory.SetAcl(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            putCmd.BuildContent = (cmd, ctx) => HttpContentFactory.BuildContentFromStream(memoryStream, 0, memoryStream.Length, null /* md5 */, cmd, ctx);
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex, ctx);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Gets the permissions settings for the Table.
        /// </summary>
        /// <returns>The Table's permissions.</returns>
        public IAsyncOperation<TablePermissions> GetPermissionsAsync()
        {
            return this.GetPermissionsAsync(null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Gets the permissions settings for the Table.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>The Table's permissions.</returns>
        public IAsyncOperation<TablePermissions> GetPermissionsAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (cancellationToken) => await Executor.ExecuteAsync(
                                                                            this.GetPermissionsImpl(modifiedOptions),
                                                                            modifiedOptions.RetryPolicy,
                                                                            operationContext,
                                                                            cancellationToken));
        }

        /// <summary>
        /// Implementation for the GetPermissions method.
        /// </summary>
        /// <param name="requestOptions">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that gets the permissions.</returns>
        private RESTCommand<TablePermissions> GetPermissionsImpl(TableRequestOptions requestOptions)
        {
            RESTCommand<TablePermissions> getCmd = new RESTCommand<TablePermissions>(this.ServiceClient.Credentials, this.Uri);

            requestOptions.ApplyToStorageCommand(getCmd);
            getCmd.Handler = this.ServiceClient.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequest = (cmd, cnt, ctx) => TableHttpRequestMessageFactory.GetAcl(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex, ctx);
            getCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
            {
                return Task<TablePermissions>.Factory.StartNew(() =>
                {
                    TablePermissions TableAcl = new TablePermissions();
                    HttpResponseParsers.ReadSharedAccessIdentifiers(TableAcl.SharedAccessPolicies, new TableAccessPolicyResponse(cmd.ResponseStream));
                    return TableAcl;
                });
            };

            return getCmd;
        }
        #endregion
    }
}
