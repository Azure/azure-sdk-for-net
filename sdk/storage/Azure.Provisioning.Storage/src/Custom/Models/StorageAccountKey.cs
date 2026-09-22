// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Storage;

// Provisioning generation omits custom ARM actions and their result models; retain the shipped listKeys result shape.
// Remove this type when action generation is supported: https://github.com/Azure/azure-sdk-for-net/issues/56753.
/// <summary> An access key for the storage account. </summary>
public partial class StorageAccountKey : ProvisionableConstruct
{
    private BicepValue<string>? _keyName;
    private BicepValue<string>? _value;
    private BicepValue<StorageAccountKeyPermission>? _permissions;
    private BicepValue<DateTimeOffset>? _createdOn;

    // Provisioning generation omits the listKeys result model; retain the shipped KeyName output property.
    /// <summary>
    /// Name of the key.
    /// </summary>
    public BicepValue<string> KeyName
    {
        get { Initialize(); return _keyName!; }
    }

    // Provisioning generation omits the listKeys result model; retain the shipped Value output property.
    /// <summary>
    /// Base 64-encoded value of the key.
    /// </summary>
    public BicepValue<string> Value
    {
        get { Initialize(); return _value!; }
    }

    // Provisioning generation omits the listKeys result model; retain the shipped Permissions output property.
    /// <summary>
    /// Permissions for the key -- read-only or full permissions.
    /// </summary>
    public BicepValue<StorageAccountKeyPermission> Permissions
    {
        get { Initialize(); return _permissions!; }
    }

    // Provisioning generation omits the listKeys result model; retain the shipped CreatedOn output property.
    /// <summary>
    /// Creation time of the key, in round trip date format.
    /// </summary>
    public BicepValue<DateTimeOffset> CreatedOn
    {
        get { Initialize(); return _createdOn!; }
    }

    /// <summary>
    /// Creates a new StorageAccountKey.
    /// </summary>
    public StorageAccountKey()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of StorageAccountKey.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _keyName = DefineProperty<string>(nameof(KeyName), ["keyName"], isOutput: true);
        _value = DefineProperty<string>(nameof(Value), ["value"], isOutput: true, isSecure: true);
        _permissions = DefineProperty<StorageAccountKeyPermission>(nameof(Permissions), ["permissions"], isOutput: true);
        _createdOn = DefineProperty<DateTimeOffset>(nameof(CreatedOn), ["creationTime"], isOutput: true);
    }
}
