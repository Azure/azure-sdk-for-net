# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.

. (Join-Path $PSScriptRoot '../SampleCiHelpers.ps1')

Describe 'Function code publication' {
    BeforeEach {
        $script:publishOriginalQueue = $env:SAMPLE_QUEUE_NAME
        $env:SAMPLE_QUEUE_NAME = 'q1'
        $script:publishPlan = @{
            schemaVersion = 1; queueName = 'q1'; jobAttempt = '1'; ownerToken = '0123456789abcdef0123456789abcdef'
            definitionId = $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' })
            buildId = $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' })
            subscriptionId = '11111111-1111-1111-1111-111111111111'; tenantId = '22222222-2222-2222-2222-222222222222'
        }
        $script:publishPlan.resourceGroup = 'azsdk-samples-{0}-{1}-q1-1-01234567' -f $script:publishPlan.definitionId, $script:publishPlan.buildId
        $script:publishedZip = ''
        $script:publishedEntries = @()
        $script:publishFailure = $false
        $script:indexedFunctions = @('example-function/queue_trigger')
        $script:indexingDelay = 0
        $script:indexingQueries = 0
        $script:indexingFailure = $false
        Mock Start-Sleep {}
        Mock Invoke-SampleAzure {
            param($Arguments, $Sensitive)
            $Sensitive | Should Be $true
            $Arguments[[array]::IndexOf($Arguments, '--subscription') + 1] | Should Be $script:publishPlan.subscriptionId
            $Arguments[[array]::IndexOf($Arguments, '--resource-group') + 1] | Should Be $script:publishPlan.resourceGroup
            if ($Arguments[1] -eq 'deployment') {
                $Arguments[[array]::IndexOf($Arguments, '--build-remote') + 1] | Should Be 'true'
                $script:publishedZip = $Arguments[[array]::IndexOf($Arguments, '--src') + 1]
                $archive = [IO.Compression.ZipFile]::OpenRead($script:publishedZip)
                try {
                    $script:publishedEntries = @($archive.Entries.FullName)
                    @($archive.Entries | Where-Object { $_.LastWriteTime.Year -ne 2000 }).Count | Should Be 0
                } finally { $archive.Dispose() }
                if ($script:publishFailure) { throw 'Isolated code publication failure' }
                return @{}
            }
            if ($Arguments[1] -eq 'function') {
                $script:indexingQueries++
                if ($script:indexingFailure) { throw 'Isolated indexing query failure' }
                if ($script:indexingQueries -le $script:indexingDelay) { return @() }
                return $script:indexedFunctions
            }
            throw 'Unexpected Azure operation in isolated publication test.'
        }
    }
    AfterEach { $env:SAMPLE_QUEUE_NAME = $script:publishOriginalQueue }

    It 'publishes exactly the three source files and removes the temporary package' {
        Publish-SampleFunctionApp -Plan $script:publishPlan -FunctionAppName 'example-function'
        ($script:publishedEntries | Sort-Object) -join ',' | Should Be 'function_app.py,host.json,requirements.txt'
        Test-Path -LiteralPath $script:publishedZip | Should Be $false
        Assert-MockCalled Invoke-SampleAzure -Times 2 -Exactly -Scope It
        Assert-MockCalled Start-Sleep -Times 0 -Exactly -Scope It
    }

    It 'waits for delayed indexing without republishing the code' {
        $script:indexingDelay = 2
        Publish-SampleFunctionApp -Plan $script:publishPlan -FunctionAppName 'example-function'
        $script:indexingQueries | Should Be 3
        Assert-MockCalled Invoke-SampleAzure -Times 1 -Exactly -Scope It -ParameterFilter { $Arguments[1] -eq 'deployment' }
        Assert-MockCalled Start-Sleep -Times 2 -Exactly -Scope It -ParameterFilter { $Seconds -eq 10 }
        Test-Path -LiteralPath $script:publishedZip | Should Be $false
    }

    It 'cleans up the package when code publishing fails and never queries function indexing' {
        $script:publishFailure = $true
        { Publish-SampleFunctionApp -Plan $script:publishPlan -FunctionAppName 'example-function' } | Should Throw 'Isolated code publication failure'
        Test-Path -LiteralPath $script:publishedZip | Should Be $false
        Assert-MockCalled Invoke-SampleAzure -Times 1 -Exactly -Scope It
    }

    It 'fails before sample execution if queue_trigger was not indexed' {
        $script:indexedFunctions = @()
        { Publish-SampleFunctionApp -Plan $script:publishPlan -FunctionAppName 'example-function' } | Should Throw 'did not index queue_trigger'
        $script:indexingQueries | Should Be 30
        Assert-MockCalled Start-Sleep -Times 29 -Exactly -Scope It -ParameterFilter { $Seconds -eq 10 }
        Test-Path -LiteralPath $script:publishedZip | Should Be $false
    }

    It 'propagates indexing query errors without retrying or leaking the package' {
        $script:indexingFailure = $true
        { Publish-SampleFunctionApp -Plan $script:publishPlan -FunctionAppName 'example-function' } | Should Throw 'Isolated indexing query failure'
        $script:indexingQueries | Should Be 1
        Assert-MockCalled Start-Sleep -Times 0 -Exactly -Scope It
        Test-Path -LiteralPath $script:publishedZip | Should Be $false
    }

    It 'rejects an incomplete source package without contacting Azure' {
        { Publish-SampleFunctionApp -Plan $script:publishPlan -FunctionAppName 'example-function' -SourceDirectory $TestDrive } |
            Should Throw 'Missing Function App source file'
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
    }
}

