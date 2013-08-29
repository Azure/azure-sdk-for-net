// -----------------------------------------------------------------------------------------
// <copyright file="CloudTableClient.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Auth.Protocol;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

#if !WINDOWS_PHONE
    using Microsoft.WindowsAzure.Storage.Table.DataServices;
#endif

    /// <summary>
    /// Provides a client-side logical representation of the Windows Azure Table Service. This client is used to configure and execute requests against the Table Service.
    /// </summary>
    /// <remarks>The service client encapsulates the base URI for the Table service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.</remarks>    
    public sealed partial class CloudTableClient
    {
        private IAuthenticationHandler authenticationHandler;

        /// <summary>
        /// Gets or sets the authentication scheme to use to sign HTTP requests.
        /// </summary>
        /// <remarks>Note that if you are using the legacy Table service API, which is based on WCF Data Services, the authentication scheme used by the TableServiceContext object will always be Shared Key Lite, regardless of the value of this property. </remarks>
        public AuthenticationScheme AuthenticationScheme
        {
            get
            {
                return this.authenticationScheme;
            }

            set
            {
                if (value != this.authenticationScheme)
                {
                    this.authenticationScheme = value;
                    this.authenticationHandler = null;
                }
            }
        }

        /// <summary>
        /// Gets the authentication handler used to sign HTTP requests.
        /// </summary>
        /// <value>The authentication handler.</value>
        internal IAuthenticationHandler AuthenticationHandler
        {
            get
            {
                IAuthenticationHandler result = this.authenticationHandler;
                if (result == null)
                {
                    if (this.Credentials.IsSharedKey)
                    {
                        result = new SharedKeyAuthenticationHandler(
                            this.GetCanonicalizer(),
                            this.Credentials,
                            this.Credentials.AccountName);
                    }
                    else
                    {
                        result = new NoOpAuthenticationHandler();
                    }

                    this.authenticationHandler = result;
                }

                return result;
            }
        }

        #region List Tables
#if SYNC
        /// <summary>
        /// Returns an enumerable collection of tables, which are retrieved lazily, that begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that provides information on how the operation executed.</param>
        /// <returns>An enumerable collection of tables that are retrieved lazily.</returns>
        [DoesServiceRequest]
        public IEnumerable<CloudTable> ListTables(string prefix = null, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();

            return CloudTableClient.GenerateListTablesQuery(prefix, null).Execute(this, TableConstants.TableServiceTablesName, requestOptions, operationContext).Select(
                     tbl => new CloudTable(tbl[TableConstants.TableName].StringValue, this));
        }

        /// <summary>
        /// Returns an enumerable collection of tables in the storage account.
        /// </summary>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>An enumerable collection of tables.</returns>
        [DoesServiceRequest]
        public TableResultSegment ListTablesSegmented(TableContinuationToken currentToken)
        {
            return this.ListTablesSegmented(null, currentToken);
        }

        /// <summary>
        /// Returns an enumerable collection of tables, which are retrieved lazily, that begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>An enumerable collection of tables that are retrieved lazily.</returns>
        [DoesServiceRequest]
        public TableResultSegment ListTablesSegmented(string prefix, TableContinuationToken currentToken)
        {
            return this.ListTablesSegmented(prefix, null, currentToken);
        }

        /// <summary>
        /// Returns an enumerable collection of tables that begin with the specified prefix and that are retrieved lazily.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that provides information on how the operation executed.</param>
        /// <returns>An enumerable collection of tables that are retrieved lazily.</returns>
        [DoesServiceRequest]
        public TableResultSegment ListTablesSegmented(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            TableQuerySegment<DynamicTableEntity> res =
                CloudTableClient.GenerateListTablesQuery(prefix, maxResults).ExecuteQuerySegmented(currentToken, this, TableConstants.TableServiceTablesName, requestOptions, operationContext);

            List<CloudTable> tables = res.Results.Select(tbl => new CloudTable(
                                                                        tbl.Properties[TableConstants.TableName].StringValue,
                                                                        this)).ToList();

            TableResultSegment retSeg = new TableResultSegment(tables) { ContinuationToken = res.ContinuationToken as TableContinuationToken };
            return retSeg;
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of tables 
        /// in the storage account.
        /// </summary>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginListTablesSegmented(TableContinuationToken currentToken, AsyncCallback callback, object state)
        {
            return this.BeginListTablesSegmented(null, currentToken, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection 
        /// of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginListTablesSegmented(string prefix, TableContinuationToken currentToken, AsyncCallback callback, object state)
        {
            return this.BeginListTablesSegmented(prefix, null, currentToken, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection 
        /// of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="requestOptions">The server timeout, maximum execution time, and retry policies for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that provides information on how the operation executed.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginListTablesSegmented(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();

            return CloudTableClient.GenerateListTablesQuery(prefix, maxResults).BeginExecuteQuerySegmented(
                currentToken,
                this,
                TableConstants.TableServiceTablesName,
                requestOptions,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection 
        /// of tables. 
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A result segment containing tables.</returns>
        public TableResultSegment EndListTablesSegmented(IAsyncResult asyncResult)
        {
            TableQuerySegment<DynamicTableEntity> res = Executor.EndExecuteAsync<TableQuerySegment<DynamicTableEntity>>(asyncResult);

            List<CloudTable> tables = res.Results.Select(tbl => new CloudTable(
                                                                         tbl.Properties[TableConstants.TableName].StringValue,
                                                                         this)).ToList();

            TableResultSegment retSeg = new TableResultSegment(tables) { ContinuationToken = res.ContinuationToken };
            return retSeg;
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection 
        /// of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TableResultSegment> ListTablesSegmentedAsync(TableContinuationToken currentToken)
        {
            return this.ListTablesSegmentedAsync(currentToken, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection 
        /// of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TableResultSegment> ListTablesSegmentedAsync(TableContinuationToken currentToken, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginListTablesSegmented, this.EndListTablesSegmented, currentToken, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection 
        /// of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, TableContinuationToken currentToken)
        {
            return this.ListTablesSegmentedAsync(prefix, currentToken, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection 
        /// of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, TableContinuationToken currentToken, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginListTablesSegmented, this.EndListTablesSegmented, prefix, currentToken, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection 
        /// of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="requestOptions">The server timeout, maximum execution time, and retry policies for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return this.ListTablesSegmentedAsync(prefix, maxResults, currentToken, requestOptions, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection 
        /// of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="requestOptions">The server timeout, maximum execution time, and retry policies for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TableResultSegment> ListTablesSegmentedAsync(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginListTablesSegmented, this.EndListTablesSegmented, prefix, maxResults, currentToken, requestOptions, operationContext, cancellationToken);
        }
#endif

        private static TableQuery<DynamicTableEntity> GenerateListTablesQuery(string prefix, int? maxResults)
        {
            TableQuery<DynamicTableEntity> query = new TableQuery<DynamicTableEntity>();

            if (!string.IsNullOrEmpty(prefix))
            {
                // Append Max char to end  '{' is 1 + 'z' in AsciiTable
                string uppperBound = prefix + '{';

                query = query.Where(TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition(TableConstants.TableName, QueryComparisons.GreaterThanOrEqual, prefix),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition(TableConstants.TableName, QueryComparisons.LessThan, uppperBound)));
            }

            if (maxResults.HasValue)
            {
                query = query.Take(maxResults.Value);
            }

            return query;
        }
        #endregion

        #region Analytics
#if SYNC
        /// <summary>
        /// Gets the service properties for the Table service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that provides information on how the operation executed.</param>
        /// <returns>The table service properties as a <see cref="ServiceProperties"/> object.</returns>
        [DoesServiceRequest]
        public ServiceProperties GetServiceProperties(TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            return Executor.ExecuteSync(this.GetServicePropertiesImpl(requestOptions), requestOptions.RetryPolicy, operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to get the service properties of the Table service.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetServiceProperties(AsyncCallback callback, object state)
        {
            return this.BeginGetServiceProperties(null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to get the service properties of the Table service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that provides information on how the operation executed.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetServiceProperties(TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            return Executor.BeginExecuteAsync(this.GetServicePropertiesImpl(requestOptions), requestOptions.RetryPolicy, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to get the service properties of the Table service.
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="BeginGetServiceProperties(AsyncCallback, object)"/>.</param>
        /// <returns>The table service properties.</returns>
        public ServiceProperties EndGetServiceProperties(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<ServiceProperties>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to get the service properties of the Table service.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ServiceProperties> GetServicePropertiesAsync()
        {
            return this.GetServicePropertiesAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get the service properties of the Table service.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ServiceProperties> GetServicePropertiesAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetServiceProperties, this.EndGetServiceProperties, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get the service properties of the Table service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ServiceProperties> GetServicePropertiesAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return this.GetServicePropertiesAsync(requestOptions, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get the service properties of the Table service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ServiceProperties> GetServicePropertiesAsync(TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetServiceProperties, this.EndGetServiceProperties, requestOptions, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Sets the service properties of the Table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that provides information on how the operation executed.</param>
        [DoesServiceRequest]
        public void SetServiceProperties(ServiceProperties properties, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            Executor.ExecuteSync(this.SetServicePropertiesImpl(properties, requestOptions), requestOptions.RetryPolicy, operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to set the service properties of the Table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, AsyncCallback callback, object state)
        {
            return this.BeginSetServiceProperties(properties, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to set the service properties of the Table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that provides information on how the operation executed.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            return Executor.BeginExecuteAsync(this.SetServicePropertiesImpl(properties, requestOptions), requestOptions.RetryPolicy, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to set the service properties of the Table service.
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="BeginSetServiceProperties(ServiceProperties, AsyncCallback, object)"/></param>
        public void EndSetServiceProperties(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to set the service properties of the Table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetServicePropertiesAsync(ServiceProperties properties)
        {
            return this.SetServicePropertiesAsync(properties, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to set the service properties of the Table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetServicePropertiesAsync(ServiceProperties properties, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetServiceProperties, this.EndSetServiceProperties, properties, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to set the service properties of the Table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetServicePropertiesAsync(ServiceProperties properties, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            return this.SetServicePropertiesAsync(properties, requestOptions, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to set the service properties of the Table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetServicePropertiesAsync(ServiceProperties properties, TableRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetServiceProperties, this.EndSetServiceProperties, properties, requestOptions, operationContext, cancellationToken);
        }
#endif

        private RESTCommand<ServiceProperties> GetServicePropertiesImpl(TableRequestOptions requestOptions)
        {
            RESTCommand<ServiceProperties> retCmd = new RESTCommand<ServiceProperties>(this.Credentials, this.BaseUri);
            retCmd.BuildRequestDelegate = TableHttpWebRequestFactory.GetServiceProperties;
            retCmd.SignRequest = this.AuthenticationHandler.SignRequest;
            retCmd.RetrieveResponseStream = true;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);

            retCmd.PostProcessResponse = (cmd, resp, ctx) => TableHttpWebResponseParsers.ReadServiceProperties(cmd.ResponseStream);
            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        private RESTCommand<NullType> SetServicePropertiesImpl(ServiceProperties properties, TableRequestOptions requestOptions)
        {
            MultiBufferMemoryStream str = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
            try
            {
                properties.WriteServiceProperties(str);
            }
            catch (InvalidOperationException invalidOpException)
            {
                throw new ArgumentException(invalidOpException.Message, "properties");
            }

            str.Seek(0, SeekOrigin.Begin);

            RESTCommand<NullType> retCmd = new RESTCommand<NullType>(this.Credentials, this.BaseUri);
            retCmd.SendStream = str;
            retCmd.BuildRequestDelegate = TableHttpWebRequestFactory.SetServiceProperties;
            retCmd.RecoveryAction = RecoveryActions.RewindStream;
            retCmd.SignRequest = this.AuthenticationHandler.SignRequest;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.Accepted, resp, NullType.Value, cmd, ex);

            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        #endregion

#if !WINDOWS_PHONE
        /// <summary>
        /// Creates a new <see cref="TableServiceContext"/> object for performing operations against the Table service.
        /// </summary>
        /// <returns>A service context to use for performing operations against the Table service.</returns>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1024:UsePropertiesWhereAppropriate",
            Justification = "This method creates a new object each time.")]
        public TableServiceContext GetTableServiceContext()
        {
            return new TableServiceContext(this);
        }
#endif
    }
}