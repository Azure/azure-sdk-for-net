// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
    [CodeGenSuppress("FeatureFlagClient", typeof(Uri), typeof(AzureKeyCredential), typeof(FeatureFlagClientOptions))]

    public partial class FeatureFlagClient
    {
        private const string OTelAttributeKey = "az.appconfiguration.key";
        private readonly SyncTokenPolicy _syncTokenPolicy;
        private readonly string _syncToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureFlagClient"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string with authentication option and related parameters.</param>
        public FeatureFlagClient(string connectionString)
            : this(connectionString, new FeatureFlagClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureFlagClient"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string with authentication option and related parameters.</param>
        /// <param name="options">Options that allow configuration of requests sent to the configuration store.</param>
        public FeatureFlagClient(string connectionString, FeatureFlagClientOptions options)
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
        /// <remarks> The <paramref name="credential"/>'s Microsoft Entra audience is configurable via the <see cref="FeatureFlagClientOptions.Audience"/> property.
        /// If no token audience is set, Azure Public Cloud is used. If using an Azure sovereign cloud, configure the audience accordingly.
        /// </remarks>
        public FeatureFlagClient(Uri endpoint, TokenCredential credential, FeatureFlagClientOptions options)
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
        internal FeatureFlagClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null, new FeatureFlagClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConfigurationClient. </summary>
        /// <param name="endpoint"> The endpoint of the App Configuration instance to send requests to. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        internal FeatureFlagClient(Uri endpoint, AzureKeyCredential credential, string syncToken, FeatureFlagClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new FeatureFlagClientOptions();

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
        internal FeatureFlagClient(Uri endpoint, TokenCredential credential, string syncToken, FeatureFlagClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new FeatureFlagClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _syncToken = syncToken;
            _apiVersion = options.Version;
        }

        private static HttpPipeline CreatePipeline(FeatureFlagClientOptions options, HttpPipelinePolicy authenticationPolicy, HttpPipelinePolicy syncTokenPolicy)
        {
            return HttpPipelineBuilder.Build(options,
                new HttpPipelinePolicy[] { new CustomHeadersPolicy() },
                new HttpPipelinePolicy[] { authenticationPolicy, syncTokenPolicy },
                new ResponseClassifier());
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> if the flag, uniquely identified by name and label, does not already exist in the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="enabled">The enabled state of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="FeatureFlag"/>.</returns>
        public virtual async Task<Response<FeatureFlag>> AddFeatureFlagAsync(string name, bool? enabled = null, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return await AddFeatureFlagAsync(ConfigurationModelFactory.FeatureFlag(name, enabled, label), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> if the flag, uniquely identified by name and label, does not already exist in the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="enabled">The enabled state of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="FeatureFlag"/>.</returns>
        public virtual Response<FeatureFlag> AddFeatureFlag(string name, bool? enabled = null, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return AddFeatureFlag(ConfigurationModelFactory.FeatureFlag(name, enabled, label), cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> only if the flag does not already exist in the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="FeatureFlag"/>.</returns>
        public virtual async Task<Response<FeatureFlag>> AddFeatureFlagAsync(FeatureFlag flag, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(AddFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, flag?.Name);
            scope.Start();

            try
            {
                MatchConditions requestOptions = new MatchConditions { IfNoneMatch = ETag.All };
                return await PutFeatureFlagAsync(flag.Name, flag, flag.Label, _syncToken, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> only if the flag does not already exist in the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="FeatureFlag"/>.</returns>
        public virtual Response<FeatureFlag> AddFeatureFlag(FeatureFlag flag, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(AddFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, flag?.Name);
            scope.Start();

            try
            {
                MatchConditions requestOptions = new MatchConditions { IfNoneMatch = ETag.All };
                return PutFeatureFlag(flag.Name, flag, flag.Label, _syncToken, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/>, uniquely identified by name and label, if it doesn't exist or overwrites the existing flag in the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="enabled">The enabled state of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="FeatureFlag"/> written to the configuration store.</returns>
        public virtual async Task<Response<FeatureFlag>> SetFeatureFlagAsync(string name, bool? enabled = null, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return await SetFeatureFlagAsync(ConfigurationModelFactory.FeatureFlag(name, enabled, label), false, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/>, uniquely identified by name and label, if it doesn't exist or overwrites the existing flag in the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="enabled">The enabled state of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="FeatureFlag"/> written to the configuration store.</returns>
        public virtual Response<FeatureFlag> SetFeatureFlag(string name, bool? enabled = null, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return SetFeatureFlag(ConfigurationModelFactory.FeatureFlag(name, enabled, label), false, cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> if it doesn't exist or overwrites the existing flag in the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to create.</param>
        /// <param name="onlyIfUnchanged">If set to true and the feature flag exists in the configuration store, overwrite the flag
        /// if the passed-in <see cref="FeatureFlag"/> is the same version as the one in the configuration store.  The flag versions
        /// are the same if their ETag fields match.  If the two flags are different versions, this method will throw an exception to indicate
        /// that the flag in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="FeatureFlag"/> written to the configuration store.</returns>
        public virtual async Task<Response<FeatureFlag>> SetFeatureFlagAsync(FeatureFlag flag, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(SetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, flag?.Name);
            scope.Start();

            try
            {
                MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = flag.ETag } : default;
                return await PutFeatureFlagAsync(flag.Name, flag, flag.Label, _syncToken, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> if it doesn't exist or overwrites the existing flag in the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to create.</param>
        /// <param name="onlyIfUnchanged">If set to true and the feature flag exists in the configuration store, overwrite the flag
        /// if the passed-in <see cref="FeatureFlag"/> is the same version as the one in the configuration store.  The flag versions
        /// are the same if their ETag fields match.  If the two flags are different versions, this method will throw an exception to indicate
        /// that the flag in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="FeatureFlag"/> written to the configuration store.</returns>
        public virtual Response<FeatureFlag> SetFeatureFlag(FeatureFlag flag, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(SetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, flag?.Name);
            scope.Start();

            try
            {
                MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = flag.ETag } : default;
                return PutFeatureFlag(flag.Name, flag, flag.Label, _syncToken, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual async Task<Response> DeleteFeatureFlagAsync(string name, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return await DeleteFeatureFlagAsync(name, label, default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual Response DeleteFeatureFlag(string name, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return DeleteFeatureFlag(name, label, default, cancellationToken);
        }

        /// <summary>
        /// Delete a <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to delete.</param>
        /// <param name="onlyIfUnchanged">If set to true and the feature flag exists in the configuration store, delete the flag
        /// if the passed-in <see cref="FeatureFlag"/> is the same version as the one in the configuration store. The flag versions
        /// are the same if their ETag fields match.  If the two flags are different versions, this method will throw an exception to indicate
        /// that the flag in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual async Task<Response> DeleteFeatureFlagAsync(FeatureFlag flag, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = flag.ETag } : default;
            return await DeleteFeatureFlagAsync(flag.Name, flag.Label, requestOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to delete.</param>
        /// <param name="onlyIfUnchanged">If set to true and the feature flag exists in the configuration store, delete the flag
        /// if the passed-in <see cref="FeatureFlag"/> is the same version as the one in the configuration store. The flag versions
        /// are the same if their ETag fields match.  If the two flags are different versions, this method will throw an exception to indicate
        /// that the flag in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual Response DeleteFeatureFlag(FeatureFlag flag, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = flag.ETag } : default;
            return DeleteFeatureFlag(flag.Name, flag.Label, requestOptions, cancellationToken);
        }

        private async Task<Response> DeleteFeatureFlagAsync(string name, string label, MatchConditions requestOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using Response response = await DeleteFeatureFlagAsync(name, label, _syncToken, requestOptions?.IfMatch, context).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => response,
                    204 => response,

                    // Throws on 412 if resource was modified.
                    _ => throw new RequestFailedException(response, null, new FeatureFlagRequestFailedDetailsParser()),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response DeleteFeatureFlag(string name, string label, MatchConditions requestOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using Response response = DeleteFeatureFlag(name, label, _syncToken, requestOptions?.IfMatch, context);

                return response.Status switch
                {
                    200 => response,
                    204 => response,

                    // Throws on 412 if resource was modified.
                    _ => throw new RequestFailedException(response, null, new FeatureFlagRequestFailedDetailsParser()),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/>, uniquely identified by name and label, from the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag to retrieve.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual async Task<Response<FeatureFlag>> GetFeatureFlagAsync(string name, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return await GetFeatureFlagAsync(name, label, acceptDateTime: default, conditions: default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/>, uniquely identified by name and label, from the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag to retrieve.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual Response<FeatureFlag> GetFeatureFlag(string name, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return GetFeatureFlag(name, label, acceptDateTime: default, conditions: default, cancellationToken);
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to retrieve.</param>
        /// <param name="onlyIfChanged">If set to true, only retrieve the flag from the configuration store if it has changed since the client last retrieved it.
        /// It is determined to have changed if the ETag field on the passed-in <see cref="FeatureFlag"/> is different from the ETag of the flag in the
        /// configuration store.  If it has not changed, the returned response will have have no value, and will throw if response.Value is accessed.  Callers may
        /// check the status code on the response to avoid triggering the exception.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual async Task<Response<FeatureFlag>> GetFeatureFlagAsync(FeatureFlag flag, bool onlyIfChanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            MatchConditions requestOptions = onlyIfChanged ? new MatchConditions { IfNoneMatch = flag.ETag } : default;
            return await GetFeatureFlagAsync(flag.Name, flag.Label, acceptDateTime: default, requestOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to retrieve.</param>
        /// <param name="onlyIfChanged">If set to true, only retrieve the flag from the configuration store if it has changed since the client last retrieved it.
        /// It is determined to have changed if the ETag field on the passed-in <see cref="FeatureFlag"/> is different from the ETag of the flag in the
        /// configuration store.  If it has not changed, the returned response will have have no value, and will throw if response.Value is accessed.  Callers may
        /// check the status code on the response to avoid triggering the exception.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual Response<FeatureFlag> GetFeatureFlag(FeatureFlag flag, bool onlyIfChanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            MatchConditions requestOptions = onlyIfChanged ? new MatchConditions { IfNoneMatch = flag.ETag } : default;
            return GetFeatureFlag(flag.Name, flag.Label, acceptDateTime: default, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to retrieve.</param>
        /// <param name="acceptDateTime">The flag will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual async Task<Response<FeatureFlag>> GetFeatureFlagAsync(FeatureFlag flag, DateTimeOffset acceptDateTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            return await GetFeatureFlagAsync(flag.Name, flag.Label, acceptDateTime, conditions: default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to retrieve.</param>
        /// <param name="acceptDateTime">The flag will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual Response<FeatureFlag> GetFeatureFlag(FeatureFlag flag, DateTimeOffset acceptDateTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            return GetFeatureFlag(flag.Name, flag.Label, acceptDateTime, conditions: default, cancellationToken);
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/>, uniquely identified by name and label, from the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag to retrieve.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="acceptDateTime">The flag will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="conditions">The match conditions to apply to request.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        internal virtual async Task<Response<FeatureFlag>> GetFeatureFlagAsync(string name, string label, DateTimeOffset? acceptDateTime, MatchConditions conditions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);
                context.AddClassifier(304, isError: false);

                var dateTime = acceptDateTime.HasValue ? acceptDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture) : null;

                using Response response = await GetFeatureFlagAsync(name, label, null, _syncToken, dateTime, conditions, null, context).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => CreateFeatureFlagResponse(response),
                    304 => CreateFeatureFlagResourceModifiedResponse(response),
                    _ => throw new RequestFailedException(response, null, new FeatureFlagRequestFailedDetailsParser())
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/>, uniquely identified by name and label, from the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag to retrieve.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="acceptDateTime">The flag will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="conditions">The match conditions to apply to request.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        internal virtual Response<FeatureFlag> GetFeatureFlag(string name, string label, DateTimeOffset? acceptDateTime, MatchConditions conditions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(GetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);
                context.AddClassifier(304, isError: false);

                var dateTime = acceptDateTime.HasValue ? acceptDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture) : null;
                using Response response = GetFeatureFlag(name, label, null, _syncToken, dateTime, conditions, null, context);

                return response.Status switch
                {
                    200 => CreateFeatureFlagResponse(response),
                    304 => CreateFeatureFlagResourceModifiedResponse(response),
                    _ => throw new RequestFailedException(response, null, new FeatureFlagRequestFailedDetailsParser())
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves one or more <see cref="FeatureFlag"/> entities that match the options specified in the passed-in <see cref="FeatureFlagSelector"/>.
        /// </summary>
        /// <param name="selector">Options used to select a set of <see cref="FeatureFlag"/> entities from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection containing the retrieved <see cref="FeatureFlag"/> entities.</returns>
        public virtual AsyncPageable<FeatureFlag> GetFeatureFlagsAsync(FeatureFlagSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));

            var pageableImplementation = GetFeatureFlagsPageableImplementation(selector, cancellationToken);

            return new AsyncConditionalPageable<FeatureFlag>(pageableImplementation);
        }

        /// <summary>
        /// Retrieves one or more <see cref="FeatureFlag"/> entities that match the options specified in the passed-in <see cref="FeatureFlagSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="FeatureFlag"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<FeatureFlag> GetFeatureFlags(FeatureFlagSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));

            var pageableImplementation = GetFeatureFlagsPageableImplementation(selector, cancellationToken);

            return new ConditionalPageable<FeatureFlag>(pageableImplementation);
        }

        private ConditionalPageableImplementation<FeatureFlag> GetFeatureFlagsPageableImplementation(FeatureFlagSelector selector, CancellationToken cancellationToken)
        {
            var name = selector.NameFilter;
            var label = selector.LabelFilter;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
            var tags = selector.TagsFilter;
            IEnumerable<FeatureFlagFields> fieldsSplit = selector.Fields.Split();

            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);

            context.AddClassifier(304, false);

            HttpMessage FirstPageRequest(MatchConditions conditions, int? pageSizeHint)
            {
                return CreateGetFeatureFlagsRequest(name, label, _syncToken, null, dateTime, fieldsSplit, conditions, tags, context);
            }

            HttpMessage NextPageRequest(MatchConditions conditions, int? pageSizeHint, string nextLink)
            {
                return CreateNextGetFeatureFlagsRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), name, label, _syncToken, null, dateTime, fieldsSplit, conditions, tags, context);
            }

            return new ConditionalPageableImplementation<FeatureFlag>(FirstPageRequest, NextPageRequest, ParseGetGetFeatureFlagsResponse, Pipeline, ClientDiagnostics, "ConfigurationClient.GetFeatureFlags", context);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="FeatureFlag"/> entities that match the specified <paramref name="nameFilter"/> and <paramref name="labelFilter"/>.
        /// </summary>
        /// <param name="nameFilter">Name filter that will be used to select a set of <see cref="FeatureFlag"/> entities.</param>
        /// <param name="labelFilter">Label filter that will be used to select a set of <see cref="FeatureFlag"/> entities.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncPageable<FeatureFlag> GetRevisionsAsync(string nameFilter, string labelFilter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nameFilter, nameof(nameFilter));
            return GetRevisionsAsync(ConfigurationModelFactory.FeatureFlagSelector { NameFilter = nameFilter, LabelFilter = labelFilter }, cancellationToken);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="FeatureFlag"/> entities that match the specified <paramref name="nameFilter"/> and <paramref name="labelFilter"/>.
        /// </summary>
        /// <param name="nameFilter">Name filter that will be used to select a set of <see cref="FeatureFlag"/> entities.</param>
        /// <param name="labelFilter">Label filter that will be used to select a set of <see cref="FeatureFlag"/> entities.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<FeatureFlag> GetRevisions(string nameFilter, string labelFilter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nameFilter, nameof(nameFilter));
            return GetRevisions(ConfigurationModelFactory.FeatureFlagSelector { NameFilter = nameFilter, LabelFilter = labelFilter }, cancellationToken);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="FeatureFlag"/> entities that satisfy the options of the <see cref="FeatureFlagSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="FeatureFlag"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncPageable<FeatureFlag> GetRevisionsAsync(FeatureFlagSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var name = selector.NameFilter;
            var label = selector.LabelFilter;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
            var tags = selector.TagsFilter;
            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<FeatureFlagFields> fieldsSplit = selector.Fields.Split();

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetFeatureFlagRevisionsRequest(name, label, null, fieldsSplit, tags, _syncToken, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetFeatureFlagRevisionsRequest(name, label, nextLink, fieldsSplit, tags, _syncToken, null, context);
            return PageableHelpers.CreateAsyncPageable<FeatureFlag>(FirstPageRequest, NextPageRequest, element => FeatureFlag.DeserializeFeatureFlag(element, default), ClientDiagnostics, Pipeline, "ConfigurationClient.GetRevisions", "items", "@nextLink", context);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="FeatureFlag"/> entities that satisfy the options of the <see cref="FeatureFlagSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="FeatureFlag"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<FeatureFlag> GetRevisions(FeatureFlagSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var name = selector.NameFilter;
            var label = selector.LabelFilter;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
            var tags = selector.TagsFilter;
            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<FeatureFlagFields> fieldsSplit = selector.Fields.Split();
            IEnumerable<string> fieldsString = selector.Fields.SplitAsStrings();

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetFeatureFlagRevisionsRequest(name, label, null, fieldsSplit, tags, _syncToken, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextGetFeatureFlagsRequest(nextLink, name, label, _syncToken, null, dateTime, fieldsSplit, null, context);
            return PageableHelpers.CreatePageable<FeatureFlag>(FirstPageRequest, NextPageRequest, element => FeatureFlag.DeserializeFeatureFlag(element, default), ClientDiagnostics, Pipeline, "ConfigurationClient.GetRevisions", "items", "@nextLink", context);
        }

        /// <summary>
        /// Sets an existing <see cref="FeatureFlag"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="isReadOnly">If true, the <see cref="FeatureFlag"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<FeatureFlag>> SetFeatureFlagReadOnlyAsync(string name, bool isReadOnly, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return await SetFeatureFlagReadOnlyAsync(name, default, isReadOnly, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets an existing <see cref="FeatureFlag"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="isReadOnly">If true, the <see cref="FeatureFlag"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<FeatureFlag> SetFeatureFlagReadOnly(string name, bool isReadOnly, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return SetFeatureFlagReadOnly(name, default, isReadOnly, cancellationToken);
        }

        /// <summary>
        /// Sets an existing <see cref="FeatureFlag"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="isReadOnly">If true, the <see cref="FeatureFlag"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<FeatureFlag>> SetFeatureFlagReadOnlyAsync(string name, string label, bool isReadOnly, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(SetFeatureFlagReadOnly)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);
                return await PutOrDeleteLockAsync(name, label, default, isReadOnly, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets an existing <see cref="FeatureFlag"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="name">The primary identifier of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="isReadOnly">If true, the <see cref="FeatureFlag"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<FeatureFlag> SetFeatureFlagReadOnly(string name, string label, bool isReadOnly, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);
            return PutOrDeleteLock(name, label, default, isReadOnly, context);
        }

        /// <summary>
        /// Sets an existing <see cref="FeatureFlag"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to update.</param>
        /// <param name="onlyIfUnchanged">If set to true and the feature flag exists in the configuration store, update the flag
        /// if the passed-in <see cref="FeatureFlag"/> is the same version as the one in the configuration store. The flag versions
        /// are the same if their ETag fields match.  If the two flags are different versions, this method will throw an exception to indicate
        /// that the flag in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="isReadOnly">If true, the <see cref="FeatureFlag"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<FeatureFlag>> SetFeatureFlagReadOnlyAsync(FeatureFlag flag, bool isReadOnly, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = flag.ETag } : default;
            RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);
            return await PutOrDeleteLockAsync(flag.Name, flag.Label, requestOptions, isReadOnly, context).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets an existing <see cref="FeatureFlag"/> to read only or read write state in the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to update.</param>
        /// <param name="onlyIfUnchanged">If set to true and the feature flag exists in the configuration store, update the flag
        /// if the passed-in <see cref="FeatureFlag"/> is the same version as the one in the configuration store. The flag versions
        /// are the same if their ETag fields match.  If the two flags are different versions, this method will throw an exception to indicate
        /// that the flag in the configuration store was modified since it was last obtained by the client.</param>
        /// <param name="isReadOnly">If true, the <see cref="FeatureFlag"/> will be set to read only in the configuration store. If false, it will be set to read write.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<FeatureFlag> SetFeatureFlagReadOnly(FeatureFlag flag, bool isReadOnly, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = flag.ETag } : default;
            RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);
            return PutOrDeleteLock(flag.Name, flag.Label, requestOptions, isReadOnly, context);
        }

        private async Task<Response<FeatureFlag>> PutOrDeleteLockAsync(string name, string label, MatchConditions requestOptions, bool isReadOnly, RequestContext context)
        {
            Response<FeatureFlag> response = isReadOnly
                ? await PutFeatureFlagLockAsync(name, label, matchConditions: requestOptions, cancellationToken: context.CancellationToken).ConfigureAwait(false)
                : await DeleteFeatureFlagLockAsync(name, label, matchConditions: requestOptions, cancellationToken: context.CancellationToken).ConfigureAwait(false);
            return response;
        }

        private Response<FeatureFlag> PutOrDeleteLock(string name, string label, MatchConditions requestOptions, bool isReadOnly, RequestContext context)
        {
            Response<FeatureFlag> response = isReadOnly
                ? PutFeatureFlagLock(name, label, matchConditions: requestOptions, cancellationToken: context.CancellationToken)
                : DeleteFeatureFlagLock(name, label, matchConditions: requestOptions, cancellationToken: context.CancellationToken);
            return response;
        }

        private static RequestContext CreateRequestContext(ErrorOptions errorOptions, CancellationToken cancellationToken)
        {
            return new RequestContext()
            {
                ErrorOptions = errorOptions,
                CancellationToken = cancellationToken
            };
        }

        private class FeatureFlagRequestFailedDetailsParser : RequestFailedDetailsParser
        {
            private const string TroubleshootingMessage =
                "For troubleshooting information, see https://aka.ms/azsdk/net/appconfiguration/troubleshoot.";
            public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
            {
                switch (response.Status)
                {
                    case 409:
                        error = new ResponseError(null, $"The flag is read only. {TroubleshootingMessage}");
                        data = null;
                        return true;
                    case 412:
                        error = new ResponseError(null, $"Flag was already present. {TroubleshootingMessage}");
                        data = null;
                        return true;
                    default:
                        error = new ResponseError(null, TroubleshootingMessage);
                        data = null;
                        return true;
                }
            }
        }
    }
}
