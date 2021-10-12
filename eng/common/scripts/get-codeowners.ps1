param (
  $TargetDirectory, # should be in relative form from root of repo. EG: sdk/servicebus
  $RootDirectory, # ideally $(Build.SourcesDirectory)
  $AuthToken,
  $VsoOwningUsers = "",
  $VsoOwningTeams = "",
  $VsoOwningLabels = ""
)

. (Join-Path ${PSScriptRoot} logging.ps1)

$target = $TargetDirectory.ToLower().Trim("/")
$codeOwnersLocation = Join-Path $RootDirectory -ChildPath ".github/CODEOWNERS"
$ownedFolders = @{}

if (!(Test-Path $codeOwnersLocation)) {
  LogWarning "Unable to find CODEOWNERS file in target directory $RootDirectory"
  exit 1
}

function VerifyAlias($APIUrl)
{
  if ($AuthToken) 
  {
    $headers = @{
      Authorization = "bearer $AuthToken"
    }
  }
  try
  {
    $response = Invoke-RestMethod -Headers $headers $APIUrl
  }
  catch 
  {
    LogDebug "Invoke-RestMethod ${APIUrl} failed with exception:`n$_"
    LogDebug "This might be because a team alias was used for user API request or vice versa."
    return $false
  }
  return $true
}

nuget install "CodeOwnersParser" -OutputDirectory . `
  -Source "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json" `
  -Prerelease -DirectDownload

$codeOwnersParserDll = (Get-ChildItem -Path "CodeOwnersParser*" -Filter "CodeOwnersParser.dll" -Recurse).FullName
Add-Type -LiteralPath $codeOwnersParserDll
$parsedEntries = [CodeOwnersParser.CodeOwnersFile]::ParseFile($codeOwnersLocation);
$filteredEntries = $parsedEntries.Where({$_.PathExpression.Trim("/\\") -eq $TargetDirectory.Trim("/\\")});

if ($filteredEntries) {
  Write-Host "Found a folder to match $target"

  $users = @()
  $teams = @()
  $labels = @()

  foreach($entry in $filteredEntries)
  {
    foreach($alias in $entry.Owners)
    {
      if ($alias.IndexOf('/') -ne -1) # Check if it's a team alias e.g. Azure/azure-sdk-eng
      {
        $org = $str.substring(0, $str.IndexOf('/'))
        $team_slug = $str.substring($str.IndexOf('/') + 1)
        $teamApiUrl =  "https://api.github.com/orgs/$org/teams/$team_slug"
        if (VerifyAlias -APIUrl $teamApiUrl)
        {
          $teams += $team_slug
          continue
        }
      }
      else
      {
        $usersApiUrl = "https://api.github.com/users/$alias"
        if (VerifyAlias -APIUrl $usersApiUrl)
        {
          $users += $str
          continue
        }
      }
      LogWarning "Alias ${str} is neither a recognized github user nor a team"
    }
    $labels += $entry.PRLabels
    $labels += $entry.ServiceLabels
  }

  if ($VsoOwningUsers) {
    $presentOwningUsers = [System.Environment]::GetEnvironmentVariable($VsoOwningUsers)
    if ($presentOwningUsers) { 
      $users += $presentOwningUsers
    }
    Write-Host "##vso[task.setvariable variable=$VsoOwningUsers;]{0}" -F ($users -join ',')
  }

  if ($VsoOwningTeams) {
    $presentOwningTeams  = [System.Environment]::GetEnvironmentVariable($VsoOwningTeams)

    if ($presentOwningTeams) { 
      $teams += $presentOwningTeams
    }
    Write-Host "##vso[task.setvariable variable=$VsoOwningTeams;]{0}" -F ($teams -join ',')
  }

  if ($VsoOwningLabels) {
    $presentOwningLabels = [System.Environment]::GetEnvironmentVariable($VsoOwningLabels)
    if ($presentOwningLabels) {
      $labels += $presentOwningLabels
    }
    Write-Host "##vso[task.setvariable variable=$VsoOwningLabels;]{0}" -F ($labels -join ',')
  }

  return $results
}
else {
  Write-Host "Unable to match path $target in CODEOWNERS file located at $codeOwnersLocation."
  Write-Host ($ownedFolders | ConvertTo-Json)
  return ""
}