Describe 'Explicit subscription targeting' {
    BeforeEach {
        $script:originalSubscription = $env:AZURE_SUBSCRIPTION_ID
        $script:originalTenant = $env:AZURE_TENANT_ID
        $script:originalQueue = $env:SAMPLE_QUEUE_NAME
        $env:AZURE_SUBSCRIPTION_ID = '11111111-1111-1111-1111-111111111111'
        $env:AZURE_TENANT_ID = '22222222-2222-2222-2222-222222222222'
        $env:SAMPLE_QUEUE_NAME = 'q1'
        $script:targetPlan = @{
            schemaVersion = 1
            definitionId = $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' })
            buildId = $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' })
            jobAttempt = '1'
            queueName = 'q1'
            ownerToken = '0123456789abcdef0123456789abcdef'
            subscriptionId = $env:AZURE_SUBSCRIPTION_ID
            tenantId = $env:AZURE_TENANT_ID
        }
        $script:targetPlan.resourceGroup = 'azsdk-samples-{0}-{1}-q1-1-01234567' -f $script:targetPlan.definitionId, $script:targetPlan.buildId
        $script:targetAccount = @{
            id = $env:AZURE_SUBSCRIPTION_ID
            tenantId = '22222222-2222-2222-2222-222222222222'
            state = 'Enabled'
            user = @{ type = 'servicePrincipal'; name = '33333333-3333-3333-3333-333333333333' }
        }
        $script:activeAccount = $script:targetAccount.Clone()
        $script:runnerIdentity = @{
            principalId = '44444444-4444-4444-4444-444444444444'
            clientId = $script:targetAccount.user.name
            tenantId = $script:targetAccount.tenantId
        }
        $script:targetUnavailable = $false
        Mock Get-SampleRunnerIdentity { return $script:runnerIdentity }
        Mock Invoke-SampleAzure {
            param($Arguments, $Sensitive)
            if ($Arguments[0] -ne 'account') { throw 'Only account metadata is expected during context selection.' }
            if ($Arguments[1] -eq 'set') {
                $script:activeAccount = $script:targetAccount.Clone()
                return
            }
            if ($Arguments -contains '--subscription') {
                if ($script:targetUnavailable) { throw 'private CLI diagnostic must not be printed' }
                return $script:targetAccount
            }
            return $script:activeAccount
        }
    }
    AfterEach {
        $env:AZURE_SUBSCRIPTION_ID = $script:originalSubscription
        $env:AZURE_TENANT_ID = $script:originalTenant
        $env:SAMPLE_QUEUE_NAME = $script:originalQueue
    }

    It 'requires an explicit environment subscription rather than the active subscription' {
        $env:AZURE_SUBSCRIPTION_ID = ''
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'AZURE_SUBSCRIPTION_ID'
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
    }

    It 'requires an explicit tenant variable before contacting Azure' {
        $env:AZURE_TENANT_ID = ''
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'AZURE_TENANT_ID'
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
    }

    It 'rejects a tenant macro or malformed tenant without echoing it' {
        $env:AZURE_TENANT_ID = '$(AZURE_TENANT_ID)'
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'tenant GUID'
        $env:AZURE_TENANT_ID = 'github_pat_unit_test_placeholder'
        $message = try { Set-SampleSubscriptionContext -Plan $script:targetPlan } catch { $_.Exception.Message }
        $message.Contains('github_pat_') | Should Be $false
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
    }

    It 'rejects a tenant different from the preview before contacting Azure' {
        $script:targetPlan.tenantId = '55555555-5555-5555-5555-555555555555'
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'deployment plan'
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
    }

    It 'rejects unresolved macros and malformed values without echoing them' {
        $env:AZURE_SUBSCRIPTION_ID = '$(AZURE_SUBSCRIPTION_ID)'
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'subscription GUID'
        $env:AZURE_SUBSCRIPTION_ID = 'github_pat_unit_test_placeholder'
        $message = try { Set-SampleSubscriptionContext -Plan $script:targetPlan } catch { $_.Exception.Message }
        $message.Contains('github_pat_') | Should Be $false
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
    }

    It 'rejects a plan for a different subscription before contacting Azure' {
        $script:targetPlan.subscriptionId = '55555555-5555-5555-5555-555555555555'
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'deployment plan'
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It
    }

    It 'uses the requested subscription without changing the authorized identity' {
        $identity = Set-SampleSubscriptionContext -Plan $script:targetPlan
        $identity.principalId | Should Be $script:runnerIdentity.principalId
        Assert-MockCalled Get-SampleRunnerIdentity -Times 1 -Exactly -Scope It -ParameterFilter { $SubscriptionId -eq $env:AZURE_SUBSCRIPTION_ID }
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It -ParameterFilter { $Arguments[1] -eq 'set' }
    }

    It 'selects an accessible subscription only within the same application and tenant' {
        $script:activeAccount.id = '55555555-5555-5555-5555-555555555555'
        $null = Set-SampleSubscriptionContext -Plan $script:targetPlan
        $script:activeAccount.id | Should Be $script:targetPlan.subscriptionId
        Assert-MockCalled Invoke-SampleAzure -Times 1 -Exactly -Scope It -ParameterFilter { $Arguments[1] -eq 'set' -and $Arguments[-1] -eq $env:AZURE_SUBSCRIPTION_ID }
    }

    It 'fails closed when the service connection cannot access the requested subscription' {
        $script:targetUnavailable = $true
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'cannot access AZURE_SUBSCRIPTION_ID'
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It -ParameterFilter { $Arguments[1] -eq 'set' }
    }

    It 'rejects a different tenant instead of switching identities' {
        $script:activeAccount.tenantId = '55555555-5555-5555-5555-555555555555'
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'same application and tenant'
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It -ParameterFilter { $Arguments[1] -eq 'set' }
    }

    It 'rejects a different application instead of switching identities' {
        $script:targetAccount.user = @{ type = 'servicePrincipal'; name = '55555555-5555-5555-5555-555555555555' }
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'same application and tenant'
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It -ParameterFilter { $Arguments[1] -eq 'set' }
    }

    It 'rejects personal logins for automated provisioning' {
        $script:activeAccount.user = @{ type = 'user'; name = 'unit-test@example.invalid' }
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'authorized Azure service connection'
    }

    It 'rejects a disabled subscription' {
        $script:targetAccount.state = 'Disabled'
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'same application and tenant'
    }

    It 'rejects token metadata for a different tenant' {
        $script:runnerIdentity.tenantId = '55555555-5555-5555-5555-555555555555'
        { Set-SampleSubscriptionContext -Plan $script:targetPlan } | Should Throw 'application identity'
    }
}

