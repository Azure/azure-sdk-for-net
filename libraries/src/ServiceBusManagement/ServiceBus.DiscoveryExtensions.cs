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
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.WindowsAzure.Management.ServiceBus
{
    public static class ServiceBusManagementDiscoveryExtensions
    {
        public static ServiceBusManagementClient CreateServiceBusManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials)
        {
            return new ServiceBusManagementClient(credentials);
        }

        public static ServiceBusManagementClient CreateServiceBusManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials, Uri baseUri)
        {
            return new ServiceBusManagementClient(credentials, baseUri);
        }

        public static ServiceBusManagementClient CreateServiceBusManagementClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<ServiceBusManagementClient>(ServiceBusManagementClient.Create);
        }
    }
}
