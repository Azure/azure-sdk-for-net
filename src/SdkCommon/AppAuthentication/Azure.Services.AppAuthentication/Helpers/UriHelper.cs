using System;

namespace Microsoft.Azure.Services.AppAuthentication
{
    internal class UriHelper
    {
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
