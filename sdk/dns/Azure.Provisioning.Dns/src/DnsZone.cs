// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Dns;

/// <summary>
/// DnsZone.
/// </summary>
public partial class DnsZone : ProvisionableResource
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
    /// Gets or sets the Location.
    /// </summary>
    public BicepValue<AzureLocation> Location
    {
        get { Initialize(); return _location!; }
        set { Initialize(); _location!.Assign(value); }
    }
    private BicepValue<AzureLocation>? _location;

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
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }
    private BicepValue<ResourceIdentifier>? _id;

    /// <summary>
    /// Gets the SystemData.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }
    private SystemData? _systemData;

    /// <summary>
    /// A list of references to virtual networks that register hostnames in this DNS zone. This is a only when ZoneType is Private.
    /// </summary>
    public BicepList<WritableSubResource> RegistrationVirtualNetworks
    {
        get { Initialize(); return _registrationVirtualNetworks!; }
        set { Initialize(); _registrationVirtualNetworks!.Assign(value); }
    }
    private BicepList<WritableSubResource>? _registrationVirtualNetworks;

    /// <summary>
    /// A list of references to virtual networks that resolve records in this DNS zone. This is a only when ZoneType is Private.
    /// </summary>
    public BicepList<WritableSubResource> ResolutionVirtualNetworks
    {
        get { Initialize(); return _resolutionVirtualNetworks!; }
        set { Initialize(); _resolutionVirtualNetworks!.Assign(value); }
    }
    private BicepList<WritableSubResource>? _resolutionVirtualNetworks;

    /// <summary>
    /// The type of this DNS zone (Public or Private).
    /// </summary>
    public BicepValue<DnsZoneType> ZoneType
    {
        get { Initialize(); return _zoneType!; }
        set { Initialize(); _zoneType!.Assign(value); }
    }
    private BicepValue<DnsZoneType>? _zoneType;

    /// <summary> The maximum number of record sets that can be created in this DNS zone.  This is a read-only property and any attempt to set this value will be ignored. </summary>
    public BicepValue<long> MaxNumberOfRecords
    {
        get { Initialize(); return _maxNumberOfRecords!; }
    }
    private BicepValue<long>? _maxNumberOfRecords;

    /// <summary> The maximum number of records per record set that can be created in this DNS zone.  This is a read-only property and any attempt to set this value will be ignored. </summary>
    public BicepValue<long> MaxNumberOfRecordsPerRecord
    {
        get { Initialize(); return _maxNumberOfRecordsPerRecord!; }
    }
    private BicepValue<long>? _maxNumberOfRecordsPerRecord;

    /// <summary> The current number of record sets in this DNS zone.  This is a read-only property and any attempt to set this value will be ignored. </summary>
    public BicepValue<long> NumberOfRecords
    {
        get { Initialize(); return _numberOfRecords!; }
    }
    private BicepValue<long>? _numberOfRecords;

    /// <summary> The name servers for this DNS zone. This is a read-only property and any attempt to set this value will be ignored. </summary>
    public BicepList<string> NameServers
    {
        get { Initialize(); return _nameServers!; }
    }
    private BicepList<string>? _nameServers;

    /// <summary> The list of signing keys. </summary>
    public BicepList<DnsSigningKey> SigningKeys
    {
        get { Initialize(); return _signingKeys!; }
    }
    private BicepList<DnsSigningKey>? _signingKeys;

    /// <summary>
    /// Creates a new DnsZone.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the DnsZone resource.  This can be
    /// used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the DnsZone.</param>
    public DnsZone(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.Network/dnsZones", resourceVersion ?? "2018-05-01")
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsZone.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
        _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
        _registrationVirtualNetworks = DefineListProperty<WritableSubResource>("RegistrationVirtualNetworks", ["properties", "registrationVirtualNetworks"]);
        _resolutionVirtualNetworks = DefineListProperty<WritableSubResource>("ResolutionVirtualNetworks", ["properties", "resolutionVirtualNetworks"]);
        _zoneType = DefineProperty<DnsZoneType>("ZoneType", ["properties", "zoneType"]);
        _maxNumberOfRecords = DefineProperty<long>("MaxNumberOfRecords", ["properties", "maxNumberOfRecordSets"], isOutput: true);
        _maxNumberOfRecordsPerRecord = DefineProperty<long>("MaxNumberOfRecordsPerRecord", ["properties", "maxNumberOfRecordsPerRecordSet"], isOutput: true);
        _numberOfRecords = DefineProperty<long>("NumberOfRecords", ["properties", "numberOfRecordSets"], isOutput: true);
        _nameServers = DefineListProperty<string>("NameServers", ["properties", "nameServers"], isOutput: true);
        _signingKeys = DefineListProperty<DnsSigningKey>("SigningKeys", ["properties", "signingKeys"], isOutput: true);
    }

    /// <summary>
    /// Supported DnsZone resource versions.
    /// </summary>
    public static class ResourceVersions
    {
        /// <summary>
        /// 2018-05-01.
        /// </summary>
        public static readonly string V2018_05_01 = "2018-05-01";

        /// <summary>
        /// 2017-10-01.
        /// </summary>
        public static readonly string V2017_10_01 = "2017-10-01";

        /// <summary>
        /// 2017-09-01.
        /// </summary>
        public static readonly string V2017_09_01 = "2017-09-01";

        /// <summary>
        /// 2016-04-01.
        /// </summary>
        public static readonly string V2016_04_01 = "2016-04-01";
    }

    /// <summary>
    /// Creates a reference to an existing DnsZone.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the DnsZone resource. This can be
    /// used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the DnsZone.</param>
    /// <returns>The existing DnsZone resource.</returns>
    public static DnsZone FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
