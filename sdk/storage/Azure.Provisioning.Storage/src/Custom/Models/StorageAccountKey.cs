// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Storage;

// TypeSpec does not generate the storage account listKeys action result. Preserve the shipped
// secure output model used by StorageAccount.GetKeys.
/// <summary>
/// An access key for the storage account.
/// </summary>
public partial class StorageAccountKey : ProvisionableConstruct
{
    private BicepValue<string>? _keyName;
    private BicepValue<string>? _value;
    private BicepValue<StorageAccountKeyPermission>? _permissions;
    private BicepValue<DateTimeOffset>? _createdOn;

    /// <summary> Gets the key name. </summary>
    public BicepValue<string> KeyName
    {
        get { Initialize(); return _keyName!; }
    }

    /// <summary> Gets the base64-encoded key value. </summary>
    public BicepValue<string> Value
    {
        get { Initialize(); return _value!; }
    }

    /// <summary> Gets the key permissions. </summary>
    public BicepValue<StorageAccountKeyPermission> Permissions
    {
        get { Initialize(); return _permissions!; }
    }

    /// <summary> Gets the key creation time. </summary>
    public BicepValue<DateTimeOffset> CreatedOn
    {
        get { Initialize(); return _createdOn!; }
    }

    /// <summary> Creates a new StorageAccountKey. </summary>
    public StorageAccountKey()
    {
    }

    /// <summary> Defines the provisionable properties. </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _keyName = DefineProperty<string>(nameof(KeyName), ["keyName"], isOutput: true);
        _value = DefineProperty<string>(nameof(Value), ["value"], isOutput: true, isSecure: true);
        _permissions = DefineProperty<StorageAccountKeyPermission>(nameof(Permissions), ["permissions"], isOutput: true);
        _createdOn = DefineProperty<DateTimeOffset>(nameof(CreatedOn), ["creationTime"], isOutput: true);
    }
}
