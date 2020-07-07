// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Configuration;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host.Config
{
    internal class WebJobsExtensionConfiguration<T> : IWebJobsExtensionConfiguration<T> where T : IExtensionConfigProvider
    {
        private readonly IConfiguration _configuration;
        private readonly Lazy<IConfigurationSection> _configSection;

        public WebJobsExtensionConfiguration(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _configSection = new Lazy<IConfigurationSection>(BuildConfiguration);
        }

        private IConfigurationSection BuildConfiguration()
        {
            return Utility.GetExtensionConfigurationSection<T>(_configuration);
        }

        public IConfigurationSection ConfigurationSection => _configSection.Value;
    }
}
