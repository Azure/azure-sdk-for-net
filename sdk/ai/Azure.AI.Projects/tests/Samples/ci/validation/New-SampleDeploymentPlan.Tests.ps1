# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

Describe 'Offline deployment-plan defaults' {
    BeforeEach {
        $script:originalSubscription = $env:AZURE_SUBSCRIPTION_ID
        $script:originalTenant = $env:AZURE_TENANT_ID
        $script:originalQueue = $env:SAMPLE_QUEUE_NAME
        $env:AZURE_SUBSCRIPTION_ID = '11111111-1111-1111-1111-111111111111'
        $env:AZURE_TENANT_ID = '22222222-2222-2222-2222-222222222222'
        $env:SAMPLE_QUEUE_NAME = 'q1'
        $script:planDirectory = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
        $manifest = Join-Path $TestDrive 'selection.json'
        @{ schemaVersion = 1; tests = @(@{
            node_id = 'tests/samples/test_samples.py::TestSamples::test_agent_tools_samples[sample_agent_mcp_with_project_connection]'
            sample_path = 'samples/agents/tools/sample_agent_mcp_with_project_connection.py'
        }) } | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $manifest -Encoding utf8
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
        @{ schemaVersion = 1; tests = @(@{
            node_id = 'tests/samples/test_samples.py::TestSamples::test_agent_tools_samples[sample_agent_azure_function]'
            sample_path = 'samples/agents/tools/sample_agent_azure_function.py'
        }) } | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $script:planArguments.SelectionManifest -Encoding utf8
        & {
            function az { throw 'Offline planning must not contact Azure.' }
            & $script:planScript @script:planArguments
        }
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        @($plan.selectedTests).Count | Should Be 1
        foreach ($name in @('STORAGE_INPUT_QUEUE_NAME', 'STORAGE_OUTPUT_QUEUE_NAME', 'STORAGE_QUEUE_SERVICE_ENDPOINT')) {
            $plan.requiredEnvironment -contains $name | Should Be $true
            $plan.environmentBindings -contains $name | Should Be $true
        }
        Test-Path -LiteralPath (Join-Path $script:planDirectory 'rejected-tests.json') | Should Be $false
    }

    It 'includes all Function bindings even when the selected sample does not require them' {
        & $script:planScript @script:planArguments
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        $functionBindings = @('FUNCTION_APP_NAME', 'FUNCTION_APP_URL', 'STORAGE_INPUT_QUEUE_NAME',
            'STORAGE_OUTPUT_QUEUE_NAME', 'STORAGE_QUEUE_SERVICE_ENDPOINT')
        foreach ($name in $functionBindings) {
            $plan.environmentBindings -contains $name | Should Be $true
            $plan.requiredEnvironment -contains $name | Should Be $false
        }
    }

    It 'deploys and publishes the Function App outside sample-selection conditions' {
        $tokens = $null
        $parseErrors = $null
        $path = (Resolve-Path (Join-Path $PSScriptRoot '../Invoke-ResourceProvisioning.ps1')).Path
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
        @{ schemaVersion = 1; tests = @(@{
            node_id = 'tests/samples/test_samples.py::TestSamples::test_agent_tools_samples[sample_agent_azure_function]'
            sample_path = 'samples/agents/tools/sample_agent_azure_function.py'
        }) } | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $script:planArguments.SelectionManifest -Encoding utf8
        & $script:planScript @script:planArguments
        $secondPlan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        ($secondPlan.environmentBindings -join ',') | Should BeExactly ($firstPlan.environmentBindings -join ',')
        ($secondPlan.requiredEnvironment -join ',') | Should Not Be ($firstPlan.requiredEnvironment -join ',')
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
}

Describe 'Per-sample rejection of unsupported environment variables' {
    BeforeEach {
        $script:originalSubscription = $env:AZURE_SUBSCRIPTION_ID
        $script:originalTenant = $env:AZURE_TENANT_ID
        $env:AZURE_SUBSCRIPTION_ID = '11111111-1111-1111-1111-111111111111'
        $env:AZURE_TENANT_ID = '22222222-2222-2222-2222-222222222222'
        $script:planDirectory = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
        $script:packageRoot = Join-Path $TestDrive 'package'
        $scannerDirectory = Join-Path $script:packageRoot '.github/skills/azure-ai-projects-record-sample/scripts'
        $null = New-Item -ItemType Directory -Path $scannerDirectory, (Join-Path $script:packageRoot 'samples') -Force
        Copy-Item -LiteralPath (Join-Path $PSScriptRoot '../../../../.github/skills/azure-ai-projects-record-sample/scripts/GetSampleRequiredEnvironmentVariables.ps1') -Destination $scannerDirectory
        Set-Content -LiteralPath (Join-Path $script:packageRoot 'samples/supported.py') -Value @('import os', 'endpoint = os.environ["FOUNDRY_PROJECT_ENDPOINT"]')
        Set-Content -LiteralPath (Join-Path $script:packageRoot 'samples/validated.py') -Value @('import os', 'endpoint = os.environ["LLM_VALIDATION_PROJECT_ENDPOINT"]')
        Set-Content -LiteralPath (Join-Path $script:packageRoot 'samples/unsupported.py') -Value @('import os', 'value = os.environ["UNIT_UNSUPPORTED_SETTING"]')
        $script:writeManifest = {
            param([string[]] $Samples)
            $path = Join-Path $TestDrive ([guid]::NewGuid().ToString('N') + '.json')
            @{ schemaVersion = 1; tests = @($Samples | ForEach-Object { @{
                node_id = "tests/samples/test_samples.py::TestSamples::test_agents_samples[$_]"; sample_path = "samples/$_.py" } }) } |
                ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $path -Encoding utf8
            return $path
        }
        $script:planScript = Join-Path $PSScriptRoot '../New-SampleDeploymentPlan.ps1'
        $script:arguments = @{
            OutputDirectory = $script:planDirectory; QueueName = 'q1'; PackageRoot = $script:packageRoot
            DefinitionId = $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' })
            BuildId = $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' }); JobAttempt = '1'
            IdentityResourceGroup = 'rg-azsdk-identities-westus3-102826_164519'
        }
    }
    AfterEach {
        $env:AZURE_SUBSCRIPTION_ID = $script:originalSubscription
        $env:AZURE_TENANT_ID = $script:originalTenant
    }

    It 'rejects only the sample with an unsupported variable and keeps the rest' {
        $manifest = & $script:writeManifest @('supported', 'unsupported', 'validated')
        & $script:planScript -SelectionManifest $manifest @script:arguments
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        @($plan.selectedTests).Count | Should Be 2
        @($plan.selectedTests | ForEach-Object { $_.sample_path } | Sort-Object) -join ',' | Should Be 'samples/supported.py,samples/validated.py'
        @($plan.requiredEnvironment) -join ',' | Should Be 'FOUNDRY_PROJECT_ENDPOINT,LLM_VALIDATION_PROJECT_ENDPOINT'
        $rejected = @(Get-Content -LiteralPath (Join-Path $script:planDirectory 'rejected-tests.json') -Raw | ConvertFrom-Json -AsHashtable)
        $rejected.Count | Should Be 1
        $rejected[0].sample_path | Should Be 'samples/unsupported.py'
        @($rejected[0].unsupported) -join ',' | Should Be 'UNIT_UNSUPPORTED_SETTING'
    }

    It 'derives the saved bindings from the Bicep output and excludes the validation endpoint' {
        $manifest = & $script:writeManifest @('supported')
        & $script:planScript -SelectionManifest $manifest @script:arguments
        $plan = Get-Content -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
        foreach ($name in @('FOUNDRY_PROJECT_ENDPOINT', 'FOUNDRY_MODEL_NAME', 'FOUNDRY_AGENT_NAME', 'MCP_PROJECT_CONNECTION_ID',
                'AZURE_SUBSCRIPTION_ID', 'AZURE_TENANT_ID', 'AZURE_RESOURCE_GROUP')) {
            @($plan.environmentBindings) -contains $name | Should Be $true
        }
        @($plan.environmentBindings) -contains 'LLM_VALIDATION_PROJECT_ENDPOINT' | Should Be $false
        Test-Path -LiteralPath (Join-Path $script:planDirectory 'rejected-tests.json') | Should Be $false
    }

    It 'writes no plan when every sample in the queue is rejected, without failing the script' {
        $manifest = & $script:writeManifest @('unsupported')
        & $script:planScript -SelectionManifest $manifest @script:arguments
        Test-Path -LiteralPath (Join-Path $script:planDirectory 'deployment-plan.json') | Should Be $false
        Test-Path -LiteralPath (Join-Path $script:planDirectory 'rejected-tests.json') | Should Be $true
    }
}