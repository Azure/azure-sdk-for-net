// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore the legacy additional-properties dictionary for API compatibility.
// Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/60666
public partial class CosmosDBServiceProperties
{
    private BicepDictionary<BinaryData> _additionalProperties = new();

    /// <summary>
    /// Gets or sets additional service properties.
    /// </summary>
    /// <remarks>
    /// This compatibility property does not currently represent TypeSpec spread
    /// properties correctly and is not recommended for use.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepDictionary<BinaryData> AdditionalProperties
    {
        get
        {
            Initialize();
            return _additionalProperties;
        }
        set
        {
            Initialize();
            _additionalProperties.Assign(value);
        }
    }
}
