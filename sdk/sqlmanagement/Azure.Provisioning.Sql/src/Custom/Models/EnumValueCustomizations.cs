// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// Preserve enum ordinals from Azure.Provisioning.Sql 1.1.0. TypeSpec generation
// orders these values differently, which would change their underlying integers.
[assembly: CodeGenEnumValue("DataMaskingState", "Disabled", 0)]
[assembly: CodeGenEnumValue("DataMaskingState", "Enabled", 1)]
[assembly: CodeGenEnumValue("GeoBackupPolicyState", "Disabled", 0)]
[assembly: CodeGenEnumValue("GeoBackupPolicyState", "Enabled", 1)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Creating", 0)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Deleting", 1)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Updating", 2)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Unknown", 3)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Succeeded", 4)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Failed", 5)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Accepted", 6)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Created", 7)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Deleted", 8)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Unrecognized", 9)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Running", 10)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Canceled", 11)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "NotSpecified", 12)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "Registering", 13)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "TimedOut", 14)]
[assembly: CodeGenEnumValue("ManagedInstancePropertiesProvisioningState", "InProgress", 15)]
