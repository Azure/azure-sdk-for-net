// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

internal partial class DomainProperties
{
    private BicepList<EventGridPrivateEndpointConnectionData> _customPrivateEndpointConnections;

    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _customPrivateEndpointConnections;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _customPrivateEndpointConnections = DefineListProperty<EventGridPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), ["privateEndpointConnections"], isOutput: true);
    }
}

internal partial class NamespaceProperties
{
    private BicepList<EventGridPrivateEndpointConnectionData> _customPrivateEndpointConnections;

    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _customPrivateEndpointConnections;
        }
        set
        {
            Initialize();
            _customPrivateEndpointConnections.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _customPrivateEndpointConnections = DefineListProperty<EventGridPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), ["privateEndpointConnections"]);
    }
}

internal partial class PartnerNamespaceProperties
{
    private BicepList<EventGridPrivateEndpointConnectionData> _customPrivateEndpointConnections;

    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _customPrivateEndpointConnections;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _customPrivateEndpointConnections = DefineListProperty<EventGridPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), ["privateEndpointConnections"], isOutput: true);
    }
}

public partial class EventGridDomain
{
    /// <summary> Gets the private endpoint connections. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections =>
        Properties is null ? default : Properties.PrivateEndpointConnections;
}

public partial class EventGridNamespace
{
    /// <summary> Gets or sets the private endpoint connections. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get => Properties is null ? default : Properties.PrivateEndpointConnections;
        set
        {
            if (Properties is null)
            {
                Properties = new NamespaceProperties();
            }
            Properties.PrivateEndpointConnections = value;
        }
    }
}

public partial class PartnerNamespace
{
    /// <summary> Gets the private endpoint connections. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections =>
        Properties is null ? default : Properties.PrivateEndpointConnections;
}

public partial class EventGridTopic
{
    private BicepList<EventGridPrivateEndpointConnectionData> _customPrivateEndpointConnections;

    /// <summary> Gets the private endpoint connections. </summary>
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _customPrivateEndpointConnections;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _customPrivateEndpointConnections = DefineListProperty<EventGridPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), ["properties", "privateEndpointConnections"], isOutput: true);
    }
}
