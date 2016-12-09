// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerProfile.Update
{
    using Microsoft.Azure.Management.Trafficmanager.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.UpdateDefinition;
    using Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.UpdateAzureEndpoint;
    using Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.UpdateExternalEndpoint;
    using Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.UpdateNestedProfileEndpoint;

    /// <summary>
    /// The stage of the traffic manager profile update allowing to specify the traffic routing method
    /// for the profile.
    /// </summary>
    public interface IWithTrafficRoutingMethod 
    {
        /// <summary>
        /// Specify that end user traffic should be distributed to the endpoints based on the weight assigned
        /// to the endpoint.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithWeightBasedRouting();

        /// <summary>
        /// Specify that end user traffic should be routed to the endpoint based on its priority
        /// i.e. use the endpoint with highest priority and if it is not available fallback to next highest
        /// priority endpoint.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithPriorityBasedRouting();

        /// <summary>
        /// Specify the traffic routing method for the profile.
        /// </summary>
        /// <param name="routingMethod">The traffic routing method for the profile.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithTrafficRoutingMethod(TrafficRoutingMethod routingMethod);

        /// <summary>
        /// Specify that end user traffic should be routed based on the geographic location of the endpoint
        /// close to user.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithPerformanceBasedRouting();
    }

    /// <summary>
    /// The stage of the traffic manager profile update allowing to specify the DNS TTL.
    /// </summary>
    public interface IWithTtl 
    {
        /// <summary>
        /// Specify the DNS TTL in seconds.
        /// </summary>
        /// <param name="ttlInSeconds">DNS TTL in seconds.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithTimeToLive(int ttlInSeconds);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// <p>
    /// Call Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Trafficmanager.Fluent.ITrafficManagerProfile>,
        IWithTrafficRoutingMethod,
        IWithMonitoringConfiguration,
        IWithEndpoint,
        IWithTtl,
        IWithProfileStatus,
        IUpdateWithTags<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile update allowing to specify endpoints.
    /// </summary>
    public interface IWithEndpoint 
    {
        /// <summary>
        /// Begins the description of an update of an existing Azure endpoint in this profile.
        /// </summary>
        /// <param name="name">The name of the Azure endpoint.</param>
        /// <return>The stage representing updating configuration for the Azure endpoint.</return>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.UpdateAzureEndpoint.IUpdateAzureEndpoint UpdateAzureTargetEndpoint(string name);

        /// <summary>
        /// Removes an endpoint in the profile.
        /// </summary>
        /// <param name="name">The name of the endpoint.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithoutEndpoint(string name);

        /// <summary>
        /// Specifies definition of an nested profile endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.UpdateDefinition.INestedProfileTargetEndpointBlank<IUpdate> DefineNestedTargetEndpoint(string name);

        /// <summary>
        /// Specifies definition of an external endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.UpdateDefinition.IExternalTargetEndpointBlank<IUpdate> DefineExternalTargetEndpoint(string name);

        /// <summary>
        /// Begins the description of an update of an existing external endpoint in this profile.
        /// </summary>
        /// <param name="name">The name of the external endpoint.</param>
        /// <return>The stage representing updating configuration for the external endpoint.</return>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.UpdateExternalEndpoint.IUpdateExternalEndpoint UpdateExternalTargetEndpoint(string name);

        /// <summary>
        /// Specifies definition of an Azure endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.UpdateDefinition.IAzureTargetEndpointBlank<IUpdate> DefineAzureTargetEndpoint(string name);

        /// <summary>
        /// Begins the description of an update of an existing nested traffic manager profile endpoint
        /// in this profile.
        /// </summary>
        /// <param name="name">The name of the nested profile endpoint.</param>
        /// <return>The stage representing updating configuration for the nested traffic manager profile endpoint.</return>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.UpdateNestedProfileEndpoint.IUpdateNestedProfileEndpoint UpdateNestedProfileTargetEndpoint(string name);
    }

    /// <summary>
    /// The stage of the traffic manager profile update allowing to disable or enable the profile.
    /// </summary>
    public interface IWithProfileStatus 
    {
        /// <summary>
        /// Specify that the profile needs to be disabled.
        /// <p>
        /// Disabling the profile will disables traffic to all endpoints in the profile.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithProfileStatusDisabled();

        /// <summary>
        /// Specify that the profile needs to be enabled.
        /// <p>
        /// Enabling the profile will enables traffic to all endpoints in the profile.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithProfileStatusEnabled();
    }

    /// <summary>
    /// The stage of the traffic manager profile update allowing to specify the endpoint monitoring configuration.
    /// </summary>
    public interface IWithMonitoringConfiguration 
    {
        /// <summary>
        /// Specify to use HTTP monitoring for the endpoints that checks for HTTP 200 response from the path '/'
        /// at regular intervals, using port 80.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithHttpMonitoring();

        /// <summary>
        /// Specify the HTTP monitoring for the endpoints that checks for HTTP 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithHttpMonitoring(int port, string path);

        /// <summary>
        /// Specify to use HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the path '/'
        /// at regular intervals, using port 443.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithHttpsMonitoring();

        /// <summary>
        /// Specify the HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        IUpdate WithHttpsMonitoring(int port, string path);
    }
}