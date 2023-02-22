function Get-CodeownersTool([string] $ToolPath, [string] $DevOpsFeed, [string] $ToolVersion)
{
  $codeownersToolCommand = Join-Path $ToolPath "retrieve-codeowners"
  # Check if the retrieve-codeowners tool exists or not.
  if (Get-Command $codeownersToolCommand -errorAction SilentlyContinue) {
    return $codeownersToolCommand
  }
  if (!(Test-Path $ToolPath)) {
    New-Item -ItemType Directory -Path $ToolPath | Out-Null
  }
  Write-Host "Installing the retrieve-codeowners tool under tool path: $ToolPath ..."

  # Run command under tool path to avoid dotnet tool install command checking .csproj files. 
  # This is a bug for dotnet tool command. Issue: https://github.com/dotnet/sdk/issues/9623
  Push-Location $ToolPath
  dotnet tool install --tool-path $ToolPath --add-source $DevOpsFeed --version $ToolVersion "Azure.Sdk.Tools.RetrieveCodeOwners" | Out-Null
  Pop-Location
  # Test to see if the tool properly installed.
  if (!(Get-Command $codeownersToolCommand -errorAction SilentlyContinue)) {
    Write-Error "The retrieve-codeowners tool is not properly installed. Please check your tool path: $ToolPath"
    return 
  }
  return $codeownersToolCommand
}

function Get-Codeowners(
  [string] $ToolPath, 
  [string] $DevOpsFeed,
  [string] $ToolVersion,
  [string] $VsoVariable,
  [string] $targetPath,
  [string] $targetDirectory,
  [string] $codeownersFileLocation,
  [bool] $includeNonUserAliases = $false)
{
  # Backward compaitiblity: if $targetPath is not provided, fall-back to the legacy $targetDirectory
  if ([string]::IsNullOrWhiteSpace($targetPath)) {
    $targetPath = $targetDirectory
  }
  if ([string]::IsNullOrWhiteSpace($targetPath)) {
    Write-Error "TargetPath (or TargetDirectory) parameter must be neither null nor whitespace."
    return ,@()
  }

  $codeownersToolCommand = Get-CodeownersTool -ToolPath $ToolPath -DevOpsFeed $DevOpsFeed -ToolVersion $ToolVersion
  Write-Host "Executing: & $codeownersToolCommand --target-path $targetPath --codeowners-file-path-or-url $codeownersFileLocation --exclude-non-user-aliases:$(!$includeNonUserAliases)"
  $commandOutput = & $codeownersToolCommand `
      --target-path $targetPath `
      --codeowners-file-path-or-url $codeownersFileLocation `
      --exclude-non-user-aliases:$(!$includeNonUserAliases) `
      2>&1

  if ($LASTEXITCODE -ne 0) {
    Write-Host "Command $codeownersToolCommand execution failed (exit code = $LASTEXITCODE). Output string: $commandOutput"
    return ,@()
  } else
  {
    Write-Host "Command $codeownersToolCommand executed successfully (exit code = 0). Output string length: $($commandOutput.length)"
  }

# Assert: $commandOutput is a valid JSON representing:
# - a single CodeownersEntry, if the $targetPath was a single path
# - or a dictionary of CodeownerEntries, keyes by each path resolved from a $targetPath glob path.
#
# For implementation details, see Azure.Sdk.Tools.RetrieveCodeOwners.Program.Main

$codeownersJson = $commandOutput | ConvertFrom-Json
  
  if ($VsoVariable) {
    $codeowners = $codeownersJson.Owners -join ","
    Write-Host "##vso[task.setvariable variable=$VsoVariable;]$codeowners"
  }

  return ,@($codeownersJson.Owners)
}