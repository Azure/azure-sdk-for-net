#Requires -Version 6.0
#Requires -PSEdition Core

<#
.SYNOPSIS
Within an assets.json file that has in a conflicted state (specifically on asset tag), merge the two tags that are conflicting and leave the assets.json in a commitable state.

.DESCRIPTION
USAGE: resolve-asset-conflict.ps1 path/to/target_assets_json

Parses the assets.json file and determines which tags are in conflict. If there are no conflicts, the script exits.

1. Parse the tags (base and target) from conflicting assets.json.
2. Update the assets.json with the base tag, but remember the target tag.
3. merge-proxy-tags.ps1 $AssetsJson base_tag target_tag

This script requires that test-proxy or azure.sdk.tools.testproxy should be on the PATH.

.PARAMETER AssetsJson
The script uses a target assets.json to understand what tags are in conflict. This is the only required parameter.
#>

param(
  [Parameter(Position=0)]
  [string] $AssetsJson
)

. (Join-Path $PSScriptRoot ".." ".." "onboarding" "common-asset-functions.ps1")
. (Join-Path $PSScriptRoot ".." ".." ".." "scripts" "Helpers" "git-helpers.ps1")

$TestProxy = Resolve-Proxy

if (!(Test-Path $AssetsJson)) {
  Write-Error "AssetsJson file does not exist: $AssetsJson"
  exit 1
}

# normally we we would Resolve-Path the $AssetsJson, but the git show command only works with relative paths, so we'll just keep that here.
if (-not $AssetsJson.EndsWith("assets.json")) {
  Write-Error "This script can only resolve conflicts within an assets.json. The file provided is not an assets.json: $AssetsJson"
  exit 1
}

$conflictingAssets = [ConflictedFile]::new($AssetsJson)

if (-not $conflictingAssets.IsConflicted) {
  Write-Host "No conflicts found in $AssetsJson, nothing to resolve, so there is no second tag to merge. Exiting"
  exit 0
}

# this is very dumb, but will properly work!
try {
  $BaseAssets = $conflictingAssets.Left() | ConvertFrom-Json
}
catch {
  Write-Error "Failed to convert previous version to valid JSON format."
  exit 1
}

try {
  $TargetAssets = $conflictingAssets.Right() | ConvertFrom-Json
}
catch {
  Write-Error "Failed to convert target assets.json version to valid JSON format."
  exit 1
}

Write-Host "Replacing conflicted assets.json with base branch version." -ForegroundColor Green
Set-Content -Path $AssetsJson -Value $conflictingAssets.Left()

$ScriptPath = Join-Path $PSScriptRoot ".." "tag-merge" "merge-proxy-tags.ps1"
& $ScriptPath $AssetsJson $BaseAssets.Tag $TargetAssets.Tag

if ($lastexitcode -eq 0) {
   Write-Host "Successfully auto-merged assets tag '$($TargetASsets.Tag)' into tag '$($BaseAssets.Tag)'. Invoke 'test-proxy push -a $AssetsJson' and commit the resulting assets.json!" -ForegroundColor Green
}
else {
  Write-Host "Conflicts were discovered, resolve the conflicts and invoke the `"merge-proxy-tags.ps1`" as recommended in the line directly above."
}