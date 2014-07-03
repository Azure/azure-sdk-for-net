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

namespace Microsoft.WindowsAzure
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using Microsoft.WindowsAzure.Common;
    using Microsoft.WindowsAzure.Common.Internals;
    using Microsoft.WindowsAzure.Management.Network;

    public static class NetworkManagementDiscoveryExtensions
    {
        public static NetworkManagementClient CreateVirtualNetworkManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials)
        {
            return new NetworkManagementClient(credentials);
        }

        public static NetworkManagementClient CreateVirtualNetworkManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials, Uri baseUri)
        {
            return new NetworkManagementClient(credentials, baseUri);
        }

        public static NetworkManagementClient CreateVirtualNetworkManagementClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<NetworkManagementClient>(NetworkManagementClient.Create);
        }
    }
}

namespace Microsoft.WindowsAzure.Management.Network
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using Microsoft.WindowsAzure.Common;
    using Microsoft.WindowsAzure.Common.Internals;

    public partial class NetworkManagementClient
    {
        public static NetworkManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new NetworkManagementClient(credentials, baseUri) :
                new NetworkManagementClient(credentials);
        }

       public override NetworkManagementClient WithHandler(DelegatingHandler handler)
        {
            return (NetworkManagementClient)WithHandler(new NetworkManagementClient(), handler);
        }
    }
}
