// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// The client to use for interacting with the Azure Configuration Store.
    /// </summary>
    public partial class ConfigurationClient
    {
        private readonly Uri _endpoint;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected ConfigurationClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationClient"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string with authentication option and related parameters.</param>
        public ConfigurationClient(string connectionString)
            : this(connectionString, new ConfigurationClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationClient"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string with authentication option and related parameters.</param>
        /// <param name="options">Options that allow configuration of requests sent to the configuration store.</param>
        public ConfigurationClient(string connectionString, ConfigurationClientOptions options)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            ParseConnectionString(connectionString, out _endpoint, out var credential, out var secret);

            _pipeline = CreatePipeline(options, new AuthenticationPolicy(credential, secret));

            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The <see cref="Uri"/> referencing the app configuration storage.</param>
        /// <param name="credential">The token credential used to sign requests.</param>
        public ConfigurationClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new ConfigurationClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The <see cref="Uri"/> referencing the app configuration storage.</param>
        /// <param name="credential">The token credential used to sign requests.</param>
        /// <param name="options">Options that allow configuration of requests sent to the configuration store.</param>
        public ConfigurationClient(Uri endpoint, TokenCredential credential, ConfigurationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            _endpoint = endpoint;
            _pipeline = CreatePipeline(options, new BearerTokenAuthenticationPolicy(credential, GetDefaultScope(endpoint)));

            _clientDiagnostics = new ClientDiagnostics(options);
        }

        private static HttpPipeline CreatePipeline(ConfigurationClientOptions options, HttpPipelinePolicy authenticationPolicy)
            => HttpPipelineBuilder.Build(options,
                new HttpPipelinePolicy[] { new CustomHeadersPolicy(), new ApiVersionPolicy(options.GetVersionString()) },
                new HttpPipelinePolicy[] { authenticationPolicy, new SyncTokenPolicy() },
                new ResponseClassifier());

        private static string GetDefaultScope(Uri uri)
            => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> if the setting, uniquely identified by key and label, does not already exist in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="value">The configuration setting's value.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="ConfigurationSetting"/>.</returns>
        public virtual async Task<Response<ConfigurationSetting>> AddConfigurationSettingAsync(string key, string value, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return await AddConfigurationSettingAsync(new ConfigurationSetting(key, value, label), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> if the setting, uniquely identified by key and label, does not already exist in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="value">The configuration setting's value.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="ConfigurationSetting"/>.</returns>
        public virtual Response<ConfigurationSetting> AddConfigurationSetting(string key, string value, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return AddConfigurationSetting(new ConfigurationSetting(key, value, label), cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> only if the setting does not already exist in the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="ConfigurationSetting"/>.</returns>
        public virtual async Task<Response<ConfigurationSetting>> AddConfigurationSettingAsync(ConfigurationSetting setting, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(AddConfigurationSetting)}");
            scope.AddAttribute("key", setting?.Key);
            scope.Start();

            try
            {
                using Request request = CreateAddRequest(setting);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                    case 201:
                        return await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false);
                    case 412:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, "Setting was already present.").ConfigureAwait(false);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> only if the setting does not already exist in the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="ConfigurationSetting"/>.</returns>
        public virtual Response<ConfigurationSetting> AddConfigurationSetting(ConfigurationSetting setting, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(AddConfigurationSetting)}");
            scope.AddAttribute("key", setting?.Key);
            scope.Start();

            try
            {
                using Request request = CreateAddRequest(setting);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                    case 201:
                        return CreateResponse(response);
                    case 412:
                        throw _clientDiagnostics.CreateRequestFailedException(response, "Setting was already present.");
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Request CreateAddRequest(ConfigurationSetting setting)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            Argument.AssertNotNullOrEmpty(setting.Key, $"{nameof(setting)}.{nameof(setting.Key)}");

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = ConfigurationServiceSerializer.SerializeRequestBody(setting);

            request.Method = RequestMethod.Put;

            BuildUriForKvRoute(request.Uri, setting);

            MatchConditions requestOptions = new MatchConditions { IfNoneMatch = ETag.All };
            ConditionalRequestOptionsExtensions.ApplyHeaders(request, requestOptions);

            request.Headers.Add(s_mediaTypeKeyValueApplicationHeader);
            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            return request;
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/>, uniquely identified by key and label, if it doesn't exist or overwrites the existing setting in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="value">The configuration setting's value.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="ConfigurationSetting"/> written to the configuration store.</returns>
        public virtual async Task<Response<ConfigurationSetting>> SetConfigurationSettingAsync(string key, string value, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return await SetConfigurationSettingAsync(new ConfigurationSetting(key, value, label), false, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/>, uniquely identified by key and label, if it doesn't exist or overwrites the existing setting in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="value">The configuration setting's value.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="ConfigurationSetting"/> written to the configuration store.</returns>
        public virtual Response<ConfigurationSetting> SetConfigurationSetting(string key, string value, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return SetConfigurationSetting(new ConfigurationSetting(key, value, label), false, cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> if it doesn't exist or overwrites the existing setting in the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to create.</param>
        /// <param name="onlyIfUnchanged">If set to true and the configuration setting exists in the configuration store, overwrite the setting
        /// if the passed-in <see cref="ConfigurationSetting"/> is the same version as the one in the configuration store.  The setting versions
        /// are the same if their ETag fields match.  If the two settings are different versions, this method will throw an exception to indicate
        /// that the setting in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="ConfigurationSetting"/> written to the configuration store.</returns>
        public virtual async Task<Response<ConfigurationSetting>> SetConfigurationSettingAsync(ConfigurationSetting setting, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(SetConfigurationSetting)}");
            scope.AddAttribute("key", setting?.Key);
            scope.Start();

            try
            {
                using Request request = CreateSetRequest(setting, onlyIfUnchanged);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    409 => throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, "The setting is read only").ConfigureAwait(false),

                    // Throws on 412 if resource was modified.
                    _ => throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> if it doesn't exist or overwrites the existing setting in the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to create.</param>
        /// <param name="onlyIfUnchanged">If set to true and the configuration setting exists in the configuration store, overwrite the setting
        /// if the passed-in <see cref="ConfigurationSetting"/> is the same version as the one in the configuration store.  The setting versions
        /// are the same if their ETag fields match.  If the two settings are different versions, this method will throw an exception to indicate
        /// that the setting in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="ConfigurationSetting"/> written to the configuration store.</returns>
        public virtual Response<ConfigurationSetting> SetConfigurationSetting(ConfigurationSetting setting, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(SetConfigurationSetting)}");
            scope.AddAttribute("key", setting?.Key);
            scope.Start();

            try
            {
                using Request request = CreateSetRequest(setting, onlyIfUnchanged);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    200 => CreateResponse(response),
                    409 => throw _clientDiagnostics.CreateRequestFailedException(response, "The setting is read only"),

                    // Throws on 412 if resource was modified.
                    _ => throw _clientDiagnostics.CreateRequestFailedException(response),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Request CreateSetRequest(ConfigurationSetting setting, bool onlyIfChanged)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            Argument.AssertNotNullOrEmpty(setting.Key, $"{nameof(setting)}.{nameof(setting.Key)}");

            Request request = _pipeline.CreateRequest();
            ReadOnlyMemory<byte> content = ConfigurationServiceSerializer.SerializeRequestBody(setting);

            request.Method = RequestMethod.Put;
            BuildUriForKvRoute(request.Uri, setting);
            request.Headers.Add(s_mediaTypeKeyValueApplicationHeader);
            request.Headers.Add(HttpHeader.Common.JsonContentType);

            if (onlyIfChanged)
            {
                ConditionalRequestOptionsExtensions.ApplyHeaders(request, new MatchConditions { IfMatch = setting.ETag });
            }

            request.Content = RequestContent.Create(content);
            return request;
        }

        /// <summary>
        /// Delete a <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual async Task<Response> DeleteConfigurationSettingAsync(string key, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return await DeleteConfigurationSettingAsync(key, label, default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual Response DeleteConfigurationSetting(string key, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return DeleteConfigurationSetting(key, label, default, cancellationToken);
        }

        /// <summary>
        /// Delete a <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to delete.</param>
        /// <param name="onlyIfUnchanged">If set to true and the configuration setting exists in the configuration store, delete the setting
        /// if the passed-in <see cref="ConfigurationSetting"/> is the same version as the one in the configuration store. The setting versions
        /// are the same if their ETag fields match.  If the two settings are different versions, this method will throw an exception to indicate
        /// that the setting in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual async Task<Response> DeleteConfigurationSettingAsync(ConfigurationSetting setting, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = setting.ETag } : default;
            return await DeleteConfigurationSettingAsync(setting.Key, setting.Label, requestOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to delete.</param>
        /// <param name="onlyIfUnchanged">If set to true and the configuration setting exists in the configuration store, delete the setting
        /// if the passed-in <see cref="ConfigurationSetting"/> is the same version as the one in the configuration store. The setting versions
        /// are the same if their ETag fields match.  If the two settings are different versions, this method will throw an exception to indicate
        /// that the setting in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual Response DeleteConfigurationSetting(ConfigurationSetting setting, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = setting.ETag } : default;
            return DeleteConfigurationSetting(setting.Key, setting.Label, requestOptions, cancellationToken);
        }

        private async Task<Response> DeleteConfigurationSettingAsync(string key, string label, MatchConditions requestOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteConfigurationSetting)}");
            scope.AddAttribute("key", key);
            scope.Start();

            try
            {
                using Request request = CreateDeleteRequest(key, label, requestOptions);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => response,
                    204 => response,
                    409 => throw _clientDiagnostics.CreateRequestFailedException(response, "The setting is read only"),

                    // Throws on 412 if resource was modified.
                    _ => throw _clientDiagnostics.CreateRequestFailedException(response)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response DeleteConfigurationSetting(string key, string label, MatchConditions requestOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteConfigurationSetting)}");
            scope.AddAttribute("key", key);
            scope.Start();

            try
            {
                using Request request = CreateDeleteRequest(key, label, requestOptions);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    200 => response,
                    204 => response,
                    409 => throw _clientDiagnostics.CreateRequestFailedException(response, "The setting is read only."),

                    // Throws on 412 if resource was modified.
                    _ => throw _clientDiagnostics.CreateRequestFailedException(response)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Request CreateDeleteRequest(string key, string label, MatchConditions requestOptions)
        {
            Request request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Delete;
            BuildUriForKvRoute(request.Uri, key, label);

            if (requestOptions != null)
            {
                ConditionalRequestOptionsExtensions.ApplyHeaders(request, requestOptions);
            }

            return request;
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/>, uniquely identified by key and label, from the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting to retrieve.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="ConfigurationSetting"/>.</returns>
        public virtual async Task<Response<ConfigurationSetting>> GetConfigurationSettingAsync(string key, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return await GetConfigurationSettingAsync(key, label, acceptDateTime: default, requestOptions: default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/>, uniquely identified by key and label, from the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting to retrieve.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="ConfigurationSetting"/>.</returns>
        public virtual Response<ConfigurationSetting> GetConfigurationSetting(string key, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return GetConfigurationSetting(key, label, acceptDateTime: default, requestOptions: default, cancellationToken);
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to retrieve.</param>
        /// <param name="onlyIfChanged">If set to true, only retrieve the setting from the configuration store if it has changed since the client last retrieved it.
        /// It is determined to have changed if the ETag field on the passed-in <see cref="ConfigurationSetting"/> is different from the ETag of the setting in the
        /// configuration store.  If it has not changed, the returned response will have have no value, and will throw if response.Value is accessed.  Callers may
        /// check the status code on the response to avoid triggering the exception.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="ConfigurationSetting"/>.</returns>
        public virtual async Task<Response<ConfigurationSetting>> GetConfigurationSettingAsync(ConfigurationSetting setting, bool onlyIfChanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            MatchConditions requestOptions = onlyIfChanged ? new MatchConditions { IfNoneMatch = setting.ETag } : default;
            return await GetConfigurationSettingAsync(setting.Key, setting.Label, acceptDateTime: default, requestOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to retrieve.</param>
        /// <param name="onlyIfChanged">If set to true, only retrieve the setting from the configuration store if it has changed since the client last retrieved it.
        /// It is determined to have changed if the ETag field on the passed-in <see cref="ConfigurationSetting"/> is different from the ETag of the setting in the
        /// configuration store.  If it has not changed, the returned response will have have no value, and will throw if response.Value is accessed.  Callers may
        /// check the status code on the response to avoid triggering the exception.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="ConfigurationSetting"/>.</returns>
        public virtual Response<ConfigurationSetting> GetConfigurationSetting(ConfigurationSetting setting, bool onlyIfChanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            MatchConditions requestOptions = onlyIfChanged ? new MatchConditions { IfNoneMatch = setting.ETag } : default;
            return GetConfigurationSetting(setting.Key, setting.Label, acceptDateTime: default, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to retrieve.</param>
        /// <param name="acceptDateTime">The setting will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="ConfigurationSetting"/>.</returns>
        public virtual async Task<Response<ConfigurationSetting>> GetConfigurationSettingAsync(ConfigurationSetting setting, DateTimeOffset acceptDateTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            return await GetConfigurationSettingAsync(setting.Key, setting.Label, acceptDateTime, requestOptions: default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to retrieve.</param>
        /// <param name="acceptDateTime">The setting will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="ConfigurationSetting"/>.</returns>
        public virtual Response<ConfigurationSetting> GetConfigurationSetting(ConfigurationSetting setting, DateTimeOffset acceptDateTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            return GetConfigurationSetting(setting.Key, setting.Label, acceptDateTime, requestOptions: default, cancellationToken);
        }

        private async Task<Response<ConfigurationSetting>> GetConfigurationSettingAsync(string key, string label, DateTimeOffset acceptDateTime, MatchConditions requestOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetConfigurationSetting)}");
            scope.AddAttribute(nameof(key), key);
            scope.Start();

            try
            {
                using Request request = CreateGetRequest(key, label, acceptDateTime, requestOptions);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    304 => CreateResourceModifiedResponse(response),
                    _ => throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<ConfigurationSetting> GetConfigurationSetting(string key, string label, DateTimeOffset acceptDateTime, MatchConditions requestOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetConfigurationSetting)}");
            scope.AddAttribute(nameof(key), key);
            scope.Start();

            try
            {
                using Request request = CreateGetRequest(key, label, acceptDateTime, requestOptions);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    200 => CreateResponse(response),
                    304 => CreateResourceModifiedResponse(response),
                    _ => throw _clientDiagnostics.CreateRequestFailedException(response),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves one or more <see cref="ConfigurationSetting"/> entities that match the options specified in the passed-in <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Options used to select a set of <see cref="ConfigurationSetting"/> entities from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection containing the retrieved <see cref="ConfigurationSetting"/> entities.</returns>
        public virtual AsyncPageable<ConfigurationSetting> GetConfigurationSettingsAsync(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetConfigurationSettingsPageAsync(selector, nextLink, cancellationToken));
        }

        /// <summary>
        /// Retrieves one or more <see cref="ConfigurationSetting"/> entities that match the options specified in the passed-in <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="ConfigurationSetting"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<ConfigurationSetting> GetConfigurationSettings(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            return PageResponseEnumerator.CreateEnumerable(nextLink => GetConfigurationSettingsPage(selector, nextLink, cancellationToken));
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="ConfigurationSetting"/> entities that match the specified <paramref name="keyFilter"/> and <paramref name="labelFilter"/>.
        /// </summary>
        /// <param name="keyFilter">Key filter that will be used to select a set of <see cref="ConfigurationSetting"/> entities.</param>
        /// <param name="labelFilter">Label filter that will be used to select a set of <see cref="ConfigurationSetting"/> entities.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncPageable<ConfigurationSetting> GetRevisionsAsync(string keyFilter, string labelFilter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyFilter, nameof(keyFilter));
            return GetRevisionsAsync(new SettingSelector { KeyFilter = keyFilter, LabelFilter = labelFilter }, cancellationToken);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="ConfigurationSetting"/> entities that match the specified <paramref name="keyFilter"/> and <paramref name="labelFilter"/>.
        /// </summary>
        /// <param name="keyFilter">Key filter that will be used to select a set of <see cref="ConfigurationSetting"/> entities.</param>
        /// <param name="labelFilter">Label filter that will be used to select a set of <see cref="ConfigurationSetting"/> entities.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<ConfigurationSetting> GetRevisions(string keyFilter, string labelFilter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyFilter, nameof(keyFilter));
            return GetRevisions(new SettingSelector { KeyFilter = keyFilter, LabelFilter = labelFilter }, cancellationToken);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="ConfigurationSetting"/> entities that satisfy the options of the <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="ConfigurationSetting"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncPageable<ConfigurationSetting> GetRevisionsAsync(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetRevisionsPageAsync(selector, nextLink, cancellationToken));
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="ConfigurationSetting"/> entities that satisfy the options of the <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="ConfigurationSetting"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<ConfigurationSetting> GetRevisions(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            return PageResponseEnumerator.CreateEnumerable(nextLink => GetRevisionsPage(selector, nextLink, cancellationToken));
        }

        private Request CreateGetRequest(string key, string label, DateTimeOffset acceptDateTime, MatchConditions requestOptions)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            Request request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            BuildUriForKvRoute(request.Uri, key, label);
            request.Headers.Add(s_mediaTypeKeyValueApplicationHeader);

            if (acceptDateTime != default)
            {
                var dateTime = acceptDateTime.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
                request.Headers.SetValue(AcceptDatetimeHeader, dateTime);
            }

            if (requestOptions != null)
            {
                ConditionalRequestOptionsExtensions.ApplyHeaders(request, requestOptions);
            }

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            return request;
        }

        /// <summary>
        /// Fetches the <see cref="ConfigurationSetting"/> from the configuration store that match the options selected in the <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting settings from the configuration store.</param>
        /// <param name="pageLink"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        private async Task<Page<ConfigurationSetting>> GetConfigurationSettingsPageAsync(SettingSelector selector, string pageLink, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetConfigurationSettings)}");
            scope.Start();

            try
            {
                using Request request = CreateBatchRequest(selector, pageLink);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                    case 206:
                        SettingBatch settingBatch = await ConfigurationServiceSerializer.ParseBatchAsync(response, cancellationToken).ConfigureAwait(false);
                        return Page<ConfigurationSetting>.FromValues(settingBatch.Settings, settingBatch.NextBatchLink, response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Fetches the <see cref="ConfigurationSetting"/> from the configuration store that match the options selected in the <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting settings from the configuration store.</param>
        /// <param name="pageLink"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        private Page<ConfigurationSetting> GetConfigurationSettingsPage(SettingSelector selector, string pageLink, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetConfigurationSettings)}");
            scope.Start();

            try
            {
                using Request request = CreateBatchRequest(selector, pageLink);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                    case 206:
                        SettingBatch settingBatch = ConfigurationServiceSerializer.ParseBatch(response);
                        return Page<ConfigurationSetting>.FromValues(settingBatch.Settings, settingBatch.NextBatchLink, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Request CreateBatchRequest(SettingSelector selector, string pageLink)
        {
            Request request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            BuildUriForGetBatch(request.Uri, selector, pageLink);
            request.Headers.Add(s_mediaTypeKeyValueApplicationHeader);
            if (selector.AcceptDateTime.HasValue)
            {
                var dateTime = selector.AcceptDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
                request.Headers.SetValue(AcceptDatetimeHeader, dateTime);
            }

            return request;
        }

        /// <summary>
        /// Lists chronological/historical representation of <see cref="ConfigurationSetting"/> from the configuration store that match the options selected in the <see cref="SettingSelector"/>.
        /// </summary>
        /// <remarks>Revisions are provided in descending order from their respective <see cref="ConfigurationSetting.LastModified"/> date.</remarks>
        /// <param name="selector">Set of options for selecting settings from the configuration store.</param>
        /// <param name="pageLink"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        private async Task<Page<ConfigurationSetting>> GetRevisionsPageAsync(SettingSelector selector, string pageLink, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetRevisions)}");
            scope.Start();

            try
            {
                using Request request = CreateGetRevisionsRequest(selector, pageLink);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                    case 206:
                        SettingBatch settingBatch = await ConfigurationServiceSerializer.ParseBatchAsync(response, cancellationToken).ConfigureAwait(false);
                        return Page<ConfigurationSetting>.FromValues(settingBatch.Settings, settingBatch.NextBatchLink, response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists chronological/historical representation of <see cref="ConfigurationSetting"/> from the configuration store that match the options selected in the <see cref="SettingSelector"/>.
        /// </summary>
        /// <remarks>Revisions are provided in descending order from their respective <see cref="ConfigurationSetting.LastModified"/> date.</remarks>
        /// <param name="selector">Set of options for selecting settings from the configuration store.</param>
        /// <param name="pageLink"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        private Page<ConfigurationSetting> GetRevisionsPage(SettingSelector selector, string pageLink, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetRevisions)}");
            scope.Start();

            try
            {
                using Request request = CreateGetRevisionsRequest(selector, pageLink);
                Response response = _pipeline.SendRequest(request, cancellationToken);
                switch (response.Status)
                {
                    case 200:
                    case 206:
                        SettingBatch settingBatch = ConfigurationServiceSerializer.ParseBatch(response);
                        return Page<ConfigurationSetting>.FromValues(settingBatch.Settings, settingBatch.NextBatchLink, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Request CreateGetRevisionsRequest(SettingSelector selector, string pageLink)
        {
            Request request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            BuildUriForRevisions(request.Uri, selector, pageLink);
            request.Headers.Add(s_mediaTypeKeyValueApplicationHeader);
            if (selector.AcceptDateTime.HasValue)
            {
                var dateTime = selector.AcceptDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
                request.Headers.SetValue(AcceptDatetimeHeader, dateTime);
            }

            return request;
        }

        /// <summary>
        /// Sets an existing <see cref="ConfigurationSetting"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="isReadOnly">If true, the <see cref="ConfigurationSetting"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> SetReadOnlyAsync(string key, bool isReadOnly, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return await SetReadOnlyAsync(key, default, default, isReadOnly, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets an existing <see cref="ConfigurationSetting"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="isReadOnly">If true, the <see cref="ConfigurationSetting"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<ConfigurationSetting> SetReadOnly(string key, bool isReadOnly, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return SetReadOnlyAsync(key, default, default, isReadOnly, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Sets an existing <see cref="ConfigurationSetting"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="isReadOnly">If true, the <see cref="ConfigurationSetting"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> SetReadOnlyAsync(string key, string label, bool isReadOnly, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return await SetReadOnlyAsync(key, label, default, isReadOnly, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets an existing <see cref="ConfigurationSetting"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="isReadOnly">If true, the <see cref="ConfigurationSetting"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<ConfigurationSetting> SetReadOnly(string key, string label, bool isReadOnly, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            return SetReadOnlyAsync(key, label, default, isReadOnly, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Sets an existing <see cref="ConfigurationSetting"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to update.</param>
        /// <param name="onlyIfUnchanged">If set to true and the configuration setting exists in the configuration store, update the setting
        /// if the passed-in <see cref="ConfigurationSetting"/> is the same version as the one in the configuration store. The setting versions
        /// are the same if their ETag fields match.  If the two settings are different versions, this method will throw an exception to indicate
        /// that the setting in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="isReadOnly">If true, the <see cref="ConfigurationSetting"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> SetReadOnlyAsync(ConfigurationSetting setting, bool isReadOnly, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = setting.ETag } : default;
            return await SetReadOnlyAsync(setting.Key, setting.Label, requestOptions, isReadOnly, true, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets an existing <see cref="ConfigurationSetting"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="setting">The <see cref="ConfigurationSetting"/> to update.</param>
        /// <param name="onlyIfUnchanged">If set to true and the configuration setting exists in the configuration store, update the setting
        /// if the passed-in <see cref="ConfigurationSetting"/> is the same version as the one in the configuration store. The setting versions
        /// are the same if their ETag fields match.  If the two settings are different versions, this method will throw an exception to indicate
        /// that the setting in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="isReadOnly">If true, the <see cref="ConfigurationSetting"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<ConfigurationSetting> SetReadOnly(ConfigurationSetting setting, bool isReadOnly, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));
            MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = setting.ETag } : default;
            return SetReadOnlyAsync(setting.Key, setting.Label, requestOptions, isReadOnly, false, cancellationToken).EnsureCompleted();
        }

        private async ValueTask<Response<ConfigurationSetting>> SetReadOnlyAsync(string key, string label, MatchConditions requestOptions, bool isReadOnly, bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(SetReadOnly)}");
            scope.AddAttribute("key", key);
            scope.Start();

            try
            {
                using Request request = CreateSetReadOnlyRequest(key, label, requestOptions, isReadOnly);
                Response response = async
                    ? await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false)
                    : _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    200 => async
                        ? await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false)
                        : CreateResponse(response),
                    _ => throw (async
                        ? await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false)
                        : _clientDiagnostics.CreateRequestFailedException(response))
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Request CreateSetReadOnlyRequest(string key, string label,  MatchConditions requestOptions, bool isReadOnly)
        {
            Request request = _pipeline.CreateRequest();
            request.Method = isReadOnly ? RequestMethod.Put : RequestMethod.Delete;
            BuildUriForLocksRoute(request.Uri, key, label);

            if (requestOptions != null)
            {
                ConditionalRequestOptionsExtensions.ApplyHeaders(request, requestOptions);
            }

            return request;
        }
    }
}
