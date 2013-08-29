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
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Windows.Foundation;

    /// <summary>
    /// Provides a client-side logical representation of the Windows Azure Table Service. This client is used to configure and execute requests against the Table Service.
    /// </summary>
    /// <remarks>The service client encapsulates the base URI for the Table service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.</remarks>    
    public sealed partial class CloudTableClient
    {
        /// <summary>
        /// Gets or sets the authentication scheme to use to sign HTTP requests.
        /// </summary>
        public AuthenticationScheme AuthenticationScheme
        {
            get
            {
                return this.authenticationScheme;
            }

            set
            {
                this.authenticationScheme = value;
            }
        }

        /// <summary>
        /// Gets the authentication handler used to sign HTTP requests.
        /// </summary>
        /// <value>The authentication handler.</value>
        internal HttpClientHandler AuthenticationHandler
        {
            get
            {
                HttpClientHandler authenticationHandler;
                if (this.Credentials.IsSharedKey)
                {
                    authenticationHandler = new SharedKeyAuthenticationHttpHandler(
                        this.GetCanonicalizer(),
                        this.Credentials,
                        this.Credentials.AccountName);
                }
                else
                {
                    authenticationHandler = new NoOpAuthenticationHttpHandler();
                }

                return authenticationHandler;
            }
        }

        #region TableOperation Execute Methods
        internal IAsyncOperation<TableResult> ExecuteAsync(string tableName, TableOperation operation, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("operation", operation);

            return operation.ExecuteAsync(this, tableName, requestOptions, operationContext);
        }
        #endregion

        #region TableQuery Execute Methods
        internal IAsyncOperation<TableQuerySegment> ExecuteQuerySegmentedAsync(string tableName, TableQuery query, TableContinuationToken token, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("query", query);
            return query.ExecuteQuerySegmentedAsync(token, this, tableName, requestOptions, operationContext);
        }
        #endregion

        #region List Tables
        internal IEnumerable<CloudTable> ListTables()
        {
            return this.ListTables(null);
        }

        internal IEnumerable<CloudTable> ListTables(string prefix)
        {
            return this.ListTables(prefix, null /* RequestOptions */, null /* OperationContext */);
        }

        internal IEnumerable<CloudTable> ListTables(string prefix, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();

            return this.GenerateListTablesQuery(prefix, null).Execute(this, TableConstants.TableServiceTablesName, requestOptions, operationContext).Select(
                    tbl => new CloudTable(tbl.Properties[TableConstants.TableName].StringValue, this));
        }

        /// <summary>
        /// Returns a collection of table items.
        /// </summary>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> token returned by a previous listing operation.</param>
        /// <returns>The result segment containing the collection of tables.</returns>
        public IAsyncOperation<TableResultSegment> ListTablesSegmentedAsync(TableContinuationToken currentToken)
        {
            return this.ListTablesSegmentedAsync(null, null /* maxResults */, currentToken, null /* TableRequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Returns a result segment containing a collection of table items beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> token returned by a previous listing operation.</param>
        /// <returns>The result segment containing the collection of tables.</returns>
        public IAsyncOperation<TableResultSegment> ListTablesSegmentedAsync(string prefix, TableContinuationToken currentToken)
        {
            return this.ListTablesSegmentedAsync(prefix, null /* maxResults */, currentToken, null /* TableRequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Returns a result segment containing a collection of tables beginning with the specified prefix.
        /// </summary>
        /// <param name="prefix">The table name prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c> the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A <see cref="TableContinuationToken"/> token returned by a previous listing operation.</param> 
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that provides information on how the operation executed.</param>
        /// <returns>The result segment containing the collection of tables.</returns>
        public IAsyncOperation<TableResultSegment> ListTablesSegmentedAsync(string prefix, int? maxResults, TableContinuationToken currentToken, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();

            TableQuery query = this.GenerateListTablesQuery(prefix, maxResults);
            return AsyncInfo.Run(async (cancellationToken) =>
            {
                TableQuerySegment seg = await this.ExecuteQuerySegmentedAsync(TableConstants.TableServiceTablesName, query, currentToken, requestOptions, operationContext).AsTask(cancellationToken);

                TableResultSegment retSegment = new TableResultSegment(seg.Results.Select(tbl => new CloudTable(tbl.Properties[TableConstants.TableName].StringValue, this)).ToList());
                retSegment.ContinuationToken = seg.ContinuationToken;
                return retSegment;
            });
        }

        private TableQuery GenerateListTablesQuery(string prefix, int? maxResults)
        {
            TableQuery query = new TableQuery();

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

        /// <summary>
        /// Gets the properties of the table service.
        /// </summary>
        /// <returns>The table service properties as a <see cref="ServiceProperties"/> object.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<ServiceProperties> GetServicePropertiesAsync()
        {
            return this.GetServicePropertiesAsync(null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Gets the properties of the table service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>The table service properties as a <see cref="ServiceProperties"/> object.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<ServiceProperties> GetServicePropertiesAsync(TableRequestOptions requestOptions, OperationContext operationContext)
        {
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (cancellationToken) => await Executor.ExecuteAsync(
                                                                      this.GetServicePropertiesImpl(modifiedOptions),
                                                                      modifiedOptions.RetryPolicy,
                                                                      operationContext,
                                                                      cancellationToken));
        }

        private RESTCommand<ServiceProperties> GetServicePropertiesImpl(TableRequestOptions requestOptions)
        {
            RESTCommand<ServiceProperties> retCmd = new RESTCommand<ServiceProperties>(this.Credentials, this.BaseUri);
            retCmd.BuildRequest = (cmd, cnt, ctx) => TableHttpRequestMessageFactory.GetServiceProperties(cmd.Uri, cmd.ServerTimeoutInSeconds, ctx);

            retCmd.RetrieveResponseStream = true;
            retCmd.Handler = this.AuthenticationHandler;
            retCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) =>
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);

            retCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                return Task.Factory.StartNew(() => HttpResponseParsers.ReadServiceProperties(cmd.ResponseStream));
            };

            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        /// <summary>
        /// Gets the properties of the table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetServicePropertiesAsync(ServiceProperties properties)
        {
            return this.SetServicePropertiesAsync(properties, null /* RequestOptions */, null /* OperationContext */);
        }

        /// <summary>
        /// Gets the properties of the table service.
        /// </summary>
        /// <param name="properties">The table service properties.</param>
        /// <param name="requestOptions">A <see cref="TableRequestOptions"/> object that specifies execution options, such as retry policy and timeout settings, for the operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetServicePropertiesAsync(ServiceProperties properties, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            return AsyncInfo.Run(async (cancellationToken) => await Executor.ExecuteAsyncNullReturn(
                                                                                    this.SetServicePropertiesImpl(properties, modifiedOptions),
                                                                                    modifiedOptions.RetryPolicy,
                                                                                    operationContext,
                                                                                    cancellationToken));
        }

        private RESTCommand<NullType> SetServicePropertiesImpl(ServiceProperties properties, TableRequestOptions requestOptions)
        {
            MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
            try
            {
                properties.WriteServiceProperties(memoryStream);
            }
            catch (InvalidOperationException invalidOpException)
            {
                throw new ArgumentException(invalidOpException.Message, "properties");
            }

            RESTCommand<NullType> retCmd = new RESTCommand<NullType>(this.Credentials, this.BaseUri);
            retCmd.ApplyRequestOptions(requestOptions);
            retCmd.BuildRequest = (cmd, cnt, ctx) => TableHttpRequestMessageFactory.SetServiceProperties(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            retCmd.BuildContent = (cmd, ctx) => HttpContentFactory.BuildContentFromStream(memoryStream, 0, memoryStream.Length, null /* md5 */, cmd, ctx);
            retCmd.Handler = this.AuthenticationHandler;
            retCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) =>
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.Accepted, resp, null /* retVal */, cmd, ex);

            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        #endregion
    }
}
