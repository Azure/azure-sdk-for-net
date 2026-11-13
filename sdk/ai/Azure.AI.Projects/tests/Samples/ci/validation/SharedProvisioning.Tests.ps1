# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

. (Join-Path $PSScriptRoot '../SampleCiHelpers.ps1')

Describe 'Language-neutral infrastructure contract' {
    It 'creates a plan without Python, a sample manifest, or Azure access: <FutureBinding>' -TestCases @(
        @{ FutureBinding = $false }, @{ FutureBinding = $true }
    ) {
        param($FutureBinding)
        $previousSubscription = $env:AZURE_SUBSCRIPTION_ID
        $previousTenant = $env:AZURE_TENANT_ID
        try {
            $env:AZURE_SUBSCRIPTION_ID = '11111111-1111-1111-1111-111111111111'
            $env:AZURE_TENANT_ID = '22222222-2222-2222-2222-222222222222'
            $directory = Join-Path $TestDrive "dotnet-plan-$FutureBinding"
            $bundle = Join-Path $TestDrive "bundle-$FutureBinding"
            $infra = Join-Path $bundle 'infra'
            $null = New-Item -ItemType Directory -Path $infra -Force
            foreach ($name in @('New-ResourceDeploymentPlan.ps1', 'SampleCiHelpers.ps1')) {
                Copy-Item -LiteralPath (Join-Path $PSScriptRoot "../$name") -Destination $bundle
            }
            $template = Get-Content -LiteralPath (Join-Path $PSScriptRoot '../infra/main.bicep') -Raw
            if ($FutureBinding) {
                # Extend only Bicep; the copied shared scripts remain unchanged.
                $template = $template.Replace('output environment object = {',
                    "output environment object = {`n  NEW_RESOURCE_ENDPOINT: 'https://example.invalid/new'")
            }
            $template | Set-Content -LiteralPath (Join-Path $infra 'main.bicep') -Encoding utf8
            & {
                function az { throw 'Offline planning must not invoke Azure CLI.' }
                function python { throw 'Shared planning must not invoke Python.' }
                & (Join-Path $bundle 'New-ResourceDeploymentPlan.ps1') -OutputDirectory $directory `
                    -QueueName q1 -IdentityResourceGroup 'shared-identities' `
                    -DefinitionId $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' }) `
                    -BuildId $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' }) -JobAttempt 1
            }
            $plan = Get-Content -LiteralPath (Join-Path $directory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
            Assert-SampleRunPlan -Plan $plan
            $plan.Contains('selectedTests') | Should Be $false
            $plan.Contains('requiredEnvironment') | Should Be $false
            $plan.identityResolution | Should BeExactly 'Pending'
            ($plan.environmentBindings -contains 'NEW_RESOURCE_ENDPOINT') | Should Be $FutureBinding
            @($plan.environmentBindings).Count | Should Be (@(Get-SampleEnvironmentNames).Count + [int] $FutureBinding)
        } finally {
            $env:AZURE_SUBSCRIPTION_ID = $previousSubscription
            $env:AZURE_TENANT_ID = $previousTenant
        }
    }

    It 'discovers a future binding solely from an explicit Bicep output' {
        $path = Join-Path $TestDrive 'future.bicep'
        @'
output environment object = {
  NEW_RESOURCE_ENDPOINT: 'https://example.invalid/new'
}
'@ | Set-Content -LiteralPath $path -Encoding utf8
        $names = @(Get-SampleBicepEnvironmentNames -BicepPath $path)
        $names.Count | Should Be 1
        $names[0] | Should BeExactly 'NEW_RESOURCE_ENDPOINT'
        Assert-SampleEnvironment -Environment @{ NEW_RESOURCE_ENDPOINT = 'https://example.invalid/new' } -Names $names
    }

    It 'rejects malformed, missing, unexpected or secret-looking output bindings: <Label>' -TestCases @(
        @{ Label = 'missing'; Environment = @{}; Names = @('NEW_RESOURCE_ENDPOINT') },
        @{ Label = 'unexpected'; Environment = @{ OTHER = 'value' }; Names = @('NEW_RESOURCE_ENDPOINT') },
        @{ Label = 'empty'; Environment = @{ NEW_RESOURCE_ENDPOINT = '' }; Names = @('NEW_RESOURCE_ENDPOINT') },
        @{ Label = 'non-string'; Environment = @{ NEW_RESOURCE_ENDPOINT = 1 }; Names = @('NEW_RESOURCE_ENDPOINT') },
        @{ Label = 'secret'; Environment = @{ ACCESS_TOKEN = 'suppressed' }; Names = @('ACCESS_TOKEN') }
    ) {
        param($Label, $Environment, $Names)
        { Assert-SampleEnvironment -Environment $Environment -Names $Names } | Should Throw
    }

}
