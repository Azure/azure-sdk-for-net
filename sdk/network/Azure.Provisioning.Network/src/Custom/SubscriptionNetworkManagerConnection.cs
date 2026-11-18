// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Network;

/// <summary> The legacy subscription Network Manager connection resource. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is deprecated and it will be removed in a future version. Please use NetworkManagerConnection instead.")]
public partial class SubscriptionNetworkManagerConnection : ProvisionableResource
{
    private BicepValue<string> _name;
    private BicepValue<string> _description;
    private BicepValue<ResourceIdentifier> _networkManagerId;
    private BicepValue<ScopeConnectionState> _connectionState;
    private BicepValue<ETag> _eTag;
    private BicepValue<ResourceIdentifier> _id;
    private SystemData _systemData;

    /// <summary> Name for the network manager connection. </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }

    /// <summary> A description of the network manager connection. </summary>
    public BicepValue<string> Description
    {
        get { Initialize(); return _description; }
        set { Initialize(); _description.Assign(value); }
    }

    /// <summary> Network Manager Id. </summary>
    public BicepValue<ResourceIdentifier> NetworkManagerId
    {
        get { Initialize(); return _networkManagerId; }
        set { Initialize(); _networkManagerId.Assign(value); }
    }

    /// <summary> Connection state. </summary>
    public BicepValue<ScopeConnectionState> ConnectionState
    {
        get { Initialize(); return _connectionState; }
    }

    /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
    public BicepValue<ETag> ETag
    {
        get { Initialize(); return _eTag; }
    }

    /// <summary> Gets the Id. </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id; }
    }

    /// <summary> Gets the SystemData. </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData; }
    }

    /// <summary> Creates a new SubscriptionNetworkManagerConnection. </summary>
    /// <param name="bicepIdentifier"> The bicep identifier name. </param>
    /// <param name="resourceVersion"> The resource API version. </param>
    public SubscriptionNetworkManagerConnection(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, "Microsoft.Network/networkManagerConnections", resourceVersion ?? "2025-05-01")
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isRequired: true);
        _description = DefineProperty<string>(nameof(Description), new string[] { "properties", "description" });
        _networkManagerId = DefineProperty<ResourceIdentifier>(nameof(NetworkManagerId), new string[] { "properties", "networkManagerId" });
        _connectionState = DefineProperty<ScopeConnectionState>(nameof(ConnectionState), new string[] { "properties", "connectionState" }, isOutput: true);
        _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "etag" }, isOutput: true);
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
    }

    /// <summary> Creates a reference to an existing SubscriptionNetworkManagerConnection. </summary>
    /// <param name="bicepIdentifier"> The bicep identifier name. </param>
    /// <param name="resourceVersion"> The resource API version. </param>
    /// <returns> The existing SubscriptionNetworkManagerConnection resource. </returns>
    public static SubscriptionNetworkManagerConnection FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        SubscriptionNetworkManagerConnection result = new SubscriptionNetworkManagerConnection(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }

    /// <summary> Supported SubscriptionNetworkManagerConnection resource versions. </summary>
    public static partial class ResourceVersions
    {
        /// <summary> API version "2025-05-01". </summary>
        public static readonly string V2025_05_01 = "2025-05-01";
    }
}
