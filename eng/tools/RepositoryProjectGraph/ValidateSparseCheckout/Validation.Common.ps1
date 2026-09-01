Set-StrictMode -Version 3.0

function Get-SparseCheckoutValidationHarnessVersion([string] $ScriptRoot) {
    # Results are reusable only when every executable harness component is unchanged. Normalize
    # line endings so the same committed scripts hash identically on Linux and Windows checkouts.
    $files = @(
        Get-ChildItem -LiteralPath $ScriptRoot -Filter '*.ps1' -File
        Get-Item -LiteralPath (Join-Path $ScriptRoot 'Dockerfile')
    ) | Sort-Object Name

    $sha = [System.Security.Cryptography.SHA256]::Create()
    try {
        foreach ($file in $files) {
            $content = [System.IO.File]::ReadAllText($file.FullName).Replace("`r`n", "`n").Replace("`r", "`n")
            $bytes = [System.Text.Encoding]::UTF8.GetBytes("$($file.Name)`n$content`n")
            $null = $sha.TransformBlock($bytes, 0, $bytes.Length, $bytes, 0)
        }
        $null = $sha.TransformFinalBlock([byte[]]::new(0), 0, 0)
        return [Convert]::ToHexString($sha.Hash).ToLowerInvariant()
    }
    finally {
        $sha.Dispose()
    }
}

function Test-SparseCheckoutArtifactHasTestProjects($CheckoutGraph, [string] $ArtifactName) {
    # Artifact seeds are configuration keys whose project path is repository-relative. Source-only
    # artifacts must retain their source projects when service.proj applies its normal exclusions.
    $artifact = $CheckoutGraph.artifacts.PSObject.Properties[$ArtifactName]
    if ($null -eq $artifact) {
        throw "Sparse checkout graph has no artifact '$ArtifactName'."
    }
    return @($artifact.Value | Where-Object {
        [string]$_ -match '^configuration:.*/tests/.*\.csproj\|'
    }).Count -gt 0
}

function Get-SparseCheckoutValidationDirectoryHash([string] $Directory) {
    $relativePaths = [System.Collections.Generic.List[string]]::new()
    foreach ($file in Get-ChildItem -LiteralPath $Directory -File -Recurse) {
        $relativePaths.Add([System.IO.Path]::GetRelativePath($Directory, $file.FullName).Replace('\', '/'))
    }
    $relativePaths.Sort([StringComparer]::Ordinal)

    $sha = [System.Security.Cryptography.SHA256]::Create()
    try {
        foreach ($relativePath in $relativePaths) {
            $nameBytes = [System.Text.Encoding]::UTF8.GetBytes("$relativePath`n")
            $null = $sha.TransformBlock($nameBytes, 0, $nameBytes.Length, $nameBytes, 0)
            $contentBytes = [System.IO.File]::ReadAllBytes((Join-Path $Directory $relativePath))
            $null = $sha.TransformBlock($contentBytes, 0, $contentBytes.Length, $contentBytes, 0)
            $separator = [byte[]]@(0)
            $null = $sha.TransformBlock($separator, 0, 1, $separator, 0)
        }
        $null = $sha.TransformFinalBlock([byte[]]::new(0), 0, 0)
        return [Convert]::ToHexString($sha.Hash).ToLowerInvariant()
    }
    finally {
        $sha.Dispose()
    }
}
