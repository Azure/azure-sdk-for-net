[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory,

    [Parameter()]
    [switch] $StrictMode = !(Test-Path Env:TF_BUILD)
)

$root = "$PSScriptRoot/../../sdk"

# special casing * here because single invocation of SnippetGenerator is much faster than
# running it per service directory
if ($ServiceDirectory -and ($ServiceDirectory -ne '*')) {
    $root += '/' + $ServiceDirectory
}

[string[]] $additionalArgs = @()
if ($StrictMode) {
    $additionalArgs += '-sm'
}

dotnet tool restore

# Helper: capture the set of currently-dirty .md/.cs files (relative to repo
# root) under a given working directory, along with each file's content hash.
# Used to distinguish files modified by snippet-generator from files the
# developer already had dirty before the script ran, so we don't rewrite
# unrelated local edits.
function Get-DirtyMdCsHashes {
    param([string] $WorkingDir)

    $result = @{}
    Push-Location $WorkingDir
    try {
        $statusOutput = git status --porcelain -- . 2>$null
        if ($LASTEXITCODE -ne 0 -or -not $statusOutput) { return $result }
        $repoRoot = (git rev-parse --show-toplevel).Trim()
        foreach ($statusLine in $statusOutput) {
            if ($statusLine.Length -lt 4) { continue }
            $relPath = $statusLine.Substring(3).Trim('"')
            $arrowIdx = $relPath.IndexOf(' -> ')
            if ($arrowIdx -ge 0) {
                $relPath = $relPath.Substring($arrowIdx + 4).Trim('"')
            }
            if (-not ($relPath -match '\.(md|cs)$')) { continue }
            $fullPath = Join-Path $repoRoot $relPath
            if (-not (Test-Path -LiteralPath $fullPath)) { continue }
            $hash = (Get-FileHash -LiteralPath $fullPath -Algorithm SHA256).Hash
            $result[$fullPath] = $hash
        }
    }
    finally {
        Pop-Location
    }
    return $result
}

Resolve-Path $root | ForEach-Object {
    $resolvedRoot = $_.Path

    # Snapshot dirty .md/.cs files BEFORE running snippet-generator so we can
    # tell which files the tool actually touched.
    $beforeHashes = Get-DirtyMdCsHashes -WorkingDir $resolvedRoot

    dotnet tool run snippet-generator -b "$resolvedRoot" $additionalArgs

    # The snippet-generator tool builds inserted snippet blocks using
    # Environment.NewLine, which produces CRLF on Windows. The repo's .md/.cs
    # files use LF endings, so the rewritten files end up with mixed CRLF/LF
    # endings, producing whitespace-only diffs. Normalize only files that the
    # tool actually changed (newly dirty, or dirty before with a different
    # content hash) to avoid rewriting unrelated local edits.
    $afterHashes = Get-DirtyMdCsHashes -WorkingDir $resolvedRoot
    $utf8NoBom = New-Object System.Text.UTF8Encoding($false)
    foreach ($fullPath in $afterHashes.Keys) {
        $afterHash = $afterHashes[$fullPath]
        if ($beforeHashes.ContainsKey($fullPath) -and $beforeHashes[$fullPath] -eq $afterHash) {
            # File was already dirty before the run with identical content — the
            # tool didn't touch it, so leave it alone.
            continue
        }
        if (-not (Test-Path -LiteralPath $fullPath)) { continue }
        $content = [System.IO.File]::ReadAllText($fullPath)
        if ($null -eq $content) { continue }
        if (-not $content.Contains("`r")) { continue }
        $normalized = $content -replace "`r`n", "`n"
        $normalized = $normalized -replace "`r", "`n"
        if ($normalized -ne $content) {
            [System.IO.File]::WriteAllText($fullPath, $normalized, $utf8NoBom)
        }
    }
}
