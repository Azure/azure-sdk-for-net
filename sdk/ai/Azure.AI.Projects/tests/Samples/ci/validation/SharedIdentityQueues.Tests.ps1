# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

. (Join-Path $PSScriptRoot '../SampleCiHelpers.ps1')
. (Join-Path $PSScriptRoot '../PythonSampleCiHelpers.ps1')

function Invoke-QueueTestEnvironment {
    param([Parameter(Mandatory)] [scriptblock] $Test)

    $testEnvironment = @{
        AZURE_SUBSCRIPTION_ID = '11111111-1111-1111-1111-111111111111'
        AZURE_TENANT_ID = '22222222-2222-2222-2222-222222222222'
        SAMPLE_QUEUE_NAME = 'q1'
        SYSTEM_DEFINITIONID = '8392'
        BUILD_BUILDID = '12345'
        SYSTEM_JOBATTEMPT = '1'
    }
    $originalEnvironment = @{}
    foreach ($entry in $testEnvironment.GetEnumerator()) {
        $originalEnvironment[$entry.Key] = [Environment]::GetEnvironmentVariable($entry.Key)
    }
    try {
        foreach ($entry in $testEnvironment.GetEnumerator()) {
            [Environment]::SetEnvironmentVariable($entry.Key, $entry.Value)
        }
        $script:queueAzureCalls = [Collections.Generic.List[string]]::new()
        function az {
            $script:queueAzureCalls.Add(($args -join ' '))
            throw 'The native Azure CLI must not run in offline queue validation.'
        }
        if ((Get-Command az).CommandType -ne 'Function') { throw 'Azure CLI isolation failed.' }
        & $Test
    } finally {
        foreach ($entry in $originalEnvironment.GetEnumerator()) {
            [Environment]::SetEnvironmentVariable($entry.Key, $entry.Value)
        }
    }
}

