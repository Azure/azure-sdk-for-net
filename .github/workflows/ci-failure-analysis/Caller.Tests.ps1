#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'CiFailureAnalysis.psm1')
    . (Join-Path $PSScriptRoot 'TestHelpers.ps1')

    function Invoke-CiTestCaller {
        param([string]$Scenario)

        $step = Get-CiWorkflowStep 'ci-failure-analysis-tests.yml' 'Run CI workflow guard and cutover tests'
        $step.Shell | Should -BeExactly 'pwsh'
        $mocks = @'
$ErrorActionPreference = 'Stop'
$script:Receipt = @{}

function Import-Module {
    [CmdletBinding()]
    param([string]$Name, [version]$MinimumVersion)

    if ($Name -cne 'Pester') {
        throw "Unexpected test-caller module: $Name"
    }
    $script:Receipt.module = $Name
    $script:Receipt.minimumVersion = [string]$MinimumVersion
    $script:Receipt.importErrorAction = [string]$PSBoundParameters['ErrorAction']
}

function Invoke-Pester {
    [CmdletBinding()]
    param([string]$Path, [string]$Output, [switch]$PassThru)

    $script:Receipt.pesterInvoked = $true
    $script:Receipt.path = $Path
    $script:Receipt.output = $Output
    $script:Receipt.passThru = [bool]$PassThru
    $script:Receipt.nativeExitCode = 0
    if ($env:CI_CALLER_SCENARIO -ceq 'passed-native-failure') {
        $pwsh = Join-Path $PSHOME $(if ($IsWindows) { 'pwsh.exe' } else { 'pwsh' })
        & $pwsh -NoProfile -NonInteractive -Command 'exit 1'
        $script:Receipt.nativeExitCode = $LASTEXITCODE
    }
    [IO.File]::WriteAllText($env:CI_CALLER_RECEIPT, (ConvertTo-Json $script:Receipt), [Text.UTF8Encoding]::new($false))

    switch -CaseSensitive ($env:CI_CALLER_SCENARIO) {
        'zero' { return [pscustomobject]@{ TotalCount = 0; Result = 'Passed' } }
        'failed' { return [pscustomobject]@{ TotalCount = 2; Result = 'Failed' } }
        'throws' { throw 'Injected Pester invocation failure.' }
        'passed' { return [pscustomobject]@{ TotalCount = 2; Result = 'Passed' } }
        'passed-native-failure' { return [pscustomobject]@{ TotalCount = 2; Result = 'Passed' } }
        default { throw 'Unexpected test-caller scenario.' }
    }
}
'@
        # GitHub appends this epilogue, so a successful Pester result alone cannot clear a native exit code.
        $epilogue = 'if ((Test-Path -LiteralPath variable:\LASTEXITCODE)) { exit $LASTEXITCODE }'
        $scriptPath = Join-Path $TestDrive 'ci-test-caller.ps1'
        $receiptPath = Join-Path $TestDrive 'ci-test-caller-receipt.json'
        [IO.File]::WriteAllText($scriptPath, "$mocks`n$($step.Run)`n$epilogue`n", [Text.UTF8Encoding]::new($false))
        $pwsh = Join-Path $PSHOME $(if ($IsWindows) { 'pwsh.exe' } else { 'pwsh' })
        $process = Invoke-CiTestProcess -FilePath $pwsh -Arguments @('-NoProfile', '-NonInteractive', '-File', $scriptPath) -Directory $TestDrive -Environment @{
            CI_CALLER_SCENARIO = $Scenario
            CI_CALLER_RECEIPT = $receiptPath
        }
        return @{
            Process = $process
            Receipt = ConvertFrom-CiJson ([IO.File]::ReadAllText($receiptPath))
        }
    }
}

Describe 'Actual CI test caller under the GitHub PowerShell wrapper' -Tag 'Caller' {
    It 'handles <Label>' -ForEach @(
        @{ Label = 'zero discovered tests'; Scenario = 'zero'; ExitCode = 1; Message = 'CI workflow guard and cutover tests did not pass' }
        @{ Label = 'failed tests'; Scenario = 'failed'; ExitCode = 1; Message = 'CI workflow guard and cutover tests did not pass' }
        @{ Label = 'Pester invocation failure'; Scenario = 'throws'; ExitCode = 1; Message = 'Injected Pester invocation failure' }
        @{ Label = 'passed tests'; Scenario = 'passed'; ExitCode = 0; Message = $null }
        @{ Label = 'passed tests with a leftover native exit code of 1'; Scenario = 'passed-native-failure'; ExitCode = 0; Message = $null }
    ) {
        $result = Invoke-CiTestCaller $Scenario
        $result.Process.ExitCode | Should -Be $ExitCode -Because $result.Process.Stderr
        $result.Receipt.module | Should -BeExactly 'Pester'
        ([version]$result.Receipt.minimumVersion -ge [version]'5.3.3') | Should -BeTrue
        $result.Receipt.importErrorAction | Should -BeExactly 'Stop'
        $result.Receipt.pesterInvoked | Should -BeTrue
        $result.Receipt.path.Replace('/', '\') | Should -BeExactly '.github\workflows\ci-failure-analysis'
        $result.Receipt.output | Should -BeExactly 'Detailed'
        $result.Receipt.passThru | Should -BeTrue
        if ($Message) {
            $result.Process.Stderr | Should -Match $Message
        }
        if ($Scenario -ceq 'passed-native-failure') {
            $result.Receipt.nativeExitCode | Should -Be 1
            $script:CallerWithoutExit = Get-CiWorkflowStep 'ci-failure-analysis-tests.yml' 'Run CI workflow guard and cutover tests'
            $script:CallerWithoutExit.Run = $CallerWithoutExit.Run -replace '(?m)^[ \t]*exit 0[ \t]*\r?$', ''
            Mock Get-CiWorkflowStep { $CallerWithoutExit }
            $control = Invoke-CiTestCaller $Scenario
            $control.Receipt.nativeExitCode | Should -Be 1
            $control.Process.ExitCode | Should -Be 1 -Because 'removing the explicit success exit must reproduce the inherited native failure'
        }
    }
}
