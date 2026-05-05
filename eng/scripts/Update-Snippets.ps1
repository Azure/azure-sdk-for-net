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
Resolve-Path $root | ForEach-Object {
    $resolvedRoot = $_.Path
    dotnet tool run snippet-generator -b "$resolvedRoot" $additionalArgs

    # The snippet-generator tool builds inserted snippet blocks using
    # Environment.NewLine, which produces CRLF on Windows. The original .md/.cs
    # files in this repo use LF endings, so the rewritten files end up with mixed
    # CRLF/LF endings, producing whitespace-only diffs. Normalize touched files to
    # LF here. Only the files the tool actually modified (per git) are normalized
    # to avoid touching unrelated files.
    Push-Location $resolvedRoot
    try {
        # `git diff --name-only` doesn't surface CRLF↔LF-only changes when
        # core.autocrlf is enabled, but `git status --porcelain` does (it tracks
        # working-tree changes regardless of normalization). The format is
        # "XY <path>" where XY is the two-letter status code.
        $statusOutput = git status --porcelain -- . 2>$null
        if ($LASTEXITCODE -eq 0 -and $statusOutput) {
            $repoRoot = (git rev-parse --show-toplevel).Trim()
            foreach ($statusLine in $statusOutput) {
                if ($statusLine.Length -lt 4) { continue }
                $relPath = $statusLine.Substring(3).Trim('"')
                # Handle renames: "old -> new"
                $arrowIdx = $relPath.IndexOf(' -> ')
                if ($arrowIdx -ge 0) {
                    $relPath = $relPath.Substring($arrowIdx + 4).Trim('"')
                }
                if (-not ($relPath -match '\.(md|cs)$')) { continue }
                $fullPath = Join-Path $repoRoot $relPath
                if (-not (Test-Path -LiteralPath $fullPath)) { continue }
                $content = [System.IO.File]::ReadAllText($fullPath)
                if ($null -eq $content) { continue }
                if ($content.Contains("`r")) {
                    $normalized = $content -replace "`r`n", "`n"
                    $normalized = $normalized -replace "`r", "`n"
                    if ($normalized -ne $content) {
                        $utf8NoBom = New-Object System.Text.UTF8Encoding($false)
                        [System.IO.File]::WriteAllText($fullPath, $normalized, $utf8NoBom)
                    }
                }
            }
        }
    }
    finally {
        Pop-Location
    }
}
