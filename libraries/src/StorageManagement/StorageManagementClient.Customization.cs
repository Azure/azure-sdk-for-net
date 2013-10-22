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
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure
{
    public static class StorageManagementDiscoveryExtensions
    {
        public static StorageManagementClient CreateStorageManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials)
        {
            return new StorageManagementClient(credentials);
        }

        public static StorageManagementClient CreateStorageManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials, Uri baseUri)
        {
            return new StorageManagementClient(credentials, baseUri);
        }

        public static StorageManagementClient CreateStorageManagementClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<StorageManagementClient>(StorageManagementClient.Create);
        }
    }
}

namespace Microsoft.WindowsAzure.Management.Storage
{
    public partial class StorageManagementClient
    {
        public static StorageManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new StorageManagementClient(credentials, baseUri) :
                new StorageManagementClient(credentials);
        }

        protected override void Clone(ServiceClient<StorageManagementClient> client)
        {
            base.Clone(client);
            StorageManagementClient management = client as StorageManagementClient;
            if (management != null)
            {
                management._credentials = Credentials;
                management._baseUri = BaseUri;
                management.Credentials.InitializeServiceClient(management);
            }
        }

        public StorageManagementClient WithHandler(DelegatingHandler handler)
        {
            return (StorageManagementClient)WithHandler(new StorageManagementClient(), handler);
        }
    }
}
