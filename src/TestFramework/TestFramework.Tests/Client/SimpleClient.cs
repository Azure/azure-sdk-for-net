// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Threading;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Client
{
    public partial class SimpleClient : ServiceClient<SimpleClient>, ISimpleClient
    {
        public SimpleClient(params DelegatingHandler[] handlers) : base(handlers)
        {

        }

        public SimpleClient(Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this.Credentials = credentials;
            this.BaseUri = baseUri;
            this.Credentials.InitializeServiceClient(this);
        }

        public SimpleClient(ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this.BaseUri = TestEnvironment.EnvEndpoints[EnvironmentNames.Prod].ResourceManagementUri;
            this.Credentials = credentials;
            this.Credentials.InitializeServiceClient(this);
        }

        public string ApiVersion
        {
            get { throw new NotImplementedException(); }
        }

        public Uri BaseUri { get; set; }

        public ServiceClientCredentials Credentials { get; set; }

        public string SubscriptionId { get; set; }

        public int? LongRunningOperationRetryTimeout { get; set; }

        public HttpResponseMessage CsmGetLocation()
        {
            var subscriptionId = this.SubscriptionId;
            // Construct URL
            string url = this.BaseUri.AbsoluteUri + "subscriptions/" + this.SubscriptionId + "/providers?api-version=2014-04-01-preview";

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;

            httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers
            //httpRequest.Headers.Add("Authorization", string.Format("Bearer {0}", accessToken));

            // Set Credentials
            var cancellationToken = new CancellationToken();
            cancellationToken.ThrowIfCancellationRequested();
            this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            return this.HttpClient.SendAsync(httpRequest, cancellationToken).Result;
        }


        public Newtonsoft.Json.JsonSerializerSettings DeserializationSettings
        {
            get { throw new NotImplementedException(); }
        }

        public Newtonsoft.Json.JsonSerializerSettings SerializationSettings
        {
            get { throw new NotImplementedException(); }
        }
    }
}
