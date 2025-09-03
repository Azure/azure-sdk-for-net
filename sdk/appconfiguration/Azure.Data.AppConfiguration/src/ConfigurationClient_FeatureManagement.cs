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
    /// <summary>
    /// The client to use for interacting with the Azure Configuration Store.
    /// </summary>
    public partial class ConfigurationClient
    {
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
            return await AddFeatureFlagAsync(new FeatureFlag(name, enabled, label), cancellationToken).ConfigureAwait(false);
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
            return AddFeatureFlag(new FeatureFlag(name, enabled, label), cancellationToken);
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
                return await GetFeatureManagementClient().PutFeatureFlagAsync(flag.Name, flag, flag.Label, _syncToken, requestOptions, cancellationToken).ConfigureAwait(false);
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
                return GetFeatureManagementClient().PutFeatureFlag(flag.Name, flag, flag.Label, _syncToken, requestOptions, cancellationToken);
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
            return await SetFeatureFlagAsync(new FeatureFlag(name, enabled, label), false, cancellationToken).ConfigureAwait(false);
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
            return SetFeatureFlag(new FeatureFlag(name, enabled, label), false, cancellationToken);
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
                return await GetFeatureManagementClient().PutFeatureFlagAsync(flag.Name, flag, flag.Label, _syncToken, requestOptions, cancellationToken).ConfigureAwait(false);
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
                return GetFeatureManagementClient().PutFeatureFlag(flag.Name, flag, flag.Label, _syncToken, requestOptions, cancellationToken);
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

                using Response response = await GetFeatureManagementClient().DeleteFeatureFlagAsync(name, label, _syncToken, requestOptions?.IfMatch, context).ConfigureAwait(false);

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

        private Response DeleteFeatureFlag(string name, string label, MatchConditions requestOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ConfigurationClient)}.{nameof(DeleteFeatureFlag)}");
            scope.AddAttribute(OTelAttributeKey, name);
            scope.Start();

            try
            {
                RequestContext context = CreateRequestContext(ErrorOptions.NoThrow, cancellationToken);

                using Response response = GetFeatureManagementClient().DeleteFeatureFlag(name, label, _syncToken, requestOptions?.IfMatch, context);

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

                using Response response = await GetFeatureManagementClient().GetFeatureFlagAsync(name, label, null, _syncToken, dateTime, conditions, null, context).ConfigureAwait(false);

                return response.Status switch
                {
                    200 => CreateFeatureFlagResponse(response),
                    304 => CreateFeatureFlagResourceModifiedResponse(response),
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
                using Response response = GetFeatureManagementClient().GetFeatureFlag(name, label, null, _syncToken, dateTime, conditions, null, context);

                return response.Status switch
                {
                    200 => CreateFeatureFlagResponse(response),
                    304 => CreateFeatureFlagResourceModifiedResponse(response),
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
                return GetFeatureManagementClient().CreateGetFeatureFlagsRequest(name, label, _syncToken, null, dateTime, fieldsSplit, conditions, tags, context);
            }

            HttpMessage NextPageRequest(MatchConditions conditions, int? pageSizeHint, string nextLink)
            {
                return GetFeatureManagementClient().CreateNextGetFeatureFlagsRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), name, label, _syncToken, null, dateTime, fieldsSplit, conditions, tags, context);
            }

            return new ConditionalPageableImplementation<FeatureFlag>(FirstPageRequest, NextPageRequest, ParseGetGetFeatureFlagsResponse, Pipeline, ClientDiagnostics, "ConfigurationClient.GetFeatureFlags", context);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="FeatureFlag"/> entities that match the specified <paramref name="nameFilter"/> and <paramref name="labelFilter"/>.
        /// </summary>
        /// <param name="nameFilter">Name filter that will be used to select a set of <see cref="FeatureFlag"/> entities.</param>
        /// <param name="labelFilter">Label filter that will be used to select a set of <see cref="FeatureFlag"/> entities.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncPageable<FeatureFlag> GetFeatureFlagRevisionsAsync(string nameFilter, string labelFilter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nameFilter, nameof(nameFilter));
            return GetFeatureFlagRevisionsAsync(new FeatureFlagSelector { NameFilter = nameFilter, LabelFilter = labelFilter }, cancellationToken);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="FeatureFlag"/> entities that match the specified <paramref name="nameFilter"/> and <paramref name="labelFilter"/>.
        /// </summary>
        /// <param name="nameFilter">Name filter that will be used to select a set of <see cref="FeatureFlag"/> entities.</param>
        /// <param name="labelFilter">Label filter that will be used to select a set of <see cref="FeatureFlag"/> entities.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<FeatureFlag> GetFeatureFlagRevisions(string nameFilter, string labelFilter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nameFilter, nameof(nameFilter));
            return GetFeatureFlagRevisions(new FeatureFlagSelector { NameFilter = nameFilter, LabelFilter = labelFilter }, cancellationToken);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="FeatureFlag"/> entities that satisfy the options of the <see cref="FeatureFlagSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="FeatureFlag"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncPageable<FeatureFlag> GetFeatureFlagRevisionsAsync(FeatureFlagSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var name = selector.NameFilter;
            var label = selector.LabelFilter;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
            var tags = selector.TagsFilter;
            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<FeatureFlagFields> fieldsSplit = selector.Fields.Split();

            HttpMessage FirstPageRequest(int? pageSizeHint) => GetFeatureManagementClient().CreateGetFeatureFlagRevisionsRequest(name, label, null, fieldsSplit, tags, _syncToken, null, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => GetFeatureManagementClient().CreateGetFeatureFlagRevisionsRequest(name, label, nextLink, fieldsSplit, tags, _syncToken, null, context);
            return PageableHelpers.CreateAsyncPageable<FeatureFlag>(FirstPageRequest, NextPageRequest, element => FeatureFlag.DeserializeFeatureFlag(element, default), ClientDiagnostics, Pipeline, "ConfigurationClient.GetRevisions", "items", "@nextLink", context);
        }

        /// <summary>
        /// Retrieves the revisions of one or more <see cref="FeatureFlag"/> entities that satisfy the options of the <see cref="FeatureFlagSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting <see cref="FeatureFlag"/> from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<FeatureFlag> GetFeatureFlagRevisions(FeatureFlagSelector selector, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(selector, nameof(selector));
            var name = selector.NameFilter;
            var label = selector.LabelFilter;
            var dateTime = selector.AcceptDateTime?.UtcDateTime.ToString(AcceptDateTimeFormat, CultureInfo.InvariantCulture);
            var tags = selector.TagsFilter;
            RequestContext context = CreateRequestContext(ErrorOptions.Default, cancellationToken);
            IEnumerable<FeatureFlagFields> fieldsSplit = selector.Fields.Split();
            IEnumerable<string> fieldsString = selector.Fields.SplitAsStrings();

            HttpMessage FirstPageRequest(int? pageSizeHint) => GetFeatureManagementClient().CreateGetFeatureFlagRevisionsRequest(name, label, null, fieldsSplit, tags, _syncToken, null, context);
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

                return await GetFeatureManagementClient().PutFeatureFlagLockAsync(name, label, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            return GetFeatureManagementClient().PutFeatureFlagLock(name, label, cancellationToken: cancellationToken);
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
            return await GetFeatureManagementClient().PutFeatureFlagLockAsync(flag.Name, flag.Label, matchConditions: requestOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            return GetFeatureManagementClient().PutFeatureFlagLock(flag.Name, flag.Label, matchConditions: requestOptions);
        }

        internal virtual FeatureManagement GetFeatureManagementClient()
        {
            if (_cachedFeatureManagement is null)
            {
                _cachedFeatureManagement = new FeatureManagement(ClientDiagnostics, Pipeline, _endpoint, _apiVersion);
            }

            return _cachedFeatureManagement;
        }
    }
}
