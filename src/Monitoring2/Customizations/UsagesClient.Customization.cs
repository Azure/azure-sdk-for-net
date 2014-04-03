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

using Microsoft.WindowsAzure.Common;
using System.Net.Http;

namespace Microsoft.WindowsAzure.Management.Monitoring.Usages
{
    public partial class UsagesClient
    {
        /// <summary>
        /// Get an instance of the MetricClient class that uses the handler while initiating web requests.
        /// </summary>
        /// <param name="handler">the handler</param>
        public override UsagesClient WithHandler(DelegatingHandler handler)
        {
            return WithHandler(new UsagesClient(), handler);
        }

        protected override void Clone(ServiceClient<UsagesClient> client)
        {
            base.Clone(client);

            UsagesClient usageClient = client as UsagesClient;
            if (usageClient != null)
            {
                usageClient._credentials = Credentials;
                usageClient._baseUri = BaseUri;
                usageClient.Credentials.InitializeServiceClient(usageClient);
            }
        }
    }
}
