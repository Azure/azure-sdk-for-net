#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

Describe 'API-only wrapper with an isolated input boundary' {
    BeforeAll {
        $script:Names = @('AGENT_OUTPUT', 'GITHUB_REPOSITORY', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'PR_UPDATED_AT', 'GH_TOKEN', 'REVIEW_INPUT_MARKERS', 'AGENT_SESSION_LOG')
        $script:ApiPath = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs'
        $script:Sha = 'a' * 40
        $script:Base = 'b' * 40
    }
    BeforeEach {
        $script:Previous = @{}
        foreach ($name in $script:Names) { $script:Previous[$name] = [Environment]::GetEnvironmentVariable($name) }
        $dir = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        [void][IO.Directory]::CreateDirectory($dir)
        Copy-Item (Join-Path $PSScriptRoot 'Invoke-PrReReviewGuard.ps1') $dir
        Copy-Item (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1') $dir
        # This boundary deliberately has no transport; it cannot contact GitHub.
        $stub = @'
function Get-PrReReviewPullRequestInput {
    param($Repository, $Number, $ExpectedHeadSha, $ExpectedBaseSha, [switch]$ApiOnly)
    if (!$ApiOnly) { throw 'Scope switch missing.' }
    return $global:GuardApiFixture
}
function Assert-PrReReviewCurrentState {
    param($Repository, $Number, $ExpectedHeadSha, $ExpectedBaseSha)
    $global:GuardApiFreshnessCalls++
    if ($global:GuardApiStale) { throw 'head or base changed' }
    return 'fresh'
}
Export-ModuleMember -Function Get-PrReReviewPullRequestInput, Assert-PrReReviewCurrentState
'@
        [IO.File]::WriteAllText((Join-Path $dir 'PrReReviewInput.psm1'), $stub)
        $script:Wrapper = Join-Path $dir 'Invoke-PrReReviewGuard.ps1'
        $env:GITHUB_REPOSITORY = 'example/repo'; $env:PR_NUMBER = '1'; $env:PR_HEAD_SHA = $script:Sha
        $env:PR_BASE_SHA = $script:Base; $env:PR_UPDATED_AT = '2026-01-01T00:00:00Z'; $env:GH_TOKEN = 'synthetic'
        $env:AGENT_OUTPUT = Join-Path $dir 'output.json'
        $env:REVIEW_INPUT_MARKERS = Join-Path $dir 'markers.json'
        $env:AGENT_SESSION_LOG = Join-Path $dir 'session.jsonl'
        $output = @{items = @(@{type = 'submit_pull_request_review'; event = 'COMMENT'; body = 'API coverage: 1/1 API files reviewed'}); errors = @()}
        $markers = @{scope = 'api'; headSha = $script:Sha; files = @(@{path = $script:ApiPath; marker = '0123456789abcdef'; chunks = @(@{content = 'Exact API patch'})})}
        $event = @{type = 'tool.execution_complete'; data = @{success = $true; result = @{content = 'Exact API patch'}}}
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json $output -Depth 10))
        [IO.File]::WriteAllText($env:REVIEW_INPUT_MARKERS, (ConvertTo-Json $markers -Depth 10))
        [IO.File]::WriteAllText($env:AGENT_SESSION_LOG, (ConvertTo-Json $event -Depth 10 -Compress))
        $global:GuardApiFixture = @{HeadSha = $script:Sha; PrChangedFiles = 7; Files = @(@{filename = $script:ApiPath}); InlineTargets = @()}
        $global:GuardApiFreshnessCalls = 0; $global:GuardApiStale = $false
    }
    AfterEach {
        foreach ($entry in $script:Previous.GetEnumerator()) { [Environment]::SetEnvironmentVariable($entry.Key, $entry.Value) }
        Remove-Variable GuardApiFixture, GuardApiFreshnessCalls, GuardApiStale -Scope Global -ErrorAction SilentlyContinue
        $fixtureDirectory = Split-Path $script:Wrapper
        Get-Module PrReReviewInput, PrReReviewGuard | Where-Object { $_.Path -and (Split-Path $_.Path) -ceq $fixtureDirectory } | Remove-Module -ErrorAction SilentlyContinue
    }
    It 'checks captured API scope, exact read evidence and final freshness' {
        { & $script:Wrapper -ApiOnly } | Should -Not -Throw
        $global:GuardApiFreshnessCalls | Should -Be 1
    }
    It 'accepts an empty captured API scope only as a no-op and still checks freshness' {
        $global:GuardApiFixture.Files = @()
        $output = @{items = @(@{type = 'noop'; message = 'No API changes'}); errors = @()}
        [IO.File]::WriteAllText($env:AGENT_OUTPUT, (ConvertTo-Json $output -Depth 10))
        Remove-Item $env:REVIEW_INPUT_MARKERS
        { & $script:Wrapper -ApiOnly } | Should -Not -Throw
        $global:GuardApiFreshnessCalls | Should -Be 1
    }
    It 'fails closed on a malformed captured <Field>' -ForEach @(
        @{Field = 'Files'}, @{Field = 'InlineTargets'}, @{Field = 'PrChangedFiles'}, @{Field = 'HeadSha'}
    ) {
        $global:GuardApiFixture.Remove($Field)
        { & $script:Wrapper -ApiOnly } | Should -Throw
        $global:GuardApiFreshnessCalls | Should -Be 0
    }
    It 'rejects missing read evidence before the freshness check' {
        Remove-Item $env:REVIEW_INPUT_MARKERS
        { & $script:Wrapper -ApiOnly } | Should -Throw '*markers*'
        $global:GuardApiFreshnessCalls | Should -Be 0
    }
    It 'rejects a head or base movement immediately before publication' {
        $global:GuardApiStale = $true
        { & $script:Wrapper -ApiOnly } | Should -Throw '*head or base changed*'
        $global:GuardApiFreshnessCalls | Should -Be 1
    }
    It 'rejects a malformed base before input capture' {
        $env:PR_BASE_SHA = 'bad'
        { & $script:Wrapper -ApiOnly } | Should -Throw '*SHA*'
        $global:GuardApiFreshnessCalls | Should -Be 0
    }
}
