// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.Extensions.Azure.Samples
{
    internal class DependencyInjectionEnabledPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly IHostingEnvironment _environment;

        public DependencyInjectionEnabledPolicy(IHostingEnvironment environment)
        {
            this._environment = environment;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Headers.Add("application-name", _environment.ApplicationName);
            base.OnSendingRequest(message);
        }
    }
}