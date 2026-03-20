// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// Error Response.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Renamed
public partial class ErrorResponse : ProvisionableConstruct
{
    private CosmosDBErrorResult _errorResult;

    /// <summary>
    /// Error code.
    /// </summary>
    public BicepValue<string> Code => _errorResult.Code;

    /// <summary>
    /// Error message indicating why the operation failed.
    /// </summary>
    public BicepValue<string> Message => _errorResult.Message;

    /// <summary>
    /// Creates a new ErrorResponse.
    /// </summary>
    public ErrorResponse() { _errorResult = new(); }

    internal ErrorResponse(CosmosDBErrorResult errorResult)
    {
        _errorResult = errorResult;
    }
}
