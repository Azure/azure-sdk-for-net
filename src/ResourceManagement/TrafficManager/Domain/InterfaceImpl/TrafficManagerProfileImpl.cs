// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateAzureEndpoint;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateExternalEndpoint;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateNestedProfileEndpoint;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update;
    using Microsoft.Azure.Management.TrafficManager.Fluent.Models;
    using System.Collections.Generic;

    internal partial class TrafficManagerProfileImpl 
    {
        /// <summary>
        /// Specify the DNS TTL in seconds.
        /// </summary>
        /// <param name="ttlInSeconds">DNS TTL in seconds.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithTtl.WithTimeToLive(int ttlInSeconds)
        {
            return this.WithTimeToLive(ttlInSeconds) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specify the DNS TTL in seconds.
        /// </summary>
        /// <param name="ttlInSeconds">DNS TTL in seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTtl.WithTimeToLive(int ttlInSeconds)
        {
            return this.WithTimeToLive(ttlInSeconds) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile;
        }

        /// <summary>
        /// Begins the definition of an Azure endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition.IAzureTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate> Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithEndpoint.DefineAzureTargetEndpoint(string name)
        {
            return this.DefineAzureTargetEndpoint(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition.IAzureTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the definition of a nested profile endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition.INestedProfileTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate> Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithEndpoint.DefineNestedTargetEndpoint(string name)
        {
            return this.DefineNestedTargetEndpoint(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition.INestedProfileTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update of an existing nested traffic manager profile endpoint
        /// in this profile.
        /// </summary>
        /// <param name="name">The name of the nested profile endpoint.</param>
        /// <return>The stage representing updating configuration for the nested traffic manager profile endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateNestedProfileEndpoint.IUpdateNestedProfileEndpoint Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithEndpoint.UpdateNestedProfileTargetEndpoint(string name)
        {
            return this.UpdateNestedProfileTargetEndpoint(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateNestedProfileEndpoint.IUpdateNestedProfileEndpoint;
        }

        /// <summary>
        /// Begins the description of an update of an existing external endpoint in this profile.
        /// </summary>
        /// <param name="name">The name of the external endpoint.</param>
        /// <return>The stage representing updating configuration for the external endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateExternalEndpoint.IUpdateExternalEndpoint Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithEndpoint.UpdateExternalTargetEndpoint(string name)
        {
            return this.UpdateExternalTargetEndpoint(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateExternalEndpoint.IUpdateExternalEndpoint;
        }

        /// <summary>
        /// Begins the description of an update of an existing Azure endpoint in this profile.
        /// </summary>
        /// <param name="name">The name of the Azure endpoint.</param>
        /// <return>The stage representing updating configuration for the Azure endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateAzureEndpoint.IUpdateAzureEndpoint Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithEndpoint.UpdateAzureTargetEndpoint(string name)
        {
            return this.UpdateAzureTargetEndpoint(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateAzureEndpoint.IUpdateAzureEndpoint;
        }

        /// <summary>
        /// Begins the definition of an external endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition.IExternalTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate> Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithEndpoint.DefineExternalTargetEndpoint(string name)
        {
            return this.DefineExternalTargetEndpoint(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateDefinition.IExternalTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Removes an endpoint in the profile.
        /// </summary>
        /// <param name="name">The name of the endpoint.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithEndpoint.WithoutEndpoint(string name)
        {
            return this.WithoutEndpoint(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specifies definition of an Azure endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.IAzureTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate> Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint.DefineAzureTargetEndpoint(string name)
        {
            return this.DefineAzureTargetEndpoint(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.IAzureTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies definition of an nested profile endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.INestedProfileTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate> Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint.DefineNestedTargetEndpoint(string name)
        {
            return this.DefineNestedTargetEndpoint(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.INestedProfileTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies definition of an external endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.IExternalTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate> Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint.DefineExternalTargetEndpoint(string name)
        {
            return this.DefineExternalTargetEndpoint(name) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.IExternalTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specify that the profile needs to be disabled.
        /// Disabling the profile will disables traffic to all endpoints in the profile.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithProfileStatus.WithProfileStatusDisabled()
        {
            return this.WithProfileStatusDisabled() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specify that the profile needs to be enabled.
        /// Enabling the profile will enables traffic to all endpoints in the profile.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithProfileStatus.WithProfileStatusEnabled()
        {
            return this.WithProfileStatusEnabled() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specify that the profile needs to be disabled.
        /// Disabling the profile will disables traffic to all endpoints in the profile.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithProfileStatus.WithProfileStatusDisabled()
        {
            return this.WithProfileStatusDisabled() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate;
        }

        /// <summary>
        /// Specify the relative DNS name of the profile.
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsLabel">The relative DNS name of the profile.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethod Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithLeafDomainLabel.WithLeafDomainLabel(string dnsLabel)
        {
            return this.WithLeafDomainLabel(dnsLabel) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethod;
        }

        /// <summary>
        /// Gets Azure endpoints in the traffic manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerAzureEndpoint> Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.AzureEndpoints
        {
            get
            {
                return this.AzureEndpoints() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerAzureEndpoint>;
            }
        }

        /// <summary>
        /// Gets the relative DNS name of the traffic manager profile.
        /// </summary>
        string Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.DnsLabel
        {
            get
            {
                return this.DnsLabel();
            }
        }

        /// <summary>
        /// Gets the DNS Time-To-Live (TTL), in seconds.
        /// </summary>
        long Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.TimeToLive
        {
            get
            {
                return this.TimeToLive();
            }
        }

        /// <summary>
        /// Gets the port that is monitored to check the health of traffic manager profile endpoints.
        /// </summary>
        long Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.MonitoringPort
        {
            get
            {
                return this.MonitoringPort();
            }
        }

        /// <summary>
        /// Gets the path that is monitored to check the health of traffic manager profile endpoints.
        /// </summary>
        string Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.MonitoringPath
        {
            get
            {
                return this.MonitoringPath();
            }
        }

        /// <summary>
        /// Gets external endpoints in the traffic manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerExternalEndpoint> Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.ExternalEndpoints
        {
            get
            {
                return this.ExternalEndpoints() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerExternalEndpoint>;
            }
        }

        /// <summary>
        /// Gets profile monitor status which is combination of the endpoint monitor status values for all endpoints in
        /// the profile, and the configured profile status.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.ProfileMonitorStatus Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.MonitorStatus
        {
            get
            {
                return this.MonitorStatus() as Microsoft.Azure.Management.TrafficManager.Fluent.ProfileMonitorStatus;
            }
        }

        /// <summary>
        /// Gets the routing method used to route traffic to traffic manager profile endpoints.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficRoutingMethod Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.TrafficRoutingMethod
        {
            get
            {
                return this.TrafficRoutingMethod();
            }
        }

        /// <summary>
        /// Gets nested traffic manager profile endpoints in this traffic manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerNestedProfileEndpoint> Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.NestedProfileEndpoints
        {
            get
            {
                return this.NestedProfileEndpoints() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerNestedProfileEndpoint>;
            }
        }

        /// <summary>
        /// Gets true if the traffic manager profile is enabled, false if enabled.
        /// </summary>
        bool Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.IsEnabled
        {
            get
            {
                return this.IsEnabled();
            }
        }

        /// <summary>
        /// Gets fully qualified domain name (FQDN) of the traffic manager profile.
        /// </summary>
        string Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        /// <summary>
        /// Specifies that end user traffic should be distributed to the endpoints based on the weight assigned
        /// to the endpoint.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithTrafficRoutingMethod.WithWeightBasedRouting()
        {
            return this.WithWeightBasedRouting() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that end user traffic should be routed based on the geographic location of the endpoint
        /// close to user.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithTrafficRoutingMethod.WithPerformanceBasedRouting()
        {
            return this.WithPerformanceBasedRouting() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that end user traffic should be routed to the endpoint based on its priority
        /// i.e. use the endpoint with highest priority and if it is not available fallback to next highest
        /// priority endpoint.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithTrafficRoutingMethod.WithPriorityBasedRouting()
        {
            return this.WithPriorityBasedRouting() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that end user traffic should be routed to the endpoint that is designated to serve users
        /// geographic region.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithTrafficRoutingMethodBeta.WithGeographicBasedRouting()
        {
            return this.WithGeographicBasedRouting() as TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the traffic routing method for the profile.
        /// </summary>
        /// <param name="routingMethod">The traffic routing method for the profile.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithTrafficRoutingMethod.WithTrafficRoutingMethod(TrafficRoutingMethod routingMethod)
        {
            return this.WithTrafficRoutingMethod(routingMethod) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that end user traffic should be distributed to the endpoints based on the weight assigned
        /// to the endpoint.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethod.WithWeightBasedRouting()
        {
            return this.WithWeightBasedRouting() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint;
        }

        /// <summary>
        /// Specifies that end user traffic should be routed based on the geographic location of the endpoint
        /// close to user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethod.WithPerformanceBasedRouting()
        {
            return this.WithPerformanceBasedRouting() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint;
        }

        /// <summary>
        /// Specifies that end user traffic should be routed to the endpoint based on its priority
        /// i.e. use the endpoint with highest priority and if it is not available fallback to next highest
        /// priority endpoint.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethod.WithPriorityBasedRouting()
        {
            return this.WithPriorityBasedRouting() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint;
        }

        /// <summary>
        /// Specifies that end user traffic should be routed to the endpoint that is designated to serve users
        /// geographic region.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethodBeta.WithGeographicBasedRouting()
        {
            return this.WithGeographicBasedRouting() as TrafficManagerProfile.Definition.IWithEndpoint;
        }

        /// <summary>
        /// Specify the traffic routing method for the profile.
        /// </summary>
        /// <param name="routingMethod">The traffic routing method for the profile.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethod.WithTrafficRoutingMethod(TrafficRoutingMethod routingMethod)
        {
            return this.WithTrafficRoutingMethod(routingMethod) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint;
        }

        /// <summary>
        /// Specify to use HTTP monitoring for the endpoints that checks for HTTP 200 response from the path '/'
        /// at regular intervals, using port 80.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithMonitoringConfiguration.WithHttpMonitoring()
        {
            return this.WithHttpMonitoring() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specify the HTTP monitoring for the endpoints that checks for HTTP 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithMonitoringConfiguration.WithHttpMonitoring(int port, string path)
        {
            return this.WithHttpMonitoring(port, path) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specify to use HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the path '/'
        /// at regular intervals, using port 443.
        /// </summary>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithMonitoringConfiguration.WithHttpsMonitoring()
        {
            return this.WithHttpsMonitoring() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specify the HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the traffic manager profile update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IWithMonitoringConfiguration.WithHttpsMonitoring(int port, string path)
        {
            return this.WithHttpsMonitoring(port, path) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update.IUpdate;
        }

        /// <summary>
        /// Specify to use HTTP monitoring for the endpoints that checks for HTTP 200 response from the path '/'
        /// at regular intervals, using port 80.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithMonitoringConfiguration.WithHttpMonitoring()
        {
            return this.WithHttpMonitoring() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate;
        }

        /// <summary>
        /// Specify the HTTP monitoring for the endpoints that checks for HTTP 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithMonitoringConfiguration.WithHttpMonitoring(int port, string path)
        {
            return this.WithHttpMonitoring(port, path) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate;
        }

        /// <summary>
        /// Specify to use HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the path '/'
        /// at regular intervals, using port 443.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithMonitoringConfiguration.WithHttpsMonitoring()
        {
            return this.WithHttpsMonitoring() as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate;
        }

        /// <summary>
        /// Specify the HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithMonitoringConfiguration.WithHttpsMonitoring(int port, string path)
        {
            return this.WithHttpsMonitoring(port, path) as Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate;
        }
    }
}