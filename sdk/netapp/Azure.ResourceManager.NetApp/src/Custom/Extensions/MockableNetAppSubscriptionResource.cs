// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableNetAppSubscriptionResource
    {
        // v1.15 exposed quota operations returning the legacy POCO; generated methods now
        // return resources, so these shims unwrap Data to preserve source compatibility.

        /// <summary>
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The default and current quota limit. </returns>
        public virtual async Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppSubscriptionQuotaLimitAsync(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Response<NetAppSubscriptionQuotaItemResource> response = await GetNetAppSubscriptionQuotaItemAsync(location, quotaLimitName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ToLegacyQuotaItem(response.Value?.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The default and current quota limit. </returns>
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimit(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Response<NetAppSubscriptionQuotaItemResource> response = GetNetAppSubscriptionQuotaItem(location, quotaLimitName, cancellationToken);
            return Response.FromValue(ToLegacyQuotaItem(response.Value?.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of quota limits. </returns>
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimitsAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            var pageable = GetNetAppSubscriptionQuotaItems(location).GetAllAsync(cancellationToken);
            return new AsyncPageableWrapper<NetAppSubscriptionQuotaItemResource, NetAppSubscriptionQuotaItem>(pageable, item => ToLegacyQuotaItem(item.Data));
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of quota limits. </returns>
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimits(AzureLocation location, CancellationToken cancellationToken = default)
        {
            var pageable = GetNetAppSubscriptionQuotaItems(location).GetAll(cancellationToken);
            return new PageableWrapper<NetAppSubscriptionQuotaItemResource, NetAppSubscriptionQuotaItem>(pageable, item => ToLegacyQuotaItem(item.Data));
        }

        /// <summary> Gets the default and current quota limit for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <returns> The quota limit resource. </returns>
        public virtual async Task<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitAsync(AzureLocation location, string quotaLimitName)
        {
            // v1.15 quirk: this overload returned the bare resource (without Response<>) and
            // had no CancellationToken parameter. Forward to the generated async getter and
            // unwrap the Response<>.
            var response = await GetNetAppSubscriptionQuotaItemAsync(location, quotaLimitName).ConfigureAwait(false);
            return response.Value;
        }

        /// <summary> Lists quota limits for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <returns> A collection of quota limit resources. </returns>
        public virtual AsyncPageable<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitsAsync(AzureLocation location)
        {
            return GetNetAppSubscriptionQuotaItems(location).GetAllAsync();
        }

        /// <summary> Gets the default and current quota limit for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The default and current quota limit. </returns>
        public virtual Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppQuotaLimitAsync(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimitAsync(location, quotaLimitName, cancellationToken);

        /// <summary> Gets the default and current quota limit for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The default and current quota limit. </returns>
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimit(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimit(location, quotaLimitName, cancellationToken);

        /// <summary> Lists quota limits for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of quota limits. </returns>
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimitsAsync(location, cancellationToken);

        /// <summary> Lists quota limits for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of quota limits. </returns>
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(AzureLocation location, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimits(location, cancellationToken);

        // v1.15 used AzureLocation for these provider actions. Modeling the spec parameter as
        // AzureLocation keeps the REST helpers correctly typed, but the generator currently drops
        // these convenience methods (https://github.com/Azure/azure-sdk-for-net/issues/59144).

        /// <summary> Checks if a file path is available. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="content"> The file path availability request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The availability result. </returns>
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

        /// <summary> Checks if a file path is available. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="content"> The file path availability request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The availability result. </returns>
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

        /// <summary> Checks if a NetApp resource name is available. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="content"> The name availability request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The availability result. </returns>
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

        /// <summary> Checks if a NetApp resource name is available. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="content"> The name availability request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The availability result. </returns>
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

        /// <summary> Checks if a quota is available. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="content"> The quota availability request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The availability result. </returns>
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

        /// <summary> Checks if a quota is available. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="content"> The quota availability request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The availability result. </returns>
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

        /// <summary> Provides storage to network proximity and target region information. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The region information. </returns>
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

        /// <summary> Provides storage to network proximity and target region information. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The region information. </returns>
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

        /// <summary> Gets the region info resources for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <returns> The region info resource collection. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetRegionInfoResources is not supported. Use GetRegionInfoResource instead.", false)]
        public virtual RegionInfoResourceCollection GetRegionInfoResources(AzureLocation location)
        {
            throw new NotSupportedException("GetRegionInfoResources is not supported. Use GetRegionInfoResource instead.");
        }

        /// <summary> Gets a region info resource. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The region info resource. </returns>
        [ForwardsClientCalls]
        public virtual Task<Response<RegionInfoResource>> GetRegionInfoResourceAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("GetRegionInfoResourceAsync with AzureLocation is not supported. Use GetRegionInfoResource() instead.");
        }

        /// <summary> Gets a region info resource. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The region info resource. </returns>
        [ForwardsClientCalls]
        public virtual Response<RegionInfoResource> GetRegionInfoResource(AzureLocation location, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("GetRegionInfoResource with AzureLocation is not supported. Use GetRegionInfoResource() instead.");
        }

        // ---- Network Sibling Set AzureLocation shims (see header on Check Availability section) ----

        /// <summary> Gets details of the specified network sibling set. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="content"> The network sibling set request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The network sibling set. </returns>
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

        /// <summary> Gets details of the specified network sibling set. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="content"> The network sibling set request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The network sibling set. </returns>
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

        /// <summary> Updates the network features of the specified network sibling set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="location"> The location name. </param>
        /// <param name="content"> The network sibling set update content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An operation representing the update. </returns>
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

        /// <summary> Updates the network features of the specified network sibling set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="location"> The location name. </param>
        /// <param name="content"> The network sibling set update content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An operation representing the update. </returns>
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

        // ---- Helper types ----

        private static NetAppSubscriptionQuotaItem ToLegacyQuotaItem(NetAppSubscriptionQuotaItemData data)
        {
            if (data == null)
            {
                return null;
            }

            return new NetAppSubscriptionQuotaItem(data.Id, data.Name, data.ResourceType, data.SystemData, data.Current, data.Default, data.Usage);
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
