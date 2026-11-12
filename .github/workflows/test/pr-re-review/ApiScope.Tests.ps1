#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'PrReReviewGuard.psm1') -Force
    $script:ApiPath = 'sdk/widgets/Azure.Widgets/api/Azure.Widgets.net8.0.cs'
    $script:SourcePath = 'sdk/widgets/Azure.Widgets/src/Generated/Models/Widget.cs'
    function New-ApiOutput([string]$Body = 'API coverage: 1/1 API files reviewed', [object[]]$Extra = @()) {
        return @{items = @($Extra) + @(@{type = 'submit_pull_request_review'; event = 'COMMENT'; body = $Body}); errors = @()}
    }
    function New-ApiExpected([int]$Count = 1) {
        return @{
            Scope = 'api'; AnalyzedHeadSha = 'a' * 40; HeadSha = 'a' * 40
            ChangedFiles = 1; ChangedApiFiles = $Count; ThreadsBefore = 0; ThreadsNow = 0
            ApiFilePaths = @(if ($Count -ne 0) { $script:ApiPath })
            InlineTargets = @(@{path = $script:SourcePath; lineRanges = @(@{start = 11; end = 15})})
        }
    }
    function New-Inline([string]$Path, $Line = 12) {
        return @{type = 'create_pull_request_review_comment'; path = $Path; line = $Line; body = 'Check Namespace.Widget.Value.'}
    }
}

Describe 'Explicit API-only publication contract' {
    It 'accepts complete scoped coverage without claiming a full PR or thread review' {
        {Assert-PrReReviewOutput (New-ApiOutput) -Expected (New-ApiExpected)} | Should -Not -Throw
    }
    It 'does not accept an old full-PR coverage claim as API-only completion' {
        $body = 'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 1/1 changed files reviewed'
        {Assert-PrReReviewOutput (New-ApiOutput $body) -Expected (New-ApiExpected)} | Should -Throw '*API*coverage*'
    }
    It 'counts selected API files rather than all PR files' {
        $expected = New-ApiExpected
        $expected.ChangedFiles = 148
        {Assert-PrReReviewOutput (New-ApiOutput) -Expected $expected} | Should -Not -Throw
    }
    It 'rejects incomplete API coverage' {
        {Assert-PrReReviewOutput (New-ApiOutput 'API coverage: 0/1 API files reviewed') -Expected (New-ApiExpected)} | Should -Throw '*incomplete*'
    }
    It 'rejects a complete-looking count that differs from independently captured API scope' {
        {Assert-PrReReviewOutput (New-ApiOutput 'API coverage: 2/2 API files reviewed') -Expected (New-ApiExpected)} | Should -Throw '*API*'
    }
    It 'accepts only a no-op when the trusted API scope is empty' {
        $output = @{items = @(@{type = 'noop'; message = 'No API-file changes.'}); errors = @()}
        {Assert-PrReReviewOutput $output -Expected (New-ApiExpected 0)} | Should -Not -Throw
        {Assert-PrReReviewOutput (New-ApiOutput 'API coverage: 0/0 API files reviewed') -Expected (New-ApiExpected 0)} | Should -Throw '*no-op*'
    }
    It 'does not accept a no-op while API changes remain' {
        $output = @{items = @(@{type = 'noop'; message = 'Nothing to do.'}); errors = @()}
        {Assert-PrReReviewOutput $output -Expected (New-ApiExpected)} | Should -Throw
    }
    It 'rejects stale API review publication instead of waiving the count check' {
        $expected = New-ApiExpected
        $expected.HeadSha = 'b' * 40
        {Assert-PrReReviewOutput (New-ApiOutput) -Expected $expected} | Should -Throw '*head*'
    }
    It 'leaves existing thread state and replies out of this first API-only pass' -ForEach @(
        @{Type = 'resolve_pull_request_review_thread'}, @{Type = 'unresolve_review_thread'}, @{Type = 'reply_to_pull_request_review_comment'}
    ) {
        param($Type)
        $body = 'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 1/1 changed files reviewed'
        $output = New-ApiOutput $body @(@{type = $Type; thread_id = 'thread'; comment_id = '1'; body = 'Unrelated state change.'})
        {Assert-PrReReviewOutput $output -Expected (New-ApiExpected)} | Should -Throw '*API*thread*'
    }
}

