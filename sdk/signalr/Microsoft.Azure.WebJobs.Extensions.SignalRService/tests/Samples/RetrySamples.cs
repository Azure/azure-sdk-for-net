// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Samples;
public class RetrySamples
{
    #region Snippet:RetryCustomization
    public class RetryStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.Configure<SignalROptions>(o => o.RetryOptions = new ServiceManagerRetryOptions
            {
                Mode = ServiceManagerRetryMode.Exponential,
                MaxDelay = TimeSpan.FromSeconds(30),
                MaxRetries = 5,
                Delay = TimeSpan.FromSeconds(1),
            });
        }
    }
    #endregion
}