﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Common.Extensions.Models;
using System.Security;

namespace Microsoft.Azure.Common.Extensions.Authentication
{
    /// <summary>
    /// This interface represents objects that can be used
    /// to obtain and manage access tokens.
    /// </summary>
    public interface ITokenProvider
    {
        /// <summary>
        /// Get a new login token for the given environment, user credential,
        /// and credential type.
        /// </summary>
        /// <param name="config">Configuration.</param>
        /// <param name="promptBehavior">Prompt behavior.</param>
        /// <param name="userId">User ID/Service principal to get the token for.</param>
        /// <param name="password">Secure strings with password/service principal key.</param>
        /// <param name="credentialType">Credential type.</param>
        /// <returns>An access token.</returns>
        IAccessToken GetAccessToken(AdalConfiguration config, ShowDialog promptBehavior, string userId,
            SecureString password, AzureAccount.AccountType credentialType);
    }
}
