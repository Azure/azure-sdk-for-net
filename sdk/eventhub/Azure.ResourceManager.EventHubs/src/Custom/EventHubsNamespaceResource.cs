// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventHubs
{
    /// <summary>
    /// A Class representing an EventHubsNamespace along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="EventHubsNamespaceResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetEventHubsNamespaceResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetEventHubsNamespace method.
    /// </summary>
    public partial class EventHubsNamespaceResource : ArmResource
    {
        /// <summary>
        /// Creates or updates a namespace. Once created, this namespace's resource manifest is immutable. This operation is idempotent.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Namespaces_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="EventHubsNamespaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Parameters for updating a namespace resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<EventHubsNamespaceResource>> UpdateAsync(EventHubsNamespaceData data, CancellationToken cancellationToken = default)
        {
            var lro = await UpdateAsync(WaitUntil.Completed, data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(lro.Value, lro.GetRawResponse());
        }

        /// <summary>
        /// Creates or updates a namespace. Once created, this namespace's resource manifest is immutable. This operation is idempotent.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Namespaces_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-01-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="EventHubsNamespaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Parameters for updating a namespace resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<EventHubsNamespaceResource> Update(EventHubsNamespaceData data, CancellationToken cancellationToken = default)
        {
            var lro = Update(WaitUntil.Completed, data, cancellationToken);
            return Response.FromValue(lro.Value, lro.GetRawResponse());
        }

        /// <summary>
        /// Refreshes a Network Security Perimeter Configuration.
        /// This method is preserved for backward compatibility.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="resourceAssociationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation CreateOrUpdateNetworkSecurityPerimeterConfiguration(WaitUntil waitUntil, string resourceAssociationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceAssociationName, nameof(resourceAssociationName));

            var collection = GetEventHubsNetworkSecurityPerimeterConfigurations();
            var resource = collection.Get(resourceAssociationName, cancellationToken).Value;
            var lro = resource.CreateOrUpdate(waitUntil, cancellationToken);
            return new NspArmOperationWrapper(lro);
        }

        /// <summary>
        /// Refreshes a Network Security Perimeter Configuration.
        /// This method is preserved for backward compatibility.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="resourceAssociationName"> The name of the resource association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> CreateOrUpdateNetworkSecurityPerimeterConfigurationAsync(WaitUntil waitUntil, string resourceAssociationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceAssociationName, nameof(resourceAssociationName));

            var collection = GetEventHubsNetworkSecurityPerimeterConfigurations();
            var resource = (await collection.GetAsync(resourceAssociationName, cancellationToken).ConfigureAwait(false)).Value;
            var lro = await resource.CreateOrUpdateAsync(waitUntil, cancellationToken).ConfigureAwait(false);
            return new NspArmOperationWrapper(lro);
        }

        private class NspArmOperationWrapper : ArmOperation
        {
            private readonly ArmOperation<EventHubsNetworkSecurityPerimeterConfigurationResource> _inner;

            public NspArmOperationWrapper(ArmOperation<EventHubsNetworkSecurityPerimeterConfigurationResource> inner)
            {
                _inner = inner;
            }

            public override string Id => _inner.Id;
            public override bool HasCompleted => _inner.HasCompleted;
            public override Response GetRawResponse() => _inner.GetRawResponse();
            public override Response UpdateStatus(CancellationToken cancellationToken = default) => _inner.UpdateStatus(cancellationToken);
            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _inner.UpdateStatusAsync(cancellationToken);
        }

        /// <summary>
        /// Gets list of NetworkSecurityPerimeterConfiguration for a namespace.
        /// This method is preserved for backward compatibility.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventHubsNetworkSecurityPerimeterConfiguration> GetNetworkSecurityPerimeterConfigurations(CancellationToken cancellationToken = default)
        {
            var collection = GetEventHubsNetworkSecurityPerimeterConfigurations();
            return Pageable<EventHubsNetworkSecurityPerimeterConfiguration>.FromPages(
                collection.GetAll(cancellationToken).AsPages().Select(page =>
                    Page<EventHubsNetworkSecurityPerimeterConfiguration>.FromValues(
                        page.Values.Select(r => EventHubsNetworkSecurityPerimeterConfiguration.FromData(r.Data)).ToArray(),
                        page.ContinuationToken,
                        page.GetRawResponse())));
        }

        /// <summary>
        /// Gets list of NetworkSecurityPerimeterConfiguration for a namespace.
        /// This method is preserved for backward compatibility.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EventHubsNetworkSecurityPerimeterConfiguration> GetNetworkSecurityPerimeterConfigurationsAsync(CancellationToken cancellationToken = default)
        {
            var collection = GetEventHubsNetworkSecurityPerimeterConfigurations();
            return AsyncPageable<EventHubsNetworkSecurityPerimeterConfiguration>.FromPages(
                collection.GetAll(cancellationToken).AsPages().Select(page =>
                    Page<EventHubsNetworkSecurityPerimeterConfiguration>.FromValues(
                        page.Values.Select(r => EventHubsNetworkSecurityPerimeterConfiguration.FromData(r.Data)).ToArray(),
                        page.ContinuationToken,
                        page.GetRawResponse())));
        }

        /// <summary>
        /// Return a NetworkSecurityPerimeterConfigurations resourceAssociationName
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkSecurityPerimeterConfigurations/{resourceAssociationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NetworkSecurityPerimeterConfigurations_GetResourceAssociationName</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-05-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceAssociationName"> The ResourceAssociation Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceAssociationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceAssociationName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<EventHubsNetworkSecurityPerimeterConfiguration>> GetNetworkSecurityPerimeterAssociationNameAsync(string resourceAssociationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceAssociationName, nameof(resourceAssociationName));

            var collection = GetEventHubsNetworkSecurityPerimeterConfigurations();
            var response = await collection.GetAsync(resourceAssociationName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(EventHubsNetworkSecurityPerimeterConfiguration.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Return a NetworkSecurityPerimeterConfigurations resourceAssociationName
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkSecurityPerimeterConfigurations/{resourceAssociationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NetworkSecurityPerimeterConfigurations_GetResourceAssociationName</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-05-01-preview</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceAssociationName"> The ResourceAssociation Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceAssociationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceAssociationName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<EventHubsNetworkSecurityPerimeterConfiguration> GetNetworkSecurityPerimeterAssociationName(string resourceAssociationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceAssociationName, nameof(resourceAssociationName));

            var collection = GetEventHubsNetworkSecurityPerimeterConfigurations();
            var response = collection.Get(resourceAssociationName, cancellationToken);
            return Response.FromValue(EventHubsNetworkSecurityPerimeterConfiguration.FromData(response.Value.Data), response.GetRawResponse());
        }
    }
}
