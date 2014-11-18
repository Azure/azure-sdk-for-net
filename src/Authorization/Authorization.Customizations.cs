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

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common.Internals;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.Azure.Management.Authorization
{
    public partial class AuthorizationManagementClient
    {
        public static AuthorizationManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            AnonymousCloudCredentials credentials = ConfigurationHelper.GetCredentials<AnonymousCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new AuthorizationManagementClient(credentials, baseUri) :
                new AuthorizationManagementClient(credentials);
        }
        public override AuthorizationManagementClient WithHandler(DelegatingHandler handler)
        {
            return (AuthorizationManagementClient)WithHandler(new AuthorizationManagementClient(), handler);
        }
    }
}
