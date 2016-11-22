// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.Update
{
    using xternalEndpoint;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerProfile.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    using estedProfileEndpoint;
    using Microsoft.Azure.Management.Trafficmanager.Fluent;

    /// <summary>
    /// The stage of the traffic manager profile endpoint update allowing to specify the endpoint weight.
    /// </summary>
    public interface IWithRoutingWeight 
    {
        /// <summary>
        /// Specifies the weight for the endpoint that will be used when the weight-based routing method
        /// TrafficRoutingMethod.WEIGHTED is enabled on the profile.
        /// </summary>
        /// <param name="weight">The endpoint weight.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithRoutingWeight(int weight);
    }

    /// <summary>
    /// The stage of an Azure endpoint update allowing to specify the target Azure resource.
    /// </summary>
    public interface IWithAzureResource 
    {
        /// <summary>
        /// Specifies the resource ID of an Azure resource.
        /// <p>
        /// supported Azure resources are cloud service, web app or public ip.
        /// </summary>
        /// <param name="resourceId">The Azure resource id.</param>
        /// <return>The next stage of the update.</return>
        IUpdate ToResourceId(string resourceId);
    }

    /// <summary>
    /// The stage of the traffic manager profile endpoint update allowing to specify the endpoint priority.
    /// </summary>
    public interface IWithRoutingPriority 
    {
        /// <summary>
        /// Specifies the weight for the endpoint that will be used when priority-based routing method
        /// is TrafficRoutingMethod.PRIORITY enabled on the profile.
        /// </summary>
        /// <param name="priority">The endpoint priority.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithRoutingPriority(int priority);
    }

    /// <summary>
    /// The stage of an external endpoint update allowing to specify the FQDN.
    /// </summary>
    public interface IWithFqdn 
    {
        /// <summary>
        /// Specifies the FQDN of an external endpoint that is not hosted in Azure.
        /// </summary>
        /// <param name="externalFqdn">The external FQDN.</param>
        /// <return>The next stage of the endpoint update.</return>
        xternalEndpoint.IUpdateExternalEndpoint ToFqdn(string externalFqdn);
    }

    /// <summary>
    /// The stage of the traffic manager endpoint update allowing to specify the location of the external
    /// or nested profile endpoints.
    /// </summary>
    public interface IWithSourceTrafficRegion 
    {
        /// <summary>
        /// Specifies the region of the endpoint that will be used when the performance-based routing method
        /// TrafficRoutingMethod.PERFORMANCE is enabled on the profile.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdate FromRegion(Region location);
    }

    /// <summary>
    /// The set of configurations that can be updated for all endpoint irrespective of their type (Azure, external, nested profile).
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerProfile.Update.IUpdate>,
        IWithRoutingWeight,
        IWithRoutingPriority,
        IWithTrafficDisabledOrEnabled
    {
    }

    /// <summary>
    /// The stage of an nested profile endpoint update allowing to specify profile and
    /// minimum child endpoint.
    /// </summary>
    public interface IWithNestedProfileConfig 
    {
        /// <summary>
        /// Specifies a nested traffic manager profile for the endpoint.
        /// </summary>
        /// <param name="nestedProfile">The nested traffic manager profile.</param>
        /// <return>The next stage of the update.</return>
        estedProfileEndpoint.IUpdateNestedProfileEndpoint ToProfile(ITrafficManagerProfile nestedProfile);

        /// <summary>
        /// Specifies the minimum number of endpoints to be online for the nested profile to be considered healthy.
        /// </summary>
        /// <param name="count">Number of endpoints.</param>
        /// <return>The next stage of the endpoint update.</return>
        estedProfileEndpoint.IUpdateNestedProfileEndpoint WithMinimumEndpointsToEnableTraffic(int count);
    }

    /// <summary>
    /// The stage of the traffic manager profile endpoint update allowing to enable or disable it.
    /// </summary>
    public interface IWithTrafficDisabledOrEnabled 
    {
        /// <summary>
        /// Specifies that the endpoint should be excluded from receiving traffic.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithTrafficDisabled();

        /// <summary>
        /// Specifies that the endpoint should receive the traffic.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithTrafficEnabled();
    }
}