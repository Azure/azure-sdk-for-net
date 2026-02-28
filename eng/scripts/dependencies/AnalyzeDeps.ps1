<#
  .SYNOPSIS
  Generate a dependency report for a set of .nupkg files

  .PARAMETER PackagesPath
  The path to the package(s) to analyze. Globs are supported.

  .PARAMETER CpmDirectory
  The path to the Central Package Management (CPM) directory.
  All .props files will be scanned recursively.

  .PARAMETER OutPath
  The path to the write the HTML-formatted report.

  .PARAMETER DumpPath
  The path to the write the JSONP-formatted dependency data file.
#>

Param(
  [Parameter(Mandatory = $true)][string]$PackagesPath,
  [Parameter(Mandatory = $false)][string]$CpmDirectory,
  [Parameter(Mandatory = $false)][string]$OutPath,
  [Parameter(Mandatory = $false)][string]$DumpPath
)

Add-Type -AssemblyName System.IO.Compression.FileSystem

Function Get-Nuspec($NupkgPath) {
  try {
    $ZipFile = [IO.Compression.ZipFile]::OpenRead($NupkgPath)
    foreach ($Entry in $ZipFile.Entries) {
      if ($Entry.Name.EndsWith(".nuspec")) {
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

Function Save-PkgDep($PkgDeps, $TargetFramework, $DepName, $DepVersion) {
  if (-Not $PkgDeps[$DepName]) {
    $PkgDeps[$DepName] = @{ }
  }
  if (-Not $PkgDeps[$DepName][$DepVersion]) {
    $PkgDeps[$DepName][$DepVersion] = New-Object System.Collections.ArrayList
  }
  if (-Not $PkgDeps[$DepName][$DepVersion].Contains($TargetFramework)) {
    $PkgDeps[$DepName][$DepVersion].Add($TargetFramework) | Out-Null
  }
}

Function Save-Locked($Locked, $DepName, $DepVersion, $Condition) {
  if (!$DepVersion) {
    Write-Warning "$DepName in CPM files does not contain a Version property so skipping it."
    return
  }
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

Function Get-PackageExport($Pkgs, $Internal) {
  $DumpData = @{ }
  foreach ($PkgName in $Pkgs.Keys) {
    $PkgInfo = $Pkgs[$PkgName]
    $Id = $PkgName + ":" + $PkgInfo.Ver
    $InternalDeps = [System.Collections.ArrayList]@()
    foreach ($Dep in $PkgInfo.Deps)
    {
      if ($Internal.Contains($Dep.name)) {
        $InternalDeps.Add($Dep) > $Null
      }
    }
    $DumpData[$Id] = @{
      name    = $PkgName;
      version = $PkgInfo.Ver;
      type    = "internal";
      deps    = $InternalDeps
    }
  }

  $PkgIds = $DumpData.Keys | ForEach-Object ToString
  foreach ($PkgId in $PkgIds) {
    foreach ($Dep in $DumpData[$PkgId].deps) {
      $DepId = $Dep.name + ":" + $Dep.version
      if (-Not $DumpData.ContainsKey($DepId)) {
        $DumpData[$DepId] = @{
          name    = $Dep.name;
          version = $Dep.version;
          type    = "internalbinary";
          deps    = @()
        }
      }
    }
  }

  return $DumpData
}

# Analyze package dependencies
$Pkgs = @{ }
$Deps = @{ }
foreach ($PkgFile in (Get-ChildItem "$PackagesPath/*.nupkg")) {
  $Nuspec = Get-Nuspec $PkgFile
  $LibraryName = $Nuspec.package.metadata.id
  $LibraryVer = $Nuspec.package.metadata.version

  $Pkgs[$LibraryName] = @{ Ver = $LibraryVer; Src = $PkgFile; Deps = New-Object System.Collections.ArrayList }
  $PkgDeps = @{ }
  
  foreach ($Group in $Nuspec.package.metadata.dependencies.group) {
    foreach ($Dep in $Group.dependency) {
      Save-PkgDep $PkgDeps $Group.targetFramework $Dep.id $Dep.version
      Save-Dep $Deps $Group.targetFramework $Dep.id $Dep.version $LibraryName
    }
  }

  foreach ($Dep in $Nuspec.package.metadata.dependencies.dependency) {
    Save-PkgDep $PkgDeps "" $Dep.id $Dep.version
    if ($Deps.Count) {
      foreach ($TargetFramework in $Deps.Keys) {
        Save-Dep $Deps $TargetFramework $Dep.id $Dep.version $LibraryName
      }
      Save-Dep $Deps "(others)" $Dep.id $Dep.version $LibraryName
    } else {
      Save-Dep $Deps "(any)" $Dep.id $Dep.version $LibraryName
    }
  }
  
  foreach ($DepName in $PkgDeps.Keys) {
    $DepVersions = $PkgDeps[$DepName]
    if ($DepVersions.Count -gt 1) {
      foreach ($DepVersion in $DepVersions.Keys) {
        $TargetFrameworks = $DepVersions[$DepVersion]
        $Pkgs[$LibraryName]["Deps"].Add(@{name = $DepName; version = $DepVersion; label = ($TargetFrameworks -Join ", ") }) | Out-Null
      }
    } else {
      $Pkgs[$LibraryName]["Deps"].Add(@{name = $DepName; version = ($DepVersions.Keys | Select-Object -first 1) }) | Out-Null
    } 
  }
}

Write-Host "Analyzing $($Pkgs.Count) packages..."

# Analyze CPM (Central Package Management) files
$Locked = @{ }

Function Read-CpmFile($FilePath, $Locked) {
  if (-Not (Test-Path $FilePath)) {
    Write-Warning "CPM file not found: $FilePath"
    return
  }

  [xml]$PackageProps = Get-Content $FilePath

  # Process ItemGroups for package versions
  foreach ($ItemGroup in $PackageProps.Project.ItemGroup) {
    if ($ItemGroup.Condition) {
      $Condition = $ItemGroup.Condition
    } else {
      $Condition = ""
    }

    # Handle CPM format: <PackageVersion Include="..." Version="..." /> or <PackageVersion Update="..." Version="..." />
    foreach ($Entry in $ItemGroup.PackageVersion) {
      if ($Entry.Include) {
        Save-Locked $Locked $Entry.Include $Entry.Version $Condition
      }
      if ($Entry.Update) {
        Save-Locked $Locked $Entry.Update $Entry.Version $Condition
      }
    }
  }
}

if ($CpmDirectory) {
  if (-Not (Test-Path $CpmDirectory -PathType Container)) {
    Write-Error "CpmDirectory must be a directory path: $CpmDirectory"
    exit 1
  }
  $PropsFiles = Get-ChildItem -Path $CpmDirectory -Filter "*.props" -Recurse
  foreach ($PropsFile in $PropsFiles) {
    Write-Host "Reading CPM file: $($PropsFile.FullName)"
    Read-CpmFile $PropsFile.FullName $Locked
  }
  Write-Host "Discovered $($Locked.Count) versions pinned in CPM files."
} else {
  Write-Warning "No CPM directory was provided. Declared dependency versions were not able to be validated."
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

$ExitCode = 0
if ($Inconsistent) {
  Write-Warning "$($Inconsistent.Count) inconsistent dependency versions were discovered."
  # Don't fail the build when inconsistent dependencies are present
  # TODO: Remove this ASAP
  #$ExitCode = 1
} else {
  Write-Host "All dependencies verified, no inconsistent dependency versions were discovered.')"
}

if ($MismatchedVersions -or $Unlocked) {
  if ($MismatchedVersions) {
    Write-Warning "$($MismatchedVersions.Count) dependency version overrides are present, causing dependency versions to differ from the version in CPM."
  }
  if ($Unlocked) {
    Write-Warning "$($Unlocked.Count) dependencies are missing from CPM."
  }
} else {
  Write-Host "All declared dependency versions match those specified in CPM."
}

if ($OutPath) {
  Write-Host "Generating HTML report..."
  $__template__ = Get-Content "$PSScriptRoot/deps.html.tpl" -Raw
  Invoke-Expression "@`"`r`n$__template__`r`n`"@" | Out-File -FilePath $OutPath
}

if ($DumpPath) {
  Write-Host "Generating JSONP data export..."
  $Internal = $Pkgs.Keys | ForEach-Object ToString
  $DumpData = Get-PackageExport $Pkgs $Internal
  Write-Host $DumpData
  $DumpDataJson = ConvertTo-Json -InputObject $DumpData -Compress -Depth 10
  Write-Host $DumpDataJson
  $DumpDataJson | Out-File -FilePath "${DumpPath}/arcdata.json"
  "const data = " + $DumpDataJson + ";" | Out-File -FilePath "${DumpPath}/data.js"
}

exit $ExitCode
