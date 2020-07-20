param (
  $TargetDirectory, # should be in relative form from root of repo. EG: sdk/servicebus
  $RootDirectory # ideally $(Build.SourcesDirectory)
)

$codeOwnersLocation = Join-Path $RootDirectory -ChildPath ".github/CODEOWNERS"

if (!(Test-Path $codeOwnersLocation)) {
  Write-Host "Unable to find CODEOWNERS file in target directory $RootDirectory"
  exit 1
}

$codeOwnersContent = Get-Content $codeOwnersLocation

$ownedFolders = @{}

foreach ($contentLine in $codeOwnersContent) {
  if (-not $contentLine.StartsWith("#") -and $contentLine){
    $splitLine = $contentLine -split "\s+"
    
    # CODEOWNERS file can also have labels present after the owner aliases
    # gh aliases start with @ in codeowners. don't pass on to API calls
    $ownedFolders[$splitLine[0].ToLower()] = ($splitLine[1..$($splitLine.Length)] `
      | ? { $_.StartsWith("@") } `
      | % { return $_.substring(1) }) -join ","
  }
}

$results = $ownedFolders[$TargetDirectory.ToLower()]

if ($results) {
  Write-Host "Discovered code owners for path $TargetDirectory are $results."
  return $results
}
else {
  Write-Host "Unable to match path $TargetDirectory in CODEOWNERS file located at $codeOwnersLocation."
  Write-Host $ownedFolders | ConvertTo-Json
  return ""
}

