param(
  [string]$PSDepsFile,
  [string]$AzSdkDepsFile
)

function Get-DepsFileContent($depsfile)
{
  if ($depsfile.StartsWith("http")) {
    try {
      $response = Invoke-WebRequest -Uri $depsfile
      $content = $response.Content
    }
    catch {
      $statusCode = $_.Exception.Response.StatusCode.value__
      Write-Error "Failed to download deps file [$statusCode] $depsfile"
      exit 1
    }
  }
  elseif (Test-Path $depsFile) {
    $content = Get-Content $depsFile
  }
  else {
    Write-Error "File $depsFile does not exists"
    exit 1
  }
  return $content
}

function Get-Assemblies($target)
{
  $assemblies = @{}
  foreach($key in $target.Keys)
  {
    $runtime = $target[$key].runtime

    if ($runtime)
    {
      foreach($assembly in $runtime.Keys)
      {
        if ($assembly -match "(?<name>[^\\/]*)\.dll") 
        {
          $name = $matches["name"]
          [Version]$version = $runtime[$assembly].assemblyVersion
          Write-Verbose "Assembly $name with version $version"
          $assemblies[$name] = $version
        }
      }
    }
  }
  return $assemblies
}

$psDeps = Get-DepsFileContent $PSDepsFile | ConvertFrom-Json -AsHashtable
$azDeps = Get-DepsFileContent $AzSdkDepsFile | ConvertFrom-Json -AsHashtable

$psTargets = @{}
$psDeps.targets.GetEnumerator() | ForEach-Object { $psTargets += $_.Value }
$psDepsVersion = Get-Assemblies $psTargets
if ($psDepsVersion.Count -eq 0) {
  Write-Error "Didn't find any assemblies in $PSDepsFile"
  exit 1
}

$azTargets = @{}
$azDeps.targets.GetEnumerator() | ForEach-Object { $azTargets += $_.Value }
$azDepsVersions = Get-Assemblies $azTargets
if ($azDepsVersions.Count -eq 0) {
  Write-Error "Didn't find any assemblies in $AzSdkDepsFile"
  exit 1
}

$incompatableCount = 0
foreach ($key in $azDepsVersions.Keys)
{
  if ($psDepsVersion.Contains($key)) {
    [Version]$psVer = $psDepsVersion[$key]
    [Version]$azVer = $azDepsVersions[$key]

    Write-Verbose "[$key] PSDepsFile has version [$psVer] and AzSdkDepsFile has version [$azVer]"

    if ($azVer -gt $psVer) {
      Write-Warning "For [$key] AzureSDK requires higher version [$azVer] then what PS has [$psVer]"
      $incompatableCount++
    }
  }
}
exit $incompatableCount

