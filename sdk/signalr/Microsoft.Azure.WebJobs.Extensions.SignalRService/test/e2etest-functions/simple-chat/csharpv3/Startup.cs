// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.SignalR;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(SimpleChatV3.Startup))]
namespace SimpleChatV3
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IEndpointRouter, EndpointRouter>();
        }
    }
}