// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp.Mocking
{
    public partial class MockableNetAppSubscriptionResource
    {
        // v1.15 exposed quota operations returning the legacy POCO; generated methods now
        // return resources, so these shims unwrap Data to preserve source compatibility.

        /// <summary>
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppSubscriptionQuotaLimitAsync(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Response<NetAppSubscriptionQuotaItemResource> response = await GetNetAppSubscriptionQuotaItemAsync(location, quotaLimitName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ToLegacyQuotaItem(response.Value?.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimit(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Response<NetAppSubscriptionQuotaItemResource> response = GetNetAppSubscriptionQuotaItem(location, quotaLimitName, cancellationToken);
            return Response.FromValue(ToLegacyQuotaItem(response.Value?.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimitsAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            return new LegacyQuotaItemAsyncPageable(GetNetAppSubscriptionQuotaItems(location).GetAllAsync(cancellationToken));
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimits(AzureLocation location, CancellationToken cancellationToken = default)
        {
            IEnumerable<Page<NetAppSubscriptionQuotaItem>> Pages()
            {
                foreach (Page<NetAppSubscriptionQuotaItemResource> page in GetNetAppSubscriptionQuotaItems(location).GetAll(cancellationToken).AsPages())
                {
                    yield return Page<NetAppSubscriptionQuotaItem>.FromValues(
                        page.Values.Select(item => ToLegacyQuotaItem(item.Data)).ToList(),
                        page.ContinuationToken,
                        page.GetRawResponse());
                }
            }

            return Pageable<NetAppSubscriptionQuotaItem>.FromPages(Pages());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitAsync(AzureLocation location, string quotaLimitName)
        {
            // v1.15 quirk: this overload returned the bare resource (without Response<>) and
            // had no CancellationToken parameter. Forward to the generated async getter and
            // unwrap the Response<>.
            return GetNetAppSubscriptionQuotaItemAsync(location, quotaLimitName)
                .ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitsAsync(AzureLocation location)
        {
            return GetNetAppSubscriptionQuotaItems(location).GetAllAsync();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppQuotaLimitAsync(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimitAsync(location, quotaLimitName, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimit(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimit(location, quotaLimitName, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimitsAsync(location, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(AzureLocation location, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimits(location, cancellationToken);

        // v1.15 used AzureLocation for these provider actions. Modeling the spec parameter as
        // AzureLocation keeps the REST helpers correctly typed, but the generator currently drops
        // these convenience methods (https://github.com/Azure/azure-sdk-for-net/issues/59144).

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppFilePathAvailabilityAsync(AzureLocation location, NetAppFilePathAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.CheckNetAppFilePathAvailability");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateCheckNetAppFilePathAvailabilityRequest(Guid.Parse(Id.SubscriptionId), location, NetAppFilePathAvailabilityContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<NetAppCheckAvailabilityResult> response = Response.FromValue(NetAppCheckAvailabilityResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppCheckAvailabilityResult> CheckNetAppFilePathAvailability(AzureLocation location, NetAppFilePathAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.CheckNetAppFilePathAvailability");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateCheckNetAppFilePathAvailabilityRequest(Guid.Parse(Id.SubscriptionId), location, NetAppFilePathAvailabilityContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<NetAppCheckAvailabilityResult> response = Response.FromValue(NetAppCheckAvailabilityResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppNameAvailabilityAsync(AzureLocation location, NetAppNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.CheckNetAppNameAvailability");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateCheckNetAppNameAvailabilityRequest(Guid.Parse(Id.SubscriptionId), location, NetAppNameAvailabilityContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<NetAppCheckAvailabilityResult> response = Response.FromValue(NetAppCheckAvailabilityResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppCheckAvailabilityResult> CheckNetAppNameAvailability(AzureLocation location, NetAppNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.CheckNetAppNameAvailability");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateCheckNetAppNameAvailabilityRequest(Guid.Parse(Id.SubscriptionId), location, NetAppNameAvailabilityContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<NetAppCheckAvailabilityResult> response = Response.FromValue(NetAppCheckAvailabilityResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppQuotaAvailabilityAsync(AzureLocation location, NetAppQuotaAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.CheckNetAppQuotaAvailability");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateCheckNetAppQuotaAvailabilityRequest(Guid.Parse(Id.SubscriptionId), location, NetAppQuotaAvailabilityContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<NetAppCheckAvailabilityResult> response = Response.FromValue(NetAppCheckAvailabilityResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppCheckAvailabilityResult> CheckNetAppQuotaAvailability(AzureLocation location, NetAppQuotaAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.CheckNetAppQuotaAvailability");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateCheckNetAppQuotaAvailabilityRequest(Guid.Parse(Id.SubscriptionId), location, NetAppQuotaAvailabilityContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<NetAppCheckAvailabilityResult> response = Response.FromValue(NetAppCheckAvailabilityResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // ---- Region Info AzureLocation shims (see header on Check Availability section) ----

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppRegionInfo>> QueryRegionInfoNetAppResourceAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.QueryRegionInfoNetAppResource");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateQueryRegionInfoNetAppResourceRequest(Guid.Parse(Id.SubscriptionId), location, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<NetAppRegionInfo> response = Response.FromValue(NetAppRegionInfo.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppRegionInfo> QueryRegionInfoNetAppResource(AzureLocation location, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.QueryRegionInfoNetAppResource");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateQueryRegionInfoNetAppResourceRequest(Guid.Parse(Id.SubscriptionId), location, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<NetAppRegionInfo> response = Response.FromValue(NetAppRegionInfo.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetRegionInfoResources is not supported. Use GetRegionInfoResource instead.", false)]
        public virtual RegionInfoResourceCollection GetRegionInfoResources(AzureLocation location)
        {
            throw new NotSupportedException("GetRegionInfoResources is not supported. Use GetRegionInfoResource instead.");
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<RegionInfoResource>> GetRegionInfoResourceAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("GetRegionInfoResourceAsync with AzureLocation is not supported. Use GetRegionInfoResource() instead.");
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RegionInfoResource> GetRegionInfoResource(AzureLocation location, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("GetRegionInfoResource with AzureLocation is not supported. Use GetRegionInfoResource() instead.");
        }

        // ---- Network Sibling Set AzureLocation shims (see header on Check Availability section) ----

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetworkSiblingSet>> QueryNetworkSiblingSetNetAppResourceAsync(AzureLocation location, QueryNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.QueryNetworkSiblingSetNetAppResource");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateQueryNetworkSiblingSetNetAppResourceRequest(Guid.Parse(Id.SubscriptionId), location, QueryNetworkSiblingSetContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<NetworkSiblingSet> response = Response.FromValue(NetworkSiblingSet.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetworkSiblingSet> QueryNetworkSiblingSetNetAppResource(AzureLocation location, QueryNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.QueryNetworkSiblingSetNetAppResource");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateQueryNetworkSiblingSetNetAppResourceRequest(Guid.Parse(Id.SubscriptionId), location, QueryNetworkSiblingSetContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<NetworkSiblingSet> response = Response.FromValue(NetworkSiblingSet.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<ArmOperation<NetworkSiblingSet>> UpdateNetworkSiblingSetNetAppResourceAsync(WaitUntil waitUntil, AzureLocation location, UpdateNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.UpdateNetworkSiblingSetNetAppResource");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateUpdateNetworkSiblingSetNetAppResourceRequest(Guid.Parse(Id.SubscriptionId), location, UpdateNetworkSiblingSetContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                NetAppArmOperation<NetworkSiblingSet> operation = new NetAppArmOperation<NetworkSiblingSet>(
                    new NetworkSiblingSetOperationSource(),
                    NetAppResourceClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<NetworkSiblingSet> UpdateNetworkSiblingSetNetAppResource(WaitUntil waitUntil, AzureLocation location, UpdateNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = NetAppResourceClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.UpdateNetworkSiblingSetNetAppResource");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = NetAppResourceRestClient.CreateUpdateNetworkSiblingSetNetAppResourceRequest(Guid.Parse(Id.SubscriptionId), location, UpdateNetworkSiblingSetContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                NetAppArmOperation<NetworkSiblingSet> operation = new NetAppArmOperation<NetworkSiblingSet>(
                    new NetworkSiblingSetOperationSource(),
                    NetAppResourceClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // ---- Resource Usage methods (old named overloads) ----

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppUsageResult> GetNetAppResourceUsagesAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetAllAsync(location, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppUsageResult> GetNetAppResourceUsages(AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetAll(location, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppUsageResult>> GetNetAppResourceUsageAsync(AzureLocation location, string usageType, CancellationToken cancellationToken = default)
        {
            return await GetAsync(location, usageType, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppUsageResult> GetNetAppResourceUsage(AzureLocation location, string usageType, CancellationToken cancellationToken = default)
        {
            return Get(location, usageType, cancellationToken);
        }

        // ---- Helper types ----

        private static NetAppSubscriptionQuotaItem ToLegacyQuotaItem(NetAppSubscriptionQuotaItemData data)
        {
            if (data == null)
            {
                return null;
            }

            return new NetAppSubscriptionQuotaItem(data.Id, data.Name, data.ResourceType, data.SystemData, data.Current, data.Default, data.Usage);
        }

        private class LegacyQuotaItemAsyncPageable : AsyncPageable<NetAppSubscriptionQuotaItem>
        {
            private readonly AsyncPageable<NetAppSubscriptionQuotaItemResource> _source;

            public LegacyQuotaItemAsyncPageable(AsyncPageable<NetAppSubscriptionQuotaItemResource> source)
            {
                _source = source;
            }

            public override async IAsyncEnumerable<Page<NetAppSubscriptionQuotaItem>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<NetAppSubscriptionQuotaItemResource> page in _source.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    yield return Page<NetAppSubscriptionQuotaItem>.FromValues(
                        page.Values.Select(item => ToLegacyQuotaItem(item.Data)).ToList(),
                        page.ContinuationToken,
                        page.GetRawResponse());
                }
            }
        }

        private class NetworkSiblingSetOperationSource : IOperationSource<NetworkSiblingSet>
        {
            NetworkSiblingSet IOperationSource<NetworkSiblingSet>.CreateResult(Response response, CancellationToken cancellationToken)
            {
                using JsonDocument document = JsonDocument.Parse(response.ContentStream);
                return NetworkSiblingSet.DeserializeNetworkSiblingSet(document.RootElement, ModelSerializationExtensions.WireOptions);
            }

            async ValueTask<NetworkSiblingSet> IOperationSource<NetworkSiblingSet>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            {
                using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                return NetworkSiblingSet.DeserializeNetworkSiblingSet(document.RootElement, ModelSerializationExtensions.WireOptions);
            }
        }
    }
}
