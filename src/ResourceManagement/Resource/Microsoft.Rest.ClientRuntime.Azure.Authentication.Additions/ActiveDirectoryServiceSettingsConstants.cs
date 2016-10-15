// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Microsoft.Rest.Azure.Authentication
{
    public static class ActiveDirectoryServiceSettingsConstants
    {
        public static ActiveDirectoryServiceSettings AzureGermanCloud
            =>
                new ActiveDirectoryServiceSettings
                {
                    AuthenticationEndpoint = new Uri("https://login.microsoftonline.de/"),
                    ValidateAuthority = true,
                    TokenAudience = new Uri("https://management.core.cloudapi.de/")
                };

        public static ActiveDirectoryServiceSettings AzureUSGovernmentCloud
            =>
                new ActiveDirectoryServiceSettings
                {
                    AuthenticationEndpoint = new Uri("https://login-us.microsoftonline.com/"),
                    ValidateAuthority = true,
                    TokenAudience = new Uri("https://management.core.usgovcloudapi.net/")
                };

    }
}
