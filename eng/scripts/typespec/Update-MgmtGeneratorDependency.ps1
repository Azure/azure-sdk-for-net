#Requires -Version 7.0
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [string] $RepoRoot,
    [Parameter(Mandatory)] [string] $PublishedPackageJson,
    [Parameter(Mandatory)] [string] $Version
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

$published = Get-Content -LiteralPath $PublishedPackageJson -Raw | ConvertFrom-Json -AsHashtable
if ($published.name -ne '@azure-typespec/http-client-csharp' -or $published.version -ne $Version) {
    throw 'The published package artifact name or version does not match the branded build.'
}
# Keep the unbranded dependency aligned with the published branded release.
$unbranded = $published.dependencies['@typespec/http-client-csharp']
try {
    $newVersion = [System.Management.Automation.SemanticVersion]::Parse($Version)
    [void][System.Management.Automation.SemanticVersion]::Parse($unbranded)
} catch {
    throw 'The published package must contain exact branded and unbranded versions.'
}

$mgmtPath = Join-Path $RepoRoot 'eng' 'packages' 'http-client-csharp-mgmt'
$mgmt = Get-Content -LiteralPath (Join-Path $mgmtPath 'package.json') -Raw | ConvertFrom-Json -AsHashtable
$propsPath = Join-Path $RepoRoot 'eng' 'centralpackagemanagement' 'Directory.Generation.Packages.props'
$props = Get-Content -LiteralPath $propsPath -Raw
$matches = [regex]::Matches($props, '<AzureGeneratorVersion>([^<]+)</AzureGeneratorVersion>')
if ($matches.Count -ne 1) { throw 'Expected exactly one AzureGeneratorVersion property.' }
$currentProps = [System.Management.Automation.SemanticVersion]::Parse($matches[0].Groups[1].Value)
$currentMgmt = [System.Management.Automation.SemanticVersion]::Parse($mgmt.dependencies['@azure-typespec/http-client-csharp'])
if ($newVersion -lt $currentProps -or $newVersion -lt $currentMgmt) {
    Write-Host "Skipping $Version because main already references a newer branded generator."
    return
}
if ($newVersion -eq $currentProps -and $newVersion -eq $currentMgmt -and $mgmt.dependencies['@typespec/http-client-csharp'] -eq $unbranded) {
    Write-Host "Management already uses $Version."
    return
}

Push-Location $mgmtPath
try {
    npm pkg set "dependencies.@azure-typespec/http-client-csharp=$Version" "dependencies.@typespec/http-client-csharp=$unbranded"
    if ($LASTEXITCODE -ne 0) { throw 'npm pkg set failed.' }
    $updatedProps = $props.Substring(0, $matches[0].Groups[1].Index) + $Version + $props.Substring($matches[0].Groups[1].Index + $matches[0].Groups[1].Length)
    [System.IO.File]::WriteAllText($propsPath, $updatedProps, [System.Text.UTF8Encoding]::new($false))
    # Set this before install so a failed update can still be surfaced for manual repair.
    Write-Host '##vso[task.setvariable variable=MgmtDependencyUpdateNeeded]true'
    npm install
    if ($LASTEXITCODE -ne 0) { throw 'npm install failed.' }
} finally {
    Pop-Location
}
