// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Client.WebHCatRest
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    /// <summary>
    /// Represents a remote rest request to submit a Hadoop jobDetails.
    /// </summary>
    internal class HadoopRemoteJobSubmissionRestClient : IHadoopJobSubmissionRestClient
    {
        private readonly BasicAuthCredential credentials;
        private readonly IAbstractionContext context;
        private readonly bool ignoreSslErrors;
        private readonly string userAgentString;

        /// <summary>
        /// Initializes a new instance of the HadoopRemoteJobSubmissionRestClient class.
        /// </summary>
        /// <param name="credentials">
        /// The credentials to use to connect to the server.
        /// </param>
        /// <param name="context">
        /// A CancellationToken that can be used to cancel events.
        /// </param>
        /// <param name="ignoreSslErrors">
        /// Specifies that server side SSL error should be ignored.
        /// </param>
        /// <param name="userAgentString">UserAgent string to pass to all calls.</param>
        public HadoopRemoteJobSubmissionRestClient(BasicAuthCredential credentials, IAbstractionContext context, bool ignoreSslErrors, string userAgentString)
        {
            this.credentials = credentials;
            this.context = context;
            this.ignoreSslErrors = ignoreSslErrors;
            this.userAgentString = userAgentString ?? string.Empty;
        }

        /// <inheritdoc/>
        public string GetUserAgentString()
        {
            return this.userAgentString;
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> ListJobs()
        {
            var relative =
                new Uri(
                    HadoopRemoteRestConstants.Jobs + "?" + HadoopRemoteRestConstants.UserName + "=" + this.credentials.UserName.EscapeDataString()
                    + "&" + HadoopRemoteRestConstants.ShowAllFields,
                    UriKind.Relative);
            return await this.MakeAsyncGetRequest(relative);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> GetJob(string jobId)
        {
            var relative =
                new Uri(
                    HadoopRemoteRestConstants.Jobs + "/" + jobId.EscapeDataString() + "?" + HadoopRemoteRestConstants.UserName + "=" +
                    this.credentials.UserName.EscapeDataString(),
                    UriKind.Relative);
            return await this.MakeAsyncGetRequest(relative);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> SubmitMapReduceJob(string payload)
        {
            var relative = new Uri(HadoopRemoteRestConstants.MapReduceJar + "?" +
                                       HadoopRemoteRestConstants.UserName + "=" +
                                       this.credentials.UserName.EscapeDataString(),
                                       UriKind.Relative);
            return await this.MakeAsyncJobSubmissionRequest(relative, payload);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> SubmitHiveJob(string payload)
        {
            var relative = new Uri(HadoopRemoteRestConstants.Hive + "?" +
                                       HadoopRemoteRestConstants.UserName + "=" +
                                       this.credentials.UserName.EscapeDataString(),
                                       UriKind.Relative);
            return await this.MakeAsyncJobSubmissionRequest(relative, payload);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> SubmitStreamingMapReduceJob(string payload)
        {
            var relative = new Uri(HadoopRemoteRestConstants.MapReduceStreaming + "?" +
                                       HadoopRemoteRestConstants.UserName + "=" +
                                       this.credentials.UserName.EscapeDataString(),
                                       UriKind.Relative);
            return await this.MakeAsyncJobSubmissionRequest(relative, payload);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> SubmitPigJob(string payload)
        {
            var relative = new Uri(HadoopRemoteRestConstants.Pig + "?" +
                                         HadoopRemoteRestConstants.UserName + "=" +
                                         this.credentials.UserName.EscapeDataString(),
                                         UriKind.Relative);
            return await this.MakeAsyncJobSubmissionRequest(relative, payload);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> SubmitSqoopJob(string payload)
        {
            var relative = new Uri(HadoopRemoteRestConstants.Sqoop + "?" +
                                         HadoopRemoteRestConstants.UserName + "=" +
                                         this.credentials.UserName.EscapeDataString(),
                                         UriKind.Relative);
            return await this.MakeAsyncJobSubmissionRequest(relative, payload);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> StopJob(string jobId)
        {
            var relative = new Uri(HadoopRemoteRestConstants.Jobs + "/" +
                                        jobId.EscapeDataString() + "?" +
                                        HadoopRemoteRestConstants.UserName + "=" +
                                        this.credentials.UserName.EscapeDataString(),
                                        UriKind.Relative);

            return await this.MakeAsyncJobCancellationRequest(relative);
        }

        /// <summary>
        /// Makes a HTTP GET request to the remote cluster.
        /// </summary>
        /// <param name="relativeUri">The relative uri for the request.</param>
        /// <returns>The response message from the remote cluster.</returns>
        private async Task<IHttpResponseMessageAbstraction> MakeAsyncGetRequest(Uri relativeUri)
        {
            using (var httpClient = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>().Create(this.context, this.ignoreSslErrors))
            {
                var uri = new Uri(this.credentials.Server, relativeUri);
                httpClient.RequestUri = uri;
                httpClient.Method = HttpMethod.Get;
                httpClient.Content = new StringContent(string.Empty);
                this.ProvideStandardHeaders(httpClient);
                return await SendRequestWithErrorChecking(httpClient, HttpStatusCode.OK);
            }
        }

        /// <summary>
        /// Makes a request to the remote cluster to submit a jobDetails.
        /// </summary>
        /// <param name="relativeUri">The relative uri to send the requst to.</param>
        /// <param name="payload">The jobDetails configuration payload.</param>
        /// <returns>The response message from the remote cluster.</returns>
        private async Task<IHttpResponseMessageAbstraction> MakeAsyncJobSubmissionRequest(Uri relativeUri, string payload)
        {
            using (var httpClient = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>().Create(this.context, this.ignoreSslErrors))
            {
                var uri = new Uri(this.credentials.Server, relativeUri);
                httpClient.RequestUri = uri;
                httpClient.Method = HttpMethod.Post;
                this.ProvideStandardHeaders(httpClient);
                httpClient.Content = new StringContent(payload);
                return await SendRequestWithErrorChecking(httpClient, HttpStatusCode.OK);
            }
        }

        /// <summary>
        /// Makes a request to the remote cluster to submit a jobDetails.
        /// </summary>
        /// <param name="relativeUri">The relative uri to send the requst to.</param>
        /// <returns>The response message from the remote cluster.</returns>
        private async Task<IHttpResponseMessageAbstraction> MakeAsyncJobCancellationRequest(Uri relativeUri)
        {
            using (var httpClient = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>().Create(this.context, this.ignoreSslErrors))
            {
                var uri = new Uri(this.credentials.Server, relativeUri);
                httpClient.RequestUri = uri;
                httpClient.Method = HttpMethod.Delete;
                httpClient.Content = new StringContent(string.Empty);
                this.ProvideStandardHeaders(httpClient);
                return await SendRequestWithErrorChecking(httpClient, HttpStatusCode.OK);
            }
        }

        /// <summary>
        /// Provides the basic authorization for a connection.
        /// </summary>
        /// <param name="httpClient">
        /// The HttpClient to which authorization should be added.
        /// </param>
        private void ProvideStandardHeaders(IHttpClientAbstraction httpClient)
        {
            if (this.credentials.UserName != null && this.credentials.Password != null)
            {
                var byteArray = Encoding.ASCII.GetBytes(this.credentials.UserName + ":" + this.credentials.Password);
                httpClient.RequestHeaders.Add(HadoopRemoteRestConstants.Authorization, "Basic " + Convert.ToBase64String(byteArray));
            }
            httpClient.RequestHeaders.Add("accept", "application/json");
            httpClient.RequestHeaders.Add("useragent", this.GetUserAgentString());
            httpClient.RequestHeaders.Add("User-Agent", this.GetUserAgentString());
        }

        /// <summary>
        /// Sends a HttpCLient request, while checking for errors on the return value.
        /// </summary>
        /// <param name="httpClient">The HttpCLient instance to send.</param>
        /// <param name="expectedStatusCode">The status code expected for a succesful response.</param>
        /// <returns>The HttpResponse, after it has been checked for errors.</returns>
        private static async Task<IHttpResponseMessageAbstraction> SendRequestWithErrorChecking(IHttpClientAbstraction httpClient, HttpStatusCode expectedStatusCode)
        {
            var httpResponseMessage = await httpClient.SendAsync();

            if (httpResponseMessage.StatusCode != expectedStatusCode)
            {
                throw new HttpLayerException(httpResponseMessage.StatusCode, httpResponseMessage.Content);
    }

            return httpResponseMessage;
}
    }
}
