// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Host.Config
{
    internal class CoreWebJobsOptionsSetup<TOptions> : IConfigureOptions<TOptions> where TOptions : class
    {
        private readonly IConfiguration _configuration;

        public CoreWebJobsOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Configure(TOptions options)
        {
            IConfiguration rootSection = _configuration.GetWebJobsRootConfiguration();

            rootSection.Bind(options);
        }
    }
}
