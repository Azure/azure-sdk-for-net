﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Storage;

// Customize the generated FileService resource.
public partial class QueueService
{
    /// <summary>
    /// Get the default value for the Name property.
    /// </summary>
    private partial BicepValue<string> GetNameDefaultValue() =>
        new StringLiteralExpression("default");

    /// <summary>
    /// Gets the Name.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
    }
}
