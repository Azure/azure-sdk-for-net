// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Common.Extensions.Authentication;
using Microsoft.Azure.Common.Extensions.Models;
using Microsoft.WindowsAzure;
using System.Security;

namespace Microsoft.Azure.Common.Extensions
{
    public interface IAuthenticationFactory
    {
        /// <summary>
        /// Returns IAccessToken if authentication succeeds or throws an exception if authentication fails.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="environment"></param>
        /// <param name="tenant"></param>
        /// <param name="password"></param>
        /// <param name="promptBehavior"></param>
        /// <returns></returns>
        IAccessToken Authenticate(AzureAccount account, AzureEnvironment environment, string tenant, SecureString password, ShowDialog promptBehavior);

        SubscriptionCloudCredentials GetSubscriptionCloudCredentials(AzureContext context);
    }
}