Describe 'Run-owned ephemeral resource guard' {
    BeforeEach {
        $script:originalQueue = $env:SAMPLE_QUEUE_NAME
        $env:SAMPLE_QUEUE_NAME = 'q1'
        $script:plan = @{
            schemaVersion = 1
            definitionId = $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' })
            buildId = $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' })
            jobAttempt = '1'
            queueName = 'q1'
            ownerToken = '0123456789abcdef0123456789abcdef'
            subscriptionId = '00000000-0000-0000-0000-000000000000'
            tenantId = '22222222-2222-2222-2222-222222222222'
        }
        $script:plan['resourceGroup'] = 'azsdk-samples-{0}-{1}-q1-1-01234567' -f $script:plan.definitionId, $script:plan.buildId
        $script:subscription = '00000000-0000-0000-0000-000000000000'
        $script:group = @{
            id = '/subscriptions/{0}/resourceGroups/{1}' -f $script:subscription, $script:plan.resourceGroup
            tags = Get-SampleOwnershipTags -Plan $script:plan
        }
    }
    AfterEach { $env:SAMPLE_QUEUE_NAME = $script:originalQueue }

    It 'accepts only exact run ownership' {
        Assert-SampleResourceGroupOwnership -Plan $script:plan -ResourceGroup $script:group -SubscriptionId $script:subscription
    }

    It 'rejects an unrelated resource group name' {
        $script:plan.resourceGroup = 'production-resource-group'
        { Assert-SampleRunPlan -Plan $script:plan } | Should Throw 'run-owned ephemeral'
    }

    It 'rejects a different subscription' {
        { Assert-SampleResourceGroupOwnership -Plan $script:plan -ResourceGroup $script:group `
            -SubscriptionId '11111111-1111-1111-1111-111111111111' } | Should Throw 'outside the deployment state'
    }

    It 'rejects a missing ownership tag' {
        $script:group.tags.Remove('sample-ci-owner')
        { Assert-SampleResourceGroupOwnership -Plan $script:plan -ResourceGroup $script:group `
            -SubscriptionId $script:subscription } | Should Throw 'exact CI ownership tags'
    }

    It 'rejects an incorrect ownership tag' {
        $script:group.tags['sample-ci-owner'] = 'a-different-run'
        { Assert-SampleResourceGroupOwnership -Plan $script:plan -ResourceGroup $script:group `
            -SubscriptionId $script:subscription } | Should Throw 'exact CI ownership tags'
    }

    It 'rejects groups with no tags' {
        $script:group.Remove('tags')
        { Assert-SampleResourceGroupOwnership -Plan $script:plan -ResourceGroup $script:group `
            -SubscriptionId $script:subscription } | Should Throw 'without ownership tags'
    }

    It 'rejects malformed ownership metadata' {
        $script:plan.ownerToken = 'not-a-run-token'
        { Assert-SampleRunPlan -Plan $script:plan } | Should Throw 'Invalid CI run ownership'
    }

    It 'rejects a missing plan subscription' {
        $script:plan.Remove('subscriptionId')
        { Assert-SampleRunPlan -Plan $script:plan } | Should Throw 'AZURE_SUBSCRIPTION_ID'
    }

    It 'rejects a missing plan tenant' {
        $script:plan.Remove('tenantId')
        { Assert-SampleRunPlan -Plan $script:plan } | Should Throw 'AZURE_TENANT_ID'
    }

    It 'rejects a resource group outside the planned subscription even if the state was changed' {
        $otherSubscription = '11111111-1111-1111-1111-111111111111'
        $script:group.id = '/subscriptions/{0}/resourceGroups/{1}' -f $otherSubscription, $script:plan.resourceGroup
        { Assert-SampleResourceGroupOwnership -Plan $script:plan -ResourceGroup $script:group -SubscriptionId $otherSubscription } |
            Should Throw 'outside the deployment state'
    }
}

