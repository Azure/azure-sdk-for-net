#Requires -Version 7.5
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot '../pr-re-review/PrReReviewInput.psm1') -Force
    . (Join-Path $PSScriptRoot '../pr-re-review/ReviewBaselines.ps1')
    $script:path = 'eng/apicompatbaselines/Azure.ResourceManager.Compute.Recommender.xml'
    $script:head = 'a' * 40; $script:base = 'b' * 40; $script:diff = 'c' * 40
    $script:repo = @{ owner = 'Azure'; repo = 'azure-sdk-for-net' }
    function Entry([string] $Id, [string] $Target) { return "<Suppression><DiagnosticId>$Id</DiagnosticId><Target>$Target</Target></Suppression>" }
    function Xml([string] $Body) { return "<?xml version=`"1.0`"?><Suppressions>$Body</Suppressions>" }
    function New-Metadata([byte[]] $Bytes) {
        $prefix = [Text.Encoding]::UTF8.GetBytes("blob $($Bytes.Length)`0")
        $combined = [byte[]]::new($prefix.Length + $Bytes.Length)
        [Buffer]::BlockCopy($prefix, 0, $combined, 0, $prefix.Length)
        [Buffer]::BlockCopy($Bytes, 0, $combined, $prefix.Length, $Bytes.Length)
        return @{ type = 'file'; encoding = 'base64'; content = [Convert]::ToBase64String($Bytes); size = $Bytes.Length; sha = [Convert]::ToHexString([Security.Cryptography.SHA1]::HashData($combined)).ToLowerInvariant() }
    }
    function Set-ContentResponse([string] $Owner, [string] $Ref, [string] $Content) {
        $route = "repos/$Owner/azure-sdk-for-net/contents/$($script:path)?ref=$Ref"
        $metadata = New-Metadata ([Text.Encoding]::UTF8.GetBytes($Content))
        $script:responses[$route] = @{ Status = 200; ExitCode = 0; Body = ($metadata | ConvertTo-Json -Compress) }
    }
    function New-Snapshot([object[]] $Files, [string] $HeadRepo = 'Azure/azure-sdk-for-net') {
        return @{ files = $Files; head_sha = $script:head; base_sha = $script:base; diff_base_sha = $script:diff; head_repo = $HeadRepo }
    }
    function Get-Inventory($Snapshot) {
        return ,(Compare-BaselineFiles -Files (Get-CapturedBaselineFiles -Snapshot $Snapshot -Repository $script:repo))
    }
}

