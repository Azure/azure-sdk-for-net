// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// MongoCluster.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class MongoCluster : ProvisionableResource
{
    /// <summary>
    /// The name of the mongo cluster.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }
    private BicepValue<string>? _name;

    /// <summary>
    /// Gets or sets the Location.
    /// </summary>
    public BicepValue<AzureLocation> Location
    {
        get { Initialize(); return _location!; }
        set { Initialize(); _location!.Assign(value); }
    }
    private BicepValue<AzureLocation>? _location;

    /// <summary>
    /// The administrator&apos;s login for the mongo cluster.
    /// </summary>
    public BicepValue<string> AdministratorLogin
    {
        get { Initialize(); return _administratorLogin!; }
        set { Initialize(); _administratorLogin!.Assign(value); }
    }
    private BicepValue<string>? _administratorLogin;

    /// <summary>
    /// The password of the administrator login.
    /// </summary>
    public BicepValue<string> AdministratorLoginPassword
    {
        get { Initialize(); return _administratorLoginPassword!; }
        set { Initialize(); _administratorLoginPassword!.Assign(value); }
    }
    private BicepValue<string>? _administratorLoginPassword;

    /// <summary>
    /// The mode to create a mongo cluster.
    /// </summary>
    public BicepValue<CosmosDBAccountCreateMode> CreateMode
    {
        get { Initialize(); return _createMode!; }
        set { Initialize(); _createMode!.Assign(value); }
    }
    private BicepValue<CosmosDBAccountCreateMode>? _createMode;

    /// <summary>
    /// The list of node group specs in the cluster.
    /// </summary>
    public BicepList<NodeGroupSpec> NodeGroupSpecs
    {
        get { Initialize(); return _nodeGroupSpecs!; }
        set { Initialize(); _nodeGroupSpecs!.Assign(value); }
    }
    private BicepList<NodeGroupSpec>? _nodeGroupSpecs;

    /// <summary>
    /// Parameters used for restore operations.
    /// </summary>
    public MongoClusterRestoreParameters RestoreParameters
    {
        get { Initialize(); return _restoreParameters!; }
        set { Initialize(); AssignOrReplace(ref _restoreParameters, value); }
    }
    private MongoClusterRestoreParameters? _restoreParameters;

    /// <summary>
    /// The Mongo DB server version. Defaults to the latest available version
    /// if not specified.
    /// </summary>
    public BicepValue<string> ServerVersion
    {
        get { Initialize(); return _serverVersion!; }
        set { Initialize(); _serverVersion!.Assign(value); }
    }
    private BicepValue<string>? _serverVersion;

    /// <summary>
    /// Gets or sets the Tags.
    /// </summary>
    public BicepDictionary<string> Tags
    {
        get { Initialize(); return _tags!; }
        set { Initialize(); _tags!.Assign(value); }
    }
    private BicepDictionary<string>? _tags;

    /// <summary>
    /// A status of the mongo cluster.
    /// </summary>
    public BicepValue<MongoClusterStatus> ClusterStatus
    {
        get { Initialize(); return _clusterStatus!; }
    }
    private BicepValue<MongoClusterStatus>? _clusterStatus;

    /// <summary>
    /// The default mongo connection string for the cluster.
    /// </summary>
    public BicepValue<string> ConnectionString
    {
        get { Initialize(); return _connectionString!; }
    }
    private BicepValue<string>? _connectionString;

    /// <summary>
    /// Earliest restore timestamp in UTC ISO8601 format.
    /// </summary>
    public BicepValue<string> EarliestRestoreTime
    {
        get { Initialize(); return _earliestRestoreTime!; }
    }
    private BicepValue<string>? _earliestRestoreTime;

    /// <summary>
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }
    private BicepValue<ResourceIdentifier>? _id;

    /// <summary>
    /// A provisioning state of the mongo cluster.
    /// </summary>
    public BicepValue<CosmosDBProvisioningState> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
    }
    private BicepValue<CosmosDBProvisioningState>? _provisioningState;

    /// <summary>
    /// Gets the SystemData.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }
    private SystemData? _systemData;

    /// <summary>
    /// Creates a new MongoCluster.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the MongoCluster resource.  This can
    /// be used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the MongoCluster.</param>
    public MongoCluster(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.DocumentDB/mongoClusters", resourceVersion ?? "2024-07-01")
    {
    }

    /// <summary>
    /// Define all the provisionable properties of MongoCluster.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
        _administratorLogin = DefineProperty<string>("AdministratorLogin", ["properties", "administratorLogin"]);
        _administratorLoginPassword = DefineProperty<string>("AdministratorLoginPassword", ["properties", "administratorLoginPassword"]);
        _createMode = DefineProperty<CosmosDBAccountCreateMode>("CreateMode", ["properties", "createMode"]);
        _nodeGroupSpecs = DefineListProperty<NodeGroupSpec>("NodeGroupSpecs", ["properties", "nodeGroupSpecs"]);
        _restoreParameters = DefineModelProperty<MongoClusterRestoreParameters>("RestoreParameters", ["properties", "restoreParameters"]);
        _serverVersion = DefineProperty<string>("ServerVersion", ["properties", "serverVersion"]);
        _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
        _clusterStatus = DefineProperty<MongoClusterStatus>("ClusterStatus", ["properties", "clusterStatus"], isOutput: true);
        _connectionString = DefineProperty<string>("ConnectionString", ["properties", "connectionString"], isOutput: true);
        _earliestRestoreTime = DefineProperty<string>("EarliestRestoreTime", ["properties", "earliestRestoreTime"], isOutput: true);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _provisioningState = DefineProperty<CosmosDBProvisioningState>("ProvisioningState", ["properties", "provisioningState"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
    }

    /// <summary>
    /// Supported MongoCluster resource versions.
    /// </summary>
    public static class ResourceVersions
    {
        /// <summary>
        /// 2024-07-01.
        /// </summary>
        public static readonly string V2024_07_01 = "2024-07-01";
    }

    /// <summary>
    /// Creates a reference to an existing MongoCluster.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the MongoCluster resource.  This can
    /// be used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the MongoCluster.</param>
    /// <returns>The existing MongoCluster resource.</returns>
    public static MongoCluster FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
