# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

. (Join-Path $PSScriptRoot '../SampleTestPlanHelpers.ps1')
. (Join-Path $PSScriptRoot '../shared/SampleCiHelpers.ps1')
. (Join-Path $PSScriptRoot '../DotNetSampleCiHelpers.ps1')

Describe 'Offline deployment-plan defaults' {
    BeforeEach {
        $script:originalSubscription = $env:AZURE_SUBSCRIPTION_ID
        $script:originalTenant = $env:AZURE_TENANT_ID
        $script:originalQueue = $env:SAMPLE_QUEUE_NAME
        $env:AZURE_SUBSCRIPTION_ID = '11111111-1111-1111-1111-111111111111'
        $env:AZURE_TENANT_ID = '22222222-2222-2222-2222-222222222222'
        $env:SAMPLE_QUEUE_NAME = 'q1'
        $script:planDirectory = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
        $manifest = Join-Path $TestDrive 'selected-tests.json'
        $agents = @{
            package = 'Azure.AI.Projects'
            fullName = 'Azure.AI.Projects.Tests.Samples.Sample_AIAgents(False).AgentsBasics'
            name = 'AgentsBasics'
        }
        $function = @{
            package = 'Azure.AI.Extensions.OpenAI'
            fullName = 'Azure.AI.Extensions.OpenAI.Tests.Samples.Sample_AzureFunction(False).AzureFunction'
            name = 'AzureFunction'
        }
        $script:agentsAssignment = (New-SampleQueuePlan -Tests $agents -Pool unit -Image unit).queues.q1
        $script:functionAssignment = (New-SampleQueuePlan -Tests $function -Pool unit -Image unit).queues.q1
        $script:agentsAssignment | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $manifest -Encoding utf8
        $script:planArguments = @{
            SelectionManifest = $manifest
            OutputDirectory = $script:planDirectory
            QueueName = 'q1'
            DefinitionId = $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' })
            BuildId = $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' })
            JobAttempt = '1'
            IdentityResourceGroup = 'rg-azsdk-identities-westus3-102826_164519'
        }
        $script:planScript = Join-Path $PSScriptRoot '../New-SampleDeploymentPlan.ps1'
    }
    AfterEach {
        $env:AZURE_SUBSCRIPTION_ID = $script:originalSubscription
        $env:AZURE_TENANT_ID = $script:originalTenant
        $env:SAMPLE_QUEUE_NAME = $script:originalQueue
    }

    It 'defaults to the proven West US 3 GPT-5.2 version without contacting Azure' {
        & {
            function az { throw 'Offline planning must not contact Azure.' }
            & $script:planScript @script:planArguments
        }
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        $plan.location | Should BeExactly ''
        $plan.identityResolution | Should BeExactly 'Pending'
        $plan.sharedIdentities.Count | Should Be 0
        $plan.identityResourceGroup | Should BeExactly 'rg-azsdk-identities-westus3-102826_164519'
        $plan.ContainsKey('identityNamePattern') | Should Be $false
        $plan.ContainsKey('projectIdentityName') | Should Be $false
        $plan.sampleModel.name | Should Be 'gpt-5.2'
        $plan.sampleModel.version | Should Be '2025-12-11'
        $plan.sampleModel.sku | Should Be 'GlobalStandard'
        $plan.sampleModel.capacity | Should Be 10
        $plan.subscriptionId | Should Be $env:AZURE_SUBSCRIPTION_ID
        $plan.tenantId | Should Be $env:AZURE_TENANT_ID
    }

    It 'retains auto as an explicit model-version override' {
        & $script:planScript @script:planArguments -ModelVersion auto
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        $plan.sampleModel.version | Should Be 'auto'
    }

    It 'plans the registered Azure Function sample with all queue bindings without contacting Azure' {
        $script:functionAssignment | ConvertTo-Json -Depth 5 |
            Set-Content -LiteralPath $script:planArguments.SelectionManifest -Encoding utf8
        & {
            function az { throw 'Offline planning must not contact Azure.' }
            & $script:planScript @script:planArguments
        }
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        @($plan.selectedTests).Count | Should Be 1
        foreach ($field in @('package', 'fullName', 'name')) {
            $plan.selectedTests[0][$field] | Should BeExactly $script:functionAssignment.selectedTests[0][$field]
        }
        $plan.filter | Should BeExactly $script:functionAssignment.filter
        foreach ($name in @('STORAGE_INPUT_QUEUE_NAME', 'STORAGE_OUTPUT_QUEUE_NAME', 'STORAGE_QUEUE_SERVICE_ENDPOINT')) {
            $plan.environmentBindings -contains $name | Should Be $true
        }
        $environment = @{}
        foreach ($name in $plan.environmentBindings) { $environment[$name] = 'test-value' }
        $environment.STORAGE_QUEUE_SERVICE_ENDPOINT = 'https://storage.queue.core.windows.net/'
        $bindings = Get-DotNetSampleEnvironment -Environment $environment
        $bindings.STORAGE_QUEUE_URI | Should BeExactly 'https://storage.queue.core.windows.net'
        $bindings.STORAGE_INPUT_QUEUE_NAME | Should BeExactly $environment.STORAGE_INPUT_QUEUE_NAME
        $bindings.STORAGE_OUTPUT_QUEUE_NAME | Should BeExactly $environment.STORAGE_OUTPUT_QUEUE_NAME
    }

    It 'includes all Function bindings even for the AgentsBasics selection' {
        & $script:planScript @script:planArguments
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        $functionBindings = @('FUNCTION_APP_NAME', 'FUNCTION_APP_URL', 'STORAGE_INPUT_QUEUE_NAME',
            'STORAGE_OUTPUT_QUEUE_NAME', 'STORAGE_QUEUE_SERVICE_ENDPOINT')
        foreach ($name in $functionBindings) {
            $plan.environmentBindings -contains $name | Should Be $true
        }
    }

    It 'deploys and publishes the Function App outside sample-selection conditions' {
        $tokens = $null
        $parseErrors = $null
        $path = (Resolve-Path (Join-Path $PSScriptRoot '../shared/Invoke-ResourceProvisioning.ps1')).Path
        $ast = [System.Management.Automation.Language.Parser]::ParseFile($path, [ref] $tokens, [ref] $parseErrors)
        $parseErrors.Count | Should Be 0
        $commands = @($ast.FindAll({
            param($node)
            $node -is [System.Management.Automation.Language.CommandAst] -and (
                $node.GetCommandName() -eq 'Publish-SampleFunctionApp' -or
                ($node.GetCommandName() -eq 'Invoke-SampleAzure' -and
                    $node.Extent.Text.Contains('-Arguments $bundleArguments'))
            )
        }, $true))
        $commands.Count | Should Be 2
        foreach ($command in $commands) {
            for ($parent = $command.Parent; $null -ne $parent; $parent = $parent.Parent) {
                ($parent -is [System.Management.Automation.Language.IfStatementAst]) | Should Be $false
            }
        }
    }

    It 'keeps provisioning bindings identical for Function and non-Function sample selections' {
        & $script:planScript @script:planArguments
        $firstPlan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        $script:functionAssignment | ConvertTo-Json -Depth 5 |
            Set-Content -LiteralPath $script:planArguments.SelectionManifest -Encoding utf8
        & $script:planScript @script:planArguments
        $secondPlan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        ($secondPlan.environmentBindings -join ',') | Should BeExactly ($firstPlan.environmentBindings -join ',')
        $secondPlan.filter | Should Not Be $firstPlan.filter
        $secondPlan.selectedTests[0].fullName | Should Not Be $firstPlan.selectedTests[0].fullName
    }

    It 'requires the identity resource group instead of a name pattern' {
        $arguments = @{} + $script:planArguments
        $arguments.Remove('IdentityResourceGroup')
        { & $script:planScript @arguments -IdentityNamePattern 'mi-azsdk-sample-{resource}-wus3' } | Should Throw
        Test-Path -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') | Should Be $false
    }

    It 'accepts any existing resource group name without inventing Azure IDs or location: <Name>' -TestCases @(
        @{ Name = 'rg-azsdk-identities-uksouth-010126_000000' }, @{ Name = 'Custom_RG.(blue)' }, @{ Name = 'a' }
    ) {
        param($Name)
        $arguments = @{} + $script:planArguments
        $arguments.IdentityResourceGroup = $Name
        & {
            function az { throw 'Offline planning must not contact Azure.' }
            & $script:planScript @arguments
        }
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        $plan.location | Should BeExactly ''
        $plan.identityResolution | Should BeExactly 'Pending'
        $plan.sharedIdentities.Count | Should Be 0
        $plan.identityResourceGroup | Should BeExactly $Name
    }

    It 'rejects an invalid identity resource group before saving a plan: <Label>' -TestCases @(
        @{ Label = 'empty'; Name = '' }, @{ Label = 'whitespace'; Name = ' ' },
        @{ Label = 'resource ID'; Name = '/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/elsewhere' },
        @{ Label = 'macro'; Name = '$(identityResourceGroup)' }, @{ Label = 'shell text'; Name = 'rg-x;Write-Host bad' },
        @{ Label = 'path'; Name = '../rg' }, @{ Label = 'trailing period'; Name = 'rg-x.' },
        @{ Label = 'newline'; Name = "rg-x`n" }, @{ Label = 'oversized'; Name = ('a' * 91) }
    ) {
        param($Label, $Name)
        $arguments = @{} + $script:planArguments
        $arguments.IdentityResourceGroup = $Name
        & {
            function az { throw 'Offline planning must not contact Azure.' }
            { & $script:planScript @arguments } | Should Throw 'Invalid shared identity resource group'
        }
        Test-Path -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') | Should Be $false
    }
    It 'keeps the matched sample assignments and excludes non-matching cases' {
        $candidates = @($script:agentsAssignment.selectedTests + $script:functionAssignment.selectedTests +
            @{ package = 'Azure.AI.Projects'; fullName = 'Azure.AI.Projects.Tests.Samples.Sample_AIAgents(True).AgentsBasicsAsync'; name = 'AgentsBasicsAsync' })
        $tree = ConvertTo-SampleSelectionTree -Selection '(Name=AgentsBasics|Name=AzureFunction)'
        $selected = @($candidates | Where-Object { Test-SampleSelection -Tree $tree -Test $_ })
        $assignment = (New-SampleQueuePlan -Tests $selected -QueueCount 1 -Pool unit -Image unit).queues.q1
        $assignment | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $script:planArguments.SelectionManifest -Encoding utf8
        & $script:planScript @script:planArguments
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        ($plan.selectedTests.name -join ',') | Should BeExactly 'AzureFunction,AgentsBasics'
        $plan.filter | Should BeExactly $assignment.filter
    }

    It 'derives the saved bindings from the Bicep output and excludes the validation endpoint' {
        & $script:planScript @script:planArguments
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        foreach ($name in @('FOUNDRY_PROJECT_ENDPOINT', 'FOUNDRY_MODEL_NAME', 'FOUNDRY_AGENT_NAME', 'MCP_PROJECT_CONNECTION_ID',
                'AZURE_SUBSCRIPTION_ID', 'AZURE_TENANT_ID', 'AZURE_RESOURCE_GROUP')) {
            @($plan.environmentBindings) -contains $name | Should Be $true
        }
        @($plan.environmentBindings) -contains 'LLM_VALIDATION_PROJECT_ENDPOINT' | Should Be $false
    }

    It 'writes no resource plan for an empty queue assignment' {
        $script:agentsAssignment.selectedTests = @()
        $script:agentsAssignment | ConvertTo-Json -Depth 5 |
            Set-Content -LiteralPath $script:planArguments.SelectionManifest -Encoding utf8
        { & $script:planScript @script:planArguments } | Should Throw 'at least one selected test'
        Test-Path -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') | Should Be $false
    }

    It 'rejects invalid .NET assignment metadata before writing a plan: <Field>' -TestCases @(
        @{ Field = 'schemaVersion'; Value = 2; Error = 'schema or queue' },
        @{ Field = 'queueName'; Value = 'q2'; Error = 'schema or queue' },
        @{ Field = 'filter'; Value = ''; Error = 'test filter' },
        @{ Field = 'fullName'; Value = ''; Error = 'unique test IDs' },
        @{ Field = 'name'; Value = ''; Error = 'package and name metadata' },
        @{ Field = 'package'; Value = ''; Error = 'package and name metadata' }
    ) {
        param($Field, $Value, $Error)
        if ($script:agentsAssignment.ContainsKey($Field)) { $script:agentsAssignment[$Field] = $Value }
        else { $script:agentsAssignment.selectedTests[0][$Field] = $Value }
        $script:agentsAssignment | ConvertTo-Json -Depth 5 |
            Set-Content -LiteralPath $script:planArguments.SelectionManifest -Encoding utf8
        { & $script:planScript @script:planArguments } | Should Throw $Error
        Test-Path -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') | Should Be $false
    }
}