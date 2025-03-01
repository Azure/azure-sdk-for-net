# cSpell:ignore PULLREQUEST
# cSpell:ignore TARGETBRANCH
[CmdletBinding()]
Param (
  [Parameter(Mandatory=$True)]
  [string] $ArtifactPath,
  [Parameter(Mandatory=$True)]
  [string] $PullRequestNumber,
  [Parameter(Mandatory=$True)]
  [string] $BuildId,
  [Parameter(Mandatory=$True)]
  [string] $CommitSha,
  [string] $APIViewUri,
  [string] $RepoFullName = "",
  [string] $ArtifactName = "packages",
  [string] $TargetBranch = ("origin/${env:SYSTEM_PULLREQUEST_TARGETBRANCH}" -replace "refs/heads/"),
  [string] $DevopsProject = "internal"
)

. (Join-Path $PSScriptRoot common.ps1)

$configFileDir = Join-Path -Path $ArtifactPath "PackageInfo"

# Submit API review request and return status whether current revision is approved or pending or failed to create review
function Submit-Request($filePath, $packageName)
{
    $repoName = $RepoFullName
    if (!$repoName) {
        $repoName = "azure/azure-sdk-for-$LanguageShort"
    }
    $reviewFileName = "$($packageName)_$($LanguageShort).json"
    $query = [System.Web.HttpUtility]::ParseQueryString('')
    $query.Add('artifactName', $ArtifactName)
    $query.Add('buildId', $BuildId)
    $query.Add('filePath', $filePath)
    $query.Add('commitSha', $CommitSha)
    $query.Add('repoName', $repoName)
    $query.Add('pullRequestNumber', $PullRequestNumber)
    $query.Add('packageName', $packageName)
    $query.Add('language', $LanguageShort)
    $query.Add('project', $DevopsProject)
    $reviewFileFullName = Join-Path -Path $ArtifactPath $packageName $reviewFileName
    if (Test-Path $reviewFileFullName)
    {
        $query.Add('codeFile', $reviewFileName)
    }
    $uri = [System.UriBuilder]$APIViewUri
    $uri.query = $query.toString()
    LogInfo "Request URI: $($uri.Uri.OriginalString)"
    try
    {
        $Response = Invoke-WebRequest -Method 'GET' -Uri $uri.Uri -MaximumRetryCount 3
        $StatusCode = $Response.StatusCode
    }
    catch
    {
        LogError "Error $StatusCode - Exception details: $($_.Exception.Response)"
        $StatusCode = $_.Exception.Response.StatusCode
    }

    return $StatusCode
}

function Should-Process-Package($pkgPath, $packageName)
{
    $pkg = Split-Path -Leaf $pkgPath
    $pkgPropPath = Join-Path -Path $configFileDir "$packageName.json"
    if (!(Test-Path $pkgPropPath))
    {
        LogWarning "Package property file path $($pkgPropPath) is invalid."
        return $False
    }
    # Get package info from json file created before updating version to daily dev
    $pkgInfo = Get-Content $pkgPropPath | ConvertFrom-Json
    $packagePath = $pkgInfo.DirectoryPath
    $modifiedFiles  = @(Get-ChangedFiles -DiffPath "$packagePath/*" -DiffFilterType '')
    $filteredFileCount = $modifiedFiles.Count
    LogInfo "Number of modified files for package: $filteredFileCount"
    return ($filteredFileCount -gt 0 -and $pkgInfo.IsNewSdk)
}

function Log-Input-Params()
{
    LogGroupStart "Input Parameters for $($ArtifactName)"
    LogInfo "Artifact Path: $($ArtifactPath)"
    LogInfo "Artifact Name: $($ArtifactName)"
    LogInfo "PullRequest Number: $($PullRequestNumber)"
    LogInfo "BuildId: $($BuildId)"
    LogInfo "Language: $($Language)"
    LogInfo "Commit SHA: $($CommitSha)"
    LogInfo "Repo Name: $($RepoFullName)"
    LogInfo "Project: $($DevopsProject)"
    LogGroupEnd
}

Log-Input-Params

if (!($FindArtifactForApiReviewFn -and (Test-Path "Function:$FindArtifactForApiReviewFn")))
{
    LogError "The function for 'FindArtifactForApiReviewFn' was not found.`
    Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
    See https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/common_engsys.md#code-structure"
    exit 1
}

$responses = @{}

LogInfo "Processing PackageInfo at $configFileDir"

$packageProperties = Get-ChildItem -Recurse -Force "$configFileDir" `
  | Where-Object { 
      $_.Extension -eq '.json' -and ($_.FullName.Substring($configFileDir.Length + 1) -notmatch '^_.*?[\\\/]')
    }

foreach ($packagePropFile in $packageProperties)
{
    $packageMetadata = Get-Content $packagePropFile | ConvertFrom-Json
    $pkgArtifactName = $packageMetadata.ArtifactName ?? $packageMetadata.Name

    LogInfo "Processing $($pkgArtifactName)"

    $packages = &$FindArtifactForApiReviewFn $ArtifactPath $pkgArtifactName

    if ($packages)
    {
        $pkgPath = $packages.Values[0]
        $isRequired = Should-Process-Package -pkgPath $pkgPath -packageName $pkgArtifactName
        LogInfo "Is API change detect required for $($pkgArtifactName):$($isRequired)"
        if ($isRequired -eq $True)
        {
            $filePath = $pkgPath.Replace($ArtifactPath , "").Replace("\", "/")
            $respCode = Submit-Request -filePath $filePath -packageName $pkgArtifactName
            if ($respCode -ne '200')
            {
                $responses[$pkgArtifactName] = $respCode
            }
        }
        else
        {
            LogInfo "Pull request does not have any change for $($pkgArtifactName)). Skipping API change detect."
        }
    }
    else
    {
        LogInfo "No package is found in artifact path to find API changes for $($pkgArtifactName)"
    }
}

foreach($pkg in $responses.keys)
{
    LogInfo "API detection request status for $($pkg) : $($responses[$pkg])"
}
