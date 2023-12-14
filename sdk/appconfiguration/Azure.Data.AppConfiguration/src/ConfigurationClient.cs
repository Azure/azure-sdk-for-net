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
    [CodeGenSuppress("ConfigurationClient", typeof(Uri), typeof(AzureKeyCredential), typeof(ConfigurationClientOptions))]
    public partial class ConfigurationClient
    {
        private const string OTelAttributeKey = "az.appconfiguration.key";
        private readonly SyncTokenPolicy _syncTokenPolicy;

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
            _apiVersion = options.Version;
            _syncTokenPolicy = new SyncTokenPolicy();
            _pipeline = CreatePipeline(options, new AuthenticationPolicy(credential, secret), _syncTokenPolicy);

            ClientDiagnostics = new ClientDiagnostics(options, true);
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
            _syncTokenPolicy = new SyncTokenPolicy();
            _pipeline = CreatePipeline(options, new BearerTokenAuthenticationPolicy(credential, GetDefaultScope(endpoint)), _syncTokenPolicy);
            _apiVersion = options.Version;

            ClientDiagnostics = new ClientDiagnostics(options, true);
        }

        /// <summary> Initializes a new instance of ConfigurationClient. </summary>
        /// <param name="endpoint"> The endpoint of the App Configuration instance to send requests to. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        internal ConfigurationClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null, new ConfigurationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConfigurationClient. </summary>
        /// <param name="endpoint"> The endpoint of the App Configuration instance to send requests to. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        internal ConfigurationClient(Uri endpoint, AzureKeyCredential credential, string syncToken, ConfigurationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new ConfigurationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _syncToken = syncToken;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of ConfigurationClient. </summary>
        /// <param name="endpoint"> The endpoint of the App Configuration instance to send requests to. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        internal ConfigurationClient(Uri endpoint, TokenCredential credential, string syncToken, ConfigurationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new ConfigurationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _syncToken = syncToken;
            _apiVersion = options.Version;
        }

        private static HttpPipeline CreatePipeline(ConfigurationClientOptions options, HttpPipelinePolicy authenticationPolicy, HttpPipelinePolicy syncTokenPolicy)
        {
            return HttpPipelineBuilder.Build(options,
                new HttpPipelinePolicy[] { new CustomHeadersPolicy() },
                new HttpPipelinePolicy[] { authenticationPolicy, syncTokenPolicy },
                new ResponseClassifier());
        }

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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(AddConfigurationSetting)}");
            scope.AddAttribute(OTelAttributeKey, setting?.Key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using RequestContent content = ConfigurationSetting.ToRequestContent(setting);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());
                MatchConditions requestOptions = new MatchConditions { IfNoneMatch = ETag.All };

                using Response response = await SetConfigurationSettingAsync(setting.Key, content, contentType, setting.Label, requestOptions, context).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                    case 201:
                        return await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false);
                    case 412:
                        throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser());
                    default:
                        throw new RequestFailedException(response);
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(AddConfigurationSetting)}");
            scope.AddAttribute(OTelAttributeKey, setting?.Key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using RequestContent content = ConfigurationSetting.ToRequestContent(setting);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());
                MatchConditions requestOptions = new MatchConditions { IfNoneMatch = ETag.All };

                using Response response = SetConfigurationSetting(setting.Key, content, contentType, setting.Label, requestOptions, context);
                switch (response.Status)
                {
                    case 200:
                    case 201:
                        return CreateResponse(response);
                    case 412:
                        throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser());
                    default:
                        throw new RequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(SetConfigurationSetting)}");
            scope.AddAttribute(OTelAttributeKey, setting?.Key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using RequestContent content = ConfigurationSetting.ToRequestContent(setting);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());
                MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = setting.ETag } : default;

                using Response response = await SetConfigurationSettingAsync(setting.Key, content, contentType, setting.Label, requestOptions, context).ConfigureAwait(false);
                return response.Status switch
                {
                    200 => await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    409 => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser()),

                    // Throws on 412 if resource was modified.
                    _ => throw new RequestFailedException(response),
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(SetConfigurationSetting)}");
            scope.AddAttribute(OTelAttributeKey, setting?.Key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using RequestContent content = ConfigurationSetting.ToRequestContent(setting);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());
                MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = setting.ETag } : default;

                using Response response = SetConfigurationSetting(setting.Key, content, contentType, setting.Label, requestOptions, context);

                return response.Status switch
                {
                    200 => CreateResponse(response),
                    409 => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser()),

                    // Throws on 412 if resource was modified.
                    _ => throw new RequestFailedException(response),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteConfigurationSetting)}");
            scope.AddAttribute(OTelAttributeKey, key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using Response response = await DeleteConfigurationSettingAsync(key, label, requestOptions?.IfMatch, context).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => response,
                    204 => response,
                    409 => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser()),

                    // Throws on 412 if resource was modified.
                    _ => throw new RequestFailedException(response)
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteConfigurationSetting)}");
            scope.AddAttribute(OTelAttributeKey, key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using Response response = DeleteConfigurationSetting(key, label, requestOptions?.IfMatch, context);

                return response.Status switch
                {
                    200 => response,
                    204 => response,
                    409 => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser()),

                    // Throws on 412 if resource was modified.
                    _ => throw new RequestFailedException(response)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
            return await GetConfigurationSettingAsync(key, label, acceptDateTime: default, conditions: default, cancellationToken).ConfigureAwait(false);
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
            return GetConfigurationSetting(key, label, acceptDateTime: default, conditions: default, cancellationToken);
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
            return await GetConfigurationSettingAsync(setting.Key, setting.Label, acceptDateTime, conditions: default, cancellationToken).ConfigureAwait(false);
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
            return GetConfigurationSetting(setting.Key, setting.Label, acceptDateTime, conditions: default, cancellationToken);
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/>, uniquely identified by key and label, from the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting to retrieve.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="acceptDateTime">The setting will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="conditions">The match conditions to apply to request.</param>
        /// <returns>A response containing the retrieved <see cref="ConfigurationSetting"/>.</returns>
        internal virtual async Task<Response<ConfigurationSetting>> GetConfigurationSettingAsync(string key, string label, DateTimeOffset? acceptDateTime, MatchConditions conditions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetConfigurationSetting)}");
            scope.AddAttribute(OTelAttributeKey, key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                var dateTime = acceptDateTime.HasValue ? acceptDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture) : null;
                using Response response = await GetConfigurationSettingAsync(key, label, dateTime, null, conditions, context).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    304 => CreateResourceModifiedResponse(response),
                    _ => throw new RequestFailedException(response),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/>, uniquely identified by key and label, from the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting to retrieve.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="acceptDateTime">The setting will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="conditions">The match conditions to apply to request.</param>
        /// <returns>A response containing the retrieved <see cref="ConfigurationSetting"/>.</returns>
        internal virtual Response<ConfigurationSetting> GetConfigurationSetting(string key, string label, DateTimeOffset? acceptDateTime, MatchConditions conditions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetConfigurationSetting)}");
            scope.AddAttribute(OTelAttributeKey, key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                var dateTime = acceptDateTime.HasValue ? acceptDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture) : null;
                using Response response = GetConfigurationSetting(key, label, dateTime, null, conditions, context);

                return response.Status switch
                {
                    200 => CreateResponse(response),
                    304 => CreateResourceModifiedResponse(response),
                    _ => throw new RequestFailedException(response),
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
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
            var key = selector.KeyFilter;
            var label = selector.LabelFilter;

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<string> fieldsString = selector.Fields.Split();

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(key, label, null, dateTime, fieldsString, null, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetConfigurationSettingsNextPageRequest(nextLink, key, label, null, dateTime, fieldsString, null, null, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, _pipeline, "ConfigurationClient.GetConfigurationSettings", "items", "@nextLink", context);
        }

        /// <summary>
        /// Retrieves one or more <see cref="ConfigurationSetting"/> entities that match the options specified in the passed-in <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="ConfigurationSetting"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<ConfigurationSetting> GetConfigurationSettings(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var key = selector.KeyFilter;
            var label = selector.LabelFilter;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<string> fieldsString = selector.Fields.Split();

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(key, label, null, dateTime, fieldsString, null, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetConfigurationSettingsNextPageRequest(nextLink, key, label, null, dateTime, fieldsString, null, null, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, _pipeline, "ConfigurationClient.GetConfigurationSettings", "items", "@nextLink", context);
        }

        /// <summary>
        /// Retrieves one or more <see cref="ConfigurationSetting"/> entities for snapshots based on name.
        /// </summary>
        /// <param name="snapshotName">A filter used to get key-values for a snapshot. The value should be the name of the snapshot.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection containing the retrieved <see cref="ConfigurationSetting"/> entities.</returns>
        public virtual AsyncPageable<ConfigurationSetting> GetConfigurationSettingsForSnapshotAsync(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(null, null, null, null, null, snapshotName, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetConfigurationSettingsNextPageRequest(nextLink, null, null, null, null, null, snapshotName, null, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, _pipeline, "ConfigurationClient.GetConfigurationSettingsForSnapshot", "items", "@nextLink", context);
        }

        /// <summary>
        /// Retrieves one or more <see cref="ConfigurationSetting"/> entities for snapshots based on name.
        /// </summary>
        /// <param name="snapshotName">A filter used to get key-values for a snapshot. The value should be the name of the snapshot.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<ConfigurationSetting> GetConfigurationSettingsForSnapshot(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(null, null, null, null, null, snapshotName, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetConfigurationSettingsNextPageRequest(nextLink, null, null, null, null, null, snapshotName, null, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, _pipeline, "ConfigurationClient.GetConfigurationSettingsForSnapshot", "items", "@nextLink", context);
        }

        /// <summary>
        /// Retrieves one or more <see cref="ConfigurationSetting"/> entities for snapshots based on name.
        /// </summary>
        /// <param name="snapshotName">A filter used to get key-values for a snapshot. The value should be the name of the snapshot.</param>
        /// <param name="fields">The fields of the <see cref="ConfigurationSetting"/> to retrieve for each setting in the retrieved group.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection containing the retrieved <see cref="ConfigurationSetting"/> entities.</returns>
        public virtual AsyncPageable<ConfigurationSetting> GetConfigurationSettingsForSnapshotAsync(string snapshotName, SettingFields fields, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<string> fieldsString = fields.Split();

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(null, null, null, null, fieldsString, snapshotName, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetConfigurationSettingsNextPageRequest(nextLink, null, null, null, null, fieldsString, snapshotName, null, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, _pipeline, "ConfigurationClient.GetConfigurationSettingsForSnapshot", "items", "@nextLink", context);
        }

        /// <summary>
        /// Retrieves one or more <see cref="ConfigurationSetting"/> entities for snapshots based on name.
        /// </summary>
        /// <param name="snapshotName">A filter used to get key-values for a snapshot. The value should be the name of the snapshot.</param>
        /// <param name="fields">The fields of the <see cref="ConfigurationSetting"/> to retrieve for each setting in the retrieved group.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<ConfigurationSetting> GetConfigurationSettingsForSnapshot(string snapshotName, SettingFields fields, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<string> fieldsString = fields.Split();

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(null, null, null, null, fieldsString, snapshotName, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetConfigurationSettingsNextPageRequest(nextLink, null, null, null, null, fieldsString, snapshotName, null, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, _pipeline, "ConfigurationClient.GetConfigurationSettingsForSnapshot", "items", "@nextLink", context);
        }

        /// <summary> Gets a single configuration snapshot. </summary>
        /// <param name="snapshotName"> The name of the configuration snapshot to retrieve. </param>
        /// <param name="fields"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSnapshot>> GetSnapshotAsync(string snapshotName, IEnumerable<SnapshotFields> fields = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.GetSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                List<string> snapshotFields = null;
                if (fields != null)
                {
                    snapshotFields = new();
                    foreach (var field in fields)
                    {
                        snapshotFields.Add(field.ToString());
                    }
                }

                Response response = await GetSnapshotAsync(snapshotName, snapshotFields, new MatchConditions(), context).ConfigureAwait(false);
                ConfigurationSnapshot value = ConfigurationSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single configuration snapshot. </summary>
        /// <param name="snapshotName"> The name of the configuration snapshot to retrieve. </param>
        /// <param name="fields"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSnapshot> GetSnapshot(string snapshotName, IEnumerable<SnapshotFields> fields = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.GetSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                List<string> snapshotFields = null;
                if (fields != null)
                {
                    snapshotFields = new();
                    foreach (var field in fields)
                    {
                        snapshotFields.Add(field.ToString());
                    }
                }

                Response response = GetSnapshot(snapshotName, snapshotFields, new MatchConditions(), context);
                ConfigurationSnapshot value = ConfigurationSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a configuration snapshot. </summary>
        /// <param name="wait">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation
        /// </param>
        /// <param name="snapshotName"> The name of the configuration snapshot to create. </param>
        /// <param name="snapshot"> The configuration snapshot to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<CreateSnapshotOperation> CreateSnapshotAsync(WaitUntil wait, string snapshotName, ConfigurationSnapshot snapshot, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));
            Argument.AssertNotNull(snapshot, nameof(snapshot));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.CreateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                using RequestContent content = ConfigurationSnapshot.ToRequestContent(snapshot);
                ContentType contentType = new(HttpHeader.Common.JsonContentType.Value.ToString());

                // Start the operation
                var operationT = await CreateSnapshotAsync(wait, snapshotName, content, contentType, context).ConfigureAwait(false);

                var createSnapshotOperation = new CreateSnapshotOperation(snapshotName, ClientDiagnostics, operationT);

                if (wait == WaitUntil.Completed)
                {
                    await createSnapshotOperation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return createSnapshotOperation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a configuration snapshot. </summary>
        /// <param name="wait">
        /// <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// </param>
        /// <param name="snapshotName"> The name of the configuration snapshot to create. </param>
        /// <param name="snapshot"> The configuration snapshot to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual CreateSnapshotOperation CreateSnapshot(WaitUntil wait, string snapshotName, ConfigurationSnapshot snapshot, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));
            Argument.AssertNotNull(snapshot, nameof(snapshot));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.CreateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                using RequestContent content = ConfigurationSnapshot.ToRequestContent(snapshot);
                ContentType contentType = new(HttpHeader.Common.JsonContentType.Value.ToString());

                // Start the operation
                var operationT = CreateSnapshot(wait, snapshotName, content, contentType, context);

                var createSnapshotOperation = new CreateSnapshotOperation(snapshotName, ClientDiagnostics, operationT);

                if (wait == WaitUntil.Completed)
                {
                    createSnapshotOperation.WaitForCompletion(cancellationToken);
                }

                return createSnapshotOperation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration snapshot to archive. </summary>
        /// <param name="snapshotName"> The name of the configuration snapshot to archive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSnapshot>> ArchiveSnapshotAsync(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.ArchiveSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = ConfigurationSnapshotStatus.Archived
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = await UpdateSnapshotStatusAsync(snapshotName, content, contentType, new MatchConditions(), context).ConfigureAwait(false);
                ConfigurationSnapshot value = ConfigurationSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration snapshot to archive. </summary>
        /// <param name="snapshotName"> The name of the configuration snapshot to archive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSnapshot> ArchiveSnapshot(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.ArchiveSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = ConfigurationSnapshotStatus.Archived
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = UpdateSnapshotStatus(snapshotName, content, contentType, new MatchConditions(), context);
                ConfigurationSnapshot value = ConfigurationSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration snapshot to archive. </summary>
        /// <param name="snapshotName"> The name of the configuration snapshot to archive. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSnapshot>> ArchiveSnapshotAsync(string snapshotName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.ArchiveSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = ConfigurationSnapshotStatus.Archived
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = await UpdateSnapshotStatusAsync(snapshotName, content, contentType, matchConditions, context).ConfigureAwait(false);
                ConfigurationSnapshot value = ConfigurationSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration snapshot to archive. </summary>
        /// <param name="snapshotName"> The name of the configuration snapshot to archive. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSnapshot> ArchiveSnapshot(string snapshotName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.ArchiveSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = ConfigurationSnapshotStatus.Archived
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = UpdateSnapshotStatus(snapshotName, content, contentType, matchConditions, context);
                ConfigurationSnapshot value = ConfigurationSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration snapshot to ready. </summary>
        /// <param name="snapshotName"> The name of the configuration snapshot to recover. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSnapshot>> RecoverSnapshotAsync(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.RecoverSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = ConfigurationSnapshotStatus.Ready
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = await UpdateSnapshotStatusAsync(snapshotName, content, contentType, new MatchConditions(), context).ConfigureAwait(false);
                ConfigurationSnapshot value = ConfigurationSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration snapshot to ready. </summary>
        /// <param name="snapshotName"> The name of the configuration snapshot to recover. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSnapshot> RecoverSnapshot(string snapshotName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.RecoverSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = ConfigurationSnapshotStatus.Ready
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = UpdateSnapshotStatus(snapshotName, content, contentType, new MatchConditions(), context);
                ConfigurationSnapshot value = ConfigurationSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration snapshot to ready. </summary>
        /// <param name="snapshotName"> The name of the configuration snapshot to recover. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSnapshot>> RecoverSnapshotAsync(string snapshotName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.RecoverSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = ConfigurationSnapshotStatus.Ready
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = await UpdateSnapshotStatusAsync(snapshotName, content, contentType, matchConditions, context).ConfigureAwait(false);
                ConfigurationSnapshot value = ConfigurationSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration snapshot to ready. </summary>
        /// <param name="snapshotName"> The name of the configuration snapshot to recover. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSnapshot> RecoverSnapshot(string snapshotName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(snapshotName, nameof(snapshotName));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.RecoverSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = ConfigurationSnapshotStatus.Ready
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = UpdateSnapshotStatus(snapshotName, content, contentType, matchConditions, context);
                ConfigurationSnapshot value = ConfigurationSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of configuration snapshots. </summary>
        /// <param name="selector">Set of options for selecting <see cref="ConfigurationSnapshot"/>.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ConfigurationSnapshot> GetSnapshotsAsync(SnapshotSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var name = selector.NameFilter;
            var fields = selector.Fields;
            var status = selector.Status;

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

            var snapshotFields = new ChangeTrackingList<string>();
            foreach (SnapshotFields field in fields)
            {
                snapshotFields.Add(field.ToString());
            }

            var snapshotStatus = new ChangeTrackingList<string>();
            foreach (ConfigurationSnapshotStatus st in status)
            {
                snapshotStatus.Add(st.ToString());
            }

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSnapshotsRequest(name, null, snapshotFields, snapshotStatus, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSnapshotsNextPageRequest(nextLink, name, null, snapshotFields, snapshotStatus, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ConfigurationSnapshot.DeserializeSnapshot, ClientDiagnostics, _pipeline, "ConfigurationClient.GetSnapshots", "items", "@nextLink", cancellationToken);
        }

        /// <summary> Gets a list of configuration snapshots. </summary>
        /// <param name="selector">Set of options for selecting <see cref="ConfigurationSnapshot"/>.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ConfigurationSnapshot> GetSnapshots(SnapshotSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var name = selector.NameFilter;
            var fields = selector.Fields;
            var status = selector.Status;

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

            var snapshotFields = new ChangeTrackingList<string>();
            foreach (SnapshotFields field in fields)
            {
                snapshotFields.Add(field.ToString());
            }

            var snapshotStatus = new ChangeTrackingList<string>();
            foreach (ConfigurationSnapshotStatus st in status)
            {
                snapshotStatus.Add(st.ToString());
            }

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSnapshotsRequest(name, null, snapshotFields, snapshotStatus, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSnapshotsNextPageRequest(nextLink, name, null, snapshotFields, snapshotStatus, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationSnapshot.DeserializeSnapshot, ClientDiagnostics, _pipeline, "ConfigurationClient.GetSnapshots", "items", "@nextLink", cancellationToken);
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
            var key = selector.KeyFilter;
            var label = selector.LabelFilter;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<string> fieldsString = selector.Fields.Split();

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetRevisionsRequest(key, label, null, dateTime, fieldsString, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetRevisionsNextPageRequest(nextLink, key, label, null, dateTime, fieldsString, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, _pipeline, "ConfigurationClient.GetRevisions", "items", "@nextLink", context);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="ConfigurationSetting"/> entities that satisfy the options of the <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="ConfigurationSetting"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<ConfigurationSetting> GetRevisions(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var key = selector.KeyFilter;
            var label = selector.LabelFilter;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<string> fieldsString = selector.Fields.Split();

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetRevisionsRequest(key, label, null, dateTime, fieldsString, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetRevisionsNextPageRequest(nextLink, key, label, null, dateTime, fieldsString, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, _pipeline, "ConfigurationClient.GetRevisions", "items", "@nextLink", context);
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(SetReadOnly)}");
            scope.AddAttribute(OTelAttributeKey, key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);
                using Response response = async ? await ToCreateAsyncResponse(key, label, requestOptions, isReadOnly, context).ConfigureAwait(false) : ToCreateResponse(key, label, requestOptions, isReadOnly, context);

                return response.Status switch
                {
                    200 => async
                        ? await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false)
                        : CreateResponse(response),
                    _ => throw new RequestFailedException(response)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response> ToCreateAsyncResponse(string key, string label, MatchConditions requestOptions, bool isReadOnly, RequestContext context)
        {
            Response response = isReadOnly ? await CreateReadOnlyLockAsync(key, label, requestOptions, context).ConfigureAwait(false) : await DeleteReadOnlyLockAsync(key, label, requestOptions, context).ConfigureAwait(false);
            return response;
        }

        private Response ToCreateResponse(string key, string label, MatchConditions requestOptions, bool isReadOnly, RequestContext context)
        {
            Response response = isReadOnly ? CreateReadOnlyLock(key, label, requestOptions, context) : DeleteReadOnlyLock(key, label, requestOptions, context);
            return response;
        }

        /// <summary>
        /// Adds an external synchronization token to ensure service requests receive up-to-date values.
        /// </summary>
        /// <param name="token">The synchronization token value.</param>
        public virtual void UpdateSyncToken(string token)
        {
            Argument.AssertNotNull(token, nameof(token));
            _syncTokenPolicy.AddToken(token);
        }

        private static RequestContext CreateRequestContext(ErrorOptions errorOptions, CancellationToken cancellationToken)
        {
            return new RequestContext()
            {
                ErrorOptions = errorOptions,
                CancellationToken = cancellationToken
            };
        }

        private class ConfigurationRequestFailedDetailsParser : RequestFailedDetailsParser
        {
            public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
            {
                switch (response.Status)
                {
                    case 409:
                        error = new ResponseError(null, "The setting is read only");
                        data = null;
                        return true;
                    case 412:
                        error = new ResponseError(null, "Setting was already present.");
                        data = null;
                        return true;
                    default:
                        error = null;
                        data = null;
                        return false;
                }
            }
        }
    }
}
