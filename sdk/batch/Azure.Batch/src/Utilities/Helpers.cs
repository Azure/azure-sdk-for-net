// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Batch.Service.Utilities
{
    internal class Helpers
    {
        // A helper method to construct the default scope based on the service endpoint.
        internal static string GetDefaultScope(Uri uri) => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";
    }
}
