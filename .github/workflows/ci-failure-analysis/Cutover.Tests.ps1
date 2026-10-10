#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'CiFailureAnalysis.psm1')
    . (Join-Path $PSScriptRoot 'TestHelpers.ps1')
    $script:TriggerCondition = Get-CiYamlProperty (Get-CiWorkflowLines 'provisioning-review-trigger.yml') 'if'
    $script:ReviewCondition = Get-CiYamlProperty (Get-CiWorkflowLines 'provisioning-review.md') 'if'

    function Invoke-ProvisioningManualDispatcher {
        param([string]$Conclusion)

        $shell = if ($IsWindows) { Join-Path $env:ProgramFiles 'Git' 'bin' 'bash.exe' } else { (Get-Command bash -ErrorAction Stop).Source }
        $step = Get-CiWorkflowStep 'provisioning-review-trigger.yml' 'Dispatch provisioning review when in scope'
        $mock = @'
gh() {
  case "$*" in
    *"workflow run"*) echo "DISPATCHED $*" ;;
    *"isDraft"*) echo false ;;
    *"headRefOid"*) echo "$CHECK_RUN_HEAD_SHA" ;;
    *"pulls/42/files"*) echo 'sdk/compute/Azure.Provisioning.Compute/src/Compute.cs' ;;
    *"pulls/42"*) echo "$CHECK_RUN_HEAD_SHA" ;;
    *"commits/"*)
      if [[ "$*" == *".completed_at"* ]]; then
        printf '2026-09-10T18:00:00Z\t%s\t%s\t%s\n' "$TEST_CONCLUSION" "$CHECK_RUN_HEAD_SHA" "$CHECK_RUN_URL"
      fi ;;
    *"repos/Azure/azure-sdk-for-net/check-runs"*) ;;
    *) echo "Unexpected gh call: $*" >&2; return 90 ;;
  esac
}
'@
        return Invoke-CiTestProcess -FilePath $shell -Arguments @('--noprofile', '--norc', '-c', "$mock`n$($step.Run)") -Directory $TestDrive -Environment @{
            GITHUB_EVENT_NAME = 'workflow_dispatch'
            GITHUB_RUN_ID = '1000'
            GITHUB_SERVER_URL = 'https://github.com'
            REPOSITORY = 'Azure/azure-sdk-for-net'
            DEFAULT_BRANCH = 'main'
            MANUAL_PR_NUMBER = '42'
            PR_NUMBER = ''
            CHECK_RUN_HEAD_SHA = 'a' * 40
            CHECK_RUN_URL = 'https://dev.azure.com/azure-sdk/public/_build/results?buildId=456'
            TEST_CONCLUSION = $Conclusion
            GH_TOKEN = 'offline-test-token'
        }
    }
}

Describe 'CI ownership cutover original behavior' -Tag 'Original' {
    It '[C01] provisioning automatic review still accepts successful CI' {
        $values = @{ github = @{ event_name = 'check_run'; event = @{ check_run = @{ name = 'net - pullrequest'; conclusion = 'success' } } } }
        Invoke-CiWorkflowExpression $TriggerCondition $values | Should -BeTrue
    }

    It '[C02] provisioning automatic review no longer owns failed CI' {
        $values = @{ github = @{ event_name = 'check_run'; event = @{ check_run = @{ name = 'net - pullrequest'; conclusion = 'failure' } } } }
        Invoke-CiWorkflowExpression $TriggerCondition $values | Should -BeFalse
    }

    It '[<Id>] provisioning does not expand automatic review to <Label>' -ForEach @(
        @{ Id = 'C03'; Label = 'cancelled'; Conclusion = 'cancelled' }
        @{ Id = 'C04'; Label = 'neutral'; Conclusion = 'neutral' }
        @{ Id = 'C05'; Label = 'null'; Conclusion = $null }
    ) {
        $values = @{ github = @{ event_name = 'check_run'; event = @{ check_run = @{ name = 'net - pullrequest'; conclusion = $Conclusion } } } }
        Invoke-CiWorkflowExpression $TriggerCondition $values | Should -BeFalse
    }

    It '[C06] provisioning manual backfill still dispatches a successful terminal CI check' {
        $result = Invoke-ProvisioningManualDispatcher 'success'
        $result.ExitCode | Should -Be 0 -Because $result.Stderr
        $result.Stdout | Should -Match 'DISPATCHED workflow run provisioning-review\.lock\.yml'
    }

    It '[C07] provisioning manual backfill does not dispatch a failed terminal CI check' {
        $result = Invoke-ProvisioningManualDispatcher 'failure'
        $result.ExitCode | Should -Be 0 -Because $result.Stderr
        $result.Stdout | Should -Not -Match 'DISPATCHED'
        $result.Stdout | Should -Match 'failed CI is handled by the standalone CI failure-analysis workflow'
    }

    It '[C08] the directly dispatchable provisioning endpoint rejects explicit failed CI' {
        $values = @{ github = @{ event_name = 'workflow_dispatch'; event = @{ inputs = @{ check_run_conclusion = 'failure' } } } }
        Invoke-CiWorkflowExpression $ReviewCondition $values | Should -BeFalse
    }

    It '[C09] the provisioning endpoint preserves successful and unspecified manual reviews' {
        foreach ($conclusion in @('success', '')) {
            $values = @{ github = @{ event_name = 'workflow_dispatch'; event = @{ inputs = @{ check_run_conclusion = $conclusion } } } }
            Invoke-CiWorkflowExpression $ReviewCondition $values | Should -BeTrue
        }
    }

    It '[C10] management dispatcher, source and compiled endpoint are retired together' {
        foreach ($name in @('mgmt-review-trigger.yml', 'mgmt-review.md', 'mgmt-review.lock.yml')) {
            Test-Path (Join-Path $PSScriptRoot '..' $name) | Should -BeFalse -Because "$name must not remain dispatchable"
        }
    }
}
