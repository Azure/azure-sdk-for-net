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

// Modified from the following source by Mark Cowlishaw <Mark.Cowlishaw@microsoft.com>
// https://github.com/Azure/azure-sdk-for-net/pull/1379/files

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xunit.Sdk;

namespace Compute.Tests
{
    public class AuthenticationHelper
    {
        public static string GetTokenForSpn(string authority, string audience, string domain, string applicationId, string secret)
        {
            var context = new AuthenticationContext(EnsureTrailingSlash(authority) + domain, true, TokenCache.DefaultShared);
            var authResult = context.AcquireToken(audience, new ClientCredential(applicationId, secret));

            return authResult.AccessToken;
        }

        private static string EnsureTrailingSlash(string endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException("endpoint");
            }

            if (!endpoint.EndsWith("/"))
            {
                return endpoint + "/";
            }

            return endpoint;
        }
    }
}
