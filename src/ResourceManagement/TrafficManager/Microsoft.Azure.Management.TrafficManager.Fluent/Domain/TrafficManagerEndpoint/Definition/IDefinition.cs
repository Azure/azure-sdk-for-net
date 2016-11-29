// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Trafficmanager.Fluent;

    /// <summary>
    /// The final stage of the traffic manager profile endpoint definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the traffic manager profile endpoint
    /// definition can be attached to the parent traffic manager profile definition using TrafficManagerEndpoint.DefinitionStages.WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of TrafficManagerEndpoint.DefinitionStages.WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>,
        IWithRoutingWeight<ParentT>,
        IWithRoutingPriority<ParentT>,
        IWithTrafficDisabled<ParentT>
    {
    }

    /// <summary>
    /// The stage of the traffic manager endpoint definition allowing to disable the endpoint.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithTrafficDisabled<ParentT> 
    {
        /// <summary>
        /// Specifies that this endpoint should be excluded from receiving traffic.
        /// </summary>
        /// <return>The next stage of the endpoint definition.</return>
        IWithAttach<ParentT> WithTrafficDisabled();
    }

    /// <summary>
    /// The stage of the traffic manager profile Azure endpoint definition allowing to specify the ID
    /// of the target Azure resource.
    /// </summary>
    /// <typeparam name="Parent">The return type of UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IWithAzureResource<ParentT> 
    {
        /// <summary>
        /// Specifies the resource ID of an Azure resource.
        /// <p>
        /// supported Azure resources are cloud service, web app or public ip.
        /// </summary>
        /// <param name="resourceId">The Azure resource id.</param>
        /// <return>The next stage of the definition.</return>
        IWithAttach<ParentT> ToResourceId(string resourceId);
    }

    /// <summary>
    /// The first stage of a traffic manager profile Azure endpoint definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IAzureTargetEndpointBlank<ParentT>  :
        IWithAzureResource<ParentT>
    {
    }

    /// <summary>
    /// The stage of the traffic manager endpoint definition allowing to specify the endpoint priority.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithRoutingPriority<ParentT> 
    {
        /// <summary>
        /// Specifies the priority for the endpoint that will be used when the parent profile is configured with
        /// Priority routing method TrafficRoutingMethod.PRIORITY.
        /// </summary>
        /// <param name="priority">The endpoint priority.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithAttach<ParentT> WithRoutingPriority(int priority);
    }

    /// <summary>
    /// The stage of the traffic manager endpoint definition allowing to specify the endpoint weight.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithRoutingWeight<ParentT> 
    {
        /// <summary>
        /// Specifies the weight for the endpoint that will be used when the parent profile is configured with
        /// Weighted routing method TrafficRoutingMethod.WEIGHTED.
        /// </summary>
        /// <param name="weight">The endpoint weight.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithAttach<ParentT> WithRoutingWeight(int weight);
    }

    /// <summary>
    /// The first stage of a traffic manager profile external endpoint definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IExternalTargetEndpointBlank<ParentT>  :
        IWithFqdn<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a traffic manager profile endpoint definition as a part of parent definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        IAzureTargetEndpointBlank<ParentT>,
        IExternalTargetEndpointBlank<ParentT>,
        INestedProfileTargetEndpointBlank<ParentT>,
        IWithAzureResource<ParentT>,
        IWithFqdn<ParentT>,
        IWithSourceTrafficRegion<ParentT>,
        IWithSourceTrafficRegionThenThreshold<ParentT>,
        IWithEndpointThreshold<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the traffic manager endpoint definition allowing to specify the location of the nested
    /// profile endpoint.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithSourceTrafficRegionThenThreshold<ParentT> 
    {
        /// <summary>
        /// Specifies the location of the endpoint that will be used when the parent profile is configured with
        /// Performance routing method TrafficRoutingMethod.PERFORMANCE.
        /// </summary>
        /// <param name="region">The location.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithEndpointThreshold<ParentT> FromRegion(Region region);
    }

    /// <summary>
    /// The stage of the nested traffic manager profile endpoint definition allowing to specify the minimum
    /// endpoints to be online in the nested profile to consider it as not degraded.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithEndpointThreshold<ParentT>  :
        IWithAttach<ParentT>
    {
        /// <summary>
        /// Specifies the minimum number of endpoints to be online for the nested profile to be considered healthy.
        /// </summary>
        /// <param name="count">The number of endpoints.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithAttach<ParentT> WithMinimumEndpointsToEnableTraffic(int count);
    }

    /// <summary>
    /// The stage of the traffic manager endpoint definition allowing to specify the location of the external
    /// endpoint.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithSourceTrafficRegion<ParentT> 
    {
        /// <summary>
        /// Specifies the location of the endpoint that will be used when the parent profile is configured with
        /// Performance routing method TrafficRoutingMethod.PERFORMANCE.
        /// </summary>
        /// <param name="region">The location.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithAttach<ParentT> FromRegion(Region region);
    }

    /// <summary>
    /// The stage of the traffic manager nested profile endpoint definition allowing to specify the profile.
    /// </summary>
    /// <typeparam name="Parent">The return type of UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IWithNestedProfile<ParentT> 
    {
        /// <summary>
        /// Specifies a nested traffic manager profile for the endpoint.
        /// </summary>
        /// <param name="profile">The nested traffic manager profile.</param>
        /// <return>The next stage of the definition.</return>
        IWithSourceTrafficRegionThenThreshold<ParentT> ToProfile(ITrafficManagerProfile profile);
    }

    /// <summary>
    /// The first stage of a traffic manager profile nested profile endpoint definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface INestedProfileTargetEndpointBlank<ParentT>  :
        IWithNestedProfile<ParentT>
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile external endpoint definition allowing to specify
    /// the FQDN.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithFqdn<ParentT> 
    {
        /// <summary>
        /// Specifies the FQDN of an external endpoint.
        /// </summary>
        /// <param name="externalFqdn">The external FQDN.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithSourceTrafficRegion<ParentT> ToFqdn(string externalFqdn);
    }
}