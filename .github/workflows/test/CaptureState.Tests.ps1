BeforeAll {
    Import-Module (Join-Path $PSScriptRoot '../pr-re-review/ReviewCapture.psm1') -Force
    function Element([string]$Json) { $doc=[Text.Json.JsonDocument]::Parse($Json);try{return $doc.RootElement.Clone()}finally{$doc.Dispose()} }
    function Identity { Element ('{"owner":"Azure","repo":"repo","pullNumber":1,"headSha":"'+('a'*40)+'"}') }
    function Pull([long]$Count=1) { Element ('{"state":"open","draft":false,"head":{"sha":"'+('a'*40)+'"},"base":{"sha":"'+('b'*40)+'"},"changed_files":'+$Count+'}') }
    function EffectId($Effect) { Element ([string]$Effect.Id) }
}
Describe 'Private changed-file capture state' {
    It 'cannot finalize before the complete listing and post-capture read' {
        $state=New-ChangedFileCapture (Identity)
        {Get-ChangedFileManifest $state}|Should -Throw '*incomplete*'
        $e=Get-ChangedFileEffect $state;Complete-ChangedFileEffect $state (EffectId $e) (Pull)
        $e=Get-ChangedFileEffect $state;Complete-ChangedFileEffect $state (EffectId $e) (Element '[{"filename":"f","status":"modified"}]')
        {Get-ChangedFileManifest $state}|Should -Throw '*incomplete*'
        $e=Get-ChangedFileEffect $state;Complete-ChangedFileEffect $state (EffectId $e) (Pull)
        (Get-ChangedFileManifest $state)|Should -Match '"changed_files":1'
        Get-ChangedFileEffect $state|Should -BeNullOrEmpty
    }
    It 'binds each response to the active effect and rejects replay' {
        $state=New-ChangedFileCapture (Identity);$e=Get-ChangedFileEffect $state
        {Complete-ChangedFileEffect $state (Element '999') (Pull)}|Should -Throw '*Unexpected*'
        $state.Stage|Should -Be 'before'
        Complete-ChangedFileEffect $state (EffectId $e) (Pull)
        {Complete-ChangedFileEffect $state (EffectId $e) (Pull)}|Should -Throw '*Unexpected*'
        $state.Stage|Should -Be 'files'
    }
    It 'does not partially commit an invalid later file or failed metadata read' {
        $state=New-ChangedFileCapture (Identity);$e=Get-ChangedFileEffect $state
        {Complete-ChangedFileEffect $state (EffectId $e) (Pull 3001)}|Should -Throw '*limit*'
        $state.Base|Should -BeNullOrEmpty
        Complete-ChangedFileEffect $state (EffectId $e) (Pull 2)
        $e=Get-ChangedFileEffect $state
        {Complete-ChangedFileEffect $state (EffectId $e) (Element '[{"filename":"f"},{"filename":"f"}]')}|Should -Throw '*duplicate*'
        $state.Files.Count|Should -Be 0
        $state.Names.Count|Should -Be 0
        Complete-ChangedFileEffect $state (EffectId $e) (Element '[{"filename":"f"},{"filename":"g"}]')
        $state.Files.Count|Should -Be 2
    }
}

Describe 'Capture response document lifetimes' {
    It 'retains only owned data after every API response document is disposed' {
        $inputs=[Text.Json.JsonDocument]::Parse(('{"repo":{"owner":"Azure","repo":"repo"},"files":{"pull_number":1,"head_sha":"'+('a'*40)+'","base_sha":"'+('b'*40)+'","changed_files":1,"files":[]}}'))
        try{$state=New-ReviewStateCapture $inputs.RootElement.GetProperty('repo') $inputs.RootElement.GetProperty('files')}finally{$inputs.Dispose()}
        $pullText='{"state":"open","draft":false,"head":{"sha":"'+('a'*40)+'","repo":{"full_name":"Before/repo"}},"base":{"sha":"'+('b'*40)+'"},"changed_files":1}'
        $threadText='{"repository":{"pullRequest":{"reviewThreads":{"totalCount":1,"nodes":[{"id":"thread","isResolved":false,"isOutdated":null,"comments":{"nodes":[{"databaseId":1,"body":"history","publishedAt":"2026-01-02T03:04:05.000Z"}],"pageInfo":{"hasNextPage":false}}}],"pageInfo":{"hasNextPage":false}}}}}'
        foreach($text in @($pullText,$threadText,'[{"id":11,"body":"prior","submitted_at":"2026-01-02T03:04:05.000Z"}]',$pullText)){
            $effect=Get-ReviewCaptureEffect $state
            $response=[Text.Json.JsonDocument]::Parse($text)
            try{Complete-ReviewCaptureEffect $state (EffectId $effect) $response.RootElement}finally{$response.Dispose()}
        }
        Get-ReviewCaptureEffect $state|Should -BeNullOrEmpty
        $result=[Text.Json.JsonDocument]::Parse((Get-ReviewCaptureSnapshot $state))
        try{
            $result.RootElement.GetProperty('head_repo').GetString()|Should -Be 'Before/repo'
            $result.RootElement.GetProperty('threads')[0].GetProperty('comments')[0].GetProperty('publishedAt').GetString()|Should -Be '2026-01-02T03:04:05.000Z'
            $result.RootElement.GetProperty('reviews')[0].GetProperty('submittedAt').GetString()|Should -Be '2026-01-02T03:04:05.000Z'
        }finally{$result.Dispose()}
    }
}
