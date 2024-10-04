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

function CompatibleConvertFrom-Yaml {
  param(
    # Accept input directly from the command parameter
    [Parameter(Mandatory=$true, ValueFromPipeline=$true)]
    [string]$Content
  )

  if (!($Content)) {
    Write-Error "Content is required."
    exit 1
  }

  # Initialize any variables or checks that need to be done once
  $yqPresent = Get-Command 'yq' -ErrorAction SilentlyContinue
  if (-not $yqPresent) {
    . (Join-Path $PSScriptRoot "../../../../eng/common/scripts/Helpers" PSModule-Helpers.ps1)
    Install-ModuleIfNotInstalled -WhatIf:$false "powershell-yaml" "0.4.1" | Import-Module
  }

  # Process the content (for example, you could convert from YAML here)
  if ($yqPresent) {
      return ($content | yq -o=json | ConvertFrom-Json -AsHashTable)
  }
  else {
      return (ConvertFrom-Yaml (Get-Content -Raw sdk/core/ci.yml))
  }
}