function New-OfflineQueuePlan {
    param([Parameter(Mandatory)] [string] $OutputDirectory, [string] $QueueName = 'q1',
        [string] $IdentityResourceGroup = 'rg-azsdk-identities-westus3-102826_164519',
        [string] $NameSuffix = 'westus3-102826_164519', [string] $Location = 'westus3')

    $null = New-Item -ItemType Directory -Path $OutputDirectory -Force
    $manifest = Join-Path $OutputDirectory 'selection.json'
    @{ schemaVersion = 1; tests = @(@{
        node_id = 'tests/samples/test_samples.py::TestSamples::test_agent_tools_samples[sample_agent_mcp_with_project_connection-{0}]' -f $QueueName
        sample_path = 'samples/agents/tools/sample_agent_mcp_with_project_connection.py'
    }) } | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $manifest -Encoding utf8
    $planScript = Join-Path $PSScriptRoot '../New-SampleDeploymentPlan.ps1'
    & $planScript -SelectionManifest $manifest -OutputDirectory $OutputDirectory -QueueName $QueueName `
        -DefinitionId $env:SYSTEM_DEFINITIONID -BuildId $env:BUILD_BUILDID -JobAttempt $env:SYSTEM_JOBATTEMPT -IdentityResourceGroup $IdentityResourceGroup
    $plan = Get-Content -LiteralPath (Join-Path $OutputDirectory 'deployment-plan.json') -Raw | ConvertFrom-Json -AsHashtable
    # Explicit fixture admission only: the live resolver is covered by IdentityResolution.Tests.ps1.
    $plan.identityResolution = 'Resolved'; $plan.location = $Location
    $plan.sharedIdentities = Get-QueueTestIdentityIds -ResourceGroup $IdentityResourceGroup -NameSuffix $NameSuffix
    $plan.identityOwner = '0123456789abcdef0123456789abcdef'
    $plan.identityPrincipalIds = @{
        project = '44444444-4444-4444-4444-444444444444'; account = '55555555-5555-5555-5555-555555555555'
        search = '66666666-6666-6666-6666-666666666666'; function = '77777777-7777-7777-7777-777777777777'
    }
    $plan | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath (Join-Path $OutputDirectory 'deployment-plan.json') -Encoding utf8
    return $plan
}

function New-OfflineQueuePlans {
    param([Parameter(Mandatory)] [string] $OutputDirectory)

    foreach ($queue in @('q1', 'q2', 'q3', 'q4')) {
        New-OfflineQueuePlan -OutputDirectory (Join-Path $OutputDirectory $queue) -QueueName $queue
    }
}

function Get-QueueTestIdentityIds {
    param([string] $ResourceGroup = 'rg-azsdk-identities-westus3-102826_164519', [string] $NameSuffix = 'westus3-102826_164519')

    $root = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/$ResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities"
    return @{
        project = $root + "/mi-azsdk-sample-project-$NameSuffix"
        account = $root + "/mi-azsdk-sample-account-$NameSuffix"
        search = $root + "/mi-azsdk-sample-search-$NameSuffix"
        function = $root + "/mi-azsdk-sample-function-$NameSuffix"
    }
}

Describe 'Offline queue ownership and deployment plans' {
    BeforeEach {
        Mock Invoke-SampleAzure { throw 'Queue ownership must be checked before any Azure request.' }
        Mock Invoke-RestMethod { throw 'Offline queue planning must not contact the network.' }
    }

    It 'creates four unique run-owned groups while binding the same four static shared identities' {
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'plans'))
            $expectedIdentities = Get-QueueTestIdentityIds
            $plans.Count | Should Be 4
            ($plans.queueName -join ',') | Should Be 'q1,q2,q3,q4'
            @($plans.resourceGroup | Sort-Object -Unique).Count | Should Be 4
            foreach ($plan in $plans) {
                $env:SAMPLE_QUEUE_NAME = $plan.queueName
                $expectedGroup = 'azsdk-samples-{0}-{1}-{2}-{3}-{4}' -f `
                    $plan.definitionId, $plan.buildId, $plan.queueName, $plan.jobAttempt, $plan.ownerToken.Substring(0, 8)
                $plan.resourceGroup | Should Be $expectedGroup
                $plan.subscriptionId | Should Be $env:AZURE_SUBSCRIPTION_ID
                $plan.tenantId | Should Be $env:AZURE_TENANT_ID
                $plan.ContainsKey('provisionMcp') | Should Be $false
                @($plan.selectedTests).Count | Should Be 1
                $plan.selectedTests[0].sample_path | Should Be 'samples/agents/tools/sample_agent_mcp_with_project_connection.py'
                $plan.sharedIdentities.Count | Should Be 4
                foreach ($purpose in $expectedIdentities.Keys) {
                    $plan.sharedIdentities[$purpose] | Should Be $expectedIdentities[$purpose]
                }
                $tags = Get-SampleOwnershipTags -Plan $plan
                $tags.Count | Should Be 4
                $tags['purpose'] | Should Be 'azure-ai-projects-sample-ci'
                $tags['sample-ci-run'] | Should Be ('8392-12345-{0}-1' -f $plan.queueName)
                $tags['sample-ci-owner'] | Should Be $plan.ownerToken
                $tags['sample-ci-queue'] | Should Be $plan.queueName
            }
            $script:queueAzureCalls.Count | Should Be 0
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
            Assert-MockCalled Invoke-RestMethod -Times 0 -Exactly -Scope It
        }
    }

    It 'rejects invalid plan queue metadata without mandatory-parameter prompts: <Label>' -TestCases @(
        @{ Label = 'missing'; Value = $null },
        @{ Label = 'empty'; Value = '' },
        @{ Label = 'below range'; Value = 'q0' },
        @{ Label = 'above range'; Value = 'q5' },
        @{ Label = 'wrong case'; Value = 'Q1' },
        @{ Label = 'extra digit'; Value = 'q01' },
        @{ Label = 'whitespace'; Value = 'q1 ' },
        @{ Label = 'unresolved macro'; Value = '$(SAMPLE_QUEUE_NAME)' }
    ) {
        param($Label, $Value)
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'invalid-queue')
            if ($null -eq $Value) { $plan.Remove('queueName') } else { $plan.queueName = $Value }
            { Assert-SampleRunPlan -Plan $plan -QueueName q1 } | Should Throw 'Invalid CI run ownership'
            $script:queueAzureCalls.Count | Should Be 0
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
        }
    }

    It 'binds helper validation to the current queue environment when no queue argument is supplied' {
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'environment-queue')
            $env:SAMPLE_QUEUE_NAME = 'q2'
            { Assert-SampleRunPlan -Plan $plan } | Should Throw 'different test queue'
            $script:queueAzureCalls.Count | Should Be 0
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
        }
    }

    It 'rejects a q2 plan swapped into q1 provisioning before Azure or deployment state creation' {
        Invoke-QueueTestEnvironment {
            $directory = Join-Path $TestDrive 'swapped-plan'
            $plan = New-OfflineQueuePlan -OutputDirectory $directory -QueueName q2
            $planPath = Join-Path $directory 'deployment-plan.json'
            $statePath = Join-Path $TestDrive 'q1-state.json'
            $provisioningScript = Join-Path $PSScriptRoot '../Invoke-SampleProvisioning.ps1'
            { & $provisioningScript -PlanPath $planPath -StatePath $statePath -QueueName q1 -ConfirmProvisioning } |
                Should Throw 'different test queue'
            $plan.queueName | Should Be 'q2'
            Test-Path -LiteralPath $statePath | Should Be $false
            $script:queueAzureCalls.Count | Should Be 0
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
            Assert-MockCalled Invoke-RestMethod -Times 0 -Exactly -Scope It
        }
    }

    It 'rejects q2 state swapped into q1 cleanup before any Azure request or deletion' {
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'swapped-state') -QueueName q2
            $statePath = Join-Path $TestDrive 'q1-cleanup.json'
            @{
                schemaVersion = 1; plan = $plan; subscriptionId = $plan.subscriptionId; tenantId = $plan.tenantId
                resourceGroupDeployment = 'sample-ci-rg-' + $plan.ownerToken; status = 'Ready'
            } | ConvertTo-Json -Depth 15 | Set-Content -LiteralPath $statePath -Encoding utf8
            $originalState = Get-Content -LiteralPath $statePath -Raw
            $cleanupScript = Join-Path $PSScriptRoot '../Remove-SampleResources.ps1'
            { & $cleanupScript -StatePath $statePath -QueueName q1 -ConfirmCleanup } | Should Throw 'different test queue'
            (Get-Content -LiteralPath $statePath -Raw) | Should Be $originalState
            $script:queueAzureCalls.Count | Should Be 0
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
            Assert-MockCalled Invoke-RestMethod -Times 0 -Exactly -Scope It
        }
    }

    It 'rejects incomplete or foreign queue ownership tags: <Label>' -TestCases @(
        @{ Label = 'missing queue tag'; Missing = $true },
        @{ Label = 'another queue tag'; Missing = $false }
    ) {
        param($Label, $Missing)
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'ownership-tags')
            $group = @{
                id = '/subscriptions/{0}/resourceGroups/{1}' -f $plan.subscriptionId, $plan.resourceGroup
                tags = Get-SampleOwnershipTags -Plan $plan
            }
            if ($Missing) { $group.tags.Remove('sample-ci-queue') } else { $group.tags['sample-ci-queue'] = 'q2' }
            { Assert-SampleResourceGroupOwnership -Plan $plan -ResourceGroup $group -SubscriptionId $plan.subscriptionId } |
                Should Throw 'exact CI ownership tags'
            $script:queueAzureCalls.Count | Should Be 0
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
        }
    }
}

