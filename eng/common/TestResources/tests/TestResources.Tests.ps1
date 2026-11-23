# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    . "$PSScriptRoot/../SubConfig-Helpers.ps1"
    function Log($Message) {}

    $script:deploymentAst = [System.Management.Automation.Language.Parser]::ParseFile(
        "$PSScriptRoot/../New-TestResources.ps1", [ref]$null, [ref]$null)
    $normalization = $deploymentAst.Find({
        param($node)
        $node -is [System.Management.Automation.Language.IfStatementAst] -and
        $node.Clauses[0].Item1.Extent.Text -eq '!$PSBoundParameters.ContainsKey(''ResourceGroupName'')'
    }, $true)
    $script:normalizeName = [scriptblock]::Create(@"
param([string] `$ResourceGroupName, [string] `$GeneratedName)
if (!`$ResourceGroupName) {
    `$ResourceGroupName = `$GeneratedName
}
$($normalization.Extent.Text)
return `$ResourceGroupName
"@)

    $assignments = $deploymentAst.FindAll({
        param($node)
        $node -is [System.Management.Automation.Language.AssignmentStatementAst] -and
        $node.Left.Extent.Text -in '$PSBoundParameters[''TenantId'']', '$PSBoundParameters[''Environment'']'
    }, $true)
    $script:hookParameters = [scriptblock]::Create(@"
param([string] `$TenantId = `$resolvedTenantId, [string] `$Environment = 'AzureCloud')
$(($assignments | ForEach-Object { $_.Extent.Text }) -join "`n")
return `$PSBoundParameters
"@)
}

Describe 'Test resource group names' {
    It 'Preserves explicit names including names longer than 90 characters' -ForEach @(
        @{ Name = 'rg-example' }
        @{ Name = ('rg-' + ('a' * 90)) }
    ) {
        $wellKnownTMETenants = @('70a036f6-8e4d-4615-bad6-149c02e7720d')
        $TenantId = $wellKnownTMETenants[0]
        $SubscriptionId = '4d042dc6-fe17-4698-a23f-ec6a8d1e98f4'

        $ResourceGroupName = & $normalizeName -ResourceGroupName $Name

        $ResourceGroupName | Should -BeExactly $Name
    }

    It 'Normalizes only generated names for the selected tenant or subscription' -ForEach @(
        @{ Tenant = '70a036f6-8e4d-4615-bad6-149c02e7720d'; Subscription = ''; Name = 'rg-example'; Expected = 'SSS3PT_rg-example' }
        @{ Tenant = ''; Subscription = '4d042dc6-fe17-4698-a23f-ec6a8d1e98f4'; Name = 'rg-example'; Expected = 'SSS3PT_rg-example' }
        @{ Tenant = ''; Subscription = ''; Name = 'rg-example'; Expected = 'rg-example' }
        @{ Tenant = '70a036f6-8e4d-4615-bad6-149c02e7720d'; Subscription = ''; Name = 'sss3pt_rg-example'; Expected = 'sss3pt_rg-example' }
        @{ Tenant = '70a036f6-8e4d-4615-bad6-149c02e7720d'; Subscription = ''; Name = ('rg-' + ('a' * 90)); Expected = ('SSS3PT_rg-' + ('a' * 80)) }
    ) {
        $wellKnownTMETenants = @('70a036f6-8e4d-4615-bad6-149c02e7720d')
        $TenantId = $Tenant
        $SubscriptionId = $Subscription

        $ResourceGroupName = & $normalizeName -GeneratedName $Name

        $ResourceGroupName | Should -BeExactly $Expected
    }

    It 'Preserves explicit names when resolving update and removal names' {
        $null, $group = GetBaseAndResourceGroupNames -resourceGroupNameDefault 'rg-example' -user 'tester' -CI $false

        $group | Should -BeExactly 'rg-example'
    }
}

Describe 'Deployment hook parameters' {
    It 'Passes resolved tenant and default or explicit environment values' -ForEach @(
        @{ Parameters = @{}; Cloud = 'AzureCloud' }
        @{ Parameters = @{ Environment = 'AzureUSGovernment' }; Cloud = 'AzureUSGovernment' }
    ) {
        $resolvedTenantId = '70a036f6-8e4d-4615-bad6-149c02e7720d'

        $boundParameters = & $hookParameters @Parameters

        $boundParameters['TenantId'] | Should -BeExactly $resolvedTenantId
        $boundParameters['Environment'] | Should -BeExactly $Cloud
    }
}
