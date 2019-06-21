$InputDir = "/Users/brsiegel/Downloads/packages"
$Packages = @{ }
$Deps = @{ }

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
  $Deps[$DepName][$TargetFramework][$DepVersion].Add($DependentPackage) | Out-Null
}

$PackageFiles = Join-Path $InputDir "*.nupkg" -Resolve
foreach ($PkgFile in $PackageFiles) {
  Write-Host "File $PkgFile"
  $Nuspec = Get-Nuspec $PkgFile
  $LibraryName = $Nuspec.package.metadata.id
  $LibraryVer = $Nuspec.package.metadata.version

  $Packages[$LibraryName] = @($LibraryVer, $PkgFile)

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
    } else {
      Save-Dep $Deps "(any)" $Dep.id $Dep.version $LibraryName
    }
  }
}

$External = $Deps.Keys | where { -not ($Packages.ContainsKey($_)) }
$Inconsistent = @{ }
foreach ($DepName in $Deps.Keys) {
  $InconsistentFrameworks = $Deps[$DepName].Keys | where { $Deps[$DepName][$_].Count -gt 1 }
  if ($InconsistentFrameworks) {
    $Inconsistent[$DepName] = $InconsistentFrameworks
  }  
}

$__template__ = Get-Content 'deps.html.tpl' -Raw
Invoke-Expression "@`"`r`n$__template__`r`n`"@" | Out-File -FilePath .\deps.html
