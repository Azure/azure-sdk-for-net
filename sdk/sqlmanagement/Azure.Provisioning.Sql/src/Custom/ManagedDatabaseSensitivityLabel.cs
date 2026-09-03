// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.Sql;

public partial class ManagedDatabaseSensitivityLabel
{
    // This resource is writable, but its PUT operation is not currently associated with the
    // resource. See https://github.com/Azure/azure-sdk-for-net/issues/62598.
    /// <summary> Creates a new ManagedDatabaseSensitivityLabel. </summary>
    /// <param name="bicepIdentifier"> The bicep identifier name. </param>
    /// <param name="resourceVersion"> The resource API version. </param>
    public ManagedDatabaseSensitivityLabel(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, "Microsoft.Sql/managedInstances/databases/schemas/tables/columns/sensitivityLabels", resourceVersion ?? "2025-01-01")
    {
    }
}
