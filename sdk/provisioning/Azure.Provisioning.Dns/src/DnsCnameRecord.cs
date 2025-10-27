// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using System;

namespace Azure.Provisioning.Dns;

/// <summary>
/// DnsCnameRecord.
/// </summary>
public partial class DnsCnameRecord : ProvisionableResource
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

    /// <summary>
    /// The canonical name for this CNAME record.
    /// </summary>
    public BicepValue<string> Cname
    {
        get { Initialize(); return _cname!; }
        set { Initialize(); _cname!.Assign(value); }
    }
    private BicepValue<string>? _cname;

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
    /// Creates a new DnsCnameRecord.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the DnsCnameRecord resource.  This can
    /// be used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the DnsCnameRecord.</param>
    public DnsCnameRecord(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.Network/dnsZones/CNAME", resourceVersion ?? "2018-05-01")
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsCnameRecord.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>("Name", ["name"], isRequired: true);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
        _parent = DefineResource<DnsZone>("Parent", ["parent"], isRequired: true);
        _cname = DefineProperty<string>("Cname", ["CNAMERecord", "cname"]);
    }

    /// <summary>
    /// Supported DnsCnameRecord resource versions.
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
    /// Creates a reference to an existing DnsCnameRecord.
    /// </summary>
    /// <param name="bicepIdentifier">
    /// The the Bicep identifier name of the DnsCnameRecord resource.  This can
    /// be used to refer to the resource in expressions, but is not the Azure
    /// name of the resource.  This value can contain letters, numbers, and
    /// underscores.
    /// </param>
    /// <param name="resourceVersion">Version of the DnsCnameRecord.</param>
    /// <returns>The existing DnsCnameRecord resource.</returns>
    public static DnsCnameRecord FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };
}
