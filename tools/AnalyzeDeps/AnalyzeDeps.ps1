<#
  .SYNOPSIS
  Generate a dependency report for a set of .nupkg files

  .PARAMETER PackagesPath
  The path to the package(s) to analyze. Globs are supported.

  .PARAMETER LockfilePath
  The path to the lockfile to analyze.
#>

Param(
  [Parameter(Mandatory = $true)][string]$PackagesPath,
  [Parameter(Mandatory = $false)][string]$LockfilePath
)

Function Get-Nuspec($NupkgPath) {
  try {
    $ZipFile = [IO.Compression.ZipFile]::OpenRead($NupkgPath)
    foreach ($Entry in $ZipFile.Entries) {
      if ($Entry.Name.EndsWith(".nuspec")) {
        Write-Host "Nuspec: $Entry.Name"
        try {
          $Reader = New-Object -TypeName System.IO.StreamReader -ArgumentList $Entry.Open()
          return [xml]$Reader.ReadToEnd()
        }
        finally {
          if ($Reader) {
            $Reader.Close()
          }
        }
      }
    }
    return $null
  }
  finally {
    if ($ZipFile) {
      $ZipFile.Dispose()
    }
  }
}

Function Save-Dep($Deps, $TargetFramework, $DepName, $DepVersion, $DependentPackage) {
  if (-Not $Deps[$DepName]) {
    $Deps[$DepName] = @{ }
  }
  if (-Not $Deps[$DepName][$TargetFramework]) {
    $Deps[$DepName][$TargetFramework] = @{ }
  }
  if (-Not $Deps[$DepName][$TargetFramework][$DepVersion]) {
    $Deps[$DepName][$TargetFramework][$DepVersion] = New-Object System.Collections.ArrayList
  }
  if (-Not $Deps[$DepName][$TargetFramework][$DepVersion].Contains($DependentPackage)) {
    $Deps[$DepName][$TargetFramework][$DepVersion].Add($DependentPackage) | Out-Null
  }
}

Function Save-Locked($Locked, $DepName, $DepVersion, $Condition) {
  if (-Not $Locked[$DepName]) {
    $Locked[$DepName] = @{ }
  }
  if (-Not $Locked[$DepName][$DepVersion]) {
    $Locked[$DepName][$DepVersion] = New-Object System.Collections.ArrayList
  }
  if (-Not $Locked[$DepName][$DepVersion].Contains($Condition)) {
    $Locked[$DepName][$DepVersion].Add($Condition.Trim()) | Out-Null
  }
}

# Analyze package dependencies
$Pkgs = @{ }
$Deps = @{ }
foreach ($PkgFile in Resolve-Path $PackagesPath) {
  Write-Host "File $PkgFile"
  $Nuspec = Get-Nuspec $PkgFile
  $LibraryName = $Nuspec.package.metadata.id
  $LibraryVer = $Nuspec.package.metadata.version

  $Pkgs[$LibraryName] = @($LibraryVer, $PkgFile)

  foreach ($Group in $Nuspec.package.metadata.dependencies.group) {
    foreach ($Dep in $Group.dependency) {
      Save-Dep $Deps $Group.targetFramework $Dep.id $Dep.version $LibraryName
    }
  }

  foreach ($Dep in $Nuspec.package.metadata.dependencies.dependency) {
    if ($Deps.Count) {
      foreach ($TargetFramework in $Deps.Keys) {
        Save-Dep $Deps $TargetFramework $Dep.id $Dep.version $LibraryName
      }
      Save-Dep $Deps "(others)" $Dep.id $Dep.version $LibraryName
    }
    else {
      Save-Dep $Deps "(any)" $Dep.id $Dep.version $LibraryName
    }
  }
}

# Analyze lockfile
$Locked = @{ }
if ($LockfilePath) {
  [xml]$PackageProps = Get-Content $LockfilePath
  foreach ($ItemGroup in $PackageProps.Project.ItemGroup) {
    if ($ItemGroup.Condition) {
      $Condition = $ItemGroup.Condition
    } else {
      $Condition = ""
    }
    foreach ($Entry in $ItemGroup.PackageReference) {
      if ($Entry.Update) {
        Save-Locked $Locked $Entry.Update $Entry.Version $Condition
      }
    }
  }
}

# Precompute some derived data for the template
$External = $Deps.Keys | Where-Object { -not ($Pkgs.ContainsKey($_)) }
$Inconsistent = @{ }
$MismatchedVersions = @{ }
$Unlocked = New-Object System.Collections.ArrayList
foreach ($DepName in $Deps.Keys) {
  $InconsistentFrameworks = $Deps[$DepName].Keys | Where-Object { $Deps[$DepName][$_].Count -gt 1 }
  if ($InconsistentFrameworks) {
    $Inconsistent[$DepName] = $InconsistentFrameworks
  }

  if ($Locked.ContainsKey($DepName)) {
    foreach ($TargetFramework in $Deps[$DepName].Keys) {
      foreach ($DepVer in $Deps[$DepName][$TargetFramework].Keys) {
        if (-Not $Locked[$DepName].ContainsKey($DepVer)) {
          if (-Not $MismatchedVersions[$DepName]) {
            $MismatchedVersions[$DepName] = @{ }
          }
          $MismatchedVersions[$DepName][$DepVer] = $Deps[$DepName][$TargetFramework][$DepVer]
        }
      }
    }
  } else {
    $Unlocked.Add($DepName) | Out-Null
  }
}

$__template__ = Get-Content 'deps.html.tpl' -Raw
Invoke-Expression "@`"`r`n$__template__`r`n`"@" | Out-File -FilePath .\deps.html
