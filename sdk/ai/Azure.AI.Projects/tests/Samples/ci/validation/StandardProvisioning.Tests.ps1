# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2
# cspell:ignore DEFINITIONID BUILDID

Describe 'Standard Foundry provisioning contract' {
    BeforeEach {
        $script:originalSubscription = $env:AZURE_SUBSCRIPTION_ID
        $script:originalTenant = $env:AZURE_TENANT_ID
        $script:originalPat = $env:MCP_GITHUB_PAT
        $env:AZURE_SUBSCRIPTION_ID = '11111111-1111-1111-1111-111111111111'
        $env:AZURE_TENANT_ID = '22222222-2222-2222-2222-222222222222'
        $env:MCP_GITHUB_PAT = $null
        $script:outputDirectory = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
        $script:planArguments = @{
            OutputDirectory = $script:outputDirectory
            QueueName = 'q1'
            IdentityResourceGroup = 'shared-identities'
            DefinitionId = $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' })
            BuildId = $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' })
            JobAttempt = '1'
        }
        $script:provisionArguments = @{
            OutputDirectory = $script:outputDirectory
            QueueName = 'q1'
            IdentityResourceGroup = 'shared-identities'
            ModelName = 'gpt-5.2'
            ModelVersion = '2025-12-11'
            ModelSku = 'GlobalStandard'
            ModelCapacity = 10
        }
    }

    AfterEach {
        $env:AZURE_SUBSCRIPTION_ID = $script:originalSubscription
        $env:AZURE_TENANT_ID = $script:originalTenant
        $env:MCP_GITHUB_PAT = $script:originalPat
    }

    It 'plans only Standard and model environment bindings without Azure or a PAT' {
        & {
            function az { throw 'Offline planning must not contact Azure.' }
            & (Join-Path $PSScriptRoot '../New-ResourceDeploymentPlan.ps1') @script:planArguments -StandardOnly
        }
        $plan = Get-Content -LiteralPath (Join-Path $script:outputDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        ($plan.environmentBindings -join ',') | Should BeExactly (
            'AZURE_RESOURCE_GROUP,AZURE_SUBSCRIPTION_ID,AZURE_TENANT_ID,FOUNDRY_AGENT_NAME,FOUNDRY_MODEL_NAME,FOUNDRY_PROJECT_ENDPOINT')
        $plan.identityResolution | Should BeExactly 'Pending'
        $plan.sharedIdentities.Count | Should Be 0
    }

    It 'preserves the full-bundle planner default for existing callers' {
        & (Join-Path $PSScriptRoot '../New-ResourceDeploymentPlan.ps1') @script:planArguments
        $plan = Get-Content -LiteralPath (Join-Path $script:outputDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        $plan.environmentBindings -contains 'FUNCTION_APP_NAME' | Should Be $true
        $plan.environmentBindings -contains 'MCP_PROJECT_CONNECTION_ID' | Should Be $true
    }

    It 'requires explicit confirmation before creating state or calling Azure' {
        & {
            function az { throw 'Unconfirmed provisioning must not contact Azure.' }
            { & (Join-Path $PSScriptRoot '../Invoke-StandardProvisioning.ps1') @script:provisionArguments } |
                Should Throw '-ConfirmProvisioning'
        }
        Test-Path -LiteralPath $script:outputDirectory | Should Be $false
    }

    It 'rejects existing output before contacting Azure or overwriting state' {
        $null = New-Item -ItemType Directory -Path $script:outputDirectory
        $statePath = Join-Path $script:outputDirectory 'deployment-state.json'
        Set-Content -LiteralPath $statePath -Value 'previous-attempt'
        & {
            function az { throw 'Existing state must not cause Azure operations.' }
            { & (Join-Path $PSScriptRoot '../Invoke-StandardProvisioning.ps1') @script:provisionArguments -ConfirmProvisioning } |
                Should Throw 'earlier attempt'
        }
        (Get-Content -LiteralPath $statePath -Raw).Trim() | Should BeExactly 'previous-attempt'
    }
}
