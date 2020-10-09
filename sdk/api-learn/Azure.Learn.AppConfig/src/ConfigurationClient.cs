// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Learn.AppConfig
{
    /// <summary>
    /// The <see cref="ConfigurationClient"/>.
    /// </summary>
    public class ConfigurationClient
    {
        private readonly Uri _endpoint;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ServiceRestClient _restClient;

        /// <summary>Initializes a new instance of the <see cref="ConfigurationClient"/>.</summary>
        public ConfigurationClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new ConfigurationClientOptions())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConfigurationClient"/>.</summary>
        public ConfigurationClient(Uri endpoint, TokenCredential credential, ConfigurationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            // Add the authentication policy to our builder.
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, GetDefaultScope(endpoint)));

            // Initialize the ClientDiagnostics.
            _clientDiagnostics = new ClientDiagnostics(options);

            // Initialize the Rest Client.
            _restClient = new ServiceRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri, options.Version);
        }

        /// <summary> Initializes a new instance of ConfigurationClient for mocking. </summary>
        protected ConfigurationClient()
        {
        }

        /// <summary>Retrieve a <see cref="ConfigurationSetting"/> from the configuration store.</summary>
        public virtual Response<ConfigurationSetting> GetConfigurationSetting(string key, string label = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>Retrieve a <see cref="ConfigurationSetting"/> from the configuration store.</summary>
        public virtual async Task<Response<ConfigurationSetting>> GetConfigurationSettingAsync(string key, string label = null, CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        /// <summary>Conditionally retrieve a <see cref="ConfigurationSetting"/> from the configuration store if the setting has been changed since it was last retrieved.</summary>
        public virtual Response<ConfigurationSetting> GetConfigurationSetting(ConfigurationSetting setting, bool onlyIfChanged = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>Conditionally retrieve a <see cref="ConfigurationSetting"/> from the configuration store if the setting has been changed since it was last retrieved.</summary>
        public virtual async Task<Response<ConfigurationSetting>> GetConfigurationSettingAsync(ConfigurationSetting setting, bool onlyIfChanged = false, CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        // A helper method to construct the default scope based on the service endpoint.
        private static string GetDefaultScope(Uri uri)
            => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";
    }
}
