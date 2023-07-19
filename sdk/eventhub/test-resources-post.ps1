# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# The purpose of this script is to add a small delay between the creation of the live test resources
# and the execution of the live tests. This allows RBAC to replicate and avoids flakiness in the first set 
# of live tests that might otherwise start running before RBAC has replicated.

param (
    [hashtable] $DeploymentOutputs,
    [string] $TenantId,
    [string] $TestApplicationId,
    [string] $TestApplicationSecret
)

Write-Verbose "Sleeping for 60 seconds to let RBAC replicate"
Start-Sleep -s 60
