// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.Scheduler;
using Microsoft.Rest;
using Scheduler.Test.Helpers;
using System;

namespace Scheduler.Test.InMemoryTests
{
    public class Base
    {
        protected SchedulerManagementClient GetSchedulerManagementClient(RecordedDelegatingHandler handler)
        {
            var tokenCredential = new TokenCredentials(Guid.NewGuid().ToString(), "abc123");
            handler.IsPassThrough = false;
            var schedulerManagementClient = new SchedulerManagementClient(credentials: tokenCredential, handlers: handler);
            schedulerManagementClient.SubscriptionId = "12345";
            return schedulerManagementClient;
        }
    }
}
