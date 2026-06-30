// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Provisioning;

#nullable disable
#pragma warning disable CS1591 // Generated-style shim properties mirror AzureEndpointTrafficManagerEndpoint.

namespace Azure.Provisioning.TrafficManager;

public partial class NestedEndpointTrafficManagerEndpoint
{
    // The provisioning emitter only flattened shared EndpointProperties onto the first endpoint resource.
    // Nested endpoints use the same Bicep properties, so expose them here until the emitter handles shared models for all resources.
    public BicepValue<ResourceIdentifier> TargetResourceId
    {
        get => Properties is null ? default : Properties.TargetResourceId;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.TargetResourceId = value;
        }
    }

    public BicepValue<string> Target
    {
        get => Properties is null ? default : Properties.Target;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.Target = value;
        }
    }

    public BicepValue<TrafficManagerEndpointStatus> EndpointStatus
    {
        get => Properties is null ? default : Properties.EndpointStatus;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.EndpointStatus = value;
        }
    }

    public BicepValue<long> Weight
    {
        get => Properties is null ? default : Properties.Weight;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.Weight = value;
        }
    }

    public BicepValue<long> Priority
    {
        get => Properties is null ? default : Properties.Priority;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.Priority = value;
        }
    }

    public BicepValue<string> EndpointLocation
    {
        get => Properties is null ? default : Properties.EndpointLocation;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.EndpointLocation = value;
        }
    }

    public BicepValue<TrafficManagerEndpointMonitorStatus> EndpointMonitorStatus
    {
        get => Properties is null ? default : Properties.EndpointMonitorStatus;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.EndpointMonitorStatus = value;
        }
    }

    public BicepValue<long> MinChildEndpoints
    {
        get => Properties is null ? default : Properties.MinChildEndpoints;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.MinChildEndpoints = value;
        }
    }

    public BicepValue<long> MinChildEndpointsIPv4
    {
        get => Properties is null ? default : Properties.MinChildEndpointsIPv4;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.MinChildEndpointsIPv4 = value;
        }
    }

    public BicepValue<long> MinChildEndpointsIPv6
    {
        get => Properties is null ? default : Properties.MinChildEndpointsIPv6;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.MinChildEndpointsIPv6 = value;
        }
    }

    public BicepList<string> GeoMapping
    {
        get => Properties is null ? default : Properties.GeoMapping;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.GeoMapping = value;
        }
    }

    public BicepList<TrafficManagerEndpointSubnetInfo> Subnets
    {
        get => Properties is null ? default : Properties.Subnets;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.Subnets = value;
        }
    }

    public BicepList<TrafficManagerEndpointCustomHeaderInfo> CustomHeaders
    {
        get => Properties is null ? default : Properties.CustomHeaders;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.CustomHeaders = value;
        }
    }

    public BicepValue<TrafficManagerEndpointAlwaysServeStatus> AlwaysServe
    {
        get => Properties is null ? default : Properties.AlwaysServe;
        set
        {
            Properties ??= new EndpointProperties();
            Properties.AlwaysServe = value;
        }
    }
}
