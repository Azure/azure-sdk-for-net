//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.Azure.Management.WebSites;
using Microsoft.WindowsAzure;

namespace Microsoft.Azure
{
    public static class WebSiteManagementDiscoveryExtensions
    {
        public static WebSiteManagementClient CreateWebSiteManagementClient(this CloudClients clients, TokenCloudCredentials credentials)
        {
            return new WebSiteManagementClient(credentials);
        }

        public static WebSiteManagementClient CreateWebSiteManagementClient(this CloudClients clients, TokenCloudCredentials credentials, Uri baseUri)
        {
            return new WebSiteManagementClient(credentials, baseUri);
        }

        public static WebSiteManagementClient CreateWebSiteManagementClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<WebSiteManagementClient>(WebSiteManagementClient.Create);
        }
    }
}

namespace Microsoft.Azure.Management.WebSites
{
    public partial class WebSiteManagementClient
    {
        public static WebSiteManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            TokenCloudCredentials credentials = ConfigurationHelper.GetCredentials<TokenCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new WebSiteManagementClient(credentials, baseUri) :
                new WebSiteManagementClient(credentials);
        }

        public override WebSiteManagementClient WithHandler(DelegatingHandler handler)
        {
            return (WebSiteManagementClient)WithHandler(new WebSiteManagementClient(), handler);
        }
    }
}
