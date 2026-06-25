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
    /// <see cref="FeatureFlag"/> entities in an Azure App Configuration store. It can be created
    /// directly, just like a <see cref="ConfigurationClient"/>, or obtained from an existing
    /// <see cref="ConfigurationClient"/> via <see cref="ConfigurationClient.GetFeatureFlagClient"/>.
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
        private readonly string _syncToken;

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
            : this(new ConfigurationClient(connectionString))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureFlagClient"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string with authentication option and related parameters.</param>
        /// <param name="options">Options that allow configuration of requests sent to the configuration store.</param>
        public FeatureFlagClient(string connectionString, ConfigurationClientOptions options)
            : this(new ConfigurationClient(connectionString, options))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureFlagClient"/> class.
        /// </summary>
        /// <param name="endpoint">The <see cref="Uri"/> referencing the app configuration storage.</param>
        /// <param name="credential">The token credential used to sign requests.</param>
        public FeatureFlagClient(Uri endpoint, TokenCredential credential)
            : this(new ConfigurationClient(endpoint, credential, new ConfigurationClientOptions()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureFlagClient"/> class.
        /// </summary>
        /// <param name="endpoint">The <see cref="Uri"/> referencing the app configuration storage.</param>
        /// <param name="credential">The token credential used to sign requests.</param>
        /// <param name="options">Options that allow configuration of requests sent to the configuration store.</param>
        /// <remarks> The <paramref name="credential"/>'s Microsoft Entra audience is configurable via the <see cref="ConfigurationClientOptions.Audience"/> property.
        /// If no token audience is set, Azure Public Cloud is used. If using an Azure sovereign cloud, configure the audience accordingly.
        /// </remarks>
        public FeatureFlagClient(Uri endpoint, TokenCredential credential, ConfigurationClientOptions options)
            : this(new ConfigurationClient(endpoint, credential, options))
        {
        }

        internal FeatureFlagClient(ConfigurationClient client)
            : this(client.ClientDiagnostics, client.Pipeline, client.EndpointValue, client.ApiVersionValue)
        {
            _syncToken = client.SyncTokenValue;
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

            (string name, string label, string acceptDatetime, IEnumerable<string> select, IList<string> tags) = TranslateFeatureFlagSelector(selector);

            return new FeatureFlagClientGetFeatureFlagsAsyncCollectionResultOfT(
                this,
                name,
                label,
                _syncToken,
                after: null,
                acceptDatetime,
                select,
                matchConditions: null,
                tags,
                cancellationToken.ToRequestContext(),
                "FeatureFlagClient.GetFeatureFlags");
        }

        /// <summary>
        /// Retrieves one or more <see cref="FeatureFlag"/> entities that match the options specified in the passed-in <see cref="FeatureFlagSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="FeatureFlag"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<FeatureFlag> GetFeatureFlags(FeatureFlagSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));

            (string name, string label, string acceptDatetime, IEnumerable<string> select, IList<string> tags) = TranslateFeatureFlagSelector(selector);

            return new FeatureFlagClientGetFeatureFlagsCollectionResultOfT(
                this,
                name,
                label,
                _syncToken,
                after: null,
                acceptDatetime,
                select,
                matchConditions: null,
                tags,
                cancellationToken.ToRequestContext(),
                "FeatureFlagClient.GetFeatureFlags");
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
                return await PutFeatureFlagAsync(name, flag, label, _syncToken, matchConditions, cancellationToken).ConfigureAwait(false);
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
                return PutFeatureFlag(name, flag, label, _syncToken, matchConditions, cancellationToken);
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
                MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = new ETag(flag.Etag) } : default;
                return await PutFeatureFlagAsync(name, flag, label, _syncToken, matchConditions, cancellationToken).ConfigureAwait(false);
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
                MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = new ETag(flag.Etag) } : default;
                return PutFeatureFlag(name, flag, label, _syncToken, matchConditions, cancellationToken);
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
                return await DeleteFeatureFlagAsync(name, label, _syncToken, ifMatch: default, cancellationToken.ToRequestContext()).ConfigureAwait(false);
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
                return DeleteFeatureFlag(name, label, _syncToken, ifMatch: default, cancellationToken.ToRequestContext());
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
                Response result = await GetFeatureFlagAsync(name, label, @select: default, _syncToken, acceptDatetime: default, matchConditions: default, tags: default, cancellationToken.ToRequestContext()).ConfigureAwait(false);
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
                Response result = GetFeatureFlag(name, label, @select: default, _syncToken, acceptDatetime: default, matchConditions: default, tags: default, cancellationToken.ToRequestContext());
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

            IEnumerable<string> select = null;
            if (selector.Fields.Count > 0)
            {
                var fields = new List<string>(selector.Fields.Count);
                foreach (FeatureFlagFields field in selector.Fields)
                {
                    fields.Add(field.ToString());
                }
                select = fields;
            }

            return (selector.NameFilter, selector.LabelFilter, acceptDatetime, select, selector.TagsFilter);
        }
    }
}
