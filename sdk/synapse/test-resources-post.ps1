# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# This script is used to generate the Test Configuration file for Storage live tests.
# It is invoked by the https://github.com/Azure/azure-sdk-for-net/blob/main/eng/New-TestResources.ps1
# script after the ARM template, defined in https://github.com/Azure/azure-sdk-for-net/blob/arm-template-storage/sdk/storage/test-resources.json, 
# is finished being deployed. The ARM template is responsible for creating the Storage accounts needed for live tests.

param (
    [hashtable] $DeploymentOutputs,
    [string] $TestApplicationOid,
    [switch] $CI
)

if ($CI) { exit }

Import-Module Az.Synapse

$roleAssignment = (Get-AzSynapseRoleAssignment -WorkspaceName $DeploymentOutputs.AZURE_SYNAPSE_WORKSPACE_NAME -ObjectId $TestApplicationOid)

if (!$roleAssignment) {
    New-AzSynapseRoleAssignment `
        -WorkspaceName $DeploymentOutputs.AZURE_SYNAPSE_WORKSPACE_NAME `
        -RoleDefinitionName "Synapse Administrator" `
        -ObjectId $TestApplicationOid
}