// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Chaos.Tests.TestDependencies.Utilities
{
    internal static class UrlUtility
    {
        internal static string GetStatusId(string url)
        {
            return url.Substring(url.IndexOf("statuses", StringComparison.OrdinalIgnoreCase)).Split('/')[1].Split('?')[0];
        }

        internal static string GetDetailsId(string url)
        {
            return url.Substring(url.IndexOf("executionDetails", StringComparison.OrdinalIgnoreCase)).Split('/')[1].Split('?')[0];
        }
    }
}
