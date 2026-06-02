// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// A NAPTR record. For more information about the NAPTR record format, see RFC
/// 3403: https://www.rfc-editor.org/rfc/rfc3403.
/// </summary>
public partial class DnsNaptrRecordInfo : ProvisionableConstruct
{
    /// <summary> The order in which the NAPTR records MUST be processed in order to accurately represent the ordered list of rules. The ordering is from lowest to highest. Valid values: 0-65535. </summary>
    public BicepValue<int> Order
    {
        get { Initialize(); return _order!; }
        set { Initialize(); _order!.Assign(value); }
    }
    private BicepValue<int>? _order;

    /// <summary> The preference specifies the order in which NAPTR records with equal 'order' values should be processed, low numbers being processed before high numbers. Valid values: 0-65535. </summary>
    public BicepValue<int> Preference
    {
        get { Initialize(); return _preference!; }
        set { Initialize(); _preference!.Assign(value); }
    }
    private BicepValue<int>? _preference;

    /// <summary> The flags specific to DDDS applications. Values currently defined in RFC 3404 are uppercase and lowercase letters "A", "P", "S", and "U", and the empty string, "". Enclose Flags in quotation marks. </summary>
    public BicepValue<string> Flags
    {
        get { Initialize(); return _flags!; }
        set { Initialize(); _flags!.Assign(value); }
    }
    private BicepValue<string>? _flags;

    /// <summary> The services specific to DDDS applications. Enclose Services in quotation marks. </summary>
    public BicepValue<string> Services
    {
        get { Initialize(); return _services!; }
        set { Initialize(); _services!.Assign(value); }
    }
    private BicepValue<string>? _services;

    /// <summary> The regular expression that the DDDS application uses to convert an input value into an output value. For example: an IP phone system might use a regular expression to convert a phone number that is entered by a user into a SIP URI. Enclose the regular expression in quotation marks. Specify either a value for 'regexp' or a value for 'replacement'. </summary>
    public BicepValue<string> Regexp
    {
        get { Initialize(); return _regexp!; }
        set { Initialize(); _regexp!.Assign(value); }
    }
    private BicepValue<string>? _regexp;

    /// <summary> The replacement is a fully qualified domain name (FQDN) of the next domain name that you want the DDDS application to submit a DNS query for. The DDDS application replaces the input value with the value specified for replacement. Specify either a value for 'regexp' or a value for 'replacement'. If you specify a value for 'regexp', specify a dot (.) for 'replacement'. </summary>
    public BicepValue<string> Replacement
    {
        get { Initialize(); return _replacement!; }
        set { Initialize(); _replacement!.Assign(value); }
    }
    private BicepValue<string>? _replacement;

    /// <summary>
    /// Creates a new DnsNaptrRecordInfo.
    /// </summary>
    public DnsNaptrRecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsNaptrRecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _order = DefineProperty<int>("Order", ["order"]);
        _preference = DefineProperty<int>("Preference", ["preference"]);
        _flags = DefineProperty<string>("Flags", ["flags"]);
        _services = DefineProperty<string>("Services", ["services"]);
        _regexp = DefineProperty<string>("Regexp", ["regexp"]);
        _replacement = DefineProperty<string>("Replacement", ["replacement"]);
    }
}
