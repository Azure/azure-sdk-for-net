<#
.SYNOPSIS
Creates APIView revisions for SDK packages.

.DESCRIPTION
Uploads package artifacts directly to APIView or creates revisions from pre-generated review token files.
#>
[CmdletBinding()]
param (
    [Parameter(Mandatory = $false)]
    [array] $ArtifactList,

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $ArtifactPath,

    [string] $SourceBranch,
    [string] $DefaultBranch,
    [string] $RepoName,
    [string] $BuildId,
    [string] $PackageName = "",
    [string] $ConfigFileDir = "",
    [string] $APIViewUri = "https://apiview.dev/autoreview",
    [string] $ArtifactName = "packages",

    [Parameter(Mandatory = $false)]
    [array] $PackageInfoFiles
)

Set-StrictMode -Version 4
$ErrorActionPreference = "Stop"

. (Join-Path $PSScriptRoot common.ps1)

function Get-ApiViewBearerToken {
    $tokenResponse = az account get-access-token --resource "api://apiview" --output json 2>&1
    if ($LASTEXITCODE -ne 0) {
        throw "Failed to acquire APIView access token: $tokenResponse"
    }

    try {
        $accessToken = ($tokenResponse | ConvertFrom-Json -ErrorAction Stop).accessToken
    }
    catch {
        throw "Failed to parse APIView access token response: $($_.Exception.Message)"
    }

    if ([string]::IsNullOrWhiteSpace($accessToken)) {
        throw "APIView access token response did not contain an access token."
    }

    return $accessToken
}

function Invoke-ApiViewSourceUpload(
    [string] $FilePath,
    [string] $ApiLabel,
    [string] $ReleaseStatus,
    [string] $PackageVersion,
    [string] $PackageType
) {
    $fileName = Split-Path -Leaf $FilePath
    Write-Host "Uploading $FilePath to APIView."

    $multipartContent = [System.Net.Http.MultipartFormDataContent]::new()
    $fileStream = $null
    try {
        $fileStream = [System.IO.FileStream]::new($FilePath, [System.IO.FileMode]::Open)
        $fileHeader = [System.Net.Http.Headers.ContentDispositionHeaderValue]::new("form-data")
        $fileHeader.Name = "file"
        $fileHeader.FileName = $fileName
        $fileContent = [System.Net.Http.StreamContent]::new($fileStream)
        $fileContent.Headers.ContentDisposition = $fileHeader
        $fileContent.Headers.ContentType = [System.Net.Http.Headers.MediaTypeHeaderValue]::Parse("application/octet-stream")
        $multipartContent.Add($fileContent)

        Add-MultipartString $multipartContent "label" $ApiLabel
        Add-MultipartString $multipartContent "packageVersion" $PackageVersion
        Add-MultipartString $multipartContent "setReleaseTag" "False"
        Add-MultipartString $multipartContent "packageType" $PackageType
        if ($ReleaseStatus -and $ReleaseStatus -ne "Unreleased") {
            Add-MultipartString $multipartContent "compareAllRevisions" "True"
        }

        $headers = @{ Authorization = "Bearer $(Get-ApiViewBearerToken)" }
        $response = Invoke-WebRequest -Method Post -Uri "$APIViewUri/upload" -Body $multipartContent -Headers $headers
        Write-Host "API review: $($response.Content)"
        Write-Host "HTTP response code: $($response.StatusCode)"
    }
    finally {
        $multipartContent.Dispose()
        if ($null -ne $fileStream) {
            $fileStream.Dispose()
        }
    }
}

function Add-MultipartString(
    [System.Net.Http.MultipartFormDataContent] $MultipartContent,
    [string] $Name,
    [string] $Value
) {
    $header = [System.Net.Http.Headers.ContentDispositionHeaderValue]::new("form-data")
    $header.Name = $Name
    $content = [System.Net.Http.StringContent]::new($Value)
    $content.Headers.ContentDisposition = $header
    $MultipartContent.Add($content)
    Write-Host "Request param, ${Name}: $Value"
}

function Invoke-ApiViewTokenCreation(
    [object] $PackageInfo,
    [string] $ApiLabel,
    [string] $ReviewFileName,
    [string] $PackagePath
) {
    $fileName = Split-Path -Leaf $PackagePath
    $queryParameters = [ordered]@{
        buildId = $BuildId
        artifactName = $ArtifactName
        originalFilePath = $fileName
        reviewFilePath = $ReviewFileName
        label = $ApiLabel
        repoName = $RepoName
        packageName = $PackageInfo.ArtifactName
        project = "internal"
        packageVersion = $PackageInfo.Version
        packageType = $PackageInfo.SdkType
    }
    if ($PackageInfo.ReleaseStatus -and $PackageInfo.ReleaseStatus -ne "Unreleased") {
        $queryParameters["compareAllRevisions"] = "true"
    }

    $query = @($queryParameters.GetEnumerator() | ForEach-Object {
        "$([System.Uri]::EscapeDataString($_.Key))=$([System.Uri]::EscapeDataString($_.Value))"
    }) -join "&"
    $uri = "$APIViewUri/create?$query"
    Write-Host "Creating APIView revision from review token file $ReviewFileName."
    Write-Host "Request to APIView: $uri"
    $headers = @{ Authorization = "Bearer $(Get-ApiViewBearerToken)" }
    $response = Invoke-WebRequest -Method Post -Uri $uri -Headers $headers
    Write-Host "API review: $($response.Content)"
    Write-Host "HTTP response code: $($response.StatusCode)"
}

