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

Describe 'Pipeline sample selection contract' {
    It 'retains the six-sample default without hardcoded worker assignments' {
        $pipeline = Get-Content -LiteralPath (Join-Path $PSScriptRoot '../../../../tests.yml') -Raw
        $selectionParameter = [regex]::Match(
            $pipeline, '(?ms)^  - name: selection\r?\n.*?(?=^  - name:|\z)').Value
        $selectionNames = @([regex]::Matches($selectionParameter, '\bName=([A-Za-z0-9_]+)') |
            ForEach-Object { $_.Groups[1].Value } | Sort-Object)
        ($selectionNames -join ',') | Should BeExactly 'AgentCRUD,AgentResponseStreamingSync,AgentResponseSync,AgentsBasics,DeploymentExample,VersionSelection'
        $pipeline | Should Not Match 'sample-slice-matrix|SampleSliceFilter|MatrixConfigs'
        $pipeline | Should Match 'sample-tests-stages.yml'
    }

    It 'opts into task-scoped CLI authentication while retaining the default test tasks' {
        $pipeline = Get-Content -LiteralPath (Join-Path $PSScriptRoot '../../../../tests.yml') -Raw
        $stages = Get-Content -LiteralPath (Join-Path $PSScriptRoot '../sample-tests-stages.yml') -Raw
        $stages | Should Match 'UseAzureCliForTests: true'
        $stages | Should Match 'ServiceConnection: azure-sdk-tests'
        $template = Get-Content -LiteralPath (
            Join-Path $PSScriptRoot '../../../../../../../eng/pipelines/templates/jobs/live.tests.yml') -Raw
        $cliBranch = [regex]::Match(
            $template,
            '(?ms)^      - \$\{\{ if eq\(parameters.CloudConfig.UseAzureCliForTests, true\) \}\}:(?<step>.*?)^      - \$\{\{ elseif')
        $cliBranch.Success | Should Be $true
        $cliBranch.Groups['step'].Value | Should Match 'task: AzureCLI@2'
        $cliBranch.Groups['step'].Value | Should Match '\$env:AZURE_TOKEN_CREDENTIALS = ''AzureCliCredential'''
        $cliBranch.Groups['step'].Value | Should Match 'dotnet test eng/service.proj'
        $cliBranch.Groups['step'].Value | Should Match 'SYSTEM_ACCESSTOKEN: \$\(System.AccessToken\)'
        $template | Should Match 'elseif eq\(''true'', parameters.UseFederatedAuth\)'
        $template | Should Match 'task: AzurePowerShell@5'
    }

    It 'defaults to a model compatible with the classic Agents sample' {
        $pipeline = Get-Content -LiteralPath (Join-Path $PSScriptRoot '../../../../tests.yml') -Raw
        $modelNameParameter = [regex]::Match(
            $pipeline, '(?ms)^  - name: modelName\r?\n.*?(?=^  - name:|\z)').Value
        $modelVersionParameter = [regex]::Match(
            $pipeline, '(?ms)^  - name: modelVersion\r?\n.*?(?=^  - name:|\z)').Value
        $modelNameParameter | Should Match '(?m)^    default: gpt-4\.1\r?$'
        $modelVersionParameter | Should Match "(?m)^    default: '2025-04-14'\r?$"
    }

    It 'plans before provisioning and downloads exact per-worker assignments' {
        $stages = Get-Content -LiteralPath (Join-Path $PSScriptRoot '../sample-tests-stages.yml') -Raw
        $stages | Should Match 'dependsOn: Plan'
        $stages | Should Match "Matrix: stageDependencies.Plan.Plan.outputs\['Discover.WorkerMatrix'\]"
        $stages | Should Match 'New-SampleTestPlan.ps1'
        $stages | Should Match 'DownloadPipelineArtifact@2'
        $stages | Should Match 'buildType: current'
        $stages | Should Match 'task.setvariable variable=AdditionalTestFilters'
        $stages | Should Not Match 'task.setvariable variable=SampleSliceFilter'
    }
}
