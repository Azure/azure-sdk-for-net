﻿//
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

namespace Microsoft.WindowsAzure.Management.Monitoring.Autoscale
{
    public partial class AutoscaleClient
    {
        /// <summary>
        /// Get an instance of the AlertsClient class that uses the handler while initiating web requests.
        /// </summary>
        /// <param name="handler">the handler</param>
        public override AutoscaleClient WithHandler(DelegatingHandler handler)
        {
            return WithHandler(new AutoscaleClient(), handler);
        }

        protected override void Clone(ServiceClient<AutoscaleClient> client)
        {
            base.Clone(client);

            AutoscaleClient autoscaleClient = client as AutoscaleClient;
            if (autoscaleClient != null)
            {
                autoscaleClient._credentials = Credentials;
                autoscaleClient._baseUri = BaseUri;
                autoscaleClient.Credentials.InitializeServiceClient(autoscaleClient);
            }
        }
    }
}
