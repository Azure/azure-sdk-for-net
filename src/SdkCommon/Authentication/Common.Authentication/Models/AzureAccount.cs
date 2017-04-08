// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
