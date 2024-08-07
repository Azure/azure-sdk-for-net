[CmdletBinding()]
Param (
  [Parameter(Mandatory=$True)]
  [array] $ArtifactList,
  [Parameter(Mandatory=$True)]
  [string] $ArtifactPath,  
  [Parameter(Mandatory=$True)]
  [string] $APIKey,  
  [string] $SourceBranch,
  [string] $DefaultBranch,
  [string] $RepoName,
  [string] $BuildId,
  [string] $PackageName = "",
  [string] $ConfigFileDir = "",
  [string] $APIViewUri = "https://apiview.dev/AutoReview",
  [string] $ArtifactName = "packages",
  [bool] $MarkPackageAsShipped = $false
)

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)
. (Join-Path $PSScriptRoot Helpers ApiView-Helpers.ps1)

# Submit API review request and return status whether current revision is approved or pending or failed to create review
function Upload-SourceArtifact($filePath, $apiLabel, $releaseStatus, $packageVersion)
{
    Write-Host "File path: $filePath"
    $fileName = Split-Path -Leaf $filePath
    Write-Host "File name: $fileName"
    $multipartContent = [System.Net.Http.MultipartFormDataContent]::new()
    $FileStream = [System.IO.FileStream]::new($filePath, [System.IO.FileMode]::Open)
    $fileHeader = [System.Net.Http.Headers.ContentDispositionHeaderValue]::new("form-data")
    $fileHeader.Name = "file"
    $fileHeader.FileName = $fileName
    $fileContent = [System.Net.Http.StreamContent]::new($FileStream)
    $fileContent.Headers.ContentDisposition = $fileHeader
    $fileContent.Headers.ContentType = [System.Net.Http.Headers.MediaTypeHeaderValue]::Parse("application/octet-stream")
    $multipartContent.Add($fileContent)


    $stringHeader = [System.Net.Http.Headers.ContentDispositionHeaderValue]::new("form-data")
    $stringHeader.Name = "label"
    $StringContent = [System.Net.Http.StringContent]::new($apiLabel)
    $StringContent.Headers.ContentDisposition = $stringHeader
    $multipartContent.Add($stringContent)
    Write-Host "Request param, label: $apiLabel"

    $versionParam = [System.Net.Http.Headers.ContentDispositionHeaderValue]::new("form-data")
    $versionParam.Name = "packageVersion"
    $versionContent = [System.Net.Http.StringContent]::new($packageVersion)
    $versionContent.Headers.ContentDisposition = $versionParam
    $multipartContent.Add($versionContent)
    Write-Host "Request param, packageVersion: $packageVersion"
    
    $releaseTagParam = [System.Net.Http.Headers.ContentDispositionHeaderValue]::new("form-data")
    $releaseTagParam.Name = "setReleaseTag"
    $releaseTagParamContent = [System.Net.Http.StringContent]::new($MarkPackageAsShipped)
    $releaseTagParamContent.Headers.ContentDisposition = $releaseTagParam
    $multipartContent.Add($releaseTagParamContent)
    Write-Host "Request param, setReleaseTag: $MarkPackageAsShipped"

    if ($releaseStatus -and ($releaseStatus -ne "Unreleased"))
    {
        $compareAllParam = [System.Net.Http.Headers.ContentDispositionHeaderValue]::new("form-data")
        $compareAllParam.Name = "compareAllRevisions"
        $compareAllParamContent = [System.Net.Http.StringContent]::new($true)
        $compareAllParamContent.Headers.ContentDisposition = $compareAllParam
        $multipartContent.Add($compareAllParamContent)
        Write-Host "Request param, compareAllRevisions: true"
    }

    $uri = "${APIViewUri}/UploadAutoReview"
    $headers = @{
        "ApiKey" = $apiKey;
        "content-type" = "multipart/form-data"
    }

    try
    {
        $Response = Invoke-WebRequest -Method 'POST' -Uri $uri -Body $multipartContent -Headers $headers
        Write-Host "API review: $($Response.Content)"
        $StatusCode = $Response.StatusCode
    }
    catch
    {
        Write-Host "Exception details: $($_.Exception.Response)"
        $StatusCode = $_.Exception.Response.StatusCode
    }

    return $StatusCode
}

