// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Preserve the legacy error wrapper used by the preview-only data transfer API.
/// <summary>
/// Error response.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class ErrorResponse : ProvisionableConstruct
{
    private CosmosDBErrorResult _errorResult;

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public BicepValue<string> Code => _errorResult.Code;

    /// <summary>
    /// Gets the error message indicating why the operation failed.
    /// </summary>
    public BicepValue<string> Message => _errorResult.Message;

    /// <summary>
    /// Creates a new ErrorResponse.
    /// </summary>
    public ErrorResponse()
    {
        _errorResult = new();
    }

    internal ErrorResponse(CosmosDBErrorResult errorResult)
    {
        _errorResult = errorResult;
    }
}
