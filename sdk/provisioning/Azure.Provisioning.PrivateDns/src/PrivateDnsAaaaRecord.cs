// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.PrivateDns;

/// <summary>
/// PrivateDnsAaaaRecord.
/// </summary>
public partial class PrivateDnsAaaaRecord : ProvisionableResource
{
    /// <summary>
    /// Gets or sets the Name.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }
    private BicepValue<string>? _name;

    /// <summary>
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }
    private BicepValue<ResourceIdentifier>? _id;

    /// <summary>
    /// The ETag of the record set.
    /// </summary>
    public BicepValue<ETag> ETag
    {
        get { Initialize(); return _eTag!; }
        set { Initialize(); _eTag!.Assign(value); }
    }
    private BicepValue<ETag>? _eTag;

    /// <summary> The metadata attached to the record set. </summary>
    public BicepDictionary<string> Metadata
    {
        get { Initialize(); return _metadata!; }
        set { Initialize(); _metadata!.Assign(value); }
    }
    private BicepDictionary<string>? _metadata;

    /// <summary> The TTL (time-to-live) of the records in the record set. </summary>
    public BicepValue<long> TtlInSeconds
    {
        get { Initialize(); return _ttlInSeconds!; }
        set { Initialize(); _ttlInSeconds!.Assign(value); }
    }
    private BicepValue<long>? _ttlInSeconds;

    /// <summary> The list of AAAA records in the record set. </summary>
    public BicepList<PrivateDnsAaaaRecordInfo> PrivateDnsAaaaRecords
    {
        get { Initialize(); return _privateDnsAaaaRecords!; }
        set { Initialize(); _privateDnsAaaaRecords!.Assign(value); }
    }
    private BicepList<PrivateDnsAaaaRecordInfo>? _privateDnsAaaaRecords;

    /// <summary>
    /// Gets the SystemData.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }
    private SystemData? _systemData;

    /// <summary>
    /// Gets or sets a reference to the parent PrivateDnsZone.
    /// </summary>
    public PrivateDnsZone? Parent
    {
        get { Initialize(); return _parent!.Value; }
        set { Initialize(); _parent!.Value = value; }
    }
    private ResourceReference<PrivateDnsZone>? _parent;

    /// <summary>
    /// Creates a new PrivateDnsAaaaRecord.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the PrivateDnsAaaaRecord resource.
    /// This can be used to refer to the resource in expressions, but is not
    /// the Azure name of the resource.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the PrivateDnsAaaaRecord.</param>
    public PrivateDnsAaaaRecord(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.Network/privateDnsZones/AAAA", resourceVersion ?? "2024-06-01")
    {
    }

    /// <summary>
    /// Define all the provisionable properties of PrivateDnsAaaaRecord.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _eTag = DefineProperty<ETag>("ETag", ["etag"]);
        _metadata = DefineDictionaryProperty<string>("Metadata", ["properties", "metadata"]);
        _ttlInSeconds = DefineProperty<long>("TtlInSeconds", ["properties", "ttl"]);
        _privateDnsAaaaRecords = DefineListProperty<PrivateDnsAaaaRecordInfo>("PrivateDnsAaaaRecords", ["properties", "aaaaRecords"]);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
        _parent = DefineResource<PrivateDnsZone>("Parent", ["parent"], isRequired: true);
    }

    /// <summary>
    /// Supported PrivateDnsAaaaRecord resource versions.
    /// </summary>
    public static class ResourceVersions
    {
        /// <summary>
        /// 2024-06-01.
        /// </summary>
        public static readonly string V2024_06_01 = "2024-06-01";

        /// <summary>
        /// 2020-06-01.
        /// </summary>
        public static readonly string V2020_06_01 = "2020-06-01";

        /// <summary>
        /// 2020-01-01.
        /// </summary>
        public static readonly string V2020_01_01 = "2020-01-01";

        /// <summary>
        /// 2018-09-01.
        /// </summary>
        public static readonly string V2018_09_01 = "2018-09-01";
    }

    /// <summary>
    /// Creates a reference to an existing PrivateDnsAaaaRecord.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the PrivateDnsAaaaRecord resource.
    /// This can be used to refer to the resource in expressions, but is not
    /// the Azure name of the resource.  This value can contain letters,
    /// numbers, and underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the PrivateDnsAaaaRecord.</param>
    /// <returns>The existing PrivateDnsAaaaRecord resource.</returns>
    public static PrivateDnsAaaaRecord FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
