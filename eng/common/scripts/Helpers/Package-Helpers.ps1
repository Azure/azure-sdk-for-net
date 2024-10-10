function GetPackageKey($pkg) {
  $pkgKey = $pkg.Package
  $groupId = $null

  if ($pkg.PSObject.Members.Name -contains "GroupId") {
    $groupId = $pkg.GroupId
  }

  if ($groupId) {
    $pkgKey = "${groupId}:${pkgKey}"
  }

  return $pkgKey
}

# Different language needs a different way to index the package. Build a map in convienice to lookup the package.
# E.g. <groupId>:<packageName> is the package key in java.
function GetPackageLookup($packageList) {
  $packageLookup = @{}

  foreach ($pkg in $packageList) {
    $pkgKey = GetPackageKey $pkg

    # We want to prefer updating non-hidden packages but if there is only
    # a hidden entry then we will return that
    if (!$packageLookup.ContainsKey($pkgKey) -or $packageLookup[$pkgKey].Hide -eq "true") {
      $packageLookup[$pkgKey] = $pkg
    }
    else {
      # Warn if there are more then one non-hidden package
      if ($pkg.Hide -ne "true") {
        Write-Host "Found more than one package entry for $($pkg.Package) selecting the first non-hidden one."
      }
    }
  }
  return $packageLookup
}

# For deprecated packages, add "(deprecated)" besides of display name.
function GetDocsTocDisplayName($pkg) {
  $displayName = $pkg.DisplayName
  if ('deprecated' -eq $pkg.Support) {
    LogWarning "The pkg $($pkg.Package) is deprecated. Adding 'deprecated' beside the display name."
    $displayName += " (deprecated)"
  }
  return $displayName
}


<#
.SYNOPSIS
This function is a safe wrapper around `yq` and `ConvertFrom-Yaml` to convert YAML content to a PowerShell HashTable object

.DESCRIPTION
This function wraps `yq` and `ConvertFrom-Yaml` to convert YAML content to a PowerShell HashTable object. The reason this function exists is
because while on a local user's machine, installing a module from the powershell gallery is an easy task, in pipelines we often have failures
to install modules from the gallery. This function will attempt to use the `yq` command if it is available on the machine, and only will install
the yaml module if `yq` is not available. This means that for the majority of runs on CI machines, the yaml module will not be installed.

.PARAMETER Content
The content to convert from YAML to a PowerShell HashTable object. Accepted as named argument or from the pipeline.

.EXAMPLE
CompatibleConvertFrom-Yaml -Content (Get-Content -Raw path/to/file.yml)

.EXAMPLE
Get-Content -Raw path/to/file.yml | CompatibleConvertFrom-Yaml
#>
function CompatibleConvertFrom-Yaml {
  param(
    [Parameter(Mandatory=$true, ValueFromPipeline=$true)]
    [string]$Content
  )

  if (!($Content)) {
    throw "Content to parse is a required input."
  }

  # Initialize any variables or checks that need to be done once
  $yqPresent = Get-Command 'yq' -ErrorAction SilentlyContinue
  if (-not $yqPresent) {
    . (Join-Path $PSScriptRoot PSModule-Helpers.ps1)
    Install-ModuleIfNotInstalled -WhatIf:$false "powershell-yaml" "0.4.1" | Import-Module
  }

  # Process the content (for example, you could convert from YAML here)
  if ($yqPresent) {
      return ($content | yq -o=json | ConvertFrom-Json -AsHashTable)
  }
  else {
      return ConvertFrom-Yaml $content
  }
}