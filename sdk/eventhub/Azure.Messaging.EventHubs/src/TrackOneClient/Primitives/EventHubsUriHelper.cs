// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace TrackOne
{
    internal static class EventHubsUriHelper
    {
        internal static string NormalizeUri(string uri, string scheme, bool stripQueryParameters = true, bool stripPath = false, bool ensureTrailingSlash = false)
        {
            UriBuilder uriBuilder = new UriBuilder(uri)
            {
                Scheme = scheme,
                Port = -1,
                Fragment = string.Empty,
                Password = string.Empty,
                UserName = string.Empty,
            };

            if (stripPath)
            {
                uriBuilder.Path = string.Empty;
            }

            if (stripQueryParameters)
            {
                uriBuilder.Query = string.Empty;
            }

            if (ensureTrailingSlash)
            {
                if (!uriBuilder.Path.EndsWith("/", StringComparison.Ordinal))
                {
                    uriBuilder.Path += "/";
                }
            }

            return uriBuilder.Uri.AbsoluteUri;
        }
    }
}
