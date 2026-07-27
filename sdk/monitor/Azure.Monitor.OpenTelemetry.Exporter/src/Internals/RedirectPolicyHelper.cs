// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class RedirectPolicyHelper
    {
        private static readonly string[] s_allowedRedirectDomainSuffixes =
        {
            ".livediagnostics.monitor.azure.com",
            ".monitor.azure.com",
            ".services.visualstudio.com",
            ".applicationinsights.azure.com",
            ".monitor.azure.us",
            ".applicationinsights.azure.us",
            ".monitor.azure.cn",
            ".applicationinsights.azure.cn",
        };

        internal static bool IsTrustedIngestionRedirect(Uri currentUri, Uri redirectUri)
        {
            if (!IsValidHttpsRedirect(redirectUri) || !currentUri.IsAbsoluteUri)
            {
                return false;
            }

            string currentHost = GetCanonicalHost(currentUri);
            string redirectHost = GetCanonicalHost(redirectUri);
            if (string.IsNullOrEmpty(currentHost) || string.IsNullOrEmpty(redirectHost))
            {
                return false;
            }

            if (string.Equals(currentHost, redirectHost, StringComparison.Ordinal))
            {
                return string.Equals(currentUri.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)
                    && currentUri.Port == redirectUri.Port;
            }

            if (!currentUri.IsDefaultPort || !redirectUri.IsDefaultPort)
            {
                return false;
            }

            foreach (string suffix in s_allowedRedirectDomainSuffixes)
            {
                if (currentHost.EndsWith(suffix, StringComparison.Ordinal)
                    && redirectHost.EndsWith(suffix, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        internal static bool IsTrustedLiveMetricsRedirect(Uri redirectUri)
        {
            if (!IsValidHttpsRedirect(redirectUri) || !redirectUri.IsDefaultPort)
            {
                return false;
            }

            string redirectHost = GetCanonicalHost(redirectUri);
            foreach (string suffix in s_allowedRedirectDomainSuffixes)
            {
                if (redirectHost.EndsWith(suffix, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValidHttpsRedirect(Uri redirectUri) =>
            redirectUri.IsAbsoluteUri
            && string.Equals(redirectUri.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)
            && string.IsNullOrEmpty(redirectUri.UserInfo);

        private static string GetCanonicalHost(Uri uri) => uri.IdnHost.TrimEnd('.').ToLowerInvariant();
    }
}