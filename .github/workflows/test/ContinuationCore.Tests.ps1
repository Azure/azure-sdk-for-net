#Requires -Version 7.3
BeforeAll {
    Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewContinuation.psm1') -Force
    Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewSerialization.psm1') -Force
    function Element($Value) {
        $document = [Text.Json.JsonDocument]::Parse((ConvertTo-Json -InputObject $Value -Depth 30 -Compress))
        try { return $document.RootElement.Clone() } finally { $document.Dispose() }
    }
    function Test-State([int] $Count = 9) {
        $files = @(); for ($i=0; $i -lt $Count; $i++) { $files += [ordered]@{filename="f$i.cs";status='modified';patch='diff'} }
        $snapshot = Element ([ordered]@{head_sha=('a'*40);base_sha=('b'*40);pull_number=1;changed_files=$Count;files=$files;threads=@()})
        return New-ContinuationState $snapshot (Get-JsDigest ($snapshot.GetRawText()))
    }
    function Completion([object[]] $Ids) {
        $results = @($Ids | ForEach-Object { [ordered]@{id=$_;status='complete';reasoning='reviewed';findings=@();action='none'} })
        return Element @{results=$results}
    }
}
Describe 'Read-only continuation prompt policy' {
    BeforeEach {
        $snapshot = Element ([ordered]@{head_sha=('a'*40);base_sha=('b'*40);diff_base_sha=('c'*40);pull_number=1;changed_files=2;files=@([ordered]@{filename='f0.cs';status='modified';patch='diff'},[ordered]@{filename='f1.cs';status='modified';patch='diff'});threads=@()})
        $script:promptState = New-ContinuationState $snapshot (Get-JsDigest ($snapshot.GetRawText()))
        $script:promptAssignment = Get-ContinuationAssignment $script:promptState ('1'*32)
        $script:promptPayload = [ordered]@{
            snapshot=(ConvertFrom-Json -InputObject $snapshot.GetRawText() -AsHashtable -DateKind String)
            batch=@([ordered]@{id='file:0';file=[ordered]@{filename='f0.cs';status='modified';patch='diff'}},[ordered]@{id='file:1';file=[ordered]@{filename='f1.cs';status='modified';patch='diff'}})
            original='Trusted rules.';nonce=('1'*32);attempt_id=$script:promptAssignment.attempt_id;maxPatchBytes=48000
            context_index='/context/index.json';prior_results_path='/root/progress.json'
            input_paths=@{'file:0'=@{patch='/context/file-0.patch';history='/context/file-0.json'};'file:1'=@{patch='/context/file-1.patch';history='/context/file-1.json'}}
        }
    }
    It 'constructs prompts without committing results, attempts, or backoff' {
        $before = ConvertTo-ContinuationJson (Get-ContinuationCheckpoint $script:promptState)
        $value = Get-ContinuationWorkerPrompt $script:promptState (Element $script:promptPayload)
        $value.prefix | Should -Match 'read-only worker, NOT the publisher'
        $value.payloadJson | Should -Match '"delivery_nonce":"11111111111111111111111111111111"'
        (ConvertTo-ContinuationJson (Get-ContinuationCheckpoint $script:promptState)) | Should -BeExactly $before
        $script:promptState.Pending.Count | Should -Be 2
        $script:promptState.BatchLimit | Should -Be 8
        $script:promptState.Active.Id | Should -Be $script:promptAssignment.attempt_id
        { Complete-ContinuationReview $script:promptState } | Should -Throw '*Incomplete*'
    }
    It 'rejects stale prompt bindings while preserving the original active assignment' {
        $script:promptPayload.attempt_id++
        { Get-ContinuationWorkerPrompt $script:promptState (Element $script:promptPayload) } | Should -Throw '*active assignment*'
        $script:promptPayload.attempt_id--
        $script:promptPayload.nonce = '2'*32
        { Get-ContinuationWorkerPrompt $script:promptState (Element $script:promptPayload) } | Should -Throw '*nonce*'
        $script:promptPayload.nonce = '1'*32
        $script:promptPayload.batch[0].file.patch = 'forged'
        { Get-ContinuationWorkerPrompt $script:promptState (Element $script:promptPayload) } | Should -Throw '*active assignment*'
        $script:promptPayload.batch[0].file.patch = 'diff'
        $script:promptPayload.snapshot.head_sha = 'd'*40
        { Get-ContinuationWorkerPrompt $script:promptState (Element $script:promptPayload) } | Should -Throw '*captured snapshot*'
        $script:promptPayload.snapshot.head_sha = 'a'*40
        $null = Get-ContinuationWorkerPrompt $script:promptState (Element $script:promptPayload)
        $script:promptState.Results.Count | Should -Be 0
        $script:promptState.Attempts.Count | Should -Be 0
    }
    It 'keeps completion transactional and delivery-gated after constructing a prompt' {
        $null = Get-ContinuationWorkerPrompt $script:promptState (Element $script:promptPayload)
        $ids = @($script:promptAssignment.ids[0], 'foreign')
        { Complete-ContinuationAssignment $script:promptState (Element $script:promptAssignment.attempt_id) ('1'*32) (Element $true) (Completion $ids) } | Should -Throw '*Unassigned*'
        $script:promptState.Results.Count | Should -Be 0
        $script:promptState.Attempts.Count | Should -Be 0
        $script:promptState.Pending.Count | Should -Be 2
        { Complete-ContinuationAssignment $script:promptState (Element $script:promptAssignment.attempt_id) ('1'*32) (Element $false) (Completion $script:promptAssignment.ids) } | Should -Throw '*verified delivery*'
        { Complete-ContinuationAssignment $script:promptState (Element $script:promptAssignment.attempt_id) ('2'*32) (Element $true) (Completion $script:promptAssignment.ids) } | Should -Throw '*nonce*'
        $null = Complete-ContinuationAssignment $script:promptState (Element $script:promptAssignment.attempt_id) ('1'*32) (Element $true) (Completion $script:promptAssignment.ids)
        $script:promptState.Results.Count | Should -Be 2
        $script:promptState.Attempts.Count | Should -Be 1
    }
}
Describe 'Transactional continuation policy' {
    BeforeEach { $script:state = Test-State; $script:nonce = '1'*32 }
    It 'rejects a differently encoded snapshot rather than hashing pretty artifact bytes' {
        $compact = $script:state.Snapshot.GetRawText()
        $pretty = ConvertFrom-Json -InputObject $compact -AsHashtable -DateKind String | ConvertTo-Json -Depth 30
        $document = [Text.Json.JsonDocument]::Parse($pretty)
        try { { New-ContinuationState $document.RootElement $script:state.SnapshotHash } | Should -Throw '*representation*' }
        finally { $document.Dispose() }
    }
    It 'keeps the original 8 to 4 to 2 to 1 backoff and resets after progress' {
        $sizes = @()
        for ($i=0; $i -lt 4; $i++) {
            $assignment = Get-ContinuationAssignment $script:state $script:nonce
            $sizes += $assignment.ids.Count
            $response = if ($i -lt 3) { Element @{results=@();reason='too large'} } else { Completion $assignment.ids }
            $null = Complete-ContinuationAssignment $script:state (Element $assignment.attempt_id) $script:nonce (Element $true) $response
        }
        $assignment = Get-ContinuationAssignment $script:state $script:nonce
        $sizes += $assignment.ids.Count
        ($sizes -join ',') | Should -BeExactly '8,4,2,1,8'
        $script:state.Results.Count | Should -Be 1
    }
    It 'does not commit earlier valid entries when a later result is invalid' {
        $assignment = Get-ContinuationAssignment $script:state $script:nonce
        $response = Completion @($assignment.ids[0], 'foreign')
        { Complete-ContinuationAssignment $script:state (Element $assignment.attempt_id) $script:nonce (Element $true) $response } | Should -Throw '*Unassigned*'
        $script:state.Pending.Count | Should -Be 9
        $script:state.Results.Count | Should -Be 0
        $script:state.Attempts.Count | Should -Be 0
        $script:state.Active.Id | Should -Be $assignment.attempt_id
        { Get-ContinuationAssignment $script:state $script:nonce } | Should -Throw '*already active*'
    }
    It 'requires verified delivery and the exact active attempt before acceptance' {
        $assignment = Get-ContinuationAssignment $script:state $script:nonce
        $response = Completion $assignment.ids
        { Complete-ContinuationAssignment $script:state (Element $assignment.attempt_id) $script:nonce (Element $false) $response } | Should -Throw '*verified delivery*'
        { Complete-ContinuationAssignment $script:state (Element ([string]$assignment.attempt_id)) $script:nonce (Element $true) $response } | Should -Throw '*active assignment*'
        { Complete-ContinuationAssignment $script:state (Element ($assignment.attempt_id+1)) $script:nonce (Element $true) $response } | Should -Throw '*active assignment*'
        { Complete-ContinuationAssignment $script:state (Element $assignment.attempt_id) ('2'*32) (Element $true) $response } | Should -Throw '*nonce*'
        $script:state.Results.Count | Should -Be 0
        $script:state.Attempts.Count | Should -Be 0
        $null = Complete-ContinuationAssignment $script:state (Element $assignment.attempt_id) $script:nonce (Element $true) $response
        $script:state.Results.Count | Should -Be 8
    }
    It 'preserves response order and never assigns completed items again' {
        $assignment = Get-ContinuationAssignment $script:state $script:nonce
        $delta = Complete-ContinuationAssignment $script:state (Element $assignment.attempt_id) $script:nonce (Element $true) (Completion @('file:1','file:0'))
        ($delta.accepted.id -join ',') | Should -BeExactly 'file:1,file:0'
        $delta.Contains('results') | Should -BeFalse
        $checkpoint = Get-ContinuationCheckpoint $script:state
        ($checkpoint.results.id -join ',') | Should -BeExactly 'file:1,file:0'
        $next = Get-ContinuationAssignment $script:state $script:nonce
        ($next.ids -join ',') | Should -BeExactly 'file:2,file:3,file:4,file:5,file:6,file:7,file:8'
        { Complete-ContinuationAssignment $script:state (Element $assignment.attempt_id) $script:nonce (Element $true) (Completion $assignment.ids) } | Should -Throw '*active assignment*'
    }
    It 'keeps blocked work pending and records only diagnostic result text' {
        $assignment = Get-ContinuationAssignment $script:state $script:nonce
        $response = Element @{results=@(@{id=$assignment.ids[0];status='blocked';reasoning='source unavailable';reply=@{ignored=$true}});reason='continue'}
        $delta = Complete-ContinuationAssignment $script:state (Element $assignment.attempt_id) $script:nonce (Element $true) $response
        $script:state.Pending.Count | Should -Be 9
        $script:state.Results.Count | Should -Be 0
        $delta.attempt.pending[0].reasoning | Should -BeExactly 'source unavailable'
        $next = Get-ContinuationAssignment $script:state $script:nonce
        $next.ids[0] | Should -BeExactly 'file:0'
        $next.ids.Count | Should -Be 4
    }
    It 'finishes only from its private complete ledger, never a diagnostic copy' {
        { Complete-ContinuationReview $script:state } | Should -Throw '*Incomplete*'
        $single = Test-State 1
        $assignment = Get-ContinuationAssignment $single $script:nonce
        { Complete-ContinuationReview $single } | Should -Throw '*Incomplete*'
        $null = Complete-ContinuationAssignment $single (Element $assignment.attempt_id) $script:nonce (Element $true) (Completion $assignment.ids)
        $diagnostic = Get-ContinuationCheckpoint $single
        # A serialized diagnostic copy can be changed without changing authority.
        $copy = ConvertFrom-Json -InputObject (ConvertTo-Json -InputObject $diagnostic -Depth 30) -AsHashtable
        $copy.results[0].reasoning='invented diagnostic'
        $outputs = Complete-ContinuationReview $single
        $outputs.Count | Should -Be 1
        $outputs[0].type | Should -BeExactly 'submit_pull_request_review'
        $single.Results[0].reasoning | Should -BeExactly 'reviewed'
    }
    It 'retains a single oversized item and keeps empty snapshots complete' {
        $empty = Test-State 0
        (Get-ContinuationAssignment $empty $script:nonce).complete | Should -BeTrue
        $snapshot = Element @{head_sha=('a'*40);base_sha=('b'*40);pull_number=1;changed_files=2;files=@(@{filename='big';status='modified';patch=('x'*50000)},@{filename='small';status='modified';patch='x'});threads=@()}
        $large = New-ContinuationState $snapshot (Get-JsDigest ($snapshot.GetRawText()))
        $assignment = Get-ContinuationAssignment $large $script:nonce
        $assignment.ids.Count | Should -Be 1
        $assignment.ids[0] | Should -BeExactly 'file:0'
    }
}
