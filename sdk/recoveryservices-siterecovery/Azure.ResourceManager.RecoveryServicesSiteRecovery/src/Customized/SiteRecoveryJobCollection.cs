// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.RecoveryServicesSiteRecovery.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    // The TypeSpec emitter misclassifies ReplicationJobsOperationGroup.export (an LRO action with
    // @armResourceCollectionAction) as a List operation on the Job resource. As a result the
    // generator produces an LRO-shaped GetAll(WaitUntil, content, CancellationToken) on the
    // collection and drops IEnumerable/IAsyncEnumerable. Suppress the misnamed members and restore
    // the baseline shape: a paginated GetAll(string filter, CancellationToken) plus the enumerable
    // interfaces. The matching Export(...) action lives on SiteRecoveryJobResource.
    [CodeGenSuppress("GetAll", typeof(WaitUntil), typeof(SiteRecoveryJobQueryContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllAsync", typeof(WaitUntil), typeof(SiteRecoveryJobQueryContent), typeof(CancellationToken))]
    public partial class SiteRecoveryJobCollection : IEnumerable<SiteRecoveryJobResource>, IAsyncEnumerable<SiteRecoveryJobResource>
    {
        /// <summary>
        /// Gets the list of Azure Site Recovery Jobs for the vault.
        /// <list type="bullet">
        /// <item><term> Request Path. </term><description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationJobs. </description></item>
        /// <item><term> Operation Id. </term><description> Jobs_List. </description></item>
        /// <item><term> Default Api Version. </term><description> 2026-01-01. </description></item>
        /// <item><term> Resource. </term><description> <see cref="SiteRecoveryJobResource"/>. </description></item>
        /// </list>
        /// </summary>
        /// <param name="filter"> OData filter options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteRecoveryJobResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteRecoveryJobResource> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            return new SiteRecoveryJobAsyncPageable(this, filter, cancellationToken);
        }

        /// <summary>
        /// Gets the list of Azure Site Recovery Jobs for the vault.
        /// <list type="bullet">
        /// <item><term> Request Path. </term><description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationJobs. </description></item>
        /// <item><term> Operation Id. </term><description> Jobs_List. </description></item>
        /// <item><term> Default Api Version. </term><description> 2026-01-01. </description></item>
        /// <item><term> Resource. </term><description> <see cref="SiteRecoveryJobResource"/>. </description></item>
        /// </list>
        /// </summary>
        /// <param name="filter"> OData filter options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteRecoveryJobResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteRecoveryJobResource> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            return new SiteRecoveryJobPageable(this, filter, cancellationToken);
        }

        IEnumerator<SiteRecoveryJobResource> IEnumerable<SiteRecoveryJobResource>.GetEnumerator() => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        IAsyncEnumerator<SiteRecoveryJobResource> IAsyncEnumerable<SiteRecoveryJobResource>.GetAsyncEnumerator(CancellationToken cancellationToken) =>
            GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        private static (List<SiteRecoveryJobData> Values, Uri NextPage) ParsePage(Response response)
        {
            using JsonDocument doc = JsonDocument.Parse(response.Content.ToMemory());
            var values = new List<SiteRecoveryJobData>();
            if (doc.RootElement.TryGetProperty("value", out JsonElement valueArray) && valueArray.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement item in valueArray.EnumerateArray())
                {
                    values.Add(SiteRecoveryJobData.DeserializeSiteRecoveryJobData(item, ModelSerializationExtensions.WireOptions));
                }
            }
            Uri next = null;
            if (doc.RootElement.TryGetProperty("nextLink", out JsonElement nl) && nl.ValueKind == JsonValueKind.String)
            {
                string s = nl.GetString();
                if (!string.IsNullOrEmpty(s))
                {
                    next = new Uri(s);
                }
            }
            return (values, next);
        }

        private sealed class SiteRecoveryJobPageable : Pageable<SiteRecoveryJobResource>
        {
            private readonly SiteRecoveryJobCollection _collection;
            private readonly string _filter;
            private readonly RequestContext _context;

            public SiteRecoveryJobPageable(SiteRecoveryJobCollection collection, string filter, CancellationToken cancellationToken) : base(cancellationToken)
            {
                _collection = collection;
                _filter = filter;
                _context = new RequestContext { CancellationToken = cancellationToken };
            }

            public override IEnumerable<Page<SiteRecoveryJobResource>> AsPages(string continuationToken, int? pageSizeHint)
            {
                Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
                while (true)
                {
                    HttpMessage message = nextPage != null
                        ? _collection._replicationJobsRestClient.CreateNextGetAllRequest(nextPage, Guid.Parse(_collection.Id.SubscriptionId), _collection.Id.ResourceGroupName, _collection._resourceName, _filter, _context)
                        : _collection._replicationJobsRestClient.CreateGetAllRequest(Guid.Parse(_collection.Id.SubscriptionId), _collection.Id.ResourceGroupName, _collection._resourceName, _filter, _context);
                    using DiagnosticScope scope = _collection._replicationJobsClientDiagnostics.CreateScope("SiteRecoveryJobCollection.GetAll");
                    scope.Start();
                    Response response;
                    try
                    {
                        response = _collection.Pipeline.ProcessMessage(message, _context);
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                    (List<SiteRecoveryJobData> values, Uri next) = ParsePage(response);
                    var resources = new List<SiteRecoveryJobResource>(values.Count);
                    foreach (SiteRecoveryJobData data in values)
                    {
                        resources.Add(new SiteRecoveryJobResource(_collection.Client, data));
                    }
                    yield return Page<SiteRecoveryJobResource>.FromValues(resources, next?.AbsoluteUri, response);
                    if (next == null)
                    {
                        yield break;
                    }
                    nextPage = next;
                }
            }
        }

        private sealed class SiteRecoveryJobAsyncPageable : AsyncPageable<SiteRecoveryJobResource>
        {
            private readonly SiteRecoveryJobCollection _collection;
            private readonly string _filter;
            private readonly RequestContext _context;

            public SiteRecoveryJobAsyncPageable(SiteRecoveryJobCollection collection, string filter, CancellationToken cancellationToken) : base(cancellationToken)
            {
                _collection = collection;
                _filter = filter;
                _context = new RequestContext { CancellationToken = cancellationToken };
            }

            public override async IAsyncEnumerable<Page<SiteRecoveryJobResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
                while (true)
                {
                    HttpMessage message = nextPage != null
                        ? _collection._replicationJobsRestClient.CreateNextGetAllRequest(nextPage, Guid.Parse(_collection.Id.SubscriptionId), _collection.Id.ResourceGroupName, _collection._resourceName, _filter, _context)
                        : _collection._replicationJobsRestClient.CreateGetAllRequest(Guid.Parse(_collection.Id.SubscriptionId), _collection.Id.ResourceGroupName, _collection._resourceName, _filter, _context);
                    using DiagnosticScope scope = _collection._replicationJobsClientDiagnostics.CreateScope("SiteRecoveryJobCollection.GetAll");
                    scope.Start();
                    Response response;
                    try
                    {
                        response = await _collection.Pipeline.ProcessMessageAsync(message, _context).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                    (List<SiteRecoveryJobData> values, Uri next) = ParsePage(response);
                    var resources = new List<SiteRecoveryJobResource>(values.Count);
                    foreach (SiteRecoveryJobData data in values)
                    {
                        resources.Add(new SiteRecoveryJobResource(_collection.Client, data));
                    }
                    yield return Page<SiteRecoveryJobResource>.FromValues(resources, next?.AbsoluteUri, response);
                    if (next == null)
                    {
                        yield break;
                    }
                    nextPage = next;
                }
            }
        }
    }
}
