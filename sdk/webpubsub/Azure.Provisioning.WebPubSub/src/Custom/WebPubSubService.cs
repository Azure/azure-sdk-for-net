// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Expressions;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.WebPubSub;

// Preserve the shipped WebPubSubService resource name and compatibility members not represented by the current schema.
/// <summary> A class representing a Web PubSub resource. </summary>
[CodeGenType("WebPubSub")]
public partial class WebPubSubService
{
#pragma warning disable CS0618 // These fields support properties intentionally preserved for compatibility.
    private BicepList<WebPubSubPrivateEndpointConnectionData> _privateEndpointConnections;
    private BicepList<WebPubSubSharedPrivateLinkData> _sharedPrivateLinkResources;

    /// <summary> Gets the private endpoint connection resources. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<WebPubSubPrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            Properties ??= new WebPubSubProperties();
            return Properties.PrivateEndpointConnections;
        }
    }

    /// <summary> Gets the shared private link resources. </summary>
    [CodeGenMember("SharedPrivateLinkResources")]
    public BicepList<WebPubSubSharedPrivateLink> SharedPrivateLinks
    {
        get
        {
            Properties ??= new WebPubSubProperties();
            return Properties.SharedPrivateLinkResources;
        }
    }

    /// <summary> Gets the private endpoint connection data models. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointConnectionResources instead.")]
    public BicepList<WebPubSubPrivateEndpointConnectionData> PrivateEndpointConnections
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
    public BicepList<WebPubSubSharedPrivateLinkData> SharedPrivateLinkResources
    {
        get
        {
            Initialize();
            return _sharedPrivateLinkResources;
        }
    }
#pragma warning restore CS0618

    /// <summary> Gets or sets whether client certificate authentication is enabled. </summary>
    [CodeGenMember("TlsIsClientCertEnabled")]
    public BicepValue<bool> IsClientCertEnabled
    {
        get => Properties is null ? default : Properties.TlsIsClientCertEnabled;
        set
        {
            Properties ??= new WebPubSubProperties();
            Properties.TlsIsClientCertEnabled = value;
        }
    }

    /// <summary> Gets the access keys for this Web PubSub service. </summary>
    /// <returns> The access keys for this Web PubSub service. </returns>
    public WebPubSubKeys GetKeys()
    {
        WebPubSubKeys key = new();
        ((IBicepValue)key).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
        return key;
    }

    partial void DefineAdditionalProperties()
    {
#pragma warning disable CS0618 // These properties are intentionally preserved for compatibility.
        _privateEndpointConnections = DefineListProperty<WebPubSubPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "properties", "privateEndpointConnections" }, isOutput: true);
        _sharedPrivateLinkResources = DefineListProperty<WebPubSubSharedPrivateLinkData>(nameof(SharedPrivateLinkResources), new string[] { "properties", "sharedPrivateLinkResources" }, isOutput: true);
#pragma warning restore CS0618
    }

    public static partial class ResourceVersions
    {
        /// <summary> API version "2020-05-01". </summary>
        public static readonly string V2020_05_01 = "2020-05-01";
        /// <summary> API version "2021-10-01". </summary>
        public static readonly string V2021_10_01 = "2021-10-01";
        /// <summary> API version "2023-02-01". </summary>
        public static readonly string V2023_02_01 = "2023-02-01";
        /// <summary> API version "2024-03-01". </summary>
        public static readonly string V2024_03_01 = "2024-03-01";
    }
}
