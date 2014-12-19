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
using Microsoft.Azure.Common.Extensions.Properties;
using System;
using System.Security;
using System.Windows.Forms;

namespace Microsoft.Azure.Common.Extensions.Authentication
{
    /// <summary>
    /// A token provider that uses ADAL to retrieve
    /// tokens from Azure Active Directory
    /// </summary>
    public class AdalTokenProvider : ITokenProvider
    {
        private readonly ITokenProvider userTokenProvider;
        private readonly ITokenProvider servicePrincipalTokenProvider;

        public AdalTokenProvider()
            : this(new ConsoleParentWindow())
        {
        }

        public AdalTokenProvider(IWin32Window parentWindow)
        {
            this.userTokenProvider = new UserTokenProvider(parentWindow);
            servicePrincipalTokenProvider = new ServicePrincipalTokenProvider();
        }

        public IAccessToken GetAccessToken(AdalConfiguration config, ShowDialog promptBehavior, string userId, SecureString password,
            AzureAccount.AccountType credentialType)
        {
            switch (credentialType)
            {
                case AzureAccount.AccountType.User:
                    return userTokenProvider.GetAccessToken(config, promptBehavior, userId, password, credentialType);
                case AzureAccount.AccountType.ServicePrincipal:
                    return servicePrincipalTokenProvider.GetAccessToken(config, promptBehavior, userId, password, credentialType);
                default:
                    throw new ArgumentException(Resources.UnknownCredentialType, "credentialType");
            }
        }
   }
}
