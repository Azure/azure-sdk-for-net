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
namespace Microsoft.WindowsAzure.Management.Configuration
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class AzureHdInsightConfigurationRestClient : IAzureHdInsightConfigurationRestClient
    {
        private const string ComponentSettingsAddressUriTemplate = "/ambari/api/v1/clusters/{0}/configurations";
        private readonly BasicAuthCredential credentials;

        public AzureHdInsightConfigurationRestClient(BasicAuthCredential credentials)
        {
            this.credentials = credentials;
        }

        public async Task<IHttpResponseMessageAbstraction> GetComponentSettingsAddress()
        {
            string componentSettingsAddressUri = string.Format(
                ComponentSettingsAddressUriTemplate, this.credentials.Server.Host.Split('.')[0]);
            Uri requestUri = new Uri(componentSettingsAddressUri, UriKind.Relative);

            return await this.MakeAsyncGetRequest(requestUri);
        }

        public async Task<IHttpResponseMessageAbstraction> GetComponentSettings(Uri componentUri)
        {
            componentUri.ArgumentNotNull("componentUri");
            return await this.MakeAsyncGetRequest(componentUri);
        }

        /// <summary>
        /// Makes a HTTP GET request to the remote cluster.
        /// </summary>
        /// <param name="relativeUri">The relative uri for the request.</param>
        /// <returns>The response message from the remote cluster.</returns>
        private async Task<IHttpResponseMessageAbstraction> MakeAsyncGetRequest(Uri relativeUri)
        {
            using (var httpClient = ServiceLocator.Instance.Locate<IHttpClientAbstractionFactory>().Create(false))
            {
                var uri = new Uri(this.credentials.Server, relativeUri);
                httpClient.RequestUri = uri;
                httpClient.Method = HttpMethod.Get;
                this.ProvideStandardHeaders(httpClient);
                return await httpClient.SendAsync();
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
                httpClient.RequestHeaders.Add(System.Net.HttpRequestHeader.Authorization.ToString(), "Basic " + Convert.ToBase64String(byteArray));
            }
            httpClient.RequestHeaders.Add("accept", "application/json");
        }
    }
}