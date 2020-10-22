// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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
        private ClientDiagnostics _clientDiagnostics;
        private ServiceRestClient _restClient;


        /// <summary>Initializes a new instance of the <see cref="ConfigurationClient"/>.</summary>
        public ConfigurationClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new ConfigurationClientOptions())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConfigurationClient"/>.</summary>
#pragma warning disable CA1801 // Parameter is never used
        public ConfigurationClient(Uri endpoint, TokenCredential credential, ConfigurationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            // Add the authentication policy to our builder.
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, GetDefaultScope(endpoint)));

            // Initialize the ClientDiagnostics.
            _clientDiagnostics = new ClientDiagnostics(options);

            _endpoint = endpoint;

            // Initialize the Rest Client.
            _restClient = new ServiceRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri, options.Version);
        }
#pragma warning restore CA1801 // Parameter is never used

        /// <summary> Initializes a new instance of ConfigurationClient for mocking. </summary>
        protected ConfigurationClient()
        {
        }

        /// <summary>Retrieve a <see cref="ConfigurationSetting"/> from the configuration store.</summary>
        public virtual Response<ConfigurationSetting> GetConfigurationSetting(string key, string label = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            var result = _restClient.GetKeyValue(key, label, cancellationToken: cancellationToken);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        /// <summary>
        /// The token
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Pageable<ConfigurationSetting> GetConfigurationSettings(CancellationToken cancellationToken = default)
        {
            var result = _restClient.GetKeyValues();

            Page<ConfigurationSetting> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetConfigurationSetting)}");
                scope.Start();

                try
                {
                    var response = _restClient.GetKeyValues(cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ConfigurationSetting> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetConfigurationSetting)}");
                scope.Start();

                try
                {
                    var parameters = HttpUtility.ParseQueryString(nextLink);
                    var response = _restClient.GetKeyValues(after: parameters["after"], cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>Retrieve a <see cref="ConfigurationSetting"/> from the configuration store.</summary>
        public virtual async Task<Response<ConfigurationSetting>> GetConfigurationSettingAsync(string key, string label = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetConfigurationSetting)}");
            scope.AddAttribute(nameof(key), key);
            scope.Start();

            try
            {
                var result = await _restClient.GetKeyValueAsync(key, label, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(result.Value, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Conditionally retrieve a <see cref="ConfigurationSetting"/> from the configuration store if the setting has been changed since it was last retrieved.</summary>
        public virtual Response<ConfigurationSetting> GetConfigurationSetting(ConfigurationSetting setting, bool onlyIfChanged = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>Conditionally retrieve a <see cref="ConfigurationSetting"/> from the configuration store if the setting has been changed since it was last retrieved.</summary>
        public virtual async Task<Response<ConfigurationSetting>> GetConfigurationSettingAsync(ConfigurationSetting setting, bool onlyIfChanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetConfigurationSetting)}");
            scope.AddAttribute(nameof(setting.Key), setting.Key);
            scope.Start();

            try
            {
                var ifNoneMatch = onlyIfChanged switch
                {
                    true => FormatETag(setting.ETag),
                    false => default
                };
                var result = await _restClient.GetKeyValueAsync(setting.Key, setting.Label, ifMatch: default, ifNoneMatch: ifNoneMatch, cancellationToken: cancellationToken).ConfigureAwait(false);

                return result.GetRawResponse().Status switch
                {
                    304 => Response.FromValue(setting, result.GetRawResponse()),
                    _ => Response.FromValue(result.Value, result.GetRawResponse())
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// upsert configuration settings
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="label">The label</param>
        /// <param name="entity">The setting</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public virtual Response<ConfigurationSetting> SetConfigurationSetting(string key, string label = null, ConfigurationSetting entity = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            var result = _restClient.PutKeyValue(key, label, null, null, entity, cancellationToken: cancellationToken);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        // A helper method to construct the default scope based on the service endpoint.
        private static string GetDefaultScope(Uri uri)
            => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";

        private static string FormatETag(ETag etag)
            => $"\"{etag}\"";
    }
}
