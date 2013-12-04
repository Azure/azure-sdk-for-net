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
using Microsoft.WindowsAzure.Common.Internals;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.WindowsAzure.Management.Sql
{
    public partial class SqlManagementClient
    {
        public static SqlManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new SqlManagementClient(credentials, baseUri) :
                new SqlManagementClient(credentials);
        }

        protected override void Clone(ServiceClient<SqlManagementClient> client)
        {
            base.Clone(client);
            SqlManagementClient management = client as SqlManagementClient;
            if (management != null)
            {
                management._credentials = Credentials;
                management._baseUri = BaseUri;
                management.Credentials.InitializeServiceClient<SqlManagementClient>(management);
            }
        }

        public SqlManagementClient WithHandler(DelegatingHandler handler)            
        {
            return (SqlManagementClient)WithHandler(new SqlManagementClient(), handler);
        }
    }
}
