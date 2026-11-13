// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Expressions;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.SignalR;

// Preserve the shipped SignalRService resource name and compatibility members not represented by the current schema.
/// <summary> A class representing a resource. </summary>
[CodeGenType("SignalR")]
public partial class SignalRService
{
    // Preserve the old flattened data-model lists for callers compiled against previous releases.
#pragma warning disable CS0618 // These fields support properties intentionally preserved for compatibility.
    private BicepList<SignalRPrivateEndpointConnectionData> _privateEndpointConnections;
    private BicepList<SignalRSharedPrivateLinkResourceData> _sharedPrivateLinkResources;

    // Expose the generated child-resource lists under distinct names so they can coexist with the legacy lists.
    /// <summary> Gets the private endpoint connection resources. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<SignalRPrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            if (Properties is null)
            {
                Properties = new SignalRProperties();
            }
            return Properties.PrivateEndpointConnections;
        }
    }

    /// <summary> Gets the shared private link resources. </summary>
    [CodeGenMember("SharedPrivateLinkResources")]
    public BicepList<SignalRSharedPrivateLink> SharedPrivateLinks
    {
        get
        {
            if (Properties is null)
            {
                Properties = new SignalRProperties();
            }
            return Properties.SharedPrivateLinkResources;
        }
    }

    // Preserve the previously shipped data-model properties as hidden obsolete compatibility APIs.
    /// <summary> Gets the private endpoint connection data models. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointConnectionResources instead.")]
    public BicepList<SignalRPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _privateEndpointConnections;
        }
    }

    /// <summary> Gets the shared private link resource data models. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use SharedPrivateLinks instead.")]
    public BicepList<SignalRSharedPrivateLinkResourceData> SharedPrivateLinkResources
    {
        get
        {
            Initialize();
            return _sharedPrivateLinkResources;
        }
    }
#pragma warning restore CS0618

    // Preserve the flattened property name while wiring it to the generated nested TLS member.
    /// <summary> Gets or sets whether client certificate authentication is enabled. </summary>
    [CodeGenMember("TlsIsClientCertEnabled")]
    public BicepValue<bool> IsClientCertEnabled
    {
        get => Properties is null ? default! : Properties.TlsIsClientCertEnabled;
        set
        {
            if (Properties is null)
            {
                Properties = new SignalRProperties();
            }
            Properties.TlsIsClientCertEnabled = value;
        }
    }

    // The provisioning emitter does not generate the listKeys expression used by this convenience API.
    /// <summary> Gets the access keys for this SignalR service. </summary>
    /// <returns> The access keys for this SignalR service. </returns>
    public SignalRKeys GetKeys()
    {
        SignalRKeys key = new();
        ((IBicepValue)key).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
        return key;
    }

    // Register the legacy model paths because the generated child-resource properties no longer represent them.
    partial void DefineAdditionalProperties()
    {
#pragma warning disable CS0618 // These properties are intentionally preserved for compatibility.
        _privateEndpointConnections = DefineListProperty<SignalRPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "properties", "privateEndpointConnections" }, isOutput: true);
        _sharedPrivateLinkResources = DefineListProperty<SignalRSharedPrivateLinkResourceData>(nameof(SharedPrivateLinkResources), new string[] { "properties", "sharedPrivateLinkResources" }, isOutput: true);
#pragma warning restore CS0618
    }

    public static partial class ResourceVersions
    {
        /// <summary> API version "2018-10-01". </summary>
        public static readonly string V2018_10_01 = "2018-10-01";
        /// <summary> API version "2020-05-01". </summary>
        public static readonly string V2020_05_01 = "2020-05-01";
        /// <summary> API version "2021-10-01". </summary>
        public static readonly string V2021_10_01 = "2021-10-01";
        /// <summary> API version "2022-02-01". </summary>
        public static readonly string V2022_02_01 = "2022-02-01";
        /// <summary> API version "2023-02-01". </summary>
        public static readonly string V2023_02_01 = "2023-02-01";
        /// <summary> API version "2024-03-01". </summary>
        public static readonly string V2024_03_01 = "2024-03-01";
    }
}
