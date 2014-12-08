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

using Microsoft.WindowsAzure.Management.RecoveryServices;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;


namespace Microsoft.Azure
{
    public static class RecoveryServicesManagementDiscoveryExtensions
    {
        public static RecoveryServicesManagementClient CreateRecoveryServicesManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials)
        {
            return new RecoveryServicesManagementClient(credentials);
        }

        public static RecoveryServicesManagementClient CreateRecoveryServicesManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials, Uri baseUri)
        {
            return new RecoveryServicesManagementClient(credentials, baseUri);
        }

        public static RecoveryServicesManagementClient CreateRecoveryServicesManagementClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<RecoveryServicesManagementClient>(RecoveryServicesManagementClient.Create);
        }
    }
}

namespace Microsoft.WindowsAzure.Management.RecoveryServices
{
    public partial class RecoveryServicesManagementClient
    {
        public static RecoveryServicesManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new RecoveryServicesManagementClient(credentials, baseUri) :
                new RecoveryServicesManagementClient(credentials);
        }

        public override RecoveryServicesManagementClient WithHandler(DelegatingHandler handler)
        {
            return (RecoveryServicesManagementClient)WithHandler(new RecoveryServicesManagementClient(), handler);
        }
    }
}
