// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Samples
{
    public class MessagePack
    {
        #region Snippet:MessagePackCustomization
        public class MessagePackStartup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                builder.Services.Configure<SignalROptions>(o => o.MessagePackHubProtocol = new MessagePackHubProtocol());
            }
        }
        #endregion
    }
}
