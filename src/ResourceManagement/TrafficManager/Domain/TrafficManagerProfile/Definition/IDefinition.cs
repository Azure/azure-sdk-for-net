// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.TrafficManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition;

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via  WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate>,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithMonitoringConfiguration,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTtl,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithProfileStatus,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to disable the profile.
    /// </summary>
    public interface IWithProfileStatus 
    {
        /// <summary>
        /// Specify that the profile needs to be disabled.
        /// Disabling the profile will disables traffic to all endpoints in the profile.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithProfileStatusDisabled();
    }

    /// <summary>
    /// The entirety of the traffic manager profile definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IBlank,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithLeafDomainLabel,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethod,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the traffic routing method
    /// for the profile.
    /// </summary>
    public interface IWithTrafficRoutingMethod  : Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethodBeta
    {
        /// <summary>
        /// Specifies that end user traffic should be distributed to the endpoints based on the weight assigned
        /// to the endpoint.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithWeightBasedRouting();

        /// <summary>
        /// Specifies that end user traffic should be routed to the endpoint based on its priority
        /// i.e. use the endpoint with highest priority and if it is not available fallback to next highest
        /// priority endpoint.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithPriorityBasedRouting();

        /// <summary>
        /// Specify the traffic routing method for the profile.
        /// </summary>
        /// <param name="routingMethod">The traffic routing method for the profile.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithTrafficRoutingMethod(TrafficRoutingMethod routingMethod);

        /// <summary>
        /// Specifies that end user traffic should be routed based on the geographic location of the endpoint
        /// close to user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithPerformanceBasedRouting();
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithHttpMonitoring();

        /// <summary>
        /// Specify the HTTP monitoring for the endpoints that checks for HTTP 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithHttpMonitoring(int port, string path);

        /// <summary>
        /// Specify to use HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the path '/'
        /// at regular intervals, using port 443.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithHttpsMonitoring();

        /// <summary>
        /// Specify the HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithHttpsMonitoring(int port, string path);
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the resource group.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroupAndRegion<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithLeafDomainLabel>
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the relative DNS name.
    /// </summary>
    public interface IWithLeafDomainLabel 
    {
        /// <summary>
        /// Specify the relative DNS name of the profile.
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsLabel">The relative DNS name of the profile.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethod WithLeafDomainLabel(string dnsLabel);
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
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithTimeToLive(int ttlInSeconds);
    }

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
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.INestedProfileTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate> DefineNestedTargetEndpoint(string name);

        /// <summary>
        /// Specifies definition of an external endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.IExternalTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate> DefineExternalTargetEndpoint(string name);

        /// <summary>
        /// Specifies definition of an Azure endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.IAzureTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate> DefineAzureTargetEndpoint(string name);
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the traffic routing method
    /// for the profile.
    /// </summary>
    public interface IWithTrafficRoutingMethodBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that end user traffic should be routed to the endpoint that is designated to serve users
        /// geographic region.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithGeographicBasedRouting();
    }
}