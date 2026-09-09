// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#nullable enable

using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Sql;

/// <summary>
/// Contains the information necessary to perform a create database restore
/// point operation.
/// </summary>
public partial class CreateDatabaseRestorePointDefinition : ProvisionableConstruct
{
    private BicepValue<string>? _restorePointLabel;

    /// <summary>
    /// Creates a new CreateDatabaseRestorePointDefinition.
    /// </summary>
    public CreateDatabaseRestorePointDefinition()
    {
    }

    /// <summary>
    /// The restore point label to apply.
    /// </summary>
    public BicepValue<string> RestorePointLabel
    {
        get
        {
            Initialize();
            return _restorePointLabel!;
        }
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// CreateDatabaseRestorePointDefinition.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _restorePointLabel = DefineProperty<string>(nameof(RestorePointLabel), new string[] { "restorePointLabel" }, isOutput: true);
    }
}