function Upload-ReviewTokenFile($packageName, $apiLabel, $releaseStatus, $reviewFileName, $packageVersion, $filePath)
{
    Write-Host "Original File path: $filePath"
    $fileName = Split-Path -Leaf $filePath
    Write-Host "OriginalFile name: $fileName"

    $params = "buildId=${BuildId}&artifactName=${ArtifactName}&originalFilePath=${fileName}&reviewFilePath=${reviewFileName}"    
    $params += "&label=${apiLabel}&repoName=${RepoName}&packageName=${packageName}&project=internal&packageVersion=${packageVersion}"
    if($MarkPackageAsShipped) {
        $params += "&setReleaseTag=true"
    }
    $uri = "${APIViewUri}/CreateApiReview?${params}"
    if ($releaseStatus -and ($releaseStatus -ne "Unreleased"))
    {
        $uri += "&compareAllRevisions=true"
    }

    Write-Host "Request to APIView: $uri"
    $headers = @{
        "ApiKey" = $APIKey;
    }

    try
    {
        $Response = Invoke-WebRequest -Method 'GET' -Uri $uri -Headers $headers
        Write-Host "API review: $($Response.Content)"
        $StatusCode = $Response.StatusCode
    }
    catch
    {
        Write-Host "Exception details: $($_.Exception)"
        $StatusCode = $_.Exception.Response.StatusCode
    }

    return $StatusCode
}

function Get-APITokenFileName($packageName)
{
    $reviewTokenFileName = "${packageName}_${LanguageShort}.json"
    $tokenFilePath = Join-Path $ArtifactPath $packageName $reviewTokenFileName
    if (Test-Path $tokenFilePath) {
        Write-Host "Review token file is present at $tokenFilePath"
        return $reviewTokenFileName
    }
    else {
        Write-Host "Review token file is not present at $tokenFilePath"
        return $null
    }
}

function Submit-APIReview($packageInfo, $packagePath, $packageArtifactName)
{
    $packageName = $packageInfo.Name    
    $apiLabel = "Source Branch:${SourceBranch}"

    # Get generated review token file if present
    # APIView processes request using different API if token file is already generated
    $reviewTokenFileName =  Get-APITokenFileName $packageArtifactName
    if ($reviewTokenFileName) {
        Write-Host "Uploading review token file $reviewTokenFileName to APIView."
        return Upload-ReviewTokenFile $packageArtifactName $apiLabel $packageInfo.ReleaseStatus $reviewTokenFileName $packageInfo.Version $packagePath
    }
    else {
        Write-Host "Uploading $packagePath to APIView."
        return Upload-SourceArtifact $packagePath $apiLabel $packageInfo.ReleaseStatus $packageInfo.Version
    }
}

function IsApiviewStatusCheckRequired($packageInfo)
{
    if ($IsApiviewStatusCheckRequiredFn -and (Test-Path "Function:$IsApiviewStatusCheckRequiredFn"))
    {
        return &$IsApiviewStatusCheckRequiredFn $packageInfo
    }

    if ($packageInfo.SdkType -eq "client" -and $packageInfo.IsNewSdk) {
        return $true
    }
    return $false
}

