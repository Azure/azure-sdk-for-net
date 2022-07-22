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
  [Parameter(Mandatory=$True)]
  [array] $ArtifactList,
  [string] $APIViewUri,
  [string] $RepoFullName = "",
  [string] $ArtifactName = "packages",
  [string] $TargetBranch = ("origin/${env:SYSTEM_PULLREQUEST_TARGETBRANCH}" -replace "refs/heads/")
)

Set-StrictMode -version 3
. (Join-Path $PSScriptRoot common.ps1)

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
    $reviewFileFullName = Join-Path -Path $ArtifactPath $packageName $reviewFileName
    if (Test-Path $reviewFileFullName)
    {
        $query.Add('codeFile', $reviewFileName)
    }
    $uri = [System.UriBuilder]$APIViewUri
    $uri.query = $query.toString()
    Write-Host "Request URI: $($uri.Uri.OriginalString)"
    try
    {
        $Response = Invoke-WebRequest -Method 'GET' -Uri $uri.Uri -MaximumRetryCount 3
        $StatusCode = $Response.StatusCode
    }
    catch
    {
        Write-Host "Error $StatusCode - Exception details: $($_.Exception.Response)"
        $StatusCode = $_.Exception.Response.StatusCode
    }

    return $StatusCode
}

function Should-Process-Package($pkgPath, $packageName)
{
    $pkg = Split-Path -Leaf $pkgPath
    $configFileDir = Join-Path -Path $ArtifactPath "PackageInfo"
    $pkgPropPath = Join-Path -Path $configFileDir "$packageName.json"
    if (!(Test-Path $pkgPropPath))
    {
        Write-Host " Package property file path $($pkgPropPath) is invalid."
        return $False
    }
    # Get package info from json file created before updating version to daily dev
    $pkgInfo = Get-Content $pkgPropPath | ConvertFrom-Json
    $packagePath = $pkgInfo.DirectoryPath
    $modifiedFiles  = Get-ChangedFiles -DiffPath "$packagePath/*" -DiffFilterType ''
    $filteredFileCount = $modifiedFiles.Count
    Write-Host "Number of modified files for package: $filteredFileCount"
    return ($filteredFileCount -gt 0 -and $pkgInfo.IsNewSdk)
}

function Log-Input-Params()
{
    Write-Host "Artifact Path: $($ArtifactPath)"
    Write-Host "Artifact Name: $($ArtifactName)"
    Write-Host "PullRequest Number: $($PullRequestNumber)"
    Write-Host "BuildId: $($BuildId)"
    Write-Host "Language: $($Language)"
    Write-Host "Commit SHA: $($CommitSha)"
    Write-Host "Repo Name: $($RepoFullName)"
    Write-Host "Package Name: $($PackageName)"
}

Log-Input-Params

if (!($FindArtifactForApiReviewFn -and (Test-Path "Function:$FindArtifactForApiReviewFn")))
{
    Write-Host "The function for 'FindArtifactForApiReviewFn' was not found.`
    Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
    See https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/common_engsys.md#code-structure"
    exit 1
}

$responses = @{}
foreach ($artifact in $ArtifactList)
{
    Write-Host "Processing $($artifact.name)"
    $packages = &$FindArtifactForApiReviewFn $ArtifactPath $artifact.name
    if ($packages)
    {
        $pkgPath = $packages.Values[0]
        $isRequired = Should-Process-Package -pkgPath $pkgPath -packageName $artifact.name
        Write-Host "Is API change detect required for $($artifact.name):$($isRequired)"
        if ($isRequired -eq $True)
        {
            $filePath = $pkgPath.Replace($ArtifactPath , "").Replace("\", "/")
            $respCode = Submit-Request -filePath $filePath -packageName $artifact.name
            if ($respCode -ne '200')
            {
                $responses[$artifact.name] = $respCode
            }
        }
        else
        {
            Write-Host "Pull request does not have any change for $($artifact.name). Skipping API change detect."
        }
    }
    else
    {
        Write-Host "No package is found in artifact path to find API changes for $($artifact.name)"
    }
}

foreach($pkg in $responses.keys)
{
    Write-Host "API detection request status for $($pkg) : $($responses[$pkg])"
}
