[CmdletBinding()]
param(
  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $InputJsonPath,

  [Parameter()]
  [string] $OutputJsonPath,

  [Parameter()]
  [string] $RepoRoot = "${PSScriptRoot}/../.."
)

$inputFileContent = Get-Content $InputJsonPath | ConvertFrom-Json
[string[]] $inputFilePaths = $inputFileContent.changedFiles;
$inputFilePaths += $inputFileContent.relatedReadmeMdFiles;
$inputFilePaths = $inputFilePaths | Select-Object -Unique

$changedFilePaths = $inputFilePaths -join "`n";
Write-Host "List of changed swagger files and related readmes:`n$changedFilePaths`n"

$autorestFilesPath = Get-ChildItem -Path "$RepoRoot/sdk"  -Filter autorest.md -Recurse | Resolve-Path -Relative

Write-Host "Updating autorest.md files for all the changed swaggers."
$sdksInfo = @{}
$headSha = $inputFileContent.headSha
$repoHttpsUrl = $inputFileContent.repoHttpsUrl
foreach ($path in $autorestFilesPath) {
  $fileContent = Get-Content $path
  foreach ($inputFilePath in $inputFilePaths) {
    $isUpdatedLines = $false
    $escapedInputFilePath = [System.Text.RegularExpressions.Regex]::Escape($inputFilePath)
    $regexForMatchingShaAndPath = "https:\/\/[^`"]*[\/][0-9a-f]{4,40}[\/]$escapedInputFilePath"
    $updatedLines = foreach ($line in $fileContent) {
      if ($line -match $regexForMatchingShaAndPath) {
        $line -replace $regexForMatchingShaAndPath, "$repoHttpsUrl/blob/$headSha/$inputFilePath"

        $isUpdatedLines = $true
        $sdkpath = (get-item $path).Directory.Parent.FullName | Resolve-Path -Relative
        if (!$sdksInfo.ContainsKey($sdkpath)) {
          $specReadmePath = $inputFileContent.relatedReadmeMdFiles -match $inputFilePath
          $sdksInfo.Add($sdkpath, $specReadmePath)
        }
      }
      else {
        $line
      }
    }
    if ($isUpdatedLines) {
      $updatedLines | Out-File -FilePath $path
    }
  }
}

Write-Host "Updated autorest.md files for all the changed swaggers. `n"

$packages = @()
$dotnet = Join-Path $RepoRoot ".dotnet"
$env:PATH = "$dotnet`:" + $env:PATH
foreach ($sdkPath in $sdksInfo.Keys) {
  $packageName = Split-Path $sdkPath -Leaf
  Write-Host "Generating code for " $packageName
  $artifacts = @()
  $hasBreakingChange = $null
  $content = $null
  $srcPath = Join-Path $sdkPath 'src'
  dotnet msbuild /restore /t:GenerateCode $srcPath
  if (!$LASTEXITCODE) {
    $result = "succeeded"
    Write-Host "Successfully generated code for" $packageName "`n"
    
    dotnet pack $srcPath /p:RunApiCompat=$false
    if (!$LASTEXITCODE) {
      $result = "succeeded"
      $artifactsPath = "$RepoRoot/artifacts/packages/Debug/$packageName"
      $artifacts += Get-ChildItem $artifactsPath -Filter *.nupkg -Recurse | Select-Object -ExpandProperty FullName | Resolve-Path -Relative
      
      $logFilePath = Join-Path "$srcPath" 'log.txt'
      if (!(Test-Path $logFilePath)) {
        New-Item $logFilePath
      }
      dotnet build $srcPath /t:RunApiCompat /p:TargetFramework=netstandard2.0 /flp:v=m`;LogFile=$logFilePath
      if (!$LASTEXITCODE) {
        $hasBreakingChange = $false
      }
      else {
        $logFile = Get-Content -Path $logFilePath | select-object -skip 2
        $breakingChanges = $logFile -join ",`n"
        $content = "Breaking Changes: $breakingChanges"
        $hasBreakingChange = $true
      }

      if (Test-Path $logFilePath) {
        Remove-Item $logFilePath
      }
    }
    else {
      $result = "failed"
      Write-Error "Error occurred while generating artifacts for $packageName `n"
    }
  } 
  else {
    $result = "failed"
    Write-Error "Error occurred while generating code for $packageName `n"
  }

  $path = , $sdkPath

  $readmeMd = $sdksInfo[$sdkPath]

  $changelog = [PSCustomObject]@{
    content           = $content
    hasBreakingChange = $hasBreakingChange
  }

  $downloadUrlPrefix = $inputFileContent.installInstructionInput.downloadUrlPrefix
  $full = $null
  if ($artifacts.count -gt 0) {
    $fileName = Split-Path $artifacts[0] -Leaf
    $full = "Download the $packageName package from [here]($downloadUrlPrefix/$fileName)"
  }
  $installInstructions = [PSCustomObject]@{
    full = $full
    lite = $full
  }

  $packageInfo = [PSCustomObject]@{
    packageName         = $packageName
    path                = $path
    readmeMd            = $readmeMd
    changelog           = $changelog
    artifacts           = $artifacts
    installInstructions = $installInstructions
    result              = $result
  }
  $packages += $packageInfo
}

if ($OutputJsonPath) {
  Write-Host "`nGenerating output JSON..."
  ConvertTo-Json @{
    packages = $packages
  } -depth 5 | Out-File -FilePath $OutputJsonPath
}
