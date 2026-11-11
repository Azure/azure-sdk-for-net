#Requires -Version 7.5
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot '../pr-re-review/PrReReviewInput.psm1') -Force
    . (Join-Path $PSScriptRoot '../pr-re-review/ReviewBaselines.ps1')
    $script:path = 'eng/apicompatbaselines/Azure.Example.xml'
    $script:head = 'a' * 40; $script:base = 'b' * 40; $script:diff = 'c' * 40
    $script:repo = @{ owner = 'Azure'; repo = 'azure-sdk-for-net' }
    function New-Metadata([string] $Body) {
        $bytes = [Text.Encoding]::UTF8.GetBytes($Body)
        $prefix = [Text.Encoding]::UTF8.GetBytes("blob $($bytes.Length)`0")
        $combined = [byte[]]::new($prefix.Length + $bytes.Length)
        [Buffer]::BlockCopy($prefix,0,$combined,0,$prefix.Length)
        [Buffer]::BlockCopy($bytes,0,$combined,$prefix.Length,$bytes.Length)
        return @{ type='file'; encoding='base64'; content=[Convert]::ToBase64String($bytes); size=$bytes.Length; sha=[Convert]::ToHexString([Security.Cryptography.SHA1]::HashData($combined)).ToLowerInvariant() }
    }
}
Describe 'PowerShell captured baseline parity' {
    BeforeEach {
        $script:calls = [Collections.Generic.List[string]]::new()
        $script:responses = @{}
        Mock Invoke-PrReReviewGhApi {
            param($Arguments, $IncludeStatus)
            $route = $Arguments[0]; $script:calls.Add($route)
            if (!$script:responses.ContainsKey($route)) { throw "Unexpected API request $route" }
            return $script:responses[$route]
        }
    }
    It 'fails closed when the captured file list or head identity is missing' {
        { Get-CapturedBaselineFiles -Snapshot @{head_sha=$script:head} -Repository $script:repo } | Should -Throw '*file list*'
        { Get-CapturedBaselineFiles -Snapshot @{files=@()} -Repository $script:repo } | Should -Throw '*head*'
        { Get-CapturedBaselineFiles -Snapshot @{files=@();head_sha=$script:head} -Repository @{} } | Should -Throw '*repository*'
    }
    It 'reads modified baseline at the diff base, not the current base tip' {
        $entry='<Suppression><DiagnosticId>CP1</DiagnosticId><Target>T:M</Target></Suppression>'
        $snapshot=@{ files=@(@{filename=$script:path;status='modified'});head_sha=$script:head;base_sha=$script:base;diff_base_sha=$script:diff;head_repo='Azure/azure-sdk-for-net' }
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:diff)"]=@{Status=200;ExitCode=0;Body=(New-Metadata '<Suppressions/>' | ConvertTo-Json -Compress)}
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"]=@{Status=200;ExitCode=0;Body=(New-Metadata "<Suppressions>$entry</Suppressions>" | ConvertTo-Json -Compress)}
        $pairs=Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo
        $result=Compare-BaselineFiles -Files $pairs
        $result.Count | Should -Be 1
        $result[0].fields.Target | Should -Be 'T:M'
        $script:calls.Count | Should -Be 2
        $script:calls[0] | Should -Match $script:diff
    }
    It 'falls back for a fork-head <Status> at the exact same SHA' -ForEach @{Status=403}, @{Status=404} {
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;base_sha=$script:base;diff_base_sha=$script:diff;head_repo='fork/azure-sdk-for-net' }
        $script:responses["repos/fork/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"]=@{Status=$Status;ExitCode=1;Body='{}'}
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"]=@{Status=200;ExitCode=0;Body=(New-Metadata '<Suppressions/>' | ConvertTo-Json -Compress)}
        $pairs=Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo
        $pairs.Count | Should -Be 1
        $script:calls.Count | Should -Be 2
        $script:calls[1] | Should -Match $script:head
    }
    It 'percent-encodes each filename segment without changing its identity' {
        $name='eng/apicompatbaselines/Azure Test%#é.xml'
        $snapshot=@{ files=@(@{filename=$name;status='added'});head_sha=$script:head;head_repo='Azure/azure-sdk-for-net' }
        $route="repos/Azure/azure-sdk-for-net/contents/eng/apicompatbaselines/Azure%20Test%25%23%C3%A9.xml?ref=$($script:head)"
        $script:responses[$route]=@{Status=200;ExitCode=0;Body=(New-Metadata '<Suppressions/>' | ConvertTo-Json -Compress)}
        $pairs=Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo
        $pairs[0].path | Should -BeExactly $name
        $script:calls[0] | Should -BeExactly $route
    }
    It 'fetches and verifies a large Contents API object via its Git blob' {
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;head_repo='Azure/azure-sdk-for-net' }
        $body='<Suppressions>' + (' ' * (1024*1024)) + '<Suppression><DiagnosticId>CP1</DiagnosticId><Target>T:M</Target></Suppression></Suppressions>'
        $blob=New-Metadata $body; $metadata=@{} + $blob; $metadata.encoding='none'; $metadata.content=''
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"]=@{Status=200;ExitCode=0;Body=($metadata | ConvertTo-Json -Compress)}
        $script:responses["repos/Azure/azure-sdk-for-net/git/blobs/$($blob.sha)"]=@{Status=200;ExitCode=0;Body=($blob | ConvertTo-Json -Compress)}
        $pairs=Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo
        $result=Compare-BaselineFiles -Files $pairs
        $result.Count | Should -Be 1
        $result[0].fields.Target | Should -Be 'T:M'
        $script:calls.Count | Should -Be 2
    }
    It 'removes an initial UTF-8 BOM from a verified baseline' {
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;head_repo='Azure/azure-sdk-for-net' }
        $text=[string][char]0xfeff + '<Suppressions><Suppression><DiagnosticId>CP1</DiagnosticId><Target>T:M</Target></Suppression></Suppressions>'
        $metadata=New-Metadata $text
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"]=@{Status=200;ExitCode=0;Body=($metadata | ConvertTo-Json -Compress)}
        (Compare-BaselineFiles -Files (Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo)).Count | Should -Be 1
    }
    It 'does not classify a filename ending in a newline as a baseline' {
        $snapshot=@{ files=@(@{filename=$script:path+"`n";status='added'});head_sha=$script:head;head_repo='Azure/azure-sdk-for-net' }
        (Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo).Count | Should -Be 0
        $script:calls.Count | Should -Be 0
    }
    It 'removes ECMAScript base64 whitespace but rejects U+0085' {
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;head_repo='Azure/azure-sdk-for-net' }
        $metadata=New-Metadata '<Suppressions/>'; $encoded=$metadata.content; $route="repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"
        $metadata.content=$encoded.Insert(2,[string][char]0xfeff)
        $script:responses[$route]=@{Status=200;ExitCode=0;Body=($metadata|ConvertTo-Json -Compress)}
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Not -Throw
        $metadata.content=$encoded.Insert(2,[string][char]0x85)
        $script:responses[$route]=@{Status=200;ExitCode=0;Body=($metadata|ConvertTo-Json -Compress)}
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw
    }
    It 'rejects a verified Git blob containing invalid UTF-8' {
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;head_repo='Azure/azure-sdk-for-net' }
        $bytes=[byte[]](0xc3,0x28); $prefix=[Text.Encoding]::UTF8.GetBytes("blob $($bytes.Length)`0"); $blob=[byte[]]::new($prefix.Length+$bytes.Length)
        [Buffer]::BlockCopy($prefix,0,$blob,0,$prefix.Length); [Buffer]::BlockCopy($bytes,0,$blob,$prefix.Length,$bytes.Length)
        $metadata=@{type='file';encoding='base64';content=[Convert]::ToBase64String($bytes);size=$bytes.Length;sha=[Convert]::ToHexString([Security.Cryptography.SHA1]::HashData($blob)).ToLowerInvariant()}
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"]=@{Status=200;ExitCode=0;Body=($metadata | ConvertTo-Json -Compress)}
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw
    }
    It 'rejects culture-ignorable characters in a blob SHA' {
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;head_repo='Azure/azure-sdk-for-net' }
        $blob=New-Metadata '<Suppressions/>'; $metadata=@{} + $blob; $metadata.encoding='none'; $metadata.content=''; $blob.sha += [char]0
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"]=@{Status=200;ExitCode=0;Body=($metadata | ConvertTo-Json -Compress)}
        $script:responses["repos/Azure/azure-sdk-for-net/git/blobs/$($metadata.sha)"]=@{Status=200;ExitCode=0;Body=($blob | ConvertTo-Json -Compress)}
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw '*Unreadable baseline blob*'
    }
    It 'rejects a blob whose size is a string even when the digits match' {
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;head_repo='Azure/azure-sdk-for-net' }
        $blob=New-Metadata '<Suppressions/>'; $metadata=@{} + $blob; $metadata.encoding='none'; $metadata.content=''; $blob.size=[string]$blob.size
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"]=@{Status=200;ExitCode=0;Body=($metadata | ConvertTo-Json -Compress)}
        $script:responses["repos/Azure/azure-sdk-for-net/git/blobs/$($blob.sha)"]=@{Status=200;ExitCode=0;Body=($blob | ConvertTo-Json -Compress)}
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw
    }
    It 'does not fall back for an inaccessible base-side blob' {
        $snapshot=@{ files=@(@{filename=$script:path;status='modified'});head_sha=$script:head;diff_base_sha=$script:diff;head_repo='fork/azure-sdk-for-net' }
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:diff)"]=@{Status=404;ExitCode=1;Body='{}'}
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw
        $script:calls.Count | Should -Be 1
    }
    It 'fails closed on truncated JSON and a failed command with an apparent 200 status' {
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;head_repo='Azure/azure-sdk-for-net' }
        $route="repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"
        $script:responses[$route]=@{Status=200;ExitCode=0;Body='{"type":'}
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw
        $script:responses[$route]=@{Status=200;ExitCode=1;Body='{}'}
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw
    }
    It 'rejects malformed statuses and non-string head repositories before fetching' {
        foreach ($status in @(('modified' + [char]0), ('added' + [char]0x00ad))) {
            $snapshot=@{ files=@(@{filename=$script:path;status=$status});head_sha=$script:head;diff_base_sha=$script:diff;head_repo='Azure/azure-sdk-for-net' }
            { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw '*Unknown baseline file status*'
        }
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;head_repo=@() }
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw '*Invalid baseline head repository*'
        $script:calls.Count | Should -Be 0
    }
    It 'does not fall back for other errors' {
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;head_repo='fork/azure-sdk-for-net' }
        $script:responses["repos/fork/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"]=@{Status=429;ExitCode=1;Body='{}'}
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw
        $script:calls.Count | Should -Be 1
    }
    It 'rejects malformed or corrupt metadata <Case>' -ForEach @(
      @{Case='type Boolean';Key='type';Value=$true},@{Case='type NUL';Key='type';Value=('file'+[char]0)},@{Case='size string';Key='size';Value='15'},@{Case='size fraction';Key='size';Value=3.5},@{Case='encoding Boolean';Key='encoding';Value=$true},@{Case='encoding NUL';Key='encoding';Value=('base64'+[char]0)},@{Case='content array';Key='content';Value=@('x')},@{Case='sha Boolean';Key='sha';Value=$true},@{Case='corrupt hash';Key='sha';Value=('0'*40)},@{Case='bad base64';Key='content';Value='####'}
    ) {
        $snapshot=@{ files=@(@{filename=$script:path;status='added'});head_sha=$script:head;head_repo='Azure/azure-sdk-for-net' }
        $metadata=New-Metadata '<Suppressions/>'; $metadata[$Key]=$Value
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"]=@{Status=200;ExitCode=0;Body=($metadata | ConvertTo-Json -Compress)}
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw
    }
}