Describe 'Bootstrap-owned shared identity bindings' {
    BeforeEach {
        $script:sharedIdentityFixture = @{
            subscriptionId = '11111111-1111-1111-1111-111111111111'
            tenantId = '22222222-2222-2222-2222-222222222222'
            responseSubscriptionId = '11111111-1111-1111-1111-111111111111'
            responseTenantId = '22222222-2222-2222-2222-222222222222'
            responseLocation = 'westus3'
            responseType = 'Microsoft.ManagedIdentity/userAssignedIdentities'
            ownerByPurpose = @{}
            ids = Get-QueueTestIdentityIds
            principals = @{
                project = '44444444-4444-4444-4444-444444444444'
                account = '55555555-5555-5555-5555-555555555555'
                search = '66666666-6666-6666-6666-666666666666'
                function = '77777777-7777-7777-7777-777777777777'
            }
            tagChanges = @{}
        }
        Mock Invoke-RestMethod { throw 'Shared identity verification must use the isolated Azure wrapper.' }
        Mock Invoke-SampleAzure {
            param($Arguments, $Sensitive)
            if (-not $Sensitive -or $Arguments.Count -ne 7 -or $Arguments[0] -cne 'rest' -or
                $Arguments[1] -cne '--method' -or $Arguments[2] -cne 'get' -or $Arguments[3] -cne '--subscription' -or
                $Arguments[4] -cne $script:sharedIdentityFixture.subscriptionId -or $Arguments[5] -cne '--url') {
                throw 'Only protected, subscription-bound metadata GETs are allowed; workers must not write IAM.'
            }
            $uri = $Arguments[6]
            $purposes = @($script:sharedIdentityFixture.ids.Keys | Where-Object {
                $uri -ceq ('https://management.azure.com{0}?api-version=2023-01-31' -f $script:sharedIdentityFixture.ids[$_])
            })
            if ($purposes.Count -ne 1) { throw 'Unexpected shared identity metadata URI.' }
            $purpose = $purposes[0]
            $tags = @{ purpose = 'azsdk-sample-identities'; 'sample-ci-retention' = 'permanent'; 'sample-ci-identity' = $purpose;
                'sample-ci-owner' = '0123456789abcdef0123456789abcdef' }
            if ($script:sharedIdentityFixture.ownerByPurpose.ContainsKey($purpose)) { $tags['sample-ci-owner'] = $script:sharedIdentityFixture.ownerByPurpose[$purpose] }
            foreach ($entry in $script:sharedIdentityFixture.tagChanges.GetEnumerator()) { $tags[$entry.Key] = $entry.Value }
            return @{
                id = $script:sharedIdentityFixture.ids[$purpose].Replace(
                    $script:sharedIdentityFixture.subscriptionId, $script:sharedIdentityFixture.responseSubscriptionId)
                location = $script:sharedIdentityFixture.responseLocation
                type = $script:sharedIdentityFixture.responseType
                properties = @{
                    tenantId = $script:sharedIdentityFixture.responseTenantId
                    principalId = $script:sharedIdentityFixture.principals[$purpose]
                }
                tags = $tags
            }
        }
    }

    It 'verifies exactly the four permanent identities at their pinned resource IDs' {
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'shared-identities')
            $identities = Get-SampleSharedIdentities -Plan $plan
            $identities.Count | Should Be 4
            foreach ($purpose in $script:sharedIdentityFixture.ids.Keys) {
                $identities[$purpose].resourceId | Should Be $script:sharedIdentityFixture.ids[$purpose]
                $identities[$purpose].principalId | Should Be $script:sharedIdentityFixture.principals[$purpose]
            }
            Assert-MockCalled Invoke-SampleAzure -Times 4 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'verifies the identities of a set in another resource group and region with no ARM writes' {
        Invoke-QueueTestEnvironment {
            $group = 'rg-azsdk-identities-uksouth-010126_000000'
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'generic-set') -IdentityResourceGroup $group -NameSuffix 'uksouth-010126_000000' -Location uksouth
            $script:sharedIdentityFixture.ids = Get-QueueTestIdentityIds -ResourceGroup $group -NameSuffix 'uksouth-010126_000000'
            $script:sharedIdentityFixture.responseLocation = 'uksouth'
            $identities = Get-SampleSharedIdentities -Plan $plan
            $identities.Count | Should Be 4
            foreach ($purpose in @('project', 'account', 'search', 'function')) {
                $identities[$purpose].resourceId | Should BeExactly $script:sharedIdentityFixture.ids[$purpose]
            }
            Assert-MockCalled Invoke-SampleAzure -Times 4 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'rejects returned identity region or type instead of trusting the selected name: <Field>' -TestCases @(
        @{ Field = 'responseLocation'; Value = 'uksouth' },
        @{ Field = 'responseLocation'; Value = $null },
        @{ Field = 'responseType'; Value = 'Microsoft.Storage/storageAccounts' }
    ) {
        param($Field, $Value)
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'metadata-mismatch')
            $script:sharedIdentityFixture[$Field] = $Value
            { Get-SampleSharedIdentities -Plan $plan } | Should Throw 'Cannot verify the bootstrap-owned shared identity'
            Assert-MockCalled Invoke-SampleAzure -Times 1 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'rejects identities from different recorded bootstrap generations' {
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'mixed-generations')
            $script:sharedIdentityFixture.ownerByPurpose['search'] = 'abcdef0123456789abcdef0123456789'
            { Get-SampleSharedIdentities -Plan $plan } | Should Throw 'one bootstrap-owned set'
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'rejects a changed admitted region when rechecking live identity metadata' {
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'forged-region')
            $plan.location = 'uksouth'
            { Get-SampleSharedIdentities -Plan $plan } | Should Throw 'Cannot verify the bootstrap-owned shared identity'
            Assert-MockCalled Invoke-SampleAzure -Times 1 -Exactly -Scope It
        }
    }

    It 'rejects a resource group changed independently of the bound identity IDs before Azure calls' {
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'forged-group')
            $plan.identityResourceGroup = 'rg-azsdk-identities-other'
            { Get-SampleSharedIdentities -Plan $plan } | Should Throw 'selected identity resource group'
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
        }
    }

    It 'rejects a pending plan or an invalid identity resource group before Azure calls' {
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'pending-group')
            $plan.identityResolution = 'Pending'; $plan.location = ''; $plan.sharedIdentities = @{}
            { Get-SampleSharedIdentities -Plan $plan } | Should Throw 'Resolve the shared identities'
            $plan.identityResourceGroup = 'bad/group'
            { Assert-SampleRunPlan -Plan $plan } | Should Throw 'Invalid shared identity resource group'
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
        }
    }

    It 'rejects nonexact shared identity bindings before any metadata request: <Label>' -TestCases @(
        @{ Label = 'malformed resource ID'; Mode = 'case' },
        @{ Label = 'swapped identity purposes'; Mode = 'swap' },
        @{ Label = 'another subscription'; Mode = 'subscription' }
    ) {
        param($Label, $Mode)
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'invalid-bindings')
            $purposes = @('project', 'account', 'search', 'function')
            for ($index = 0; $index -lt $purposes.Count; $index++) {
                $purpose = $purposes[$index]
                if ($Mode -eq 'case') {
                    $plan.sharedIdentities[$purpose] = $plan.sharedIdentities[$purpose].Replace('/resourceGroups/', '/resourceGroups//')
                } elseif ($Mode -eq 'swap') {
                    $plan.sharedIdentities[$purpose] = $script:sharedIdentityFixture.ids[$purposes[($index + 1) % $purposes.Count]]
                } else {
                    $plan.sharedIdentities[$purpose] = $plan.sharedIdentities[$purpose].Replace(
                        $plan.subscriptionId, '99999999-9999-9999-9999-999999999999')
                }
            }
            { Get-SampleSharedIdentities -Plan $plan } | Should Throw 'Unexpected shared identity binding'
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'requires exactly four shared identity bindings: <Label>' -TestCases @(
        @{ Label = 'missing binding'; Extra = $false },
        @{ Label = 'extra binding'; Extra = $true }
    ) {
        param($Label, $Extra)
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'binding-count')
            if ($Extra) { $plan.sharedIdentities['extra'] = $plan.sharedIdentities.project }
            else { $plan.sharedIdentities.Remove('function') }
            { Get-SampleSharedIdentities -Plan $plan } | Should Throw 'four bootstrap-owned shared identities'
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'rejects returned shared identity metadata from another <Boundary>' -TestCases @(
        @{ Boundary = 'subscription'; Field = 'responseSubscriptionId' },
        @{ Boundary = 'tenant'; Field = 'responseTenantId' }
    ) {
        param($Boundary, $Field)
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'identity-target')
            $script:sharedIdentityFixture[$Field] = '99999999-9999-9999-9999-999999999999'
            { Get-SampleSharedIdentities -Plan $plan } | Should Throw 'Cannot verify the bootstrap-owned shared identity'
            Assert-MockCalled Invoke-SampleAzure -Times 1 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'requires the exact bootstrap ownership tag: <Tag>' -TestCases @(
        @{ Tag = 'purpose'; Value = 'unrelated-identities' },
        @{ Tag = 'sample-ci-retention'; Value = 'temporary' },
        @{ Tag = 'sample-ci-identity'; Value = 'another-purpose' },
        @{ Tag = 'sample-ci-owner'; Value = '' }
    ) {
        param($Tag, $Value)
        Invoke-QueueTestEnvironment {
            $plan = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'identity-tags')
            $script:sharedIdentityFixture.tagChanges[$Tag] = $Value
            { Get-SampleSharedIdentities -Plan $plan } | Should Throw 'Cannot verify the bootstrap-owned shared identity'
            Assert-MockCalled Invoke-SampleAzure -Times 1 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'accepts one preconfigured shared identity set for all four queues without querying or granting IAM' {
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'shared-queue-plans'))
            foreach ($plan in $plans) {
                $env:SAMPLE_QUEUE_NAME = $plan.queueName
                $identities = Get-SampleSharedIdentities -Plan $plan
                $identities.Count | Should Be 4
                $identities.project.principalId | Should Be $script:sharedIdentityFixture.principals.project
            }
            Assert-MockCalled Invoke-SampleAzure -Times 16 -Exactly -Scope It
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It -ParameterFilter {
                $Arguments -contains 'create' -or $Arguments -contains 'put' -or $Arguments -contains 'delete' -or
                ($Arguments -join ' ') -match 'Microsoft.Authorization/roleAssignments'
            }
            $script:queueAzureCalls.Count | Should Be 0
        }
    }
}

