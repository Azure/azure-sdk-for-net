# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Compare captured central ApiCompat XML as a multiset and report each added
# suppression with nearby comment context. JSON travels over standard streams;
# never execute PR content or resolve XML entities. Capture mode also fetches
# exact GitHub blobs through the shared gh helper and verifies their Git hashes.
param([switch] $Capture)
$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [System.Text.UTF8Encoding]::new($false)
[Console]::OutputEncoding = [System.Text.UTF8Encoding]::new($false)

function Get-BaselineEntries {
    param([AllowNull()][object] $Content)

    if ($null -eq $Content) { return ,@() }
    if ($Content -isnot [string] -or [Text.Encoding]::UTF8.GetByteCount($Content) -gt 4MB) {
        throw 'Invalid or oversized baseline'
    }
    if ($Content -match '<!\s*(?:DOCTYPE|ENTITY)\b') { throw 'DTD and entity declarations are not allowed' }

    $settings = [System.Xml.XmlReaderSettings]::new()
    $settings.DtdProcessing = [System.Xml.DtdProcessing]::Prohibit
    $settings.XmlResolver = $null
    $settings.IgnoreProcessingInstructions = $true
    $reader = [System.Xml.XmlReader]::Create([System.IO.StringReader]::new($Content), $settings)
    try {
        $document = [System.Xml.XmlDocument]::new()
        $document.XmlResolver = $null
        $document.PreserveWhitespace = $true
        $document.Load($reader)
    } finally {
        $reader.Dispose()
    }
    $root = $document.psbase.DocumentElement
    if ($null -eq $root -or $root.psbase.Name -cne 'Suppressions' -or $root.psbase.NamespaceURI) {
        throw 'Unexpected baseline root'
    }

    $entries = [System.Collections.Generic.List[object]]::new()
    $comment = $null
    foreach ($node in $root.psbase.ChildNodes) {
        if ($node.psbase.NodeType -eq [System.Xml.XmlNodeType]::Comment) {
            $comment = $node.psbase.Value.Trim()
            if (-not $comment) { $comment = $null }
            continue
        }
        if ($node.psbase.NodeType -ne [System.Xml.XmlNodeType]::Element) { continue }
        if ($node.psbase.Name -cne 'Suppression' -or $node.psbase.NamespaceURI) { throw 'Unexpected baseline element' }
        foreach ($attribute in $node.psbase.Attributes) {
            if ($attribute.psbase.NamespaceURI -cne 'http://www.w3.org/2000/xmlns/') { throw 'Unexpected baseline element' }
        }
        $fields = [System.Collections.Generic.SortedDictionary[string, string]]::new([StringComparer]::Ordinal)
        foreach ($field in $node.psbase.ChildNodes) {
            if ($field.psbase.NodeType -eq [System.Xml.XmlNodeType]::Comment) { throw 'Unsupported suppression field' }
            if ($field.psbase.NodeType -ne [System.Xml.XmlNodeType]::Element) { continue }
            foreach ($attribute in $field.psbase.Attributes) {
                if ($attribute.psbase.NamespaceURI -cne 'http://www.w3.org/2000/xmlns/') { throw 'Unsupported suppression field' }
            }
            foreach ($child in $field.psbase.ChildNodes) {
                if ($child.psbase.NodeType -eq [System.Xml.XmlNodeType]::Element -or $child.psbase.NodeType -eq [System.Xml.XmlNodeType]::Comment) { throw 'Unsupported suppression field' }
            }
            $name = if ($field.psbase.NamespaceURI) { "{$($field.psbase.NamespaceURI)}$($field.psbase.LocalName)" } else { $field.psbase.LocalName }
            if ($fields.ContainsKey($name)) { throw 'Duplicate suppression field' }
            $fields.Add($name, $field.psbase.InnerText.Trim())
        }
        if (-not $fields.ContainsKey('DiagnosticId') -or -not $fields['DiagnosticId'] -or
            -not $fields.ContainsKey('Target') -or -not $fields['Target']) {
            throw 'Incomplete suppression entry'
        }
        # Length-prefixed sorted pairs provide an unambiguous, case-sensitive multiset key.
        $builder = [System.Text.StringBuilder]::new()
        foreach ($name in $fields.Keys) {
            $value = $fields[$name]
            [void]$builder.Append($name.Length).Append(':').Append($name).Append($value.Length).Append(':').Append($value)
        }
        $key = $builder.ToString()
        $entries.Add(@{ Key = $key; Fields = $fields; Comment = $comment })
        $comment = $null
    }
    return ,$entries.ToArray()
}

