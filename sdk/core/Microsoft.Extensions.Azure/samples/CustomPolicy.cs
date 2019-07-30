﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Hosting;

namespace Azure.Core.Extensions.Samples
{
    internal class DependencyInjectionEnabledPolicy : SynchronousHttpPipelinePolicy
    {
        private readonly IHostingEnvironment _environment;

        public DependencyInjectionEnabledPolicy(IHostingEnvironment environment)
        {
            this._environment = environment;
        }

        public override void OnSendingRequest(HttpPipelineMessage message)
        {
            message.Request.Headers.Add("application-name", _environment.ApplicationName);
            base.OnSendingRequest(message);
        }
    }
}