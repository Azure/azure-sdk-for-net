//-----------------------------------------------------------------------
// <copyright file="TableServiceContext.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table.DataServices
{
    using System;
    using System.Data.Services.Client;
    using System.Globalization;
    using System.Net;
    using System.Threading;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;

    /// <summary>
    /// Represents a <see cref="DataServiceContext"/> object for use with the Windows Azure Table service.
    /// </summary>
    /// <remarks>The <see cref="TableServiceContext"/> class does not support concurrent queries or requests.</remarks>
    public class TableServiceContext : DataServiceContext, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceContext"/> class.
        /// </summary>
        public TableServiceContext(CloudTableClient client)
            : base(client.BaseUri)
        {
            if (client.BaseUri == null)
            {
                throw new ArgumentNullException("client.BaseUri");
            }

            if (!client.BaseUri.IsAbsoluteUri)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.RelativeAddressNotPermitted, client.BaseUri.ToString());

                throw new ArgumentException(errorMessage, "client.BaseUri");
            }

            this.SendingRequest += this.TableServiceContext_SendingRequest;

            this.IgnoreMissingProperties = true;
            this.MergeOption = MergeOption.PreserveChanges;
            this.ServiceClient = client;
        }

        #region Cancellation Support
        internal void InternalCancel()
        {
            lock (this.cancellationLock)
            {
                this.cancellationRequested = true;
                if (this.currentRequest != null)
                {
                    this.currentRequest.Abort();
                }
            }
        }

        internal void ResetCancellation()
        {
            lock (this.cancellationLock)
            {
                this.cancellationRequested = false;
                this.currentRequest = null;
            }
        }

        private object cancellationLock = new object();

        private bool cancellationRequested = false;

        private HttpWebRequest currentRequest = null;
        #endregion

        #region Signing + Execution

        // Action to hook up response header parsing
        private Action<HttpWebRequest> sendingSignedRequestAction;

        internal Action<HttpWebRequest> SendingSignedRequestAction
        {
            get { return this.sendingSignedRequestAction; }
            set { this.sendingSignedRequestAction = value; }
        }

        // Only one concurrent operation per context is supported.
        private Semaphore contextSemaphore = new Semaphore(1, 1);

        internal Semaphore ContextSemaphore
        {
            get { return this.contextSemaphore; }
            set { this.contextSemaphore = value; }
        }

        /// <summary>
        /// Callback on DataContext object sending request.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Data.Services.Client.SendingRequestEventArgs"/> instance containing the event data.</param>       
        private void TableServiceContext_SendingRequest(object sender, SendingRequestEventArgs e)
        {
            HttpWebRequest request = e.Request as HttpWebRequest;

            // Check timeout
            int timeoutDex = request.RequestUri.Query.LastIndexOf("&timeout=", System.StringComparison.Ordinal);
            if (timeoutDex > 0)
            {
                timeoutDex += 9; // Magic number -> length of "&timeout="
                int endDex = request.RequestUri.Query.IndexOf('&', timeoutDex);
                string timeoutString = endDex > 0
                                           ? request.RequestUri.Query.Substring(timeoutDex, endDex - timeoutDex)
                                           : request.RequestUri.Query.Substring(timeoutDex);

                int result = -1;
                int.TryParse(timeoutString, out result);
                if (result > 0)
                {
                    request.Timeout = result * 1000; // Convert to ms
                }
            }

            // Sign request
            if (this.ServiceClient.Credentials.IsSharedKey)
            {
                this.ServiceClient.AuthenticationHandler.SignRequest(request, null /* operationContext */);
            }
            else if (this.ServiceClient.Credentials.IsSAS)
            {
                Uri transformedUri = this.ServiceClient.Credentials.TransformUri(request.RequestUri);

                // Recreate the request
                HttpWebRequest newRequest = WebRequest.Create(transformedUri) as HttpWebRequest;
                TableUtilities.CopyRequestData(newRequest, request);
                e.Request = newRequest;
                request = newRequest;
            }

            lock (this.cancellationLock)
            {
                if (this.cancellationRequested)
                {
                    throw new OperationCanceledException(SR.OperationCanceled);
                }

                this.currentRequest = request;
            }

            // SAS will be handled directly by the queries themselves prior to transformation
            request.Headers.Add(
                Constants.HeaderConstants.StorageVersionHeader,
                Constants.HeaderConstants.TargetStorageVersion);

            CommonUtils.ApplyRequestOptimizations(request, -1);

            if (this.sendingSignedRequestAction != null)
            {
                this.sendingSignedRequestAction(request);
            }
        }
        #endregion

        /// <summary>
        /// Gets the <see cref="CloudTableClient"/> object that represents the Table service.
        /// </summary>
        /// <value>A client object that specifies the Table service endpoint.</value>
        public CloudTableClient ServiceClient { get; private set; }

        /// <summary>
        /// Begins an asynchronous operation to save changes, using the retry policy specified for the service context.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSaveChangesWithRetries(AsyncCallback callback, object state)
        {
            return this.BeginSaveChangesWithRetries(this.SaveChangesDefaultOptions, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to save changes, using the retry policy specified for the service context.
        /// </summary>
        /// <param name="options">Additional options for saving changes.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSaveChangesWithRetries(SaveChangesOptions options, AsyncCallback callback, object state)
        {
            return this.BeginSaveChangesWithRetries(options, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to save changes, using the retry policy specified for the service context.
        /// </summary>
        /// <param name="options">Additional options for saving changes.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <param name="requestOptions"> </param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSaveChangesWithRetries(SaveChangesOptions options, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            TableCommand<DataServiceResponse, DataServiceResponse> cmd = this.GenerateSaveChangesCommand(options, requestOptions);
            return TableExecutor.BeginExecuteAsync(cmd, requestOptions.RetryPolicy, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to save changes.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns> A <see cref="DataServiceResponse"/> that represents the result of the operation.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public DataServiceResponse EndSaveChangesWithRetries(IAsyncResult asyncResult)
        {
            return TableExecutor.EndExecuteAsync<DataServiceResponse, DataServiceResponse>(asyncResult);
        }

        /// <summary>
        /// Saves changes, using the retry policy specified for the service context.
        /// </summary>
        /// <returns>A <see cref="DataServiceResponse"/> that represents the result of the operation.</returns>
        [DoesServiceRequest]
        public DataServiceResponse SaveChangesWithRetries()
        {
            return this.SaveChangesWithRetries(this.SaveChangesDefaultOptions);
        }

        /// <summary>
        /// Saves changes, using the retry policy specified for the service context.
        /// </summary>
        /// <param name="options">Additional options for saving changes.</param>
        /// <param name="requestOptions"> </param>
        /// <param name="operationContext"> </param>
        /// <returns> A <see cref="DataServiceResponse"/> that represents the result of the operation.</returns>
        [DoesServiceRequest]
        public DataServiceResponse SaveChangesWithRetries(SaveChangesOptions options, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = TableRequestOptions.ApplyDefaults(requestOptions, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            TableCommand<DataServiceResponse, DataServiceResponse> cmd = this.GenerateSaveChangesCommand(options, requestOptions);
            return TableExecutor.ExecuteSync(cmd, requestOptions.RetryPolicy, operationContext);
        }

        internal TableCommand<DataServiceResponse, DataServiceResponse> GenerateSaveChangesCommand(SaveChangesOptions options, TableRequestOptions requestOptions)
        {
            TableCommand<DataServiceResponse, DataServiceResponse> cmd = new TableCommand<DataServiceResponse, DataServiceResponse>();

            if (requestOptions.ServerTimeout.HasValue)
            {
                this.Timeout = (int)requestOptions.ServerTimeout.Value.TotalSeconds;
            }

            cmd.ExecuteFunc = () => this.SaveChanges(options);
            cmd.Begin = (callback, state) => this.BeginSaveChanges(options, callback, state);
            cmd.End = this.EndSaveChanges;
            cmd.ParseResponse = this.ParseDataServiceResponse;
            cmd.ApplyRequestOptions(requestOptions);
            cmd.Context = this;

            return cmd;
        }

        private DataServiceResponse ParseDataServiceResponse(DataServiceResponse resp, RequestResult reqResult, TableCommand<DataServiceResponse, DataServiceResponse> cmd)
        {
            if (reqResult.Exception != null)
            {
                throw reqResult.Exception;
            }

            return resp;
        }

        /// <summary>
        /// Releases unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);  
        }

        protected virtual void Dispose(bool explicitDisposing)
        {
            if (explicitDisposing)
            {
                GC.SuppressFinalize(this);

                if (this.contextSemaphore != null)
                {
#if DN35CP
                    this.contextSemaphore.Close();
#else
                    this.contextSemaphore.Dispose();
#endif
                }
            }
        }
    }
}