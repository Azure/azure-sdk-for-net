// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.AppService;

public partial class SlotConfigNames : ProvisionableResource
{
    // for backward compatibility, this resource has a non-settable name.
    /// <summary>
    /// Gets the Name.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
    }
    /// <summary>
    /// Get the default value for the Name property.
    /// </summary>
    private partial BicepValue<string> GetNameDefaultValue() =>
        new StringLiteralExpression("slotConfigNames");
}