Describe 'API findings use actual source diff anchors, not API listing positions' {
    It 'rejects direct inline comments on the oversized API listing' {
        $body = 'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 1/1 changed files reviewed'
        {Assert-PrReReviewOutput (New-ApiOutput $body @((New-Inline $script:ApiPath))) -Expected (New-ApiExpected)} | Should -Throw '*API listing*'
    }
    It 'accepts the corresponding generated source file at an independently listed diff line' {
        {Assert-PrReReviewOutput (New-ApiOutput -Extra @((New-Inline $script:SourcePath))) -Expected (New-ApiExpected)} | Should -Not -Throw
    }
    It 'rejects a guessed source file outside the scoped source candidate list' {
        $body = 'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 1/1 changed files reviewed'
        {Assert-PrReReviewOutput (New-ApiOutput $body @((New-Inline 'sdk/other/Azure.Other/src/Generated/Widget.cs'))) -Expected (New-ApiExpected)} | Should -Throw '*source*'
    }
    It 'rejects a correct filename at a line outside the actual source diff' {
        $body = 'Coverage: 0/0 threads fetched, 0/0 unresolved threads verified, 1/1 changed files reviewed'
        {Assert-PrReReviewOutput (New-ApiOutput $body @((New-Inline $script:SourcePath 4000))) -Expected (New-ApiExpected)} | Should -Throw '*diff*'
    }
    It 'uses the exact candidate path and range when same-named types occur in different namespaces' {
        $other = 'sdk/widgets/Azure.Widgets/src/Generated/Other/Widget.cs'
        $expected = New-ApiExpected
        $expected.InlineTargets += @{path = $other; lineRanges = @(@{start = 30; end = 35})}
        { Assert-PrReReviewOutput (New-ApiOutput -Extra @((New-Inline $other 31))) -Expected $expected } | Should -Not -Throw
        { Assert-PrReReviewOutput (New-ApiOutput -Extra @((New-Inline $other 12))) -Expected $expected } | Should -Throw '*diff*'
        { Assert-PrReReviewOutput (New-ApiOutput -Extra @((New-Inline $other.ToUpperInvariant() 31))) -Expected $expected } | Should -Throw '*source*'
    }
    It 'keeps a finding in the review summary when there is no confident inline target' {
        $output = New-ApiOutput "API coverage: 1/1 API files reviewed`n`nFinding: Namespace.Widget.Value is removed; no valid source diff anchor was found."
        $expected = New-ApiExpected
        $expected.InlineTargets = @()
        {Assert-PrReReviewOutput $output -Expected $expected} | Should -Not -Throw
    }
}

Describe 'API-only guard rejects ambiguous or invalid trusted inputs' {
    It 'rejects the old full coverage line even alongside valid API coverage' {
        $body = "API coverage: 1/1 API files reviewed`n> **Coverage:** 0/0 threads fetched, 0/0 unresolved threads verified, 1/1 changed files reviewed"
        { Assert-PrReReviewOutput (New-ApiOutput $body) -Expected (New-ApiExpected) } | Should -Throw '*Coverage*'
    }
    It 'rejects inline on a selected API file renamed out of the API directory' {
        $path = 'sdk/widgets/Azure.Widgets/src/FormerApi.cs'
        $expected = New-ApiExpected
        $expected.ApiFilePaths = @($path)
        $expected.InlineTargets = @(@{path = $path; lineRanges = @(@{start = 11; end = 15})})
        { Assert-PrReReviewOutput (New-ApiOutput -Extra @((New-Inline $path))) -Expected $expected } | Should -Throw '*API listing*'
    }
    It 'rejects <Label>' -ForEach @(
        @{Label = 'two source candidates for the same path'; Kind = 'duplicate'}
        @{Label = 'an invalid input scope'; Kind = 'badScope'}
        @{Label = 'a missing analyzed head'; Kind = 'missingHead'}
        @{Label = 'two equal malformed heads'; Kind = 'badHead'}
        @{Label = 'a fractional count'; Kind = 'fraction'}
        @{Label = 'a string count'; Kind = 'stringCount'}
        @{Label = 'a missing API path set'; Kind = 'missingPaths'}
        @{Label = 'a duplicate API path set'; Kind = 'duplicatePaths'}
        @{Label = 'missing source ranges'; Kind = 'missingRanges'}
        @{Label = 'a malformed range'; Kind = 'badRange'}
        @{Label = 'an inverted range'; Kind = 'invertedRange'}
    ) {
        $expected = New-ApiExpected
        switch ($Kind) {
            duplicate { $expected.InlineTargets += $expected.InlineTargets[0] }
            badScope { $expected.Scope = 'API' }
            missingHead { $expected.Remove('AnalyzedHeadSha') }
            badHead { $expected.HeadSha = 'bad'; $expected.AnalyzedHeadSha = 'bad' }
            fraction { $expected.ChangedApiFiles = 1.5 }
            stringCount { $expected.ChangedApiFiles = '1' }
            missingPaths { $expected.Remove('ApiFilePaths') }
            duplicatePaths { $expected.ChangedFiles = 2; $expected.ChangedApiFiles = 2; $expected.ApiFilePaths = @($script:ApiPath, $script:ApiPath) }
            missingRanges { $expected.InlineTargets[0].Remove('lineRanges') }
            badRange { $expected.InlineTargets[0].lineRanges = @(@{start = '1'; end = 15}) }
            invertedRange { $expected.InlineTargets[0].lineRanges = @(@{start = 15; end = 11}) }
        }
        $body = if ($Kind -eq 'duplicatePaths') { 'API coverage: 2/2 API files reviewed' } else { 'API coverage: 1/1 API files reviewed' }
        { Assert-PrReReviewOutput (New-ApiOutput $body @((New-Inline $script:SourcePath))) -Expected $expected } | Should -Throw
    }
    It 'rejects all out-of-scope writes even alongside an incomplete report' -ForEach @(
        @{Type = 'resolve_pull_request_review_thread'}, @{Type = 'unresolve_review_thread'},
        @{Type = 'reply_to_pull_request_review_comment'}, @{Type = 'add_comment'}
    ) {
        $output = @{items = @(@{type = $Type}, @{type = 'report_incomplete'}); errors = @()}
        { Assert-PrReReviewOutput $output -Expected (New-ApiExpected) } | Should -Throw
    }
    It 'rejects ingestion errors even when the scope is empty' {
        $output = @{items = @(@{type = 'noop'}); errors = @('bad output')}
        { Assert-PrReReviewOutput $output -Expected (New-ApiExpected 0) } | Should -Throw '*ingestion*'
    }
    It 'rejects a partial review paired with a tool failure' -ForEach @(
        @{Type = 'report_incomplete'}, @{Type = 'missing_data'}, @{Type = 'missing_tool'}
    ) {
        { Assert-PrReReviewOutput (New-ApiOutput -Extra @(@{type = $Type})) -Expected (New-ApiExpected) } | Should -Throw '*incomplete*'
    }
}

