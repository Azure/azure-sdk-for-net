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

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Common.Authentication.Models
{
    [Serializable]
    public partial class AzureAccount
    {
        public string Id { get; set; }

        public AccountType Type { get; set; }

        public Dictionary<Property, string> Properties { get; set; }

        public enum AccountType
        {
            Certificate,
            User,
            ServicePrincipal,
            AccessToken
        }

        public enum Property
        {
            /// <summary>
            /// Comma separated list of subscription ids on this account.
            /// </summary>
            Subscriptions,

            /// <summary>
            /// Comma separated list of tenants on this account.
            /// </summary>
            Tenants,

            /// <summary>
            /// Access token.
            /// </summary>
            AccessToken,

            /// <summary>
            /// Thumbprint for associated certificate
            /// </summary>
            CertificateThumbprint
        }
    }
}
