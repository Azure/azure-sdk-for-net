// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Search
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

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
