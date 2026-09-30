// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Relationships
{
    // Remove this workaround after regenerating with the fix for:
    // https://github.com/Azure/azure-sdk-for-net/issues/63507 (relative continuation tokens).
    internal static class RelationshipsPaging
    {
        internal static string NormalizeContinuationToken(string continuationToken, Uri endpoint)
        {
            if (continuationToken == null)
            {
                return null;
            }

            var uri = new Uri(continuationToken, UriKind.RelativeOrAbsolute);
            return uri.IsAbsoluteUri ? continuationToken : new Uri(endpoint, uri).AbsoluteUri;
        }
    }
}
