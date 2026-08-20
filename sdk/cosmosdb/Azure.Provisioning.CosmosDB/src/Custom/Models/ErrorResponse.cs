// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class ErrorResponse : ProvisionableConstruct
{
    private CosmosDBErrorResult _errorResult;

    public BicepValue<string> Code => _errorResult.Code;
    public BicepValue<string> Message => _errorResult.Message;

    public ErrorResponse()
    {
        _errorResult = new();
    }

    internal ErrorResponse(CosmosDBErrorResult errorResult)
    {
        _errorResult = errorResult;
    }
}
