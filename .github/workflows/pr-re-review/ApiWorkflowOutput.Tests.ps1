# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewInput.psm1') -Force
}

Describe 'Deterministic API-work flag for the workflow gate' {
    BeforeEach {
        $script:PreviousFlagEnvironment = @{}
        foreach ($name in 'GITHUB_REPOSITORY', 'PR_NUMBER', 'PR_HEAD_SHA', 'PR_BASE_SHA', 'REVIEW_INPUT_DIR', 'REVIEW_INPUT_MARKERS', 'GITHUB_OUTPUT', 'GITHUB_STEP_SUMMARY') {
            $script:PreviousFlagEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
        }
        $env:GITHUB_REPOSITORY = 'Azure/azure-sdk-for-net'
        $env:PR_NUMBER = '123'
        $env:PR_HEAD_SHA = 'head'
        $env:PR_BASE_SHA = 'base'
        $root = Join-Path $TestDrive ([guid]::NewGuid())
        $null = [IO.Directory]::CreateDirectory($root)
        $env:REVIEW_INPUT_DIR = Join-Path $root 'input'
        $env:REVIEW_INPUT_MARKERS = Join-Path $root 'private/markers.json'
        $env:GITHUB_OUTPUT = Join-Path $root 'workflow-output.txt'
        $env:GITHUB_STEP_SUMMARY = $null
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi { throw 'Unexpected API call in test.' }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/pulls/123' } {
            '{"changed_files":1,"head":{"sha":"head"},"base":{"sha":"base"}}'
        }
    }
    AfterEach {
        foreach ($name in $script:PreviousFlagEnvironment.Keys) {
            [Environment]::SetEnvironmentVariable($name, $script:PreviousFlagEnvironment[$name])
        }
    }
    It 'emits an affirmative flag and the API count only after a successful scoped export' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs","status":"modified","patch":"@@ -1 +1 @@\n-old\n+new"}]]'
        }
        & (Join-Path $PSScriptRoot 'Invoke-PrReReviewInputExport.ps1')
        Test-Path $env:GITHUB_OUTPUT | Should -BeTrue
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT) | Should -Match '(?m)^has_api_changes=true$'
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT) | Should -Match '(?m)^api_files=1$'
    }
    It 'emits a negative flag for a PR with no API changes, without invoking the model' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":".github/workflows/pr-re-review.lock.yml","status":"modified","patch":"unrelated"}]]'
        }
        & (Join-Path $PSScriptRoot 'Invoke-PrReReviewInputExport.ps1')
        Test-Path $env:GITHUB_OUTPUT | Should -BeTrue
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT) | Should -Match '(?m)^has_api_changes=false$'
        [IO.File]::ReadAllText($env:GITHUB_OUTPUT) | Should -Match '(?m)^api_files=0$'
    }
    It 'does not authorize review when the head moves during API export' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } {
            '[[{"filename":"sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs","status":"added","patch":null}]]'
        }
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/contents/*' } { 'public class Widget {}' }
        $script:PrReads = 0
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/pulls/123' } {
            $script:PrReads++
            if ($script:PrReads -ge 3) { return '{"changed_files":1,"head":{"sha":"new-head"},"base":{"sha":"base"}}' }
            '{"changed_files":1,"head":{"sha":"head"},"base":{"sha":"base"}}'
        }
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewInputExport.ps1') } | Should -Throw '*stale*'
        Test-Path $env:GITHUB_OUTPUT | Should -BeFalse
    }
    It 'does not emit an affirmative flag when the independently captured inventory is incomplete' {
        Mock -ModuleName PrReReviewInput Invoke-PrReReviewGhApi -ParameterFilter { $Arguments -like '*/files*' } { '[]' }
        { & (Join-Path $PSScriptRoot 'Invoke-PrReReviewInputExport.ps1') } | Should -Throw '*listed 0*'
        Test-Path $env:GITHUB_OUTPUT | Should -BeFalse
    }
}