Describe 'Aggregate four-queue capacity admission' {
    BeforeEach {
        $script:batchCapacityFixture = @{
            subscriptionId = '11111111-1111-1111-1111-111111111111'
            account = @{ name = @{ value = 'AccountCount' }; currentValue = 0; limit = 4; unit = 'Count' }
            search = @{ name = @{ value = 'standard' }; currentValue = 0; limit = 4; unit = 'Count' }
            model = @{ name = @{ value = 'OpenAI.GlobalStandard.gpt5v' }; currentValue = 0; limit = 40 }
            leftovers = @()
            catalog = @(@{ model = @{
                name = 'gpt-5.2'; format = 'OpenAI'; version = '2025-12-11'; isDefaultVersion = $true
                skus = @(@{
                    name = 'GlobalStandard'; usageName = 'OpenAI.GlobalStandard.gpt5v'
                    capacity = @{ minimum = 1; maximum = 100; step = 1 }
                })
            } })
        }
        Mock Assert-SampleRegionAvailability { }
        Mock Invoke-RestMethod { throw 'Capacity unit tests must not contact the network.' }
        Mock Invoke-SampleAzure {
            param($Arguments, $Sensitive)
            $subscription = $script:batchCapacityFixture.subscriptionId
            $command = $Arguments -join '|'
            if ($Sensitive -and $command -ceq "group|list|--subscription|$subscription|--query|[?tags.purpose=='azure-ai-projects-sample-ci'].{id:id,name:name}") {
                return $script:batchCapacityFixture.leftovers
            }
            if (-not $Sensitive -and $command -ceq "cognitiveservices|usage|list|--location|westus3|--subscription|$subscription") {
                return @($script:batchCapacityFixture.account, $script:batchCapacityFixture.model)
            }
            if ($Sensitive -and $command -ceq "rest|--method|get|--subscription|$subscription|--url|https://management.azure.com/subscriptions/$subscription/providers/Microsoft.Search/locations/westus3/usages?api-version=2025-05-01") {
                return @{ value = @($script:batchCapacityFixture.search) }
            }
            if (-not $Sensitive -and $command -ceq "cognitiveservices|model|list|--location|westus3|--subscription|$subscription") {
                return $script:batchCapacityFixture.catalog
            }
            throw 'Only the four fixed read-only batch-capacity requests are allowed; no create or IAM write may run.'
        }
    }

    It 'admits four queues with exactly four free account and Search slots and forty catalog-key model units' {
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'capacity-pass'))
            @(Assert-SampleBatchCapacity -Plans $plans).Count | Should Be 0
            Assert-MockCalled Invoke-SampleAzure -Times 4 -Exactly -Scope It
            Assert-MockCalled Assert-SampleRegionAvailability -Times 1 -Exactly -Scope It -ParameterFilter {
                $SubscriptionId -ceq '11111111-1111-1111-1111-111111111111' -and $Location -ceq 'westus3'
            }
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It -ParameterFilter { $Arguments -contains 'create' }
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'checks only two active queues for the default two-case selection' {
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'two-queue-capacity'))[0..1]
            $script:batchCapacityFixture.account.limit = 2
            $script:batchCapacityFixture.search.limit = 2
            $script:batchCapacityFixture.model.limit = 20
            @(Assert-SampleBatchCapacity -Plans $plans).Count | Should Be 0
            Assert-MockCalled Invoke-SampleAzure -Times 4 -Exactly -Scope It
        }
    }

    It 'admits infrastructure plans with no Python test metadata' {
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'language-neutral-capacity'))
            foreach ($plan in $plans) {
                $plan.Remove('selectedTests')
                $plan.Remove('requiredEnvironment')
            }
            @(Assert-SampleBatchCapacity -Plans $plans).Count | Should Be 0
            Assert-MockCalled Invoke-SampleAzure -Times 4 -Exactly -Scope It
        }
    }

    It 'rejects empty or repeated queue selections before contacting Azure: <Mode>' -TestCases @(
        @{ Mode = 'empty' }, @{ Mode = 'repeat' }
    ) {
        param($Mode)
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'invalid-shards'))
            if ($Mode -eq 'empty') { $plans[1].selectedTests = @() }
            else { $plans[1].selectedTests = $plans[0].selectedTests }
            { Assert-PythonSamplePartition -Plans $plans } | Should Throw 'unique test nodes'
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'rejects insufficient aggregate <Quota> before any create' -TestCases @(
        @{ Quota = 'account'; Limit = 3; Description = 'batch Foundry account quota'; Calls = 2 },
        @{ Quota = 'search'; Limit = 3; Description = 'batch Search S1 quota'; Calls = 3 },
        @{ Quota = 'model'; Limit = 39; Description = 'batch sample-model quota'; Calls = 4 }
    ) {
        param($Quota, $Limit, $Description, $Calls)
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'capacity-fail'))
            $script:batchCapacityFixture[$Quota].limit = $Limit
            { Assert-SampleBatchCapacity -Plans $plans } | Should Throw ('Insufficient ' + $Description)
            Assert-MockCalled Invoke-SampleAzure -Times $Calls -Exactly -Scope It
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It -ParameterFilter { $Arguments -contains 'create' }
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'blocks admission while a temporary sample resource group from another attempt remains' {
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'leftover-plans'))
            $name = 'azsdk-samples-8392-12344-q1-1-abcdef01'
            $script:batchCapacityFixture.leftovers = @(@{
                name = $name; id = '/subscriptions/{0}/resourceGroups/{1}' -f $env:AZURE_SUBSCRIPTION_ID, $name
            })
            { Assert-SampleBatchCapacity -Plans $plans } | Should Throw 'Temporary sample RGs from another attempt still exist'
            Assert-MockCalled Invoke-SampleAzure -Times 1 -Exactly -Scope It
            Assert-MockCalled Assert-SampleRegionAvailability -Times 0 -Exactly -Scope It
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It -ParameterFilter { $Arguments -contains 'create' }
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'rejects duplicate queues even when the resource group names are distinct' {
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'duplicate-queues'))
            $plans[1].queueName = 'q1'
            { Assert-SampleBatchCapacity -Plans $plans } | Should Throw 'one to four distinct queue plans'
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
            Assert-MockCalled Assert-SampleRegionAvailability -Times 0 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'rejects mismatched batch target metadata before capacity requests: <Field>' -TestCases @(
        @{ Field = 'subscriptionId'; Value = '99999999-9999-9999-9999-999999999999' },
        @{ Field = 'tenantId'; Value = '99999999-9999-9999-9999-999999999999' },
        @{ Field = 'location'; Value = 'eastus' }
    ) {
        param($Field, $Value)
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'batch-target'))
            $plans[3][$Field] = $Value
            $expectedError = switch ($Field) {
                'location' { 'one explicit target and pipeline run' }
                'subscriptionId' { 'Unexpected shared identity binding' }
                default { 'one explicit target and pipeline run' }
            }
            { Assert-SampleBatchCapacity -Plans $plans } | Should Throw $expectedError
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'rejects mismatched sample-model settings before capacity requests: <Field>' -TestCases @(
        @{ Field = 'name'; Value = 'gpt-other' },
        @{ Field = 'version'; Value = '2025-01-01' },
        @{ Field = 'sku'; Value = 'Standard' },
        @{ Field = 'capacity'; Value = 11 }
    ) {
        param($Field, $Value)
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'batch-model'))
            $plans[3].sampleModel[$Field] = $Value
            { Assert-SampleBatchCapacity -Plans $plans } | Should Throw 'same sample model configuration'
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
            $script:queueAzureCalls.Count | Should Be 0
        }
    }

    It 'rejects a different valid identity set in one worker before checking batch capacity' {
        Invoke-QueueTestEnvironment {
            $plans = @(New-OfflineQueuePlans -OutputDirectory (Join-Path $TestDrive 'mixed-identity-sets'))
            $plans[1] = New-OfflineQueuePlan -OutputDirectory (Join-Path $TestDrive 'other-set') -QueueName q2 -IdentityResourceGroup 'rg-azsdk-identities-westus3-010126_000000' -NameSuffix 'westus3-010126_000000'
            { Assert-SampleBatchCapacity -Plans $plans } | Should Throw 'one explicit target and pipeline run'
            Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
        }
    }
}
