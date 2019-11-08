// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Tests
{
    internal static class UriExtensions
    {
        internal static Uri ToHttps(this Uri uri)
        {
            if (uri == null)
            {
                return null;
            }

            UriBuilder uriBuilder = new UriBuilder(uri);
            uriBuilder.Scheme = "https";
            uriBuilder.Port = 443;
            return uriBuilder.Uri;
        }
    }
}
