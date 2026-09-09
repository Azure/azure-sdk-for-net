// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only data transfer API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// Error Response.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class CosmosDBErrorResult : ProvisionableConstruct
{
    private BicepValue<string>? _code;
    private BicepValue<string>? _message;

    /// <summary>
    /// Error code.
    /// </summary>
    public BicepValue<string> Code
    {
        get { Initialize(); return _code!; }
    }

    /// <summary>
    /// Error message indicating why the operation failed.
    /// </summary>
    public BicepValue<string> Message
    {
        get { Initialize(); return _message!; }
    }

    /// <summary>
    /// Creates a new CosmosDBErrorResult.
    /// </summary>
    public CosmosDBErrorResult()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of CosmosDBErrorResult.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _code = DefineProperty<string>("Code", ["code"], isOutput: true);
        _message = DefineProperty<string>("Message", ["message"], isOutput: true);
    }
}