Describe 'Cleanup target-state guard' {
    BeforeEach {
        $script:originalQueue = $env:SAMPLE_QUEUE_NAME
        $env:SAMPLE_QUEUE_NAME = 'q1'
        $plan = @{
            schemaVersion = 1
            definitionId = $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' })
            buildId = $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' })
            jobAttempt = '1'
            queueName = 'q1'
            ownerToken = '0123456789abcdef0123456789abcdef'
            subscriptionId = '11111111-1111-1111-1111-111111111111'
            tenantId = '22222222-2222-2222-2222-222222222222'
        }
        $plan.resourceGroup = 'azsdk-samples-{0}-{1}-q1-1-01234567' -f $plan.definitionId, $plan.buildId
        $script:cleanupState = @{
            schemaVersion = 1
            plan = $plan
            subscriptionId = $plan.subscriptionId
            tenantId = $plan.tenantId
            resourceGroupDeployment = 'sample-ci-rg-' + $plan.ownerToken
            status = 'Ready'
        }
        $script:cleanupPath = Join-Path $TestDrive 'cleanup-state.json'
        $script:cleanupScript = Join-Path $PSScriptRoot '../Remove-SampleResources.ps1'
    }
    AfterEach { $env:SAMPLE_QUEUE_NAME = $script:originalQueue }

    It 'rejects a changed tenant before any Azure request or deletion' {
        $script:cleanupState.tenantId = '33333333-3333-3333-3333-333333333333'
        $script:cleanupState | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath $script:cleanupPath -Encoding utf8
        $message = & {
            function az { throw 'The native Azure CLI must not run for invalid cleanup state.' }
            if ((Get-Command az).CommandType -ne 'Function') { throw 'Azure CLI isolation failed.' }
            try { & $script:cleanupScript -StatePath $script:cleanupPath -QueueName q1 -ConfirmCleanup } catch { $_.Exception.Message }
        }
        $message | Should Be 'Invalid cleanup state. No resources were deleted.'
        (Get-Content -LiteralPath $script:cleanupPath -Raw | ConvertFrom-Json).status | Should Be 'Ready'
    }

    It 'rejects a missing tenant before any Azure request or deletion' {
        $script:cleanupState.Remove('tenantId')
        $script:cleanupState | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath $script:cleanupPath -Encoding utf8
        $message = & {
            function az { throw 'The native Azure CLI must not run for invalid cleanup state.' }
            if ((Get-Command az).CommandType -ne 'Function') { throw 'Azure CLI isolation failed.' }
            try { & $script:cleanupScript -StatePath $script:cleanupPath -QueueName q1 -ConfirmCleanup } catch { $_.Exception.Message }
        }
        $message | Should Be 'Invalid cleanup state. No resources were deleted.'
        (Get-Content -LiteralPath $script:cleanupPath -Raw | ConvertFrom-Json).status | Should Be 'Ready'
    }
}

