// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Configures <see cref="WebPubSubServiceAccessOptions"/> by reading from the default configuration section.
    /// </summary>
    internal class WebPubSubServiceAccessOptionsSetup : IConfigureOptions<WebPubSubServiceAccessOptions>
    {
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _azureComponentFactory;
        private readonly INameResolver _nameResolver;
        private readonly IOptionsMonitor<WebPubSubFunctionsOptions> _publicOptions;

        public WebPubSubServiceAccessOptionsSetup(
            IConfiguration configuration,
            AzureComponentFactory azureComponentFactory,
            INameResolver nameResolver,
            IOptionsMonitor<WebPubSubFunctionsOptions> publicOptions)
        {
            _configuration = configuration;
            _azureComponentFactory = azureComponentFactory;
            _nameResolver = nameResolver;
            _publicOptions = publicOptions;
        }

        public void Configure(WebPubSubServiceAccessOptions options)
        {
            var publicOptions = _publicOptions.CurrentValue;

            // WebPubSubFunctionsOptions.ConnectionString can be set via code only. Takes the highest priority.
            if (!string.IsNullOrEmpty(publicOptions.ConnectionString))
            {
                options.WebPubSubAccess = WebPubSubServiceAccessUtil.CreateFromConnectionString(publicOptions.ConnectionString);
            }
            else
            {
                var defaultSection = _configuration.GetSection(Constants.WebPubSubConnectionStringName);
                if (WebPubSubServiceAccessUtil.CreateFromIConfiguration(defaultSection, _azureComponentFactory, out var access))
                {
                    options.WebPubSubAccess = access!;
                }
            }

            // Only configure Hub from the default config section if not already set
            options.Hub = publicOptions.Hub ?? _nameResolver.Resolve(Constants.HubNameStringName);
        }
    }
}
