// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// The properties used to create a new server.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServer with AdministratorLogin and AdministratorLoginPassword instead.")]
public partial class PostgreSqlServerPropertiesForDefaultCreate : PostgreSqlServerPropertiesForCreate
{
    /// <summary>
    /// The administrator&apos;s login name of a server. Can only be specified
    /// when the server is being created (and is required for creation).
    /// </summary>
    public BicepValue<string> AdministratorLogin
    {
        get { Initialize(); return _administratorLogin!; }
    }
    private BicepValue<string> _administratorLogin;

    /// <summary>
    /// The password of the administrator login.
    /// </summary>
    public BicepValue<string> AdministratorLoginPassword
    {
        get { Initialize(); return _administratorLoginPassword!; }
    }
    private BicepValue<string> _administratorLoginPassword;

    /// <summary>
    /// Creates a new PostgreSqlServerPropertiesForDefaultCreate.
    /// </summary>
    public PostgreSqlServerPropertiesForDefaultCreate() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// PostgreSqlServerPropertiesForDefaultCreate.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("createMode", ["createMode"], defaultValue: "Default");
        _administratorLogin = DefineProperty<string>("AdministratorLogin", ["administratorLogin"], isOutput: true);
        _administratorLoginPassword = DefineProperty<string>("AdministratorLoginPassword", ["administratorLoginPassword"], isOutput: true);
    }
}