Describe 'GitHub MCP secret validation' {
    BeforeEach { $script:originalPat = $env:MCP_GITHUB_PAT }
    AfterEach { $env:MCP_GITHUB_PAT = $script:originalPat }

    It 'accepts a complete prefixed PAT without returning its value' {
        $env:MCP_GITHUB_PAT = 'github_pat_' + 'unit_test_placeholder'
        @(Assert-SampleMcpPat).Count | Should Be 0
    }

    It 'accepts a classic PAT prefix' {
        $env:MCP_GITHUB_PAT = 'ghp_' + 'UnitTestPlaceholder'
        @(Assert-SampleMcpPat).Count | Should Be 0
    }

    It 'rejects suffix-only tokens instead of adding a duplicate prefix' {
        $env:MCP_GITHUB_PAT = 'suffix-only-placeholder'
        { Assert-SampleMcpPat } | Should Throw 'complete GitHub PAT'
    }

    It 'rejects an undefined ADO macro' {
        $env:MCP_GITHUB_PAT = '$(MCP_GITHUB_PAT)'
        { Assert-SampleMcpPat } | Should Throw 'ADO secret'
    }

    It 'rejects a Bearer-prefixed value' {
        $env:MCP_GITHUB_PAT = 'Bearer github_pat_' + 'unit_test_placeholder'
        { Assert-SampleMcpPat } | Should Throw 'complete GitHub PAT'
    }
}