function Get-ApiReviewTokenFileName([string] $ArtifactName) {
    $reviewTokenFileName = "${ArtifactName}_${LanguageShort}.json"
    $tokenFilePath = Join-Path $ArtifactPath $ArtifactName $reviewTokenFileName
    if (Test-Path $tokenFilePath) {
        Write-Host "Review token file is present at $tokenFilePath"
        return $reviewTokenFileName
    }

    Write-Host "Review token file is not present at $tokenFilePath"
    return $null
}

function Submit-ApiViewRevision([object] $PackageInfo, [string] $PackagePath) {
    $apiLabel = "Source Branch:$SourceBranch"
    $reviewTokenFileName = Get-ApiReviewTokenFileName $PackageInfo.ArtifactName
    if ($reviewTokenFileName) {
        Invoke-ApiViewTokenCreation $PackageInfo $apiLabel $reviewTokenFileName $PackagePath
        return
    }

    Invoke-ApiViewSourceUpload $PackagePath $apiLabel $PackageInfo.ReleaseStatus $PackageInfo.Version $PackageInfo.SdkType
}

function Find-PackageArtifacts([object] $PackageInfo) {
    if (-not $FindArtifactForApiReviewFn -or -not (Test-Path "Function:$FindArtifactForApiReviewFn")) {
        throw "The function configured by 'FindArtifactForApiReviewFn' was not found."
    }

    $artifactName = if ($PackageInfo.ArtifactName) { $PackageInfo.ArtifactName } else { $PackageInfo.Name }
    $functionInfo = Get-Command $FindArtifactForApiReviewFn -ErrorAction Stop
    if ($functionInfo.Parameters.Keys -contains "packageInfo") {
        return &$FindArtifactForApiReviewFn $ArtifactPath $PackageInfo
    }

    return &$FindArtifactForApiReviewFn $ArtifactPath $artifactName
}

function Process-Package([object] $PackageInfo) {
    $packages = Find-PackageArtifacts $PackageInfo
    if (-not $packages) {
        Write-Host "No package is found in artifact path to submit a review request for $($PackageInfo.ArtifactName)."
        return
    }

    $version = [AzureEngSemanticVersion]::ParseVersionString($PackageInfo.Version)
    if ($null -eq $version) {
        throw "Version '$($PackageInfo.Version)' for package $($PackageInfo.ArtifactName) is invalid."
    }

    Write-Host "Version: $version"
    Write-Host "SDK Type: $($PackageInfo.SdkType)"
    Write-Host "Release Status: $($PackageInfo.ReleaseStatus)"
    if ($SourceBranch -ne $DefaultBranch -and $version.IsPrerelease) {
        Write-Host "Build is triggered from $SourceBranch with a prerelease version. Skipping APIView revision creation."
        return
    }

    foreach ($packagePath in $packages.Values) {
        Write-Host "Submitting APIView revision for package $($PackageInfo.ArtifactName), file path: $packagePath"
        Submit-ApiViewRevision $PackageInfo $packagePath
    }
}

function Resolve-PackageInfoFiles {
    if (-not $ConfigFileDir) {
        $script:ConfigFileDir = Join-Path $ArtifactPath "PackageInfo"
    }

    if ($PackageName) {
        $packageInfoPath = Join-Path $ConfigFileDir "$PackageName.json"
        if (-not (Test-Path $packageInfoPath)) {
            throw "Package property file path $packageInfoPath is invalid."
        }
        return @($packageInfoPath)
    }

    if ($ArtifactList -and $ArtifactList.Count -gt 0) {
        $files = @()
        foreach ($artifact in $ArtifactList) {
            $packageInfoPath = Join-Path $ConfigFileDir "$($artifact.Name).json"
            if (Test-Path $packageInfoPath) {
                $files += $packageInfoPath
            }
            else {
                Write-Warning "Package property file path $packageInfoPath is invalid."
            }
        }
        return $files
    }

    if ($PackageInfoFiles -and $PackageInfoFiles.Count -gt 0) {
        return @($PackageInfoFiles | Where-Object { -not [string]::IsNullOrWhiteSpace($_) })
    }

    throw "No package information provided. Provide PackageName, ArtifactList, or PackageInfoFiles."
}

Write-Host "Artifact path: $ArtifactPath"
Write-Host "Source branch: $SourceBranch"
Write-Host "Package name: $PackageName"

$processedPackageInfoFiles = @(Resolve-PackageInfoFiles)
if ($processedPackageInfoFiles.Count -eq 0) {
    throw "No package info files found after processing the supplied package inputs."
}

$failures = @()
foreach ($packageInfoFile in $processedPackageInfoFiles) {
    try {
        $packageInfo = Get-Content $packageInfoFile -Raw | ConvertFrom-Json -ErrorAction Stop
        Write-Host "Processing $($packageInfo.ArtifactName)"
        Process-Package $packageInfo
    }
    catch {
        Write-Error "Failed to create an APIView revision from ${packageInfoFile}: $($_.Exception.Message)" -ErrorAction Continue
        $failures += $packageInfoFile
    }
}

if ($failures.Count -gt 0) {
    throw "APIView revision creation failed for $($failures.Count) package(s)."
}
