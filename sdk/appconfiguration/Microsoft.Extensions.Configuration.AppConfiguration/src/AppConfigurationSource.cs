// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.AppConfiguration;

namespace Microsoft.Extensions.Configuration.AppConfiguration
{
    /// <summary>
    /// Represents Azure App Configuration settings as an <see cref="IConfigurationSource"/>.
    /// </summary>
    internal class AppConfigurationSource : IConfigurationSource
    {
        private readonly AppConfigurationOptions _options;
        private readonly ConfigurationClient _client;

        /// <summary>
        /// Creates a new instance of <see cref="AppConfigurationSource"/>.
        /// </summary>
        /// <param name="client">The <see cref="ConfigurationClient"/> to use for retrieving values.</param>
        /// <param name="options">The <see cref="AppConfigurationOptions"/> to configure provider behaviors.</param>
        public AppConfigurationSource(ConfigurationClient client, AppConfigurationOptions options)
        {
            _options = options;
            _client = client;
        }

        /// <inheritdoc />
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new AppConfigurationProvider(_client, _options);
        }
    }
}
