// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.WebPubSub;

/// <summary> The access keys of a Web PubSub resource. </summary>
public partial class WebPubSubKeys : ProvisionableConstruct
{
    private BicepValue<string> _primaryKey;
    private BicepValue<string> _secondaryKey;
    private BicepValue<string> _primaryConnectionString;
    private BicepValue<string> _secondaryConnectionString;

    /// <summary> Gets the primary access key. </summary>
    public BicepValue<string> PrimaryKey { get { Initialize(); return _primaryKey; } }

    /// <summary> Gets the secondary access key. </summary>
    public BicepValue<string> SecondaryKey { get { Initialize(); return _secondaryKey; } }

    /// <summary> Gets the connection string constructed with the primary key. </summary>
    public BicepValue<string> PrimaryConnectionString { get { Initialize(); return _primaryConnectionString; } }

    /// <summary> Gets the connection string constructed with the secondary key. </summary>
    public BicepValue<string> SecondaryConnectionString { get { Initialize(); return _secondaryConnectionString; } }

    /// <summary> Creates a new instance of <see cref="WebPubSubKeys"/>. </summary>
    public WebPubSubKeys()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _primaryKey = DefineProperty<string>(nameof(PrimaryKey), new string[] { "primaryKey" }, isOutput: true, isSecure: true);
        _secondaryKey = DefineProperty<string>(nameof(SecondaryKey), new string[] { "secondaryKey" }, isOutput: true, isSecure: true);
        _primaryConnectionString = DefineProperty<string>(nameof(PrimaryConnectionString), new string[] { "primaryConnectionString" }, isOutput: true, isSecure: true);
        _secondaryConnectionString = DefineProperty<string>(nameof(SecondaryConnectionString), new string[] { "secondaryConnectionString" }, isOutput: true, isSecure: true);
    }
}
