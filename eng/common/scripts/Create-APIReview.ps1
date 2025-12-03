[CmdletBinding()]
Param (
  [Parameter(Mandatory=$False)]
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
  [bool] $MarkPackageAsShipped = $false,
  [Parameter(Mandatory=$False)]
  [array] $PackageInfoFiles
)

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)
. (Join-Path $PSScriptRoot Helpers ApiView-Helpers.ps1)

# Submit API review request and return status whether current revision is approved or pending or failed to create review
function Upload-SourceArtifact($filePath, $apiLabel, $releaseStatus, $packageVersion, $packageType)
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

    $packageTypeParam = [System.Net.Http.Headers.ContentDispositionHeaderValue]::new("form-data")
    $packageTypeParam.Name = "packageType"
    $packageTypeParamContent = [System.Net.Http.StringContent]::new($packageType)
    $packageTypeParamContent.Headers.ContentDisposition = $packageTypeParam
    $multipartContent.Add($packageTypeParamContent)
    Write-Host "Request param, packageType: $packageType"

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

function Upload-ReviewTokenFile($packageName, $apiLabel, $releaseStatus, $reviewFileName, $packageVersion, $filePath, $packageType)
{
    Write-Host "Original File path: $filePath"
    $fileName = Split-Path -Leaf $filePath
    Write-Host "OriginalFile name: $fileName"

    $params = "buildId=${BuildId}&artifactName=${ArtifactName}&originalFilePath=${fileName}&reviewFilePath=${reviewFileName}"
    $params +="&label=${apiLabel}&repoName=${RepoName}&packageName=${packageName}&project=internal&packageVersion=${packageVersion}&packageType=${packageType}"
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

function Submit-APIReview($packageInfo, $packagePath)
{
    $apiLabel = "Source Branch:${SourceBranch}"
    $packageType = $packageInfo.SdkType

    # Get generated review token file if present
    # APIView processes request using different API if token file is already generated
    $reviewTokenFileName =  Get-APITokenFileName $packageInfo.ArtifactName
    if ($reviewTokenFileName) {
        Write-Host "Uploading review token file $reviewTokenFileName to APIView."
        return Upload-ReviewTokenFile $packageInfo.ArtifactName $apiLabel $packageInfo.ReleaseStatus $reviewTokenFileName $packageInfo.Version $packagePath $packageType
    }
    else {
        Write-Host "Uploading $packagePath to APIView."
        return Upload-SourceArtifact $packagePath $apiLabel $packageInfo.ReleaseStatus $packageInfo.Version $packageType
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

function ProcessPackage($packageInfo)
{
    $packages = @{}
    if ($FindArtifactForApiReviewFn -and (Test-Path "Function:$FindArtifactForApiReviewFn"))
    {
        $pkgArtifactName = $packageInfo.ArtifactName ?? $packageInfo.Name

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
            $version = [AzureEngSemanticVersion]::ParseVersionString($packageInfo.Version)
            if ($null -eq $version)
            {
                Write-Host "Version info is not available for package $($packageInfo.ArtifactName), because version '$($packageInfo.Version)' is invalid. Please check if the version follows Azure SDK package versioning guidelines."
                return 1
            }

            Write-Host "Version: $($version)"
            Write-Host "SDK Type: $($packageInfo.SdkType)"
            Write-Host "Release Status: $($packageInfo.ReleaseStatus)"

            # Run create review step only if build is triggered from main branch or if version is GA.
            # This is to avoid invalidating review status by a build triggered from feature branch
            if ( ($SourceBranch -eq $DefaultBranch) -or (-not $version.IsPrerelease) -or $MarkPackageAsShipped)
            {
                Write-Host "Submitting API Review request for package $($pkg), File path: $($pkgPath)"
                $respCode = Submit-APIReview $packageInfo $pkgPath
                Write-Host "HTTP Response code: $($respCode)"

                # no need to check API review status when marking a package as shipped
                if ($MarkPackageAsShipped)
                {
                    if ($respCode -eq '500')
                    {
                        Write-Host "Failed to mark package $($packageInfo.ArtifactName) as released. Please reach out to Azure SDK engineering systems on teams channel."
                        return 1
                    }
                    Write-Host "Package $($packageInfo.ArtifactName) is marked as released."
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
                Process-ReviewStatusCode $respCode $packageInfo.ArtifactName $apiStatus $pkgNameStatus

                if ($apiStatus.IsApproved) {
                    Write-Host "API status: $($apiStatus.Details)"
                }
                elseif (!$packageInfo.ReleaseStatus -or $packageInfo.ReleaseStatus -eq "Unreleased") {
                    Write-Host "Release date is not set for current version in change log file for package. Ignoring API review approval status since package is not yet ready for release."
                }
                elseif ($version.IsPrerelease)
                {
                    # Check if package name is approved. Preview version cannot be released without package name approval
                    if (!$pkgNameStatus.IsApproved)
                    {
                        if (IsApiviewStatusCheckRequired $packageInfo)
                        {
                            Write-Error $($pkgNameStatus.Details)
                            return 1
                        }
                        else{
                            Write-Host "Package name is not approved for package $($packageInfo.ArtifactName), however it is not required for this package type so it can still be released without API review approval."
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
                    if (IsApiviewStatusCheckRequired $packageInfo)
                    {
                        if (!$apiStatus.IsApproved)
                        {
                            Write-Host "Package version $($version) is GA and automatic API Review is not yet approved for package $($packageInfo.ArtifactName)."
                            Write-Host "Build and release is not allowed for GA package without API review approval."
                            Write-Host "You will need to queue another build to proceed further after API review is approved"
                            Write-Host "You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
                        }
                        return 1
                    }
                    else {
                        Write-Host "API review is not approved for package $($packageInfo.ArtifactName), however it is not required for this package type so it can still be released without API review approval."
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

Write-Host "Artifact path: $($ArtifactPath)"
Write-Host "Source branch: $($SourceBranch)"
Write-Host "Package Info Files: $($PackageInfoFiles)"
Write-Host "Artifact List: $($ArtifactList)"
Write-Host "Package Name: $($PackageName)"

# Parameter priority and backward compatibility logic
# Priority order: PackageName > Artifacts > PackageInfoFiles (for backward compatibility)

if (-not $ConfigFileDir) {
    $ConfigFileDir = Join-Path -Path $ArtifactPath "PackageInfo"
}

Write-Host "Config File directory: $($ConfigFileDir)"

# Initialize working variable
$ProcessedPackageInfoFiles = @()

if ($PackageName -and $PackageName -ne "") {
    # Highest Priority: Single package mode (existing usage)
    Write-Host "Using PackageName parameter: $PackageName"
    $pkgPropPath = Join-Path -Path $ConfigFileDir "$PackageName.json"
    if (Test-Path $pkgPropPath) {
        $ProcessedPackageInfoFiles = @($pkgPropPath)
    }
    else {
        Write-Error "Package property file path $pkgPropPath is invalid."
        exit 1
    }
}
elseif ($ArtifactList -and $ArtifactList.Count -gt 0) {
    # Second Priority: Multiple artifacts mode (existing usage)
    Write-Host "Using ArtifactList parameter with $($ArtifactList.Count) artifacts"
    foreach ($artifact in $ArtifactList) {
        $pkgPropPath = Join-Path -Path $ConfigFileDir "$($artifact.name).json"
        if (Test-Path $pkgPropPath) {
            $ProcessedPackageInfoFiles += $pkgPropPath
        }
        else {
            Write-Warning "Package property file path $pkgPropPath is invalid."
        }
    }
}
elseif ($PackageInfoFiles -and $PackageInfoFiles.Count -gt 0) {
    # Lowest Priority: Direct PackageInfoFiles (new method)
    Write-Host "Using PackageInfoFiles parameter with $($PackageInfoFiles.Count) files"
    $ProcessedPackageInfoFiles = $PackageInfoFiles  # Use as-is
}
else {
    Write-Error "No package information provided. Please provide either 'PackageName', 'ArtifactList', or 'PackageInfoFiles' parameters."
    exit 1
}

# Validate that we have package info files to process
if (-not $ProcessedPackageInfoFiles -or $ProcessedPackageInfoFiles.Count -eq 0) {
    Write-Error "No package info files found after processing parameters."
    exit 1
}

$responses = @{}
Write-Host "Processed Package Info Files: $($ProcessedPackageInfoFiles -join ', ')"

# Process all packages using the processed PackageInfoFiles array
foreach ($packageInfoFile in $ProcessedPackageInfoFiles)
{
    $packageInfo = Get-Content $packageInfoFile | ConvertFrom-Json
    Write-Host "Processing $($packageInfo.ArtifactName)"
    $result = ProcessPackage -packageInfo $packageInfo
    $responses[$packageInfo.ArtifactName] = $result
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
