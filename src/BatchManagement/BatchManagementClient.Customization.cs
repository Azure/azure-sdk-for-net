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
using Microsoft.WindowsAzure;
using Microsoft.Azure.Management.Batch;

namespace Microsoft.Azure
{
    public static class BatchManagementDiscoveryExtensions
    {
        public static BatchManagementClient CreateBatchManagementClient(this CloudClients clients, TokenCloudCredentials credentials)
        {
            return new BatchManagementClient(credentials);
        }

        public static BatchManagementClient CreateBatchManagementClient(this CloudClients clients, TokenCloudCredentials credentials, Uri baseUri)
        {
            return new BatchManagementClient(credentials, baseUri);
        }

        public static BatchManagementClient CreateBatchManagementClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<BatchManagementClient>(BatchManagementClient.Create);
        }
    }
}

namespace Microsoft.Azure.Management.Batch
{
    public partial class BatchManagementClient
    {
        public static BatchManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            TokenCloudCredentials credentials = ConfigurationHelper.GetCredentials<TokenCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new BatchManagementClient(credentials, baseUri) :
                new BatchManagementClient(credentials);
        }

        public override BatchManagementClient WithHandler(DelegatingHandler handler)
        {
            return (BatchManagementClient)WithHandler(new BatchManagementClient(), handler);
        }
    }
}