Describe 'Model availability preflight' {
    BeforeEach {
        $script:catalog = @(@{ model = @{
            name = 'gpt-4.1'; format = 'OpenAI'; version = '2025-04-14'; isDefaultVersion = $true
            skus = @(@{ name = 'GlobalStandard'; usageName = 'OpenAI.GlobalStandard.gpt-4.1';
                capacity = @{ minimum = 1; maximum = 100; step = 1 } })
        } })
    }

    It 'resolves a unique default model version and SKU' {
        $model = Resolve-SampleModel -Catalog $script:catalog -Name 'gpt-4.1' -Version 'auto' -Sku 'GlobalStandard' -Capacity 10
        $model.version | Should Be '2025-04-14'
        $model.usageName | Should Be 'OpenAI.GlobalStandard.gpt-4.1'
    }

    It 'rejects an unavailable model SKU' {
        { Resolve-SampleModel -Catalog $script:catalog -Name 'gpt-4.1' -Version 'auto' -Sku 'Standard' -Capacity 10 } |
            Should Throw 'unavailable'
    }

    It 'rejects an unavailable explicit version' {
        { Resolve-SampleModel -Catalog $script:catalog -Name 'gpt-4.1' -Version 'missing' -Sku 'GlobalStandard' -Capacity 10 } |
            Should Throw 'unavailable'
    }

    It 'rejects capacity outside the SKU limits' {
        { Resolve-SampleModel -Catalog $script:catalog -Name 'gpt-4.1' -Version 'auto' -Sku 'GlobalStandard' -Capacity 101 } |
            Should Throw 'SKU limits'
    }

    It 'rejects an ambiguous default version' {
        $other = @{ model = @{ name = 'gpt-4.1'; format = 'OpenAI'; version = 'another-default'; isDefaultVersion = $true } }
        { Resolve-SampleModel -Catalog @($script:catalog[0], $other) -Name 'gpt-4.1' -Version 'auto' -Sku 'GlobalStandard' -Capacity 10 } |
            Should Throw 'exactly one default'
    }
}

Describe 'Foundry account quota preflight' {
    BeforeEach {
        $script:accountQuota = @{ name = @{ value = 'AccountCount' }; currentValue = 3; limit = 200; unit = 'Count' }
        $script:modelQuota = @{ name = @{ value = 'OpenAI.GlobalStandard.gpt-4.1' }; currentValue = 0; limit = 1000 }
    }

    It 'accepts available account quota independently of model quota' {
        @(Assert-SampleAccountQuota -Usages @($script:modelQuota, $script:accountQuota) -Location 'eastus').Count | Should Be 0
    }

    It 'accepts exactly one remaining account slot' {
        $script:accountQuota.currentValue = 199
        Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'westus3'
    }

    It 'accepts numeric JSON doubles and an explicitly included status' {
        $script:accountQuota.currentValue = [double] 3
        $script:accountQuota.limit = [double] 200
        $script:accountQuota.status = 'Included'
        Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'westus3'
    }

    It 'rejects exhausted account quota even when model quota is available' {
        $script:accountQuota.currentValue = 200
        { Assert-SampleAccountQuota -Usages @($script:modelQuota, $script:accountQuota) -Location 'eastus' } |
            Should Throw "Insufficient Cognitive Services account quota in 'eastus'"
    }

    It 'rejects account quota already in overage' {
        $script:accountQuota.currentValue = 201
        { Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'eastus' } | Should Throw 'No resources were created'
    }

    It 'rejects blocked account quota even when the numeric limit has room' {
        $script:accountQuota.status = 'Blocked'
        { Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'eastus' } | Should Throw 'status: Blocked'
    }

    It 'rejects unknown account quota status' {
        $script:accountQuota.status = 'Unknown'
        { Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'eastus' } | Should Throw 'status: Unknown'
    }

    It 'rejects an empty usage response' {
        { Assert-SampleAccountQuota -Usages @() -Location 'eastus' } | Should Throw 'Cannot verify'
    }

    It 'rejects a missing account quota instead of treating model quota as account quota' {
        { Assert-SampleAccountQuota -Usages @($script:modelQuota) -Location 'eastus' } | Should Throw 'Cannot verify'
    }

    It 'rejects ambiguous duplicate account quota entries' {
        { Assert-SampleAccountQuota -Usages @($script:accountQuota, $script:accountQuota) -Location 'eastus' } | Should Throw 'Cannot verify'
    }

    It 'rejects a missing current count rather than assuming zero' {
        $script:accountQuota.Remove('currentValue')
        { Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'eastus' } | Should Throw 'Cannot verify'
    }

    It 'rejects a missing quota limit' {
        $script:accountQuota.Remove('limit')
        { Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'eastus' } | Should Throw 'Cannot verify'
    }

    It 'rejects nonnumeric usage values' {
        $script:accountQuota.currentValue = 'not-a-number'
        { Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'eastus' } | Should Throw 'Cannot verify'
    }

    It 'rejects a negative usage value' {
        $script:accountQuota.currentValue = -1
        { Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'eastus' } | Should Throw 'Cannot verify'
    }

    It 'rejects a nonfinite quota limit' {
        $script:accountQuota.limit = [double]::PositiveInfinity
        { Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'eastus' } | Should Throw 'Cannot verify'
    }

    It 'rejects a quota with the wrong unit' {
        $script:accountQuota.unit = 'CountPerSecond'
        { Assert-SampleAccountQuota -Usages @($script:accountQuota) -Location 'eastus' } | Should Throw 'Cannot verify'
    }
}

