// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.ServiceBus;

// Customize the generated MigrationConfiguration resource
public partial class MigrationConfiguration
{
    private partial BicepValue<string> GetNameDefaultValue() =>
        new StringLiteralExpression("$default");
}
