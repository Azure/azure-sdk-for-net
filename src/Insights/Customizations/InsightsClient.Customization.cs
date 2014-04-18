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

namespace Microsoft.Azure.Insights
{
    public partial class InsightsClient
    {
        /// <summary>
        /// Get an instance of the AlertsClient class that uses the handler while initiating web requests.
        /// </summary>
        /// <param name="handler">the handler</param>
        public override InsightsClient WithHandler(DelegatingHandler handler)
        {
            return WithHandler(new InsightsClient(), handler);
        }

        protected override void Clone(ServiceClient<InsightsClient> client)
        {
            base.Clone(client);

            InsightsClient insightsClient = client as InsightsClient;
            if (insightsClient != null)
            {
                insightsClient._credentials = Credentials;
                insightsClient._baseUri = BaseUri;
                insightsClient.Credentials.InitializeServiceClient(insightsClient);
            }
        }
    }
}
