// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Search
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    // TODO: Remove once this issue is fixed: https://github.com/Azure/autorest/issues/583
    internal static class UserAgentHelper
    {
        public static void SetUserAgent(HttpClient httpClient, Type serviceClientType)
        {
            httpClient.DefaultRequestHeaders.UserAgent.Clear();
            httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue(serviceClientType.FullName, Consts.AssemblyFileVersion));
        }
    }
}
