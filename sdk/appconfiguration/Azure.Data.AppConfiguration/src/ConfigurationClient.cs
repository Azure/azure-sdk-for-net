// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using static Azure.Core.Pipeline.TaskExtensions;

#pragma warning disable AZC0007

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Renamed.
    // - Suppressed convenience methods. These are implemented through custom code.
    // - Suppressed protocol methods that do not have an existing convenience method API.
    /// <summary>
    /// The client to use for interacting with the Azure Configuration Store.
    /// </summary>
    [CodeGenType("AzureAppConfigurationClient")]
    [CodeGenSuppress("ConfigurationClient", typeof(Uri), typeof(AzureKeyCredential), typeof(ConfigurationClientOptions))]
    [CodeGenSuppress("GetKeys", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetKeysAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CheckKeys", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CheckKeysAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetConfigurationSetting", typeof(string), typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(CancellationToken))]
    [CodeGenSuppress("GetConfigurationSettingAsync", typeof(string), typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(CancellationToken))]
    [CodeGenSuppress("GetConfigurationSettings", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(CancellationToken))]
    [CodeGenSuppress("GetConfigurationSettingsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(CancellationToken))]
    [CodeGenSuppress("CheckKeyValue", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(IEnumerable<>), typeof(CancellationToken))]
    [CodeGenSuppress("CheckKeyValueAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(IEnumerable<>), typeof(CancellationToken))]
    [CodeGenSuppress("CheckKeyValues", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(CancellationToken))]
    [CodeGenSuppress("CheckKeyValuesAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(CancellationToken))]
    [CodeGenSuppress("SetConfigurationSettingInternal", typeof(string), typeof(PutKeyValueRequestContentType), typeof(ConfigurationSetting), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("SetConfigurationSettingInternalAsync", typeof(string), typeof(PutKeyValueRequestContentType), typeof(ConfigurationSetting), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteConfigurationSetting", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteConfigurationSettingAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSnapshot", typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSnapshotAsync", typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSnapshots", typeof(string), typeof(string), typeof(IEnumerable<>), typeof(IEnumerable<>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSnapshotsAsync", typeof(string), typeof(string), typeof(IEnumerable<>), typeof(IEnumerable<>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CheckSnapshots", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CheckSnapshotsAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CreateSnapshot", typeof(string), typeof(CreateSnapshotRequestContentType), typeof(ConfigurationSnapshot), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CreateSnapshotAsync", typeof(string), typeof(CreateSnapshotRequestContentType), typeof(ConfigurationSnapshot), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationDetails", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationDetailsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CreateReadOnlyLock", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CreateReadOnlyLockAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteReadOnlyLock", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteReadOnlyLockAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLabels", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingLabelFields>), typeof(CancellationToken))]
    [CodeGenSuppress("GetLabelsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingLabelFields>), typeof(CancellationToken))]
    [CodeGenSuppress("CheckLabels", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingLabelFields>), typeof(CancellationToken))]
    [CodeGenSuppress("CheckLabelsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingLabelFields>), typeof(CancellationToken))]
    [CodeGenSuppress("CheckSnapshot", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CheckSnapshotAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetRevisions", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingFields>), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("GetRevisionsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingFields>), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("CheckRevisions", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingFields>), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("CheckRevisionsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingFields>), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("GetKeys", typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetKeysAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeys", typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeysAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeyValues", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeyValuesAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeyValue", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(IEnumerable<>), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeyValueAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(IEnumerable<>), typeof(RequestContext))]
    [CodeGenSuppress("CheckSnapshots", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckSnapshotsAsync", typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetOperationDetails", typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetOperationDetailsAsync", typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSnapshots", typeof(string), typeof(string), typeof(IEnumerable<>), typeof(IEnumerable<>), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetSnapshotsAsync", typeof(string), typeof(string), typeof(IEnumerable<>), typeof(IEnumerable<>), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckSnapshot", typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckSnapshotAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetLabels", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingLabelFields>), typeof(RequestContext))]
    [CodeGenSuppress("GetLabelsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingLabelFields>), typeof(RequestContext))]
    [CodeGenSuppress("CheckLabels", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingLabelFields>), typeof(RequestContext))]
    [CodeGenSuppress("CheckLabelsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingLabelFields>), typeof(RequestContext))]
    [CodeGenSuppress("GetRevisions", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetRevisionsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("CheckRevisions", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingFields>), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("CheckRevisionsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SettingFields>), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetConfigurationSettings", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(RequestContext))]
    [CodeGenSuppress("GetConfigurationSettingsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(RequestContext))]

    public partial class ConfigurationClient
    {
        private const string OTelAttributeKey = "az.appconfiguration.key";
        private readonly SyncTokenPolicy _syncTokenPolicy;
        private readonly string _syncToken;

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
            Pipeline = CreatePipeline(options, new AuthenticationPolicy(credential, secret), _syncTokenPolicy);

            ClientDiagnostics = new ClientDiagnostics(options, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The <see cref="Uri"/> referencing the app configuration storage.</param>
        /// <param name="credential">The token credential used to sign requests.</param>
        /// <param name="options">Options that allow configuration of requests sent to the configuration store.</param>
        /// <remarks> The <paramref name="credential"/>'s Microsoft Entra audience is configurable via the <see cref="ConfigurationClientOptions.Audience"/> property.
        /// If no token audience is set, Azure Public Cloud is used. If using an Azure sovereign cloud, configure the audience accordingly.
        /// </remarks>
        public ConfigurationClient(Uri endpoint, TokenCredential credential, ConfigurationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            _endpoint = endpoint;
            _syncTokenPolicy = new SyncTokenPolicy();
            Pipeline = CreatePipeline(options, new BearerTokenAuthenticationPolicy(credential, options.GetDefaultScope(endpoint)), _syncTokenPolicy);
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
            Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
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
            Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
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

                using Response response = await SetConfigurationSettingInternalAsync(setting.Key, contentType.ToString(), content, setting.Label, _syncToken, requestOptions, context: context).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                    case 201:
                        return await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false);
                    default:
                        throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser());
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

                using Response response = SetConfigurationSettingInternal(setting.Key, contentType.ToString(), content, setting.Label, _syncToken, requestOptions, context: context);
                switch (response.Status)
                {
                    case 200:
                    case 201:
                        return CreateResponse(response);
                    default:
                        throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser());
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

                using Response response = await SetConfigurationSettingInternalAsync(setting.Key, contentType.ToString(), content, setting.Label, _syncToken, requestOptions, context: context).ConfigureAwait(false);
                return response.Status switch
                {
                    200 => await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false),

                    // Throws on 412 if resource was modified.
                    _ => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser()),
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

                using Response response = SetConfigurationSettingInternal(setting.Key, contentType.ToString(), content, setting.Label, _syncToken, requestOptions, context: context);

                return response.Status switch
                {
                    200 => CreateResponse(response),

                    // Throws on 412 if resource was modified.
                    _ => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser()),
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

                using Response response = await DeleteConfigurationSettingAsync(key, label, _syncToken, requestOptions?.IfMatch, context).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => response,
                    204 => response,

                    // Throws on 412 if resource was modified.
                    _ => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser()),
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

                using Response response = DeleteConfigurationSetting(key, label, _syncToken, requestOptions?.IfMatch, context);

                return response.Status switch
                {
                    200 => response,
                    204 => response,

                    // Throws on 412 if resource was modified.
                    _ => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser()),
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
                context.AddClassifier(304, isError: false);

                var dateTime = acceptDateTime.HasValue ? acceptDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture) : null;

                using Response response = await GetConfigurationSettingAsync(key, label, null, _syncToken, dateTime, conditions, null, context).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => await CreateResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    304 => CreateResourceModifiedResponse(response),
                    _ => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser())
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
                context.AddClassifier(304, isError: false);

                var dateTime = acceptDateTime.HasValue ? acceptDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture) : null;
                using Response response = GetConfigurationSetting(key, label, null, _syncToken, dateTime, conditions, null, context);

                return response.Status switch
                {
                    200 => CreateResponse(response),
                    304 => CreateResourceModifiedResponse(response),
                    _ => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser())
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

            var pageableImplementation = GetConfigurationSettingsPageableImplementation(selector, cancellationToken);

            return new AsyncConditionalPageable(pageableImplementation);
        }

        /// <summary>
        /// Retrieves one or more <see cref="ConfigurationSetting"/> entities that match the options specified in the passed-in <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="ConfigurationSetting"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<ConfigurationSetting> GetConfigurationSettings(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));

            var pageableImplementation = GetConfigurationSettingsPageableImplementation(selector, cancellationToken);

            return new ConditionalPageable(pageableImplementation);
        }

        private ConditionalPageableImplementation GetConfigurationSettingsPageableImplementation(SettingSelector selector, CancellationToken cancellationToken)
        {
            var key = selector.KeyFilter;
            var label = selector.LabelFilter;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
            var tags = selector.TagsFilter;

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<string> fieldsString = selector.Fields.Split();

            context.AddClassifier(304, false);

            HttpMessage FirstPageRequest(MatchConditions conditions, int? pageSizeHint)
            {
                return CreateGetConfigurationSettingsRequest(key, label, _syncToken, null, dateTime, fieldsString, null, conditions, tags, context);
            }
            ;

            HttpMessage NextPageRequest(MatchConditions conditions, int? pageSizeHint, string nextLink)
            {
                return CreateNextGetConfigurationSettingsRequest(nextLink, key, label, _syncToken, null, dateTime, fieldsString, null, conditions, tags, context);
            }

            return new ConditionalPageableImplementation(FirstPageRequest, NextPageRequest, ParseGetConfigurationSettingsResponse, Pipeline, ClientDiagnostics, "ConfigurationClient.GetConfigurationSettings", context);
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

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(null, null, _syncToken, null, null, null, snapshotName, null, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetConfigurationSettingsRequest(nextLink, null, null, _syncToken, null, null, null, snapshotName, null, null, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, Pipeline, "ConfigurationClient.GetConfigurationSettingsForSnapshot", "items", "@nextLink", context);
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

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(null, null, _syncToken, null, null, null, snapshotName, null, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetConfigurationSettingsRequest(nextLink, null, null, _syncToken, null, null, null, snapshotName, null, null, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, Pipeline, "ConfigurationClient.GetConfigurationSettingsForSnapshot", "items", "@nextLink", context);
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

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(null, null, _syncToken, null, null, fieldsString, snapshotName, null, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetConfigurationSettingsRequest(nextLink, null, null, _syncToken, null, null, fieldsString, snapshotName, null, null, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, Pipeline, "ConfigurationClient.GetConfigurationSettingsForSnapshot", "items", "@nextLink", context);
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

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(null, null, _syncToken, null, null, fieldsString, snapshotName, null, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetConfigurationSettingsRequest(nextLink, null, null, _syncToken, null, null, fieldsString, snapshotName, null, null, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, Pipeline, "ConfigurationClient.GetConfigurationSettingsForSnapshot", "items", "@nextLink", context);
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

                Response response = await GetSnapshotAsync(snapshotName, fields, _syncToken, new MatchConditions(), context).ConfigureAwait(false);
                ConfigurationSnapshot value = (ConfigurationSnapshot)response;
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
                Response response = GetSnapshot(snapshotName, fields, _syncToken, new MatchConditions(), context);
                ConfigurationSnapshot value = (ConfigurationSnapshot)response;
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
                using RequestContent content = snapshot;
                ContentType contentType = new(HttpHeader.Common.JsonContentType.Value.ToString());

                // Start the operation
                var operationT = await CreateSnapshotAsync(wait, snapshotName, contentType.ToString(), content, _syncToken, context).ConfigureAwait(false);

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
                using RequestContent content = snapshot;
                ContentType contentType = new(HttpHeader.Common.JsonContentType.Value.ToString());

                // Start the operation
                var operationT = CreateSnapshot(wait, snapshotName, contentType.ToString(), content, _syncToken, context);

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

                Response response = await UpdateSnapshotStatusAsync(snapshotName, contentType.ToString(), content, _syncToken, new MatchConditions(), context).ConfigureAwait(false);
                ConfigurationSnapshot value = (ConfigurationSnapshot)response;
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

                Response response = UpdateSnapshotStatus(snapshotName, contentType.ToString(), content, _syncToken, new MatchConditions(), context);
                ConfigurationSnapshot value = (ConfigurationSnapshot)response;
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

                Response response = await UpdateSnapshotStatusAsync(snapshotName, contentType.ToString(), content, _syncToken, matchConditions, context).ConfigureAwait(false);
                ConfigurationSnapshot value = (ConfigurationSnapshot)response;
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

                Response response = UpdateSnapshotStatus(snapshotName, contentType.ToString(), content, _syncToken, matchConditions, context);
                ConfigurationSnapshot value = (ConfigurationSnapshot)response;
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

                Response response = await UpdateSnapshotStatusAsync(snapshotName, contentType.ToString(), content, _syncToken, new MatchConditions(), context).ConfigureAwait(false);
                ConfigurationSnapshot value = (ConfigurationSnapshot)response;
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

                Response response = UpdateSnapshotStatus(snapshotName, contentType.ToString(), content, _syncToken, new MatchConditions(), context);
                ConfigurationSnapshot value = (ConfigurationSnapshot)response;
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

                Response response = await UpdateSnapshotStatusAsync(snapshotName, contentType.ToString(), content, _syncToken, matchConditions, context).ConfigureAwait(false);
                ConfigurationSnapshot value = (ConfigurationSnapshot)response;
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

                Response response = UpdateSnapshotStatus(snapshotName, contentType.ToString(), content, _syncToken, matchConditions, context);
                ConfigurationSnapshot value = (ConfigurationSnapshot)response;
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
            IList<SnapshotFields> fields = selector.Fields?.Count > 0
                ? [ .. selector.Fields]
                : null;
            var status = selector.Status;

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSnapshotsRequest(name, null, fields, status, _syncToken, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetSnapshotsRequest(nextLink, name, null, fields, status, _syncToken, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ConfigurationSnapshot.DeserializeSnapshot, ClientDiagnostics, Pipeline, "ConfigurationClient.GetSnapshots", "items", "@nextLink", cancellationToken);
        }

        /// <summary> Gets a list of configuration snapshots. </summary>
        /// <param name="selector">Set of options for selecting <see cref="ConfigurationSnapshot"/>.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ConfigurationSnapshot> GetSnapshots(SnapshotSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var name = selector.NameFilter;
            IList<SnapshotFields> fields = selector.Fields?.Count > 0
                ? [.. selector.Fields]
                : null;
            var status = selector.Status;

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSnapshotsRequest(name, null, fields, status, _syncToken, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetSnapshotsRequest(nextLink, name, null, fields, status, _syncToken, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationSnapshot.DeserializeSnapshot, ClientDiagnostics, Pipeline, "ConfigurationClient.GetSnapshots", "items", "@nextLink", cancellationToken);
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
            var tags = selector.TagsFilter;
            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<string> fieldsString = selector.Fields.Split();

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetRevisionsRequest(key, label, _syncToken, null, dateTime, fieldsString, tags, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetRevisionsRequest(nextLink, key, label, _syncToken, null, dateTime, fieldsString, tags, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, Pipeline, "ConfigurationClient.GetRevisions", "items", "@nextLink", context);
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
            var tags = selector.TagsFilter;
            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<string> fieldsString = selector.Fields.Split();

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetRevisionsRequest(key, label, _syncToken, null, dateTime, fieldsString, tags, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetRevisionsRequest(nextLink, key, label, _syncToken, null, dateTime, fieldsString, tags, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, Pipeline, "ConfigurationClient.GetRevisions", "items", "@nextLink", context);
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

        /// <summary> Gets a list of labels. </summary>
        /// <param name="selector">Set of options for selecting <see cref="SettingLabel"/>.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<SettingLabel> GetLabelsAsync(SettingLabelSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var name = selector.NameFilter;
            List<SettingLabelFields> fields = selector.Fields?.Count > 0
                ? [.. selector.Fields]
                : null;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetLabelsRequest(name, _syncToken, null, dateTime, fields, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetLabelsRequest(nextLink, name, _syncToken, null, dateTime, fields, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, SettingLabel.DeserializeLabel, ClientDiagnostics, Pipeline, "ConfigurationClient.GetLabels", "items", "@nextLink", cancellationToken);
        }

        /// <summary> Gets a list of labels. </summary>
        /// <param name="selector">Set of options for selecting <see cref="SettingLabel"/>.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<SettingLabel> GetLabels(SettingLabelSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var name = selector.NameFilter;
            List<SettingLabelFields> fields = selector.Fields?.Count > 0
               ? [.. selector.Fields]
               : null;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetLabelsRequest(name, _syncToken, null, dateTime, fields, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetLabelsRequest(nextLink, name, _syncToken, null, dateTime, fields, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, SettingLabel.DeserializeLabel, ClientDiagnostics, Pipeline, "ConfigurationClient.GetLabels", "items", "@nextLink", cancellationToken);
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
                    _ => throw new RequestFailedException(response, null, new ConfigurationRequestFailedDetailsParser()),
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
            Response response = isReadOnly
                ? await CreateReadOnlyLockAsync(key, label, _syncToken, requestOptions, context).ConfigureAwait(false)
                : await DeleteReadOnlyLockAsync(key, label, _syncToken, requestOptions, context).ConfigureAwait(false);
            return response;
        }

        private Response ToCreateResponse(string key, string label, MatchConditions requestOptions, bool isReadOnly, RequestContext context)
        {
            Response response = isReadOnly
                ? CreateReadOnlyLock(key, label, _syncToken, requestOptions, context)
                : DeleteReadOnlyLock(key, label, _syncToken, requestOptions, context);
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

        /// <summary>
        /// Parses the response of a <see cref="GetConfigurationSettings(SettingSelector, CancellationToken)"/> request.
        /// The "@nextLink" JSON property is not reliable since the service does not return a response body for 304
        /// responses. This method also attempts to extract the next link address from the "Link" header.
        /// </summary>
        private (List<ConfigurationSetting> Values, string NextLink) ParseGetConfigurationSettingsResponse(Response response)
        {
            var values = new List<ConfigurationSetting>();
            string nextLink = null;

            if (response.Status == 200)
            {
                var document = response.ContentStream != null ? JsonDocument.Parse(response.ContentStream) : JsonDocument.Parse(response.Content);

                if (document.RootElement.TryGetProperty("items", out var itemsValue))
                {
                    foreach (var jsonItem in itemsValue.EnumerateArray())
                    {
                        ConfigurationSetting setting = ConfigurationServiceSerializer.ReadSetting(jsonItem);
                        values.Add(setting);
                    }
                }

                if (document.RootElement.TryGetProperty("@nextLink", out var nextLinkValue))
                {
                    nextLink = nextLinkValue.GetString();
                }
            }

            // The "Link" header is formatted as:
            // <nextLink>; rel="next"
            if (nextLink == null && response.Headers.TryGetValue("Link", out string linkHeader))
            {
                int nextLinkEndIndex = linkHeader.IndexOf('>');
                nextLink = linkHeader.Substring(1, nextLinkEndIndex - 1);
            }

            return (values, nextLink);
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
            private const string TroubleshootingMessage =
                "For troubleshooting information, see https://aka.ms/azsdk/net/appconfiguration/troubleshoot.";
            public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
            {
                switch (response.Status)
                {
                    case 409:
                        error = new ResponseError(null, $"The setting is read only. {TroubleshootingMessage}");
                        data = null;
                        return true;
                    case 412:
                        error = new ResponseError(null, $"Setting was already present. {TroubleshootingMessage}");
                        data = null;
                        return true;
                    default:
                        error = new ResponseError(null, TroubleshootingMessage);
                        data = null;
                        return true;
                }
            }
        }

        //
        //
        // Feature Management

        /// <summary> Initializes a new instance of FeatureManagement. </summary>
        internal virtual FeatureManagement GetFeatureManagementClient()
        {
            return Volatile.Read(ref _cachedFeatureManagement) ?? Interlocked.CompareExchange(ref _cachedFeatureManagement, new FeatureManagement(ClientDiagnostics, Pipeline, _endpoint, _apiVersion), null) ?? _cachedFeatureManagement;
        }

        /// <summary>
        /// [Protocol Method] Gets a list of feature flags.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> A filter used to match feature flag names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Pageable<BinaryData> GetFeatureFlags(string name, string label, string syncToken, string after, string acceptDatetime, IEnumerable<FeatureFlagFields> @select, MatchConditions matchConditions, IEnumerable<string> tags, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlags)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().GetFeatureFlags(name, label, syncToken, after, acceptDatetime, @select, matchConditions, tags, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets a list of feature flags.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> A filter used to match feature flag names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual AsyncPageable<BinaryData> GetFeatureFlagsAsync(string name, string label, string syncToken, string after, string acceptDatetime, IEnumerable<FeatureFlagFields> @select, MatchConditions matchConditions, IEnumerable<string> tags, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlags)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().GetFeatureFlagsAsync(name, label, syncToken, after, acceptDatetime, @select, matchConditions, tags, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of feature flags. </summary>
        /// <param name="name"> A filter used to match feature flag names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Pageable<FeatureFlag> GetFeatureFlags(string name = default, string label = default, string syncToken = default, string after = default, string acceptDatetime = default, IEnumerable<FeatureFlagFields> @select = default, MatchConditions matchConditions = default, IEnumerable<string> tags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlags)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().GetFeatureFlags(name: name, label: label, syncToken: syncToken, after: after, acceptDatetime: acceptDatetime, select: @select, matchConditions: matchConditions, tags: tags, cancellationToken: cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of feature flags. </summary>
        /// <param name="name"> A filter used to match feature flag names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual AsyncPageable<FeatureFlag> GetFeatureFlagsAsync(string name = default, string label = default, string syncToken = default, string after = default, string acceptDatetime = default, IEnumerable<FeatureFlagFields> @select = default, MatchConditions matchConditions = default, IEnumerable<string> tags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlags)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().GetFeatureFlagsAsync(name: name, label: label, syncToken: syncToken, after: after, acceptDatetime: acceptDatetime, select: @select, matchConditions: matchConditions, tags: tags, cancellationToken: cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Requests the headers and status of the given resource.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> A filter used to match feature flag names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response CheckFeatureFlags(string name, string label, string syncToken, string after, string acceptDatetime, IEnumerable<FeatureFlagFields> @select, MatchConditions matchConditions, IEnumerable<string> tags, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlags)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().CheckFeatureFlags(name, label, syncToken, after, acceptDatetime, @select, matchConditions, tags, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Requests the headers and status of the given resource.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> A filter used to match feature flag names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> CheckFeatureFlagsAsync(string name, string label, string syncToken, string after, string acceptDatetime, IEnumerable<FeatureFlagFields> @select, MatchConditions matchConditions, IEnumerable<string> tags, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlags)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await GetFeatureManagementClient().CheckFeatureFlagsAsync(name, label, syncToken, after, acceptDatetime, @select, matchConditions, tags, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter used to match feature flag names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response CheckFeatureFlags(string name = default, string label = default, string syncToken = default, string after = default, string acceptDatetime = default, IEnumerable<FeatureFlagFields> @select = default, MatchConditions matchConditions = default, IEnumerable<string> tags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlags)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return CheckFeatureFlags(name: name, label: label, syncToken: syncToken, after: after, acceptDatetime: acceptDatetime, select: @select, matchConditions: matchConditions, tags: tags, cancellationToken: cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter used to match feature flag names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response> CheckFeatureFlagsAsync(string name = default, string label = default, string syncToken = default, string after = default, string acceptDatetime = default, IEnumerable<FeatureFlagFields> @select = default, MatchConditions matchConditions = default, IEnumerable<string> tags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlags)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await CheckFeatureFlagsAsync(name: name, label: label, syncToken: syncToken, after: after, acceptDatetime: acceptDatetime, select: @select, matchConditions: matchConditions, tags: tags, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets a single feature flag.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the feature flag. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetFeatureFlag(string name, string label, IEnumerable<FeatureFlagFields> @select, string syncToken, string acceptDatetime, MatchConditions matchConditions, IEnumerable<string> tags, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().GetFeatureFlag(name, label, @select, syncToken, acceptDatetime, matchConditions, tags, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets a single feature flag.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the feature flag. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetFeatureFlagAsync(string name, string label, IEnumerable<FeatureFlagFields> @select, string syncToken, string acceptDatetime, MatchConditions matchConditions, IEnumerable<string> tags, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await GetFeatureManagementClient().GetFeatureFlagAsync(name, label, @select, syncToken, acceptDatetime, matchConditions, tags, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single feature flag. </summary>
        /// <param name="name"> The name of the feature flag. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<FeatureFlag> GetFeatureFlag(string name, string label = default, IEnumerable<FeatureFlagFields> @select = default, string syncToken = default, string acceptDatetime = default, MatchConditions matchConditions = default, IEnumerable<string> tags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().GetFeatureFlag(name, label, @select, syncToken, acceptDatetime, matchConditions, tags, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single feature flag. </summary>
        /// <param name="name"> The name of the feature flag. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<FeatureFlag>> GetFeatureFlagAsync(string name, string label = default, IEnumerable<FeatureFlagFields> @select = default, string syncToken = default, string acceptDatetime = default, MatchConditions matchConditions = default, IEnumerable<string> tags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await GetFeatureManagementClient().GetFeatureFlagAsync(name, label, @select, syncToken, acceptDatetime, matchConditions, tags, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Requests the headers and status of the given resource.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the feature flag to retrieve. </param>
        /// <param name="label"> The label of the feature flag to retrieve. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response CheckFeatureFlag(string name, string label, string syncToken, string acceptDatetime, MatchConditions matchConditions, IEnumerable<FeatureFlagFields> @select, IEnumerable<string> tags, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().CheckFeatureFlag(name, label, syncToken, acceptDatetime, matchConditions, @select, tags, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Requests the headers and status of the given resource.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the feature flag to retrieve. </param>
        /// <param name="label"> The label of the feature flag to retrieve. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> CheckFeatureFlagAsync(string name, string label, string syncToken, string acceptDatetime, MatchConditions matchConditions, IEnumerable<FeatureFlagFields> @select, IEnumerable<string> tags, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await GetFeatureManagementClient().CheckFeatureFlagAsync(name, label, syncToken, acceptDatetime, matchConditions, @select, tags, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> The name of the feature flag to retrieve. </param>
        /// <param name="label"> The label of the feature flag to retrieve. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response CheckFeatureFlag(string name, string label = default, string syncToken = default, string acceptDatetime = default, MatchConditions matchConditions = default, IEnumerable<FeatureFlagFields> @select = default, IEnumerable<string> tags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().CheckFeatureFlag(name, label, syncToken, acceptDatetime, matchConditions, @select, tags, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> The name of the feature flag to retrieve. </param>
        /// <param name="label"> The label of the feature flag to retrieve. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="acceptDatetime">
        /// Requests the server to respond with the state of the resource at the specified
        /// time.
        /// </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/keyvaluefiltering
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response> CheckFeatureFlagAsync(string name, string label = default, string syncToken = default, string acceptDatetime = default, MatchConditions matchConditions = default, IEnumerable<FeatureFlagFields> @select = default, IEnumerable<string> tags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await GetFeatureManagementClient().CheckFeatureFlagAsync(name, label, syncToken, acceptDatetime, matchConditions, @select, tags, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a feature flag.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the feature flag to create. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="label"> The label of the feature flag to create. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response PutFeatureFlag(string name, RequestContent content, string label = default, string syncToken = default, MatchConditions matchConditions = default, RequestContext context = null)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(PutFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().PutFeatureFlag(name, content, label, syncToken, matchConditions, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a feature flag.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the feature flag to create. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="label"> The label of the feature flag to create. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> PutFeatureFlagAsync(string name, RequestContent content, string label = default, string syncToken = default, MatchConditions matchConditions = default, RequestContext context = null)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(PutFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await GetFeatureManagementClient().PutFeatureFlagAsync(name, content, label, syncToken, matchConditions, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a feature flag. </summary>
        /// <param name="name"> The name of the feature flag to create. </param>
        /// <param name="entity"> The feature flag to create. </param>
        /// <param name="label"> The label of the feature flag to create. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<FeatureFlag> PutFeatureFlag(string name, FeatureFlag entity = default, string label = default, string syncToken = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(PutFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().PutFeatureFlag(name, entity, label, syncToken, matchConditions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a feature flag. </summary>
        /// <param name="name"> The name of the feature flag to create. </param>
        /// <param name="entity"> The feature flag to create. </param>
        /// <param name="label"> The label of the feature flag to create. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<FeatureFlag>> PutFeatureFlagAsync(string name, FeatureFlag entity = default, string label = default, string syncToken = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(PutFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await GetFeatureManagementClient().PutFeatureFlagAsync(name, entity, label, syncToken, matchConditions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Deletes a feature flag.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the feature flag to delete. </param>
        /// <param name="label"> The label of the feature flag to delete. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="ifMatch">
        /// Used to perform an operation only if the targeted resource's etag matches the
        /// value provided.
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response DeleteFeatureFlag(string name, string label, string syncToken, ETag? ifMatch, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();
            try
            {
                return GetFeatureManagementClient().DeleteFeatureFlag(name, label, syncToken, ifMatch, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Deletes a feature flag.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the feature flag to delete. </param>
        /// <param name="label"> The label of the feature flag to delete. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="ifMatch">
        /// Used to perform an operation only if the targeted resource's etag matches the
        /// value provided.
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> DeleteFeatureFlagAsync(string name, string label, string syncToken, ETag? ifMatch, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteFeatureFlagAsync)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();
            try
            {
                return await GetFeatureManagementClient().DeleteFeatureFlagAsync(name, label, syncToken, ifMatch, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a feature flag. </summary>
        /// <param name="name"> The name of the feature flag to delete. </param>
        /// <param name="label"> The label of the feature flag to delete. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="ifMatch">
        /// Used to perform an operation only if the targeted resource's etag matches the
        /// value provided.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<FeatureFlag> DeleteFeatureFlag(string name, string label = default, string syncToken = default, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().DeleteFeatureFlag(name, label, syncToken, ifMatch, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a feature flag. </summary>
        /// <param name="name"> The name of the feature flag to delete. </param>
        /// <param name="label"> The label of the feature flag to delete. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="ifMatch">
        /// Used to perform an operation only if the targeted resource's etag matches the
        /// value provided.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<FeatureFlag>> DeleteFeatureFlagAsync(string name, string label = default, string syncToken = default, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await GetFeatureManagementClient().DeleteFeatureFlagAsync(name, label, syncToken, ifMatch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets a list of feature flag revisions.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> A filter used to match names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Pageable<BinaryData> GetFeatureFlagRevisions(string name, string label, string after, IEnumerable<SettingFields> @select, IEnumerable<string> tags, string syncToken, MatchConditions matchConditions, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlagRevisions)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();
            try
            {
                return GetFeatureManagementClient().GetFeatureFlagRevisions(name, label, after, @select, tags, syncToken, matchConditions, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets a list of feature flag revisions.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> A filter used to match names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual AsyncPageable<BinaryData> GetFeatureFlagRevisionsAsync(string name, string label, string after, IEnumerable<SettingFields> @select, IEnumerable<string> tags, string syncToken, MatchConditions matchConditions, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlagRevisionsAsync)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();
            try
            {
                return GetFeatureManagementClient().GetFeatureFlagRevisionsAsync(name, label, after, @select, tags, syncToken, matchConditions, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of feature flag revisions. </summary>
        /// <param name="name"> A filter used to match names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Pageable<FeatureFlag> GetFeatureFlagRevisions(string name = default, string label = default, string after = default, IEnumerable<SettingFields> @select = default, IEnumerable<string> tags = default, string syncToken = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlagRevisions)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().GetFeatureFlagRevisions(name, label, after, @select, tags, syncToken, matchConditions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of feature flag revisions. </summary>
        /// <param name="name"> A filter used to match names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual AsyncPageable<FeatureFlag> GetFeatureFlagRevisionsAsync(string name = default, string label = default, string after = default, IEnumerable<SettingFields> @select = default, IEnumerable<string> tags = default, string syncToken = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlagRevisions)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().GetFeatureFlagRevisionsAsync(name, label, after, @select, tags, syncToken, matchConditions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Requests the headers and status of the given resource.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> A filter used to match names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response CheckFeatureFlagRevisions(string name, string label, string after, IEnumerable<SettingFields> @select, IEnumerable<string> tags, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlagRevisions)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();
            try
            {
                return GetFeatureManagementClient().CheckFeatureFlagRevisions(name, label, after, @select, tags, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Requests the headers and status of the given resource.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> A filter used to match names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> CheckFeatureFlagRevisionsAsync(string name, string label, string after, IEnumerable<SettingFields> @select, IEnumerable<string> tags, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlagRevisionsAsync)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();
            try
            {
                return await GetFeatureManagementClient().CheckFeatureFlagRevisionsAsync(name, label, after, @select, tags, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter used to match names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response CheckFeatureFlagRevisions(string name = default, string label = default, string after = default, IEnumerable<SettingFields> @select = default, IEnumerable<string> tags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlagRevisions)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return GetFeatureManagementClient().CheckFeatureFlagRevisions(name, label, after, @select, tags, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter used to match names. </param>
        /// <param name="label">
        /// A filter used to match labels. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="after">
        /// Instructs the server to return elements that appear after the element referred
        /// to by the specified token.
        /// </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="tags">
        /// A filter used to query by tags. Syntax reference:
        /// https://aka.ms/azconfig/docs/restapirevisions
        /// </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response> CheckFeatureFlagRevisionsAsync(string name = default, string label = default, string after = default, IEnumerable<SettingFields> @select = default, IEnumerable<string> tags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(CheckFeatureFlagRevisions)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await GetFeatureManagementClient().CheckFeatureFlagRevisionsAsync(name, label, after, @select, tags, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Locks a feature flag.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the feature flag to lock. </param>
        /// <param name="label"> The label, if any, of the feature flag to lock. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response PutFeatureFlagLock(string name, string label, string syncToken, MatchConditions matchConditions, RequestContext context)
        {
            return GetFeatureManagementClient().PutFeatureFlagLock(name, label, syncToken, matchConditions, context);
        }

        /// <summary>
        /// [Protocol Method] Locks a feature flag.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the feature flag to lock. </param>
        /// <param name="label"> The label, if any, of the feature flag to lock. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> PutFeatureFlagLockAsync(string name, string label, string syncToken, MatchConditions matchConditions, RequestContext context)
        {
            return await GetFeatureManagementClient().PutFeatureFlagLockAsync(name, label, syncToken, matchConditions, context).ConfigureAwait(false);
        }

        /// <summary> Locks a feature flag. </summary>
        /// <param name="name"> The name of the feature flag to lock. </param>
        /// <param name="label"> The label, if any, of the feature flag to lock. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<FeatureFlag> PutFeatureFlagLock(string name, string label = default, string syncToken = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            return GetFeatureManagementClient().PutFeatureFlagLock(name, label, syncToken, matchConditions, cancellationToken);
        }

        /// <summary> Locks a feature flag. </summary>
        /// <param name="name"> The name of the feature flag to lock. </param>
        /// <param name="label"> The label, if any, of the feature flag to lock. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<FeatureFlag>> PutFeatureFlagLockAsync(string name, string label = default, string syncToken = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            return await GetFeatureManagementClient().PutFeatureFlagLockAsync(name, label, syncToken, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// [Protocol Method] Unlocks a feature flag.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The key of the feature flag to unlock. </param>
        /// <param name="label"> The label, if any, of the feature flag to unlock. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response DeleteFeatureFlagLock(string name, string label, string syncToken, MatchConditions matchConditions, RequestContext context)
        {
            return GetFeatureManagementClient().DeleteFeatureFlagLock(name, label, syncToken, matchConditions, context);
        }

        /// <summary>
        /// [Protocol Method] Unlocks a feature flag.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The key of the feature flag to unlock. </param>
        /// <param name="label"> The label, if any, of the feature flag to unlock. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> DeleteFeatureFlagLockAsync(string name, string label, string syncToken, MatchConditions matchConditions, RequestContext context)
        {
            return await GetFeatureManagementClient().DeleteFeatureFlagLockAsync(name, label, syncToken, matchConditions, context).ConfigureAwait(false);
        }

        /// <summary> Unlocks a feature flag. </summary>
        /// <param name="name"> The key of the feature flag to unlock. </param>
        /// <param name="label"> The label, if any, of the feature flag to unlock. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<FeatureFlag> DeleteFeatureFlagLock(string name, string label = default, string syncToken = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            return GetFeatureManagementClient().DeleteFeatureFlagLock(name, label, syncToken, matchConditions, cancellationToken);
        }

        /// <summary> Unlocks a feature flag. </summary>
        /// <param name="name"> The key of the feature flag to unlock. </param>
        /// <param name="label"> The label, if any, of the feature flag to unlock. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<FeatureFlag>> DeleteFeatureFlagLockAsync(string name, string label = default, string syncToken = default, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            return await GetFeatureManagementClient().DeleteFeatureFlagLockAsync(name, label, syncToken, matchConditions, cancellationToken).ConfigureAwait(false);
        }
    }
}
