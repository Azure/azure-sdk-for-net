[CmdletBinding()]
Param (
  [Parameter(Mandatory=$True)]
  [string] $ArtifactPath,
  [Parameter(Mandatory=$True)]
  [string] $APIViewUri,
  [Parameter(Mandatory=$True)]
  [string] $APIKey,
  [Parameter(Mandatory=$True)]
  [string] $APILabel,
  [string] $PackageName,
  [string] $ConfigFileDir = ""
)


# Submit API review request and return status whether current revision is approved or pending or failed to create review
function Submit-APIReview($packagename, $filePath, $uri, $apiKey, $apiLabel)
{
    $multipartContent = [System.Net.Http.MultipartFormDataContent]::new()
    $FileStream = [System.IO.FileStream]::new($filePath, [System.IO.FileMode]::Open)
    $fileHeader = [System.Net.Http.Headers.ContentDispositionHeaderValue]::new("form-data")
    $fileHeader.Name = "file"
    $fileHeader.FileName = $packagename
    $fileContent = [System.Net.Http.StreamContent]::new($FileStream)
    $fileContent.Headers.ContentDisposition = $fileHeader
    $fileContent.Headers.ContentType = [System.Net.Http.Headers.MediaTypeHeaderValue]::Parse("application/octet-stream")
    $multipartContent.Add($fileContent)


    $stringHeader = [System.Net.Http.Headers.ContentDispositionHeaderValue]::new("form-data")
    $stringHeader.Name = "label"
    $StringContent = [System.Net.Http.StringContent]::new($apiLabel)
    $StringContent.Headers.ContentDisposition = $stringHeader
    $multipartContent.Add($stringContent)

    $headers = @{
        "ApiKey" = $apiKey;
        "content-type" = "multipart/form-data"
    }

    try
    {
        $Response = Invoke-WebRequest -Method 'POST' -Uri $uri -Body $multipartContent -Headers $headers
        Write-Host "API Review URL: $($Response.Content)"
        $StatusCode = $Response.StatusCode
    }
    catch
    {
        Write-Host "Exception details: $($_.Exception.Response)"
        $StatusCode = $_.Exception.Response.StatusCode
    }

    return $StatusCode
}


. (Join-Path $PSScriptRoot common.ps1)
$packages = @{}
if ($FindArtifactForApiReviewFn -and (Test-Path "Function:$FindArtifactForApiReviewFn"))
{
    $packages = &$FindArtifactForApiReviewFn $ArtifactPath $PackageName
}
else
{
    Write-Host "The function for 'FindArtifactForApiReviewFn' was not found.`
    Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
    See https://github.com/Azure/azure-sdk-tools/blob/master/doc/common/common_engsys.md#code-structure"
    exit(1)
}

$responses = @{}
if ($packages)
{
    foreach($pkg in $packages.Keys)
    {
        Write-Host "Submitting API Review for package $($pkg)"
        Write-Host $packages[$pkg]
        $responses[$pkg] = Submit-APIReview -packagename $pkg -filePath $packages[$pkg] -uri $APIViewUri -apiKey $APIKey -apiLabel $APILabel
    }
}
else
{
    Write-Host "No package is found in artifact path to submit review request"
}

$FoundFailure = $False
if (-not $ConfigFileDir)
{
    $ConfigFileDir = Join-Path -Path $ArtifactPath "PackageInfo"
}
foreach ($pkgName in $responses.Keys)
{    
    $respCode = $responses[$pkgName]
    if ($respCode -ne '200')
    {
        $pkgPropPath = Join-Path -Path $ConfigFileDir "$PackageName.json"
        if (-Not (Test-Path $pkgPropPath))
        {
            Write-Host " Package property file path $($pkgPropPath) is invalid."
        }
        else
        {
            $pkgInfo = Get-Content $pkgPropPath | ConvertFrom-Json
            $version = [AzureEngSemanticVersion]::ParseVersionString($pkgInfo.Version)
            Write-Host "Package name: $($PackageName)"
            Write-Host "Version: $($version)"
            Write-Host "SDK Type: $($pkgInfo.SdkType)"
            if ($version.IsPrerelease)
            {
                Write-Host "Package version is not GA. Ignoring API view approval status"
            }
            elseif ($pkgInfo.SdkType -eq "client" -and $pkgInfo.IsNewSdk)
            {
                $FoundFailure = $True
                if ($respCode -eq '201')
                {
                    Write-Host "Package version $($version) is GA and automatic API Review is not yet approved for package $($PackageName)."
                    Write-Host "Build and release is not allowed for GA package without API review approval."
                    Write-Host "You will need to queue another build to proceed further after API review is approved"
                    Write-Host "You can check http://aka.ms/azsdk/engsys/apireview/faq for more details on API Approval."
                }
                else
                {
                    Write-Host "Failed to create API Review for package $($PackageName). Please reach out to Azure SDK engineering systems on teams channel and share this build details."
                }
                exit 1
            }
            else
            {
                Write-Host "API review is not approved for package $($PackageName). Management and track1 package can be released without API review approval."
            }      
        }
    }
}
