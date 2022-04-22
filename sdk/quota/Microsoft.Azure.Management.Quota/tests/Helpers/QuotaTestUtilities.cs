// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;

namespace Microsoft.Azure.Management.Quota.Tests.Helpers
{
    public static class QuotaTestUtilities
    {
        public static AzureQuotaExtensionAPIClient GetAzureQuotaExtensionAPIClient(
            MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            var client = context.GetServiceClient<AzureQuotaExtensionAPIClient>(handlers:
                handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
            return client;
        }
    }
}
