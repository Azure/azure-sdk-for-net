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
using System.Net.Http;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Subscriptions;

namespace Microsoft.WindowsAzure
{
    public static class SubscriptionDiscoveryExtensions
    {
        public static SubscriptionClient CreateSubscriptionClient(this CloudClients clients, SubscriptionCloudCredentials credentials)
        {
            return new SubscriptionClient(credentials);
        }

        public static SubscriptionClient CreateSubscriptionClient(this CloudClients clients, SubscriptionCloudCredentials credentials, Uri baseUri)
        {
            return new SubscriptionClient(credentials, baseUri);
        }

        public static SubscriptionClient CreateSubscriptionClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<SubscriptionClient>(SubscriptionClient.Create);
        }
    }
}

namespace Microsoft.WindowsAzure.Subscriptions
{
    public partial class SubscriptionClient
    {
        public static SubscriptionClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new SubscriptionClient(credentials, baseUri) :
                new SubscriptionClient(credentials);
        }

        public override SubscriptionClient WithHandler(DelegatingHandler handler)
        {
            return (SubscriptionClient)WithHandler(new SubscriptionClient(), handler);
        }
    }
}
