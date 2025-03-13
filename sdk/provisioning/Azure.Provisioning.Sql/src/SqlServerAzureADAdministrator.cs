// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Sql;

// Customize the generated SqlServerAzureADAdministrator resource
public partial class SqlServerAzureADAdministrator
{
    private partial BicepValue<string> GetNameDefaultValue() =>
        new StringLiteralExpression("ActiveDirectory");
}
