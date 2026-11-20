#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    . (Join-Path $PSScriptRoot 'TestHelpers.ps1')
}

Describe 'CI failure analysis PowerShell runner requirements' -Tag 'RunnerRequirement' {
    It '<Workflow> job <Job> uses the full hosted PowerShell image' -ForEach @(
        @{ Workflow = 'ci-failure-analysis.lock.yml'; Job = 'pre_activation' }
        @{ Workflow = 'ci-failure-analysis.lock.yml'; Job = 'safe_outputs' }
        @{ Workflow = 'ci-failure-analysis-trigger.yml'; Job = 'prepare' }
        @{ Workflow = 'ci-failure-analysis-trigger.yml'; Job = 'finalize' }
    ) {
        $jobLines = Get-CiJobLines (Get-CiWorkflowLines $Workflow) $Job
        Get-CiYamlProperty $jobLines 'runs-on' | Should -BeExactly 'ubuntu-latest' -Because 'the PowerShell guard requires the full hosted image'
    }
}
