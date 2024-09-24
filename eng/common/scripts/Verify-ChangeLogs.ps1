# Wrapper Script for ChangeLog Verification in a PR
[CmdletBinding()]
param (
  [String]$PackagePropertiesFolder
)
Set-StrictMode -Version 3

. (Join-Path $PSScriptRoot common.ps1)

function ShouldVerifyChangeLog ($ServiceDirectory, $PackageName) {
    $jsonCiYmlPath = Join-Path $ServiceDirectory "ci.yml.json"

    if (Test-Path $jsonCiYmlPath)
    {
        $ciYml = ConvertFrom-Json (Get-Content $jsonCiYmlPath -Raw)

        if ($ciYml.extends -and $ciYml.extends.parameters -and $ciYml.extends.parameters.Artifacts) {
            $packagesCheckingChangeLog = $ciYml.extends.parameters.Artifacts `
                | Where-Object { -not ($_["skipVerifyChangelog"] -eq $true) }
                | Select-Object -ExpandProperty name

            if ($packagesCheckingChangeLog -contains $PackageName)
            {
                return $true
            } else {
                return $false
            }
        }
    }
}

# find which packages we need to confirm the changelog for
$packageProperties = Get-ChildItem -Recurse "$PackagePropertiesFolder" *.json

# grab the json file, then confirm the changelog entry for it
$allPassing = $true
foreach($propertiesFile in $packageProperties) {
  $PackageProp = Get-Content -Path $propertiesFile | ConvertFrom-Json

  if (-not (ShouldVerifyChangeLog -ServiceDirectory (Join-Path $RepoRoot "sdk" $PackageProp.ServiceDirectory) -PackageName $PackageProp.Name)) {
        Write-Host "Skipping changelog verification for $($PackageProp.Name)"
        continue
  }

  $validChangeLog =  Confirm-ChangeLogEntry -ChangeLogLocation $PackageProp.ChangeLogPath -VersionString $PackageProp.Version -ForRelease $false

  if (-not $validChangeLog) {
    $allPassing = $false
  }
}

if (!$allPassing)
{
  exit 1
}

exit 0
