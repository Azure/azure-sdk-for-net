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
    # If CI generates token file then it passes both token file name and original file (filePath) to APIView
    # If both files are passed then APIView downloads the parent directory as a zip
    # If code file is not passed(for e.g. .NET or Java) then APIView needs full path to original file to download only that file.
    if (Test-Path $reviewFileFullName)
    {
        $query.Add('codeFile', $reviewFileName)
        # Pass only relative path in package artifact directory when code file is also present
        $query.Add('filePath', (Split-Path -Leaf $filePath))
    }
    else
    {
        $query.Add('filePath', $filePath)
    }
    $uri = [System.UriBuilder]$APIViewUri
    $uri.query = $query.toString()

    $correlationId = [System.Guid]::NewGuid().ToString()
    $headers = @{
      "x-correlation-id" = $correlationId
    }
    LogInfo "Request URI: $($uri.Uri.OriginalString)"
    LogInfo "Correlation ID: $correlationId"
    try
    {
        $Response = Invoke-WebRequest -Method 'GET' -Uri $uri.Uri -Headers $headers -MaximumRetryCount 3
        $StatusCode = $Response.StatusCode
        if ($Response.Headers['Content-Type'] -like 'application/json*') {
            $responseContent = $Response.Content | ConvertFrom-Json | ConvertTo-Json -Depth 10
            LogSuccess $responseContent
        }
    }
    catch
    {
        LogError "Error $StatusCode - Exception details: $($_.Exception.Response)"
        $StatusCode = $_.Exception.Response.StatusCode
    }

    return $StatusCode
}

function Should-Process-Package($packageInfo)
{
    $packagePath = $packageInfo.DirectoryPath
    $modifiedFiles  = @(Get-ChangedFiles -DiffPath "$packagePath/*" -DiffFilterType '')
    $filteredFileCount = $modifiedFiles.Count
    LogInfo "Number of modified files for package: $filteredFileCount"
    return ($filteredFileCount -gt 0 -and $packageInfo.IsNewSdk)
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

$packageInfoFiles = Get-ChildItem -Recurse -Force "$configFileDir" `
  | Where-Object {
      $_.Extension -eq '.json' -and ($_.FullName.Substring($configFileDir.Length + 1) -notmatch '^_.*?[\\\/]')
    }

foreach ($packageInfoFile in $packageInfoFiles)
{
    $packageInfo = Get-Content $packageInfoFile | ConvertFrom-Json
    $pkgArtifactName = $packageInfo.ArtifactName ?? $packageInfo.Name

    LogInfo "Processing $($pkgArtifactName)"

    # Check if the function supports the packageInfo parameter
    $functionInfo = Get-Command $FindArtifactForApiReviewFn -ErrorAction SilentlyContinue
    $supportsPackageInfoParam = $false
    
    if ($functionInfo -and $functionInfo.Parameters) {
        # Check if function specifically supports packageInfo parameter
        $parameterNames = $functionInfo.Parameters.Keys
        $supportsPackageInfoParam = $parameterNames -contains 'packageInfo'
    }
    
    # Call function with appropriate parameters
    if ($supportsPackageInfoParam) {
        LogInfo "Calling $FindArtifactForApiReviewFn with packageInfo parameter"
        $packages = &$FindArtifactForApiReviewFn $ArtifactPath $packageInfo
    }
    else {
        LogInfo "Calling $FindArtifactForApiReviewFn with legacy parameters"
        $packages = &$FindArtifactForApiReviewFn $ArtifactPath $pkgArtifactName
    }

    if ($packages)
    {
        $pkgPath = $packages.Values[0]
        $isRequired = Should-Process-Package $packageInfo
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
            LogInfo "Pull request does not have any change for $($pkgArtifactName). Skipping API change detect."
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
