// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests
{
    public class StronglyTypedServerlessHubTests
    {
        [Fact]
        public async Task NegotiateAsync()
        {
            var serviceManager = new ServiceManagerBuilder().WithOptions(o => o.ConnectionString = FakeEndpointUtils.GetFakeConnectionString(1).Single()).BuildServiceManager();
            var hubContext = await serviceManager.CreateHubContextAsync<IChatClient>("hubName", default);
            var myHub = new TestStronglyTypedHub(hubContext);
            var connectionInfo = await myHub.Negotiate("user");
            Assert.NotNull(connectionInfo);
        }
    }
}
