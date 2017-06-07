//-----------------------------------------------------------------------
// <copyright file="AzureHttpClient.cs" company="Microsoft">
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
// <summary>
//    Contains code for the AzureHttpClient class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// The main class of the client library, contains all of the Async methods that 
    /// represent Azure APIs
    /// </summary>
    public partial class AzureHttpClient : IDisposable
    {
        /// <summary>
        /// Constructor of the AzureHttpClient class. It uses the default azure API endpoint
        /// of https://management.core.windows.net.
        /// </summary>
        /// <param name="subscriptionId">The subscription Id of the target subscription.</param>
        /// <param name="managementCertificate">A valid management certificate for the target subscription.</param>
        public AzureHttpClient(Guid subscriptionId, X509Certificate2 managementCertificate)
            : this(DefaultBaseAddress, subscriptionId, managementCertificate)
        {
        }

        //100 seconds is the default timeout...
        /// <summary>
        /// Constructor for the AzureHttpClient class which enables pointing to non-default Azure API endpoints. Also allows
        /// overriding the default 100 second timeout used with HttpClient.
        /// </summary>
        /// <param name="baseUrl">Alternate API endpoint.</param>
        /// <param name="subscriptionId">The subscription Id of the target subscription.</param>
        /// <param name="managementCertificate">A valid management certificate for the target subscription.</param>
        /// <param name="timeout">Optional API timeout time, in milliseconds. Default value is 100000 (100 seconds).</param>
        public AzureHttpClient(Uri baseUrl, Guid subscriptionId, X509Certificate2 managementCertificate, int timeout = 100000)
        {
            this.SubscriptionId = subscriptionId;
            WebRequestHandler handler = new WebRequestHandler();
            handler.ClientCertificates.Add(managementCertificate);

            this._wrappedClient = new HttpClient(handler);
            this._wrappedClient.BaseAddress = baseUrl;
            this._wrappedClient.Timeout = new TimeSpan(0,0,0,0,timeout);

            this._formatter = new XmlMediaTypeFormatter { UseXmlSerializer = false };
            this._disposeLock = new object();
            this._disposed = false;
        }

        #region IDisposable Pattern
        private object _disposeLock;
        private bool _disposed;
        //no finalizer because no unmanaged resources
        /// <summary>
        /// Use IDisposable.Dispose to dispose of the AzureHttpClient class.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                if (!_disposed)
                {
                    _disposed = true;

                    if (disposing)
                    {
                        _wrappedClient.Dispose();
                        _wrappedClient = null;
                        _formatter = null;
                    }
                }
                else
                {
                    throw new ObjectDisposedException(this.GetType().ToString());
                }
            }
        }
        #endregion

        /// <summary>
        /// The Default API Endpoint for Azure: https://management.core.windows.net
        /// </summary>
        public static readonly Uri DefaultBaseAddress = new Uri(AzureConstants.AzureDefaultEndpoint);

        /// <summary>
        /// Gets the SubscriptionId used by this instance of AzureHttpClient
        /// </summary>
        public Guid SubscriptionId { get; private set; }

        #region Miscellaneous operations
        /// <summary>
        /// Begins an asychronous operation to track the status of a long-running asynchronous operation.
        /// </summary>
        /// <param name="requestId">The requestId identifying the long-running operation, returned from the intial call.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns an <see cref="OperationStatusInfo"/> object.</returns>
        public Task<OperationStatusInfo> GetOperationStatusAsync(string requestId, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(requestId, "requestId");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.GetOperationStatus, requestId));

            return StartGetTask<OperationStatusInfo>(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to list the valid data center locations for the subscription.
        /// </summary>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="LocationCollection"/></returns>
        public Task<LocationCollection> ListLocationsAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.Locations));

            return StartGetTask<LocationCollection>(message, token);
        }
        #endregion

        #region Helper Methods
        HttpRequestMessage CreateBaseMessage(HttpMethod method, Uri uri, object content = null)
        {
            HttpRequestMessage message = new HttpRequestMessage(method, uri);

            message.Headers.Add(UriFragments.VersionHeader, UriFragments.VersionTarget_1_7);

            if (content != null)
            {
                message.Content = new ObjectContent(content.GetType(), content, _formatter);
            }

            return message;
        }

        //use this one for calls that don't return any content. We return the request id
        //this can be ignored for calls that complete right away.
        Task<string> StartSendTask(HttpRequestMessage message, CancellationToken token)
        {
            return StartSendTask<string>(message, token, (returnTask) =>
                {
                    returnTask.Result.EnsureSuccessStatusCodeEx();
                    token.ThrowIfCancellationRequested();

                    return returnTask.Result.Headers.GetValues(UriFragments.RequestIdHeader).First();
                });
        }

        //use this one for calls that return specific content, GET operations in general
        Task<T> StartGetTask<T>(HttpRequestMessage message, CancellationToken token)
        {
            return StartSendTask<T>(message, token, (returnTask) =>
                {
                    returnTask.Result.EnsureSuccessStatusCodeEx();
                    token.ThrowIfCancellationRequested();

                    return returnTask.Result.Content.ReadAsSync<T>(_formatter);
                });
        }

        //currently only option is execute synchronously, so we don't spawn another thread
        //the result will be read by the time we get there...
        private const TaskContinuationOptions options = TaskContinuationOptions.ExecuteSynchronously;

        Task<T> StartSendTask<T>(HttpRequestMessage message, CancellationToken token, Func<Task<HttpResponseMessage>,T> continuation)
        {
            return _wrappedClient.SendAsync(message, token)
                       .ContinueWith<T>(continuation, token, options, TaskScheduler.Current);
        }

        Uri CreateTargetUri(string uriformat, params string[] additionalFragments)
        {
            if (additionalFragments == null) throw new ArgumentNullException("additionalFragments");

            string[] formatArgs = new string[additionalFragments.Length + 1];
            formatArgs[0] = SubscriptionId.ToString();

            if (additionalFragments.Length > 0)
            {
                additionalFragments.CopyTo(formatArgs, 1);
            }

            string formattedUri = string.Format(uriformat, formatArgs);
            Uri retUri = new Uri(_wrappedClient.BaseAddress, formattedUri);

            return retUri;
        }
        #endregion

        private HttpClient _wrappedClient;
        private XmlMediaTypeFormatter _formatter;

        //this is the only supported algorithm
        private const string _sha1thumbprintAlgorithm = "sha1";

    }
}
