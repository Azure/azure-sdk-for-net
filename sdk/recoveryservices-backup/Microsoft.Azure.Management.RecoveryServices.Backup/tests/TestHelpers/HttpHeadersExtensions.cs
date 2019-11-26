// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net.Http.Headers;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public static class HttpHeadersExtensions
    {
        public static Uri GetAzureAsyncOperationHeader(this HttpResponseHeaders headers)
        {
            var asyncHeader = headers.GetValues("Azure-AsyncOperation").FirstOrDefault();
            return new Uri(asyncHeader);
        }

        public static string GetAzureAsyncOperationId(this HttpResponseHeaders headers)
        {
            var asyncHeader = headers.GetAzureAsyncOperationHeader();
            return asyncHeader.Segments.Last();
        }
    }
}
