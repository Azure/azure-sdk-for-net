// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#nullable enable

using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Sql;

/// <summary>
/// SQL server communication link.
/// This resource is only supported by API version 2014-04-01. Later API
/// versions no longer contain this resource.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class SqlServerCommunicationLink : ProvisionableResource
{
    private BicepValue<string>? _name;
    private BicepValue<string>? _partnerServer;
    private BicepValue<ResourceIdentifier>? _id;
    private BicepValue<string>? _kind;
    private BicepValue<AzureLocation>? _location;
    private BicepValue<string>? _state;
    private SystemData? _systemData;
    private ResourceReference<SqlServer>? _parent;

    /// <summary>
    /// The name of the server communication link.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }

    /// <summary>
    /// The name of the partner server.
    /// </summary>
    public BicepValue<string> PartnerServer
    {
        get { Initialize(); return _partnerServer!; }
        set { Initialize(); _partnerServer!.Assign(value); }
    }

    /// <summary>
    /// Gets the resource ID.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }

    /// <summary>
    /// Communication link kind. This property is used for Azure portal metadata.
    /// </summary>
    public BicepValue<string> Kind
    {
        get { Initialize(); return _kind!; }
    }

    /// <summary>
    /// Communication link location.
    /// </summary>
    public BicepValue<AzureLocation> Location
    {
        get { Initialize(); return _location!; }
    }

    /// <summary>
    /// The state.
    /// </summary>
    public BicepValue<string> State
    {
        get { Initialize(); return _state!; }
    }

    /// <summary>
    /// Gets the system metadata.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }

    /// <summary>
    /// Gets or sets a reference to the parent SQL server.
    /// </summary>
    public SqlServer? Parent
    {
        get { Initialize(); return _parent!.Value; }
        set { Initialize(); _parent!.Value = value; }
    }

    /// <summary>
    /// Creates a new <see cref="SqlServerCommunicationLink"/>.
    /// </summary>
    /// <param name="bicepIdentifier">The Bicep identifier name.</param>
    /// <param name="resourceVersion">The resource API version.</param>
    public SqlServerCommunicationLink(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.Sql/servers/communicationLinks", resourceVersion ?? "2014-04-01")
    {
    }

    /// <summary>
    /// Defines the provisionable properties of <see cref="SqlServerCommunicationLink"/>.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isRequired: true);
        _partnerServer = DefineProperty<string>(nameof(PartnerServer), new string[] { "properties", "partnerServer" });
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
        _kind = DefineProperty<string>(nameof(Kind), new string[] { "kind" }, isOutput: true);
        _location = DefineProperty<AzureLocation>(nameof(Location), new string[] { "location" }, isOutput: true);
        _state = DefineProperty<string>(nameof(State), new string[] { "properties", "state" }, isOutput: true);
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        _parent = DefineResource<SqlServer>(nameof(Parent), new string[] { "parent" }, isRequired: true);
    }

    /// <summary>
    /// Creates a reference to an existing <see cref="SqlServerCommunicationLink"/>.
    /// </summary>
    /// <param name="bicepIdentifier">The Bicep identifier name.</param>
    /// <param name="resourceVersion">The resource API version.</param>
    /// <returns>The existing resource.</returns>
    public static SqlServerCommunicationLink FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };

    /// <summary>
    /// Supported resource versions.
    /// </summary>
    public static partial class ResourceVersions
    {
        /// <summary> API version "2014-01-01". </summary>
        public static readonly string V2014_01_01 = "2014-01-01";

        /// <summary> API version "2014-04-01". </summary>
        public static readonly string V2014_04_01 = "2014-04-01";
    }
}
