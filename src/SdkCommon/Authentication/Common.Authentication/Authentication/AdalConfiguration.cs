// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Class storing the configuration information needed
    /// for ADAL to request token from the right AD tenant
    /// depending on environment.
    /// </summary>
    public class AdalConfiguration
    {
        //
        // These constants define the default values to use for AD authentication
        // against RDFE
        //
        public const string PowerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2";          

        public static readonly Uri PowerShellRedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob");

        // ID for site to pass to enable EBD (email-based differentiation)
        // This gets passed in the call to get the azure branding on the
        // login window. Also adding popup flag to handle overly large login windows.
        public const string EnableEbdMagicCookie = "site_id=501358&display=popup";

        public string AdEndpoint { get;set; }

        public bool ValidateAuthority { get; set; }

        public string AdDomain { get; set; }

        public string ClientId { get; set; }

        public Uri ClientRedirectUri { get; set; }

        public string ResourceClientUri { get; set; }

        public TokenCache TokenCache { get; set; }

        public AdalConfiguration()
        {
            ClientId = PowerShellClientId;
            ClientRedirectUri = PowerShellRedirectUri;
            ValidateAuthority = true;
            AdEndpoint = string.Empty;
            ResourceClientUri = "https://management.core.windows.net/";
        }
    }
}