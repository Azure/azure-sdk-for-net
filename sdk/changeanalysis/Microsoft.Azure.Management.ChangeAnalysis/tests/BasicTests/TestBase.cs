// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ChangeAnalysis.Tests.Helpers;
using Microsoft.ChangeAnalysis;
using Microsoft.Rest;
using System;

namespace Microsoft.Azure.Management.ChangeAnalysis.Tests.BasicTests
{
    public class TestBase
    {
        protected AzureChangeAnalysisManagementClient GetChangeAnalysisManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var tokenProvider = new StringTokenProvider("granted", "SimpleString");
            var id = Guid.NewGuid().ToString();
            var token = new TokenCredentials(tokenProvider: tokenProvider, tenantId: id, callerId: id);
            var client = new AzureChangeAnalysisManagementClient(token, handler);
            token.InitializeServiceClient(client);
            client.SubscriptionId = id;

            return client;
        }
    }
}
