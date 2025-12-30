#! /bin/env pwsh

# Not defining a default parameter set makes SkipLogin/Subscription required all the time.
[CmdletBinding(DefaultParameterSetName = 'Default')]
param(
    [string]$SearchDirectory,
    [hashtable]$Filters,
    [string]$Environment,
    [string]$Repository,
    [switch]$SkipPushImages,
    [string]$ClusterGroup,
    [string]$DeployId,
    [switch]$SkipLogin,
    [string]$Subscription,
    [string]$Tenant,

    # Default to true in Azure Pipelines environments
    [switch] $CI = ($null -ne $env:SYSTEM_TEAMPROJECTID),

    # Optional namespace override, otherwise the shell user or chart annotation will be used
    [string]$Namespace,

    # Override remote stress-test-addons with local on-disk addons for development
    [System.IO.FileInfo]$LocalAddonsPath,

    # Renders chart templates locally without deployment
    [Parameter(Mandatory=$False)][switch]$Template,

    [Parameter(Mandatory=$False)][switch]$RetryFailedTests,

    # Matrix generation parameters
    [Parameter(Mandatory=$False)][string]$MatrixFileName,
    [Parameter(Mandatory=$False)][string]$MatrixSelection,
    [Parameter(Mandatory=$False)][string]$MatrixDisplayNameFilter,
    [Parameter(Mandatory=$False)][array]$MatrixFilters,
    [Parameter(Mandatory=$False)][array]$MatrixReplace,
    [Parameter(Mandatory=$False)][array]$MatrixNonSparseParameters,

    # Prevent kubernetes from deleting nodes or rebalancing pods related to this test for N days
    [Parameter(Mandatory=$False)][ValidateRange(1, 14)][int]$LockDeletionForDays
)

. $PSScriptRoot/stress-test-deployment-lib.ps1

# If there are local changes to values.yaml it's almost certain that the user
# is an admin and has provisioned a new stress cluster but not published a
# new addons chart with the new infra config values. In these cases we should
# just fail, as deploying without the local addons override causes misleading
# errors in the cluster with pods not able to mount storage accounts using the
# old values.yaml reference from the published stress-test-addons helm chart.
if (!$LocalAddonsPath) {
    try {
        $repoRoot = git -C $PSScriptRoot rev-parse --show-toplevel 2>$null
    } catch {
        $repoRoot = $null
    }

    if ($repoRoot -and (Split-Path $repoRoot -Leaf) -eq "azure-sdk-tools") {
        $valuesFile = Join-Path $repoRoot "tools/stress-cluster/cluster/kubernetes/stress-test-addons/values.yaml"
        if (Test-Path $valuesFile) {
            $valuesStatus = git -C $repoRoot status --porcelain -- $valuesFile
            if ($valuesStatus) {
                $localAddonsDir = Split-Path $valuesFile -Parent
                throw "Detected changes to '$valuesFile' without -LocalAddonsPath. Re-run with '-LocalAddonsPath $localAddonsDir' to apply local addon values."
            }
        }
    }
}

CheckDependencies
DeployStressTests @PSBoundParameters
