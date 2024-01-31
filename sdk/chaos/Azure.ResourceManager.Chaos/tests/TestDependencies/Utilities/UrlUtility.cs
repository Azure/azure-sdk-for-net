// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Chaos.Tests.TestDependencies.Utilities
{
    internal static class UrlUtility
    {
        internal static string GetExecutionsId(string url)
        {
            return url.Substring(url.IndexOf("executions", StringComparison.OrdinalIgnoreCase)).Split('/')[1].Split('?')[0];
        }
    }
}
