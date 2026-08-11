#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Determinism guard for emit-repair-report.ps1 (the auto-build-repair PR summary emitter).

.DESCRIPTION
  Renders the comment for every terminal state and asserts the guarantees the
  audit/metrics design depends on:

    1. Every terminal state emits a comment containing exactly one telemetry object.
    2. The telemetry object validates against telemetry-schema.v1.json.
    3. The object is "sanitizer-invariant by construction": it contains only
       characters that gh-aw's add_comment sanitizer never rewrites (no @mention,
       no bare URL, no `#<ref>`, no template delimiters, no XML comment). This is
       what lets CloudMine parse it byte-for-byte out of the issues/comments stream.
    4. The collapsible <details>/<summary> structure is present (allow-listed GFM
       tags the sanitizer preserves).
    5. No stripped <!-- --> HTML comment is relied upon for identity.

  Pure static checks — no network and no gh-aw install required, so it runs anywhere
  (locally and in CI). The live byte-for-byte round-trip through the real sanitizer
  was validated separately against github/gh-aw's sanitize_content.cjs.

.NOTES
  Exit code 0 = all assertions passed; 1 = one or more failed.
#>
[CmdletBinding()]
param(
    [string]$EmitterPath = (Join-Path $PSScriptRoot '..' 'emit-repair-report.ps1'),
    [string]$SchemaPath  = (Join-Path $PSScriptRoot '..' 'telemetry-schema.v1.json')
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$EmitterPath = (Resolve-Path $EmitterPath).Path
$SchemaPath  = (Resolve-Path $SchemaPath).Path
$schema      = Get-Content -Raw $SchemaPath

$failures = [System.Collections.Generic.List[string]]::new()
function Assert([bool]$cond, [string]$msg) {
    if ($cond) { Write-Host "  [PASS] $msg" } else { Write-Host "  [FAIL] $msg" -ForegroundColor Red; $script:failures.Add($msg) }
}

function Get-TelemetryObject([string]$body) {
    $m = [regex]::Match($body, '(?s)```json\s*\n(.*?)\n```')
    if ($m.Success) { return $m.Groups[1].Value } else { return $null }
}

# Characters/patterns the gh-aw sanitizer rewrites. The object must contain NONE of them.
function Test-SanitizerSafe([string]$obj) {
    $violations = @()
    if ($obj -match '(^|[^\w`])@[A-Za-z0-9]')        { $violations += '@mention' }
    if ($obj -match '(?i)[a-z][a-z0-9+.-]*://')        { $violations += 'url-scheme' }
    if ($obj -match '(^|[^\w`])#\w')                   { $violations += 'issue-ref (#n)' }
    if ($obj -match '\{\{|\$\{|<%=|\{#|\{%')           { $violations += 'template-delimiter' }
    if ($obj -match '<!--')                            { $violations += 'xml-comment' }
    return , $violations
}

$tmp = Join-Path ([System.IO.Path]::GetTempPath()) ("emit-tests-" + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $tmp | Out-Null

try {
    # ---- build fixtures for each terminal state --------------------------------
    $repairedDir = Join-Path $tmp 'repaired'; New-Item -ItemType Directory -Path $repairedDir | Out-Null
    [ordered]@{ success = $true; appliedPatches = @(@{ filePath = 'sdk/foo/Azure.Foo/src/Custom.cs'; description = 'fix'; replacementCount = 1 }) } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $repairedDir 'result-1.json')
    # Pre-repair build errors: the deterministic source for the "Build Errors Fixed" list on
    # a first-try success (the successful result carries no buildResult).
    $repairedPre = Join-Path $repairedDir 'pre-repair-errors.txt'
    "sdk/foo/Azure.Foo/src/Custom.cs(1,1): error CS0117: 'X' has no member 'Y'" |
        Set-Content -LiteralPath $repairedPre

    $failedDir = Join-Path $tmp 'failed'; New-Item -ItemType Directory -Path $failedDir | Out-Null
    $nl = [char]10
    [ordered]@{ success = $false; buildResult = "Custom.cs(1,1): error CS0117: bad$nl@evil https://x.test fixes #9"; errorCode = 'maxIterations'; specChangeRequired = @('AZC0012: rename') } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $failedDir 'result-1.json')

    $cases = @(
        @{ name = 'repaired';              args = @('-ResultsDir', $repairedDir, '-PackagePath', 'sdk/foo/Azure.Foo', '-PreRepairSha', '', '-PreRepairErrorsFile', $repairedPre) ; expect = 'repaired' }
        @{ name = 'failed';                args = @('-ResultsDir', $failedDir,   '-PackagePath', 'sdk/foo/Azure.Foo') ; expect = 'failed' }
        @{ name = 'ineligible';            args = @('-Eligible:$false') ; expect = 'ineligible' }
        @{ name = 'skipped_already_green'; args = @('-ForcedStatus', 'skipped_already_green', '-PackagePath', 'sdk/foo/Azure.Foo') ; expect = 'skipped_already_green' }
    )

    foreach ($c in $cases) {
        Write-Host "State: $($c.name)"
        $out = Join-Path $tmp "$($c.name).md"
        $argList = @('-NoProfile', '-File', $EmitterPath) + $c.args + @('-Pr', '123', '-HeadSha', 'abc1234', '-Repo', 'Azure/azure-sdk-for-net', '-OutFile', $out)
        & pwsh @argList | Out-Null
        Assert (Test-Path $out) "renders a comment file"
        $body = Get-Content -Raw $out

        $obj = Get-TelemetryObject $body
        Assert ($null -ne $obj) "contains exactly one telemetry json block"
        Assert ((([regex]::Matches($body, '```json')).Count) -eq 1) "exactly one ```json fence"

        if ($obj) {
            $valid = $false
            try { $valid = Test-Json -Json $obj -Schema $schema -ErrorAction Stop } catch { $valid = $false }
            Assert $valid "telemetry object validates against telemetry-schema.v1.json"

            $parsed = $obj | ConvertFrom-Json
            Assert ($parsed.status -eq $c.expect) "status == '$($c.expect)'"
            Assert ($parsed.schema_version -eq 'v1') "schema_version == v1"
            if ($c.expect -eq 'repaired') { Assert ($null -ne $parsed.repaired_at) "repaired_at set when repaired" }
            else { Assert ($null -eq $parsed.repaired_at) "repaired_at null when not repaired" }

            $v = Test-SanitizerSafe $obj
            Assert ($v.Count -eq 0) ("object is sanitizer-safe" + $(if ($v.Count) { " (violations: $($v -join ', '))" } else { '' }))
        }

        Assert ($body -notmatch '<!--') "no <!-- --> HTML comment (sanitizer strips it)"
        if ($c.expect -ne 'ineligible') {
            Assert ($body -match '<details><summary>Telemetry \(machine-readable\)</summary>') "telemetry <details> present"
            Assert ($body -match '(?m)^### Summary$') "Summary section present"
            Assert ($body -match '(?m)^### Invariants Confirmed$') "Invariants section present"
        }
        Assert ($body -match '## SDK Build Repair') "visible heading present (identity)"

        if ($c.expect -eq 'repaired') {
            # Regression guard: a first-try success must still list the errors it fixed,
            # sourced from the pre-repair build log (the success result has no buildResult).
            Assert ($body -match '(?m)^### Build Errors Fixed$') "repaired: 'Build Errors Fixed' section present"
            Assert ($body -match 'CS0117') "repaired: fixed error code shown (not 'none')"
            Assert ($body -match 'Fix committed as a reviewable commit') "repaired: claims a committed fix"
        }
        if ($c.expect -eq 'failed') {
            Assert ($body -match '(?m)^### Remaining Build Errors$') "failed: 'Remaining Build Errors' section present"
            # This fixture carries specChangeRequired, so the invariant must NOT claim a commit.
            Assert ($body -notmatch 'Fix committed as a reviewable commit') "failed(spec-change): does not falsely claim a committed fix"
            Assert ($body -match 'requires a spec-repo change; nothing committed here') "failed(spec-change): reports out-of-scope, nothing committed"
        }
        if ($c.expect -eq 'skipped_already_green') {
            # Already-green runs commit nothing; the invariant line must not claim a fix.
            Assert ($body -notmatch 'Fix committed as a reviewable commit') "skipped_already_green: does not falsely claim a committed fix"
            Assert ($body -match 'No changes needed - nothing committed') "skipped_already_green: reports nothing committed"
        }
    }

    # -------------------------------------------------------------------------
    # Helper: create a throwaway git repo so the emitter's git-diff-based file
    # list (working-tree vs HEAD, package-scoped) can be exercised deterministically.
    # -------------------------------------------------------------------------
    function New-ScratchRepo([string]$path) {
        New-Item -ItemType Directory -Force -Path $path | Out-Null
        Push-Location $path
        try {
            git init -q | Out-Null
            git config user.email 'test@test.invalid' | Out-Null
            git config user.name  'emit-test'         | Out-Null
            git config commit.gpgsign false           | Out-Null
        } finally { Pop-Location }
    }

    # =========================================================================
    # Grouped Files Changed: per-iteration attribution + Generated/ split +
    # "Other custom changes" bucket + merge-ref package scoping (phantom-files guard).
    # Two iterations edit two custom files; a third custom file is edited but NOT
    # reported by any appliedPatches; one Generated/ file is regenerated; and an
    # unrelated out-of-package file is dirtied to prove the package scope excludes it.
    # =========================================================================
    Write-Host 'Section: grouped file list (iterations + generated + other-custom + scoping)'
    $pkg = 'sdk/foo/Azure.Foo'
    $g1 = Join-Path $tmp 'git-grouped'
    New-ScratchRepo $g1
    Push-Location $g1
    try {
        New-Item -ItemType Directory -Force -Path "$pkg/src/Customizations" | Out-Null
        New-Item -ItemType Directory -Force -Path "$pkg/src/Generated"      | Out-Null
        New-Item -ItemType Directory -Force -Path '.github'                 | Out-Null
        Set-Content "$pkg/src/Customizations/Foo.cs" 'orig'
        Set-Content "$pkg/src/Customizations/Bar.cs" 'orig'
        Set-Content "$pkg/src/Customizations/Baz.cs" 'orig'
        Set-Content "$pkg/src/Generated/Thing.cs"    'orig'
        Set-Content '.github/noise.txt'              'orig'
        git add -A | Out-Null; git commit -q -m base | Out-Null
        # Base advances on an unrelated file to simulate the PR *merge ref* (head + base).
        Set-Content '.github/noise.txt' 'changed-on-base'; git add -A | Out-Null; git commit -q -m 'base advances' | Out-Null
        # Uncommitted repair footprint (as it exists when the emitter runs), PLUS an
        # uncommitted out-of-package edit that an unscoped diff would wrongly include.
        Set-Content "$pkg/src/Customizations/Foo.cs" 'fixed'
        Set-Content "$pkg/src/Customizations/Bar.cs" 'fixed'
        Set-Content "$pkg/src/Customizations/Baz.cs" 'fixed'
        Set-Content "$pkg/src/Generated/Thing.cs"    'regenerated'
        Set-Content '.github/noise.txt'              'uncommitted-noise'
    } finally { Pop-Location }
    $gr = Join-Path $g1 'results'; New-Item -ItemType Directory -Path $gr | Out-Null
    [ordered]@{ success = $false; buildResult = 'Foo.cs(1,1): error CS0103: bad'; appliedPatches = @(@{ filePath = 'src/Customizations/Foo.cs'; description = 'fix Foo'; replacementCount = 2 }) } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $gr 'result-1.json')
    [ordered]@{ success = $true; appliedPatches = @(@{ filePath = 'src/Customizations/Bar.cs'; description = 'fix Bar'; replacementCount = 1 }) } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $gr 'result-2.json')
    $gout = Join-Path $tmp 'grouped.md'
    & pwsh -NoProfile -File $EmitterPath -ResultsDir $gr -PackagePath $pkg -RepoRoot $g1 -Pr 123 -HeadSha 'abc1234' -Repo 'Azure/azure-sdk-for-net' -OutFile $gout | Out-Null
    $gbody = Get-Content -Raw $gout
    Assert ($gbody -match '(?m)^#### Iteration 1$') 'grouped: Iteration 1 header present'
    Assert ($gbody -match '(?m)^#### Iteration 2$') 'grouped: Iteration 2 header present'
    Assert ($gbody -match '(?m)^#### Regenerated \(cumulative\)$') 'grouped: Regenerated group present'
    Assert ($gbody -match '(?m)^#### Other custom changes$') 'grouped: Other-custom group present'
    Assert ($gbody -match 'Foo\.cs`.*fix Foo \(2 replacements\)') 'grouped: Foo attributed to iteration 1 with count'
    Assert ($gbody -match 'Bar\.cs`.*fix Bar \(1 replacement\)') 'grouped: Bar attributed to iteration 2 with count'
    Assert ($gbody -match 'Baz\.cs') 'grouped: unpatched custom file listed under other-custom'
    Assert ($gbody -match 'Thing\.cs`.*Generated') 'grouped: regenerated file typed Generated'
    Assert ($gbody -notmatch 'noise\.txt') 'grouped: out-of-package file excluded (phantom-files guard)'
    Assert ($gbody -match '### Files Changed \(4 distinct: 3 custom, 1 generated\)') 'grouped: header counts distinct/custom/generated'
    Assert ($gbody -match '\| \*\*Iterations used\*\* \| 2 of 3 \|') 'grouped: two iterations reported'

    # =========================================================================
    # Committed-fallback file list: when the repair is already committed the
    # working tree is clean vs HEAD, so the emitter must fall back to diffing the
    # provided -PreRepairSha (still package-scoped), NOT the appliedPatches union.
    # =========================================================================
    Write-Host 'Section: committed-fallback file list (-PreRepairSha)'
    $g2 = Join-Path $tmp 'git-committed'
    New-ScratchRepo $g2
    $preSha = $null
    Push-Location $g2
    try {
        New-Item -ItemType Directory -Force -Path "$pkg/src/Customizations" | Out-Null
        Set-Content "$pkg/src/Customizations/Custom.cs" 'broken'
        git add -A | Out-Null; git commit -q -m 'pre-repair' | Out-Null
        $preSha = (git rev-parse HEAD).Trim()
        # Repair already committed -> working tree clean vs HEAD.
        Set-Content "$pkg/src/Customizations/Custom.cs" 'fixed'
        git add -A | Out-Null; git commit -q -m 'repair' | Out-Null
    } finally { Pop-Location }
    $cr = Join-Path $g2 'results'; New-Item -ItemType Directory -Path $cr | Out-Null
    [ordered]@{ success = $true; appliedPatches = @(@{ filePath = 'src/Customizations/Custom.cs'; description = 'fix'; replacementCount = 1 }) } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $cr 'result-1.json')
    $cout = Join-Path $tmp 'committed.md'
    & pwsh -NoProfile -File $EmitterPath -ResultsDir $cr -PackagePath $pkg -PreRepairSha $preSha -RepoRoot $g2 -Pr 123 -HeadSha 'abc1234' -Repo 'Azure/azure-sdk-for-net' -OutFile $cout | Out-Null
    $cbody = Get-Content -Raw $cout
    Assert ($cbody -match 'Custom\.cs') 'committed-fallback: changed file listed from PreRepairSha diff'
    Assert ($cbody -notmatch 'derived from engine-applied patches') 'committed-fallback: used git (not appliedPatches) source'

    # =========================================================================
    # NoEngineResult: eligible, but the results dir is empty (no result-*.json).
    # Must resolve to status=failed with an explicit 'NoEngineResult' stop reason,
    # never a silent success or a crash.
    # =========================================================================
    Write-Host 'Section: NoEngineResult (eligible, empty results dir)'
    $emptyDir = Join-Path $tmp 'empty-results'; New-Item -ItemType Directory -Path $emptyDir | Out-Null
    $neOut = Join-Path $tmp 'noengine.md'
    & pwsh -NoProfile -File $EmitterPath -ResultsDir $emptyDir -PackagePath $pkg -Pr 123 -HeadSha 'abc1234' -Repo 'Azure/azure-sdk-for-net' -OutFile $neOut | Out-Null
    $neBody = Get-Content -Raw $neOut
    $neObj = Get-TelemetryObject $neBody
    Assert ($null -ne $neObj) 'no-engine: telemetry object present'
    if ($neObj) { Assert ((($neObj | ConvertFrom-Json).status) -eq 'failed') 'no-engine: status == failed' }
    Assert ($neBody -match '\| \*\*Stop reason\*\* \| `NoEngineResult` \|') 'no-engine: NoEngineResult stop reason shown'

    # =========================================================================
    # Format-Cell escaping: an appliedPatches description containing a table pipe
    # and a newline must be escaped (pipe -> \|, newline -> space) so the markdown
    # Files Changed row stays a single, well-formed cell. Exercised via the
    # appliedPatches render path (empty git repo -> no diff -> grouping still runs).
    # =========================================================================
    Write-Host 'Section: Format-Cell escaping (pipe + newline in description)'
    $g3 = Join-Path $tmp 'git-escape'
    New-ScratchRepo $g3
    Push-Location $g3
    try {
        Set-Content 'README.md' 'seed'
        git add -A | Out-Null; git commit -q -m seed | Out-Null   # clean tree, no package changes
    } finally { Pop-Location }
    $er = Join-Path $g3 'results'; New-Item -ItemType Directory -Path $er | Out-Null
    [ordered]@{ success = $true; appliedPatches = @(@{ filePath = "$pkg/src/Custom.cs"; description = "use A | B${nl}second line"; replacementCount = 1 }) } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $er 'result-1.json')
    $eout = Join-Path $tmp 'escape.md'
    & pwsh -NoProfile -File $EmitterPath -ResultsDir $er -PackagePath $pkg -RepoRoot $g3 -Pr 123 -HeadSha 'abc1234' -Repo 'Azure/azure-sdk-for-net' -OutFile $eout | Out-Null
    $ebody = Get-Content -Raw $eout
    Assert ($ebody.Contains('use A \| B second line')) 'escape: pipe escaped and newline flattened in table cell'
    Assert ($ebody -notmatch '(?m)^ second line') 'escape: no raw newline splits the table row'

    # =========================================================================
    # Untracked (newly created) files: `git diff` never lists new files, so the
    # emitter must union in `git ls-files --others` to report the full footprint.
    # Repair edits one tracked file AND creates one brand-new (un-added) file.
    # =========================================================================
    Write-Host 'Section: untracked (new) files included in Files Changed'
    $g4 = Join-Path $tmp 'git-untracked'
    New-ScratchRepo $g4
    Push-Location $g4
    try {
        New-Item -ItemType Directory -Force -Path "$pkg/src/Customizations" | Out-Null
        Set-Content "$pkg/src/Customizations/Existing.cs" 'orig'
        git add -A | Out-Null; git commit -q -m base | Out-Null
        Set-Content "$pkg/src/Customizations/Existing.cs" 'fixed'   # modified (tracked)
        Set-Content "$pkg/src/Customizations/BrandNew.cs" 'new'     # created (untracked, not git add-ed)
    } finally { Pop-Location }
    $ur = Join-Path $g4 'results'; New-Item -ItemType Directory -Path $ur | Out-Null
    [ordered]@{ success = $true; appliedPatches = @(@{ filePath = 'src/Customizations/Existing.cs'; description = 'fix'; replacementCount = 1 }) } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $ur 'result-1.json')
    $uout = Join-Path $tmp 'untracked.md'
    & pwsh -NoProfile -File $EmitterPath -ResultsDir $ur -PackagePath $pkg -RepoRoot $g4 -Pr 123 -HeadSha 'abc1234' -Repo 'Azure/azure-sdk-for-net' -OutFile $uout | Out-Null
    $ubody = Get-Content -Raw $uout
    Assert ($ubody -match 'BrandNew\.cs') 'untracked: newly created file appears in Files Changed'
    Assert ($ubody -match 'Existing\.cs') 'untracked: modified tracked file still appears'
    Assert ($ubody -notmatch 'derived from engine-applied patches') 'untracked: used git working-tree source (not appliedPatches)'

    # =========================================================================
    # Stray non-numeric result file: a file like result-final.json matches the
    # result-*.json glob but is NOT an attempt. It must be ignored (never [int]-
    # parsed during the sort), so the emitter still renders and the numeric
    # attempts alone drive status.
    # =========================================================================
    Write-Host 'Section: stray non-numeric result file ignored (no crash)'
    $g5 = Join-Path $tmp 'git-stray'
    New-ScratchRepo $g5
    Push-Location $g5; try { Set-Content 'README.md' 'seed'; git add -A | Out-Null; git commit -q -m seed | Out-Null } finally { Pop-Location }
    $sr = Join-Path $g5 'results'; New-Item -ItemType Directory -Path $sr | Out-Null
    [ordered]@{ success = $true; appliedPatches = @(@{ filePath = "$pkg/src/Custom.cs"; description = 'fix'; replacementCount = 1 }) } |
        ConvertTo-Json -Depth 6 | Set-Content (Join-Path $sr 'result-1.json')
    Set-Content (Join-Path $sr 'result-final.json') '{"success":false}'   # stray: must be skipped, not crash
    $sout = Join-Path $tmp 'stray.md'
    & pwsh -NoProfile -File $EmitterPath -ResultsDir $sr -PackagePath $pkg -RepoRoot $g5 -Pr 123 -HeadSha 'abc1234' -Repo 'Azure/azure-sdk-for-net' -OutFile $sout | Out-Null
    Assert (Test-Path $sout) 'stray: emitter still renders a comment (stray result-final.json ignored)'
    $sbody = Get-Content -Raw $sout
    $sobj = Get-TelemetryObject $sbody
    Assert ($null -ne $sobj -and (($sobj | ConvertFrom-Json).status) -eq 'repaired') 'stray: numeric result-1.json alone drives status=repaired'
    Assert ((([regex]::Matches($sbody, '```json')).Count) -eq 1) 'stray: exactly one telemetry block'
    Assert ($sbody -match '\| \*\*Iterations used\*\* \| 1 of 3 \|') 'stray: stray file not counted as an iteration'

    # =========================================================================
    # repaired_at determinism: the timestamp must be the write time of the
    # successful result file (when the green result was recorded), NOT render-time
    # Get-Date, so re-emitting the same run yields an identical payload.
    # =========================================================================
    Write-Host 'Section: repaired_at is the result file mtime and stable across re-runs'
    $g6 = Join-Path $tmp 'git-repairedat'
    New-ScratchRepo $g6
    Push-Location $g6; try { Set-Content 'README.md' 'seed'; git add -A | Out-Null; git commit -q -m seed | Out-Null } finally { Pop-Location }
    $rr = Join-Path $g6 'results'; New-Item -ItemType Directory -Path $rr | Out-Null
    $rfile = Join-Path $rr 'result-1.json'
    [ordered]@{ success = $true; appliedPatches = @(@{ filePath = "$pkg/src/Custom.cs"; description = 'fix'; replacementCount = 1 }) } |
        ConvertTo-Json -Depth 6 | Set-Content $rfile
    $fixed = [datetime]::new(2024, 1, 2, 3, 4, 5, [System.DateTimeKind]::Utc)   # pin the mtime
    (Get-Item $rfile).LastWriteTimeUtc = $fixed
    $expected = $fixed.ToString('yyyy-MM-ddTHH:mm:ssZ')
    $raOut = Join-Path $tmp 'repairedat.md'
    & pwsh -NoProfile -File $EmitterPath -ResultsDir $rr -PackagePath $pkg -RepoRoot $g6 -Pr 123 -HeadSha 'abc1234' -Repo 'Azure/azure-sdk-for-net' -OutFile $raOut | Out-Null
    # Assert against the raw JSON text (ConvertFrom-Json would coerce the ISO string to a
    # [datetime], defeating an exact string compare).
    $raJson = Get-TelemetryObject (Get-Content -Raw $raOut)
    Assert ($raJson -match ('"repaired_at":"' + [regex]::Escape($expected) + '"')) 'repaired_at: equals the successful result file mtime (UTC ISO-8601)'
    $raOut2 = Join-Path $tmp 'repairedat2.md'
    & pwsh -NoProfile -File $EmitterPath -ResultsDir $rr -PackagePath $pkg -RepoRoot $g6 -Pr 123 -HeadSha 'abc1234' -Repo 'Azure/azure-sdk-for-net' -OutFile $raOut2 | Out-Null
    $raJson2 = Get-TelemetryObject (Get-Content -Raw $raOut2)
    Assert ($raJson2 -match ('"repaired_at":"' + [regex]::Escape($expected) + '"')) 'repaired_at: stable (unchanged) on re-emit'

    # =========================================================================
    # eligible/status consistency: when status resolves to 'ineligible' the
    # telemetry 'eligible' field must be false, regardless of which path set the
    # status. Both the -Eligible:$false gate and an explicit -ForcedStatus
    # ineligible (even with the default -Eligible $true) must yield eligible=false,
    # so downstream metric denominators never see {"eligible":true,"status":"ineligible"}.
    # =========================================================================
    Write-Host 'Section: eligible=false whenever status=ineligible (both paths)'
    $ineA = Join-Path $tmp 'inelig-gate.md'
    & pwsh -NoProfile -File $EmitterPath -Eligible:$false -Pr 123 -HeadSha 'abc1234' -Repo 'Azure/azure-sdk-for-net' -OutFile $ineA | Out-Null
    $ineAJson = Get-TelemetryObject (Get-Content -Raw $ineA)
    Assert ($ineAJson -match '"eligible":false' -and $ineAJson -match '"status":"ineligible"') 'ineligible-gate: eligible=false, status=ineligible'
    $ineB = Join-Path $tmp 'inelig-forced.md'
    & pwsh -NoProfile -File $EmitterPath -ForcedStatus 'ineligible' -Pr 123 -HeadSha 'abc1234' -Repo 'Azure/azure-sdk-for-net' -OutFile $ineB | Out-Null
    $ineBJson = Get-TelemetryObject (Get-Content -Raw $ineB)
    Assert ($ineBJson -match '"status":"ineligible"') 'ineligible-forced: status=ineligible'
    Assert ($ineBJson -match '"eligible":false') 'ineligible-forced: eligible forced false despite default -Eligible $true'
    Assert ($ineBJson -notmatch '"eligible":true') 'ineligible-forced: no contradictory eligible=true'
}
finally {
    Remove-Item $tmp -Recurse -Force -ErrorAction SilentlyContinue
}

Write-Host ''
if ($failures.Count -gt 0) {
    Write-Host "FAILED: $($failures.Count) assertion(s)." -ForegroundColor Red
    exit 1
}
Write-Host 'All determinism assertions passed.' -ForegroundColor Green
exit 0
