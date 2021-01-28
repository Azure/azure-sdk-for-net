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
  [string] $PackageName = ""
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
        $StatusCode = $Response.StatusCode
    }
    catch
    {
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
    Write-Host "Function 'FindArtifactForApiReviewFn' is not found"
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
foreach ($pkgName in $responses.Keys)
{    
    $respCode = $responses[$pkgName]
    if ($respCode -ne '200')
    {
        $FoundFailure = $True
        if ($respCode -eq '201')
        {
            Write-Host "API Review is pending for package $pkgName"
        }
        else
        {
            Write-Host "Failed to create API Review for package $pkgName"
        }
    }
}
if ($FoundFailure)
{
    Write-Host "Atleast one API review is not yet approved"
}
