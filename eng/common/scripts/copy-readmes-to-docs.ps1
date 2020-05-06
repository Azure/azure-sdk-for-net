# Example Usage: ./copy-readmes-to-docs.ps1 -CodeRepo C:/repo/sdk-for-python -DocRepo C:/repo/azure-docs-sdk-python
# run the link updating script before this to get links fixed to the release
# Highly recommended that you use Powershell Core.
# git reset --hard origin/smoke-test on the doc repo prior to running this

param (
  [String]$CodeRepo,
  [String]$DocRepo,
  [String]$TargetServices
)

$PACKAGE_README_REGEX = ".*[\/\\]sdk[\\\/][^\/\\]+[\\\/][^\/\\]+[\/\\]README\.md" 

Write-Host "repo is $CodeRepo"

$date = Get-Date -Format "MM/dd/yyyy"

if ($CodeRepo -Match "net")
{
  $lang = ".NET"
  $TARGET_FOLDER = Join-Path -Path $DocRepo  -ChildPath "api/overview/azure"
  $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/dotnet-packages.csv"
}
if ($CodeRepo -Match "python"){
  $lang = "Python"
  $TARGET_FOLDER = Join-Path -Path $DocRepo  -ChildPath "docs-ref-services"
  $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/python-packages.csv"
}
if ($CodeRepo -Match "java"){
  $lang = "Java"
  $TARGET_FOLDER = Join-Path -Path $DocRepo  -ChildPath "docs-ref-services"
  $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/java-packages.csv"
}
if ($CodeRepo -Match "js"){
  $lang = "JavaScript"
  $TARGET_FOLDER = Join-Path -Path $DocRepo  -ChildPath "docs-ref-services"
  $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/js-packages.csv"
}



$metadataResponse = Invoke-WebRequest -Uri $metadataUri | ConvertFrom-Csv

if ([string]::IsNullOrWhiteSpace($TargetServices))
{
  $selectedServices = $metadataResponse | ForEach-Object -Process {$_.RepoPath} | Get-Unique
}
else {
  $selectedServices = $TargetServices -Split "," | % { return $_.Trim() }
}


foreach($service in $selectedServices){
  $readmePath = Join-Path -Path $CodeRepo  -ChildPath "sdk/$service"
  Write-Host "Examining: $readmePath" 

  $libraries = $metadataResponse | Where-Object { $_.RepoPath -eq $service }
  
  foreach($library in $libraries){

    $package = $library.Package
    $version = If ([string]::IsNullOrWhiteSpace($library.VersionGA)) {$library.VersionPreview} Else {$library.VersionGA}

    $file = Join-Path -Path $readmePath -ChildPath "/$package/README.md" | Get-Item
    Write-Host "`tOutputting $($file.FullName)"

    $fileContent = Get-Content $file

    $fileContent = $fileContent -Join "`n"

    $fileMatch = (Select-String -InputObject $fileContent -Pattern 'Azure .+? (client|plugin|shared) library for (JavaScript|Java|Python|\.NET)').Matches[0]

    $header = "---`r`ntitle: $fileMatch`r`nkeywords: Azure, $lang, SDK, API, $service, $package`r`nauthor: maggiepint`r`nms.author: magpint`r`nms.date: $date`r`nms.topic: article`r`nms.prod: azure`r`nms.technology: azure`r`nms.devlang: $lang`r`nms.service: $service`r`n---`r`n"

    $fileContent = $fileContent -replace $fileMatch, "$fileMatch - Version $version `r`n"

    $fileContent = "$header $fileContent"

    $readmeName = "$($file.Directory.Name.Replace('azure-','').Replace('Azure.', '').ToLower())-readme.md"

    $readmeOutputLocation = Join-Path $TARGET_FOLDER -ChildPath $readmeName

    Set-Content -Path $readmeOutputLocation -Value $fileContent
  }
}