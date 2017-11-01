using System;

namespace Microsoft.Azure.Services.AppAuthentication
{
    internal class UriHelper
    {
        /// <summary>
        /// Given an Azure AD authority URL, returns the tenant from it
        /// </summary>
        /// <param name="authority">Azure AD authority e.g. https://login.microsoftonline.com/tenantID</param>
        /// <returns>Tenant if the authority is valid and has tenant information, else null</returns>
        internal static string GetTenantByAuthority(string authority)
        {
            if (!string.IsNullOrEmpty(authority))
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
