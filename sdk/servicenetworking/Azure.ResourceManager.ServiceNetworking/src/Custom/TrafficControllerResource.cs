// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ServiceNetworking
{
#pragma warning disable 0618
    /// <summary>
    /// A Class representing a TrafficController along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="TrafficControllerResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetTrafficControllerResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetTrafficController method.
    /// </summary>
    public partial class TrafficControllerResource : ArmResource
    {
        /// <summary> Gets a collection of AssociationResources in the TrafficController. </summary>
        /// <returns> An object representing collection of AssociationResources and their operations over a AssociationResource. </returns>
        [Obsolete("This method is now deprecated. Please use `GetTrafficControllerAssociations` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AssociationCollection GetAssociations()
        {
            return GetCachedClient(client => new AssociationCollection(client, Id));
        }

        /// <summary>
        /// Get a Association
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="associationName"> Name of Association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="associationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="associationName"/> is an empty string, and was expected to be non-empty. </exception>
        [Obsolete("This method is now deprecated. Please use `GetTrafficControllerAssociationAsync` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<AssociationResource>> GetAssociationAsync(string associationName, CancellationToken cancellationToken = default)
        {
            return await GetAssociations().GetAsync(associationName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a Association
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/associations/{associationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AssociationsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AssociationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="associationName"> Name of Association. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="associationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="associationName"/> is an empty string, and was expected to be non-empty. </exception>
        [Obsolete("This method is now deprecated. Please use `GetTrafficControllerAssociation` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<AssociationResource> GetAssociation(string associationName, CancellationToken cancellationToken = default)
        {
            return GetAssociations().Get(associationName, cancellationToken);
        }

        /// <summary> Gets a collection of FrontendResources in the TrafficController. </summary>
        /// <returns> An object representing collection of FrontendResources and their operations over a FrontendResource. </returns>
        [Obsolete("This method is now deprecated. Please use `GetTrafficControllerFrontends` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FrontendCollection GetFrontends()
        {
            return GetCachedClient(client => new FrontendCollection(client, Id));
        }

        /// <summary>
        /// Get a Frontend
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends/{frontendName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="frontendName"> Frontends. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="frontendName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="frontendName"/> is an empty string, and was expected to be non-empty. </exception>
        [Obsolete("This method is now deprecated. Please use `GetTrafficControllerFrontendAsync` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<FrontendResource>> GetFrontendAsync(string frontendName, CancellationToken cancellationToken = default)
        {
            return await GetFrontends().GetAsync(frontendName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a Frontend
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceNetworking/trafficControllers/{trafficControllerName}/frontends/{frontendName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FrontendsInterface_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FrontendResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="frontendName"> Frontends. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="frontendName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="frontendName"/> is an empty string, and was expected to be non-empty. </exception>
        [Obsolete("This method is now deprecated. Please use `GetTrafficControllerFrontend` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<FrontendResource> GetFrontend(string frontendName, CancellationToken cancellationToken = default)
        {
            return GetFrontends().Get(frontendName, cancellationToken);
        }
    }
#pragma warning restore 0618
}
