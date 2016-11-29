// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using TrafficManagerEndpoint.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Threading.Tasks;
    using TrafficManagerProfile.Update;
    using TrafficManagerEndpoint.UpdateDefinition;
    using TrafficManagerEndpoint.Definition;
    using System.Threading;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using TrafficManagerEndpoint.UpdateNestedProfileEndpoint;
    using TrafficManagerEndpoint.UpdateExternalEndpoint;
    using TrafficManagerProfile.Definition;
    using TrafficManagerEndpoint.UpdateAzureEndpoint;

    internal partial class TrafficManagerEndpointImpl 
    {
        /// <summary>
        /// Specifies that this endpoint should be excluded from receiving traffic.
        /// </summary>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate> TrafficManagerEndpoint.Definition.IWithTrafficDisabled<TrafficManagerProfile.Definition.IWithCreate>.WithTrafficDisabled()
        {
            return this.WithTrafficDisabled() as TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies that this endpoint should be excluded from receiving traffic.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate> TrafficManagerEndpoint.UpdateDefinition.IWithTrafficDisabled<TrafficManagerProfile.Update.IUpdate>.WithTrafficDisabled()
        {
            return this.WithTrafficDisabled() as TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the location of the endpoint that will be used when the parent profile is configured with
        /// Performance routing method TrafficRoutingMethod.PERFORMANCE.
        /// </summary>
        /// <param name="region">The location.</param>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.Definition.IWithEndpointThreshold<TrafficManagerProfile.Definition.IWithCreate> TrafficManagerEndpoint.Definition.IWithSourceTrafficRegionThenThreshold<TrafficManagerProfile.Definition.IWithCreate>.FromRegion(Region region)
        {
            return this.FromRegion(region) as TrafficManagerEndpoint.Definition.IWithEndpointThreshold<TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the location of the endpoint that will be used when the parent profile is configured with
        /// Performance routing method TrafficRoutingMethod.PERFORMANCE.
        /// </summary>
        /// <param name="region">The location.</param>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.UpdateDefinition.IWithEndpointThreshold<TrafficManagerProfile.Update.IUpdate> TrafficManagerEndpoint.UpdateDefinition.IWithSourceTrafficRegionThenThreshold<TrafficManagerProfile.Update.IUpdate>.FromRegion(Region region)
        {
            return this.FromRegion(region) as TrafficManagerEndpoint.UpdateDefinition.IWithEndpointThreshold<TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the priority for the endpoint that will be used when the parent profile is configured with
        /// Priority routing method TrafficRoutingMethod.PRIORITY.
        /// </summary>
        /// <param name="priority">The endpoint priority.</param>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate> TrafficManagerEndpoint.Definition.IWithRoutingPriority<TrafficManagerProfile.Definition.IWithCreate>.WithRoutingPriority(int priority)
        {
            return this.WithRoutingPriority(priority) as TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the weight for the endpoint that will be used when priority-based routing method
        /// is TrafficRoutingMethod.PRIORITY enabled on the profile.
        /// </summary>
        /// <param name="priority">
        /// Priority of this endpoint. Possible values are from 1 to 1000, lower
        /// values represent higher priority.
        /// </param>
        /// <return>The next stage of the definition.</return>
        TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate> TrafficManagerEndpoint.UpdateDefinition.IWithRoutingPriority<TrafficManagerProfile.Update.IUpdate>.WithRoutingPriority(int priority)
        {
            return this.WithRoutingPriority(priority) as TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that the endpoint should receive the traffic.
        /// </summary>
        /// <return>The next stage of the update.</return>
        TrafficManagerEndpoint.Update.IUpdate TrafficManagerEndpoint.Update.IWithTrafficDisabledOrEnabled.WithTrafficEnabled()
        {
            return this.WithTrafficEnabled() as TrafficManagerEndpoint.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the endpoint should be excluded from receiving traffic.
        /// </summary>
        /// <return>The next stage of the update.</return>
        TrafficManagerEndpoint.Update.IUpdate TrafficManagerEndpoint.Update.IWithTrafficDisabledOrEnabled.WithTrafficDisabled()
        {
            return this.WithTrafficDisabled() as TrafficManagerEndpoint.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the FQDN of an external endpoint that is not hosted in Azure.
        /// </summary>
        /// <param name="externalFqdn">The external FQDN.</param>
        /// <return>The next stage of the endpoint update.</return>
        TrafficManagerEndpoint.UpdateExternalEndpoint.IUpdateExternalEndpoint TrafficManagerEndpoint.Update.IWithFqdn.ToFqdn(string externalFqdn)
        {
            return this.ToFqdn(externalFqdn) as TrafficManagerEndpoint.UpdateExternalEndpoint.IUpdateExternalEndpoint;
        }

        /// <summary>
        /// Specifies the resource ID of an Azure resource.
        /// <p>
        /// supported Azure resources are cloud service, web app or public ip.
        /// </summary>
        /// <param name="resourceId">The Azure resource id.</param>
        /// <return>The next stage of the update.</return>
        TrafficManagerEndpoint.Update.IUpdate TrafficManagerEndpoint.Update.IWithAzureResource.ToResourceId(string resourceId)
        {
            return this.ToResourceId(resourceId) as TrafficManagerEndpoint.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<TrafficManagerProfile.Update.IUpdate>.Attach()
        {
            return this.Attach() as TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the weight for the endpoint that will be used when the parent profile is configured with
        /// Weighted routing method TrafficRoutingMethod.WEIGHTED.
        /// </summary>
        /// <param name="weight">The endpoint weight.</param>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate> TrafficManagerEndpoint.Definition.IWithRoutingWeight<TrafficManagerProfile.Definition.IWithCreate>.WithRoutingWeight(int weight)
        {
            return this.WithRoutingWeight(weight) as TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the weight for the endpoint that will be used when the weight-based routing method
        /// TrafficRoutingMethod.WEIGHTED is enabled on the profile.
        /// </summary>
        /// <param name="weight">The endpoint weight.</param>
        /// <return>The next stage of the definition.</return>
        TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate> TrafficManagerEndpoint.UpdateDefinition.IWithRoutingWeight<TrafficManagerProfile.Update.IUpdate>.WithRoutingWeight(int weight)
        {
            return this.WithRoutingWeight(weight) as TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the minimum number of endpoints to be online for the nested profile to be considered healthy.
        /// </summary>
        /// <param name="count">The number of endpoints.</param>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate> TrafficManagerEndpoint.Definition.IWithEndpointThreshold<TrafficManagerProfile.Definition.IWithCreate>.WithMinimumEndpointsToEnableTraffic(int count)
        {
            return this.WithMinimumEndpointsToEnableTraffic(count) as TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the minimum number of endpoints to be online for the nested profile to be considered healthy.
        /// </summary>
        /// <param name="count">The number of endpoints.</param>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate> TrafficManagerEndpoint.UpdateDefinition.IWithEndpointThreshold<TrafficManagerProfile.Update.IUpdate>.WithMinimumEndpointsToEnableTraffic(int count)
        {
            return this.WithMinimumEndpointsToEnableTraffic(count) as TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the weight for the endpoint that will be used when the weight-based routing method
        /// TrafficRoutingMethod.WEIGHTED is enabled on the profile.
        /// </summary>
        /// <param name="weight">The endpoint weight.</param>
        /// <return>The next stage of the update.</return>
        TrafficManagerEndpoint.Update.IUpdate TrafficManagerEndpoint.Update.IWithRoutingWeight.WithRoutingWeight(int weight)
        {
            return this.WithRoutingWeight(weight) as TrafficManagerEndpoint.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a nested traffic manager profile for the endpoint.
        /// </summary>
        /// <param name="profile">The nested traffic manager profile.</param>
        /// <return>The next stage of the definition.</return>
        TrafficManagerEndpoint.Definition.IWithSourceTrafficRegionThenThreshold<TrafficManagerProfile.Definition.IWithCreate> TrafficManagerEndpoint.Definition.IWithNestedProfile<TrafficManagerProfile.Definition.IWithCreate>.ToProfile(ITrafficManagerProfile profile)
        {
            return this.ToProfile(profile) as TrafficManagerEndpoint.Definition.IWithSourceTrafficRegionThenThreshold<TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies a nested traffic manager profile for the endpoint.
        /// </summary>
        /// <param name="profile">The nested traffic manager profile.</param>
        /// <return>The next stage of the definition.</return>
        TrafficManagerEndpoint.UpdateDefinition.IWithSourceTrafficRegionThenThreshold<TrafficManagerProfile.Update.IUpdate> TrafficManagerEndpoint.UpdateDefinition.IWithNestedProfile<TrafficManagerProfile.Update.IUpdate>.ToProfile(ITrafficManagerProfile profile)
        {
            return this.ToProfile(profile) as TrafficManagerEndpoint.UpdateDefinition.IWithSourceTrafficRegionThenThreshold<TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        TrafficManagerProfile.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<TrafficManagerProfile.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as TrafficManagerProfile.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the FQDN of an external endpoint.
        /// </summary>
        /// <param name="externalFqdn">The external FQDN.</param>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.Definition.IWithSourceTrafficRegion<TrafficManagerProfile.Definition.IWithCreate> TrafficManagerEndpoint.Definition.IWithFqdn<TrafficManagerProfile.Definition.IWithCreate>.ToFqdn(string externalFqdn)
        {
            return this.ToFqdn(externalFqdn) as TrafficManagerEndpoint.Definition.IWithSourceTrafficRegion<TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the FQDN of an external endpoint.
        /// </summary>
        /// <param name="externalFqdn">The external FQDN.</param>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.UpdateDefinition.IWithSourceTrafficRegion<TrafficManagerProfile.Update.IUpdate> TrafficManagerEndpoint.UpdateDefinition.IWithFqdn<TrafficManagerProfile.Update.IUpdate>.ToFqdn(string externalFqdn)
        {
            return this.ToFqdn(externalFqdn) as TrafficManagerEndpoint.UpdateDefinition.IWithSourceTrafficRegion<TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the weight for the endpoint that will be used when priority-based routing method
        /// is TrafficRoutingMethod.PRIORITY enabled on the profile.
        /// </summary>
        /// <param name="priority">The endpoint priority.</param>
        /// <return>The next stage of the update.</return>
        TrafficManagerEndpoint.Update.IUpdate TrafficManagerEndpoint.Update.IWithRoutingPriority.WithRoutingPriority(int priority)
        {
            return this.WithRoutingPriority(priority) as TrafficManagerEndpoint.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the location of the endpoint that will be used when the parent profile is configured with
        /// Performance routing method TrafficRoutingMethod.PERFORMANCE.
        /// </summary>
        /// <param name="region">The location.</param>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate> TrafficManagerEndpoint.Definition.IWithSourceTrafficRegion<TrafficManagerProfile.Definition.IWithCreate>.FromRegion(Region region)
        {
            return this.FromRegion(region) as TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the location of the endpoint that will be used when the parent profile is configured with
        /// Performance routing method TrafficRoutingMethod.PERFORMANCE.
        /// </summary>
        /// <param name="region">The location.</param>
        /// <return>The next stage of the endpoint definition.</return>
        TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate> TrafficManagerEndpoint.UpdateDefinition.IWithSourceTrafficRegion<TrafficManagerProfile.Update.IUpdate>.FromRegion(Region region)
        {
            return this.FromRegion(region) as TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the resource ID of an Azure resource.
        /// <p>
        /// supported Azure resources are cloud service, web app or public ip.
        /// </summary>
        /// <param name="resourceId">The Azure resource id.</param>
        /// <return>The next stage of the definition.</return>
        TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate> TrafficManagerEndpoint.Definition.IWithAzureResource<TrafficManagerProfile.Definition.IWithCreate>.ToResourceId(string resourceId)
        {
            return this.ToResourceId(resourceId) as TrafficManagerEndpoint.Definition.IWithAttach<TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the resource ID of an Azure resource.
        /// <p>
        /// supported Azure resources are cloud service, web app or public ip.
        /// </summary>
        /// <param name="resourceId">The Azure resource id.</param>
        /// <return>The next stage of the definition.</return>
        TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate> TrafficManagerEndpoint.UpdateDefinition.IWithAzureResource<TrafficManagerProfile.Update.IUpdate>.ToResourceId(string resourceId)
        {
            return this.ToResourceId(resourceId) as TrafficManagerEndpoint.UpdateDefinition.IWithAttach<TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the region of the endpoint that will be used when the performance-based routing method
        /// TrafficRoutingMethod.PERFORMANCE is enabled on the profile.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <return>The next stage of the endpoint update.</return>
        TrafficManagerEndpoint.Update.IUpdate TrafficManagerEndpoint.Update.IWithSourceTrafficRegion.FromRegion(Region location)
        {
            return this.FromRegion(location) as TrafficManagerEndpoint.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the minimum number of endpoints to be online for the nested profile to be considered healthy.
        /// </summary>
        /// <param name="count">Number of endpoints.</param>
        /// <return>The next stage of the endpoint update.</return>
        TrafficManagerEndpoint.UpdateNestedProfileEndpoint.IUpdateNestedProfileEndpoint TrafficManagerEndpoint.Update.IWithNestedProfileConfig.WithMinimumEndpointsToEnableTraffic(int count)
        {
            return this.WithMinimumEndpointsToEnableTraffic(count) as TrafficManagerEndpoint.UpdateNestedProfileEndpoint.IUpdateNestedProfileEndpoint;
        }

        /// <summary>
        /// Specifies a nested traffic manager profile for the endpoint.
        /// </summary>
        /// <param name="nestedProfile">The nested traffic manager profile.</param>
        /// <return>The next stage of the update.</return>
        TrafficManagerEndpoint.UpdateNestedProfileEndpoint.IUpdateNestedProfileEndpoint TrafficManagerEndpoint.Update.IWithNestedProfileConfig.ToProfile(ITrafficManagerProfile nestedProfile)
        {
            return this.ToProfile(nestedProfile) as TrafficManagerEndpoint.UpdateNestedProfileEndpoint.IUpdateNestedProfileEndpoint;
        }

        /// <return>
        /// The priority of the endpoint which is used when traffic manager profile is configured with
        /// Priority traffic-routing method.
        /// </return>
        int ITrafficManagerEndpoint.RoutingPriority
        {
            get
            {
                return this.RoutingPriority();
            }
        }

        /// <return>The endpoint type.</return>
        EndpointType ITrafficManagerEndpoint.EndpointType
        {
            get
            {
                return this.EndpointType();
            }
        }

        /// <return>The monitor status of the endpoint.</return>
        EndpointMonitorStatus ITrafficManagerEndpoint.MonitorStatus
        {
            get
            {
                return this.MonitorStatus() as EndpointMonitorStatus;
            }
        }

        /// <return>
        /// The weight of the endpoint which is used when traffic manager profile is configured with
        /// Weighted traffic-routing method.
        /// </return>
        int ITrafficManagerEndpoint.RoutingWeight
        {
            get
            {
                return this.RoutingWeight();
            }
        }

        /// <return>True if the endpoint is enabled, false otherwise.</return>
        bool ITrafficManagerEndpoint.IsEnabled
        {
            get
            {
                return this.IsEnabled();
            }
        }
    }
}