Describe 'API read evidence is bound to the independent scope' {
    BeforeEach {
        $script:MarkersPath = Join-Path $TestDrive 'api-markers.json'
        $script:LogPath = Join-Path $TestDrive 'api-session.jsonl'
        $script:ReadExpected = New-ApiExpected
        $script:ReadExpected.ApiFilePaths = @($script:ApiPath)
        $script:Markers = @{
            scope = 'api'; headSha = 'a' * 40
            files = @(@{path = $script:ApiPath; marker = '0123456789abcdef'; chunks = @(@{content = 'Exact API diff and end marker'})})
        }
        $event = @{type = 'tool.execution_complete'; data = @{success = $true; result = @{content = 'Exact API diff and end marker'}}}
        [IO.File]::WriteAllText($script:LogPath, (ConvertTo-Json $event -Depth 10 -Compress))
    }
    It 'accepts complete scoped content at the captured head' {
        [IO.File]::WriteAllText($script:MarkersPath, (ConvertTo-Json $script:Markers -Depth 10))
        {Assert-PrReReviewReadCoverage (New-ApiOutput) $script:MarkersPath $script:LogPath -Expected $script:ReadExpected} | Should -Not -Throw
    }
    It 'rejects a marker missing its chunks rather than treating it as read' {
        $script:Markers.files[0].Remove('chunks')
        [IO.File]::WriteAllText($script:MarkersPath, (ConvertTo-Json $script:Markers -Depth 10))
        {Assert-PrReReviewReadCoverage (New-ApiOutput) $script:MarkersPath $script:LogPath -Expected $script:ReadExpected} | Should -Throw '*malformed*'
    }
    It 'rejects a newline-only chunk even when another tool result exists' {
        $script:Markers.files[0].chunks[0].content = "`n"
        [IO.File]::WriteAllText($script:MarkersPath, (ConvertTo-Json $script:Markers -Depth 10))
        {Assert-PrReReviewReadCoverage (New-ApiOutput) $script:MarkersPath $script:LogPath -Expected $script:ReadExpected} | Should -Throw '*missing*'
    }
    It 'rejects markers from another review head' {
        $script:Markers.headSha = 'b' * 40
        [IO.File]::WriteAllText($script:MarkersPath, (ConvertTo-Json $script:Markers -Depth 10))
        {Assert-PrReReviewReadCoverage (New-ApiOutput) $script:MarkersPath $script:LogPath -Expected $script:ReadExpected} | Should -Throw '*head*'
    }
    It 'rejects a marker artifact that does not identify API scope' {
        $script:Markers.Remove('scope')
        [IO.File]::WriteAllText($script:MarkersPath, (ConvertTo-Json $script:Markers -Depth 10))
        {Assert-PrReReviewReadCoverage (New-ApiOutput) $script:MarkersPath $script:LogPath -Expected $script:ReadExpected} | Should -Throw '*scope*'
    }
    It 'rejects an empty exported subset even if the body claims all API files were read' {
        $script:Markers.files = @()
        [IO.File]::WriteAllText($script:MarkersPath, (ConvertTo-Json $script:Markers -Depth 10))
        {Assert-PrReReviewReadCoverage (New-ApiOutput) $script:MarkersPath $script:LogPath -Expected $script:ReadExpected} | Should -Throw '*API file set*'
    }
    It 'rejects markers for a different file even if its content occurs in the log' {
        $script:Markers.files[0].path = 'sdk/widgets/Azure.Widgets/api/Other.cs'
        [IO.File]::WriteAllText($script:MarkersPath, (ConvertTo-Json $script:Markers -Depth 10))
        {Assert-PrReReviewReadCoverage (New-ApiOutput) $script:MarkersPath $script:LogPath -Expected $script:ReadExpected} | Should -Throw '*omit API file*'
    }
}
