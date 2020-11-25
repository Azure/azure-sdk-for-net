param(
  [string] $InputJsonPath = $GenerateInput,
  [string] $OutputJsonPath = $GenerateOutput,
  [string] $RepoRoot = "${PSScriptRoot}/../.."
)

$inputFileContent = Get-Content $InputJsonPath | ConvertFrom-Json
$inputFilePaths = $inputFileContent.changedFiles;
$inputFilePaths += $inputFileContent.relatedReadmeMdFiles;
$inputFilePaths = $inputFilePaths | Select-Object -Unique

$changedFilePaths = $inputFilePaths -join "`n";
Write-Host "List of changed swagger files and related readmes:`n$changedFilePaths`n"

$autorestFilesPath = Get-ChildItem -Path "$RepoRoot/sdk"  -Filter autorest.md -Recurse | Resolve-Path -Relative

Write-Host "Updating autorest.md files for all the changed swaggers."
$sdksInfo = @{}
$headSha = $inputFileContent.headSha
$repoHttpsUrl = $inputFileContent.repoHttpsUrl
foreach ($inputFilePath in $inputFilePaths) {
  foreach ($path in $autorestFilesPath) {
    $fileContent = Get-Content $path
    $isUpdatedLines = $false
    $updatedLines = foreach ($line in $fileContent) {
      $regexForMatchingShaAndPath = "[\/][0-9a-f]{4,40}[\/]$inputFilePath"
      if ($line -match $regexForMatchingShaAndPath) {
        $line -replace "https:\/\/[^`"]*$regexForMatchingShaAndPath", "$repoHttpsUrl/blob/$headSha/$inputFilePath"

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

function Test-PreviousScript() {
  $result = $null
  if ($LASTEXITCODE -eq 0) {
    $result = "succeeded"
  }
  else {
    $result = "failed"
  }
  Write-Host "Result: $result"
  return $result
}

$packages = @()
foreach ($sdkPath in $sdksInfo.Keys) {
  $packageName = Split-Path $sdkPath -Leaf
  Write-Host "Generating code for " $packageName
  $srcPath = Join-Path $sdkPath 'src'
  dotnet msbuild /restore /t:GenerateCode $srcPath

  $artifacts = @()
  $hasBreakingChange = $null
  $content = $null
  $result = Test-PreviousScript
  if ($result -eq "succeeded") {
    Write-Host "Successfully generated code for" $packageName "`n"
    
    $csprojPath = Get-ChildItem $srcPath -Filter *.csproj -Recurse
    dotnet pack $csprojPath /p:RunApiCompat=$false
    $result = Test-PreviousScript
    if ($result -eq "succeeded") {
      $artifactsPath = "$RepoRoot/artifacts/packages/Debug/$packageName"
      $artifacts += Get-ChildItem $artifactsPath -Filter *.nupkg -Recurse | Select-Object -ExpandProperty FullName | Resolve-Path -Relative

      $logFilePath = Join-Path "$srcPath" 'log.txt'
      if (!(Test-Path $logFilePath)) {
        New-Item $logFilePath
      }
      dotnet build $csprojPath /t:RunApiCompat /p:TargetFramework=netstandard2.0 /flp:v=m`;LogFile=$logFilePath
      
      $result = Test-PreviousScript
      if ($result -eq "succeeded") {
        $hasBreakingChange = $false
      }
      else {
        $logFile = Get-Content -Path $logFilePath | select-object -skip 2
        $breakingChanges = $logFile -join ",`n"
        $content = "Breaking Changes: $breakingChanges"
        $hasBreakingChange = $true
        $result = "succeeded"
      }

      if (Test-Path $logFilePath) {
        Remove-Item $logFilePath
      }
    }
  } 
  else {
    Write-Error "Error occurred while generating code for" $packageName "`n"
  }

  $path = @()
  $path += $sdkPath

  $readmeMd = @()
  $readmeMd += $sdksInfo[$sdkPath]

  $changelog = [PSCustomObject]@{
    content           = $content
    hasBreakingChange = $hasBreakingChange
  }

  $downloadUrlPrefix = $inputFileContent.installInstructionInput.downloadUrlPrefix
  $fileName = Split-Path $artifacts[0] -Leaf
  $installInstructions = [PSCustomObject]@{
    full = "Download the $packageName package from [here]($downloadUrlPrefix/$fileName)"
    lite = "Download the $packagename package from [here]($downloadUrlPrefix/$fileName)"
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
