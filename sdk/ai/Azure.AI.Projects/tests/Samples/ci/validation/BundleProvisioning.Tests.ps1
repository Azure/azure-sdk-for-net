# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

. (Join-Path $PSScriptRoot '../SampleCiHelpers.ps1')

Describe 'Full bundle .NET bindings' {
    BeforeEach {
        $script:environment = @{}
        foreach ($name in @(Get-SampleEnvironmentNames)) { $script:environment[$name] = "https://example.invalid/$name" }
        $script:environment.MCP_PROJECT_CONNECTION_ID = '/subscriptions/unit/projects/project/connections/mcp'
        $script:environment.STORAGE_QUEUE_SERVICE_ENDPOINT = 'https://storage.queue.core.windows.net/'
    }

    It 'maps names and IDs without altering the canonical environment' {
        $bindings = Get-DotNetSampleEnvironment -Environment $script:environment
        $bindings.MCP_PROJECT_CONNECTION_NAME | Should BeExactly $script:environment.MCP_PROJECT_CONNECTION_ID
        $bindings.AI_SEARCH_CONNECTION_NAME | Should BeExactly $script:environment.AI_SEARCH_PROJECT_CONNECTION_ID
        $bindings.BING_CONNECTION_ID | Should BeExactly $script:environment.BING_PROJECT_CONNECTION_ID
        $bindings.BING_CONNECTION_NAME | Should BeExactly $script:environment.BING_PROJECT_CONNECTION_NAME
        $bindings.CUSTOM_BING_CONNECTION_ID | Should BeExactly $script:environment.BING_CUSTOM_SEARCH_PROJECT_CONNECTION_ID
        $bindings.CUSTOM_BING_CONNECTION_NAME | Should BeExactly $script:environment.BING_CUSTOM_SEARCH_PROJECT_CONNECTION_NAME
        $bindings.PLAYWRIGHT_CONNECTION_ID | Should BeExactly $script:environment.BROWSER_AUTOMATION_PROJECT_CONNECTION_ID
        $bindings.PLAYWRIGHT_CONNECTION_NAME | Should BeExactly $script:environment.BROWSER_AUTOMATION_PROJECT_CONNECTION_NAME
        $bindings.BROWSER_AUTOMATION_NAME | Should BeExactly $script:environment.BROWSER_AUTOMATION_PROJECT_CONNECTION_NAME
        $bindings.STORAGE_QUEUE_URI | Should BeExactly 'https://storage.queue.core.windows.net'
        $bindings.OPENAPI_PROJECT_CONNECTION_ID | Should BeExactly $script:environment.OPENAPI_PROJECT_CONNECTION_ID
        $bindings.BING_CUSTOM_SEARCH_INSTANCE_NAME | Should BeExactly $script:environment.BING_CUSTOM_SEARCH_INSTANCE_NAME
        $script:environment.ContainsKey('STORAGE_QUEUE_URI') | Should Be $false
        foreach ($name in $script:environment.Keys) {
            $bindings[$name] | Should BeExactly $script:environment[$name]
        }
    }

    It 'rejects incomplete or secret-bearing environments before publishing' {
        $script:environment.Remove('OPENAPI_PROJECT_CONNECTION_ID')
        { Get-DotNetSampleEnvironment -Environment $script:environment } | Should Throw 'non-secret environment'
        $script:environment.OPENAPI_PROJECT_CONNECTION_ID = 'connection'
        $script:environment.ACCESS_TOKEN = 'unit-test-placeholder'
        { Get-DotNetSampleEnvironment -Environment $script:environment } | Should Throw 'non-secret environment'
    }

    It 'publishes the deployed model publisher required by the deployment sample' {
        $pipeline = Get-Content -LiteralPath (Join-Path $PSScriptRoot '../../../../tests.yml') -Raw
        $testEnvironment = [regex]::Match($pipeline, '(?ms)^    EnvVars:\r?\n(?<body>.*?)^    PreSteps:').Groups['body'].Value
        $testEnvironment | Should Match '(?m)^      MODEL_PUBLISHER: OpenAI\r?$'
        foreach ($template in @('sample-resources.bicep', 'standard-model.bicep')) {
            $model = Get-Content -LiteralPath (Join-Path $PSScriptRoot "../infra/$template") -Raw
            $model | Should Match "(?m)^      format: 'OpenAI'\r?$"
        }
    }

    It 'deploys the full bundle and exposes aliases to tests, with secrets only in provisioning' {
        $pipeline = Get-Content -LiteralPath (Join-Path $PSScriptRoot '../../../../tests.yml') -Raw
        $pipeline | Should Match 'Invoke-BundleProvisioning.ps1'
        $pipeline | Should Not Match 'Invoke-StandardProvisioning.ps1'
        $pipeline | Should Match 'MCP_GITHUB_PAT: \$\(MCP_GITHUB_PAT\)'
        $pipeline | Should Match 'PROJ_CONN_OPEN_API_KEY: \$\(PROJ_CONN_OPEN_API_KEY\)'
        $testEnvironment = [regex]::Match($pipeline, '(?ms)^    EnvVars:\r?\n(?<body>.*?)^    PreSteps:').Groups['body'].Value
        $testEnvironment | Should Not Match 'MCP_GITHUB_PAT|PROJ_CONN_OPEN_API_KEY'
        $bindings = Get-DotNetSampleEnvironment -Environment $script:environment
        foreach ($name in @('MCP_PROJECT_CONNECTION_NAME', 'AI_SEARCH_CONNECTION_NAME',
            'BING_CONNECTION_ID', 'BING_CONNECTION_NAME', 'CUSTOM_BING_CONNECTION_ID', 'CUSTOM_BING_CONNECTION_NAME',
            'PLAYWRIGHT_CONNECTION_ID', 'PLAYWRIGHT_CONNECTION_NAME', 'BROWSER_AUTOMATION_NAME',
            'OPENAPI_PROJECT_CONNECTION_ID', 'OPENAPI_PROJECT_CONNECTION_NAME', 'STORAGE_QUEUE_URI')) {
            $bindings.ContainsKey($name) | Should Be $true
            $testEnvironment | Should Match ([regex]::Escape("${name}: `$($name)"))
        }
        $pipeline | Should Match 'condition: always\(\)'
        $pipeline | Should Match 'Remove-SampleResources.ps1'
    }
}

