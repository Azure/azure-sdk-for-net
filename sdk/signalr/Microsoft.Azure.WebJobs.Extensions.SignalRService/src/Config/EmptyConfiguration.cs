// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// This configuration does nothing but provides a reload token from a real <see cref="IConfiguration"/> object.
    /// It aims to trigger a configuration reload of <see cref="ServiceHubContext"/> when the real configuration changes. As the <see cref="ServiceManagerBuilder"/> doesn't provide an API to inject an <see cref="IOptionsChangeTokenSource{ServiceManagerOptions}"/> and it has a different way to read configuration with function extensions, we have to inject an empty configuration via <see cref="ServiceManagerBuilder.WithConfiguration(IConfiguration)"/> to provide a reload token and does actual configuration parsing via <see cref="ServiceManagerBuilder.WithOptions(Action{ServiceManagerOptions})"/>.
    /// </summary>
    internal class EmptyConfiguration : IConfiguration
    {
        private static readonly IConfiguration EmptyImpl = new ConfigurationBuilder().AddInMemoryCollection().Build();
        private readonly IConfiguration _configuration;

        public EmptyConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string this[string key] { get => null; set { } }

        public IEnumerable<IConfigurationSection> GetChildren() => Array.Empty<IConfigurationSection>();

        public IChangeToken GetReloadToken() => _configuration.GetReloadToken();

        public IConfigurationSection GetSection(string key) => EmptyImpl.GetSection(key);
    }
}
