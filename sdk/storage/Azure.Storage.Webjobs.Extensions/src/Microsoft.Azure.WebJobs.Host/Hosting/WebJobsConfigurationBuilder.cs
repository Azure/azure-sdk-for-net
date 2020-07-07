// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Hosting
{
    internal class WebJobsConfigurationBuilder : IWebJobsConfigurationBuilder
    {
        public WebJobsConfigurationBuilder(IConfigurationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            ConfigurationBuilder = new TrackedConfigurationBuilder(builder);
        }

        public IConfigurationBuilder ConfigurationBuilder { get; private set; }
    }
}