Describe 'Secret-safe ARM error diagnostics' {
    It 'extracts nested ARM error codes without returning messages or credentials' {
        $details = @{ error = @{ code = 'DeploymentFailed'; message = 'Bearer secret-placeholder'; details = @(
            @{ code = 'BadRequest'; message = 'github_pat_unit_test_placeholder'; request = @{ code = 'NotAnError' } }
        ) } }
        $codes = @(Get-SampleAzureErrorCodes -ErrorDetails $details)
        ($codes -join ',') | Should Be 'BadRequest,DeploymentFailed'
    }

    It 'deduplicates error codes' {
        $details = @{ code = 'DeploymentFailed'; details = @(@{ code = 'BadRequest' }, @{ code = 'BadRequest' }) }
        (@(Get-SampleAzureErrorCodes -ErrorDetails $details) -join ',') | Should Be 'BadRequest,DeploymentFailed'
    }

    It 'does not treat raw text as an error code' {
        @(Get-SampleAzureErrorCodes -ErrorDetails 'Bearer secret-placeholder').Count | Should Be 0
    }

    It 'rejects token-shaped code fields' {
        @(Get-SampleAzureErrorCodes -ErrorDetails @{ code = 'github_pat_unit_test_placeholder' }).Count | Should Be 0
        @(Get-SampleAzureErrorCodes -ErrorDetails @{ code = 'ghp_UnitTestPlaceholder' }).Count | Should Be 0
    }

    It 'rejects multiline code fields' {
        @(Get-SampleAzureErrorCodes -ErrorDetails @{ code = "BadRequest`nBearer secret-placeholder" }).Count | Should Be 0
    }

    It 'handles absent ARM error details' {
        @(Get-SampleAzureErrorCodes -ErrorDetails $null).Count | Should Be 0
    }

    It 'extracts codes from CLI preflight errors without returning secure messages' {
        $text = 'ERROR: {"code":"InvalidTemplateDeployment","message":"Bearer secret-placeholder","details":[{"code":"BadRequest","message":"github_pat_unit_test_placeholder"}]}'
        (@(Get-SampleAzureCliErrorCodes -Text $text) -join ',') | Should Be 'BadRequest,InvalidTemplateDeployment'
    }

    It 'extracts inner error codes from separate CLI JSON lines' {
        $text = "ERROR: {`"code`":`"DeploymentFailed`"}`nInner Errors:`n{`"code`":`"AuthorizationFailed`",`"message`":`"secret-placeholder`"}"
        (@(Get-SampleAzureCliErrorCodes -Text $text) -join ',') | Should Be 'AuthorizationFailed,DeploymentFailed'
    }

    It 'extracts a standard parenthesized CLI error code without its message' {
        (@(Get-SampleAzureCliErrorCodes -Text 'ERROR: (BadRequest) Bearer secret-placeholder') -join ',') | Should Be 'BadRequest'
    }

    It 'never returns unstructured CLI messages or token-shaped codes' {
        @(Get-SampleAzureCliErrorCodes -Text 'ERROR: github_pat_unit_test_placeholder').Count | Should Be 0
        @(Get-SampleAzureCliErrorCodes -Text 'ERROR: {"code":"ghp_UnitTestPlaceholder"}').Count | Should Be 0
        @(Get-SampleAzureCliErrorCodes -Text '').Count | Should Be 0
    }

    It 'keeps the protected CLI failure message limited to parsed error codes' {
        $failure = & {
            function az { $global:LASTEXITCODE = 1; 'ERROR: {"code":"BadRequest","message":"github_pat_unit_test_placeholder"}' }
            if ((Get-Command az).CommandType -ne 'Function') { throw 'The native Azure CLI must not run in this unit test.' }
            try { $null = Invoke-SampleAzure -Arguments @('deployment', 'group') -Sensitive } catch { $_.Exception.Message }
        }
        $failure | Should Be "Azure operation 'deployment group' failed (exit 1). ARM error codes: BadRequest."
    }

    It 'does not expose a protected response through a JSON parser error' {
        $failure = & {
            function az { $global:LASTEXITCODE = 0; 'not-json github_pat_unit_test_placeholder' }
            if ((Get-Command az).CommandType -ne 'Function') { throw 'The native Azure CLI must not run in this unit test.' }
            try { $null = Invoke-SampleAzure -Arguments @('account', 'get-access-token') -Sensitive } catch { $_.Exception.Message }
        }
        $failure | Should Be 'Azure operation returned invalid protected JSON; response content was suppressed.'
    }

    It 'still returns parsed protected JSON on success without logging it' {
        $response = & {
            function az { $global:LASTEXITCODE = 0; '{"value":"unit-test-placeholder"}' }
            if ((Get-Command az).CommandType -ne 'Function') { throw 'The native Azure CLI must not run in this unit test.' }
            Invoke-SampleAzure -Arguments @('account', 'show') -Sensitive
        }
        $response['value'] | Should Be 'unit-test-placeholder'
    }

}

