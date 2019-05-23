// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AlertsManagement.Tests.Helpers;
using Microsoft.Azure.Management.AlertsManagement;
using Microsoft.Rest;

namespace AlertsManagement.Tests.UnitTests
{
    public class TestBase
    {
        protected AlertsManagementClient GetAlertsManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var tokenProvider = new StringTokenProvider("granted", "SimpleString");
            var id = Guid.NewGuid().ToString();
            var token = new TokenCredentials(tokenProvider: tokenProvider, tenantId: id, callerId: id);
            var client = new AlertsManagementClient(token, handler);
            token.InitializeServiceClient(client);
            client.SubscriptionId = id;

            return client;
        }
    }
}