Describe 'Captured central ApiCompat baselines' {
    BeforeEach {
        $script:calls = [Collections.Generic.List[string]]::new()
        $script:responses = @{}
        Mock Invoke-PrReReviewGhApi {
            param($Arguments, $IncludeStatus)
            $route = $Arguments[0]; $script:calls.Add($route)
            if (!$script:responses.ContainsKey($route)) { throw "Missing $route" }
            return $script:responses[$route]
        }
    }

    It 'captures all new suppressions in a #64595-style added baseline' {
        $added = Xml ('<!-- Intentional preview rename. -->' + (Entry CP0001 'T:DiagnosticData') + (Entry CP0002 'M:Factory'))
        Set-ContentResponse Azure $script:head $added
        $result = Get-Inventory (New-Snapshot @(@{ filename = $script:path; status = 'added' }))
        $result.Count | Should -Be 2
        $result[0].fields['Target'] | Should -BeExactly 'T:DiagnosticData'
        $result[1].fields['Target'] | Should -BeExactly 'M:Factory'
        $result[0].nearby_comment | Should -BeExactly 'Intentional preview rename.'
    }
    It 'compares complete entries, preserving distinct targets and duplicate additions' {
        $one = Entry CP0001 'T:One'; $two = Entry CP0001 'T:Two'
        Set-ContentResponse Azure $script:diff (Xml $one)
        Set-ContentResponse Azure $script:head (Xml ($two + $one + $two))
        $result = Get-Inventory (New-Snapshot @(@{ filename = $script:path; status = 'modified' }))
        $result.Count | Should -Be 2
        $result[0].fields['Target'] | Should -BeExactly 'T:Two'
        $result[1].fields['Target'] | Should -BeExactly 'T:Two'
    }
    It 'uses the diff base for modified baselines when the base tip diverged' {
        $suppression = Entry CP1 'T:Model'
        foreach ($example in @(@{old='';tip=$suppression;head=$suppression;expected=1}, @{old=$suppression;tip='';head=$suppression;expected=0})) {
            $script:calls.Clear()
            Set-ContentResponse Azure $script:diff (Xml $example.old)
            Set-ContentResponse Azure $script:base (Xml $example.tip)
            Set-ContentResponse Azure $script:head (Xml $example.head)
            $result = Get-Inventory (New-Snapshot @(@{filename=$script:path;status='modified'}))
            $result.Count | Should -Be $example.expected
            $script:calls.Count | Should -Be 2
            $script:calls[0] | Should -Match $script:diff
        }
        $snapshot=New-Snapshot @(@{filename=$script:path;status='modified'});$snapshot.diff_base_sha=$null
        { Get-CapturedBaselineFiles -Snapshot $snapshot -Repository $script:repo } | Should -Throw '*diff base*'
    }
    It 'does not attribute an old comment to an unrelated appended entry' {
        $one = Entry CP0001 'T:One'; $two = Entry CP0002 'T:Two'
        Set-ContentResponse Azure $script:diff (Xml ('<!-- Old rationale -->' + $one))
        Set-ContentResponse Azure $script:head (Xml ('<!-- Old rationale -->' + $one + $two))
        $result = Get-Inventory (New-Snapshot @(@{ filename = $script:path; status = 'modified' }))
        $result[0].nearby_comment | Should -Be $null
    }
    It 'loads large Contents API objects via the verified Git blob' {
        $content = Xml ((' ' * (1024*1024)) + (Entry CP0001 'T:One'))
        $blob = New-Metadata ([Text.Encoding]::UTF8.GetBytes($content))
        $metadata = @{} + $blob; $metadata.encoding = 'none'; $metadata.content = ''
        $script:responses["repos/Azure/azure-sdk-for-net/contents/$($script:path)?ref=$($script:head)"] = @{ Status=200; ExitCode=0; Body=($metadata|ConvertTo-Json -Compress) }
        $script:responses["repos/Azure/azure-sdk-for-net/git/blobs/$($blob.sha)"] = @{ Status=200; ExitCode=0; Body=($blob|ConvertTo-Json -Compress) }
        $result = Get-Inventory (New-Snapshot @(@{ filename = $script:path; status = 'added' }))
        $result[0].fields['Target'] | Should -BeExactly 'T:One'
    }
    It 'surfaces renamed baseline entries and ignores removed baselines' {
        $old = 'eng/apicompatbaselines/Azure.Old.xml'
        Set-ContentResponse Azure $script:head (Xml (Entry CP0001 'T:One'))
        $result = Get-Inventory (New-Snapshot @(@{ filename=$script:path;previous_filename=$old;status='renamed' }))
        $result.Count | Should -Be 1
        $result[0].path | Should -BeExactly $script:path
        (Get-Inventory (New-Snapshot @(@{filename=$script:path;status='removed'}))).Count | Should -Be 0
    }
    It 'preserves empty results, Unicode values and case-sensitive fields' {
        Set-ContentResponse Azure $script:head (Xml '')
        (Get-Inventory (New-Snapshot @(@{filename=$script:path;status='added'}))).Count | Should -Be 0
        $content = Xml ((Entry CP0001 'T:𝄞界') + '<Suppression><DiagnosticId>CP0002</DiagnosticId><Target>T:Two</Target><target>different</target></Suppression>')
        Set-ContentResponse Azure $script:head $content
        $result = Get-Inventory (New-Snapshot @(@{filename=$script:path;status='added'}))
        $result[0].fields['Target'] | Should -BeExactly 'T:𝄞界'
        $result[1].fields['DiagnosticId'] | Should -BeExactly 'CP0002'
        $result[1].fields['Target'] | Should -BeExactly 'T:Two'
        $result[1].fields['target'] | Should -BeExactly 'different'
        $result[1].fields.Count | Should -Be 3
    }
    It 'preserves XML namespaces, comments and processing instructions' {
        $content = Xml '<!-- note --><?ignored x?><Suppression xmlns:ext="urn:test"><DiagnosticId>CP0001</DiagnosticId><Target>T:One</Target><ext:Extra>value</ext:Extra></Suppression>'
        Set-ContentResponse Azure $script:head $content
        $result = Get-Inventory (New-Snapshot @(@{filename=$script:path;status='added'}))
        $result[0].nearby_comment | Should -BeExactly 'note'
        $result[0].fields['{urn:test}Extra'] | Should -BeExactly 'value'
        Set-ContentResponse Azure $script:head (Xml '<!-- <!DOCTYPE ignored> -->')
        { Get-Inventory (New-Snapshot @(@{filename=$script:path;status='added'})) } | Should -Throw '*DTD*'
    }
    It 'rejects a near-declaration namespace on <Location>' -ForEach @(
        @{ Location='suppression'; AttributeOnSuppression=$true; ExpectedError='*Unexpected baseline element*' },
        @{ Location='field'; AttributeOnSuppression=$false; ExpectedError='*Unsupported suppression field*' }
    ) {
        $namespace = 'http://www.w3.org/2000/xmlns/' + [char]0x00ad
        $attribute = ' ext:unexpected="value"'
        $suppressionAttribute = if ($AttributeOnSuppression) { $attribute } else { '' }
        $fieldAttribute = if ($AttributeOnSuppression) { '' } else { $attribute }
        $content = "<Suppressions xmlns:ext=`"$namespace`"><Suppression$suppressionAttribute><DiagnosticId>CP0001</DiagnosticId><Target$fieldAttribute>T:One</Target></Suppression></Suppressions>"
        { Get-BaselineEntries $content } | Should -Throw $ExpectedError
    }
    It 'accepts actual namespace declarations on suppressions and fields' {
        $content = Xml '<Suppression xmlns:ext="urn:test"><DiagnosticId>CP0001</DiagnosticId><Target xmlns:other="urn:other">T:One</Target></Suppression>'
        $entries = Get-BaselineEntries $content
        $entries.Count | Should -Be 1
        $entries[0].Fields['Target'] | Should -BeExactly 'T:One'
    }
    It 'does not confuse XML fields with PowerShell DOM properties' {
        $content = Xml '<Suppression><NodeType>Comment</NodeType><Value>ignored</Value><Name>x</Name><Attributes>y</Attributes><ChildNodes>z</ChildNodes><DiagnosticId>CP0001</DiagnosticId><Target>T:One</Target></Suppression>'
        Set-ContentResponse Azure $script:head $content
        $result = Get-Inventory (New-Snapshot @(@{filename=$script:path;status='added'}))
        $result.Count | Should -Be 1
        $result[0].fields['NodeType'] | Should -BeExactly 'Comment'
        $result[0].fields['Target'] | Should -BeExactly 'T:One'
    }
    It 'rejects invalid suppression structure and external XML entities' {
        foreach ($case in @(
            @{ content=(Xml '<Suppression><DiagnosticId>CP0001</DiagnosticId><Target>T:One</Target><Target>T:Two</Target></Suppression>'); error='*Duplicate suppression field*' },
            @{ content=(Xml '<Suppression><DiagnosticId>CP0001</DiagnosticId><Target><Nested /></Target></Suppression>'); error='*Unsupported suppression field*' },
            @{ content=(Xml '<Suppression><DiagnosticId>CP0001</DiagnosticId><!-- unexpected --><Target>T:One</Target></Suppression>'); error='*Unsupported suppression field*' },
            @{ content='<Suppressions xmlns="urn:test" />'; error='*Unexpected baseline root*' },
            @{ content='<!DOCTYPE Suppressions [<!ENTITY x SYSTEM "file:///etc/passwd">]><Suppressions>&x;</Suppressions>'; error='*DTD*' }
        )) {
            Set-ContentResponse Azure $script:head $case.content
            { Get-Inventory (New-Snapshot @(@{filename=$script:path;status='added'})) } | Should -Throw $case.error
        }
    }
    It 'fails closed for missing or malformed baseline content' {
        Set-ContentResponse Azure $script:head (Xml '')
        { Get-Inventory (New-Snapshot @(@{filename=$script:path;status='modified'})) } | Should -Throw '*Missing*'
        Set-ContentResponse Azure $script:head '<Suppressions>'
        { Get-Inventory (New-Snapshot @(@{filename=$script:path;status='added'})) } | Should -Throw '*Load*'
        Set-ContentResponse Azure $script:head '<!DOCTYPE x><Suppressions />'
        { Get-Inventory (New-Snapshot @(@{filename=$script:path;status='added'})) } | Should -Throw '*DTD*'
    }
}
