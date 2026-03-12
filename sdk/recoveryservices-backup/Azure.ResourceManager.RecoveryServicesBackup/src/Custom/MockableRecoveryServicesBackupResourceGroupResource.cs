// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesBackup.Mocking
{
    // Suppress duplicate GetAllAsync/GetAll(string, string, string, CancellationToken) overloads
    // (BackupManagementUsage, ProtectedItemResource, WorkloadProtectableItemResource, ProtectableContainerResource)
    // that collide with the ProtectionIntentResource variants.
    [CodeGenSuppress("GetAllAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    // Suppress duplicate GetAsync/Get(string, string, CancellationToken) overloads
    // (OperationStatus, TieringCostInfo, non-generic Response) that collide with the ValidateOperationsResponse variants.
    [CodeGenSuppress("GetAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(string), typeof(string), typeof(CancellationToken))]
    // Suppress duplicate GetAllAsync/GetAll(string, string, CancellationToken) overloads
    // (DeletedProtectionContainers) that collide with BackupProtectionContainers variants.
    [CodeGenSuppress("GetAllAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class MockableRecoveryServicesBackupResourceGroupResource
    {
    }
}