Describe 'Full bundle worker orchestration' {
    BeforeEach {
        $script:outputDirectory = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
        $script:arguments = @{
            OutputDirectory = $script:outputDirectory; IdentityResourceGroup = 'shared-identities'; QueueName = 'q1'
            ModelName = 'gpt-4.1'; ModelVersion = '2025-04-14'; ModelSku = 'GlobalStandard'; ModelCapacity = 40
        }
    }

    It 'requires confirmation before state creation or Azure access' {
        & {
            function az { throw 'Unconfirmed provisioning must not contact Azure.' }
            { & (Join-Path $PSScriptRoot '../Invoke-BundleProvisioning.ps1') @script:arguments } |
                Should Throw '-ConfirmProvisioning'
        }
        Test-Path -LiteralPath $script:outputDirectory | Should Be $false
    }

    It 'rejects existing output before adopting a previous attempt' {
        $null = New-Item -ItemType Directory -Path $script:outputDirectory
        $path = Join-Path $script:outputDirectory 'deployment-state.json'
        Set-Content -LiteralPath $path -Value 'previous-attempt'
        { & (Join-Path $PSScriptRoot '../Invoke-BundleProvisioning.ps1') @script:arguments -ConfirmProvisioning } |
            Should Throw 'earlier attempt'
        (Get-Content -LiteralPath $path -Raw).Trim() | Should BeExactly 'previous-attempt'
    }

    It 'resolves a plan before deployment and publishes only a ready environment: <Status>' -TestCases @(
        @{ Status = 'Ready' }, @{ Status = 'Failed' }
    ) {
        param($Status)
        $fixture = Join-Path $TestDrive "wrapper-$Status"
        $null = New-Item -ItemType Directory -Path $fixture
        Copy-Item -LiteralPath (Join-Path $PSScriptRoot '../Invoke-BundleProvisioning.ps1') -Destination $fixture
        @'
function Set-SampleSubscriptionContext { param($Plan) @{ tenantId = 'tenant' } }
function Resolve-SampleIdentitySelection { param($Plan) $Plan.identityResolution = 'Resolved'; $Plan }
function Get-SampleEnvironmentNames { @('FOUNDRY_PROJECT_ENDPOINT') }
function Assert-SampleEnvironment { param($Environment, $Names)
    if ($Environment.Count -ne 1 -or -not $Environment.Contains('FOUNDRY_PROJECT_ENDPOINT')) { throw 'Unexpected environment.' }
}
function Get-DotNetSampleEnvironment { param($Environment) $Environment }
'@ | Set-Content -LiteralPath (Join-Path $fixture 'SampleCiHelpers.ps1')
        @'
param($OutputDirectory, $IdentityResourceGroup, $QueueName, $ModelName, $ModelVersion, $ModelSku, $ModelCapacity)
$null = New-Item -ItemType Directory -Path $OutputDirectory
@{ identityResolution = 'Pending' } | ConvertTo-Json | Set-Content -LiteralPath (Join-Path $OutputDirectory 'deployment-plan.json')
'@ | Set-Content -LiteralPath (Join-Path $fixture 'New-ResourceDeploymentPlan.ps1')
        @'
param($PlanPath, $StatePath, $QueueName, [switch] $ConfirmProvisioning)
$plan = Get-Content -LiteralPath $PlanPath -Raw | ConvertFrom-Json -AsHashtable
if (-not $ConfirmProvisioning -or $plan.identityResolution -cne 'Resolved') { throw 'Unresolved or unconfirmed deployment.' }
@{ status = '__STATUS__'; environment = @{ FOUNDRY_PROJECT_ENDPOINT = "https://example.invalid/100%`nvalue" } } |
    ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $StatePath
'@.Replace('__STATUS__', $Status) | Set-Content -LiteralPath (Join-Path $fixture 'Invoke-ResourceProvisioning.ps1')
        Mock Write-Host {}
        if ($Status -ceq 'Ready') {
            & (Join-Path $fixture 'Invoke-BundleProvisioning.ps1') @script:arguments -ConfirmProvisioning
            Assert-MockCalled Write-Host -Times 1 -Exactly -Scope It -ParameterFilter {
                $Object -match '^##vso\[task.setvariable variable=FOUNDRY_PROJECT_ENDPOINT\]https://example.invalid/100%AZP25%0Avalue$'
            }
        } else {
            { & (Join-Path $fixture 'Invoke-BundleProvisioning.ps1') @script:arguments -ConfirmProvisioning } |
                Should Throw 'not ready'
            Assert-MockCalled Write-Host -Times 0 -Exactly -Scope It -ParameterFilter {
                $Object -match '^##vso\[task.setvariable'
            }
        }
    }
}
