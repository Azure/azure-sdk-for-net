# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

. (Join-Path $PSScriptRoot '../SampleCiHelpers.ps1')

Describe 'Cleanup script behavior with an isolated Azure CLI' {
    BeforeEach {
        $script:originalSubscription = $env:AZURE_SUBSCRIPTION_ID
        $script:originalTenant = $env:AZURE_TENANT_ID
        $script:originalQueue = $env:SAMPLE_QUEUE_NAME
        $env:AZURE_SUBSCRIPTION_ID = '11111111-1111-1111-1111-111111111111'
        $env:AZURE_TENANT_ID = '22222222-2222-2222-2222-222222222222'
        $env:SAMPLE_QUEUE_NAME = 'q1'
        $plan = @{
            schemaVersion = 1
            definitionId = $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' })
            buildId = $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' })
            jobAttempt = '1'
            queueName = 'q1'
            ownerToken = '0123456789abcdef0123456789abcdef'
            subscriptionId = $env:AZURE_SUBSCRIPTION_ID
            tenantId = $env:AZURE_TENANT_ID
        }
        $plan.resourceGroup = 'azsdk-samples-{0}-{1}-q1-1-01234567' -f $plan.definitionId, $plan.buildId
        $script:fixture = @{
            statePath = Join-Path $TestDrive 'cleanup.json'
            scriptPath = Join-Path $PSScriptRoot '../Remove-SampleResources.ps1'
            state = @{
                schemaVersion = 1; plan = $plan; subscriptionId = $plan.subscriptionId; tenantId = $plan.tenantId
                resourceGroupDeployment = 'sample-ci-rg-' + $plan.ownerToken; status = 'Ready'
            }
            group = @{
                id = '/subscriptions/{0}/resourceGroups/{1}' -f $plan.subscriptionId, $plan.resourceGroup
                tags = Get-SampleOwnershipTags -Plan $plan
            }
            exists = $true
            deletionFails = $false
            deletionLeavesGroup = $false
            calls = [Collections.Generic.List[string]]::new()
        }
    }
    AfterEach {
        $env:AZURE_SUBSCRIPTION_ID = $script:originalSubscription
        $env:AZURE_TENANT_ID = $script:originalTenant
        $env:SAMPLE_QUEUE_NAME = $script:originalQueue
    }

    function Invoke-IsolatedCleanup {
        param([switch] $Apply, [switch] $Preview)
        $fixture = $script:fixture
        $fixture.state | ConvertTo-Json -Depth 8 | Set-Content -LiteralPath $fixture.statePath -Encoding utf8
        & {
            function az {
                $global:LASTEXITCODE = 0
                $fixture.calls.Add(($args -join ' '))
                if ($args[0] -eq 'account') {
                    if ($args[1] -eq 'get-access-token') {
                        $claims = @{ oid = '44444444-4444-4444-4444-444444444444';
                            appid = '33333333-3333-3333-3333-333333333333'; tid = $env:AZURE_TENANT_ID; idtyp = 'app' }
                        $payload = [Convert]::ToBase64String([Text.Encoding]::UTF8.GetBytes(($claims | ConvertTo-Json -Compress))).TrimEnd('=').Replace('+', '-').Replace('/', '_')
                        return (@{ accessToken = 'header.' + $payload + '.signature' } | ConvertTo-Json -Compress)
                    }
                    return (@{ id = $env:AZURE_SUBSCRIPTION_ID; tenantId = $env:AZURE_TENANT_ID; state = 'Enabled';
                        user = @{ type = 'servicePrincipal'; name = '33333333-3333-3333-3333-333333333333' } } | ConvertTo-Json -Compress)
                }
                if ($args[0] -eq 'group' -and $args[1] -eq 'exists') { return ($fixture.exists | ConvertTo-Json) }
                if ($args[0] -eq 'group' -and $args[1] -eq 'show') { return ($fixture.group | ConvertTo-Json -Depth 5) }
                if ($args[0] -eq 'group' -and $args[1] -eq 'delete') {
                    if ($fixture.deletionFails) { $global:LASTEXITCODE = 1; return }
                    if (-not $fixture.deletionLeavesGroup) { $fixture.exists = $false }
                    return
                }
                if ($args[0] -eq 'deployment' -and $args[1] -eq 'sub' -and $args[2] -eq 'delete') { return }
                throw 'Unexpected native Azure command in isolated cleanup test.'
            }
            if ((Get-Command az).CommandType -ne 'Function') { throw 'Azure CLI isolation failed.' }
            $failure = $null
            try { & $fixture.scriptPath -StatePath $fixture.statePath -QueueName q1 -ConfirmCleanup:$Apply -WhatIf:$Preview }
            catch { $failure = $_.Exception.Message }
            return [pscustomobject]@{
                failure = $failure
                state = Get-Content -LiteralPath $fixture.statePath -Raw | ConvertFrom-Json -AsHashtable
                deletes = @($fixture.calls | Where-Object { $_ -match '^(group delete|deployment sub delete) ' })
            }
        }
    }

    It 'does not delete or mark completion without explicit confirmation' {
        $result = Invoke-IsolatedCleanup
        $result.failure | Should BeNullOrEmpty
        $result.deletes.Count | Should Be 0
        $result.state.status | Should Be 'Ready'
    }

    It 'does not mark WhatIf complete even when only deployment history remains' {
        $script:fixture.exists = $false
        $result = Invoke-IsolatedCleanup -Apply -Preview
        $result.failure | Should BeNullOrEmpty
        $result.deletes.Count | Should Be 0
        $result.state.status | Should Be 'Ready'
    }

    It 'refuses a foreign ownership tag before deletion' {
        $script:fixture.group.tags['sample-ci-owner'] = 'another-run'
        $result = Invoke-IsolatedCleanup -Apply
        $result.failure | Should Match 'ownership tags'
        $result.deletes.Count | Should Be 0
        $result.state.status | Should Be 'Ready'
    }

    It 'deletes only the exact planned group and subscription deployment' {
        $result = Invoke-IsolatedCleanup -Apply
        $result.failure | Should BeNullOrEmpty
        $result.deletes.Count | Should Be 2
        $result.deletes[0] | Should Match ('^group delete --name ' + $script:fixture.state.plan.resourceGroup + ' --subscription ' + $env:AZURE_SUBSCRIPTION_ID + ' --yes ')
        $result.deletes[1] | Should Match ('^deployment sub delete --name ' + $script:fixture.state.resourceGroupDeployment + ' --subscription ' + $env:AZURE_SUBSCRIPTION_ID + ' ')
        $result.state.status | Should Be 'CleanedUp'
    }

    It 'preserves incomplete state if group deletion fails' {
        $script:fixture.deletionFails = $true
        $result = Invoke-IsolatedCleanup -Apply
        $result.failure | Should Match 'failed'
        $result.deletes.Count | Should Be 1
        $result.state.status | Should Be 'Ready'
    }

    It 'requires the group to be absent before recording completion' {
        $script:fixture.deletionLeavesGroup = $true
        $result = Invoke-IsolatedCleanup -Apply
        $result.failure | Should Match 'still exists'
        $result.deletes.Count | Should Be 1
        $result.state.status | Should Be 'Ready'
    }
}