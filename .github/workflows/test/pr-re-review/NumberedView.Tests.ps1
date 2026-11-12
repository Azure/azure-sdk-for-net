#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot '..' '..' 'pr-re-review' 'PrReReviewGuard.psm1') -Force
    $script:output = @{ items = @(@{ type = 'submit_pull_request_review' }) }
    # The start/completion shape and numbered result match Copilot 1.0.80's retained
    # events.jsonl lines 40-41; the exported part and nonce markers are synthetic.
    $script:chunk = "# Review input part 1 [55b88126560859f9]`n# Review input 1/1: sdk/widgets/api/Widgets.cs (modified, +2 -1)`n@@ -1,2 +1,3 @@`n public class Widget`n+public string Name { get; }`n`n# End of part [55b88126560859f9]`n"
    function New-Markers {
        param([string]$Content = $script:chunk)
        $path = Join-Path $TestDrive "markers-$([guid]::NewGuid()).json"
        $data = @{ files = @(@{ path = 'sdk/widgets/api/Widgets.cs'; marker = '55b88126560859f9'; chunks = @(@{ content = $Content }) }) }
        [IO.File]::WriteAllText($path, (ConvertTo-Json -InputObject $data -Depth 10))
        return $path
    }
    function New-Start {
        param([string]$Id = 'toolu_0156eqXs8PQSTYNXXaExN98S', [string]$Tool = 'view')
        return @{ type = 'tool.execution_start'; data = @{ toolCallId = $Id; toolName = $Tool; arguments = @{ path = '/tmp/patches/1-part-1.txt'; view_range = @(1, 200) }; turnId = '6'; model = 'claude-sonnet-5.5'; rte = $true } }
    }
    function New-Complete {
        param([string]$Content, [string]$Id = 'toolu_0156eqXs8PQSTYNXXaExN98S', [bool]$Success = $true)
        return @{ type = 'tool.execution_complete'; data = @{ toolCallId = $Id; model = 'claude-sonnet-5.5'; interactionId = 'interaction'; turnId = '6'; rte = $true; success = $Success; result = @{ content = $Content; detailedContent = $Content }; toolTelemetry = @{} } }
    }
    function ConvertTo-View {
        param([string]$Content, [int]$FirstLine = 1)
        $lines = $Content.TrimEnd([char[]]"`r`n").Split("`n")
        return (@(for ($i = 0; $i -lt $lines.Count; $i++) { "$($i + $FirstLine). $($lines[$i])" }) -join "`n")
    }
    function New-Log {
        param([object[]]$Events, [string]$Path = (Join-Path $TestDrive "events-$([guid]::NewGuid()).jsonl"))
        [IO.File]::WriteAllLines($Path, [string[]]@($Events | ForEach-Object { ConvertTo-Json -InputObject $_ -Depth 20 -Compress }))
        return $Path
    }
}

