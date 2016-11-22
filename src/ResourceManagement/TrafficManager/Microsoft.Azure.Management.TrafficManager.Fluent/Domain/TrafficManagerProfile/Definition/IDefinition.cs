// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerProfile.Definition
{
    using Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Trafficmanager.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify endpoint.
    /// </summary>
    public interface IWithEndpoint 
    {
        /// <summary>
        /// Specifies definition of an nested profile endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.Definition.INestedProfileTargetEndpointBlank<IWithCreate> DefineNestedTargetEndpoint(string name);

        /// <summary>
        /// Specifies definition of an external endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.Definition.IExternalTargetEndpointBlank<IWithCreate> DefineExternalTargetEndpoint(string name);

        /// <summary>
        /// Specifies definition of an Azure endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TrafficManagerEndpoint.Definition.IAzureTargetEndpointBlank<IWithCreate> DefineAzureTargetEndpoint(string name);
    }

    /// <summary>
    /// The entirety of the traffic manager profile definition.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithLeafDomainLabel,
        IWithTrafficRoutingMethod,
        IWithCreate
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the DNS TTL.
    /// </summary>
    public interface IWithTtl 
    {
        /// <summary>
        /// Specify the DNS TTL in seconds.
        /// </summary>
        /// <param name="ttlInSeconds">DNS TTL in seconds.</param>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithCreate WithTimeToLive(int ttlInSeconds);
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the relative DNS name.
    /// </summary>
    public interface IWithLeafDomainLabel 
    {
        /// <summary>
        /// Specify the relative DNS name of the profile.
        /// <p>
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsLabel">The relative DNS name of the profile.</param>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithTrafficRoutingMethod WithLeafDomainLabel(string dnsLabel);
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to disable the profile.
    /// </summary>
    public interface IWithProfileStatus 
    {
        /// <summary>
        /// Specify that the profile needs to be disabled.
        /// <p>
        /// Disabling the profile will disables traffic to all endpoints in the profile.
        /// </summary>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithCreate WithProfileStatusDisabled();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Trafficmanager.Fluent.ITrafficManagerProfile>,
        IDefinitionWithTags<IWithCreate>,
        IWithMonitoringConfiguration,
        IWithTtl,
        IWithProfileStatus,
        IWithEndpoint
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the endpoint monitoring configuration.
    /// </summary>
    public interface IWithMonitoringConfiguration 
    {
        /// <summary>
        /// Specify to use HTTP monitoring for the endpoints that checks for HTTP 200 response from the path '/'
        /// at regular intervals, using port 80.
        /// </summary>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithCreate WithHttpMonitoring();

        /// <summary>
        /// Specify the HTTP monitoring for the endpoints that checks for HTTP 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithCreate WithHttpMonitoring(int port, string path);

        /// <summary>
        /// Specify to use HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the path '/'
        /// at regular intervals, using port 443.
        /// </summary>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithCreate WithHttpsMonitoring();

        /// <summary>
        /// Specify the HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithCreate WithHttpsMonitoring(int port, string path);
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the resource group.
    /// </summary>
    public interface IBlank  :
        IWithGroupAndRegion<IWithLeafDomainLabel>
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the traffic routing method
    /// for the profile.
    /// </summary>
    public interface IWithTrafficRoutingMethod 
    {
        /// <summary>
        /// Specify that end user traffic should be distributed to the endpoints based on the weight assigned
        /// to the endpoint.
        /// </summary>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithEndpoint WithWeightBasedRouting();

        /// <summary>
        /// Specify that end user traffic should be routed to the endpoint based on its priority
        /// i.e. use the endpoint with highest priority and if it is not available fallback to next highest
        /// priority endpoint.
        /// </summary>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithEndpoint WithPriorityBasedRouting();

        /// <summary>
        /// Specify the traffic routing method for the profile.
        /// </summary>
        /// <param name="routingMethod">The traffic routing method for the profile.</param>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithEndpoint WithTrafficRoutingMethod(TrafficRoutingMethod routingMethod);

        /// <summary>
        /// Specify that end user traffic should be routed based on the geographic location of the endpoint
        /// close to user.
        /// </summary>
        /// <return>The next stage of the traffic manager profile definition.</return>
        IWithEndpoint WithPerformanceBasedRouting();
    }
}