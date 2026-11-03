# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

Describe 'Provisioning rejects ineligible regions before mutation' {
    It 'creates neither deployment state nor resources when Search S1 is unavailable' {
        $previousSubscription = $env:AZURE_SUBSCRIPTION_ID
        $previousTenant = $env:AZURE_TENANT_ID
        $previousQueue = $env:SAMPLE_QUEUE_NAME
        $previousPat = $env:MCP_GITHUB_PAT
        try {
            $env:MCP_GITHUB_PAT = 'github_pat_' + 'unit_test_placeholder'
            $env:AZURE_SUBSCRIPTION_ID = '11111111-1111-1111-1111-111111111111'
            $env:AZURE_TENANT_ID = '22222222-2222-2222-2222-222222222222'
            $env:SAMPLE_QUEUE_NAME = 'q1'
            $plan = @{
                schemaVersion = 1
                definitionId = $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' })
                buildId = $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' })
                jobAttempt = '1'; ownerToken = '0123456789abcdef0123456789abcdef'
                queueName = 'q1'
                subscriptionId = $env:AZURE_SUBSCRIPTION_ID; tenantId = $env:AZURE_TENANT_ID
                location = 'westus3'
            }
            $plan.resourceGroup = 'azsdk-samples-{0}-{1}-q1-1-01234567' -f $plan.definitionId, $plan.buildId
            $planPath = Join-Path $TestDrive 'plan.json'
            $statePath = Join-Path $TestDrive 'state.json'
            $plan | ConvertTo-Json -Depth 5 | Set-Content -LiteralPath $planPath -Encoding utf8
            $calls = [Collections.Generic.List[string]]::new()
            $provisioningScript = Join-Path $PSScriptRoot '../Invoke-SampleProvisioning.ps1'
            $failure = & {
                function az {
                    $global:LASTEXITCODE = 0
                    $calls.Add(($args -join ' '))
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
                    if ($args[0] -eq 'group' -and $args[1] -eq 'exists') { return 'false' }
                    if ($args[0] -eq 'rest' -and $args[2] -eq 'get') {
                        return '{"value":[{"regionName":"westus3","skus":[]}]}'
                    }
                    throw 'Unexpected or mutating native Azure command in the isolated preflight test.'
                }
                if ((Get-Command az).CommandType -ne 'Function') { throw 'Azure CLI isolation failed.' }
                try {
                    & $provisioningScript -PlanPath $planPath -StatePath $statePath -QueueName q1 -ConfirmProvisioning
                } catch { $_.Exception.Message }
            }
            $failure | Should Match 'AI Search S1 is not offered'
            Test-Path -LiteralPath $statePath | Should Be $false
            @($calls | Where-Object { $_ -match '\b(create|delete|set|register)\b' }).Count | Should Be 0
            @($calls | Where-Object { $_ -match '^provider |Microsoft.Authorization/roleAssignments' }).Count | Should Be 0
        } finally {
            $env:AZURE_SUBSCRIPTION_ID = $previousSubscription
            $env:AZURE_TENANT_ID = $previousTenant
            $env:SAMPLE_QUEUE_NAME = $previousQueue
            $env:MCP_GITHUB_PAT = $previousPat
        }
    }
}