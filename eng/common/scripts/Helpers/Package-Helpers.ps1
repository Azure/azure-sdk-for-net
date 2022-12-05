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