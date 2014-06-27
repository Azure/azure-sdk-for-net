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
using Microsoft.WindowsAzure.WebSitesExtensions;

namespace Microsoft.WindowsAzure
{
    public static class WebSiteExtensionsDiscoveryExtensions
    {
        public static WebSiteExtensionsClient CreateWebSiteExtensionsClient(this CloudClients clients, BasicAuthenticationCloudCredentials credentials, string siteName)
        {
            return new WebSiteExtensionsClient(siteName, credentials);
        }

        public static WebSiteExtensionsClient CreateWebSiteExtensionsClient(this CloudClients clients, BasicAuthenticationCloudCredentials credentials, string siteName, Uri baseUri)
        {
            return new WebSiteExtensionsClient(siteName, credentials, baseUri);
        }

        public static WebSiteExtensionsClient CreateWebSiteExtensionsClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<WebSiteExtensionsClient>(WebSiteExtensionsClient.Create);
        }
    }
}

namespace Microsoft.WindowsAzure.WebSitesExtensions
{
    public partial class WebSiteExtensionsClient
    {
        public static WebSiteExtensionsClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            BasicAuthenticationCloudCredentials credentials = ConfigurationHelper.GetCredentials<BasicAuthenticationCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);
            
            string siteName = ConfigurationHelper.GetString(settings, "SiteName", false);

            if (baseUri != null && siteName != null)
            {
                return new WebSiteExtensionsClient(siteName, credentials, baseUri);
            }
            else if (siteName != null)
            {
                return new WebSiteExtensionsClient(siteName, credentials);		 
            }

            throw new ArgumentNullException();
        }

        public override WebSiteExtensionsClient WithHandler(DelegatingHandler handler)
        {
            return (WebSiteExtensionsClient)WithHandler(new WebSiteExtensionsClient(), handler);
        }
    }
}
