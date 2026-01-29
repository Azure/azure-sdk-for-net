// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// An SOA record.
/// </summary>
public partial class DnsSoaRecordInfo : ProvisionableConstruct
{
    /// <summary> The domain name of the authoritative name server for this SOA record. </summary>
    public BicepValue<string> Host
    {
        get { Initialize(); return _host!; }
        set { Initialize(); _host!.Assign(value); }
    }
    private BicepValue<string>? _host;

    /// <summary> The email contact for this SOA record. </summary>
    public BicepValue<string> Email
    {
        get { Initialize(); return _email!; }
        set { Initialize(); _email!.Assign(value); }
    }
    private BicepValue<string>? _email;

    /// <summary> The serial number for this SOA record. </summary>
    public BicepValue<long> SerialNumber
    {
        get { Initialize(); return _serialNumber!; }
        set { Initialize(); _serialNumber!.Assign(value); }
    }
    private BicepValue<long>? _serialNumber;

    /// <summary> The refresh value for this SOA record. </summary>
    public BicepValue<long> RefreshTimeInSeconds
    {
        get { Initialize(); return _refreshTimeInSeconds!; }
        set { Initialize(); _refreshTimeInSeconds!.Assign(value); }
    }
    private BicepValue<long>? _refreshTimeInSeconds;

    /// <summary> The retry time for this SOA record. </summary>
    public BicepValue<long> RetryTimeInSeconds
    {
        get { Initialize(); return _retryTimeInSeconds!; }
        set { Initialize(); _retryTimeInSeconds!.Assign(value); }
    }
    private BicepValue<long>? _retryTimeInSeconds;

    /// <summary> The expire time for this SOA record. </summary>
    public BicepValue<long> ExpireTimeInSeconds
    {
        get { Initialize(); return _expireTimeInSeconds!; }
        set { Initialize(); _expireTimeInSeconds!.Assign(value); }
    }
    private BicepValue<long>? _expireTimeInSeconds;

    /// <summary> The minimum value for this SOA record. By convention this is used to determine the negative caching duration. </summary>
    public BicepValue<long> MinimumTtlInSeconds
    {
        get { Initialize(); return _minimumTtlInSeconds!; }
        set { Initialize(); _minimumTtlInSeconds!.Assign(value); }
    }
    private BicepValue<long>? _minimumTtlInSeconds;

    /// <summary>
    /// Creates a new DnsSoaRecordInfo.
    /// </summary>
    public DnsSoaRecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsSoaRecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _host = DefineProperty<string>("Host", ["host"]);
        _email = DefineProperty<string>("Email", ["email"]);
        _serialNumber = DefineProperty<long>("SerialNumber", ["serialNumber"]);
        _refreshTimeInSeconds = DefineProperty<long>("RefreshTimeInSeconds", ["refreshTime"]);
        _retryTimeInSeconds = DefineProperty<long>("RetryTimeInSeconds", ["retryTime"]);
        _expireTimeInSeconds = DefineProperty<long>("ExpireTimeInSeconds", ["expireTime"]);
        _minimumTtlInSeconds = DefineProperty<long>("MinimumTtlInSeconds", ["minimumTTL"]);
    }
}