Describe 'Service connection identity metadata' {
    BeforeEach {
        $script:identityClaims = @{
            oid = '11111111-1111-1111-1111-111111111111'
            appid = '22222222-2222-2222-2222-222222222222'
            tid = '33333333-3333-3333-3333-333333333333'
            idtyp = 'app'
            unrelated = 'must-not-be-returned'
        }
        Mock Invoke-SampleAzure {
            param($Arguments, $Sensitive)
            if (-not $Sensitive) { throw 'Tokens must use protected capture.' }
            $json = $script:identityClaims | ConvertTo-Json -Compress
            $payload = [Convert]::ToBase64String([Text.Encoding]::UTF8.GetBytes($json)).TrimEnd('=').Replace('+', '-').Replace('/', '_')
            return @{ accessToken = 'header.' + $payload + '.signature'; unrelated = 'must-not-be-returned' }
        }
    }

    It 'returns only public application identity identifiers' {
        $identity = Get-SampleRunnerIdentity
        $identity.Count | Should Be 3
        $identity.principalId | Should Be $script:identityClaims.oid
        $identity.clientId | Should Be $script:identityClaims.appid
        $identity.tenantId | Should Be $script:identityClaims.tid
        ($identity | ConvertTo-Json).Contains('must-not-be-returned') | Should Be $false
        ($identity | ConvertTo-Json).Contains('accessToken') | Should Be $false
    }

    It 'accepts a v2 application client claim' {
        $script:identityClaims.azp = $script:identityClaims.appid
        $script:identityClaims.Remove('appid')
        (Get-SampleRunnerIdentity).clientId | Should Be '22222222-2222-2222-2222-222222222222'
    }

    It 'rejects delegated user tokens rather than proposing a grant to a user' {
        $script:identityClaims.scp = 'user_impersonation'
        { Get-SampleRunnerIdentity } | Should Throw 'raw response were suppressed'
    }

    It 'rejects malformed metadata without echoing its contents' {
        $script:identityClaims.oid = 'github_pat_unit_test_placeholder'
        $failure = $null
        try { $null = Get-SampleRunnerIdentity } catch { $failure = $_.Exception.Message }
        $failure.Contains('github_pat_') | Should Be $false
        $failure | Should Be 'Could not identify the Azure service-connection application; token and raw response were suppressed.'
    }
}
