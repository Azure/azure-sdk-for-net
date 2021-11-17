// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Trigger.StronglyTypedHub
{
    public class StronglyTypedHubContextStoreTests
    {
        [Fact]
        public void GetStronglyTypedHubContextFact()
        {
            var serviceManager = new ServiceManagerBuilder().WithOptions(o => o.ConnectionString = FakeEndpointUtils.GetFakeConnectionString(1).Single()).BuildServiceManager();
            var hubContext = new ServiceHubContextStore(null, serviceManager).GetAsync<IChatClient>(GetType().Name).Result;
        }
    }
}
