// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore the preview-only Cassandra view API from the previous GA package because
// the selected stable TypeSpec version does not generate it.
/// <summary>
/// CassandraViewGetResult.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CassandraViewGetResult : ProvisionableResource
{
    private BicepValue<string>? _name;
    private BicepValue<AzureLocation>? _location;
    private CassandraViewResource? _resource;
    private ManagedServiceIdentity? _identity;
    private CosmosDBCreateUpdateConfig? _options;
    private BicepDictionary<string>? _tags;
    private BicepValue<ResourceIdentifier>? _id;
    private SystemData? _systemData;
    private ResourceReference<CassandraKeyspace>? _parent;

    /// <summary>
    /// Cosmos DB view name.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }

    /// <summary>
    /// Gets or sets the Location.
    /// </summary>
    public BicepValue<AzureLocation> Location
    {
        get { Initialize(); return _location!; }
        set { Initialize(); _location!.Assign(value); }
    }

    /// <summary>
    /// The standard JSON format of a Cassandra view.
    /// </summary>
    public CassandraViewResource Resource
    {
        get { Initialize(); return _resource!; }
        set { Initialize(); AssignOrReplace(ref _resource, value); }
    }

    /// <summary>
    /// Identity for the resource.
    /// </summary>
    public ManagedServiceIdentity Identity
    {
        get { Initialize(); return _identity!; }
        set { Initialize(); AssignOrReplace(ref _identity, value); }
    }

    /// <summary>
    /// A key-value pair of options to be applied for the request. This
    /// corresponds to the headers sent with the request.
    /// </summary>
    public CosmosDBCreateUpdateConfig Options
    {
        get { Initialize(); return _options!; }
        set { Initialize(); AssignOrReplace(ref _options, value); }
    }

    /// <summary>
    /// Gets or sets the Tags.
    /// </summary>
    public BicepDictionary<string> Tags
    {
        get { Initialize(); return _tags!; }
        set { Initialize(); _tags!.Assign(value); }
    }

    /// <summary>
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }

    /// <summary>
    /// Gets the SystemData.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }

    /// <summary>
    /// Gets or sets a reference to the parent CassandraKeyspace.
    /// </summary>
    public CassandraKeyspace? Parent
    {
        get { Initialize(); return _parent!.Value; }
        set { Initialize(); _parent!.Value = value; }
    }

    /// <summary>
    /// Creates a new CassandraViewGetResult.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the CassandraViewGetResult resource.
    /// This can be used to refer to the resource in expressions, but is not
    /// the Azure name of the resource.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the CassandraViewGetResult.</param>
    public CassandraViewGetResult(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.DocumentDB/databaseAccounts/cassandraKeyspaces/views", resourceVersion ?? "2025-04-15")
    {
    }

    /// <summary>
    /// Define all the provisionable properties of CassandraViewGetResult.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
        _resource = DefineModelProperty<CassandraViewResource>("Resource", ["properties", "resource"], isRequired: true);
        _identity = DefineModelProperty<ManagedServiceIdentity>("Identity", ["identity"]);
        _options = DefineModelProperty<CosmosDBCreateUpdateConfig>("Options", ["properties", "options"]);
        _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
        _parent = DefineResource<CassandraKeyspace>("Parent", ["parent"], isRequired: true);
    }

    /// <summary>
    /// Supported CassandraViewGetResult resource versions.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ResourceVersions
    {
        /// <summary>
        /// 2025-04-15.
        /// </summary>
        public static readonly string V2025_04_15 = "2025-04-15";

        /// <summary>
        /// 2024-11-15.
        /// </summary>
        public static readonly string V2024_11_15 = "2024-11-15";

        /// <summary>
        /// 2024-08-15.
        /// </summary>
        public static readonly string V2024_08_15 = "2024-08-15";

        /// <summary>
        /// 2024-05-15.
        /// </summary>
        public static readonly string V2024_05_15 = "2024-05-15";

        /// <summary>
        /// 2023-11-15.
        /// </summary>
        public static readonly string V2023_11_15 = "2023-11-15";

        /// <summary>
        /// 2023-09-15.
        /// </summary>
        public static readonly string V2023_09_15 = "2023-09-15";

        /// <summary>
        /// 2023-04-15.
        /// </summary>
        public static readonly string V2023_04_15 = "2023-04-15";

        /// <summary>
        /// 2023-03-15.
        /// </summary>
        public static readonly string V2023_03_15 = "2023-03-15";

        /// <summary>
        /// 2022-11-15.
        /// </summary>
        public static readonly string V2022_11_15 = "2022-11-15";

        /// <summary>
        /// 2022-08-15.
        /// </summary>
        public static readonly string V2022_08_15 = "2022-08-15";

        /// <summary>
        /// 2022-05-15.
        /// </summary>
        public static readonly string V2022_05_15 = "2022-05-15";

        /// <summary>
        /// 2021-10-15.
        /// </summary>
        public static readonly string V2021_10_15 = "2021-10-15";

        /// <summary>
        /// 2021-06-15.
        /// </summary>
        public static readonly string V2021_06_15 = "2021-06-15";

        /// <summary>
        /// 2021-05-15.
        /// </summary>
        public static readonly string V2021_05_15 = "2021-05-15";

        /// <summary>
        /// 2021-04-15.
        /// </summary>
        public static readonly string V2021_04_15 = "2021-04-15";

        /// <summary>
        /// 2021-03-15.
        /// </summary>
        public static readonly string V2021_03_15 = "2021-03-15";

        /// <summary>
        /// 2021-01-15.
        /// </summary>
        public static readonly string V2021_01_15 = "2021-01-15";

        /// <summary>
        /// 2020-09-01.
        /// </summary>
        public static readonly string V2020_09_01 = "2020-09-01";

        /// <summary>
        /// 2020-04-01.
        /// </summary>
        public static readonly string V2020_04_01 = "2020-04-01";

        /// <summary>
        /// 2020-03-01.
        /// </summary>
        public static readonly string V2020_03_01 = "2020-03-01";

        /// <summary>
        /// 2019-12-12.
        /// </summary>
        public static readonly string V2019_12_12 = "2019-12-12";

        /// <summary>
        /// 2019-08-01.
        /// </summary>
        public static readonly string V2019_08_01 = "2019-08-01";

        /// <summary>
        /// 2016-03-31.
        /// </summary>
        public static readonly string V2016_03_31 = "2016-03-31";

        /// <summary>
        /// 2016-03-19.
        /// </summary>
        public static readonly string V2016_03_19 = "2016-03-19";

        /// <summary>
        /// 2015-11-06.
        /// </summary>
        public static readonly string V2015_11_06 = "2015-11-06";

        /// <summary>
        /// 2015-04-08.
        /// </summary>
        public static readonly string V2015_04_08 = "2015-04-08";

        /// <summary>
        /// 2014-04-01.
        /// </summary>
        public static readonly string V2014_04_01 = "2014-04-01";
    }

    /// <summary>
    /// Creates a reference to an existing CassandraViewGetResult.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the CassandraViewGetResult resource.
    /// This can be used to refer to the resource in expressions, but is not
    /// the Azure name of the resource.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the CassandraViewGetResult.</param>
    /// <returns>The existing CassandraViewGetResult resource.</returns>
    public static CassandraViewGetResult FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
