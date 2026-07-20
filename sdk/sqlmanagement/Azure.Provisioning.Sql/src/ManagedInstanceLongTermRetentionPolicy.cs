// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Sql;

public partial class ManagedInstanceLongTermRetentionPolicy
{
    private partial BicepValue<string> GetNameDefaultValue() =>
        "default";
}
