// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Data.Services.Client;
using System.Data.Services.Common;
using System.Net;
using Microsoft.WindowsAzure.MediaServices.Client.OAuth;
using Microsoft.WindowsAzure.MediaServices.Client.Versioning;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    internal class AzureMediaServicesDataServiceContextFactory
    {
        private readonly OAuthDataServiceAdapter _oAuthDataServiceAdapter;
        private readonly ServiceVersionAdapter _serviceVersionAdapter;

        public AzureMediaServicesDataServiceContextFactory(OAuthDataServiceAdapter oAuthDataServiceAdapter, ServiceVersionAdapter serviceVersionAdapter)
        {
            if (oAuthDataServiceAdapter == null)
            {
                throw new ArgumentNullException("oAuthDataServiceAdapter");
            }

            if (serviceVersionAdapter == null)
            {
                throw new ArgumentNullException("serviceVersionAdapter");
            }

            _oAuthDataServiceAdapter = oAuthDataServiceAdapter;
            _serviceVersionAdapter = serviceVersionAdapter;
        }

        public DataServiceContext CreateDataServiceContext(Uri azureMediaServicesEndpoint)
        {
            if (azureMediaServicesEndpoint == null)
            {
                throw new ArgumentNullException("azureMediaServicesEndpoint");
            }

            Uri mediaServicesAccountApiEndpoint = GetAccountApiEndpoint(_oAuthDataServiceAdapter, _serviceVersionAdapter, azureMediaServicesEndpoint);

            var dataContext = new DataServiceContext(mediaServicesAccountApiEndpoint, DataServiceProtocolVersion.V3)
            {
                IgnoreMissingProperties = true,
                IgnoreResourceNotFoundException = true,
                MergeOption = MergeOption.PreserveChanges
            };

            _oAuthDataServiceAdapter.Adapt(dataContext);
            _serviceVersionAdapter.Adapt(dataContext);

            return dataContext;
        }

        private static Uri GetAccountApiEndpoint(OAuthDataServiceAdapter oAuthDataServiceAdapter, ServiceVersionAdapter versionAdapter, Uri apiServer)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiServer);
            request.AllowAutoRedirect = false;
            oAuthDataServiceAdapter.AddAccessTokenToRequest(request);
            versionAdapter.AddVersionToRequest(request);

            using (WebResponse response = request.GetResponse())
            {
                return GetAccountApiEndpointFromResponse(response);
            }
        }

        private static Uri GetAccountApiEndpointFromResponse(WebResponse webResponse)
        {
            HttpWebResponse httpWebResponse = (HttpWebResponse)webResponse;
            
            if (httpWebResponse.StatusCode == HttpStatusCode.MovedPermanently)
            {
                return new Uri(httpWebResponse.Headers[HttpResponseHeader.Location]);
            }

            if (httpWebResponse.StatusCode == HttpStatusCode.OK)
            {
                return httpWebResponse.ResponseUri;
            }

            throw new InvalidOperationException("Unexpected response code.");
        }
    }
}