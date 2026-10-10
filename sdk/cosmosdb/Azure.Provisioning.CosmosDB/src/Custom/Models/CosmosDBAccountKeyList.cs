// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore the result model required by the legacy CosmosDBAccount.GetKeys API, which
// is not projected by the current provisioning generator.
/// <summary>
/// The access keys for the given database account.
/// </summary>
public partial class CosmosDBAccountKeyList : ProvisionableConstruct
{
    private BicepValue<string> _primaryMasterKey;
    private BicepValue<string> _secondaryMasterKey;
    private BicepValue<string> _primaryReadonlyMasterKey;
    private BicepValue<string> _secondaryReadonlyMasterKey;

    /// <summary>
    /// Base 64 encoded value of the primary read-write key.
    /// </summary>
    public BicepValue<string> PrimaryMasterKey
    {
        get { Initialize(); return _primaryMasterKey; }
    }

    /// <summary>
    /// Base 64 encoded value of the secondary read-write key.
    /// </summary>
    public BicepValue<string> SecondaryMasterKey
    {
        get { Initialize(); return _secondaryMasterKey; }
    }

    /// <summary>
    /// Base 64 encoded value of the primary read-only key.
    /// </summary>
    public BicepValue<string> PrimaryReadonlyMasterKey
    {
        get { Initialize(); return _primaryReadonlyMasterKey; }
    }

    /// <summary>
    /// Base 64 encoded value of the secondary read-only key.
    /// </summary>
    public BicepValue<string> SecondaryReadonlyMasterKey
    {
        get { Initialize(); return _secondaryReadonlyMasterKey; }
    }

    /// <summary>
    /// Creates a new CosmosDBAccountKeyList.
    /// </summary>
    public CosmosDBAccountKeyList()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of CosmosDBAccountKeyList.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _primaryMasterKey = DefineProperty<string>("PrimaryMasterKey", new string[] { "primaryMasterKey" }, isOutput: true, isSecure: true);
        _secondaryMasterKey = DefineProperty<string>("SecondaryMasterKey", new string[] { "secondaryMasterKey" }, isOutput: true, isSecure: true);
        _primaryReadonlyMasterKey = DefineProperty<string>("PrimaryReadonlyMasterKey", new string[] { "primaryReadonlyMasterKey" }, isOutput: true, isSecure: true);
        _secondaryReadonlyMasterKey = DefineProperty<string>("SecondaryReadonlyMasterKey", new string[] { "secondaryReadonlyMasterKey" }, isOutput: true, isSecure: true);
    }
}
