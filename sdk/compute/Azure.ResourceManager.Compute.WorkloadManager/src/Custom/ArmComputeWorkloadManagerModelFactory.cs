// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.WorkloadManager.Models
{
    [CodeGenSuppress("RuntimeBindingProperties", typeof(WorkloadManagerProvisioningState?), typeof(ResourceIdentifier), typeof(string), typeof(ExecutionIdentity), typeof(RuntimeNetworkProfile))]
    [CodeGenSuppress("ExecutionIdentity", typeof(string), typeof(ExecutionIdentityScope))]
    [CodeGenSuppress("ReferencedExecutionIdentity", typeof(ExecutionIdentityScope), typeof(ResourceIdentifier))]
    [CodeGenSuppress("ServiceManagedExecutionIdentity", typeof(ExecutionIdentityScope), typeof(ResourceIdentifier))]
    [CodeGenSuppress("ManagedRuntimeBindingProperties", typeof(WorkloadManagerProvisioningState?), typeof(ResourceIdentifier), typeof(ExecutionIdentity), typeof(RuntimeNetworkProfile), typeof(ManagedRuntimeProfile))]
    [CodeGenSuppress("ReferencedRuntimeBindingProperties", typeof(WorkloadManagerProvisioningState?), typeof(ResourceIdentifier), typeof(ExecutionIdentity), typeof(RuntimeNetworkProfile), typeof(ResourceIdentifier))]
    public static partial class ArmComputeWorkloadManagerModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.RuntimeBindingProperties"/>. </summary>
        public static RuntimeBindingProperties RuntimeBindingProperties(WorkloadManagerProvisioningState? provisioningState = default, ResourceIdentifier providerResourceId = default, string provisioningMode = default, ExecutionIdentity executionIdentity = default, RuntimeNetworkProfile networkProfile = default)
        {
            return new UnknownRuntimeBindingProperties(
                provisioningState,
                providerResourceId,
                provisioningMode,
                executionIdentity is null ? default : new RuntimeIdentityProfile(executionIdentity, default),
                networkProfile,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ExecutionIdentity"/>. </summary>
        public static ExecutionIdentity ExecutionIdentity(string provisioningMode = default, ExecutionIdentityScope scope = default)
        {
            return new UnknownExecutionIdentity(provisioningMode, scope, default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ReferencedExecutionIdentity"/>. </summary>
        public static ReferencedExecutionIdentity ReferencedExecutionIdentity(ExecutionIdentityScope scope = default, ResourceIdentifier userAssignedIdentityResourceId = default)
        {
            return new ReferencedExecutionIdentity(ExecutionIdentityProvisioningMode.Referenced, scope, default, userAssignedIdentityResourceId);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ServiceManagedExecutionIdentity"/>. </summary>
        public static ServiceManagedExecutionIdentity ServiceManagedExecutionIdentity(ExecutionIdentityScope scope = default, ResourceIdentifier userAssignedIdentityResourceId = default)
        {
            return new ServiceManagedExecutionIdentity(ExecutionIdentityProvisioningMode.ServiceManaged, scope, default, userAssignedIdentityResourceId);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ManagedRuntimeBindingProperties"/>. </summary>
        public static ManagedRuntimeBindingProperties ManagedRuntimeBindingProperties(WorkloadManagerProvisioningState? provisioningState = default, ResourceIdentifier providerResourceId = default, ExecutionIdentity executionIdentity = default, RuntimeNetworkProfile networkProfile = default, ManagedRuntimeProfile managedProfile = default)
        {
            return new ManagedRuntimeBindingProperties(
                provisioningState,
                providerResourceId,
                RuntimeBindingProvisioningMode.Managed,
                executionIdentity is null ? default : new RuntimeIdentityProfile(executionIdentity, default),
                networkProfile,
                default,
                managedProfile);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ReferencedRuntimeBindingProperties"/>. </summary>
        public static ReferencedRuntimeBindingProperties ReferencedRuntimeBindingProperties(WorkloadManagerProvisioningState? provisioningState = default, ResourceIdentifier providerResourceId = default, ExecutionIdentity executionIdentity = default, RuntimeNetworkProfile networkProfile = default, ResourceIdentifier resourceId = default)
        {
            return new ReferencedRuntimeBindingProperties(
                provisioningState,
                providerResourceId,
                RuntimeBindingProvisioningMode.Referenced,
                executionIdentity is null ? default : new RuntimeIdentityProfile(executionIdentity, default),
                networkProfile,
                default,
                resourceId);
        }
    }
}
