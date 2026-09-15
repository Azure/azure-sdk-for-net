// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.EventHubs;

/// <summary> Namespace/EventHub connection strings and keys. </summary>
// The TypeSpec provisioning generator does not emit action helpers or retain their response models yet.
// Preserve the shipped secure access-key result type for the custom GetKeys() compatibility APIs.
public partial class EventHubsAccessKeys : ProvisionableConstruct
{
    private BicepValue<string> _primaryConnectionString;
    private BicepValue<string> _secondaryConnectionString;
    private BicepValue<string> _aliasPrimaryConnectionString;
    private BicepValue<string> _aliasSecondaryConnectionString;
    private BicepValue<string> _primaryKey;
    private BicepValue<string> _secondaryKey;
    private BicepValue<string> _keyName;

    /// <summary> Primary connection string of the created namespace authorization rule. </summary>
    public BicepValue<string> PrimaryConnectionString
    {
        get { Initialize(); return _primaryConnectionString; }
    }

    /// <summary> Secondary connection string of the created namespace authorization rule. </summary>
    public BicepValue<string> SecondaryConnectionString
    {
        get { Initialize(); return _secondaryConnectionString; }
    }

    /// <summary> Primary connection string of the alias if geo-disaster recovery is enabled. </summary>
    public BicepValue<string> AliasPrimaryConnectionString
    {
        get { Initialize(); return _aliasPrimaryConnectionString; }
    }

    /// <summary> Secondary connection string of the alias if geo-disaster recovery is enabled. </summary>
    public BicepValue<string> AliasSecondaryConnectionString
    {
        get { Initialize(); return _aliasSecondaryConnectionString; }
    }

    /// <summary> A base64-encoded 256-bit primary key for signing and validating the SAS token. </summary>
    public BicepValue<string> PrimaryKey
    {
        get { Initialize(); return _primaryKey; }
    }

    /// <summary> A base64-encoded 256-bit secondary key for signing and validating the SAS token. </summary>
    public BicepValue<string> SecondaryKey
    {
        get { Initialize(); return _secondaryKey; }
    }

    /// <summary> A string that describes the authorization rule. </summary>
    public BicepValue<string> KeyName
    {
        get { Initialize(); return _keyName; }
    }

    /// <summary> Creates a new EventHubsAccessKeys. </summary>
    public EventHubsAccessKeys()
    {
    }

    /// <summary> Defines all provisionable properties of EventHubsAccessKeys. </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _primaryConnectionString = DefineProperty<string>(nameof(PrimaryConnectionString), ["primaryConnectionString"], isOutput: true, isSecure: true);
        _secondaryConnectionString = DefineProperty<string>(nameof(SecondaryConnectionString), ["secondaryConnectionString"], isOutput: true, isSecure: true);
        _aliasPrimaryConnectionString = DefineProperty<string>(nameof(AliasPrimaryConnectionString), ["aliasPrimaryConnectionString"], isOutput: true, isSecure: true);
        _aliasSecondaryConnectionString = DefineProperty<string>(nameof(AliasSecondaryConnectionString), ["aliasSecondaryConnectionString"], isOutput: true, isSecure: true);
        _primaryKey = DefineProperty<string>(nameof(PrimaryKey), ["primaryKey"], isOutput: true, isSecure: true);
        _secondaryKey = DefineProperty<string>(nameof(SecondaryKey), ["secondaryKey"], isOutput: true, isSecure: true);
        _keyName = DefineProperty<string>(nameof(KeyName), ["keyName"], isOutput: true);
    }
}
