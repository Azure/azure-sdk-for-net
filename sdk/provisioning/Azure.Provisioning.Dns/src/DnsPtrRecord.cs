// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Dns;

/// <summary>
/// DnsPtrRecord.
/// </summary>
public partial class DnsPtrRecord : ProvisionableResource
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
    /// Gets the SystemData.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }
    private SystemData? _systemData;

    /// <summary> The list of PTR records in the record set. </summary>
    public BicepList<DnsPtrRecordInfo> DnsPtrRecords
    {
        get { Initialize(); return _dnsPtrRecords!; }
        set { Initialize(); _dnsPtrRecords!.Assign(value); }
    }
    private BicepList<DnsPtrRecordInfo>? _dnsPtrRecords;

    /// <summary>
    /// Gets or sets a reference to the parent DnsZone.
    /// </summary>
    public DnsZone? Parent
    {
        get { Initialize(); return _parent!.Value; }
        set { Initialize(); _parent!.Value = value; }
    }
    private ResourceReference<DnsZone>? _parent;

    /// <summary>
    /// Creates a new DnsPtrRecord.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the DnsPtrRecord resource.  This can
    /// be used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the DnsPtrRecord.</param>
    public DnsPtrRecord(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.Network/dnsZones/PTR", resourceVersion ?? "2018-05-01")
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsPtrRecord.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
        _dnsPtrRecords = DefineListProperty<DnsPtrRecordInfo>("DnsPtrRecords", ["properties", "PTRRecords"]);
        _parent = DefineResource<DnsZone>("Parent", ["parent"], isRequired: true);
    }

    /// <summary>
    /// Supported DnsPtrRecord resource versions.
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
    /// Creates a reference to an existing DnsPtrRecord.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the DnsPtrRecord resource.  This can
    /// be used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the DnsPtrRecord.</param>
    /// <returns>The existing DnsPtrRecord resource.</returns>
    public static DnsPtrRecord FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
