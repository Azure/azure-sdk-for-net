// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Confluent.Models;

namespace Azure.ResourceManager.Confluent
{
    public partial class ConfluentOrganizationResource
    {
        /// <summary>
        /// Get Environment details by environment Id
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_GetEnvironmentById</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-02-13</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ConfluentOrganizationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="environmentId"> Confluent environment id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="environmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="environmentId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<SCEnvironmentRecord> GetEnvironment(string environmentId, CancellationToken cancellationToken = default)
        {
            var response = GetSCEnvironmentRecord(environmentId, cancellationToken);
            var data = response.Value.Data;
            var record = new SCEnvironmentRecord(
                data.Kind,
                data.Id,
                data.Name,
                data.Metadata,
                null);
            return Response.FromValue(record, response.GetRawResponse());
        }

        /// <summary>
        /// Get Environment details by environment Id
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_GetEnvironmentById</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-02-13</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ConfluentOrganizationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="environmentId"> Confluent environment id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="environmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="environmentId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<SCEnvironmentRecord>> GetEnvironmentAsync(string environmentId, CancellationToken cancellationToken = default)
        {
            var response = await GetSCEnvironmentRecordAsync(environmentId, cancellationToken).ConfigureAwait(false);
            var data = response.Value.Data;
            var record = new SCEnvironmentRecord(
                data.Kind,
                data.Id,
                data.Name,
                data.Metadata,
                null);
            return Response.FromValue(record, response.GetRawResponse());
        }

        /// <summary>
        /// Get cluster by Id
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_GetClusterById</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-02-13</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ConfluentOrganizationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="environmentId"> Confluent environment id. </param>
        /// <param name="clusterId"> Confluent kafka or schema registry cluster id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="environmentId"/> or <paramref name="clusterId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="environmentId"/> or <paramref name="clusterId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<SCClusterRecord> GetCluster(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            var resource = GetSCEnvironmentRecord(environmentId, cancellationToken).Value;
            var response = resource.GetSCClusterRecord(clusterId, cancellationToken);
            var data = response.Value.Data;
            var record = new SCClusterRecord(
                data.Kind,
                data.Id,
                data.Name,
                data.Metadata,
                data.Spec,
                data.Status,
                null);
            return Response.FromValue(record, response.GetRawResponse());
        }

        /// <summary>
        /// Get cluster by Id
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_GetClusterById</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-02-13</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ConfluentOrganizationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="environmentId"> Confluent environment id. </param>
        /// <param name="clusterId"> Confluent kafka or schema registry cluster id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="environmentId"/> or <paramref name="clusterId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="environmentId"/> or <paramref name="clusterId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<SCClusterRecord>> GetClusterAsync(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            var resource = (await GetSCEnvironmentRecordAsync(environmentId, cancellationToken).ConfigureAwait(false)).Value;
            var response = await resource.GetSCClusterRecordAsync(clusterId, cancellationToken).ConfigureAwait(false);
            var data = response.Value.Data;
            var record = new SCClusterRecord(
                data.Kind,
                data.Id,
                data.Name,
                data.Metadata,
                data.Spec,
                data.Status,
                null);
            return Response.FromValue(record, response.GetRawResponse());
        }
    }
}
