# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    $script:WorkflowPath = Join-Path $PSScriptRoot '..' 'pr-re-review.md'
    $script:Workflow = [IO.File]::ReadAllText($script:WorkflowPath)
    $script:LockLines = [IO.File]::ReadAllLines((Join-Path $PSScriptRoot '..' 'pr-re-review.lock.yml'))
    function Get-ApiWorkflowCompiledJob([string]$Name) {
        $start = [array]::IndexOf($script:LockLines, "  ${Name}:")
        if ($start -lt 0) { return '' }
        $end = $start + 1
        while ($end -lt $script:LockLines.Count -and $script:LockLines[$end] -cnotmatch '^  [A-Za-z_][A-Za-z0-9_-]*:') { $end++ }
        return ($script:LockLines[$start..($end - 1)] -join "`n")
    }
}

Describe 'API review workflow scope and trusted input wiring' {
    It 'selects the input in a separate read-only job before invoking the model' {
        $job = Get-ApiWorkflowCompiledJob 'api_scope'
        $job | Should -Not -BeNullOrEmpty
        ($job -match '(?m)^      contents: read$') | Should -BeTrue
        ($job -match '(?m)^      pull-requests: read$') | Should -BeTrue
        ($job -notmatch '(?m)^      \S+: write$') | Should -BeTrue
        ($job -match 'Invoke-PrReReviewInputExport\.ps1') | Should -BeTrue
        ($job -notmatch 'copilot-requests:|copilot.*--prompt|npm (?:install|ci)|dotnet (?:build|test|restore)') | Should -BeTrue
    }

    It 'retains the compiler-managed activation dependency alongside API selection' {
        $agent = Get-ApiWorkflowCompiledJob 'agent'
        $needs = [regex]::Match($agent, '(?m)^    needs:.*(?:\r?\n {6}.*)*').Value
        ($needs -match '\bactivation\b') | Should -BeTrue
        ($needs -match '\bapi_scope\b') | Should -BeTrue
    }

    It 'does not invoke the agent for an empty or missing API-work flag' {
        $agent = Get-ApiWorkflowCompiledJob 'agent'
        $condition = [regex]::Match($agent, '(?m)^    if:.*(?:\r?\n {6}.*)*').Value
        ($condition -match "needs\.api_scope\.result == 'success'") | Should -BeTrue
        ($condition -match "needs\.api_scope\.outputs\.has_api_changes == 'true'") | Should -BeTrue
    }

    It 'uses trusted base helpers rather than executing the PR helper changes' {
        $job = Get-ApiWorkflowCompiledJob 'api_scope'
        ($job -match 'ref: \$\{\{ github\.event\.pull_request\.base\.sha \}\}') | Should -BeTrue
        ($job -match 'persist-credentials: false') | Should -BeTrue
        ($job -notmatch 'ref: \$\{\{ github\.event\.pull_request\.head\.sha \}\}') | Should -BeTrue
    }

    It 'mounts only the visible API export with the normal read-only action assets' {
        $agent = Get-ApiWorkflowCompiledJob 'agent'
        ($agent -match 'name: pr-re-review-api-input') | Should -BeTrue
        ($agent -match 'path: \$\{\{ runner\.temp \}\}/gh-aw/actions/api-review-input') | Should -BeTrue
        ($agent -notmatch 'name: pr-re-review-api-markers') | Should -BeTrue
        ($agent -match '--mount "\$\{RUNNER_TEMP\}/gh-aw:\$\{RUNNER_TEMP\}/gh-aw:ro"') | Should -BeTrue
    }

    It 'separates the independently captured markers from the visible API data' {
        $job = Get-ApiWorkflowCompiledJob 'api_scope'
        ($job -match 'name: pr-re-review-api-input') | Should -BeTrue
        ($job -match 'name: pr-re-review-api-markers') | Should -BeTrue
        ($job -match 'REVIEW_INPUT_DIR: \$\{\{ runner\.temp \}\}/gh-aw/actions/api-review-input') | Should -BeTrue
        ($job -match 'REVIEW_INPUT_MARKERS: \$\{\{ runner\.temp \}\}/api-review-markers/markers\.json') | Should -BeTrue
    }

    It 'cannot run the legacy custom thread writer if the API publication guard fails' {
        $writer = Get-ApiWorkflowCompiledJob 'unresolve_review_thread'
        $needs = [regex]::Match($writer, '(?m)^    needs:.*(?:\r?\n {6}.*)*').Value
        ($needs -match '\bsafe_outputs\b') | Should -BeTrue
        ($writer -match "needs\.safe_outputs\.result == 'success'") | Should -BeTrue
    }

    It 'retains the existing model CLI and time limit rather than introducing a controller' {
        ($script:Workflow -match '(?m)^timeout-minutes: 25$') | Should -BeTrue
        ($script:Workflow -match '(?m)^  id: copilot$') | Should -BeTrue
        ($script:Workflow -match '(?m)^  version: "1\.0\.80"$') | Should -BeTrue
        ($script:Workflow -notmatch 'ReviewContinuation|ReviewNativeWorker|Invoke-NativeReview|ReviewSupervisor') | Should -BeTrue
    }

    It 'makes non-API files informational rather than coverage assignments' {
        ($script:Workflow -match 'Other changed files are \*\*not review assignments\*\*') | Should -BeTrue
        ($script:Workflow -match '`prChangedFiles` is informational, not the coverage denominator') | Should -BeTrue
        ($script:Workflow -match 'API coverage: <reviewed>/<changed> API files reviewed') | Should -BeTrue
    }

    It 'requires verified symbol identity and uses body fallback rather than guessed API anchors' {
        ($script:Workflow -match 'fully qualified namespace, declaring type and affected member/overload') | Should -BeTrue
        ($script:Workflow -match 'matching filename alone is not proof') | Should -BeTrue
        ($script:Workflow -match 'Never use an API listing path or API-listing line number') | Should -BeTrue
        ($script:Workflow -match 'no valid inline line exists, put the finding in the final review body') | Should -BeTrue
        ($script:Workflow -match 'Never recommend manually editing generated code') | Should -BeTrue
    }

    It 'keeps unrelated review-thread state unchanged' {
        ($script:Workflow -match 'Do not reply to, resolve, or reopen existing threads') | Should -BeTrue
        ($script:Workflow -match 'Do not re-verify every old resolved/unresolved thread') | Should -BeTrue
    }
}