function ProcessPackage($packageName)
{
    $packages = @{}
    if ($FindArtifactForApiReviewFn -and (Test-Path "Function:$FindArtifactForApiReviewFn"))
    {
        $packages = &$FindArtifactForApiReviewFn $ArtifactPath $packageName
    }
    else
    {
        Write-Host "The function for 'FindArtifactForApiReviewFn' was not found.`
        Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
        See https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/common_engsys.md#code-structure"
        return 1
    }

    if ($packages)
    {
        foreach($pkgPath in $packages.Values)
        {
            $pkg = Split-Path -Leaf $pkgPath
            $pkgPropPath = Join-Path -Path $ConfigFileDir "$packageName.json"
            if (-Not (Test-Path $pkgPropPath))
            {
                Write-Host " Package property file path $($pkgPropPath) is invalid."
                continue
            }
            # Get package info from json file created before updating version to daily dev
            $pkgInfo = Get-Content $pkgPropPath | ConvertFrom-Json
            $version = [AzureEngSemanticVersion]::ParseVersionString($pkgInfo.Version)
            if ($version -eq $null)
            {
                Write-Host "Version info is not available for package $packageName, because version '$(pkgInfo.Version)' is invalid. Please check if the version follows Azure SDK package versioning guidelines."
                return 1
            }
            
            Write-Host "Version: $($version)"
            Write-Host "SDK Type: $($pkgInfo.SdkType)"
            Write-Host "Release Status: $($pkgInfo.ReleaseStatus)"

            # Run create review step only if build is triggered from main branch or if version is GA.
            # This is to avoid invalidating review status by a build triggered from feature branch
            if ( ($SourceBranch -eq $DefaultBranch) -or (-not $version.IsPrerelease) -or $MarkPackageAsShipped)
            {
                Write-Host "Submitting API Review request for package $($pkg), File path: $($pkgPath)"
                $respCode = Submit-APIReview $pkgInfo $pkgPath $packageName
                Write-Host "HTTP Response code: $($respCode)"

                # no need to check API review status when marking a package as shipped
                if ($MarkPackageAsShipped)
                {
                    if ($respCode -eq '500')
                    {
                        Write-Host "Failed to mark package ${packageName} as released. Please reach out to Azure SDK engineering systems on teams channel."   
                        return 1
                    }
                    Write-Host "Package ${packageName} is marked as released."   
                    return 0
                }

                $apiStatus = [PSCustomObject]@{
                    IsApproved = $false
                    Details = ""
                }
                $pkgNameStatus = [PSCustomObject]@{
                    IsApproved = $false
                    Details = ""
                }
                Process-ReviewStatusCode $respCode $packageName $apiStatus $pkgNameStatus

                if ($apiStatus.IsApproved) {
                    Write-Host "API status: $($apiStatus.Details)"
                }
                elseif (!$pkgInfo.ReleaseStatus -or $pkgInfo.ReleaseStatus -eq "Unreleased") {
                    Write-Host "Release date is not set for current version in change log file for package. Ignoring API review approval status since package is not yet ready for release."
                }
                elseif ($version.IsPrerelease)
                {
                    # Check if package name is approved. Preview version cannot be released without package name approval
                    if (!$pkgNameStatus.IsApproved) 
                    {
                        if (IsApiviewStatusCheckRequired $pkgInfo)
                        {
                            Write-Error $($pkgNameStatus.Details)
                            return 1
                        }
                        else{
                            Write-Host "Package name is not approved for package $($packageName), however it is not required for this package type so it can still be released without API review approval."
                        }                        
                    }
                    # Ignore API review status for prerelease version
                    Write-Host "Package version is not GA. Ignoring API view approval status"
                }                
                else
                {
                    # Return error code if status code is 201 for new data plane package
                    # Temporarily enable API review for spring SDK types. Ideally this should be done be using 'IsReviewRequired' method in language side
                    # to override default check of SDK type client
                    if (IsApiviewStatusCheckRequired $pkgInfo)
                    {
                        if (!$apiStatus.IsApproved)
                        {
                            Write-Host "Package version $($version) is GA and automatic API Review is not yet approved for package $($packageName)."
                            Write-Host "Build and release is not allowed for GA package without API review approval."
                            Write-Host "You will need to queue another build to proceed further after API review is approved"
                            Write-Host "You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
                        }
                        return 1
                    }
                    else {
                        Write-Host "API review is not approved for package $($packageName), however it is not required for this package type so it can still be released without API review approval."
                    }
                }
            }
            else {
                Write-Host "Build is triggered from $($SourceBranch) with prerelease version. Skipping API review status check."
            }
        }
    }
    else {
        Write-Host "No package is found in artifact path to submit review request"
    }
    return 0
}

$responses = @{}
# Check if package config file is present. This file has package version, SDK type etc info.
if (-not $ConfigFileDir)
{
    $ConfigFileDir = Join-Path -Path $ArtifactPath "PackageInfo"
}

Write-Host "Artifact path: $($ArtifactPath)"
Write-Host "Source branch: $($SourceBranch)"
Write-Host "Config File directory: $($ConfigFileDir)"

# if package name param is not empty then process only that package
if ($PackageName)
{
    Write-Host "Processing $($PackageName)"
    $result = ProcessPackage -packageName $PackageName
    $responses[$PackageName] = $result 
}
else
{
    # process all packages in the artifact
    foreach ($artifact in $ArtifactList)
    {
        Write-Host "Processing $($artifact.name)"
        $result = ProcessPackage -packageName $artifact.name
        $responses[$artifact.name] = $result
    }
}

$exitCode = 0
foreach($pkg in $responses.keys)
{    
    if ($responses[$pkg] -eq 1)
    {
        Write-Host "API changes are not approved for $($pkg)"
        $exitCode = 1
    }
}
exit $exitCode