Describe 'Numbered native view read coverage' {
    It 'accepts a complete exported part returned by a successful correlated view' {
        $log = New-Log @((New-Start), (New-Complete (ConvertTo-View $script:chunk)))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath (New-Markers) -SessionLogPath $log } | Should -Not -Throw
    }

    It 'rejects <Case>' -ForEach @(
        @{ Case = 'a completion without a start' }
        @{ Case = 'a different tool' }
        @{ Case = 'a case-mismatched tool' }
        @{ Case = 'a failed view' }
        @{ Case = 'a view with no success field' }
        @{ Case = 'a different call ID' }
        @{ Case = 'a completion preceding its start' }
        @{ Case = 'a duplicated start' }
        @{ Case = 'a reused ID' }
        @{ Case = 'an inconsistent first number' }
        @{ Case = 'a skipped number' }
        @{ Case = 'a duplicated number' }
        @{ Case = 'out-of-order numbers' }
        @{ Case = 'a doubled prefix' }
        @{ Case = 'an empty number' }
        @{ Case = 'a truncated result' }
        @{ Case = 'a missing line' }
        @{ Case = 'an inserted line inside the part with valid numbering' }
        @{ Case = 'a deleted line inside the part with valid numbering' }
        @{ Case = 'an overflowing number' }
        @{ Case = 'a zero first number' }
        @{ Case = 'a wrapper before the numbered result' }
        @{ Case = 'a wrapper after the numbered result' }
        @{ Case = 'a changed line' }
        @{ Case = 'separate partial results' }
    ) {
        $view = ConvertTo-View $script:chunk
        $start = New-Start
        $complete = New-Complete $view
        $events = @($start, $complete)
        switch ($Case) {
            'a completion without a start' { $events = @($complete) }
            'a different tool' { $start.data.toolName = 'bash' }
            'a case-mismatched tool' { $start.data.toolName = 'View' }
            'a failed view' { $complete.data.success = $false }
            'a view with no success field' { $complete.data.Remove('success') }
            'a different call ID' { $complete.data.toolCallId = 'other' }
            'a completion preceding its start' { $events = @($complete, $start) }
            'a duplicated start' { $events = @($start, $start, $complete) }
            'a reused ID' { $events = @($start, (New-Complete 'unrelated'), $start, $complete) }
            'an inconsistent first number' { $view = $view -replace '^1\. ', '2. ' }
            'a skipped number' { $view = $view -replace '(?m)^3\. ', '4. ' }
            'a duplicated number' { $view = $view -replace '(?m)^3\. ', '2. ' }
            'out-of-order numbers' { $view = $view -replace '(?m)^2\. ', '3. ' -replace '(?m)^3\. (@@)', '2. $1' }
            'a doubled prefix' { $view = $view -replace '(?m)^3\. ', '3. 3. ' }
            'an empty number' { $view = $view -replace '(?m)^3\. ', '. ' }
            'a truncated result' { $view = $view.Substring(0, $view.LastIndexOf("`n")) }
            'a missing line' { $view = $view -replace '(?m)^3\. [^\n]*\n', '' }
            'an inserted line inside the part with valid numbering' { $view = ConvertTo-View $script:chunk.Replace('@@ -1,2 +1,3 @@', "inserted`n@@ -1,2 +1,3 @@") }
            'a deleted line inside the part with valid numbering' { $view = ConvertTo-View $script:chunk.Replace("@@ -1,2 +1,3 @@`n", '') }
            'an overflowing number' { $view = $view -replace '^1\. ', '999999999999999999999999999. ' }
            'a zero first number' { $view = $view -replace '^1\. ', '0. ' }
            'a wrapper before the numbered result' { $view = "View output:`n$view" }
            'a wrapper after the numbered result' { $view += "`nEnd output" }
            'a changed line' { $view = $view.Replace('Widget', 'Gadget') }
            'separate partial results' {
                $split = $view.IndexOf("`n4. ")
                $events = @($start, (New-Complete $view.Substring(0, $split)), (New-Start 'other'), (New-Complete $view.Substring($split + 1) 'other'))
            }
        }
        if ($Case -ne 'separate partial results') { $complete.data.result.content = $view }
        $log = New-Log $events
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath (New-Markers) -SessionLogPath $log } | Should -Throw -ExpectedMessage '*0 of 1*Widgets.cs*'
    }

    It 'accepts multiple complete parts with numbered surrounding content in one view starting at <FirstLine>' -ForEach @(
        @{ FirstLine = 1 }
        @{ FirstLine = 37 }
    ) {
        $second = "# Review input part 2 [9b8a76543210fedc]`n+second 123 ☃`n`n# End of part [9b8a76543210fedc]`n"
        $markers = New-Markers
        $data = Get-Content -LiteralPath $markers -Raw | ConvertFrom-Json -AsHashtable
        $data.files[0].chunks += @{ content = $second }
        [IO.File]::WriteAllText($markers, (ConvertTo-Json -InputObject $data -Depth 10))
        # One spill-file result contains both entire independently marked chunks,
        # as in retained Copilot session events 40-41, plus surrounding lines.
        $combined = "leading context`n$($script:chunk)between parts`n${second}trailing context`n"
        $log = New-Log @((New-Start), (New-Complete (ConvertTo-View $combined $FirstLine)))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath $markers -SessionLogPath $log } | Should -Not -Throw
    }

    It 'rejects a <Damage> second part even when the first is complete in the same numbered result' -ForEach @(
        @{ Damage = 'missing' }
        @{ Damage = 'changed' }
    ) {
        $second = "# Review input part 2 [9b8a76543210fedc]`n+API line`n# End of part [9b8a76543210fedc]`n"
        $markers = New-Markers
        $data = Get-Content -LiteralPath $markers -Raw | ConvertFrom-Json -AsHashtable
        $data.files[0].chunks += @{ content = $second }
        [IO.File]::WriteAllText($markers, (ConvertTo-Json -InputObject $data -Depth 10))
        $actualSecond = if ($Damage -eq 'missing') { '' } else { $second.Replace('+API line', '+changed line') }
        $log = New-Log @((New-Start), (New-Complete (ConvertTo-View "leading`n$($script:chunk)between`n${actualSecond}trailing" 37)))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath $markers -SessionLogPath $log } | Should -Throw -ExpectedMessage '*0 of 1*Widgets.cs*'
    }

    It 'rejects malformed numbering in surrounding content even when the part is complete' {
        $view = (ConvertTo-View "leading`n$($script:chunk)trailing" 37) -replace '^37\. ', '38. '
        $log = New-Log @((New-Start), (New-Complete $view))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath (New-Markers) -SessionLogPath $log } | Should -Throw -ExpectedMessage '*0 of 1*Widgets.cs*'
    }

    It 'does not normalize numbered output from an unrelated tool' {
        $log = New-Log @((New-Start -Tool 'bash'), (New-Complete (ConvertTo-View "leading`n$($script:chunk)trailing" 37)))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath (New-Markers) -SessionLogPath $log } | Should -Throw -ExpectedMessage '*0 of 1*Widgets.cs*'
    }

    It 'does not correlate a start and completion in different sessions with the same ID' {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        [void][IO.Directory]::CreateDirectory((Join-Path $root 'a'))
        [void][IO.Directory]::CreateDirectory((Join-Path $root 'b'))
        [void](New-Log @((New-Start)) (Join-Path $root 'a/events.jsonl'))
        [void](New-Log @((New-Complete (ConvertTo-View $script:chunk))) (Join-Path $root 'b/events.jsonl'))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath (New-Markers) -SessionLogPath $root } | Should -Throw -ExpectedMessage '*0 of 1*Widgets.cs*'
    }

    It 'handles numbered source text, blank lines, Unicode and <Ending> viewer line endings' -ForEach @(
        @{ Ending = 'LF' }
        @{ Ending = 'CRLF' }
    ) {
        $chunk = "# Review input part 1 [55b88126560859f9]`r`n1. original number`r`n`r`n2. ☃ café`r`n# End of part [55b88126560859f9]`r`n"
        $view = "1. # Review input part 1 [55b88126560859f9]`n2. 1. original number`n3. `n4. 2. ☃ café`n5. # End of part [55b88126560859f9]`n"
        if ($Ending -eq 'CRLF') { $view = $view.Replace("`n", "`r`n") }
        $log = New-Log @((New-Start), (New-Complete $view))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath (New-Markers $chunk) -SessionLogPath $log } | Should -Not -Throw
    }

    It 'accepts independently paired views with colliding IDs in separate sessions' {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        [void][IO.Directory]::CreateDirectory((Join-Path $root 'a'))
        [void][IO.Directory]::CreateDirectory((Join-Path $root 'b'))
        [void](New-Log @((New-Start), (New-Complete 'unrelated')) (Join-Path $root 'a/events.jsonl'))
        [void](New-Log @((New-Start), (New-Complete (ConvertTo-View $script:chunk))) (Join-Path $root 'b/events.jsonl'))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath (New-Markers) -SessionLogPath $root } | Should -Not -Throw
    }

    It 'requires each numbered part independently, including double-digit line numbers' {
        $second = "# Review input part 2 [9b8a76543210fedc]`n" + ((1..12 | ForEach-Object { "+API line $_" }) -join "`n") + "`n# End of part [9b8a76543210fedc]`n"
        $markers = New-Markers
        $data = Get-Content -LiteralPath $markers -Raw | ConvertFrom-Json -AsHashtable
        $data.files[0].chunks += @{ content = $second }
        [IO.File]::WriteAllText($markers, (ConvertTo-Json -InputObject $data -Depth 10))
        $firstView = @((New-Start), (New-Complete (ConvertTo-View $script:chunk)))
        $log = New-Log $firstView
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath $markers -SessionLogPath $log } | Should -Throw -ExpectedMessage '*0 of 1*Widgets.cs*'
        $log = New-Log ($firstView + @((New-Start 'other'), (New-Complete (ConvertTo-View $second) 'other')))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath $markers -SessionLogPath $log } | Should -Not -Throw
    }

    It 'preserves bare carriage returns in source lines' {
        $chunk = "# Review input part 1 [55b88126560859f9]`n+one`rtwo`n# End of part [55b88126560859f9]`n"
        $log = New-Log @((New-Start), (New-Complete (ConvertTo-View $chunk)))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath (New-Markers $chunk) -SessionLogPath $log } | Should -Not -Throw
    }

    It 'rejects a stripped bare carriage return in a numbered source line' {
        $chunk = "# Review input part 1 [55b88126560859f9]`n+one`rtwo`n# End of part [55b88126560859f9]`n"
        $view = (ConvertTo-View $chunk).Replace("`r", '')
        $log = New-Log @((New-Start), (New-Complete $view))
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath (New-Markers $chunk) -SessionLogPath $log } | Should -Throw -ExpectedMessage '*0 of 1*Widgets.cs*'
    }

    It 'still accepts an uncorrelated raw shell completion with surrounding text' {
        $complete = New-Complete "shell header`n$($script:chunk)shell footer"
        $complete.data.Remove('toolCallId')
        $log = New-Log @($complete)
        { Assert-PrReReviewReadCoverage $script:output -MarkersPath (New-Markers) -SessionLogPath $log } | Should -Not -Throw
    }
}
