#Requires -Version 7.0
<#
.SYNOPSIS
Fetch recent push-destination history without changing the regeneration checkout.
#>
param(
    [Parameter(Mandatory = $true)]
    [ValidateRange(1, 10000)]
    [int] $Depth,

    [Parameter(Mandatory = $true)]
    [ValidatePattern('^[0-9a-fA-F]{40,64}$')]
    [string] $SourceVersion
)

$ErrorActionPreference = 'Stop'

# The generated PR targets main. Knowing its recent history lets Git exclude
# objects already present at the push destination when building a push pack.
Write-Host "Fetching main with depth $Depth for regeneration push"
git fetch --no-tags "--depth=$Depth" origin '+refs/heads/main:refs/remotes/origin/regeneration-main'
if ($LASTEXITCODE -ne 0) {
    throw "Unable to fetch main for regeneration push (exit code $LASTEXITCODE)."
}

$shallowFile = git rev-parse --git-path shallow
if ($LASTEXITCODE -ne 0) {
    throw "Unable to locate the Git shallow file (exit code $LASTEXITCODE)."
}

# A synthetic PR merge or divergent source may remain a shallow root even after
# fetching main. Fetch the exact source SHA, not a PR ref that may have moved.
if ((Test-Path -LiteralPath $shallowFile) -and (@(Get-Content -LiteralPath $shallowFile) -contains $SourceVersion)) {
    Write-Host "Deepening shallow source $SourceVersion to depth $Depth"
    git fetch --no-tags "--depth=$Depth" origin "+${SourceVersion}:refs/remotes/origin/regeneration-source"
    if ($LASTEXITCODE -ne 0) {
        throw "Unable to deepen regeneration source $SourceVersion (exit code $LASTEXITCODE)."
    }
}
