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

using Microsoft.Azure.Management.Automation;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;


namespace Microsoft.Azure
{
    public static class AutomationManagementDiscoveryExtensions
    {
        public static AutomationManagementClient CreateAutomationManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials)
        {
            return new AutomationManagementClient(credentials);
        }

        public static AutomationManagementClient CreateAutomationManagementClient(this CloudClients clients, SubscriptionCloudCredentials credentials, Uri baseUri)
        {
            return new AutomationManagementClient(credentials, baseUri);
        }

        public static AutomationManagementClient CreateAutomationManagementClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<AutomationManagementClient>(AutomationManagementClient.Create);
        }
    }
}

namespace Microsoft.Azure.Management.Automation
{
    public partial class AutomationManagementClient
    {
        public static AutomationManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new AutomationManagementClient(credentials, baseUri) :
                new AutomationManagementClient(credentials);
        }

        public override AutomationManagementClient WithHandler(DelegatingHandler handler)
        {
            return (AutomationManagementClient)WithHandler(new AutomationManagementClient(), handler);
        }

        public static List<T> ContinuationTokenHandler<T>(Func<string, ResponseWithSkipToken<T>> listFunc)
        {
            var models = new List<T>();
            string skipToken = null;
            do
            {
                var result = listFunc.Invoke(skipToken);
                models.AddRange(result.AutomationManagementModels);
                skipToken = result.SkipToken;
            }
            while (!string.IsNullOrEmpty(skipToken));
            return models;
        }
    }
}
