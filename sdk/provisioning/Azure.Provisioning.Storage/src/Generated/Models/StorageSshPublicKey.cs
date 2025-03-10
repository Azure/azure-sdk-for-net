// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable enable

using Azure.Provisioning.Primitives;
using System;

namespace Azure.Provisioning.Storage;

/// <summary>
/// The StorageSshPublicKey.
/// </summary>
public partial class StorageSshPublicKey : ProvisionableConstruct
{
    /// <summary>
    /// Optional. It is used to store the function/usage of the key.
    /// </summary>
    public BicepValue<string> Description 
    {
        get { Initialize(); return _description!; }
        set { Initialize(); _description!.Assign(value); }
    }
    private BicepValue<string>? _description;

    /// <summary>
    /// Ssh public key base64 encoded. The format should be:
    /// &apos;&lt;keyType&gt; &lt;keyData&gt;&apos;, e.g. ssh-rsa AAAABBBB.
    /// </summary>
    public BicepValue<string> Key 
    {
        get { Initialize(); return _key!; }
        set { Initialize(); _key!.Assign(value); }
    }
    private BicepValue<string>? _key;

    /// <summary>
    /// Creates a new StorageSshPublicKey.
    /// </summary>
    public StorageSshPublicKey()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of StorageSshPublicKey.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _description = DefineProperty<string>("Description", ["description"]);
        _key = DefineProperty<string>("Key", ["key"], isSecure: true);
    }
}
