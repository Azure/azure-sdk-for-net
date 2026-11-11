# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Compare captured central ApiCompat baseline XML. Input and output are JSON on
# standard streams; never execute PR content or resolve XML entities.
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

try {
    $files = ConvertFrom-Json -InputObject ([Console]::In.ReadToEnd()) -AsHashtable -NoEnumerate
    if ($files -isnot [array]) { throw 'Invalid baseline input' }
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
    [Console]::Out.Write((ConvertTo-Json -InputObject $result.ToArray() -Depth 10 -Compress))
} catch {
    [Console]::Error.WriteLine("Invalid baseline input: $($_.Exception.Message)")
    exit 1
}