function Compare-BaselineFiles {
    param([Parameter(Mandatory)][AllowEmptyCollection()][object[]] $Files)
    if ($Files -isnot [array]) { throw 'Invalid baseline input' }
    $result = [System.Collections.Generic.List[object]]::new()
    foreach ($file in $files) {
        if ($file -isnot [System.Collections.IDictionary] -or -not $file.Contains('base') -or -not $file.Contains('head') -or -not $file.Contains('path')) {
            throw 'Invalid baseline file'
        }
        $counts = [System.Collections.Generic.Dictionary[string, int]]::new([StringComparer]::Ordinal)
        foreach ($entry in (Get-BaselineEntries $file['base'])) {
            if (-not $counts.ContainsKey($entry.Key)) { $counts[$entry.Key] = 0 }
            $counts[$entry.Key]++
        }
        foreach ($entry in (Get-BaselineEntries $file['head'])) {
            if ($counts.ContainsKey($entry.Key) -and $counts[$entry.Key] -gt 0) {
                $counts[$entry.Key]--
            } else {
                $result.Add(@{ path = $file['path']; fields = $entry.Fields; nearby_comment = $entry.Comment })
            }
        }
    }
    return ,$result.ToArray()
}

function Get-CapturedBaselineFiles {
    param([Parameter(Mandatory)][System.Collections.IDictionary] $Snapshot,
          [Parameter(Mandatory)][System.Collections.IDictionary] $Repository)

    if ($Snapshot['files'] -isnot [array]) { throw 'Invalid captured baseline file list.' }
    if ($Snapshot['head_sha'] -isnot [string] -or $Snapshot['head_sha'] -cnotmatch '\A[a-fA-F0-9]{40}\z') { throw 'Invalid captured baseline head.' }
    if ($Repository['owner'] -isnot [string] -or $Repository['repo'] -isnot [string] -or
        $Repository['owner'] -cnotmatch '\A[a-zA-Z0-9_.-]+\z' -or $Repository['repo'] -cnotmatch '\A[a-zA-Z0-9_.-]+\z') { throw 'Invalid captured baseline repository.' }
    $repo = "$($Repository['owner'])/$($Repository['repo'])"
    $isBaseline = { param($name) $name -is [string] -and $name -cmatch '\Aeng/apicompatbaselines/[^/]+\.xml\z' }
    function Read-CapturedBaseline([string] $Name, [string] $Ref, [string] $OwnerRepo) {
        $source = $OwnerRepo
        $encoded = ($Name -split '/' | ForEach-Object { [uri]::EscapeDataString($_) }) -join '/'
        $response = Invoke-PrReReviewGhApi -Arguments @("repos/$source/contents/${encoded}?ref=$Ref") -IncludeStatus
        if ($response.ExitCode -ne 0 -or $response.Status -ne 200) {
            if ($Ref -cne $Snapshot['head_sha'] -or $response.Status -notin @(403,404) -or $source -ceq $repo) { throw 'Unable to fetch captured baseline content.' }
            $source = $repo
            $response = Invoke-PrReReviewGhApi -Arguments @("repos/$source/contents/${encoded}?ref=$Ref") -IncludeStatus
            if ($response.ExitCode -ne 0 -or $response.Status -ne 200) { throw 'Unable to fetch captured baseline content.' }
        }
        $metadata = ConvertFrom-Json -InputObject $response.Body -AsHashtable -NoEnumerate
        if ($metadata -isnot [System.Collections.IDictionary] -or $metadata['type'] -isnot [string] -or $metadata['type'] -cne 'file' -or
            ($metadata['size'] -isnot [long] -and $metadata['size'] -isnot [int] -and $metadata['size'] -isnot [double]) -or
            -not ($metadata['size'] -ge 0 -and $metadata['size'] -le 4MB -and [Math]::Floor([double]$metadata['size']) -eq $metadata['size']) -or
            $metadata['sha'] -isnot [string] -or $metadata['sha'] -cnotmatch '\A[a-fA-F0-9]{40}\z') { throw 'Unreadable baseline content.' }
        $data = $metadata
        if ($metadata['encoding'] -is [string] -and $metadata['encoding'] -ceq 'none') {
            $blob = Invoke-PrReReviewGhApi -Arguments @("repos/$source/git/blobs/$($metadata['sha'])") -IncludeStatus
            if ($blob.ExitCode -ne 0 -or $blob.Status -ne 200) { throw 'Unreadable baseline blob.' }
            $data = ConvertFrom-Json -InputObject $blob.Body -AsHashtable -NoEnumerate
        }
        if ($data -isnot [System.Collections.IDictionary] -or $data['encoding'] -isnot [string] -or $data['encoding'] -cne 'base64' -or
            $data['content'] -isnot [string] -or ($data['size'] -isnot [long] -and $data['size'] -isnot [int] -and $data['size'] -isnot [double]) -or
            $data['size'] -ne $metadata['size'] -or $data['sha'] -isnot [string] -or $data['sha'] -cne $metadata['sha']) { throw 'Unreadable baseline blob.' }
        # ECMAScript's \s differs from .NET's (notably U+FEFF and U+0085).
        $encodedContent = [regex]::Replace($data['content'], '[\u0009-\u000D\u0020\u00A0\u1680\u2000-\u200A\u2028\u2029\u202F\u205F\u3000\uFEFF]', '')
        if ($encodedContent -cnotmatch '\A(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?\z') { throw 'Invalid baseline encoding.' }
        $bytes = [Convert]::FromBase64String($encodedContent)
        $prefix = [Text.Encoding]::UTF8.GetBytes("blob $($bytes.Length)`0")
        $combined = [byte[]]::new($prefix.Length + $bytes.Length)
        [Buffer]::BlockCopy($prefix, 0, $combined, 0, $prefix.Length)
        [Buffer]::BlockCopy($bytes, 0, $combined, $prefix.Length, $bytes.Length)
        $actual = [Convert]::ToHexString([Security.Cryptography.SHA1]::HashData($combined)).ToLowerInvariant()
        if ($bytes.Length -ne $data['size'] -or $actual -cne $data['sha'].ToLowerInvariant()) { throw 'Incomplete or corrupt baseline content.' }
        $text = [Text.UTF8Encoding]::new($false, $true).GetString($bytes)
        # TextDecoder('utf-8') strips one initial BOM after verifying the bytes.
        if ($text.Length -and $text[0] -eq [char]0xFEFF) { $text = $text.Substring(1) }
        return $text
    }
    $pairs = [System.Collections.Generic.List[object]]::new()
    foreach ($file in $Snapshot['files']) {
        if (-not (& $isBaseline $file['filename']) -and -not (& $isBaseline $file['previous_filename'])) { continue }
        if ($file['status'] -isnot [string] -or $file['status'] -cnotin @('added','modified','removed','renamed')) { throw 'Unknown baseline file status.' }
        if (-not (& $isBaseline $file['filename']) -or $file['status'] -ceq 'removed') { continue }
        $headRepo = if ($Snapshot['head_repo']) { $Snapshot['head_repo'] } else { $repo }
        $names = $headRepo -split '/'
        if ($names.Count -ne 2 -or @($names | Where-Object { $_ -cnotmatch '\A[a-zA-Z0-9_.-]+\z' }).Count) { throw 'Invalid baseline head repository.' }
        if ($file['status'] -ceq 'modified' -and ($Snapshot['diff_base_sha'] -isnot [string] -or $Snapshot['diff_base_sha'] -cnotmatch '\A[a-fA-F0-9]{40}\z')) { throw 'Missing captured baseline diff base.' }
        $base = if ($file['status'] -ceq 'modified') { Read-CapturedBaseline $file['filename'] $Snapshot['diff_base_sha'] $repo } else { $null }
        $head = Read-CapturedBaseline $file['filename'] $Snapshot['head_sha'] $headRepo
        $pairs.Add(@{ path = $file['filename']; base = $base; head = $head })
    }
    return ,$pairs.ToArray()
}

if ($MyInvocation.InvocationName -ne '.') {
    try {
        $files = ConvertFrom-Json -InputObject ([Console]::In.ReadToEnd()) -AsHashtable -NoEnumerate
        if ($Capture) {
            Import-Module (Join-Path $PSScriptRoot 'PrReReviewInput.psm1') -Force
            if ($files -isnot [System.Collections.IDictionary]) { throw 'Invalid baseline capture input' }
            $files = Get-CapturedBaselineFiles -Snapshot $files['snapshot'] -Repository $files['repo']
        }
        if ($files -isnot [array]) { throw 'Invalid baseline input' }
        [Console]::Out.Write((ConvertTo-Json -InputObject (Compare-BaselineFiles -Files $files) -Depth 10 -Compress))
    } catch {
        [Console]::Error.WriteLine("Invalid baseline input: $($_.Exception.Message)")
        exit 1
    }
}
