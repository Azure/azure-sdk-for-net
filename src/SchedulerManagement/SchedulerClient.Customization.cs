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
using Microsoft.WindowsAzure.Scheduler;

namespace Microsoft.WindowsAzure
{
    public static class SchedulerDiscoveryExtensions
    {
        public static SchedulerClient CreateSchedulerClient(this CloudClients clients, SubscriptionCloudCredentials credentials, string cloudServiceName, string jobCollectionName)
        {
            return new SchedulerClient(credentials, cloudServiceName, jobCollectionName);
        }

        public static SchedulerClient CreateSchedulerClient(this CloudClients clients, SubscriptionCloudCredentials credentials, string cloudServiceName, string jobCollectionName, Uri baseUri)
        {
            return new SchedulerClient(credentials, cloudServiceName, jobCollectionName, baseUri);
        }

        public static SchedulerClient CreateSchedulerClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<SchedulerClient>(SchedulerClient.Create);
        }
    }
}

namespace Microsoft.WindowsAzure.Scheduler
{
    public partial class SchedulerClient
    {
        public static SchedulerClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            string cloudServiceName = ConfigurationHelper.GetString(settings, "CloudServiceName", true);
            string jobCollectionName = ConfigurationHelper.GetString(settings, "JobCollectionName", true);
            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new SchedulerClient(credentials, cloudServiceName, jobCollectionName, baseUri) :
                new SchedulerClient(credentials, cloudServiceName, jobCollectionName);
        }

        protected override void Clone(ServiceClient<SchedulerClient> client)
        {
            base.Clone(client);
            SchedulerClient management = client as SchedulerClient;
            if (management != null)
            {
                management._credentials = Credentials;
                management._cloudServiceName = CloudServiceName;
                management._jobCollectionName = JobCollectionName;
                management._baseUri = BaseUri;
                management.Credentials.InitializeServiceClient(management);
            }
        }

        public SchedulerClient WithHandler(DelegatingHandler handler)
        {
            return (SchedulerClient)WithHandler(new SchedulerClient(), handler);
        }
    }
}
