// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
        /// Lists of all the environments in a organization
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_ListEnvironments</description>
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
        /// <param name="pageSize"> Pagination size. </param>
        /// <param name="pageToken"> An opaque pagination token to fetch the next set of records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SCEnvironmentRecord"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<SCEnvironmentRecord> GetEnvironments(int? pageSize = null, string pageToken = null, CancellationToken cancellationToken = default)
        {
            var collection = GetSCEnvironmentRecords();
            var response = collection.GetAll(pageSize, pageToken, cancellationToken);
            IEnumerable<Page<SCEnvironmentRecord>> PageIterator()
            {
                foreach (var page in response.AsPages(pageToken, pageSize))
                {
                    var records = new List<SCEnvironmentRecord>(page.Values.Count);
                    foreach (var resource in page.Values)
                    {
                        var data = resource.Data;
                        var record = new SCEnvironmentRecord(
                            data.Kind,
                            data.Id,
                            data.Name,
                            data.Metadata,
                            null);
                        records.Add(record);
                    }
                    yield return Page<SCEnvironmentRecord>.FromValues(records, page.ContinuationToken, page.GetRawResponse());
                }
            }

            return Pageable<SCEnvironmentRecord>.FromPages(PageIterator());
        }

        /// <summary>
        /// Lists of all the environments in a organization
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_ListEnvironments</description>
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
        /// <param name="pageSize"> Pagination size. </param>
        /// <param name="pageToken"> An opaque pagination token to fetch the next set of records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SCEnvironmentRecord"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<SCEnvironmentRecord> GetEnvironmentsAsync(int? pageSize = null, string pageToken = null, CancellationToken cancellationToken = default)
        {
            var collection = GetSCEnvironmentRecords();
            var response = collection.GetAllAsync(pageSize, pageToken, cancellationToken);

            async IAsyncEnumerable<Page<SCEnvironmentRecord>> PageIterator([EnumeratorCancellation] CancellationToken ct = default)
            {
                await foreach (var page in response.AsPages(pageToken, pageSize).WithCancellation(ct).ConfigureAwait(false))
                {
                    var records = new List<SCEnvironmentRecord>(page.Values.Count);
                    foreach (var resource in page.Values)
                    {
                        var data = resource.Data;
                        var record = new SCEnvironmentRecord(
                            data.Kind,
                            data.Id,
                            data.Name,
                            data.Metadata,
                            null);
                        records.Add(record);
                    }
                    yield return Page<SCEnvironmentRecord>.FromValues(records, page.ContinuationToken, page.GetRawResponse());
                }
            }

            return AsyncPageable<SCEnvironmentRecord>.FromPages((IEnumerable<Page<SCEnvironmentRecord>>)PageIterator(cancellationToken));
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

        /// <summary>
        /// Lists of all the clusters in a environment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_ListClusters</description>
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
        /// <param name="pageSize"> Pagination size. </param>
        /// <param name="pageToken"> An opaque pagination token to fetch the next set of records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="environmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="environmentId"/> is null. </exception>
        /// <returns> A collection of <see cref="SCClusterRecord"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<SCClusterRecord> GetClusters(string environmentId, int? pageSize = null, string pageToken = null, CancellationToken cancellationToken = default)
        {
            var resource = GetSCEnvironmentRecord(environmentId, cancellationToken).Value;
            var collection = resource.GetSCClusterRecords();
            var response = collection.GetAll(pageSize, pageToken, cancellationToken);
            IEnumerable<Page<SCClusterRecord>> PageIterator()
            {
                foreach (var page in response.AsPages(pageToken, pageSize))
                {
                    var records = new List<SCClusterRecord>(page.Values.Count);
                    foreach (var resource in page.Values)
                    {
                        var data = resource.Data;
                        var record = new SCClusterRecord(
                                        data.Kind,
                                        data.Id,
                                        data.Name,
                                        data.Metadata,
                                        data.Spec,
                                        data.Status,
                                        null);
                        records.Add(record);
                    }
                    yield return Page<SCClusterRecord>.FromValues(records, page.ContinuationToken, page.GetRawResponse());
                }
            }

            return Pageable<SCClusterRecord>.FromPages(PageIterator());
        }

        /// <summary>
        /// Lists of all the clusters in a environment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_ListClusters</description>
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
        /// <param name="pageSize"> Pagination size. </param>
        /// <param name="pageToken"> An opaque pagination token to fetch the next set of records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="environmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="environmentId"/> is null. </exception>
        /// <returns> An async collection of <see cref="SCClusterRecord"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<SCClusterRecord> GetClustersAsync(string environmentId, int? pageSize = null, string pageToken = null, CancellationToken cancellationToken = default)
        {
            var resource = GetSCEnvironmentRecordAsync(environmentId, cancellationToken).Result.Value;
            var collection = resource.GetSCClusterRecords();
            var response = collection.GetAllAsync(pageSize, pageToken, cancellationToken);
            async IAsyncEnumerable<Page<SCClusterRecord>> PageIterator([EnumeratorCancellation] CancellationToken ct = default)
            {
                await foreach (var page in response.AsPages(pageToken, pageSize).WithCancellation(ct).ConfigureAwait(false))
                {
                    var records = new List<SCClusterRecord>(page.Values.Count);
                    foreach (var resource in page.Values)
                    {
                        var data = resource.Data;
                        var record = new SCClusterRecord(
                                            data.Kind,
                                            data.Id,
                                            data.Name,
                                            data.Metadata,
                                            data.Spec,
                                            data.Status,
                                            null);
                        records.Add(record);
                    }
                    yield return Page<SCClusterRecord>.FromValues(records, page.ContinuationToken, page.GetRawResponse());
                }
            }

            return AsyncPageable<SCClusterRecord>.FromPages((IEnumerable<Page<SCClusterRecord>>)PageIterator(cancellationToken));
        }

        /// <summary>
        /// Get schema registry cluster by Id
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/schemaRegistryClusters/{clusterId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_GetSchemaRegistryClusterById</description>
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
        public virtual Response<SchemaRegistryClusterRecord> GetSchemaRegistryCluster(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            var response = GetSCEnvironmentRecord(environmentId, cancellationToken).Value;
            return response.GetSchemaRegistryCluster(clusterId, cancellationToken);
        }

        /// <summary>
        /// Get schema registry cluster by Id
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/schemaRegistryClusters/{clusterId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_GetSchemaRegistryClusterById</description>
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
        public virtual async Task<Response<SchemaRegistryClusterRecord>> GetSchemaRegistryClusterAsync(string environmentId, string clusterId, CancellationToken cancellationToken = default)
        {
            var response = (await GetSCEnvironmentRecordAsync(environmentId, cancellationToken).ConfigureAwait(false)).Value;
            return await response.GetSchemaRegistryClusterAsync(clusterId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get schema registry clusters
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/schemaRegistryClusters</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_ListSchemaRegistryClusters</description>
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
        /// <param name="pageSize"> Pagination size. </param>
        /// <param name="pageToken"> An opaque pagination token to fetch the next set of records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="environmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="environmentId"/> is null. </exception>
        /// <returns> A collection of <see cref="SchemaRegistryClusterRecord"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<SchemaRegistryClusterRecord> GetSchemaRegistryClusters(string environmentId, int? pageSize = null, string pageToken = null, CancellationToken cancellationToken = default)
        {
            var response = GetSCEnvironmentRecord(environmentId, cancellationToken).Value;
            return response.GetSchemaRegistryClusters(pageSize, pageToken, cancellationToken);
        }

        /// <summary>
        /// Get schema registry clusters
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/schemaRegistryClusters</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Organization_ListSchemaRegistryClusters</description>
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
        /// <param name="pageSize"> Pagination size. </param>
        /// <param name="pageToken"> An opaque pagination token to fetch the next set of records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="environmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="environmentId"/> is null. </exception>
        /// <returns> An async collection of <see cref="SchemaRegistryClusterRecord"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<SchemaRegistryClusterRecord> GetSchemaRegistryClustersAsync(string environmentId, int? pageSize = null, string pageToken = null, CancellationToken cancellationToken = default)
        {
            var response = GetSCEnvironmentRecord(environmentId, cancellationToken).Value;
            return response.GetSchemaRegistryClustersAsync(pageSize, pageToken, cancellationToken);
        }
    }
}
