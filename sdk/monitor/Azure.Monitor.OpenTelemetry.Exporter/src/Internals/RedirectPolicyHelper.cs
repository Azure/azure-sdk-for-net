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

            if (!TryGetCanonicalHost(currentUri, out var currentHost) || !TryGetCanonicalHost(redirectUri, out var redirectHost))
            {
                return false;
            }

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

        /// <summary>
        /// Whether a host is one Azure Monitor ingestion answers on, for deciding what may be sent
        /// an Entra ID token when the destination came from telemetry rather than configuration.
        /// </summary>
        internal static bool IsTrustedIngestionHost(string canonicalHost)
        {
            foreach (string suffix in s_allowedRedirectDomainSuffixes)
            {
                if (canonicalHost.EndsWith(suffix, StringComparison.Ordinal))
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

            return TryGetCanonicalHost(redirectUri, out var redirectHost) && IsTrustedIngestionHost(redirectHost);
        }

        private static bool IsValidHttpsRedirect(Uri redirectUri) =>
            redirectUri.IsAbsoluteUri
            && string.Equals(redirectUri.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)
            && string.IsNullOrEmpty(redirectUri.UserInfo);

        /// <remarks>
        /// <see cref="Uri.IdnHost"/> throws on a malformed punycode label. A redirect target is
        /// chosen by whatever answered the request, so the input is not ours to trust.
        /// </remarks>
        internal static bool TryGetCanonicalHost(Uri uri, out string host)
        {
            try
            {
                host = uri.IdnHost.TrimEnd('.').ToLowerInvariant();
                return true;
            }
            catch (UriFormatException)
            {
                host = string.Empty;
                return false;
            }
        }
    }
}