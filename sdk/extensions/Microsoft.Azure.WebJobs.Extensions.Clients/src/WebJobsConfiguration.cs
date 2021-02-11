// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Wraps the <see cref="IConfiguration"/> instance and applies fallback rules similar to https://github.com/Azure/azure-webjobs-sdk/blob/dev/src/Microsoft.Azure.WebJobs.Host/Extensions/IConfigurationExtensions.cs.
    /// </summary>
    internal class WebJobsConfiguration : IConfiguration
    {
        private readonly IConfiguration _configuration;

        public WebJobsConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private const string DefaultConfigurationRootSectionName = "AzureWebJobs";

        public string this[string key]
        {
            get => _configuration[key];
            set => _configuration[key] = value;
        }

        public IEnumerable<IConfigurationSection> GetChildren() => _configuration.GetChildren();

        public IChangeToken GetReloadToken() => _configuration.GetReloadToken();

        public IConfigurationSection GetSection(string key)
        {
            var section = _configuration.GetSection(key);
            if (section.Exists())
            {
                return section;
            }

            var prefixedKey = DefaultConfigurationRootSectionName + key;
            section = _configuration.GetSection(prefixedKey);
            if (section.Exists())
            {
                return section;
            }

            return _configuration.GetSection("ConnectionStrings").GetSection(key);
        }
    }
}
