// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AppConfiguration
{
    // The feature flag operations are generated onto this sub-client via the
    // @clientLocation TypeSpec customization. The generated convenience overloads are
    // suppressed so the hand-authored, idiomatic convenience methods below can take
    // their place while reusing the generated protocol methods and pageable types.
    /// <summary>
    /// The <see cref="FeatureFlagClient"/> allows you to create, retrieve, update, and delete
    /// <see cref="FeatureFlag"/> entities in an Azure App Configuration store. It is created
    /// directly, just like a <see cref="ConfigurationClient"/>.
    /// </summary>
    [CodeGenSuppress("GetFeatureFlags", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(MatchConditions), typeof(IEnumerable<>), typeof(CancellationToken))]
    [CodeGenSuppress("GetFeatureFlagsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IEnumerable<>), typeof(MatchConditions), typeof(IEnumerable<>), typeof(CancellationToken))]
    [CodeGenSuppress("GetFeatureFlag", typeof(string), typeof(string), typeof(IEnumerable<FeatureFlagFields>), typeof(string), typeof(string), typeof(MatchConditions), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("GetFeatureFlagAsync", typeof(string), typeof(string), typeof(IEnumerable<FeatureFlagFields>), typeof(string), typeof(string), typeof(MatchConditions), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteFeatureFlag", typeof(string), typeof(string), typeof(string), typeof(ETag?), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteFeatureFlagAsync", typeof(string), typeof(string), typeof(string), typeof(ETag?), typeof(CancellationToken))]
    public partial class FeatureFlagClient
    {
        private const string OTelAttributeKey = "az.appconfiguration.key";
        private const string AcceptDateTimeFormat = "R";

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureFlagClient"/> class for mocking.
        /// </summary>
        protected FeatureFlagClient()
        {
        }

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
            : this(
                CreateDiagnostics(options),
                CreateConnectionStringPipeline(connectionString, options, out Uri endpoint),
                endpoint,
                options.Version)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureFlagClient"/> class.
        /// </summary>
        /// <param name="endpoint">The <see cref="Uri"/> referencing the app configuration storage.</param>
        /// <param name="credential">The token credential used to sign requests.</param>
        public FeatureFlagClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new FeatureFlagClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureFlagClient"/> class.
        /// </summary>
        /// <param name="endpoint">The <see cref="Uri"/> referencing the app configuration storage.</param>
        /// <param name="credential">The token credential used to sign requests.</param>
        /// <param name="options">Options that allow configuration of requests sent to the configuration store.</param>
        /// <remarks> The <paramref name="credential"/>'s Microsoft Entra audience is configurable via the <see cref="FeatureFlagClientOptions.Audience"/> property.
        /// If no token audience is set, Azure Public Cloud is used. If using an Azure sovereign cloud, configure the audience accordingly.
        /// </remarks>
        public FeatureFlagClient(Uri endpoint, TokenCredential credential, FeatureFlagClientOptions options)
            : this(
                CreateDiagnostics(options),
                CreateTokenCredentialPipeline(endpoint, credential, options),
                endpoint,
                options.Version)
        {
        }

        private static ClientDiagnostics CreateDiagnostics(FeatureFlagClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));
            return new ClientDiagnostics(options, true);
        }

        private static HttpPipeline CreateConnectionStringPipeline(string connectionString, FeatureFlagClientOptions options, out Uri endpoint)
        {
            Argument.AssertNotNull(connectionString, nameof(connectionString));
            Argument.AssertNotNull(options, nameof(options));

            ConfigurationClient.ParseConnectionString(connectionString, out endpoint, out var credential, out var secret);
            return ConfigurationClient.CreatePipeline(options, options.Audience != null, new AuthenticationPolicy(credential, secret), new SyncTokenPolicy());
        }

        private static HttpPipeline CreateTokenCredentialPipeline(Uri endpoint, TokenCredential credential, FeatureFlagClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            return ConfigurationClient.CreatePipeline(options, options.Audience != null, new BearerTokenAuthenticationPolicy(credential, options.GetDefaultScope(endpoint)), new SyncTokenPolicy());
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
            (string name, string label, string acceptDatetime, IEnumerable<string> select, IList<string> tags) = TranslateFeatureFlagSelector(selector);

            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            context.AddClassifier(304, isError: false);

            HttpMessage FirstPageRequest(MatchConditions conditions, int? pageSizeHint)
            {
                return CreateGetFeatureFlagsRequest(name, label, null, null, acceptDatetime, select, conditions, tags, context);
            }

            HttpMessage NextPageRequest(MatchConditions conditions, int? pageSizeHint, string nextLink)
            {
                HttpMessage message = CreateNextGetFeatureFlagsRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), name, label, null, null, acceptDatetime, select, conditions, tags, context);

                // The generated next-page request only carries the continuation link, so the
                // per-call headers must be re-applied to honor point-in-time reads and the
                // per-page match conditions used by conditional paging.
                if (acceptDatetime != null)
                {
                    message.Request.Headers.SetValue("Accept-Datetime", acceptDatetime);
                }
                if (conditions != null)
                {
                    message.Request.Headers.Add(conditions);
                }

                return message;
            }

            return new ConditionalPageableImplementation<FeatureFlag>(FirstPageRequest, NextPageRequest, ParseGetFeatureFlagsResponse, Pipeline, ClientDiagnostics, "FeatureFlagClient.GetFeatureFlags", context);
        }

        private (List<FeatureFlag> Values, string NextLink) ParseGetFeatureFlagsResponse(Response response)
        {
            var values = new List<FeatureFlag>();
            string nextLink = null;

            if (response.Status == 200)
            {
                FeatureFlagListResult result = (FeatureFlagListResult)response;
                if (result.Items != null)
                {
                    foreach (FeatureFlag flag in result.Items)
                    {
                        values.Add(flag);
                    }
                }
                nextLink = result.NextLink;
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

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> if the feature flag, uniquely identified by name and label, does not already exist in the configuration store.
        /// </summary>
        /// <param name="name">The name of the feature flag.</param>
        /// <param name="enabled">The enabled state of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="FeatureFlag"/>.</returns>
        public virtual async Task<Response<FeatureFlag>> AddFeatureFlagAsync(string name, bool? enabled, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return await AddFeatureFlagAsync(name, new FeatureFlag { Enabled = enabled }, label, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> if the feature flag, uniquely identified by name and label, does not already exist in the configuration store.
        /// </summary>
        /// <param name="name">The name of the feature flag.</param>
        /// <param name="enabled">The enabled state of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="FeatureFlag"/>.</returns>
        public virtual Response<FeatureFlag> AddFeatureFlag(string name, bool? enabled, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return AddFeatureFlag(name, new FeatureFlag { Enabled = enabled }, label, cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> only if the feature flag does not already exist in the configuration store.
        /// </summary>
        /// <param name="name">The name of the feature flag.</param>
        /// <param name="flag">The <see cref="FeatureFlag"/> body to create.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="FeatureFlag"/>.</returns>
        public virtual async Task<Response<FeatureFlag>> AddFeatureFlagAsync(string name, FeatureFlag flag, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(flag, nameof(flag));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(AddFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                MatchConditions matchConditions = new MatchConditions { IfNoneMatch = ETag.All };
                return await PutFeatureFlagAsync(name, flag, label, null, matchConditions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> only if the feature flag does not already exist in the configuration store.
        /// </summary>
        /// <param name="name">The name of the feature flag.</param>
        /// <param name="flag">The <see cref="FeatureFlag"/> body to create.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the added <see cref="FeatureFlag"/>.</returns>
        public virtual Response<FeatureFlag> AddFeatureFlag(string name, FeatureFlag flag, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(flag, nameof(flag));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(AddFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                MatchConditions matchConditions = new MatchConditions { IfNoneMatch = ETag.All };
                return PutFeatureFlag(name, flag, label, null, matchConditions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/>, uniquely identified by name and label, if it doesn't exist or overwrites the existing feature flag in the configuration store.
        /// </summary>
        /// <param name="name">The name of the feature flag.</param>
        /// <param name="enabled">The enabled state of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="FeatureFlag"/> written to the configuration store.</returns>
        public virtual async Task<Response<FeatureFlag>> SetFeatureFlagAsync(string name, bool? enabled, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return await SetFeatureFlagAsync(name, new FeatureFlag { Enabled = enabled }, label, onlyIfUnchanged: false, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/>, uniquely identified by name and label, if it doesn't exist or overwrites the existing feature flag in the configuration store.
        /// </summary>
        /// <param name="name">The name of the feature flag.</param>
        /// <param name="enabled">The enabled state of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="FeatureFlag"/> written to the configuration store.</returns>
        public virtual Response<FeatureFlag> SetFeatureFlag(string name, bool? enabled, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return SetFeatureFlag(name, new FeatureFlag { Enabled = enabled }, label, onlyIfUnchanged: false, cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> if it doesn't exist or overwrites the existing feature flag in the configuration store.
        /// </summary>
        /// <param name="name">The name of the feature flag.</param>
        /// <param name="flag">The <see cref="FeatureFlag"/> body to create or overwrite.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="onlyIfUnchanged">If set to true and the feature flag exists in the configuration store, overwrite it only if the
        /// passed-in <see cref="FeatureFlag"/> is the same version as the one in the configuration store. The versions are the same if their
        /// <see cref="FeatureFlag.Etag"/> values match. If they differ, the service returns 412 (precondition failed) and a
        /// <see cref="RequestFailedException"/> is thrown.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="FeatureFlag"/> written to the configuration store.</returns>
        public virtual async Task<Response<FeatureFlag>> SetFeatureFlagAsync(string name, FeatureFlag flag, string label = default, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(flag, nameof(flag));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(SetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = flag.Etag } : default;
                return await PutFeatureFlagAsync(name, flag, label, null, matchConditions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="FeatureFlag"/> if it doesn't exist or overwrites the existing feature flag in the configuration store.
        /// </summary>
        /// <param name="name">The name of the feature flag.</param>
        /// <param name="flag">The <see cref="FeatureFlag"/> body to create or overwrite.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="onlyIfUnchanged">If set to true and the feature flag exists in the configuration store, overwrite it only if the
        /// passed-in <see cref="FeatureFlag"/> is the same version as the one in the configuration store. The versions are the same if their
        /// <see cref="FeatureFlag.Etag"/> values match. If they differ, the service returns 412 (precondition failed) and a
        /// <see cref="RequestFailedException"/> is thrown.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the <see cref="FeatureFlag"/> written to the configuration store.</returns>
        public virtual Response<FeatureFlag> SetFeatureFlag(string name, FeatureFlag flag, string label = default, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(flag, nameof(flag));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(SetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = flag.Etag } : default;
                return PutFeatureFlag(name, flag, label, null, matchConditions, cancellationToken);
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
        /// <param name="flag">The <see cref="FeatureFlag"/> to delete.</param>
        /// <param name="onlyIfUnchanged">If set to true and the feature flag exists in the configuration store, delete the feature flag only if
        /// the passed-in <see cref="FeatureFlag"/> is the same version as the one in the configuration store. The versions are the same if their
        /// <see cref="FeatureFlag.Etag"/> values match. If they differ, the service returns 412 (precondition failed) and a
        /// <see cref="RequestFailedException"/> is thrown to indicate that the feature flag in the configuration store was modified since it was
        /// last obtained by the client.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual async Task<Response> DeleteFeatureFlagAsync(FeatureFlag flag, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = flag.Etag } : default;
            return await DeleteFeatureFlagAsync(flag.Name, flag.Label, requestOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to delete.</param>
        /// <param name="onlyIfUnchanged">If set to true and the feature flag exists in the configuration store, delete the feature flag only if
        /// the passed-in <see cref="FeatureFlag"/> is the same version as the one in the configuration store. The versions are the same if their
        /// <see cref="FeatureFlag.Etag"/> values match. If they differ, the service returns 412 (precondition failed) and a
        /// <see cref="RequestFailedException"/> is thrown to indicate that the feature flag in the configuration store was modified since it was
        /// last obtained by the client.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual Response DeleteFeatureFlag(FeatureFlag flag, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            MatchConditions requestOptions = onlyIfUnchanged ? new MatchConditions { IfMatch = flag.Etag } : default;
            return DeleteFeatureFlag(flag.Name, flag.Label, requestOptions, cancellationToken);
        }

        private async Task<Response> DeleteFeatureFlagAsync(string name, string label, MatchConditions requestOptions, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(DeleteFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await DeleteFeatureFlagAsync(name, label, null, requestOptions?.IfMatch, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response DeleteFeatureFlag(string name, string label, MatchConditions requestOptions, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(DeleteFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return DeleteFeatureFlag(name, label, null, requestOptions?.IfMatch, cancellationToken.ToRequestContext());
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
        /// <param name="name">The name of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual async Task<Response> DeleteFeatureFlagAsync(string name, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(DeleteFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return await DeleteFeatureFlagAsync(name, label, null, ifMatch: default, cancellationToken.ToRequestContext()).ConfigureAwait(false);
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
        /// <param name="name">The name of the feature flag.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        public virtual Response DeleteFeatureFlag(string name, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(DeleteFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                return DeleteFeatureFlag(name, label, null, ifMatch: default, cancellationToken.ToRequestContext());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to retrieve.</param>
        /// <param name="onlyIfChanged">If set to true, only retrieve the feature flag from the configuration store if it has changed since the
        /// client last retrieved it. The feature flag is considered unchanged if its <see cref="FeatureFlag.Etag"/> matches the version in the
        /// configuration store. If it is unchanged, the returned <see cref="Response{T}"/> will have a status of 304 (not modified) and its
        /// <see cref="Response{T}.Value"/> will be null.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual async Task<Response<FeatureFlag>> GetFeatureFlagAsync(FeatureFlag flag, bool onlyIfChanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            MatchConditions requestOptions = onlyIfChanged ? new MatchConditions { IfNoneMatch = flag.Etag } : default;
            return await GetFeatureFlagAsync(flag.Name, flag.Label, acceptDateTime: default, requestOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to retrieve.</param>
        /// <param name="onlyIfChanged">If set to true, only retrieve the feature flag from the configuration store if it has changed since the
        /// client last retrieved it. The feature flag is considered unchanged if its <see cref="FeatureFlag.Etag"/> matches the version in the
        /// configuration store. If it is unchanged, the returned <see cref="Response{T}"/> will have a status of 304 (not modified) and its
        /// <see cref="Response{T}.Value"/> will be null.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual Response<FeatureFlag> GetFeatureFlag(FeatureFlag flag, bool onlyIfChanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            MatchConditions requestOptions = onlyIfChanged ? new MatchConditions { IfNoneMatch = flag.Etag } : default;
            return GetFeatureFlag(flag.Name, flag.Label, acceptDateTime: default, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieve an existing <see cref="FeatureFlag"/> from the configuration store.
        /// </summary>
        /// <param name="flag">The <see cref="FeatureFlag"/> to retrieve.</param>
        /// <param name="acceptDateTime">The feature flag will be retrieved exactly as it existed at the provided time.</param>
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
        /// <param name="acceptDateTime">The feature flag will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual Response<FeatureFlag> GetFeatureFlag(FeatureFlag flag, DateTimeOffset acceptDateTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(flag, nameof(flag));
            return GetFeatureFlag(flag.Name, flag.Label, acceptDateTime, conditions: default, cancellationToken);
        }

        internal virtual async Task<Response<FeatureFlag>> GetFeatureFlagAsync(string name, string label, DateTimeOffset? acceptDateTime, MatchConditions conditions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(GetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                RequestContext context = new RequestContext { ErrorOptions = ErrorOptions.NoThrow, CancellationToken = cancellationToken };
                context.AddClassifier(304, isError: false);

                string dateTime = acceptDateTime.HasValue ? acceptDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture) : null;

                Response response = await GetFeatureFlagAsync(name, label, @select: default, null, dateTime, conditions, tags: default, context).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => Response.FromValue((FeatureFlag)response, response),
                    304 => new NoBodyResponse<FeatureFlag>(response),
                    _ => throw new RequestFailedException(response)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual Response<FeatureFlag> GetFeatureFlag(string name, string label, DateTimeOffset? acceptDateTime, MatchConditions conditions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(GetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                RequestContext context = new RequestContext { ErrorOptions = ErrorOptions.NoThrow, CancellationToken = cancellationToken };
                context.AddClassifier(304, isError: false);

                string dateTime = acceptDateTime.HasValue ? acceptDateTime.Value.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture) : null;

                Response response = GetFeatureFlag(name, label, @select: default, null, dateTime, conditions, tags: default, context);

                return response.Status switch
                {
                    200 => Response.FromValue((FeatureFlag)response, response),
                    304 => new NoBodyResponse<FeatureFlag>(response),
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
        /// Retrieve an existing <see cref="FeatureFlag"/>, uniquely identified by name and label, from the configuration store.
        /// </summary>
        /// <param name="name">The name of the feature flag to retrieve.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual async Task<Response<FeatureFlag>> GetFeatureFlagAsync(string name, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(GetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                Response result = await GetFeatureFlagAsync(name, label, @select: default, null, acceptDatetime: default, matchConditions: default, tags: default, cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue((FeatureFlag)result, result);
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
        /// <param name="name">The name of the feature flag to retrieve.</param>
        /// <param name="label">A label used to group this feature flag with others.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the retrieved <see cref="FeatureFlag"/>.</returns>
        public virtual Response<FeatureFlag> GetFeatureFlag(string name, string label = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(FeatureFlagClient)}.{nameof(GetFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                Response result = GetFeatureFlag(name, label, @select: default, null, acceptDatetime: default, matchConditions: default, tags: default, cancellationToken.ToRequestContext());
                return Response.FromValue((FeatureFlag)result, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private (string Name, string Label, string AcceptDatetime, IEnumerable<string> Select, IList<string> Tags) TranslateFeatureFlagSelector(FeatureFlagSelector selector)
        {
            string acceptDatetime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);

            IEnumerable<string> select = selector.Fields.Split();

            return (selector.NameFilter, selector.LabelFilter, acceptDatetime, select, selector.TagsFilter);
        }
    }
}
