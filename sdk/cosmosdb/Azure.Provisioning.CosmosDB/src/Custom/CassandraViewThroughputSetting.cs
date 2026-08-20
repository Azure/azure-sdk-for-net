// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CassandraViewThroughputSetting : ProvisionableResource
{
    private BicepValue<string>? _name;
    private BicepValue<AzureLocation>? _location;
    private ThroughputSettingsResourceInfo? _resource;
    private ManagedServiceIdentity? _identity;
    private BicepDictionary<string>? _tags;
    private BicepValue<ResourceIdentifier>? _id;
    private SystemData? _systemData;
    private ResourceReference<CassandraViewGetResult>? _parent;

    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
    }

    public BicepValue<AzureLocation> Location
    {
        get { Initialize(); return _location!; }
        set { Initialize(); _location!.Assign(value); }
    }

    public ThroughputSettingsResourceInfo Resource
    {
        get { Initialize(); return _resource!; }
        set { Initialize(); AssignOrReplace(ref _resource, value); }
    }

    public ManagedServiceIdentity Identity
    {
        get { Initialize(); return _identity!; }
        set { Initialize(); AssignOrReplace(ref _identity, value); }
    }

    public BicepDictionary<string> Tags
    {
        get { Initialize(); return _tags!; }
        set { Initialize(); _tags!.Assign(value); }
    }

    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }

    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }

    public CassandraViewGetResult? Parent
    {
        get { Initialize(); return _parent!.Value; }
        set { Initialize(); _parent!.Value = value; }
    }

    public CassandraViewThroughputSetting(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/views/throughputSettings", resourceVersion ?? "2025-04-15")
    {
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"], isOutput: true);
        _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
        _resource = DefineModelProperty<ThroughputSettingsResourceInfo>("Resource", ["properties", "resource"], isRequired: true);
        _identity = DefineModelProperty<ManagedServiceIdentity>("Identity", ["identity"]);
        _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
        _parent = DefineResource<CassandraViewGetResult>("Parent", ["parent"], isRequired: true);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ResourceVersions
    {
        public static readonly string V2025_04_15 = "2025-04-15";
        public static readonly string V2024_11_15 = "2024-11-15";
        public static readonly string V2024_08_15 = "2024-08-15";
        public static readonly string V2024_05_15 = "2024-05-15";
        public static readonly string V2023_11_15 = "2023-11-15";
        public static readonly string V2023_09_15 = "2023-09-15";
        public static readonly string V2023_04_15 = "2023-04-15";
        public static readonly string V2023_03_15 = "2023-03-15";
        public static readonly string V2022_11_15 = "2022-11-15";
        public static readonly string V2022_08_15 = "2022-08-15";
        public static readonly string V2022_05_15 = "2022-05-15";
        public static readonly string V2021_10_15 = "2021-10-15";
        public static readonly string V2021_06_15 = "2021-06-15";
        public static readonly string V2021_05_15 = "2021-05-15";
        public static readonly string V2021_04_15 = "2021-04-15";
        public static readonly string V2021_03_15 = "2021-03-15";
        public static readonly string V2021_01_15 = "2021-01-15";
        public static readonly string V2020_09_01 = "2020-09-01";
        public static readonly string V2020_04_01 = "2020-04-01";
        public static readonly string V2020_03_01 = "2020-03-01";
        public static readonly string V2019_12_12 = "2019-12-12";
        public static readonly string V2019_08_01 = "2019-08-01";
        public static readonly string V2016_03_31 = "2016-03-31";
        public static readonly string V2016_03_19 = "2016-03-19";
        public static readonly string V2015_11_06 = "2015-11-06";
        public static readonly string V2015_04_08 = "2015-04-08";
        public static readonly string V2014_04_01 = "2014-04-01";
    }

    public static CassandraViewThroughputSetting FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
