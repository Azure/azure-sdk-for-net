// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Rest;

namespace Monitor.Tests.BasicTests
{
    public class TestBase
    {
        protected MonitorManagementClient GetMonitorManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var tokenProvider = new StringTokenProvider("granted", "SimpleString");
            var id = Guid.NewGuid().ToString();
            var token = new TokenCredentials(tokenProvider: tokenProvider, tenantId: id, callerId: id);
            var client = new MonitorManagementClient(token, handler);
            token.InitializeServiceClient(client);
            client.SubscriptionId = id;

            return client;
        }
    }
}
