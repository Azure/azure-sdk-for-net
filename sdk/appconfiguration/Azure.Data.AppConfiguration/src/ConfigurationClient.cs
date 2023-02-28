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
    [CodeGenSuppress("CreateSnapshot", typeof(string), typeof(RequestContent), typeof(ContentType), typeof(RequestContext))]
    [CodeGenSuppress("CreateSnapshotAsync", typeof(string), typeof(RequestContent), typeof(ContentType), typeof(RequestContext))]
    [CodeGenSuppress("GetSnapshot", typeof(string), typeof(IEnumerable<string>), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("GetSnapshotAsync", typeof(string), typeof(IEnumerable<string>), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("UpdateSnapshotStatus", typeof(string), typeof(RequestContent), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("UpdateSnapshotStatusAsync", typeof(string), typeof(RequestContent), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("CheckSnapshotsAsync", typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckSnapshots", typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckSnapshotAsync", typeof(string), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("CheckSnapshot", typeof(string), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeyValues", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeyValuesAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeys", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeysAsync", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeyValue", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("CheckKeyValueAsync", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("CheckLabels", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("CheckLabelsAsync", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("CheckRevisions", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("CheckRevisionsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("CreateReadOnlyLock", typeof(string), typeof(string), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("CreateReadOnlyLockAsync", typeof(string), typeof(string), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("DeleteReadOnlyLock", typeof(string), typeof(string), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("DeleteReadOnlyLockAsync", typeof(string), typeof(string), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("GetConfigurationSetting", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("GetConfigurationSettingAsync", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("GetConfigurationSettings", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetConfigurationSettingsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetKeys", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetKeysAsync", typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetLabels", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetLabelsAsync", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetRevisions", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetRevisionsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("SetConfigurationSetting", typeof(string), typeof(RequestContent), typeof(ContentType), typeof(string), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("SetConfigurationSettingAsync", typeof(string), typeof(RequestContent), typeof(ContentType), typeof(string), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("DeleteConfigurationSetting", typeof(string), typeof(string), typeof(ETag), typeof(RequestContext))]
    [CodeGenSuppress("DeleteConfigurationSettingAsync", typeof(string), typeof(string), typeof(ETag), typeof(RequestContext))]
    [CodeGenSuppress("GetConfigurationSetting", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(MatchConditions), typeof(RequestContext))]
    [CodeGenSuppress("GetConfigurationSettingAsync", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<string>), typeof(MatchConditions), typeof(RequestContext))]
    public partial class ConfigurationClient
    {
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
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal ConfigurationClient(Uri endpoint) : this(endpoint, (string)null, new ConfigurationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConfigurationClient. </summary>
        /// <param name="endpoint"> The endpoint of the App Configuration instance to send requests to. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal ConfigurationClient(Uri endpoint, string syncToken, ConfigurationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ConfigurationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
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
            scope.AddAttribute("key", setting?.Key);
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
                        throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(null, "Setting was already present.")).ConfigureAwait(false);
                    default:
                        throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
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
            scope.AddAttribute("key", setting?.Key);
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
                        throw ClientDiagnostics.CreateRequestFailedException(response, new ResponseError(null, "Setting was already present."));
                    default:
                        throw ClientDiagnostics.CreateRequestFailedException(response);
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
            scope.AddAttribute("key", setting?.Key);
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
                    409 => throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(null, "The setting is read only")).ConfigureAwait(false),

                    // Throws on 412 if resource was modified.
                    _ => throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false),
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
            scope.AddAttribute("key", setting?.Key);
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
                    409 => throw ClientDiagnostics.CreateRequestFailedException(response, new ResponseError(null, "The setting is read only")),

                    // Throws on 412 if resource was modified.
                    _ => throw ClientDiagnostics.CreateRequestFailedException(response),
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
            scope.AddAttribute("key", key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using Response response = await DeleteConfigurationSettingAsync(key, label, requestOptions?.IfMatch, context).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => response,
                    204 => response,
                    409 => throw ClientDiagnostics.CreateRequestFailedException(response, new ResponseError(null, "The setting is read only")),

                    // Throws on 412 if resource was modified.
                    _ => throw ClientDiagnostics.CreateRequestFailedException(response)
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
            scope.AddAttribute("key", key);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using Response response = DeleteConfigurationSetting(key, label, requestOptions?.IfMatch, context);

                return response.Status switch
                {
                    200 => response,
                    204 => response,
                    409 => throw ClientDiagnostics.CreateRequestFailedException(response, new ResponseError(null, "The setting is read only.")),

                    // Throws on 412 if resource was modified.
                    _ => throw ClientDiagnostics.CreateRequestFailedException(response)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a key-value. </summary>
        /// <param name="key"> The key of the key-value to delete. </param>
        /// <param name="label"> The label of the key-value to delete. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="key"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        internal virtual async Task<Response> DeleteConfigurationSettingAsync(string key, string label, ETag? ifMatch, RequestContext context)
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.DeleteConfigurationSetting");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteConfigurationSettingRequest(key, label, ifMatch, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a key-value. </summary>
        /// <param name="key"> The key of the key-value to delete. </param>
        /// <param name="label"> The label of the key-value to delete. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="key"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual Response DeleteConfigurationSetting(string key, string label, ETag? ifMatch, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.DeleteConfigurationSetting");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteConfigurationSettingRequest(key, label, ifMatch, context);
                return _pipeline.ProcessMessage(message, context);
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
            scope.AddAttribute(nameof(key), key);
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
                    _ => throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false),
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
            scope.AddAttribute(nameof(key), key);
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
                    _ => throw ClientDiagnostics.CreateRequestFailedException(response),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="key"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Generated/Docs/ConfigurationClient.xml" path="doc/members/member[@name='GetConfigurationSettingAsync(String,String,String,IEnumerable,MatchConditions,RequestContext)']/*" />
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        internal virtual async Task<Response> GetConfigurationSettingAsync(string key, string label, string acceptDatetime, IEnumerable<string> select, MatchConditions matchConditions, RequestContext context)
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.GetConfigurationSetting");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetConfigurationSettingRequest(key, label, acceptDatetime, select, matchConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="key"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Generated/Docs/ConfigurationClient.xml" path="doc/members/member[@name='GetConfigurationSetting(String,String,String,IEnumerable,MatchConditions,RequestContext)']/*" />
        internal virtual Response GetConfigurationSetting(string key, string label, string acceptDatetime, IEnumerable<string> select, MatchConditions matchConditions, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.GetConfigurationSetting");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetConfigurationSettingRequest(key, label, acceptDatetime, select, matchConditions, context);
                return _pipeline.ProcessMessage(message, context);
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
            IEnumerable<string> fieldsString = selector.Fields == SettingFields.All ? null : selector.Fields.ToString().ToLowerInvariant().Replace("isreadonly", "locked").Split(',');

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(key, label, null, dateTime, fieldsString, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetConfigurationSettingsNextPageRequest(nextLink, key, label, null, dateTime, fieldsString, null, context);
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
            IEnumerable<string> fieldsString = selector.Fields == SettingFields.All ? null : selector.Fields.ToString().ToLowerInvariant().Replace("isreadonly", "locked").Split(',');

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetConfigurationSettingsRequest(key, label, null, dateTime, fieldsString, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetConfigurationSettingsNextPageRequest(nextLink, key, label, null, dateTime, fieldsString, null, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationServiceSerializer.ReadSetting, ClientDiagnostics, _pipeline, "ConfigurationClient.GetConfigurationSettings", "items", "@nextLink", context);
        }

        /// <summary> Gets a single configuration setting snapshot. </summary>
        /// <param name="name"> The name of the configuration setting snapshot to retrieve. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSettingsSnapshot>> GetSnapshotAsync(string name, IEnumerable<SnapshotFields> select = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.GetSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                List<string> snapshotFields = null;
                if (select != null)
                {
                    snapshotFields = new();
                    foreach (var field in select)
                    {
                        snapshotFields.Add(field.ToString());
                    }
                }

                Response response = await GetSnapshotAsync(name, snapshotFields, context).ConfigureAwait(false);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single configuration setting snapshot. </summary>
        /// <param name="name"> The name of the configuration setting snapshot to retrieve. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSettingsSnapshot> GetSnapshot(string name, IEnumerable<SnapshotFields> select = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.GetSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                List<string> snapshotFields = null;
                if (select != null)
                {
                    snapshotFields = new();
                    foreach (var field in select)
                    {
                        snapshotFields.Add(field.ToString());
                    }
                }

                Response response = GetSnapshot(name, snapshotFields, context);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single key-value snapshot. </summary>
        /// <param name="name"> The name of the key-value snapshot to retrieve. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Generated/Docs/ConfigurationClient.xml" path="doc/members/member[@name='GetSnapshotAsync(String,IEnumerable,MatchConditions,RequestContext)']/*" />
        internal virtual async Task<Response> GetSnapshotAsync(string name, IEnumerable<string> select, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.GetSnapshot");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSnapshotRequest(name, select, new MatchConditions(), context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a single key-value snapshot. </summary>
        /// <param name="name"> The name of the key-value snapshot to retrieve. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Generated/Docs/ConfigurationClient.xml" path="doc/members/member[@name='GetSnapshot(String,IEnumerable,MatchConditions,RequestContext)']/*" />
        internal virtual Response GetSnapshot(string name, IEnumerable<string> select, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.GetSnapshot");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSnapshotRequest(name, select, new MatchConditions(), context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a configuration setting snapshot. </summary>
        /// <param name="name"> The name of the configuration setting snapshot to create. </param>
        /// <param name="snapshot"> The configuration setting snapshot to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSettingsSnapshot>> CreateSnapshotAsync(string name, ConfigurationSettingsSnapshot snapshot, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(snapshot, nameof(snapshot));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.CreateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                using RequestContent content = ConfigurationSettingsSnapshot.ToRequestContent(snapshot);
                ContentType contentType = new ContentType(HttpHeader.Common.JsonContentType.Value.ToString());

                Response response = await CreateSnapshotAsync(name, content, contentType, context).ConfigureAwait(false);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal async Task<Response> CreateSnapshotAsync(string name, RequestContent content, ContentType contentType, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.CreateSnapshot");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateSnapshotRequest(name, content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a configuration setting snapshot. </summary>
        /// <param name="name"> The name of the configuration setting snapshot to create. </param>
        /// <param name="snapshot"> The configuration setting snapshot to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSettingsSnapshot> CreateSnapshot(string name, ConfigurationSettingsSnapshot snapshot, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(snapshot, nameof(snapshot));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.CreateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
                using RequestContent content = ConfigurationSettingsSnapshot.ToRequestContent(snapshot);
                ContentType contentType = new(HttpHeader.Common.JsonContentType.Value.ToString());

                Response response = CreateSnapshot(name, content, contentType, context);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal Response CreateSnapshot(string name, RequestContent content, ContentType contentType, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.CreateSnapshot");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateSnapshotRequest(name, content, contentType, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration setting snapshot to archive. </summary>
        /// <param name="name"> The name of the configuration setting snapshot to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSettingsSnapshot>> ArchiveSnapshotAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.UpdateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = SnapshotStatus.Archived
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = await UpdateSnapshotStatusAsync(name, content, new MatchConditions(), context).ConfigureAwait(false);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration setting snapshot to archive. </summary>
        /// <param name="snapshot"> The snapshot object of the configuration setting snapshot to archive. </param>
        /// <param name="onlyIfUnchanged">TODO</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSettingsSnapshot>> ArchiveSnapshotAsync(ConfigurationSettingsSnapshot snapshot, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(snapshot, nameof(snapshot));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.UpdateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = SnapshotStatus.Archived
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                var matchConditions = new MatchConditions();

                MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = snapshot.Etag } : default;

                Response response = await UpdateSnapshotStatusAsync(snapshot.Name, content, requestOptions, context).ConfigureAwait(false);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal async Task<Response> UpdateSnapshotStatusAsync(string name, RequestContent content, MatchConditions matchConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.UpdateSnapshotStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateSnapshotStatusRequest(name, content, matchConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration setting snapshot to archive. </summary>
        /// <param name="name"> The name of the configuration setting snapshot to archive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSettingsSnapshot> ArchiveSnapshot(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.UpdateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = SnapshotStatus.Archived
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = UpdateSnapshotStatus(name, content, new MatchConditions(), context);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration setting snapshot to archive. </summary>
        /// <param name="snapshot"> The snapshot object of the configuration setting snapshot to archive. </param>
        /// <param name="onlyIfUnchanged">TODO</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSettingsSnapshot> ArchiveSnapshot(ConfigurationSettingsSnapshot snapshot, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(snapshot, nameof(snapshot));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.UpdateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = SnapshotStatus.Archived
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = snapshot.Etag } : default;

                Response response = UpdateSnapshotStatus(snapshot.Name, content, requestOptions, context);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal Response UpdateSnapshotStatus(string name, RequestContent content, MatchConditions matchConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.UpdateSnapshotStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateSnapshotStatusRequest(name, content, matchConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration setting snapshot to ready. </summary>
        /// <param name="name"> The name of the configuration setting snapshot to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSettingsSnapshot>> RecoverSnapshotAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.UpdateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = SnapshotStatus.Ready
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = await UpdateSnapshotStatusAsync(name, content, new MatchConditions(), context).ConfigureAwait(false);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration setting snapshot to ready. </summary>
        /// <param name="snapshot"> The name of the configuration setting snapshot to delete. </param>
        /// <param name="onlyIfUnchanged">TODO</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConfigurationSettingsSnapshot>> RecoverSnapshotAsync(ConfigurationSettingsSnapshot snapshot, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(snapshot, nameof(snapshot));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.UpdateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = SnapshotStatus.Ready
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                // TODO

                Response response = await UpdateSnapshotStatusAsync(snapshot.Name, content, new MatchConditions(), context).ConfigureAwait(false);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration setting snapshot to ready. </summary>
        /// <param name="name"> The name of the configuration setting snapshot to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSettingsSnapshot> RecoverSnapshot(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.UpdateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = SnapshotStatus.Ready
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = UpdateSnapshotStatus(name, content, new MatchConditions(), context);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the state of a configuration setting snapshot to ready. </summary>
        /// <param name="snapshot"> The name of the configuration setting snapshot to delete. </param>
        /// <param name="onlyIfUnchanged">TODO</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConfigurationSettingsSnapshot> RecoverSnapshot(ConfigurationSettingsSnapshot snapshot, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(snapshot, nameof(snapshot));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.UpdateSnapshot");
            scope.Start();
            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

                SnapshotUpdateParameters snapshotUpdateParameters = new()
                {
                    Status = SnapshotStatus.Ready
                };
                using RequestContent content = SnapshotUpdateParameters.ToRequestContent(snapshotUpdateParameters);

                Response response = UpdateSnapshotStatus(snapshot.Name, content, new MatchConditions(), context);
                ConfigurationSettingsSnapshot value = ConfigurationSettingsSnapshot.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list of configuration setting snapshots. </summary>
        /// <param name="name"> A filter for the name of the returned snapshots. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="status"> Used to filter returned snapshots by their status property. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ConfigurationSettingsSnapshot> GetSnapshotsAsync(string name = null, string after = null, IEnumerable<SnapshotFields> select = null, SnapshotStatus? status = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            string snapshotStatus = status?.ToString();
            List<string> snapshotFields = null;
            if (select != null)
            {
                snapshotFields = new();
                foreach (SnapshotFields field in select)
                {
                    snapshotFields.Add(field.ToString());
                }
            }

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSnapshotsRequest(name, after, snapshotFields, snapshotStatus, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSnapshotsNextPageRequest(nextLink, name, after, snapshotFields, snapshotStatus, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, ConfigurationSettingsSnapshot.DeserializeSnapshot, ClientDiagnostics, _pipeline, "ConfigurationClient.GetSnapshots", "items", "@nextLink", cancellationToken);
        }

        /// <summary> Gets a list of configuration setting snapshots. </summary>
        /// <param name="name"> A filter for the name of the returned snapshots. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="status"> Used to filter returned snapshots by their status property. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ConfigurationSettingsSnapshot> GetSnapshots(string name = null, string after = null, IEnumerable<SnapshotFields> select = null, SnapshotStatus? status = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            string snapshotStatus = status?.ToString();
            List<string> snapshotFields = null;
            if (select != null)
            {
                snapshotFields = new();
                foreach (SnapshotFields field in select)
                {
                    snapshotFields.Add(field.ToString());
                }
            }

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSnapshotsRequest(name, after, snapshotFields, snapshotStatus, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSnapshotsNextPageRequest(nextLink, name, after, snapshotFields, snapshotStatus, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, ConfigurationSettingsSnapshot.DeserializeSnapshot, ClientDiagnostics, _pipeline, "ConfigurationClient.GetSnapshots", "items", "@nextLink", cancellationToken);
        }

        /// <summary> Gets a list of key-value snapshots. </summary>
        /// <param name="name"> A filter for the name of the returned snapshots. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="status"> Used to filter returned snapshots by their status property. Allowed values: &quot;provisioning&quot; | &quot;ready&quot; | &quot;archived&quot; | &quot;failed&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Generated/Docs/ConfigurationClient.xml" path="doc/members/member[@name='GetSnapshotsAsync(String,String,IEnumerable,String,RequestContext)']/*" />
        internal virtual AsyncPageable<BinaryData> GetSnapshotsAsync(string name, string after, IEnumerable<string> select, string status, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSnapshotsRequest(name, after, select, status, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSnapshotsNextPageRequest(nextLink, name, after, select, status, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "ConfigurationClient.GetSnapshots", "items", "@nextLink", context);
        }

        /// <summary> Gets a list of key-value snapshots. </summary>
        /// <param name="name"> A filter for the name of the returned snapshots. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="status"> Used to filter returned snapshots by their status property. Allowed values: &quot;provisioning&quot; | &quot;ready&quot; | &quot;archived&quot; | &quot;failed&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Generated/Docs/ConfigurationClient.xml" path="doc/members/member[@name='GetSnapshots(String,String,IEnumerable,String,RequestContext)']/*" />
        internal virtual Pageable<BinaryData> GetSnapshots(string name, string after, IEnumerable<string> select, string status, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSnapshotsRequest(name, after, select, status, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSnapshotsNextPageRequest(nextLink, name, after, select, status, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "ConfigurationClient.GetSnapshots", "items", "@nextLink", context);
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
            IEnumerable<string> fieldsString = selector.Fields == SettingFields.All ? null : selector.Fields.ToString().ToLowerInvariant().Replace("isreadonly", "locked").Split(',');

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
            IEnumerable<string> fieldsString = selector.Fields == SettingFields.All ? null : selector.Fields.ToString().ToLowerInvariant().Replace("isreadonly", "locked").Split(',');

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

        /// <summary> Creates a key-value. </summary>
        /// <param name="key"> The key of the key-value to create. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="contentType"> Body Parameter content-type. Allowed values: &quot;application/*+json&quot; | &quot;application/json&quot; | &quot;application/json-patch+json&quot; | &quot;application/vnd.microsoft.appconfig.kv+json&quot; | &quot;application/vnd.microsoft.appconfig.kvset+json&quot; | &quot;text/json&quot;. </param>
        /// <param name="label"> The label of the key-value to create. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="key"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual async Task<Response> SetConfigurationSettingAsync(string key, RequestContent content, ContentType contentType, string label = null, MatchConditions matchConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.SetConfigurationSetting");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSetConfigurationSettingRequest(key, content, contentType, label, matchConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a key-value. </summary>
        /// <param name="key"> The key of the key-value to create. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="contentType"> Body Parameter content-type. Allowed values: &quot;application/*+json&quot; | &quot;application/json&quot; | &quot;application/json-patch+json&quot; | &quot;application/vnd.microsoft.appconfig.kv+json&quot; | &quot;application/vnd.microsoft.appconfig.kvset+json&quot; | &quot;text/json&quot;. </param>
        /// <param name="label"> The label of the key-value to create. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="key"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual Response SetConfigurationSetting(string key, RequestContent content, ContentType contentType, string label = null, MatchConditions matchConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.SetConfigurationSetting");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSetConfigurationSettingRequest(key, content, contentType, label, matchConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Locks a key-value. </summary>
        /// <param name="key"> The key of the key-value to lock. </param>
        /// <param name="label"> The label, if any, of the key-value to lock. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="key"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual async Task<Response> CreateReadOnlyLockAsync(string key, string label = null, MatchConditions matchConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.CreateReadOnlyLock");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateReadOnlyLockRequest(key, label, matchConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Locks a key-value. </summary>
        /// <param name="key"> The key of the key-value to lock. </param>
        /// <param name="label"> The label, if any, of the key-value to lock. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="key"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual Response CreateReadOnlyLock(string key, string label = null, MatchConditions matchConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.CreateReadOnlyLock");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateReadOnlyLockRequest(key, label, matchConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Unlocks a key-value. </summary>
        /// <param name="key"> The key of the key-value to unlock. </param>
        /// <param name="label"> The label, if any, of the key-value to unlock. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="key"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual async Task<Response> DeleteReadOnlyLockAsync(string key, string label = null, MatchConditions matchConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.DeleteReadOnlyLock");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteReadOnlyLockRequest(key, label, matchConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Unlocks a key-value. </summary>
        /// <param name="key"> The key of the key-value to unlock. </param>
        /// <param name="label"> The label, if any, of the key-value to unlock. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="key"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual Response DeleteReadOnlyLock(string key, string label = null, MatchConditions matchConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));

            using var scope = ClientDiagnostics.CreateScope("ConfigurationClient.DeleteReadOnlyLock");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteReadOnlyLockRequest(key, label, matchConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async ValueTask<Response<ConfigurationSetting>> SetReadOnlyAsync(string key, string label, MatchConditions requestOptions, bool isReadOnly, bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(SetReadOnly)}");
            scope.AddAttribute("key", key);
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
                    _ => throw (async
                        ? await ClientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false)
                        : ClientDiagnostics.CreateRequestFailedException(response))
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
    }
}
