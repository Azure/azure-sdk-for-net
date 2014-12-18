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
namespace Microsoft.HadoopAppliance.Client.HadoopStorageRestClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class HadoopApplianceStorageRestClient : IHadoopApplianceStorageRestClient
    {
        private StorageClientBasicAuthCredential credentials;
        private readonly bool ignoreSslErrors;
        private readonly TimeSpan timeout;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HadoopApplianceStorageRestClient"/> class.
        /// </summary>
        /// <param name="credentials">The connection credentials to use when connecting to the instance.</param>
        /// <param name="ignoreSslErrors">Specifies that server side SSL errors should be ignored.</param>
        /// <param name="timeout">Maximum time span for storage commands.</param>
        public HadoopApplianceStorageRestClient(IStorageClientCredential credentials, bool ignoreSslErrors, TimeSpan timeout)
        {
            this.credentials = (StorageClientBasicAuthCredential)credentials;
            this.ignoreSslErrors = ignoreSslErrors;
            this.timeout = timeout;
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> ListStatus(string path)
        {
            var relativeUri = this.MakeRelativeUri(path, "LISTSTATUS");
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Get);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> GetFileStatus(string path)
        {
            var relativeUri = this.MakeRelativeUri(path, "GETFILESTATUS");
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Get);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> Exists(string path)
        {
            var relativeUri = this.MakeRelativeUri(path, "GETFILESTATUS");
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Get, HttpStatusCode.OK, HttpStatusCode.NotFound);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> CreateDirectory(string path)
        {
            var relativeUri = this.MakeRelativeUri(path, "MKDIRS");
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Put);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> Write(string path, Stream data, bool? overwrite)
        {
            string relativeUri;
            if (overwrite.HasValue)
            {
                relativeUri = this.MakeRelativeUri(path, "CREATE", new KeyValuePair<string, string>("overwrite", overwrite.Value.ToString()));
            }
            else
            {
                relativeUri = this.MakeRelativeUri(path, "CREATE");
            }
            
            var factory = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>();
            string location;
            StringContent emptyContent = new StringContent(string.Empty);
            using (var httpClient = factory.Create(this.ignoreSslErrors, false))
            {
                var uri = new Uri(this.GetRootUri() + relativeUri);
                httpClient.Timeout = this.timeout;
                httpClient.RequestUri = uri;
                httpClient.Method = HttpMethod.Put;
                httpClient.Content = emptyContent;
                httpClient.ContentType = "text/xml";
                this.ProvideStandardHeaders(httpClient);
                var response = await SendRequestWithErrorChecking(httpClient, HttpStatusCode.TemporaryRedirect);
                location = response.Headers.GetValues("Location").First();
            }
            using (var httpClient = factory.Create(this.ignoreSslErrors, false))
            {
                httpClient.Timeout = this.timeout;
                httpClient.RequestUri = new Uri(location);
                httpClient.Method = HttpMethod.Put;
                StreamContent sc = new StreamContent(data);
                httpClient.Content = sc;
                httpClient.ContentType = "application/octet-stream";
                this.ProvideStandardHeaders(httpClient);
                return await SendRequestWithErrorChecking(httpClient, HttpStatusCode.Created);
            }
        }

        /// <inheritdoc />
        public Task<IHttpResponseMessageAbstraction> Write(string path, Stream data)
        {
            return this.Write(path, data, false);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> Append(string path, Stream data)
        {
            var relativeUri = this.MakeRelativeUri(path, "APPEND");
            var factory = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>();
            string location;
            using (var httpClient = factory.Create(this.ignoreSslErrors, false))
            {
                var uri = new Uri(this.GetRootUri() + relativeUri);
                httpClient.Timeout = this.timeout;
                httpClient.RequestUri = uri;
                httpClient.Method = HttpMethod.Post;
                this.ProvideStandardHeaders(httpClient);
                var response = await SendRequestWithErrorChecking(httpClient, HttpStatusCode.TemporaryRedirect);
                location = response.Headers.GetValues("Location").First();
            }
            using (var httpClient = factory.Create(this.ignoreSslErrors, false))
            {
                httpClient.Timeout = this.timeout;
                httpClient.RequestUri = new Uri(location);
                httpClient.Method = HttpMethod.Post;
                StreamContent sc = new StreamContent(data);
                httpClient.Content = sc;
                httpClient.ContentType = "application/octet-stream";
                this.ProvideStandardHeaders(httpClient);
                return await SendRequestWithErrorChecking(httpClient, HttpStatusCode.OK);
            }
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> Read(string path, long? offset, long? length, int? buffersize)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            if (offset.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("offset", offset.Value.ToString()));
            }
            if (length.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("length", length.Value.ToString()));
            }
            if (buffersize.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("buffersize", buffersize.Value.ToString()));
            }

            var relativeUri = this.MakeRelativeUri(path, "OPEN", parameters.ToArray());
            var factory = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>();
            string location;
            using (var httpClient = factory.Create(this.ignoreSslErrors, false))
            {
                var uri = new Uri(this.GetRootUri() + relativeUri);
                httpClient.Timeout = this.timeout;
                httpClient.RequestUri = uri;
                httpClient.Method = HttpMethod.Get;
                this.ProvideStandardHeaders(httpClient);
                var response = await SendRequestWithErrorChecking(httpClient, HttpStatusCode.TemporaryRedirect);
                location = response.Headers.GetValues("Location").First();
            }
            using (var httpClient = factory.Create(this.ignoreSslErrors, false))
            {
                httpClient.Timeout = this.timeout;
                httpClient.RequestUri = new Uri(location);
                httpClient.Method = HttpMethod.Get;
                this.ProvideStandardHeaders(httpClient);
                return await SendRequestWithErrorChecking(httpClient, HttpStatusCode.OK);
            }
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> Delete(string path, bool? recursive)
        {
            string relativeUri;
            if (recursive.HasValue)
            {
                relativeUri = this.MakeRelativeUri(path, "DELETE", new KeyValuePair<string, string>("recursive", recursive.Value.ToString()));
            }
            else
            {
                relativeUri = this.MakeRelativeUri(path, "DELETE");
            }
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Delete);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> Rename(string path, string destination)
        {
            var relativeUri = this.MakeRelativeUri(path, "RENAME", new KeyValuePair<string, string>("destination", destination));
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Put);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> GetContentSummary(string path)
        {
            var relativeUri = this.MakeRelativeUri(path, "GETCONTENTSUMMARY");
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Get);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> GetHomeDirectory()
        {
            var relativeUri = this.MakeRelativeUri("/", "GETHOMEDIRECTORY");
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Get);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> SetOwner(string path, string owner, string group)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            if (owner.IsNotNullOrEmpty())
            {
                parameters.Add(new KeyValuePair<string, string>("owner", owner));
            }
            if (group.IsNotNullOrEmpty())
            {
                parameters.Add(new KeyValuePair<string, string>("group", group));
            }
            var relativeUri = this.MakeRelativeUri(path, "SETOWNER", parameters.ToArray());
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Put);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> SetPermission(string path, string permission)
        {
            var relativeUri = this.MakeRelativeUri(path, "SETPERMISSION", new KeyValuePair<string, string>("permission", permission));
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Put);
        }

        /// <inheritdoc />
        public async Task<IHttpResponseMessageAbstraction> SetReplication(string path, short replication)
        {
            var relativeUri = this.MakeRelativeUri(path, "SETREPLICATION", new KeyValuePair<string, string>("replication", replication.ToString()));
            return await this.MakeAsyncRequest(relativeUri, HttpMethod.Put);
        }

        private string GetRootUri()
        {
            return new Uri(this.credentials.Server, "/webhdfs/v1").ToString();
        }

        private string MakeRelativeUri(string path, string operation, params KeyValuePair<string, string>[] additionalParams)
        {
            string location = path + "?" + "user.name" + "=" + this.credentials.UserName.EscapeDataString() + "&op=" + operation;
            if (additionalParams.IsNotNull() && additionalParams.Length > 0)
            {
                location += "&" + string.Join("&", additionalParams.Select((kvp) => kvp.Key + "=" + kvp.Value));
            }
            return location;
        }

        private Task<IHttpResponseMessageAbstraction> MakeAsyncRequest(string relativeUri, HttpMethod method)
        {
            return this.MakeAsyncRequest(relativeUri, method, HttpStatusCode.OK);
        }

        private async Task<IHttpResponseMessageAbstraction> MakeAsyncRequest(string relativeUri, HttpMethod method, params HttpStatusCode[] expectedStatusCodes)
        {
            var factory = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>();
            using (var httpClient = factory.Create(this.ignoreSslErrors))
            {
                var uri = new Uri(this.GetRootUri() + relativeUri);
                httpClient.Timeout = this.timeout;
                httpClient.RequestUri = uri;
                httpClient.Method = method;
                if (method == HttpMethod.Put)
                {
                    httpClient.Content = new StringContent(string.Empty);
                    httpClient.ContentType = "text/json";
                }
                this.ProvideStandardHeaders(httpClient);
                return await SendRequestWithErrorChecking(httpClient, expectedStatusCodes);
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
                httpClient.RequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(byteArray));
            }
            httpClient.RequestHeaders.Add("accept", "application/json");
            httpClient.RequestHeaders.Add("useragent", "HDInsight .NET SDK");
            httpClient.RequestHeaders.Add("User-Agent", "HDInsight .NET SDK");
        }

        /// <summary>
        /// Sends a HttpCLient request, while checking for errors on the return value.
        /// </summary>
        /// <param name="httpClient">The HttpCLient instance to send.</param>
        /// <param name="allowedStatusCodes">Allowed status codes for a succesful response.</param>
        /// <returns>The HttpResponse, after it has been checked for errors.</returns>
        private static async Task<IHttpResponseMessageAbstraction> SendRequestWithErrorChecking(IHttpClientAbstraction httpClient, params HttpStatusCode[] allowedStatusCodes)
        {
            var httpResponseMessage = await httpClient.SendAsync();

            if (!allowedStatusCodes.Contains(httpResponseMessage.StatusCode))
            {
                throw new HttpLayerException(httpResponseMessage.StatusCode, httpResponseMessage.Content);
            }

            return httpResponseMessage;
        }
    }
}
