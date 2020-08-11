// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Services.AppAuthentication
{
    internal class UriHelper
    {
        /// <summary>
        /// Given an Azure AD authority URL, returns the instance URL from it
        /// </summary>
        /// <param name="authority">Azure AD authority e.g. https://login.microsoftonline.com/tenantID</param>
        /// <returns>Instance URL if the authority is valid, else null</returns>
        internal static string GetAzureAdInstanceByAuthority(string authority)
        {
            if (!string.IsNullOrWhiteSpace(authority))
            {
                Uri authorityUri;
                if (Uri.TryCreate(authority, UriKind.Absolute, out authorityUri))
                {
                    if (authorityUri.Scheme != "https")
                    {
                        return null;
                    }

                    string path = authorityUri.AbsolutePath.Substring(1);
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        return null;
                    }

                    return $"https://{authorityUri.Host}/";
                }
            }

            return null;
        }

        /// <summary>
        /// Given an Azure AD authority URL, returns the tenant from it
        /// </summary>
        /// <param name="authority">Azure AD authority e.g. https://login.microsoftonline.com/tenantID</param>
        /// <returns>Tenant if the authority is valid and has tenant information, else null</returns>
        internal static string GetTenantByAuthority(string authority)
        {
            if (!string.IsNullOrWhiteSpace(authority))
            {
                Uri authorityUri;

                if (Uri.TryCreate(authority, UriKind.Absolute, out authorityUri))
                {
                    if (authorityUri?.Segments.Length >= 2)
                    {
                        return authorityUri.Segments[1].TrimEnd('/');
                    }
                }
            }

            return null;
        }
    }
}
