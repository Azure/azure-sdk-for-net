// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests
{
    public class TestStronglyTypedHub : ServerlessHub<IChatClient>
    {
        public TestStronglyTypedHub(ServiceHubContext<IChatClient> serviceHubContext) : base(serviceHubContext) { }

        [FunctionName("negotiate")]
        public Task<SignalRConnectionInfo> Negotiate(string userId)
        {
            return NegotiateAsync(new() { UserId = userId });
        }

        [FunctionName(nameof(Broadcast))]
        public async Task Broadcast([SignalRTrigger] InvocationContext invocationContext, string message)
        {
            await Clients.All.ReceiveMessage(message);
        }

        internal void TestFunction([SignalRTrigger] InvocationContext context, string arg0, int arg1)
        {
        }

        internal void TestFunctionWithIgnore([SignalRTrigger] InvocationContext context, string arg0, int arg1, [SignalRIgnore] int arg2)
        {
        }

        internal void TestFunctionWithSpecificType([SignalRTrigger] InvocationContext context, string arg0, int arg1, ILogger logger, CancellationToken token)
        {
        }

        internal void OnConnected([SignalRTrigger] InvocationContext context, string arg0, int arg1)
        {
        }

        internal void OnDisconnected([SignalRTrigger] InvocationContext context, string arg0, int arg1)
        {
        }
    }
}
